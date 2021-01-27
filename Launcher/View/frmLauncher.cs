using ScanLauncher.Common;
using ScanLauncher.Config;
using ScanLauncher.Core;
using ScanLauncher.Data;
using ScanLauncher.Service;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Windows.Forms;


namespace ScanLauncher.View
{
    public partial class frmLauncher : BaseForm, IScanForm
    {
        public frmLauncher()
        {
            InitializeComponent();

            InitializeProperties();

            InitializeResource();

            InitializeEvent();

            InitializeTempDirectory();
        }

        #region Variable
        private HttpListenerHelper httpListenerHelper;        
        private LauncherService launcherService = null;          
        private List<ProcessItem> SvrProcessData = null;
        private int lastSecurityId = -1;        
        private frmAboutBox formAboutBox = null;
        private frmInit formInit = null;
        private frmHistory formHistory = null;
        private frmVersionSync fVersionSync = null;
        private RunHistoryItem runHistoryItem;


        #endregion

        #region Initialize

        public override void InitializeResource()
        {   
            IsFirstRun = true;
            lstAccessDateTime = DateTime.Now;
            overlapSeconds = ApplicationConfig.OverlapSeconds;
            RequestHistoryHelper.InitializeResource();
        }

        private void InitializeProperties()
        {
            ApplicationConfig.InitializeAppSettings();
            lastSecurityId = Properties.Settings.Default.LastSecurityId;
            CryptographyHelper.AES.InitLastRequestIndex(lastSecurityId);

            runHistoryItem = new RunHistoryItem
            {
                IsRun = false,
                ServerHost = ApplicationConfig.ServerHost,
                ServerInfo = ApplicationConfig.Mode,                
                CreateDate = DateTime.Now.ToString(),
            };
        }

        public override void InitializeEvent()
        {
            this.Load += FrmLauncher_Load;
            this.miVersionSync.Click += MiVersionSync_Click;
            this.miImageWatcher.Click += MiImageWatcher_Click;
            this.miHistory.Click += MiHistory_Click;
            this.miInfo.Click += MiInfo_Click;
            this.miExit.Click += MiExit_Click;
            this.miInit.Click += MiInit_Click;
            Application.ApplicationExit += Application_ApplicationExit;
        }

        private void InitializeTempDirectory()
        {
            FileHelper.ClearTempPathByStartsWith("ScanLauncher");
        }

        #endregion

        #region Create

        /// <summary>
        /// 최신버전 동기화
        /// </summary>
        private void CreateVersionSync()
        {
            if (fVersionSync != null)
            {
                try
                {
                    fVersionSync.Dispose();
                    fVersionSync = null;
                }
                finally
                { }
            }

            IsRunning = true;

            try
            {
                ShowBalloonTip("최신버전 동기화를 시작합니다.", ToolTipIcon.None, false);

                fVersionSync = new frmVersionSync();
                fVersionSync.ProcessChanged += FVersionSync_ProcessChanged;
                fVersionSync.FormClosed += FVersionSync_FormClosed;
                fVersionSync.ShowDialog(this);
            }
            catch (Exception ex)
            {
                ShowBalloonTip(ex.Message, ToolTipIcon.Error, false);
            }
            finally
            {
                IsRunning = false;
            }
        }
        
        /// <summary>
        /// 웹소켓
        /// </summary>
        private void CreateListener()
        {
            string httpListenerUrl = ApplicationConfig.HttpListenerConfig.ListenerUrl;
            string message = "";

            httpListenerHelper = new HttpListenerHelper(SendResponse, httpListenerUrl);
            message = httpListenerHelper.Runs(this);

            if (string.IsNullOrEmpty(message))
            {
                runHistoryItem.IsRun = true;
                runHistoryItem.WebSocketInfo = httpListenerUrl;
            }
            else
            {
                runHistoryItem.IsRun = false;
            }
        }



        /// <summary>
        /// 런처 서비스
        /// </summary>
        private void CreateListenerService()
        {
            if (launcherService != null)
            {
                launcherService = null;
            }

            launcherService = new LauncherService();
            launcherService.LauncherStatusChanged += LauncherService_LauncherStatusChanged;
            SvrProcessData = launcherService.SvrProcessData;
        }

        #endregion

        #region WebSocket

        /// <summary>
        /// WebSocket HttpListener
        /// </summary>
        /// <param name="frm"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public static string SendResponse(BaseForm frm, HttpListenerRequest request)
        {
            string result = string.Empty;

            try
            {
                if (frm.InvokeRequired)
                {
                    frm.Invoke(new MethodInvoker(delegate ()
                    {
                        if (frm.IsRunning == false)
                        {
                            var idx = RequestHistoryHelper.AddItem(request);
                            frm.ShowForm(request, idx);
                        }
                    }));
                }
            }
            catch (Exception ex)
            {
                result = string.Format("Fail, {0}, {1}", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), ex.Message);
                return MessageHelper.HttpResponseMessage(result);
            }

            if (frm.IsRunning)
            {                
                result = string.Format("Running, {0}, {1}", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), request.QueryString.Count);
            }
            else
            {
                result = string.Format("Success, {0}, {1}", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), request.QueryString.Count);
            }

            return MessageHelper.HttpResponseMessage(result);
        }

        /// <summary>
        /// WebSocket Process
        /// </summary>
        /// <param name="r"></param>
        /// <param name="i"></param>
        public override void ShowForm(HttpListenerRequest r, int i)
        {
            var host = r.UrlReferrer == null ? string.Empty : r.UrlReferrer.Host;
            var pid = r.QueryString[KeyContext.QueryKey.ProcessId];
            var sid = r.QueryString[KeyContext.QueryKey.SecurityId];
            var mode = r.QueryString[KeyContext.QueryKey.Mode];
            var authcode = r.QueryString[KeyContext.QueryKey.AuthCode]; //AES
            bool isRun = false;

            try
            {
                this.Cursor = Cursors.WaitCursor;
                //연속호출 체크
                if (CheckOverlapRequest() == false) return;

                this.Cursor = Cursors.WaitCursor;
                string message = string.Empty;
                string eninsttcd = string.Empty;
                string enuserid = string.Empty;
                int sindex = -1;

                if (string.IsNullOrEmpty(pid) || string.IsNullOrEmpty(sid) || string.IsNullOrEmpty(mode) || string.IsNullOrEmpty(authcode))
                {
                    ShowBalloonTip("필수 매겨변수가 누락되었습니다.", ToolTipIcon.Error);
                    return;
                }

                //개발모드가 아니면 도메인 체크
                //if (ApplicationConfig.DevMode == false)
                //{
                //    if (string.IsNullOrEmpty(host) ||
                //        host.Equals(ApplicationConfig.ServerHostName, StringComparison.CurrentCultureIgnoreCase) == false)
                //    {
                //        ShowBalloonTip("정상적인 접근이 아닙니다.", ToolTipIcon.Error);
                //        return;
                //    }
                //}

                sindex = GetSecurityIndex(sid);

                if (sindex < 0 || lastSecurityId.Equals(sindex))
                {
                    ShowBalloonTip("정상적인 요청이 아닙니다.", ToolTipIcon.Error);
                    return;
                }

                //복호화
                string[] dec = GetDecryptUserId(sindex, authcode);

                if (string.IsNullOrEmpty(dec[0]) || string.IsNullOrEmpty(dec[1]))
                {
                    ShowBalloonTip("복호화에 실패했습니다 \r\n 다시 호출해 주십시오.", ToolTipIcon.Error);
                    return;
                }

                if (Request == null ||
                    Request.CORR_INSTT_CD.Equals(dec[0], StringComparison.CurrentCultureIgnoreCase) == false ||
                    Request.USR_ID.Equals(dec[1], StringComparison.CurrentCultureIgnoreCase) == false)
                {
                    //사용자 정보 조회
                    isRun = SetUserAuthInfo(dec);
                }
                else
                {
                    //마지막 호출 사용자와 현재 호출 사용자 비교
                    isRun = (Request.CORR_INSTT_CD.Equals(dec[0], StringComparison.CurrentCultureIgnoreCase) &&
                        Request.USR_ID.Equals(dec[1], StringComparison.CurrentCultureIgnoreCase));
                }

                if (isRun == false || Request == null || string.IsNullOrEmpty(Request.USR_ID))
                {
                    ShowBalloonTip("사용자 인증에 실패 하였습니다.", ToolTipIcon.Error);
                    return;
                }
                else
                {
                    launcherService.ClearProcess(pid);
                }

                if (launcherService.Status == LauncherRunStatus.IsRuning)
                {
                    RequestHistoryHelper.GetActiveItem(i).Message = string.Empty;
                    RequestHistoryHelper.GetActiveItem(i).State = "Complete";

                    ProcessItem item = GetProcessInfo(r.QueryString);

                    string prgName = launcherService.RunAt(item);

                    if (string.IsNullOrEmpty(prgName) == false)
                    {
                        InteropHelper.SwitchToThisWindowApp(prgName);
                    }
                }
                else
                {
                    if (launcherService.Status.Equals(LauncherRunStatus.IsRuning) == false)
                    {
                        ShowBalloonTip("요청을 수행 할 수 없습니다. \r\n 프로그램을 다시 시작해 주십시오.", ToolTipIcon.Error);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                ShowBalloonTip(ex.Message, ToolTipIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private int GetSecurityIndex(object sid)
        {
            int index = -1;

            try
            {
                index = Convert.ToInt32(sid);

                if (index < 0 || index > 100)
                {
                    index = -1;
                }
            }
            catch
            {
                index = -1;
            }

            return index;
        }

        /// <summary>
        /// 요청사용자 복호화 정보
        /// </summary>
        /// <param name="index"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        private string[] GetDecryptUserId(int index, string authData)
        {
            string[] obj = new string[2];
            string result = string.Empty;
            DateTime svrDate;
                
            using (AuthService service = new AuthService())
            {
                svrDate = service.GetServerDate();
            }

            try
            {
                result = CryptographyHelper.AES.Decrypt(authData, index, "sc" + svrDate.ToString("yyyyMMdd"), false);

                if (string.IsNullOrEmpty(result) == false)
                {
                    string[] auth = result.Split('|');

                    if (auth.Count() == 2)
                    {
                        //교정기관코드
                        obj[0] = auth[0];
                        //사용자아이디
                        obj[1] = auth[1];
                    }
                }
            }
            catch
            {
                result = string.Empty;
            }
            finally
            {
                lastSecurityId = index;
            }

            return obj;
        }

        private bool SetUserAuthInfo(string[] dec)
        {
            bool result = false;

            // 개발자모드일경우 사용자인증X
            if (ApplicationConfig.Mode == "D")
            {
                Request = new RequestItem();
                Request.CORR_INSTT_CD = dec[0];
                Request.USR_ID = dec[1];
                result = true;
            }
            else
            {
                //서비스 호출 로직
                using (AuthService service = new AuthService())
                {
                    Request = service.GetUserInfo(dec[0], dec[1]);
                }

                if (Request == null)
                    result = false;
                else
                {
                    result = (Request.CORR_INSTT_CD.Equals(dec[0], StringComparison.CurrentCultureIgnoreCase) &&
                        Request.USR_ID.Equals(dec[1], StringComparison.CurrentCultureIgnoreCase));
                }
            }

            return result;
        }

        private ProcessItem GetProcessInfo(NameValueCollection queryString)
        {
            var mlsfc = queryString[KeyContext.QueryKey.Mlsfc];
            var sclas = queryString[KeyContext.QueryKey.Sclas];
            var processname = queryString[KeyContext.QueryKey.ProcessId];
            Request.R_MODE = queryString[KeyContext.QueryKey.RequestMode];

            ProcessItem item = SvrProcessData.Find(x => x.ProcessName.Equals(processname, StringComparison.CurrentCultureIgnoreCase));

            if (item != null)
            {
                Request.LCLAS_CD = queryString[KeyContext.QueryKey.Mode].ToUpper();
                Request.MLSFC_CD = string.IsNullOrEmpty(mlsfc) ? string.Empty : mlsfc.ToUpper();
                Request.SCLAS_CD = string.IsNullOrEmpty(sclas) ? string.Empty : sclas.ToUpper();

                if (string.IsNullOrEmpty(Request.R_MODE))
                    Request.R_MODE = ApplicationConfig.Mode;

                item.QueryString = queryString;
                item.Mode = Request.LCLAS_CD;
                item.Request = Request;
            }

            return item;
        }

#endregion

        #region BalloonTip

        private void ShowBalloonTip(string message, ToolTipIcon icon = 0, bool isHistory = true, int timeout = 1000)
        {
            if (isHistory)
            {
                RequestHistoryHelper.GetActiveItem().Message = message;
                RequestHistoryHelper.GetActiveItem().State = "Error";
            }

            notifyIcon.BalloonTipIcon = icon;
            notifyIcon.BalloonTipText = message;
            notifyIcon.BalloonTipTitle = ApplicationConfig.SolutionTitle;
            notifyIcon.ShowBalloonTip(timeout);
        }
        #endregion

        #region Event

        protected override void OnLoad(EventArgs e)
        {
            Visible = false;
            ShowInTaskbar = false;
            Opacity = 0;

            base.OnLoad(e);
        }

        private void FrmLauncher_Load(object sender, EventArgs e)
        {
            try
            {
                //ShowBalloonTip("ScanLauncher 가 실행 중입니다.");
                //BeginInvoke(new MethodInvoker(delegate { Hide(); }));

                //최신버전 동기화
                CreateVersionSync();
                //웹 소켓 기동
                CreateListener();
                //런체 서비스 기동
                CreateListenerService();
            }
            catch (Exception ex)
            {
                MessageHelper.MessageShow(ex.Message, 3);
            }
        }

        /// <summary>
        /// 최신버전 동기화 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FVersionSync_ProcessChanged(object sender, SyncStateEventArgs e)
        {
            if (e.Status == PublishProcessStatus.Complete)
            {
                runHistoryItem.IsRun = true;
                runHistoryItem.LastUpdateDate = DateTime.Now.ToString();
            }
            else
            {
                runHistoryItem.IsRun = false;
            }
        }

        /// <summary>
        /// 최신버전동기화 종료 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FVersionSync_FormClosed(object sender, FormClosedEventArgs e)
        {
            IsRunning = false;
        }

        private void MiImageWatcher_Click(object sender, EventArgs e)
        {
            frmImageWatcher frm = new frmImageWatcher();
            frm.ShowDialog();
        }

        private void MiVersionSync_Click(object sender, EventArgs e)
        {
            CreateVersionSync();
        }

        private void MiInfo_Click(object sender, EventArgs e)
        {
            if (formAboutBox != null)
            {
                formAboutBox.Dispose();
                formAboutBox = null;
            }

            runHistoryItem.AutoSyncStatus = (launcherService == null) ? string.Empty : launcherService.Status.ToString();

            formAboutBox = new frmAboutBox();
            formAboutBox.SetSettingData(runHistoryItem);
            formAboutBox.ShowDialog(this);
        }

        private void MiHistory_Click(object sender, EventArgs e)
        {
            if (formHistory != null)
            {
                formHistory.Dispose();
                formHistory = null;
            }

            formHistory = new frmHistory();
            formHistory.ShowDialog(this);
        }

        private void MiInit_Click(object sender, EventArgs e)
        {
            if (formInit != null)
            {
                formInit.Dispose();
                formInit = null;
            }

            formInit = new frmInit();
            formInit.ShowDialog(this);
        }

        private void MiExit_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void LauncherService_LauncherStatusChanged(object sender, string mode, Config.LauncherStatus state, string message)
        {
            if (state.Equals(Config.LauncherStatus.IsRuning) && string.IsNullOrEmpty(message)) //End State
            {
                this.Cursor = Cursors.Default;
            }
            else
            {
                bool update = false;
                ToolTipIcon icon;

                if (state.Equals(Config.LauncherStatus.Error))
                {
                    icon = ToolTipIcon.Error;
                    update = true;
                }
                else if (state.Equals(Config.LauncherStatus.Warning))
                {
                    icon = ToolTipIcon.Warning;
                    update = true;
                }
                else if (state.Equals(Config.LauncherStatus.Information))
                    icon = ToolTipIcon.Info;
                else
                    icon = ToolTipIcon.None;

                
                ShowBalloonTip(message, icon, update);
            }
        }

        private void Application_ApplicationExit(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default.LastSecurityId = lastSecurityId;
                Properties.Settings.Default.Save();
            }
            finally { }
        }

        #endregion
    }
}
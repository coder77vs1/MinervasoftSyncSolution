using ScanLauncher.Config;
using ScanLauncher.Core;
using ScanLauncher.Data;
using ScanLauncher.Event;
using System;
using System.Collections.Generic;

namespace ScanLauncher.Service
{
    /// <summary>
    /// 런처 서비스
    /// </summary>
    public class LauncherService
    {
        private ProcessItem runProcessInfo = null;
        private ProcessItem requestProcessInfo = null;
        private string lastRequestMode;
        public event LauncherEventHandler LauncherStatusChanged;
        private bool IsFirstRun;
        private DateTime lstAccessDateTime;
        private int overlapSeconds;
        public List<ProcessItem> SvrProcessData { get; private set; }
        public LauncherRunStatus Status { get; private set; }
        public LauncherService()
        {
            InitializeResource();
        }

        private void InitializeResource()
        {
            IsFirstRun = true;
            Status = LauncherRunStatus.Standby;
            lstAccessDateTime = DateTime.Now;
            overlapSeconds = ApplicationConfig.OverlapSeconds;

            lastRequestMode = string.Empty;

            GetServerData();
        }

        public string RunAt(ProcessItem processItem)
        {
            string result = string.Empty;

            if (processItem == null || string.IsNullOrEmpty(processItem.ProcessName)) return result;

            requestProcessInfo = processItem;

            try
            {
                //연속호출 체크
                if (CheckOverlapRequest())
                {
                    //실행여부 체크
                    if (CheckRuning())
                    {
                        OnStatusUpdate(LauncherStatus.Information, "실행 중 입니다.");
                    }
                    else
                    {
                        OnStatusUpdate(LauncherStatus.Information, "최초 실행 중 입니다.");
                        //신규 실행
                        NewRunApp();
                    }

                    if (Status == LauncherRunStatus.IsRuning)
                    {
                        result = runProcessInfo.ProcessName;
                        InteropHelper.SwitchToThisWindowApp(result);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                OnStatusUpdate(LauncherStatus.IsRuning, string.Empty);
            }

            return result;
        }

        private bool CheckRuning()
        {
            if (Status.Equals(LauncherRunStatus.IsRuning) == false)
                return false;

            bool result = false;
            int processid = 0;

            processid = ProcessHelper.GetProcessId(requestProcessInfo.ProcessName);

            if (processid > 0 && runProcessInfo != null)
            {
                if (runProcessInfo.ProcessId.Equals(processid) &&
                    runProcessInfo.Mode.Equals(requestProcessInfo.Mode, StringComparison.CurrentCultureIgnoreCase))
                {
                    result = true;
                }
            }

            if (result == false)
            {
                if (processid > 0)
                    ClearProcess(requestProcessInfo.ProcessName);

                runProcessInfo = null;
            }

            return result;
        }

        public void ClearProcess(string processName)
        {
            ProcessHelper.ProcessKill(processName);
        }

        public bool NewRunApp()
        {
            if (Status.Equals(LauncherRunStatus.IsRuning) == false)
                return false;

            bool result = false;
            
            try
            {
                SetRequestProcessItem();

                var key = string.Format("ScanStation_{0}", ProcessHelper.GetCurrentProcessId());
                var data = JsonHelper.JsonSerizlizer<RequestItem>(requestProcessInfo.Request);
                var context = CryptographyHelper.AES.Encrypt(data, key);

                if (ProcessHelper.RunApp(requestProcessInfo.ProcessPath, context))
                {
                    if (SetInstProcessItem())
                    {
                        Status = LauncherRunStatus.IsRuning;
                        result = true;
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                Status = LauncherRunStatus.Error;
                throw ex;
            }
        }

        private void SetRequestProcessItem()
        {
            // 파라미터 설정
            if (requestProcessInfo.QueryString != null && requestProcessInfo.QueryString.Count > 0)
            {
                IDictionary<string, string> data = new Dictionary<string, string>();

                foreach (var k in requestProcessInfo.QueryString.AllKeys)
                {
                    data.Add(k, requestProcessInfo.QueryString[k]);
                }
                //requestProcessInfo.QueryString[KeyContext.QueryKey.UserId] = requestProcessInfo.User.UserId;
                //requestProcessInfo.Arguments = string.Join("&", requestProcessInfo.QueryString.AllKeys.Select(x => x + "=" + requestProcessInfo.QueryString[x]));
                //requestProcessInfo.Request.CONTEXT = requestProcessInfo.Arguments;
                requestProcessInfo.Request.LCLAS_CD = requestProcessInfo.QueryString[KeyContext.QueryKey.Mode];
                requestProcessInfo.Request.QueryString = data;
            }
        }

        private bool SetInstProcessItem()
        {
            bool result = false;
            DateTime CreateDateTime;

            try
            {
                if(runProcessInfo != null)
                    CreateDateTime = runProcessInfo.CreateDateTime;
                else
                    CreateDateTime = DateTime.Now;

                runProcessInfo = new ProcessItem(requestProcessInfo);
                runProcessInfo.ProcessId = ProcessHelper.GetProcessId(requestProcessInfo.ProcessName);

                if (runProcessInfo.ProcessId > 0)
                {
                    runProcessInfo.CreateDateTime = CreateDateTime;
                    runProcessInfo.LastAccessDateTime = DateTime.Now;
                    result = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        private void GetServerData()
        {
            try
            {
                SvrProcessData = new List<ProcessItem>();
                if (ApplicationConfig.Mode == "D")
                {
                    SvrProcessData.Add(new ProcessItem() { ProcessName = "ScanStation", ProcessPath = "C:\\Minervasoft\\ScanStation\\Publish\\ScanStation.exe", ReqArguments = "job;mode;" });
                    Status = LauncherRunStatus.IsRuning;
                }
                else
                {
                    var resource = WebClientHelper.WebClientReadFile(ApplicationConfig.ServerProcessFilePath);

                    if (string.IsNullOrEmpty(resource) == false)
                    {
                        SvrProcessData = JsonHelper.JsonDeserizlizer<List<ProcessItem>>(resource);
                        Status = LauncherRunStatus.IsRuning;
                    }
                    else
                    {
                        Status = LauncherRunStatus.Error;
                    }
                }
                
            }
            catch (Exception ex)
            {
                Status = LauncherRunStatus.Error;
                throw ex;
            }
        }

        /// <summary>
        /// 중복실행 체크
        /// </summary>
        /// <returns></returns>
        private bool CheckOverlapRequest()
        {
            if (IsFirstRun)
            {
                IsFirstRun = false;
                return true;
            }
            else
            {
                TimeSpan datediff = DateTime.Now - lstAccessDateTime;
                var diffSec = datediff.TotalSeconds;
                var result = (diffSec > overlapSeconds); //기준시간보다 커야 정상

                lstAccessDateTime = DateTime.Now;


                return result;
            }
        }

        private void OnStatusUpdate(LauncherStatus state, string message = "")
        {
            LauncherStatusChanged?.Invoke(this, lastRequestMode, state, message);
        }
    }
}
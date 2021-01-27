using ScanLauncher.Data;
using System;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace ScanLauncher.Common
{
    public class BaseForm : Form , IScanForm
    {
        public BaseForm()
        {
            InitializeBaseComponent();
        }

        public void InitializeBaseComponent()
        {
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        public virtual void InitializeEvent() { }

        public virtual void InitializeResource() { }

        public virtual void InitializeControl() { }

        public bool IsRunning { get; set; } = false;

        public RequestItem Request { get; set; } = null;

        protected bool IsFirstRun { get; set; } = false;

        protected DateTime lstAccessDateTime { get; set; }

        protected int overlapSeconds { get; set; }

        public virtual void ShowForm(HttpListenerRequest r, int i) { }

        public virtual void SetCultureResources(string name)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(name);
        }

        protected string WebClientReadFile(string url)
        {
            string result = string.Empty;

            try
            {
                using (WebClient client = new WebClient())
                {
                    client.Encoding = Encoding.UTF8;
                    result = client.DownloadString(url);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return result;
        }

        #region Overlap

        /// <summary>
        /// 중복실행 체크
        /// </summary>
        /// <returns></returns>
        protected bool CheckOverlapRequest()
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
        #endregion
    }
}

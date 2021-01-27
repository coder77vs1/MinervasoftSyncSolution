using ScanLauncher.Common;
using ScanLauncher.Core;
using ScanLauncher.Data;
using System;
using System.Text;

namespace ScanLauncher.View
{
    partial class frmAboutBox : BaseForm, IScanForm
    {
        public frmAboutBox()
        {
            InitializeComponent();

            InitializeResource();
        }

        #region Initialize

        public override void InitializeResource()
        {
            this.Text = String.Format("{0} 정보", AssemblyHelper.AssemblyTitle);
            this.labelProductName.Text = AssemblyHelper.AssemblyProduct;
            this.labelVersion.Text = String.Format("버전 {0}", AssemblyHelper.AssemblyVersion);
            this.labelCopyright.Text = AssemblyHelper.AssemblyCopyright;
            this.labelCompanyName.Text = AssemblyHelper.AssemblyCompany;
            this.textBoxDescription.Text = AssemblyHelper.AssemblyDescription;
        }
        #endregion

        public void SetSettingData(RunHistoryItem runHistoryItem)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("런       처 : " + (runHistoryItem.IsRun ? "정상" : "오류"));            
            sb.AppendLine("업데이트상태 : " + runHistoryItem.AutoSyncStatus);
            sb.AppendLine("업데이트일자 : " + runHistoryItem.LastUpdateDate);
            sb.AppendLine("웹소켓  주소 : " + runHistoryItem.WebSocketInfo);
            sb.AppendLine("서   버   명 : " + runHistoryItem.ServerHost);
            sb.AppendLine("실행    모드 : " + (runHistoryItem.ServerInfo.Equals("R") ? "운영" : "개발") + "(" + runHistoryItem.ServerInfo + ")");

            txtSettingData.Text = sb.ToString();
        }
    }
}

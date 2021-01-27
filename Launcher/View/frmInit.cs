using ScanLauncher.Common;
using ScanLauncher.Core;
using ScanLauncher.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScanLauncher.View
{
    public partial class frmInit : BaseForm, IScanForm
    {
        public frmInit()
        {
            InitializeComponent();

            InitializeEvent();

            InitializeControl();
        }

        public override void InitializeEvent()
        {
            this.btnRun.Click += BtnRun_Click;
            this.btnCheck.Click += BtnCheck_Click;
        }

        public override void InitializeControl()
        {
            this.chkOpt2.Checked = false;
            this.chkOpt3.Checked = false;            
            this.Cursor = Cursors.Default;
        }

        private void BtnCheck_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            bool result = false;

            using (AutoSyncService service = new AutoSyncService())
            {
                result = service.CheckClientResource();
            }

            if (result)
            {
                MessageHelper.MessageShow("프로그램이 정상 입니다.", 1);
            }
            else
            {
                MessageHelper.MessageShow("프로그램 초기화를 진행 해 주십시오.", 3);
            }

            InitializeControl();
        }

        private void BtnRun_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            if (chkOpt1.Checked) //프로세서 강제 종료
                SetProcessKill();

            if (chkOpt2.Checked) //프로그램 파일 삭제
                SetProcessFile();

            if (chkOpt3.Checked) //프로그램 설정파일 삭제
                SetProcessConfig();

            InitializeControl();

            MessageHelper.MessageShow("처리완료.", 1);
            this.Close();
        }

        /// <summary>
        /// //프로세서 강제 종료
        /// </summary>
        private void SetProcessKill()
        {
            ProcessHelper.ProcessKill("ScanStation");
        }

        /// <summary>
        /// 프로그램 파일 삭제
        /// </summary>
        private void SetProcessFile()
        {
            using (AutoSyncService service = new AutoSyncService())
            {
                service.ClearClientPublishPath();
            }
        }

        /// <summary>
        /// 프로그램 설정파일 삭제
        /// </summary>
        private void SetProcessConfig()
        {
            using (AutoSyncService service = new AutoSyncService())
            {
                service.ClearClientConfig();
            }
        }
    }
}
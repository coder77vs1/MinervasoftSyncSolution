using ScanLauncher.Common;
using ScanLauncher.Data;
using ScanLauncher.Service;
using ScanLauncher.Config;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading.Tasks;
using ScanLauncher.Core;
using System.IO;
using ScanLauncher.Event;

namespace ScanLauncher.View
{
    public partial class frmVersionSync : BaseForm, IScanForm
    {
        public frmVersionSync()
        {
            InitializeComponent();

            InitializeEvent();
        }

        #region Variable
        private Timer processTimer;
        private SyncResourceData syncResourceData;
        private AutoSyncService autoSyncService = null;
        private string tempDirectory;
        private bool processRunAt;
        public event SyncStateEventHandler ProcessChanged;
        #endregion

        #region Initialize

        public void InitializeTimer()
        {
            if (processTimer == null)
            {
                processTimer = new Timer();
                processTimer.Interval = 1000;
                processTimer.Tick += ProcessTimer_Tick;
                processTimer.Enabled = true;
            }
        }

        public override void InitializeEvent()
        {
            this.Load += FrmVersionSync_Load;
        }

        public override void InitializeResource()
        {
            syncResourceData = new SyncResourceData
            {
                ClientConfig = new PublishData
                {
                    Files = new List<PublishFileItem>()
                },

                ServerConfig = new PublishData
                {
                    Files = new List<PublishFileItem>()
                }
            };
        }

        public override void InitializeControl()
        {
            processRunAt = false;

            progressBar.Maximum = AutoSyncService.Maximum;
            progressBar.Step = 1;
            progressBar.Value = 0;

            btnClose.Click += BtnClose_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnClose.Visible = false;
            btnUpdate.Visible = false;
        }

        private void InitializeAutoSyncService()
        {
            progressBar.Value = 0;

            tempDirectory = FileHelper.GetNewTempPath("ScanLauncher." + Guid.NewGuid().ToString("N"));

            autoSyncService = new AutoSyncService();
            autoSyncService.SyncStateChanged += AutoSyncService_SyncStateChanged;
            autoSyncService.SyncProcessEnd += AutoSyncService_SyncProcessEnd;
            autoSyncService.Start(syncResourceData, tempDirectory);
        }

        #endregion

        #region Event

        private void FrmVersionSync_Load(object sender, EventArgs e)
        {
            InitializeTimer();
        }

        private void ProcessTimer_Tick(object sender, EventArgs e)
        {
            processTimer.Enabled = false;
            processTimer.Stop();

            InitializeResource();

            InitializeControl();

            InitializeAutoSyncService();
        }
        
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            InitializeAutoSyncService();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            ClearTempDirectory();

            this.Close();
        }

        private void AutoSyncService_SyncProcessEnd(object sender, SyncStateEventArgs e)
        {
            EndProcess(e.StepName, e.Message, (e.Status == PublishProcessStatus.Complete));
        }

        private void AutoSyncService_SyncStateChanged(object sender, SyncStateEventArgs e)
        {
            if (e.Status == PublishProcessStatus.Fail)
                EndProcess(e.StepName, e.Message, false);
            else
                SetProgressBar(e.StepName, e.Message);
        }

        #endregion

        #region Methed

        private void SetProgressBar(string context, string message)
        {
            lblProcess.InvokeIfRequired(() =>
            {
                lblProcess.Text = context;
            });

            lblMessage.InvokeIfRequired(() =>
            {
                lblMessage.Text = message;
            });

            progressBar.InvokeIfRequired(() =>
            {
                progressBar.Value += 1;
            });

            this.InvokeIfRequired(() =>
            {
                lblProcess.Refresh();
                lblMessage.Refresh();
                Application.DoEvents();
            });
        }

        private void EndProcess(string context, string message, bool isComplete)
        {
            lblProcess.InvokeIfRequired(() =>
            {
                lblProcess.Text = context;
            });

            lblMessage.InvokeIfRequired(() =>
            {
                lblMessage.Text = message;
            });

            ProcessChanged?.Invoke(this, new SyncStateEventArgs
            {
                StepName = this.Name,
                Status = isComplete ? PublishProcessStatus.Complete : PublishProcessStatus.Fail,
                Message = message
            });

            if (isComplete || processRunAt)
            {
                btnClose.Visible = true;
                btnClose.PerformClick();
            }
            else
            {
                btnClose.Visible = true;
                btnUpdate.Visible = true;
                processRunAt = true;
            }
        }

        private void ClearTempDirectory()
        {
            try
            {
                Task.Run(() => { FileHelper.DirectoryDelete(tempDirectory); });
            }
            finally
            { }
        }
        #endregion
    }
}

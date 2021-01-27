using ScanLauncher.Common;
using ScanLauncher.Core;
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
    public partial class frmHistory : BaseForm, IScanForm
    {
        public frmHistory()
        {
            InitializeComponent();

            InitializeEvent();

            InitializeResource();
        }

        public override void InitializeEvent()
        {
            this.btnClear.Click += BtnClear_Click;
            this.btnClose.Click += BtnClose_Click;
        }

        public override void InitializeResource()
        {
            if (RequestHistoryHelper.RequestHistoryData != null)
            {
                this.dataGridView1.DataSource = RequestHistoryHelper.RequestHistoryData;
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = null;
            RequestHistoryHelper.InitializeResource();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

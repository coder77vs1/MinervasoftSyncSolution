using MinervasoftSyncApp.Common;
using MinervasoftSyncApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinervasoftSyncApp.View
{
    public partial class frmMain : BaseForm
    {
        public frmMain()
        {
            InitializeComponent();
            //환경설정 초기화
            InitializeConfig();
        }

        /// <summary>
        /// 실행경로
        /// </summary>
        public string PRODUCT_RESOURCE { get; set; }

        /// <summary>
        /// 리소스파일 명
        /// </summary>
        public string PRODUCT_RESOURCE_FILE { get; set; }

        private DSResource.ApplicationRow activeApplicationRow { get; set; }

        #region Initialize
        /// <summary>
        /// 환경설정 초기화 함수
        /// </summary>
        public void InitializeConfig()
        {
            PRODUCT_RESOURCE = System.Windows.Forms.Application.StartupPath;
            PRODUCT_RESOURCE_FILE = string.Empty;
        }
        #endregion

        #region Events

        private void btnProduct_Click(object sender, EventArgs e)
        {
            frmProduct frm = new frmProduct
            {
                ResourcePath = PRODUCT_RESOURCE,
                StartPosition = FormStartPosition.CenterScreen
            };

            frm.ShowDialog(this);
        }

        private void btnApplication_Click(object sender, EventArgs e)
        {
            frmApplication frm = new frmApplication
            {
                ResourcePath = PRODUCT_RESOURCE,
                StartPosition = FormStartPosition.CenterScreen
            };

            frm.ShowDialog(this);
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            frmSetting frm = new frmSetting
            {
                ResourcePath = PRODUCT_RESOURCE,
                StartPosition = FormStartPosition.CenterScreen
            };

            frm.ShowDialog(this);
        }
        #endregion

        private void btnGet_Click(object sender, EventArgs e)
        {
            PRODUCT_RESOURCE_FILE = OpenFilePathByXml(this.ResourcePath);

            if (File.Exists(PRODUCT_RESOURCE_FILE))
            {
                try
                {
                    this.dsResource1.Clear();

                    this.dsResource1.ReadXml(PRODUCT_RESOURCE_FILE);
                }
                catch
                {
                    MessageBox.Show("ERROR!");
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null) return;

            ClearControls();

            activeApplicationRow = ((listBox1.SelectedItem as System.Data.DataRowView).Row as DSResource.ApplicationRow);

            txtApplicationId.Tag = activeApplicationRow;
            txtApplicationId.Text = activeApplicationRow.ApplicationId;
            txtApplicationName.Text = activeApplicationRow.ApplicationName;
            txtApplicationKey.Text = activeApplicationRow.ApplicationKey;
            txtApplicationType.Text = activeApplicationRow.ApplicationType;
            txtServerUrl.Text = activeApplicationRow.ServerUrl;
            txtClientPath.Text = activeApplicationRow.ServerUrl;
            txtReleasePath.Text = activeApplicationRow.ReleasePath;
        }

        protected override void ClearControls()
        {
            this.txtApplicationId.Tag = string.Empty;
            this.txtApplicationId.Text = string.Empty;
            this.txtApplicationName.Text = string.Empty;
            this.txtApplicationKey.Text = string.Empty;
            this.txtApplicationType.Text = string.Empty;
            this.txtServerUrl.Text = string.Empty;
            this.txtClientPath.Text = string.Empty;
            this.txtReleasePath.Text = string.Empty;
        }
    }
}
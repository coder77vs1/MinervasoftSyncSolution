using MinervasoftSyncApp.Common;
using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MinervasoftSyncApp.View
{
    public partial class frmSetting : BaseForm
    {
        public frmSetting()
        {
            InitializeComponent();

            InitializeData();
        }

        private void InitializeData()
        {
            List<string> typeData = new List<string>
            {
                "WebSocket", "CustomURI"
            };

            cboServiceType.DataSource = typeData;
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            this.txtPath.Text = OpenFilePathByXml(this.ResourcePath);

            if (string.IsNullOrEmpty(this.txtPath.Text)) return;

            if (File.Exists(this.txtPath.Text))
            {
                try
                {
                    this.dsResource1.Clear();

                    this.dsResource1.ReadXml(this.txtPath.Text);

                    if (this.dsResource1.Config.Rows.Count == 1)
                    {
                        this.cboServiceType.Text = this.dsResource1.Config[0].ServiceType;
                        this.txtLauncherPath.Text = this.dsResource1.Config[0].LauncherPath;
                        this.txtCertificationExe.Text = this.dsResource1.Config[0].CertificationExe;
                    }
                }
                catch
                {
                    MessageBox.Show("ERROR!");
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.dsResource1.Config.Count == 0 || string.IsNullOrEmpty(this.txtPath.Text))
                return;

            try
            {
                if (this.dsResource1.Config.Rows.Count == 1)
                {
                    this.dsResource1.Config[0].ServiceType = this.cboServiceType.Text;
                    this.dsResource1.Config[0].LauncherPath = this.txtLauncherPath.Text;
                    this.dsResource1.Config[0].CertificationExe = this.txtCertificationExe.Text;

                    File.Delete(this.txtPath.Text);
                    this.dsResource1.WriteXml(this.txtPath.Text);

                    MessageBox.Show("SUCCESS");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        protected override void ClearControls()
        {
            this.cboServiceType.Tag = string.Empty;
            this.cboServiceType.SelectedIndex = 0;
            this.txtLauncherPath.Text = string.Empty;
            this.txtCertificationExe.Text = string.Empty;
        }
    }
}

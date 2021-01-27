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
                        this.txtValue1.Text = this.dsResource1.Config[0].ServiceType;
                        this.txtValue2.Text = this.dsResource1.Config[0].Startup;
                        this.txtValue3.Text = this.dsResource1.Config[0].LauncherPath;
                        this.txtValue4.Text = this.dsResource1.Config[0].SyncType;
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
                    this.dsResource1.Config[0].ServiceType = this.txtValue1.Text;
                    this.dsResource1.Config[0].Startup = this.txtValue2.Text;
                    this.dsResource1.Config[0].LauncherPath = this.txtValue3.Text;
                    this.dsResource1.Config[0].SyncType = this.txtValue4.Text;

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
            this.txtValue1.Tag = string.Empty;
            this.txtValue1.Text = string.Empty;

            this.txtValue2.Tag = string.Empty;
            this.txtValue2.Text = string.Empty;

            this.txtValue3.Tag = string.Empty;
            this.txtValue3.Text = string.Empty;

            this.txtValue4.Tag = string.Empty;
            this.txtValue4.Text = string.Empty;
        }
    }
}

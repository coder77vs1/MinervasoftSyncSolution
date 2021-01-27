using MinervasoftSyncApp.Common;
using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;

namespace MinervasoftSyncApp.View
{
    public partial class frmApplication : BaseForm
    {
        public frmApplication()
        {
            InitializeComponent();

            InitializeData();
        }

        private void InitializeData()
        {
            List<string> typeData = new List<string>
            { 
                "Application", "Resource"
            };

            cboApplicationType.DataSource = typeData;
        }

        protected override void ClearControls()
        {
            this.txtApplicationId.Tag = string.Empty;
            this.txtApplicationId.Text = string.Empty;
            this.txtApplicationName.Text = string.Empty;
            this.txtServerUrl.Text = string.Empty;
            this.txtClientPath.Text = string.Empty;
            this.txtReleasePath.Text = string.Empty;
            this.txtApplicationKey.Text = string.Empty;
            this.cboApplicationType.SelectedIndex = 0;
        }

        #region Events

        private void btnGet_Click(object sender, EventArgs e)
        {
            ClearControls();

            this.txtPath.Text = OpenFilePathByXml(this.ResourcePath);

            if (string.IsNullOrEmpty(this.txtPath.Text)) return;

            this.dsResource1.Clear();

            if (File.Exists(this.txtPath.Text))
            {
                try
                {
                    this.dsResource1.ReadXml(this.txtPath.Text);
                }
                catch
                {
                    MessageBox.Show("ERROR!");
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearControls();
            this.dataGridView2.ClearSelection();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtApplicationId.Text) || string.IsNullOrEmpty(txtApplicationName.Text))
                return;

            if (string.IsNullOrEmpty(txtApplicationId.Tag.ToString()))
            {
                this.dsResource1.Application.AddApplicationRow(
                        txtApplicationId.Text.Trim(),
                        txtApplicationName.Text.Trim(),
                        txtApplicationKey.Text.Trim(),
                        cboApplicationType.Text,
                        txtServerUrl.Text.Trim(),
                        txtClientPath.Text.Trim(),
                        txtReleasePath.Text.Trim()
                    );
            }
            else
            {
                var rowIndex = Convert.ToInt32(txtApplicationId.Tag);
                this.dsResource1.Application[rowIndex].ApplicationId = txtApplicationId.Text;
                this.dsResource1.Application[rowIndex].ApplicationName = txtApplicationName.Text;
                this.dsResource1.Application[rowIndex].ApplicationKey = txtApplicationKey.Text;
                this.dsResource1.Application[rowIndex].ApplicationType = cboApplicationType.Text;
                this.dsResource1.Application[rowIndex].ServerUrl = txtServerUrl.Text;
                this.dsResource1.Application[rowIndex].ClientPath = txtClientPath.Text;
                this.dsResource1.Application[rowIndex].ReleasePath = txtReleasePath.Text;
            }

            ClearControls();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.dataGridView2.SelectedRows.Count > 0)
            {
                var rowIndex = this.dataGridView2.SelectedRows[0].Index;

                this.dataGridView2.ClearSelection();
                this.dsResource1.Application[rowIndex].Delete();

                ClearControls();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtPath.Text))
                return;

            this.dataGridView2.EndEdit();
            this.dataGridView2.Refresh();

            try
            {
                File.Delete(this.txtPath.Text);
                this.dsResource1.WriteXml(this.txtPath.Text);

                MessageBox.Show("SUCCESS");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ClearControls();

            if ((e.RowIndex < 0) || (e.ColumnIndex < 0)) return;

            txtApplicationId.Tag = e.RowIndex;
            txtApplicationId.Text = this.dsResource1.Application[e.RowIndex].ApplicationId;
            txtApplicationName.Text = this.dsResource1.Application[e.RowIndex].ApplicationName;
            txtApplicationKey.Text = this.dsResource1.Application[e.RowIndex].ApplicationKey;
            cboApplicationType.Text = this.dsResource1.Application[e.RowIndex].ApplicationType;
            txtServerUrl.Text = this.dsResource1.Application[e.RowIndex].ServerUrl;
            txtClientPath.Text = this.dsResource1.Application[e.RowIndex].ClientPath;
            txtReleasePath.Text = this.dsResource1.Application[e.RowIndex].ReleasePath;
        }

        #endregion
    }
}

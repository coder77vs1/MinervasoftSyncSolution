using MinervasoftSyncApp.Common;
using System;
using System.IO;
using System.Windows.Forms;

namespace MinervasoftSyncApp.View
{
    public partial class frmApplication : BaseForm
    {
        public frmApplication()
        {
            InitializeComponent();
        }

        protected override void ClearControls()
        {
            this.txtApplicationId.Tag = string.Empty;
            this.txtApplicationId.Text = string.Empty;

            this.txtApplicationName.Tag = string.Empty;
            this.txtApplicationName.Text = string.Empty;

            this.txtApplicationPath.Tag = string.Empty;
            this.txtApplicationPath.Text = string.Empty;

            this.txtApplicationKey.Tag = string.Empty;
            this.txtApplicationKey.Text = string.Empty;

            this.txtUseYn.Tag = string.Empty;
            this.txtUseYn.Text = string.Empty;
        }

        #region Events

        private void btnGet_Click(object sender, EventArgs e)
        {
            ClearControls();

            this.txtPath.Text = this.ResourcePath;

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
                        txtApplicationPath.Text.Trim(),
                        txtApplicationKey.Text.Trim(),
                        txtUseYn.Text.Trim()
                    );
            }
            else
            {
                var rowIndex = Convert.ToInt32(txtApplicationId.Tag);
                this.dsResource1.Application[rowIndex].ApplicationId = txtApplicationId.Text;
                this.dsResource1.Application[rowIndex].ApplicationName = txtApplicationName.Text;
                this.dsResource1.Application[rowIndex].ApplicationPath = txtApplicationPath.Text;
                this.dsResource1.Application[rowIndex].ApplicationKey = txtApplicationKey.Text;
                this.dsResource1.Application[rowIndex].UseYn = txtUseYn.Text;
            }

            ClearControls();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.dataGridView2.SelectedRows.Count > 0)
            {
                var rowIndex = this.dataGridView2.SelectedRows[0].Index;

                this.dataGridView2.ClearSelection();
                this.dsResource1.Product[rowIndex].Delete();

                ClearControls();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.dsResource1.Product.Count == 0)
                return;

            this.dataGridView2.EndEdit();
            this.dataGridView2.Refresh();

            try
            {
                File.Delete(this.ResourcePath);
                this.dsResource1.WriteXml(this.ResourcePath);

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
            txtApplicationPath.Text = this.dsResource1.Application[e.RowIndex].ApplicationPath;
            txtApplicationKey.Text = this.dsResource1.Application[e.RowIndex].ApplicationKey;
            txtUseYn.Text = this.dsResource1.Application[e.RowIndex].UseYn;
        }

        #endregion
    }
}

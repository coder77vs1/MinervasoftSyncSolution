using MinervasoftSyncApp.Common;
using System;
using System.IO;
using System.Windows.Forms;

namespace MinervasoftSyncApp.View
{
    public partial class frmProduct : BaseForm
    {
        public frmProduct()
        {
            InitializeComponent();
        }

        protected override void ClearControls()
        {
            this.txtProductId.Tag = string.Empty;
            this.txtProductId.Text = string.Empty;

            this.txtProductName.Tag = string.Empty;
            this.txtProductName.Text = string.Empty;

            this.txtInstallName.Tag = string.Empty;
            this.txtInstallName.Text = string.Empty;

            this.txtInstallPath.Tag = string.Empty;
            this.txtInstallPath.Text = string.Empty;

            this.txtCheckFileName.Tag = string.Empty;
            this.txtCheckFileName.Text = string.Empty;

            this.txtCheckDate.Tag = string.Empty;
            this.txtCheckDate.Text = string.Empty;
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
            if (string.IsNullOrEmpty(txtProductId.Text) || string.IsNullOrEmpty(txtProductName.Text))
                return;

            if (string.IsNullOrEmpty(txtProductId.Tag.ToString()))
            {
                this.dsResource1.Product.AddProductRow(
                        txtProductId.Text.Trim(),
                        txtProductName.Text.Trim(),
                        txtInstallName.Text.Trim(),
                        txtInstallPath.Text.Trim(),
                        txtCheckFileName.Text.Trim(),
                        txtCheckDate.Text.Trim()
                    );
            }
            else
            {
                var rowIndex = Convert.ToInt32(txtProductId.Tag);
                this.dsResource1.Product[rowIndex].ProductId = txtProductId.Text;
                this.dsResource1.Product[rowIndex].ProductName = txtProductName.Text;
                this.dsResource1.Product[rowIndex].InstallName = txtInstallName.Text;
                this.dsResource1.Product[rowIndex].InstallPath = txtInstallPath.Text;
                this.dsResource1.Product[rowIndex].CheckFileName = txtCheckFileName.Text;
                this.dsResource1.Product[rowIndex].CheckDate = txtCheckDate.Text;
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

            txtProductId.Tag = e.RowIndex;
            txtProductId.Text = this.dsResource1.Product[e.RowIndex].ProductId;
            txtProductName.Text = this.dsResource1.Product[e.RowIndex].ProductName;
            txtInstallName.Text = this.dsResource1.Product[e.RowIndex].InstallName;
            txtInstallPath.Text = this.dsResource1.Product[e.RowIndex].InstallPath;
            txtCheckFileName.Text = this.dsResource1.Product[e.RowIndex].CheckFileName;
            txtCheckDate.Text = this.dsResource1.Product[e.RowIndex].CheckDate;
        }

        #endregion
    }
}

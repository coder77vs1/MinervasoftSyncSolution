namespace MinervasoftSyncApp.View
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label9;
            System.Windows.Forms.Label label10;
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.lblFileName = new System.Windows.Forms.ToolStripLabel();
            this.btnConfig = new System.Windows.Forms.ToolStripButton();
            this.btnApplication = new System.Windows.Forms.ToolStripButton();
            this.btnProduct = new System.Windows.Forms.ToolStripButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblFileName,
            this.btnConfig,
            this.btnApplication,
            this.btnProduct});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1161, 27);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // lblFileName
            // 
            this.lblFileName.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblFileName.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.lblFileName.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblFileName.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(0, 24);
            // 
            // btnConfig
            // 
            this.btnConfig.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnConfig.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnConfig.Image = ((System.Drawing.Image)(resources.GetObject("btnConfig.Image")));
            this.btnConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(73, 24);
            this.btnConfig.Text = "환경설정";
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // btnApplication
            // 
            this.btnApplication.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnApplication.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnApplication.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnApplication.Image = ((System.Drawing.Image)(resources.GetObject("btnApplication.Image")));
            this.btnApplication.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnApplication.Name = "btnApplication";
            this.btnApplication.Size = new System.Drawing.Size(103, 24);
            this.btnApplication.Text = "프로그램관리";
            this.btnApplication.Click += new System.EventHandler(this.btnApplication_Click);
            // 
            // btnProduct
            // 
            this.btnProduct.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnProduct.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnProduct.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnProduct.Image = ((System.Drawing.Image)(resources.GetObject("btnProduct.Image")));
            this.btnProduct.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Size = new System.Drawing.Size(73, 24);
            this.btnProduct.Text = "제품관리";
            this.btnProduct.Click += new System.EventHandler(this.btnProduct_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel2.Controls.Add(this.textBox4);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.txtSource);
            this.panel2.Controls.Add(label6);
            this.panel2.Controls.Add(label7);
            this.panel2.Controls.Add(this.textBox2);
            this.panel2.Controls.Add(label8);
            this.panel2.Controls.Add(this.textBox3);
            this.panel2.Controls.Add(label9);
            this.panel2.Controls.Add(label10);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 27);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1161, 148);
            this.panel2.TabIndex = 14;
            // 
            // txtSource
            // 
            this.txtSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSource.Location = new System.Drawing.Point(98, 10);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(1051, 21);
            this.txtSource.TabIndex = 3;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(129)));
            label6.Location = new System.Drawing.Point(35, 66);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(53, 17);
            label6.TabIndex = 12;
            label6.Text = "Process";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(129)));
            label7.Location = new System.Drawing.Point(16, 120);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(72, 17);
            label7.TabIndex = 10;
            label7.Text = "Client Path";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(98, 118);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(1051, 21);
            this.textBox2.TabIndex = 9;
            this.textBox2.Text = "C:\\Minervasoft\\ScanStation\\";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(129)));
            label8.Location = new System.Drawing.Point(12, 93);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(76, 17);
            label8.TabIndex = 8;
            label8.Text = "Server Path";
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.Location = new System.Drawing.Point(98, 91);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(1051, 21);
            this.textBox3.TabIndex = 7;
            this.textBox3.Text = "/nics/install/scanstation/";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(129)));
            label9.Location = new System.Drawing.Point(35, 39);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(53, 17);
            label9.TabIndex = 6;
            label9.Text = "Release";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(129)));
            label10.Location = new System.Drawing.Point(38, 12);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(49, 17);
            label10.TabIndex = 4;
            label10.Text = "Source";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(98, 39);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1051, 21);
            this.textBox1.TabIndex = 13;
            // 
            // textBox4
            // 
            this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox4.Location = new System.Drawing.Point(98, 66);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(1051, 21);
            this.textBox4.TabIndex = 14;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1161, 680);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel lblFileName;
        private System.Windows.Forms.ToolStripButton btnProduct;
        private System.Windows.Forms.ToolStripButton btnApplication;
        private System.Windows.Forms.ToolStripButton btnConfig;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
    }
}
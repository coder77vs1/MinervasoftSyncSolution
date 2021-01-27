namespace ScanLauncher.View
{
    partial class frmAboutBox
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Panel pTopLineBox;
            System.Windows.Forms.Panel pTopLine;
            this.okButton = new System.Windows.Forms.Button();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.labelProductName = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.labelCopyright = new System.Windows.Forms.Label();
            this.labelCompanyName = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.txtSettingData = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            pTopLineBox = new System.Windows.Forms.Panel();
            pTopLine = new System.Windows.Forms.Panel();
            pTopLineBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pTopLineBox
            // 
            pTopLineBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(159)))), ((int)(((byte)(238)))));
            pTopLineBox.Controls.Add(pTopLine);
            pTopLineBox.Dock = System.Windows.Forms.DockStyle.Top;
            pTopLineBox.Location = new System.Drawing.Point(0, 0);
            pTopLineBox.Name = "pTopLineBox";
            pTopLineBox.Size = new System.Drawing.Size(507, 1);
            pTopLineBox.TabIndex = 47;
            // 
            // pTopLine
            // 
            pTopLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(125)))));
            pTopLine.Dock = System.Windows.Forms.DockStyle.Left;
            pTopLine.Location = new System.Drawing.Point(0, 0);
            pTopLine.Name = "pTopLine";
            pTopLine.Size = new System.Drawing.Size(150, 1);
            pTopLine.TabIndex = 0;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(254)))));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(106)))), ((int)(((byte)(117)))));
            this.okButton.Location = new System.Drawing.Point(407, 271);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(87, 28);
            this.okButton.TabIndex = 24;
            this.okButton.Text = "확인(&O)";
            this.okButton.UseVisualStyleBackColor = false;
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.logoPictureBox.Location = new System.Drawing.Point(13, 11);
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.Size = new System.Drawing.Size(154, 140);
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logoPictureBox.TabIndex = 13;
            this.logoPictureBox.TabStop = false;
            // 
            // labelProductName
            // 
            this.labelProductName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(71)))), ((int)(((byte)(80)))));
            this.labelProductName.Location = new System.Drawing.Point(177, 11);
            this.labelProductName.Name = "labelProductName";
            this.labelProductName.Size = new System.Drawing.Size(312, 16);
            this.labelProductName.TabIndex = 26;
            this.labelProductName.Text = "제품 이름";
            this.labelProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelVersion
            // 
            this.labelVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(71)))), ((int)(((byte)(80)))));
            this.labelVersion.Location = new System.Drawing.Point(177, 34);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(312, 16);
            this.labelVersion.TabIndex = 25;
            this.labelVersion.Text = "버전";
            this.labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCopyright
            // 
            this.labelCopyright.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(71)))), ((int)(((byte)(80)))));
            this.labelCopyright.Location = new System.Drawing.Point(177, 57);
            this.labelCopyright.Name = "labelCopyright";
            this.labelCopyright.Size = new System.Drawing.Size(312, 16);
            this.labelCopyright.TabIndex = 27;
            this.labelCopyright.Text = "저작권";
            this.labelCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCompanyName
            // 
            this.labelCompanyName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(71)))), ((int)(((byte)(80)))));
            this.labelCompanyName.Location = new System.Drawing.Point(177, 80);
            this.labelCompanyName.Name = "labelCompanyName";
            this.labelCompanyName.Size = new System.Drawing.Size(312, 16);
            this.labelCompanyName.TabIndex = 28;
            this.labelCompanyName.Text = "회사 이름";
            this.labelCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.BackColor = System.Drawing.Color.White;
            this.textBoxDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(71)))), ((int)(((byte)(80)))));
            this.textBoxDescription.Location = new System.Drawing.Point(177, 109);
            this.textBoxDescription.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.ReadOnly = true;
            this.textBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxDescription.Size = new System.Drawing.Size(317, 42);
            this.textBoxDescription.TabIndex = 29;
            this.textBoxDescription.TabStop = false;
            this.textBoxDescription.Text = "설명";
            // 
            // txtSettingData
            // 
            this.txtSettingData.BackColor = System.Drawing.Color.White;
            this.txtSettingData.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(71)))), ((int)(((byte)(80)))));
            this.txtSettingData.Location = new System.Drawing.Point(13, 182);
            this.txtSettingData.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            this.txtSettingData.Multiline = true;
            this.txtSettingData.Name = "txtSettingData";
            this.txtSettingData.ReadOnly = true;
            this.txtSettingData.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSettingData.Size = new System.Drawing.Size(481, 80);
            this.txtSettingData.TabIndex = 30;
            this.txtSettingData.TabStop = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(71)))), ((int)(((byte)(80)))));
            this.label1.Location = new System.Drawing.Point(11, 163);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(312, 16);
            this.label1.TabIndex = 31;
            this.label1.Text = "ScanStation";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmAboutBox
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(507, 307);
            this.Controls.Add(pTopLineBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSettingData);
            this.Controls.Add(this.labelProductName);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.labelCopyright);
            this.Controls.Add(this.labelCompanyName);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.logoPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximumSize = new System.Drawing.Size(523, 346);
            this.MinimumSize = new System.Drawing.Size(523, 346);
            this.Name = "frmAboutBox";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ScanLauncher";
            pTopLineBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.Label labelProductName;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label labelCopyright;
        private System.Windows.Forms.Label labelCompanyName;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.TextBox txtSettingData;
        private System.Windows.Forms.Label label1;
    }
}

namespace ScanLauncher.View
{
    partial class frmInit
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
            System.Windows.Forms.Panel pTopLineBox;
            System.Windows.Forms.Panel pTopLine;
            this.chkOpt1 = new System.Windows.Forms.CheckBox();
            this.chkOpt2 = new System.Windows.Forms.CheckBox();
            this.chkOpt3 = new System.Windows.Forms.CheckBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnCheck = new System.Windows.Forms.Button();
            pTopLineBox = new System.Windows.Forms.Panel();
            pTopLine = new System.Windows.Forms.Panel();
            pTopLineBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkOpt1
            // 
            this.chkOpt1.AutoSize = true;
            this.chkOpt1.Checked = true;
            this.chkOpt1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOpt1.Enabled = false;
            this.chkOpt1.Font = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(129)));
            this.chkOpt1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(71)))), ((int)(((byte)(80)))));
            this.chkOpt1.Location = new System.Drawing.Point(24, 24);
            this.chkOpt1.Name = "chkOpt1";
            this.chkOpt1.Size = new System.Drawing.Size(180, 21);
            this.chkOpt1.TabIndex = 0;
            this.chkOpt1.Text = "프로세서 강제 종료 (필수)";
            this.chkOpt1.UseVisualStyleBackColor = true;
            // 
            // chkOpt2
            // 
            this.chkOpt2.AutoSize = true;
            this.chkOpt2.Font = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(129)));
            this.chkOpt2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(71)))), ((int)(((byte)(80)))));
            this.chkOpt2.Location = new System.Drawing.Point(24, 57);
            this.chkOpt2.Name = "chkOpt2";
            this.chkOpt2.Size = new System.Drawing.Size(141, 21);
            this.chkOpt2.TabIndex = 1;
            this.chkOpt2.Text = "프로그램 파일 삭제";
            this.chkOpt2.UseVisualStyleBackColor = true;
            // 
            // chkOpt3
            // 
            this.chkOpt3.AutoSize = true;
            this.chkOpt3.Font = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(129)));
            this.chkOpt3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(71)))), ((int)(((byte)(80)))));
            this.chkOpt3.Location = new System.Drawing.Point(24, 90);
            this.chkOpt3.Name = "chkOpt3";
            this.chkOpt3.Size = new System.Drawing.Size(167, 21);
            this.chkOpt3.TabIndex = 2;
            this.chkOpt3.Text = "프로그램 설정파일 삭제";
            this.chkOpt3.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(254)))));
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(129)));
            this.btnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(106)))), ((int)(((byte)(117)))));
            this.btnExit.Location = new System.Drawing.Point(294, 123);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(70, 26);
            this.btnExit.TabIndex = 43;
            this.btnExit.Text = "닫기";
            this.btnExit.UseVisualStyleBackColor = false;
            // 
            // btnRun
            // 
            this.btnRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRun.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.btnRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRun.Font = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(129)));
            this.btnRun.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(71)))), ((int)(((byte)(80)))));
            this.btnRun.Location = new System.Drawing.Point(220, 123);
            this.btnRun.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(70, 26);
            this.btnRun.TabIndex = 42;
            this.btnRun.Text = "실행";
            this.btnRun.UseVisualStyleBackColor = false;
            // 
            // btnCheck
            // 
            this.btnCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCheck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.btnCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheck.Font = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(129)));
            this.btnCheck.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(71)))), ((int)(((byte)(80)))));
            this.btnCheck.Location = new System.Drawing.Point(24, 123);
            this.btnCheck.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(108, 26);
            this.btnCheck.TabIndex = 45;
            this.btnCheck.Text = "프로그램 검사";
            this.btnCheck.UseVisualStyleBackColor = false;
            // 
            // pTopLineBox
            // 
            pTopLineBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(159)))), ((int)(((byte)(238)))));
            pTopLineBox.Controls.Add(pTopLine);
            pTopLineBox.Dock = System.Windows.Forms.DockStyle.Top;
            pTopLineBox.Location = new System.Drawing.Point(0, 0);
            pTopLineBox.Name = "pTopLineBox";
            pTopLineBox.Size = new System.Drawing.Size(374, 1);
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
            // frmInit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(374, 161);
            this.Controls.Add(pTopLineBox);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.chkOpt3);
            this.Controls.Add(this.chkOpt2);
            this.Controls.Add(this.chkOpt1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximumSize = new System.Drawing.Size(390, 200);
            this.MinimumSize = new System.Drawing.Size(390, 200);
            this.Name = "frmInit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "프로그램 초기화";
            pTopLineBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkOpt1;
        private System.Windows.Forms.CheckBox chkOpt2;
        private System.Windows.Forms.CheckBox chkOpt3;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnCheck;
    }
}
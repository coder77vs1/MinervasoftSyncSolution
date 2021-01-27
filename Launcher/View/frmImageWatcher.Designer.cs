namespace ScanLauncher.View
{
    partial class frmImageWatcher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImageWatcher));
            pTopLineBox = new System.Windows.Forms.Panel();
            pTopLine = new System.Windows.Forms.Panel();
            pTopLineBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // pTopLineBox
            // 
            pTopLineBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(159)))), ((int)(((byte)(238)))));
            pTopLineBox.Controls.Add(pTopLine);
            pTopLineBox.Dock = System.Windows.Forms.DockStyle.Top;
            pTopLineBox.Location = new System.Drawing.Point(0, 0);
            pTopLineBox.Name = "pTopLineBox";
            pTopLineBox.Size = new System.Drawing.Size(250, 1);
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
            // frmImageWatcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 159);
            this.ControlBox = false;
            this.Controls.Add(pTopLineBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmImageWatcher";
            this.Text = "이미지동기화";
            pTopLineBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
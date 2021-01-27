namespace ScanLauncher.View
{
    partial class frmLauncher
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLauncher));
            System.Windows.Forms.Panel pTopLineBox;
            System.Windows.Forms.Panel pTopLine;
            this.label1 = new System.Windows.Forms.Label();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.miInit = new System.Windows.Forms.ToolStripMenuItem();
            this.miImageWatcher = new System.Windows.Forms.ToolStripMenuItem();
            this.miHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.miVersionSync = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.miExit = new System.Windows.Forms.ToolStripMenuItem();
            pTopLineBox = new System.Windows.Forms.Panel();
            pTopLine = new System.Windows.Forms.Panel();
            this.contextMenu.SuspendLayout();
            pTopLineBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(103, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "ScanStation Launcher가 실행 중 입니다.";
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenu;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "ScanLauncher";
            this.notifyIcon.Visible = true;
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miInfo,
            this.miInit,
            this.miImageWatcher,
            this.miHistory,
            this.miVersionSync,
            this.toolStripSeparator1,
            this.miExit});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(163, 142);
            // 
            // miInfo
            // 
            this.miInfo.Name = "miInfo";
            this.miInfo.Size = new System.Drawing.Size(162, 22);
            this.miInfo.Text = "프로그램 정보";
            // 
            // miInit
            // 
            this.miInit.Name = "miInit";
            this.miInit.Size = new System.Drawing.Size(162, 22);
            this.miInit.Text = "프로그램 초기화";
            // 
            // miImageWatcher
            // 
            this.miImageWatcher.Name = "miImageWatcher";
            this.miImageWatcher.Size = new System.Drawing.Size(162, 22);
            this.miImageWatcher.Text = "이미지 동기화";
            this.miImageWatcher.Visible = false;
            // 
            // miHistory
            // 
            this.miHistory.Name = "miHistory";
            this.miHistory.Size = new System.Drawing.Size(162, 22);
            this.miHistory.Text = "호출이력 정보";
            // 
            // miVersionSync
            // 
            this.miVersionSync.Name = "miVersionSync";
            this.miVersionSync.Size = new System.Drawing.Size(162, 22);
            this.miVersionSync.Text = "최신버전 동기화";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(159, 6);
            // 
            // miExit
            // 
            this.miExit.Name = "miExit";
            this.miExit.Size = new System.Drawing.Size(162, 22);
            this.miExit.Text = "프로그램 종료";
            // 
            // pTopLineBox
            // 
            pTopLineBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(159)))), ((int)(((byte)(238)))));
            pTopLineBox.Controls.Add(pTopLine);
            pTopLineBox.Dock = System.Windows.Forms.DockStyle.Top;
            pTopLineBox.Location = new System.Drawing.Point(0, 0);
            pTopLineBox.Name = "pTopLineBox";
            pTopLineBox.Size = new System.Drawing.Size(484, 1);
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
            // frmLauncher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(484, 161);
            this.Controls.Add(pTopLineBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(500, 200);
            this.MinimumSize = new System.Drawing.Size(500, 200);
            this.Name = "frmLauncher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.contextMenu.ResumeLayout(false);
            pTopLineBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem miInfo;
        private System.Windows.Forms.ToolStripMenuItem miVersionSync;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem miExit;
        private System.Windows.Forms.ToolStripMenuItem miImageWatcher;
        private System.Windows.Forms.ToolStripMenuItem miInit;
        private System.Windows.Forms.ToolStripMenuItem miHistory;
    }
}
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
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            System.Windows.Forms.Label label7;
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnConfig = new System.Windows.Forms.ToolStripButton();
            this.btnApplication = new System.Windows.Forms.ToolStripButton();
            this.btnProduct = new System.Windows.Forms.ToolStripButton();
            this.btnGet = new System.Windows.Forms.ToolStripButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtReleasePath = new System.Windows.Forms.TextBox();
            this.txtClientPath = new System.Windows.Forms.TextBox();
            this.txtApplicationKey = new System.Windows.Forms.TextBox();
            this.txtServerUrl = new System.Windows.Forms.TextBox();
            this.txtApplicationName = new System.Windows.Forms.TextBox();
            this.txtApplicationId = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.dsResource1 = new MinervasoftSyncApp.Data.DSResource();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.btnAll = new System.Windows.Forms.ToolStripButton();
            this.btnClear = new System.Windows.Forms.ToolStripButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.txtApplicationType = new System.Windows.Forms.TextBox();
            label6 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsResource1)).BeginInit();
            this.toolStrip3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(129)));
            label6.Location = new System.Drawing.Point(313, 116);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(67, 17);
            label6.TabIndex = 28;
            label6.Text = "ClientPath";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(129)));
            label5.Location = new System.Drawing.Point(301, 170);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(79, 17);
            label5.TabIndex = 27;
            label5.Text = "ReleasePath";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(129)));
            label4.Location = new System.Drawing.Point(318, 143);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(62, 17);
            label4.TabIndex = 25;
            label4.Text = "ServerUrl";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(129)));
            label3.Location = new System.Drawing.Point(284, 62);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(96, 17);
            label3.TabIndex = 21;
            label3.Text = "ApplicationKey";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(129)));
            label2.Location = new System.Drawing.Point(270, 35);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(110, 17);
            label2.TabIndex = 20;
            label2.Text = "ApplicationName";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(129)));
            label1.Location = new System.Drawing.Point(293, 8);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(87, 17);
            label1.TabIndex = 19;
            label1.Text = "ApplicationId";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnConfig,
            this.btnApplication,
            this.btnProduct,
            this.btnGet});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1161, 27);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
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
            // btnGet
            // 
            this.btnGet.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnGet.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnGet.Image = ((System.Drawing.Image)(resources.GetObject("btnGet.Image")));
            this.btnGet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(37, 24);
            this.btnGet.Text = "Get";
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel2.Controls.Add(label7);
            this.panel2.Controls.Add(this.txtApplicationType);
            this.panel2.Controls.Add(this.txtReleasePath);
            this.panel2.Controls.Add(this.txtClientPath);
            this.panel2.Controls.Add(label6);
            this.panel2.Controls.Add(label5);
            this.panel2.Controls.Add(this.txtApplicationKey);
            this.panel2.Controls.Add(label4);
            this.panel2.Controls.Add(this.txtServerUrl);
            this.panel2.Controls.Add(this.txtApplicationName);
            this.panel2.Controls.Add(this.txtApplicationId);
            this.panel2.Controls.Add(label3);
            this.panel2.Controls.Add(label2);
            this.panel2.Controls.Add(label1);
            this.panel2.Controls.Add(this.listBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 27);
            this.panel2.Name = "panel2";
            this.panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panel2.Size = new System.Drawing.Size(1161, 198);
            this.panel2.TabIndex = 14;
            // 
            // txtReleasePath
            // 
            this.txtReleasePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReleasePath.Location = new System.Drawing.Point(383, 168);
            this.txtReleasePath.Name = "txtReleasePath";
            this.txtReleasePath.ReadOnly = true;
            this.txtReleasePath.Size = new System.Drawing.Size(766, 21);
            this.txtReleasePath.TabIndex = 30;
            // 
            // txtClientPath
            // 
            this.txtClientPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtClientPath.Location = new System.Drawing.Point(383, 114);
            this.txtClientPath.Name = "txtClientPath";
            this.txtClientPath.ReadOnly = true;
            this.txtClientPath.Size = new System.Drawing.Size(766, 21);
            this.txtClientPath.TabIndex = 29;
            // 
            // txtApplicationKey
            // 
            this.txtApplicationKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtApplicationKey.Location = new System.Drawing.Point(383, 60);
            this.txtApplicationKey.Name = "txtApplicationKey";
            this.txtApplicationKey.ReadOnly = true;
            this.txtApplicationKey.Size = new System.Drawing.Size(766, 21);
            this.txtApplicationKey.TabIndex = 26;
            // 
            // txtServerUrl
            // 
            this.txtServerUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtServerUrl.Location = new System.Drawing.Point(383, 141);
            this.txtServerUrl.Name = "txtServerUrl";
            this.txtServerUrl.ReadOnly = true;
            this.txtServerUrl.Size = new System.Drawing.Size(766, 21);
            this.txtServerUrl.TabIndex = 24;
            // 
            // txtApplicationName
            // 
            this.txtApplicationName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtApplicationName.Location = new System.Drawing.Point(383, 33);
            this.txtApplicationName.Name = "txtApplicationName";
            this.txtApplicationName.ReadOnly = true;
            this.txtApplicationName.Size = new System.Drawing.Size(766, 21);
            this.txtApplicationName.TabIndex = 23;
            // 
            // txtApplicationId
            // 
            this.txtApplicationId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtApplicationId.Location = new System.Drawing.Point(383, 6);
            this.txtApplicationId.Name = "txtApplicationId";
            this.txtApplicationId.ReadOnly = true;
            this.txtApplicationId.Size = new System.Drawing.Size(766, 21);
            this.txtApplicationId.TabIndex = 22;
            // 
            // listBox1
            // 
            this.listBox1.DataSource = this.dsResource1;
            this.listBox1.DisplayMember = "Application.ApplicationName";
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.listBox1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(0, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(250, 198);
            this.listBox1.TabIndex = 17;
            this.listBox1.ValueMember = "Application.ApplicationId";
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // dsResource1
            // 
            this.dsResource1.DataSetName = "DSResource";
            this.dsResource1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 658);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1161, 22);
            this.statusStrip1.TabIndex = 15;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStrip3
            // 
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.btnAll,
            this.btnClear});
            this.toolStrip3.Location = new System.Drawing.Point(0, 225);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(1161, 27);
            this.toolStrip3.TabIndex = 16;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.toolStripLabel2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripLabel2.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.toolStripLabel2.ForeColor = System.Drawing.SystemColors.GrayText;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(0, 24);
            // 
            // btnAll
            // 
            this.btnAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnAll.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnAll.Image = ((System.Drawing.Image)(resources.GetObject("btnAll.Image")));
            this.btnAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(31, 24);
            this.btnAll.Text = "All";
            // 
            // btnClear
            // 
            this.btnClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnClear.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(48, 24);
            this.btnClear.Text = "Clear";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView1.Location = new System.Drawing.Point(0, 252);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.ShowCellErrors = false;
            this.dataGridView1.ShowCellToolTips = false;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.ShowRowErrors = false;
            this.dataGridView1.Size = new System.Drawing.Size(1161, 201);
            this.dataGridView1.TabIndex = 17;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 453);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1161, 5);
            this.splitter1.TabIndex = 18;
            this.splitter1.TabStop = false;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripButton2,
            this.btnSave});
            this.toolStrip2.Location = new System.Drawing.Point(0, 458);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1161, 27);
            this.toolStrip2.TabIndex = 19;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.toolStripLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripLabel1.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.toolStripLabel1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(0, 24);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(57, 24);
            this.toolStripButton2.Text = "Create";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSave.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(44, 24);
            this.btnSave.Text = "Save";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(0, 485);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.ShowCellErrors = false;
            this.dataGridView2.ShowCellToolTips = false;
            this.dataGridView2.ShowEditingIcon = false;
            this.dataGridView2.ShowRowErrors = false;
            this.dataGridView2.Size = new System.Drawing.Size(1161, 173);
            this.dataGridView2.TabIndex = 20;
            // 
            // txtApplicationType
            // 
            this.txtApplicationType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtApplicationType.Location = new System.Drawing.Point(383, 87);
            this.txtApplicationType.Name = "txtApplicationType";
            this.txtApplicationType.ReadOnly = true;
            this.txtApplicationType.Size = new System.Drawing.Size(766, 21);
            this.txtApplicationType.TabIndex = 31;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(129)));
            label7.Location = new System.Drawing.Point(277, 89);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(103, 17);
            label7.TabIndex = 32;
            label7.Text = "ApplicationType";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1161, 680);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.toolStrip3);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsResource1)).EndInit();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnProduct;
        private System.Windows.Forms.ToolStripButton btnApplication;
        private System.Windows.Forms.ToolStripButton btnConfig;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private Data.DSResource dsResource1;
        private System.Windows.Forms.ToolStripButton btnGet;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox txtReleasePath;
        private System.Windows.Forms.TextBox txtClientPath;
        private System.Windows.Forms.TextBox txtApplicationKey;
        private System.Windows.Forms.TextBox txtServerUrl;
        private System.Windows.Forms.TextBox txtApplicationName;
        private System.Windows.Forms.TextBox txtApplicationId;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripButton btnAll;
        private System.Windows.Forms.ToolStripButton btnClear;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TextBox txtApplicationType;
    }
}
namespace Elegant.Ui.Samples.ControlsSample
{
    partial class ServerInfoPage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuExtenderProvider1 = new Elegant.Ui.ContextMenuExtenderProvider(this.components);
            this.CalendarPageControls = new Elegant.Ui.Panel();
            this.TopControlsPanel = new Elegant.Ui.Panel();
            this.label5 = new Elegant.Ui.Label();
            this.label4 = new Elegant.Ui.Label();
            this.RBRunStatusStop = new Elegant.Ui.RadioButton();
            this.RBRunStatusRun = new Elegant.Ui.RadioButton();
            this.label3 = new Elegant.Ui.Label();
            this.label8 = new Elegant.Ui.Label();
            this.TBServerName = new System.Windows.Forms.TextBox();
            this.label2 = new Elegant.Ui.Label();
            this.TBServerId = new System.Windows.Forms.TextBox();
            this.label1 = new Elegant.Ui.Label();
            this.TBRealIpAddress = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.lbProductName = new Elegant.Ui.Label();
            this.dgUserInfo = new System.Windows.Forms.DataGridView();
            this.colServerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colServerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRealIpAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRunStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CalendarPageControls.SuspendLayout();
            this.TopControlsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgUserInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // CalendarPageControls
            // 
            this.CalendarPageControls.Controls.Add(this.TopControlsPanel);
            this.CalendarPageControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CalendarPageControls.Location = new System.Drawing.Point(0, 0);
            this.CalendarPageControls.Name = "CalendarPageControls";
            this.CalendarPageControls.Padding = new System.Windows.Forms.Padding(17, 0, 0, 14);
            this.CalendarPageControls.Size = new System.Drawing.Size(828, 680);
            this.CalendarPageControls.TabIndex = 2;
            this.CalendarPageControls.VisibleChanged += new System.EventHandler(this.CalendarPageControls_VisibleChanged);
            // 
            // TopControlsPanel
            // 
            this.TopControlsPanel.Controls.Add(this.label5);
            this.TopControlsPanel.Controls.Add(this.label4);
            this.TopControlsPanel.Controls.Add(this.RBRunStatusStop);
            this.TopControlsPanel.Controls.Add(this.RBRunStatusRun);
            this.TopControlsPanel.Controls.Add(this.label3);
            this.TopControlsPanel.Controls.Add(this.label8);
            this.TopControlsPanel.Controls.Add(this.TBServerName);
            this.TopControlsPanel.Controls.Add(this.label2);
            this.TopControlsPanel.Controls.Add(this.TBServerId);
            this.TopControlsPanel.Controls.Add(this.label1);
            this.TopControlsPanel.Controls.Add(this.TBRealIpAddress);
            this.TopControlsPanel.Controls.Add(this.btnDelete);
            this.TopControlsPanel.Controls.Add(this.btnSave);
            this.TopControlsPanel.Controls.Add(this.btnInsert);
            this.TopControlsPanel.Controls.Add(this.lbProductName);
            this.TopControlsPanel.Controls.Add(this.dgUserInfo);
            this.TopControlsPanel.Location = new System.Drawing.Point(17, 10);
            this.TopControlsPanel.Name = "TopControlsPanel";
            this.TopControlsPanel.Size = new System.Drawing.Size(794, 540);
            this.TopControlsPanel.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(118, 499);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(343, 19);
            this.label5.TabIndex = 46;
            this.label5.Text = "해당ID의 장비에 작업프로그램을 중지했을때만 상태를 변경할것";
            this.label5.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(250, 453);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(197, 19);
            this.label4.TabIndex = 45;
            this.label4.Text = "예) 192.168.0.3";
            this.label4.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RBRunStatusStop
            // 
            this.RBRunStatusStop.Id = "c9055274-1ffa-4047-a3b0-1135ae837782";
            this.RBRunStatusStop.Location = new System.Drawing.Point(187, 475);
            this.RBRunStatusStop.Name = "RBRunStatusStop";
            this.RBRunStatusStop.RadioGroupName = "rgRunStatus";
            this.RBRunStatusStop.Size = new System.Drawing.Size(104, 24);
            this.RBRunStatusStop.TabIndex = 22;
            this.RBRunStatusStop.Text = "중지";
            // 
            // RBRunStatusRun
            // 
            this.RBRunStatusRun.Id = "4e27b3a3-5630-4dfb-8c44-c1d8498b085f";
            this.RBRunStatusRun.Location = new System.Drawing.Point(118, 475);
            this.RBRunStatusRun.Name = "RBRunStatusRun";
            this.RBRunStatusRun.RadioGroupName = "rgRunStatus";
            this.RBRunStatusRun.Size = new System.Drawing.Size(104, 24);
            this.RBRunStatusRun.TabIndex = 21;
            this.RBRunStatusRun.Text = "실행";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(220, 399);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(348, 19);
            this.label3.TabIndex = 42;
            this.label3.Text = "예) 001, 002 번호를 증가시키는 방식. 장비마다 복수의 ID를 할당";
            this.label3.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(23, 425);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 19);
            this.label8.TabIndex = 35;
            this.label8.Text = "장비명";
            this.label8.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TBServerName
            // 
            this.TBServerName.Location = new System.Drawing.Point(117, 422);
            this.TBServerName.MaxLength = 20;
            this.TBServerName.Name = "TBServerName";
            this.TBServerName.Size = new System.Drawing.Size(174, 21);
            this.TBServerName.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(24, 399);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 19);
            this.label2.TabIndex = 33;
            this.label2.Text = "장비ID";
            this.label2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TBServerId
            // 
            this.TBServerId.Location = new System.Drawing.Point(118, 396);
            this.TBServerId.MaxLength = 3;
            this.TBServerId.Name = "TBServerId";
            this.TBServerId.Size = new System.Drawing.Size(86, 21);
            this.TBServerId.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(24, 452);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 19);
            this.label1.TabIndex = 31;
            this.label1.Text = "장비 IP주소";
            this.label1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TBRealIpAddress
            // 
            this.TBRealIpAddress.Location = new System.Drawing.Point(119, 449);
            this.TBRealIpAddress.MaxLength = 15;
            this.TBRealIpAddress.Name = "TBRealIpAddress";
            this.TBRealIpAddress.Size = new System.Drawing.Size(122, 21);
            this.TBRealIpAddress.TabIndex = 13;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(678, 475);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 53;
            this.btnDelete.Text = "삭제";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(597, 476);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 52;
            this.btnSave.Text = "저장";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(519, 477);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(75, 23);
            this.btnInsert.TabIndex = 51;
            this.btnInsert.Text = "새로 작성";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // lbProductName
            // 
            this.lbProductName.Location = new System.Drawing.Point(24, 479);
            this.lbProductName.Name = "lbProductName";
            this.lbProductName.Size = new System.Drawing.Size(85, 19);
            this.lbProductName.TabIndex = 13;
            this.lbProductName.Text = "실행/중지상태";
            this.lbProductName.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgUserInfo
            // 
            this.dgUserInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgUserInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colServerId,
            this.colServerName,
            this.colRealIpAddress,
            this.colRunStatus});
            this.dgUserInfo.Location = new System.Drawing.Point(3, 3);
            this.dgUserInfo.MultiSelect = false;
            this.dgUserInfo.Name = "dgUserInfo";
            this.dgUserInfo.ReadOnly = true;
            this.dgUserInfo.RowHeadersVisible = false;
            this.dgUserInfo.RowTemplate.Height = 23;
            this.dgUserInfo.Size = new System.Drawing.Size(788, 343);
            this.dgUserInfo.TabIndex = 0;
            this.dgUserInfo.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgProduct_CellMouseClick);
            this.dgUserInfo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgProduct_CellClick);
            this.dgUserInfo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgProduct_CellContentClick);
            // 
            // colServerId
            // 
            this.colServerId.DataPropertyName = "server_id";
            this.colServerId.HeaderText = "작업ID";
            this.colServerId.Name = "colServerId";
            this.colServerId.ReadOnly = true;
            this.colServerId.Width = 80;
            // 
            // colServerName
            // 
            this.colServerName.DataPropertyName = "server_name";
            this.colServerName.HeaderText = "장비명";
            this.colServerName.Name = "colServerName";
            this.colServerName.ReadOnly = true;
            this.colServerName.Width = 200;
            // 
            // colRealIpAddress
            // 
            this.colRealIpAddress.DataPropertyName = "real_ip_address";
            this.colRealIpAddress.HeaderText = "장비 IP주소";
            this.colRealIpAddress.Name = "colRealIpAddress";
            this.colRealIpAddress.ReadOnly = true;
            this.colRealIpAddress.Width = 150;
            // 
            // colRunStatus
            // 
            this.colRunStatus.DataPropertyName = "run_status";
            this.colRunStatus.HeaderText = "실행/중지 상태";
            this.colRunStatus.Name = "colRunStatus";
            this.colRunStatus.ReadOnly = true;
            this.colRunStatus.Width = 200;
            // 
            // ServerInfoPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CalendarPageControls);
            this.Name = "ServerInfoPage";
            this.Size = new System.Drawing.Size(828, 680);
            this.CalendarPageControls.ResumeLayout(false);
            this.TopControlsPanel.ResumeLayout(false);
            this.TopControlsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgUserInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ContextMenuExtenderProvider contextMenuExtenderProvider1;
        private Panel CalendarPageControls;
		private Panel TopControlsPanel;
        private System.Windows.Forms.DataGridView dgUserInfo;
        private Label lbProductName;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnInsert;
        private Label label1;
        private System.Windows.Forms.TextBox TBRealIpAddress;
        private Label label8;
        private System.Windows.Forms.TextBox TBServerName;
        private Label label2;
        private System.Windows.Forms.TextBox TBServerId;
        private Label label3;
        private RadioButton RBRunStatusStop;
        private RadioButton RBRunStatusRun;
        private Label label4;
        private Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn colServerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colServerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRealIpAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRunStatus;
    }
}

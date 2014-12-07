namespace Elegant.Ui.Samples.ControlsSample
{
    partial class IpInfoPage
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
            this.button1 = new System.Windows.Forms.Button();
            this.RBBrowserTypeFireFox = new Elegant.Ui.RadioButton();
            this.label7 = new Elegant.Ui.Label();
            this.TBPwdDaum = new System.Windows.Forms.TextBox();
            this.label8 = new Elegant.Ui.Label();
            this.TBLoginIdDaum = new System.Windows.Forms.TextBox();
            this.label6 = new Elegant.Ui.Label();
            this.TBPwdNaver = new System.Windows.Forms.TextBox();
            this.label5 = new Elegant.Ui.Label();
            this.RBUseTypeNormal = new Elegant.Ui.RadioButton();
            this.RBUseTypeLogin = new Elegant.Ui.RadioButton();
            this.label4 = new Elegant.Ui.Label();
            this.RBDeviceTypeMobile = new Elegant.Ui.RadioButton();
            this.RBDeviceTypeWeb = new Elegant.Ui.RadioButton();
            this.ButtonFileUpload = new System.Windows.Forms.Button();
            this.label2 = new Elegant.Ui.Label();
            this.TBIPAddress = new System.Windows.Forms.TextBox();
            this.label1 = new Elegant.Ui.Label();
            this.TBLoginIdNaver = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.label3 = new Elegant.Ui.Label();
            this.RBBrowserTypeIE = new Elegant.Ui.RadioButton();
            this.RBBrowserTypeChrome = new Elegant.Ui.RadioButton();
            this.dgUserInfo = new System.Windows.Forms.DataGridView();
            this.OpenFileDlgIpList = new System.Windows.Forms.OpenFileDialog();
            this.colIpAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBrowserType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeviceType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUseType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLoginIdNaver = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLoginPwdNaver = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLoginIdDaum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLoginPwdDaum = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.TopControlsPanel.Controls.Add(this.button1);
            this.TopControlsPanel.Controls.Add(this.RBBrowserTypeFireFox);
            this.TopControlsPanel.Controls.Add(this.label7);
            this.TopControlsPanel.Controls.Add(this.TBPwdDaum);
            this.TopControlsPanel.Controls.Add(this.label8);
            this.TopControlsPanel.Controls.Add(this.TBLoginIdDaum);
            this.TopControlsPanel.Controls.Add(this.label6);
            this.TopControlsPanel.Controls.Add(this.TBPwdNaver);
            this.TopControlsPanel.Controls.Add(this.label5);
            this.TopControlsPanel.Controls.Add(this.RBUseTypeNormal);
            this.TopControlsPanel.Controls.Add(this.RBUseTypeLogin);
            this.TopControlsPanel.Controls.Add(this.label4);
            this.TopControlsPanel.Controls.Add(this.RBDeviceTypeMobile);
            this.TopControlsPanel.Controls.Add(this.RBDeviceTypeWeb);
            this.TopControlsPanel.Controls.Add(this.ButtonFileUpload);
            this.TopControlsPanel.Controls.Add(this.label2);
            this.TopControlsPanel.Controls.Add(this.TBIPAddress);
            this.TopControlsPanel.Controls.Add(this.label1);
            this.TopControlsPanel.Controls.Add(this.TBLoginIdNaver);
            this.TopControlsPanel.Controls.Add(this.btnDelete);
            this.TopControlsPanel.Controls.Add(this.btnSave);
            this.TopControlsPanel.Controls.Add(this.btnInsert);
            this.TopControlsPanel.Controls.Add(this.label3);
            this.TopControlsPanel.Controls.Add(this.RBBrowserTypeIE);
            this.TopControlsPanel.Controls.Add(this.RBBrowserTypeChrome);
            this.TopControlsPanel.Controls.Add(this.dgUserInfo);
            this.TopControlsPanel.Location = new System.Drawing.Point(17, 10);
            this.TopControlsPanel.Name = "TopControlsPanel";
            this.TopControlsPanel.Size = new System.Drawing.Size(794, 656);
            this.TopControlsPanel.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(627, 420);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 71;
            this.button1.Text = "목록삭제";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // RBBrowserTypeFireFox
            // 
            this.RBBrowserTypeFireFox.Id = "2fed6d64-8d20-4e7f-9d65-1f169471c108";
            this.RBBrowserTypeFireFox.Location = new System.Drawing.Point(251, 458);
            this.RBBrowserTypeFireFox.Name = "RBBrowserTypeFireFox";
            this.RBBrowserTypeFireFox.RadioGroupName = "rgBrowserType";
            this.RBBrowserTypeFireFox.Size = new System.Drawing.Size(104, 24);
            this.RBBrowserTypeFireFox.TabIndex = 23;
            this.RBBrowserTypeFireFox.Text = "파이어폭스";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(21, 612);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 19);
            this.label7.TabIndex = 48;
            this.label7.Text = "다음비번";
            this.label7.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TBPwdDaum
            // 
            this.TBPwdDaum.Location = new System.Drawing.Point(116, 609);
            this.TBPwdDaum.MaxLength = 20;
            this.TBPwdDaum.Name = "TBPwdDaum";
            this.TBPwdDaum.Size = new System.Drawing.Size(86, 21);
            this.TBPwdDaum.TabIndex = 54;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(20, 583);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 19);
            this.label8.TabIndex = 46;
            this.label8.Text = "다음ID";
            this.label8.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TBLoginIdDaum
            // 
            this.TBLoginIdDaum.Location = new System.Drawing.Point(115, 580);
            this.TBLoginIdDaum.MaxLength = 20;
            this.TBLoginIdDaum.Name = "TBLoginIdDaum";
            this.TBLoginIdDaum.Size = new System.Drawing.Size(86, 21);
            this.TBLoginIdDaum.TabIndex = 53;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(21, 556);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 19);
            this.label6.TabIndex = 44;
            this.label6.Text = "네이버비번";
            this.label6.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TBPwdNaver
            // 
            this.TBPwdNaver.Location = new System.Drawing.Point(116, 553);
            this.TBPwdNaver.MaxLength = 20;
            this.TBPwdNaver.Name = "TBPwdNaver";
            this.TBPwdNaver.Size = new System.Drawing.Size(86, 21);
            this.TBPwdNaver.TabIndex = 52;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(19, 501);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 19);
            this.label5.TabIndex = 42;
            this.label5.Text = "로그인여부";
            this.label5.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RBUseTypeNormal
            // 
            this.RBUseTypeNormal.Id = "d679d9e4-28c1-4da6-b2fb-d7e57732893d";
            this.RBUseTypeNormal.Location = new System.Drawing.Point(185, 497);
            this.RBUseTypeNormal.Name = "RBUseTypeNormal";
            this.RBUseTypeNormal.RadioGroupName = "rgUseType";
            this.RBUseTypeNormal.Size = new System.Drawing.Size(104, 24);
            this.RBUseTypeNormal.TabIndex = 42;
            this.RBUseTypeNormal.Text = "비로그인";
            // 
            // RBUseTypeLogin
            // 
            this.RBUseTypeLogin.Id = "eb7fc939-0443-4cdc-80df-6185baf4a000";
            this.RBUseTypeLogin.Location = new System.Drawing.Point(116, 497);
            this.RBUseTypeLogin.Name = "RBUseTypeLogin";
            this.RBUseTypeLogin.RadioGroupName = "rgUseType";
            this.RBUseTypeLogin.Size = new System.Drawing.Size(104, 24);
            this.RBUseTypeLogin.TabIndex = 41;
            this.RBUseTypeLogin.Text = "로그인";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(19, 482);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 19);
            this.label4.TabIndex = 39;
            this.label4.Text = "단말유형";
            this.label4.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RBDeviceTypeMobile
            // 
            this.RBDeviceTypeMobile.Id = "3dd3c2c7-034f-4252-9aaa-94470e7ec2ab";
            this.RBDeviceTypeMobile.Location = new System.Drawing.Point(185, 478);
            this.RBDeviceTypeMobile.Name = "RBDeviceTypeMobile";
            this.RBDeviceTypeMobile.RadioGroupName = "rgDeviceType";
            this.RBDeviceTypeMobile.Size = new System.Drawing.Size(104, 24);
            this.RBDeviceTypeMobile.TabIndex = 32;
            this.RBDeviceTypeMobile.Text = "모바일";
            // 
            // RBDeviceTypeWeb
            // 
            this.RBDeviceTypeWeb.Id = "7559f8b4-804a-4885-93e9-f47deeb7f3c8";
            this.RBDeviceTypeWeb.Location = new System.Drawing.Point(116, 478);
            this.RBDeviceTypeWeb.Name = "RBDeviceTypeWeb";
            this.RBDeviceTypeWeb.RadioGroupName = "rgDeviceType";
            this.RBDeviceTypeWeb.Size = new System.Drawing.Size(104, 24);
            this.RBDeviceTypeWeb.TabIndex = 31;
            this.RBDeviceTypeWeb.Text = "웹";
            // 
            // ButtonFileUpload
            // 
            this.ButtonFileUpload.Location = new System.Drawing.Point(708, 420);
            this.ButtonFileUpload.Name = "ButtonFileUpload";
            this.ButtonFileUpload.Size = new System.Drawing.Size(75, 23);
            this.ButtonFileUpload.TabIndex = 72;
            this.ButtonFileUpload.Text = "목록업로드";
            this.ButtonFileUpload.UseVisualStyleBackColor = true;
            this.ButtonFileUpload.Click += new System.EventHandler(this.ButtonFileUpload_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(21, 436);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 19);
            this.label2.TabIndex = 33;
            this.label2.Text = "IP주소";
            this.label2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TBIPAddress
            // 
            this.TBIPAddress.Location = new System.Drawing.Point(115, 433);
            this.TBIPAddress.MaxLength = 20;
            this.TBIPAddress.Name = "TBIPAddress";
            this.TBIPAddress.Size = new System.Drawing.Size(86, 21);
            this.TBIPAddress.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(20, 527);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 19);
            this.label1.TabIndex = 31;
            this.label1.Text = "네이버ID";
            this.label1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TBLoginIdNaver
            // 
            this.TBLoginIdNaver.Location = new System.Drawing.Point(115, 524);
            this.TBLoginIdNaver.MaxLength = 20;
            this.TBLoginIdNaver.Name = "TBLoginIdNaver";
            this.TBLoginIdNaver.Size = new System.Drawing.Size(86, 21);
            this.TBLoginIdNaver.TabIndex = 51;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(685, 612);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 63;
            this.btnDelete.Text = "삭제";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(604, 613);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 62;
            this.btnSave.Text = "저장";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(526, 613);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(75, 23);
            this.btnInsert.TabIndex = 61;
            this.btnInsert.Text = "새로 작성";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(19, 461);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 19);
            this.label3.TabIndex = 18;
            this.label3.Text = "브라우저유형";
            this.label3.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RBBrowserTypeIE
            // 
            this.RBBrowserTypeIE.Id = "34bf0f9a-8884-4747-967d-3bad2550470c";
            this.RBBrowserTypeIE.Location = new System.Drawing.Point(165, 457);
            this.RBBrowserTypeIE.Name = "RBBrowserTypeIE";
            this.RBBrowserTypeIE.RadioGroupName = "rgBrowserType";
            this.RBBrowserTypeIE.Size = new System.Drawing.Size(104, 24);
            this.RBBrowserTypeIE.TabIndex = 22;
            this.RBBrowserTypeIE.Text = "익스플로어";
            // 
            // RBBrowserTypeChrome
            // 
            this.RBBrowserTypeChrome.Id = "a2e44ef3-f381-4249-bbc4-329ca2946e5c";
            this.RBBrowserTypeChrome.Location = new System.Drawing.Point(116, 457);
            this.RBBrowserTypeChrome.Name = "RBBrowserTypeChrome";
            this.RBBrowserTypeChrome.RadioGroupName = "rgBrowserType";
            this.RBBrowserTypeChrome.Size = new System.Drawing.Size(104, 24);
            this.RBBrowserTypeChrome.TabIndex = 21;
            this.RBBrowserTypeChrome.Text = "크롬";
            // 
            // dgUserInfo
            // 
            this.dgUserInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgUserInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIpAddress,
            this.colBrowserType,
            this.colDeviceType,
            this.colUseType,
            this.colLoginIdNaver,
            this.colLoginPwdNaver,
            this.colLoginIdDaum,
            this.colLoginPwdDaum});
            this.dgUserInfo.Location = new System.Drawing.Point(3, 3);
            this.dgUserInfo.MultiSelect = false;
            this.dgUserInfo.Name = "dgUserInfo";
            this.dgUserInfo.ReadOnly = true;
            this.dgUserInfo.RowHeadersVisible = false;
            this.dgUserInfo.RowTemplate.Height = 23;
            this.dgUserInfo.Size = new System.Drawing.Size(788, 411);
            this.dgUserInfo.TabIndex = 0;
            this.dgUserInfo.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgProduct_CellMouseClick);
            this.dgUserInfo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgProduct_CellClick);
            this.dgUserInfo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgProduct_CellContentClick);
            // 
            // OpenFileDlgIpList
            // 
            this.OpenFileDlgIpList.DefaultExt = "*.txt";
            this.OpenFileDlgIpList.FileName = "ipList.txt";
            this.OpenFileDlgIpList.Filter = "텍스트 파일(*.txt)|*.txt";
            this.OpenFileDlgIpList.Title = "IP목록 등록";
            // 
            // colIpAddress
            // 
            this.colIpAddress.DataPropertyName = "ip_address";
            this.colIpAddress.HeaderText = "IP주소";
            this.colIpAddress.Name = "colIpAddress";
            this.colIpAddress.ReadOnly = true;
            this.colIpAddress.Width = 120;
            // 
            // colBrowserType
            // 
            this.colBrowserType.DataPropertyName = "browser_type";
            this.colBrowserType.HeaderText = "브라우저유형";
            this.colBrowserType.Name = "colBrowserType";
            this.colBrowserType.ReadOnly = true;
            // 
            // colDeviceType
            // 
            this.colDeviceType.DataPropertyName = "device_type";
            this.colDeviceType.HeaderText = "모바일/웹";
            this.colDeviceType.Name = "colDeviceType";
            this.colDeviceType.ReadOnly = true;
            this.colDeviceType.Width = 90;
            // 
            // colUseType
            // 
            this.colUseType.DataPropertyName = "use_type";
            this.colUseType.HeaderText = "로그인여부";
            this.colUseType.Name = "colUseType";
            this.colUseType.ReadOnly = true;
            this.colUseType.Width = 90;
            // 
            // colLoginIdNaver
            // 
            this.colLoginIdNaver.DataPropertyName = "login_id_naver";
            this.colLoginIdNaver.HeaderText = "네이버ID";
            this.colLoginIdNaver.Name = "colLoginIdNaver";
            this.colLoginIdNaver.ReadOnly = true;
            this.colLoginIdNaver.Width = 80;
            // 
            // colLoginPwdNaver
            // 
            this.colLoginPwdNaver.DataPropertyName = "login_pwd_naver";
            this.colLoginPwdNaver.HeaderText = "네이버비번";
            this.colLoginPwdNaver.Name = "colLoginPwdNaver";
            this.colLoginPwdNaver.ReadOnly = true;
            this.colLoginPwdNaver.Width = 90;
            // 
            // colLoginIdDaum
            // 
            this.colLoginIdDaum.DataPropertyName = "login_id_daum";
            this.colLoginIdDaum.HeaderText = "다음ID";
            this.colLoginIdDaum.Name = "colLoginIdDaum";
            this.colLoginIdDaum.ReadOnly = true;
            this.colLoginIdDaum.Width = 80;
            // 
            // colLoginPwdDaum
            // 
            this.colLoginPwdDaum.DataPropertyName = "login_pwd_daum";
            this.colLoginPwdDaum.HeaderText = "다음비번";
            this.colLoginPwdDaum.Name = "colLoginPwdDaum";
            this.colLoginPwdDaum.ReadOnly = true;
            this.colLoginPwdDaum.Width = 80;
            // 
            // IpInfoPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CalendarPageControls);
            this.Name = "IpInfoPage";
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
        private Label label3;
        private RadioButton RBBrowserTypeIE;
        private RadioButton RBBrowserTypeChrome;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnInsert;
        private Label label1;
        private System.Windows.Forms.TextBox TBLoginIdNaver;
        private Label label2;
        private System.Windows.Forms.TextBox TBIPAddress;
        private System.Windows.Forms.Button ButtonFileUpload;
        private System.Windows.Forms.OpenFileDialog OpenFileDlgIpList;
        private RadioButton RBBrowserTypeFireFox;
        private Label label7;
        private System.Windows.Forms.TextBox TBPwdDaum;
        private Label label8;
        private System.Windows.Forms.TextBox TBLoginIdDaum;
        private Label label6;
        private System.Windows.Forms.TextBox TBPwdNaver;
        private Label label5;
        private RadioButton RBUseTypeNormal;
        private RadioButton RBUseTypeLogin;
        private Label label4;
        private RadioButton RBDeviceTypeMobile;
        private RadioButton RBDeviceTypeWeb;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIpAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBrowserType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeviceType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUseType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLoginIdNaver;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLoginPwdNaver;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLoginIdDaum;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLoginPwdDaum;
    }
}

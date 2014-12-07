namespace Elegant.Ui.Samples.ControlsSample
{
    partial class UserInfoPage
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
            this.tbEtc = new System.Windows.Forms.TextBox();
            this.label9 = new Elegant.Ui.Label();
            this.tbCompanyName = new System.Windows.Forms.TextBox();
            this.label4 = new Elegant.Ui.Label();
            this.tbPhone = new System.Windows.Forms.TextBox();
            this.label8 = new Elegant.Ui.Label();
            this.tbPasswd = new System.Windows.Forms.TextBox();
            this.label2 = new Elegant.Ui.Label();
            this.tbUserId = new System.Windows.Forms.TextBox();
            this.label1 = new Elegant.Ui.Label();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.label7 = new Elegant.Ui.Label();
            this.tbUpdateDate = new System.Windows.Forms.TextBox();
            this.label6 = new Elegant.Ui.Label();
            this.tbCreateDate = new System.Windows.Forms.TextBox();
            this.label3 = new Elegant.Ui.Label();
            this.rbUserTypeCust = new Elegant.Ui.RadioButton();
            this.rbUserTypeAdmin = new Elegant.Ui.RadioButton();
            this.lbProductName = new Elegant.Ui.Label();
            this.tbMobile = new System.Windows.Forms.TextBox();
            this.dgUserInfo = new System.Windows.Forms.DataGridView();
            this.colUserId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPasswd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUserType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCompany = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEtc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUpdateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.TopControlsPanel.Controls.Add(this.tbEtc);
            this.TopControlsPanel.Controls.Add(this.label9);
            this.TopControlsPanel.Controls.Add(this.tbCompanyName);
            this.TopControlsPanel.Controls.Add(this.label4);
            this.TopControlsPanel.Controls.Add(this.tbPhone);
            this.TopControlsPanel.Controls.Add(this.label8);
            this.TopControlsPanel.Controls.Add(this.tbPasswd);
            this.TopControlsPanel.Controls.Add(this.label2);
            this.TopControlsPanel.Controls.Add(this.tbUserId);
            this.TopControlsPanel.Controls.Add(this.label1);
            this.TopControlsPanel.Controls.Add(this.tbEmail);
            this.TopControlsPanel.Controls.Add(this.btnDelete);
            this.TopControlsPanel.Controls.Add(this.btnSave);
            this.TopControlsPanel.Controls.Add(this.btnInsert);
            this.TopControlsPanel.Controls.Add(this.label7);
            this.TopControlsPanel.Controls.Add(this.tbUpdateDate);
            this.TopControlsPanel.Controls.Add(this.label6);
            this.TopControlsPanel.Controls.Add(this.tbCreateDate);
            this.TopControlsPanel.Controls.Add(this.label3);
            this.TopControlsPanel.Controls.Add(this.rbUserTypeCust);
            this.TopControlsPanel.Controls.Add(this.rbUserTypeAdmin);
            this.TopControlsPanel.Controls.Add(this.lbProductName);
            this.TopControlsPanel.Controls.Add(this.tbMobile);
            this.TopControlsPanel.Controls.Add(this.dgUserInfo);
            this.TopControlsPanel.Location = new System.Drawing.Point(17, 10);
            this.TopControlsPanel.Name = "TopControlsPanel";
            this.TopControlsPanel.Size = new System.Drawing.Size(794, 638);
            this.TopControlsPanel.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(33, 546);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 19);
            this.label5.TabIndex = 41;
            this.label5.Text = "기타";
            this.label5.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbEtc
            // 
            this.tbEtc.Location = new System.Drawing.Point(127, 543);
            this.tbEtc.MaxLength = 200;
            this.tbEtc.Name = "tbEtc";
            this.tbEtc.Size = new System.Drawing.Size(300, 21);
            this.tbEtc.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(32, 519);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 19);
            this.label9.TabIndex = 39;
            this.label9.Text = "업체명";
            this.label9.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbCompanyName
            // 
            this.tbCompanyName.Location = new System.Drawing.Point(127, 516);
            this.tbCompanyName.MaxLength = 200;
            this.tbCompanyName.Name = "tbCompanyName";
            this.tbCompanyName.Size = new System.Drawing.Size(300, 21);
            this.tbCompanyName.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(32, 493);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 19);
            this.label4.TabIndex = 37;
            this.label4.Text = "일반전화";
            this.label4.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbPhone
            // 
            this.tbPhone.Location = new System.Drawing.Point(127, 490);
            this.tbPhone.MaxLength = 11;
            this.tbPhone.Name = "tbPhone";
            this.tbPhone.Size = new System.Drawing.Size(159, 21);
            this.tbPhone.TabIndex = 17;
            this.tbPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbMobile_KeyPress);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(31, 395);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 19);
            this.label8.TabIndex = 35;
            this.label8.Text = "비번";
            this.label8.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbPasswd
            // 
            this.tbPasswd.Location = new System.Drawing.Point(125, 392);
            this.tbPasswd.MaxLength = 18;
            this.tbPasswd.Name = "tbPasswd";
            this.tbPasswd.Size = new System.Drawing.Size(105, 21);
            this.tbPasswd.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(32, 369);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 19);
            this.label2.TabIndex = 33;
            this.label2.Text = "사용자ID";
            this.label2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbUserId
            // 
            this.tbUserId.Location = new System.Drawing.Point(126, 366);
            this.tbUserId.MaxLength = 10;
            this.tbUserId.Name = "tbUserId";
            this.tbUserId.Size = new System.Drawing.Size(105, 21);
            this.tbUserId.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(32, 440);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 19);
            this.label1.TabIndex = 31;
            this.label1.Text = "이메일";
            this.label1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(127, 437);
            this.tbEmail.MaxLength = 100;
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(159, 21);
            this.tbEmail.TabIndex = 15;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(683, 595);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 53;
            this.btnDelete.Text = "삭제";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(602, 596);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 52;
            this.btnSave.Text = "저장";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(524, 597);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(75, 23);
            this.btnInsert.TabIndex = 51;
            this.btnInsert.Text = "새로 작성";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(31, 599);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 19);
            this.label7.TabIndex = 26;
            this.label7.Text = "최종수정일";
            this.label7.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbUpdateDate
            // 
            this.tbUpdateDate.Location = new System.Drawing.Point(127, 596);
            this.tbUpdateDate.Name = "tbUpdateDate";
            this.tbUpdateDate.ReadOnly = true;
            this.tbUpdateDate.Size = new System.Drawing.Size(209, 21);
            this.tbUpdateDate.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(30, 573);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 19);
            this.label6.TabIndex = 24;
            this.label6.Text = "생성일";
            this.label6.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbCreateDate
            // 
            this.tbCreateDate.Location = new System.Drawing.Point(127, 570);
            this.tbCreateDate.Name = "tbCreateDate";
            this.tbCreateDate.ReadOnly = true;
            this.tbCreateDate.Size = new System.Drawing.Size(209, 21);
            this.tbCreateDate.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(30, 418);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 19);
            this.label3.TabIndex = 18;
            this.label3.Text = "사용자유형";
            this.label3.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rbUserTypeCust
            // 
            this.rbUserTypeCust.Id = "81e30fd4-c3a8-4605-ae76-147c65059783";
            this.rbUserTypeCust.Location = new System.Drawing.Point(196, 414);
            this.rbUserTypeCust.Name = "rbUserTypeCust";
            this.rbUserTypeCust.RadioGroupName = "rgUserType";
            this.rbUserTypeCust.Size = new System.Drawing.Size(104, 24);
            this.rbUserTypeCust.TabIndex = 14;
            this.rbUserTypeCust.Text = "고객";
            // 
            // rbUserTypeAdmin
            // 
            this.rbUserTypeAdmin.Id = "dd2254de-2700-448a-81d6-71b706d16925";
            this.rbUserTypeAdmin.Location = new System.Drawing.Point(127, 414);
            this.rbUserTypeAdmin.Name = "rbUserTypeAdmin";
            this.rbUserTypeAdmin.RadioGroupName = "rgUserType";
            this.rbUserTypeAdmin.Size = new System.Drawing.Size(104, 24);
            this.rbUserTypeAdmin.TabIndex = 13;
            this.rbUserTypeAdmin.Text = "관리자";
            // 
            // lbProductName
            // 
            this.lbProductName.Location = new System.Drawing.Point(32, 467);
            this.lbProductName.Name = "lbProductName";
            this.lbProductName.Size = new System.Drawing.Size(85, 19);
            this.lbProductName.TabIndex = 13;
            this.lbProductName.Text = "휴대폰";
            this.lbProductName.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbMobile
            // 
            this.tbMobile.Location = new System.Drawing.Point(127, 464);
            this.tbMobile.MaxLength = 11;
            this.tbMobile.Name = "tbMobile";
            this.tbMobile.Size = new System.Drawing.Size(159, 21);
            this.tbMobile.TabIndex = 16;
            this.tbMobile.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbMobile_KeyPress);
            // 
            // dgUserInfo
            // 
            this.dgUserInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgUserInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colUserId,
            this.colPasswd,
            this.colUserType,
            this.colEmail,
            this.colMobile,
            this.colPhone,
            this.colCompany,
            this.colEtc,
            this.colCreateDate,
            this.colUpdateDate});
            this.dgUserInfo.Location = new System.Drawing.Point(3, 3);
            this.dgUserInfo.MultiSelect = false;
            this.dgUserInfo.Name = "dgUserInfo";
            this.dgUserInfo.ReadOnly = true;
            this.dgUserInfo.RowHeadersVisible = false;
            this.dgUserInfo.RowTemplate.Height = 23;
            this.dgUserInfo.Size = new System.Drawing.Size(788, 332);
            this.dgUserInfo.TabIndex = 0;
            this.dgUserInfo.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgProduct_CellMouseClick);
            this.dgUserInfo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgProduct_CellClick);
            this.dgUserInfo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgProduct_CellContentClick);
            // 
            // colUserId
            // 
            this.colUserId.DataPropertyName = "user_id";
            this.colUserId.HeaderText = "사용자ID";
            this.colUserId.Name = "colUserId";
            this.colUserId.ReadOnly = true;
            this.colUserId.Width = 80;
            // 
            // colPasswd
            // 
            this.colPasswd.DataPropertyName = "passwd";
            this.colPasswd.HeaderText = "비번";
            this.colPasswd.Name = "colPasswd";
            this.colPasswd.ReadOnly = true;
            // 
            // colUserType
            // 
            this.colUserType.DataPropertyName = "user_type";
            this.colUserType.HeaderText = "사용자 유형";
            this.colUserType.Name = "colUserType";
            this.colUserType.ReadOnly = true;
            this.colUserType.Width = 70;
            // 
            // colEmail
            // 
            this.colEmail.DataPropertyName = "email";
            this.colEmail.HeaderText = "이메일";
            this.colEmail.Name = "colEmail";
            this.colEmail.ReadOnly = true;
            // 
            // colMobile
            // 
            this.colMobile.DataPropertyName = "mobile";
            this.colMobile.HeaderText = "휴대전화";
            this.colMobile.Name = "colMobile";
            this.colMobile.ReadOnly = true;
            // 
            // colPhone
            // 
            this.colPhone.DataPropertyName = "phone";
            this.colPhone.HeaderText = "일반전화";
            this.colPhone.Name = "colPhone";
            this.colPhone.ReadOnly = true;
            // 
            // colCompany
            // 
            this.colCompany.DataPropertyName = "company_name";
            this.colCompany.HeaderText = "업체명";
            this.colCompany.Name = "colCompany";
            this.colCompany.ReadOnly = true;
            // 
            // colEtc
            // 
            this.colEtc.DataPropertyName = "etc";
            this.colEtc.HeaderText = "기타";
            this.colEtc.Name = "colEtc";
            this.colEtc.ReadOnly = true;
            // 
            // colCreateDate
            // 
            this.colCreateDate.DataPropertyName = "create_date";
            this.colCreateDate.HeaderText = "생성일";
            this.colCreateDate.Name = "colCreateDate";
            this.colCreateDate.ReadOnly = true;
            // 
            // colUpdateDate
            // 
            this.colUpdateDate.DataPropertyName = "update_date";
            this.colUpdateDate.HeaderText = "최종수정일";
            this.colUpdateDate.Name = "colUpdateDate";
            this.colUpdateDate.ReadOnly = true;
            // 
            // UserInfoPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CalendarPageControls);
            this.Name = "UserInfoPage";
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
        private RadioButton rbUserTypeCust;
        private RadioButton rbUserTypeAdmin;
        private Label lbProductName;
        private System.Windows.Forms.TextBox tbMobile;
        private Label label7;
        private System.Windows.Forms.TextBox tbUpdateDate;
        private Label label6;
        private System.Windows.Forms.TextBox tbCreateDate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnInsert;
        private Label label1;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPasswd;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCompany;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEtc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUpdateDate;
        private Label label8;
        private System.Windows.Forms.TextBox tbPasswd;
        private Label label2;
        private System.Windows.Forms.TextBox tbUserId;
        private Label label5;
        private System.Windows.Forms.TextBox tbEtc;
        private Label label9;
        private System.Windows.Forms.TextBox tbCompanyName;
        private Label label4;
        private System.Windows.Forms.TextBox tbPhone;
    }
}

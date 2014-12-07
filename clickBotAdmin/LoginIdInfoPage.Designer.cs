namespace Elegant.Ui.Samples.ControlsSample
{
    partial class LoginIdInfoPage
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
            this.label8 = new Elegant.Ui.Label();
            this.TBPasswd = new System.Windows.Forms.TextBox();
            this.label2 = new Elegant.Ui.Label();
            this.TBLoginId = new System.Windows.Forms.TextBox();
            this.label1 = new Elegant.Ui.Label();
            this.TBUserID = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.label7 = new Elegant.Ui.Label();
            this.TBUpdateDate = new System.Windows.Forms.TextBox();
            this.label6 = new Elegant.Ui.Label();
            this.TBCreateDate = new System.Windows.Forms.TextBox();
            this.label3 = new Elegant.Ui.Label();
            this.RBIdTypeDaum = new Elegant.Ui.RadioButton();
            this.RBIdTypeNaver = new Elegant.Ui.RadioButton();
            this.dgUserInfo = new System.Windows.Forms.DataGridView();
            this.colLoginId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPasswd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUserId = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.TopControlsPanel.Controls.Add(this.label8);
            this.TopControlsPanel.Controls.Add(this.TBPasswd);
            this.TopControlsPanel.Controls.Add(this.label2);
            this.TopControlsPanel.Controls.Add(this.TBLoginId);
            this.TopControlsPanel.Controls.Add(this.label1);
            this.TopControlsPanel.Controls.Add(this.TBUserID);
            this.TopControlsPanel.Controls.Add(this.btnDelete);
            this.TopControlsPanel.Controls.Add(this.btnSave);
            this.TopControlsPanel.Controls.Add(this.btnInsert);
            this.TopControlsPanel.Controls.Add(this.label7);
            this.TopControlsPanel.Controls.Add(this.TBUpdateDate);
            this.TopControlsPanel.Controls.Add(this.label6);
            this.TopControlsPanel.Controls.Add(this.TBCreateDate);
            this.TopControlsPanel.Controls.Add(this.label3);
            this.TopControlsPanel.Controls.Add(this.RBIdTypeDaum);
            this.TopControlsPanel.Controls.Add(this.RBIdTypeNaver);
            this.TopControlsPanel.Controls.Add(this.dgUserInfo);
            this.TopControlsPanel.Location = new System.Drawing.Point(17, 10);
            this.TopControlsPanel.Name = "TopControlsPanel";
            this.TopControlsPanel.Size = new System.Drawing.Size(794, 646);
            this.TopControlsPanel.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(28, 508);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 19);
            this.label8.TabIndex = 35;
            this.label8.Text = "비번";
            this.label8.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TBPasswd
            // 
            this.TBPasswd.Location = new System.Drawing.Point(122, 505);
            this.TBPasswd.MaxLength = 20;
            this.TBPasswd.Name = "TBPasswd";
            this.TBPasswd.Size = new System.Drawing.Size(86, 21);
            this.TBPasswd.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(29, 482);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 19);
            this.label2.TabIndex = 33;
            this.label2.Text = "사용자ID";
            this.label2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TBLoginId
            // 
            this.TBLoginId.Location = new System.Drawing.Point(123, 479);
            this.TBLoginId.MaxLength = 20;
            this.TBLoginId.Name = "TBLoginId";
            this.TBLoginId.Size = new System.Drawing.Size(86, 21);
            this.TBLoginId.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(29, 553);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 19);
            this.label1.TabIndex = 31;
            this.label1.Text = "고객ID";
            this.label1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TBUserID
            // 
            this.TBUserID.Location = new System.Drawing.Point(124, 550);
            this.TBUserID.MaxLength = 10;
            this.TBUserID.Name = "TBUserID";
            this.TBUserID.Size = new System.Drawing.Size(86, 21);
            this.TBUserID.TabIndex = 30;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(680, 602);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 43;
            this.btnDelete.Text = "삭제";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(599, 603);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 42;
            this.btnSave.Text = "저장";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(521, 604);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(75, 23);
            this.btnInsert.TabIndex = 41;
            this.btnInsert.Text = "새로 작성";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(28, 606);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 19);
            this.label7.TabIndex = 26;
            this.label7.Text = "최종수정일";
            this.label7.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TBUpdateDate
            // 
            this.TBUpdateDate.Location = new System.Drawing.Point(124, 603);
            this.TBUpdateDate.Name = "TBUpdateDate";
            this.TBUpdateDate.ReadOnly = true;
            this.TBUpdateDate.Size = new System.Drawing.Size(209, 21);
            this.TBUpdateDate.TabIndex = 33;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(27, 580);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 19);
            this.label6.TabIndex = 24;
            this.label6.Text = "생성일";
            this.label6.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TBCreateDate
            // 
            this.TBCreateDate.Location = new System.Drawing.Point(124, 577);
            this.TBCreateDate.Name = "TBCreateDate";
            this.TBCreateDate.ReadOnly = true;
            this.TBCreateDate.Size = new System.Drawing.Size(209, 21);
            this.TBCreateDate.TabIndex = 31;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(27, 531);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 19);
            this.label3.TabIndex = 18;
            this.label3.Text = "사용자유형";
            this.label3.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RBIdTypeDaum
            // 
            this.RBIdTypeDaum.Id = "a051ecd9-9400-46da-908c-f6b63644d1e5";
            this.RBIdTypeDaum.Location = new System.Drawing.Point(193, 527);
            this.RBIdTypeDaum.Name = "RBIdTypeDaum";
            this.RBIdTypeDaum.RadioGroupName = "rgIdType";
            this.RBIdTypeDaum.Size = new System.Drawing.Size(104, 24);
            this.RBIdTypeDaum.TabIndex = 22;
            this.RBIdTypeDaum.Text = "다음";
            // 
            // RBIdTypeNaver
            // 
            this.RBIdTypeNaver.Id = "9c0542ca-fe65-4d61-8eb9-ce0d7ee155a5";
            this.RBIdTypeNaver.Location = new System.Drawing.Point(124, 527);
            this.RBIdTypeNaver.Name = "RBIdTypeNaver";
            this.RBIdTypeNaver.RadioGroupName = "rgIdType";
            this.RBIdTypeNaver.Size = new System.Drawing.Size(104, 24);
            this.RBIdTypeNaver.TabIndex = 21;
            this.RBIdTypeNaver.Text = "네이버";
            // 
            // dgUserInfo
            // 
            this.dgUserInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgUserInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colLoginId,
            this.colPasswd,
            this.colIdType,
            this.colUserId,
            this.colCreateDate,
            this.colUpdateDate});
            this.dgUserInfo.Location = new System.Drawing.Point(3, 3);
            this.dgUserInfo.MultiSelect = false;
            this.dgUserInfo.Name = "dgUserInfo";
            this.dgUserInfo.ReadOnly = true;
            this.dgUserInfo.RowHeadersVisible = false;
            this.dgUserInfo.RowTemplate.Height = 23;
            this.dgUserInfo.Size = new System.Drawing.Size(788, 446);
            this.dgUserInfo.TabIndex = 0;
            this.dgUserInfo.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgProduct_CellMouseClick);
            this.dgUserInfo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgProduct_CellClick);
            this.dgUserInfo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgProduct_CellContentClick);
            // 
            // colLoginId
            // 
            this.colLoginId.DataPropertyName = "login_id";
            this.colLoginId.HeaderText = "사용자ID";
            this.colLoginId.Name = "colLoginId";
            this.colLoginId.ReadOnly = true;
            this.colLoginId.Width = 80;
            // 
            // colPasswd
            // 
            this.colPasswd.DataPropertyName = "passwd";
            this.colPasswd.HeaderText = "비번";
            this.colPasswd.Name = "colPasswd";
            this.colPasswd.ReadOnly = true;
            // 
            // colIdType
            // 
            this.colIdType.DataPropertyName = "id_type";
            this.colIdType.HeaderText = "계정 유형(네이버/다음)";
            this.colIdType.Name = "colIdType";
            this.colIdType.ReadOnly = true;
            this.colIdType.Width = 200;
            // 
            // colUserId
            // 
            this.colUserId.DataPropertyName = "userid";
            this.colUserId.HeaderText = "고객ID";
            this.colUserId.Name = "colUserId";
            this.colUserId.ReadOnly = true;
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
            // LoginIdInfoPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CalendarPageControls);
            this.Name = "LoginIdInfoPage";
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
        private RadioButton RBIdTypeDaum;
        private RadioButton RBIdTypeNaver;
        private Label label7;
        private System.Windows.Forms.TextBox TBUpdateDate;
        private Label label6;
        private System.Windows.Forms.TextBox TBCreateDate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnInsert;
        private Label label1;
        private System.Windows.Forms.TextBox TBUserID;
        private Label label8;
        private System.Windows.Forms.TextBox TBPasswd;
        private Label label2;
        private System.Windows.Forms.TextBox TBLoginId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLoginId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPasswd;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUpdateDate;
    }
}

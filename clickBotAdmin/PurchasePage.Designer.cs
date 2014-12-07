namespace Elegant.Ui.Samples.ControlsSample
{
    partial class PurchasePage
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
            this.label12 = new Elegant.Ui.Label();
            this.TBTaskType = new System.Windows.Forms.TextBox();
            this.label5 = new Elegant.Ui.Label();
            this.TBSiteType = new System.Windows.Forms.TextBox();
            this.TBDeviceType = new System.Windows.Forms.TextBox();
            this.DTPickerPurchaseDate = new System.Windows.Forms.DateTimePicker();
            this.CBProductDetail = new System.Windows.Forms.ComboBox();
            this.CBUserDetail = new System.Windows.Forms.ComboBox();
            this.label9 = new Elegant.Ui.Label();
            this.rbUseFlagN = new Elegant.Ui.RadioButton();
            this.rbUseFlagY = new Elegant.Ui.RadioButton();
            this.label4 = new Elegant.Ui.Label();
            this.rbPurchaseTypeCash = new Elegant.Ui.RadioButton();
            this.rbPurchaseTypeCard = new Elegant.Ui.RadioButton();
            this.label1 = new Elegant.Ui.Label();
            this.label11 = new Elegant.Ui.Label();
            this.label10 = new Elegant.Ui.Label();
            this.label8 = new Elegant.Ui.Label();
            this.label2 = new Elegant.Ui.Label();
            this.tbPurchaseId = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.label7 = new Elegant.Ui.Label();
            this.tbUpdateDate = new System.Windows.Forms.TextBox();
            this.label6 = new Elegant.Ui.Label();
            this.tbCreateDate = new System.Windows.Forms.TextBox();
            this.label3 = new Elegant.Ui.Label();
            this.lbProductName = new Elegant.Ui.Label();
            this.tbPurchaseAmount = new System.Windows.Forms.TextBox();
            this.DGPurchase = new System.Windows.Forms.DataGridView();
            this.colPurchaseId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUserId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeviceType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSiteType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTaskType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPurchaseDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPurchaseAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPurchaseType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUsedFlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUpdateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CalendarPageControls.SuspendLayout();
            this.TopControlsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGPurchase)).BeginInit();
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
            // 
            // TopControlsPanel
            // 
            this.TopControlsPanel.Controls.Add(this.label12);
            this.TopControlsPanel.Controls.Add(this.TBTaskType);
            this.TopControlsPanel.Controls.Add(this.label5);
            this.TopControlsPanel.Controls.Add(this.TBSiteType);
            this.TopControlsPanel.Controls.Add(this.TBDeviceType);
            this.TopControlsPanel.Controls.Add(this.DTPickerPurchaseDate);
            this.TopControlsPanel.Controls.Add(this.CBProductDetail);
            this.TopControlsPanel.Controls.Add(this.CBUserDetail);
            this.TopControlsPanel.Controls.Add(this.label9);
            this.TopControlsPanel.Controls.Add(this.rbUseFlagN);
            this.TopControlsPanel.Controls.Add(this.rbUseFlagY);
            this.TopControlsPanel.Controls.Add(this.label4);
            this.TopControlsPanel.Controls.Add(this.rbPurchaseTypeCash);
            this.TopControlsPanel.Controls.Add(this.rbPurchaseTypeCard);
            this.TopControlsPanel.Controls.Add(this.label1);
            this.TopControlsPanel.Controls.Add(this.label11);
            this.TopControlsPanel.Controls.Add(this.label10);
            this.TopControlsPanel.Controls.Add(this.label8);
            this.TopControlsPanel.Controls.Add(this.label2);
            this.TopControlsPanel.Controls.Add(this.tbPurchaseId);
            this.TopControlsPanel.Controls.Add(this.btnDelete);
            this.TopControlsPanel.Controls.Add(this.btnSave);
            this.TopControlsPanel.Controls.Add(this.btnInsert);
            this.TopControlsPanel.Controls.Add(this.label7);
            this.TopControlsPanel.Controls.Add(this.tbUpdateDate);
            this.TopControlsPanel.Controls.Add(this.label6);
            this.TopControlsPanel.Controls.Add(this.tbCreateDate);
            this.TopControlsPanel.Controls.Add(this.label3);
            this.TopControlsPanel.Controls.Add(this.lbProductName);
            this.TopControlsPanel.Controls.Add(this.tbPurchaseAmount);
            this.TopControlsPanel.Controls.Add(this.DGPurchase);
            this.TopControlsPanel.Location = new System.Drawing.Point(17, 10);
            this.TopControlsPanel.Name = "TopControlsPanel";
            this.TopControlsPanel.Size = new System.Drawing.Size(794, 641);
            this.TopControlsPanel.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(247, 444);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(344, 19);
            this.label12.TabIndex = 62;
            this.label12.Text = "예: 순위올리기, 연관검색어, 블로그순위올리기, 검색어자동완성";
            this.label12.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TBTaskType
            // 
            this.TBTaskType.Location = new System.Drawing.Point(125, 442);
            this.TBTaskType.Name = "TBTaskType";
            this.TBTaskType.ReadOnly = true;
            this.TBTaskType.Size = new System.Drawing.Size(119, 21);
            this.TBTaskType.TabIndex = 61;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(28, 442);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 19);
            this.label5.TabIndex = 60;
            this.label5.Text = "작업종류";
            this.label5.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TBSiteType
            // 
            this.TBSiteType.Location = new System.Drawing.Point(124, 414);
            this.TBSiteType.Name = "TBSiteType";
            this.TBSiteType.ReadOnly = true;
            this.TBSiteType.Size = new System.Drawing.Size(86, 21);
            this.TBSiteType.TabIndex = 59;
            // 
            // TBDeviceType
            // 
            this.TBDeviceType.Location = new System.Drawing.Point(124, 386);
            this.TBDeviceType.Name = "TBDeviceType";
            this.TBDeviceType.ReadOnly = true;
            this.TBDeviceType.Size = new System.Drawing.Size(86, 21);
            this.TBDeviceType.TabIndex = 58;
            // 
            // DTPickerPurchaseDate
            // 
            this.DTPickerPurchaseDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTPickerPurchaseDate.Location = new System.Drawing.Point(123, 471);
            this.DTPickerPurchaseDate.Name = "DTPickerPurchaseDate";
            this.DTPickerPurchaseDate.Size = new System.Drawing.Size(103, 21);
            this.DTPickerPurchaseDate.TabIndex = 15;
            // 
            // CBProductDetail
            // 
            this.CBProductDetail.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.CBProductDetail.FormattingEnabled = true;
            this.CBProductDetail.Location = new System.Drawing.Point(123, 361);
            this.CBProductDetail.MaxDropDownItems = 50;
            this.CBProductDetail.Name = "CBProductDetail";
            this.CBProductDetail.Size = new System.Drawing.Size(259, 20);
            this.CBProductDetail.TabIndex = 13;
            this.CBProductDetail.SelectedIndexChanged += new System.EventHandler(this.CBProductDetail_SelectedIndexChanged);
            // 
            // CBUserDetail
            // 
            this.CBUserDetail.FormattingEnabled = true;
            this.CBUserDetail.Location = new System.Drawing.Point(124, 335);
            this.CBUserDetail.Name = "CBUserDetail";
            this.CBUserDetail.Size = new System.Drawing.Size(240, 20);
            this.CBUserDetail.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(27, 558);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 19);
            this.label9.TabIndex = 54;
            this.label9.Text = "사용여부";
            this.label9.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rbUseFlagN
            // 
            this.rbUseFlagN.Id = "4f866122-fd7d-4503-8900-9db1fe138052";
            this.rbUseFlagN.Location = new System.Drawing.Point(193, 554);
            this.rbUseFlagN.Name = "rbUseFlagN";
            this.rbUseFlagN.RadioGroupName = "rgUseType";
            this.rbUseFlagN.Size = new System.Drawing.Size(104, 24);
            this.rbUseFlagN.TabIndex = 33;
            this.rbUseFlagN.Text = "미사용";
            // 
            // rbUseFlagY
            // 
            this.rbUseFlagY.Id = "22d55254-56c4-4891-ad05-a860cd1f6a81";
            this.rbUseFlagY.Location = new System.Drawing.Point(124, 554);
            this.rbUseFlagY.Name = "rbUseFlagY";
            this.rbUseFlagY.RadioGroupName = "rgUseType";
            this.rbUseFlagY.Size = new System.Drawing.Size(104, 24);
            this.rbUseFlagY.TabIndex = 32;
            this.rbUseFlagY.Text = "사용";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(26, 527);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 19);
            this.label4.TabIndex = 51;
            this.label4.Text = "카드/현금이체";
            this.label4.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rbPurchaseTypeCash
            // 
            this.rbPurchaseTypeCash.Id = "a0d408db-7d60-46e9-afa9-3381bb0a2b23";
            this.rbPurchaseTypeCash.Location = new System.Drawing.Point(192, 523);
            this.rbPurchaseTypeCash.Name = "rbPurchaseTypeCash";
            this.rbPurchaseTypeCash.RadioGroupName = "rgPurchaseType";
            this.rbPurchaseTypeCash.Size = new System.Drawing.Size(104, 24);
            this.rbPurchaseTypeCash.TabIndex = 22;
            this.rbPurchaseTypeCash.Text = "현금이체";
            // 
            // rbPurchaseTypeCard
            // 
            this.rbPurchaseTypeCard.Id = "2d6a6e18-c95e-43a2-af4e-30486ff1efb8";
            this.rbPurchaseTypeCard.Location = new System.Drawing.Point(123, 523);
            this.rbPurchaseTypeCard.Name = "rbPurchaseTypeCard";
            this.rbPurchaseTypeCard.RadioGroupName = "rgPurchaseType";
            this.rbPurchaseTypeCard.Size = new System.Drawing.Size(104, 24);
            this.rbPurchaseTypeCard.TabIndex = 21;
            this.rbPurchaseTypeCard.Text = "신용카드";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(26, 471);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 19);
            this.label1.TabIndex = 48;
            this.label1.Text = "구매일";
            this.label1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(28, 386);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(85, 19);
            this.label11.TabIndex = 46;
            this.label11.Text = "모바일/웹";
            this.label11.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(29, 337);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 19);
            this.label10.TabIndex = 43;
            this.label10.Text = "고객정보";
            this.label10.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(29, 364);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 19);
            this.label8.TabIndex = 35;
            this.label8.Text = "상품정보";
            this.label8.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(29, 309);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 19);
            this.label2.TabIndex = 33;
            this.label2.Text = "구매번호";
            this.label2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbPurchaseId
            // 
            this.tbPurchaseId.Location = new System.Drawing.Point(123, 306);
            this.tbPurchaseId.MaxLength = 10;
            this.tbPurchaseId.Name = "tbPurchaseId";
            this.tbPurchaseId.ReadOnly = true;
            this.tbPurchaseId.Size = new System.Drawing.Size(86, 21);
            this.tbPurchaseId.TabIndex = 32;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(696, 605);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 53;
            this.btnDelete.Text = "삭제";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(615, 606);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 52;
            this.btnSave.Text = "저장";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(537, 607);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(75, 23);
            this.btnInsert.TabIndex = 51;
            this.btnInsert.Text = "새로 작성";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(27, 612);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 19);
            this.label7.TabIndex = 26;
            this.label7.Text = "최종수정일";
            this.label7.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbUpdateDate
            // 
            this.tbUpdateDate.Location = new System.Drawing.Point(123, 609);
            this.tbUpdateDate.Name = "tbUpdateDate";
            this.tbUpdateDate.ReadOnly = true;
            this.tbUpdateDate.Size = new System.Drawing.Size(209, 21);
            this.tbUpdateDate.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(26, 586);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 19);
            this.label6.TabIndex = 24;
            this.label6.Text = "생성일";
            this.label6.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbCreateDate
            // 
            this.tbCreateDate.Location = new System.Drawing.Point(123, 583);
            this.tbCreateDate.Name = "tbCreateDate";
            this.tbCreateDate.ReadOnly = true;
            this.tbCreateDate.Size = new System.Drawing.Size(209, 21);
            this.tbCreateDate.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(27, 414);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 19);
            this.label3.TabIndex = 18;
            this.label3.Text = "네이버/다음";
            this.label3.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbProductName
            // 
            this.lbProductName.Location = new System.Drawing.Point(28, 498);
            this.lbProductName.Name = "lbProductName";
            this.lbProductName.Size = new System.Drawing.Size(85, 19);
            this.lbProductName.TabIndex = 13;
            this.lbProductName.Text = "구매금액";
            this.lbProductName.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbPurchaseAmount
            // 
            this.tbPurchaseAmount.Location = new System.Drawing.Point(123, 495);
            this.tbPurchaseAmount.MaxLength = 11;
            this.tbPurchaseAmount.Name = "tbPurchaseAmount";
            this.tbPurchaseAmount.Size = new System.Drawing.Size(159, 21);
            this.tbPurchaseAmount.TabIndex = 16;
            this.tbPurchaseAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbPurchaseAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbMobile_KeyPress);
            // 
            // DGPurchase
            // 
            this.DGPurchase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGPurchase.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPurchaseId,
            this.colUserId,
            this.colProduct,
            this.colDeviceType,
            this.colSiteType,
            this.colTaskType,
            this.colPurchaseDate,
            this.colPurchaseAmount,
            this.colPurchaseType,
            this.colUsedFlag,
            this.colCreateDate,
            this.colUpdateDate});
            this.DGPurchase.Location = new System.Drawing.Point(3, 3);
            this.DGPurchase.MultiSelect = false;
            this.DGPurchase.Name = "DGPurchase";
            this.DGPurchase.ReadOnly = true;
            this.DGPurchase.RowHeadersVisible = false;
            this.DGPurchase.RowTemplate.Height = 23;
            this.DGPurchase.Size = new System.Drawing.Size(788, 287);
            this.DGPurchase.TabIndex = 0;
            this.DGPurchase.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgProduct_CellMouseClick);
            this.DGPurchase.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgProduct_CellClick);
            // 
            // colPurchaseId
            // 
            this.colPurchaseId.DataPropertyName = "purchase_id";
            this.colPurchaseId.HeaderText = "구매번호";
            this.colPurchaseId.Name = "colPurchaseId";
            this.colPurchaseId.ReadOnly = true;
            this.colPurchaseId.Width = 80;
            // 
            // colUserId
            // 
            this.colUserId.DataPropertyName = "user_detail";
            this.colUserId.HeaderText = "고객명";
            this.colUserId.Name = "colUserId";
            this.colUserId.ReadOnly = true;
            // 
            // colProduct
            // 
            this.colProduct.DataPropertyName = "product_detail";
            this.colProduct.HeaderText = "상품정보";
            this.colProduct.Name = "colProduct";
            this.colProduct.ReadOnly = true;
            // 
            // colDeviceType
            // 
            this.colDeviceType.DataPropertyName = "device_type";
            this.colDeviceType.HeaderText = "모바일/웹";
            this.colDeviceType.Name = "colDeviceType";
            this.colDeviceType.ReadOnly = true;
            // 
            // colSiteType
            // 
            this.colSiteType.DataPropertyName = "site_type";
            this.colSiteType.HeaderText = "네이버/다음";
            this.colSiteType.Name = "colSiteType";
            this.colSiteType.ReadOnly = true;
            // 
            // colTaskType
            // 
            this.colTaskType.DataPropertyName = "task_type";
            this.colTaskType.HeaderText = "작업종류";
            this.colTaskType.Name = "colTaskType";
            this.colTaskType.ReadOnly = true;
            // 
            // colPurchaseDate
            // 
            this.colPurchaseDate.DataPropertyName = "purchase_date";
            this.colPurchaseDate.HeaderText = "구매일";
            this.colPurchaseDate.Name = "colPurchaseDate";
            this.colPurchaseDate.ReadOnly = true;
            // 
            // colPurchaseAmount
            // 
            this.colPurchaseAmount.DataPropertyName = "purchase_amount";
            this.colPurchaseAmount.HeaderText = "구매금액";
            this.colPurchaseAmount.Name = "colPurchaseAmount";
            this.colPurchaseAmount.ReadOnly = true;
            // 
            // colPurchaseType
            // 
            this.colPurchaseType.DataPropertyName = "purchase_type";
            this.colPurchaseType.HeaderText = "카드/자동이체";
            this.colPurchaseType.Name = "colPurchaseType";
            this.colPurchaseType.ReadOnly = true;
            // 
            // colUsedFlag
            // 
            this.colUsedFlag.DataPropertyName = "used_flag";
            this.colUsedFlag.HeaderText = "사용여부";
            this.colUsedFlag.Name = "colUsedFlag";
            this.colUsedFlag.ReadOnly = true;
            // 
            // colCreateDate
            // 
            this.colCreateDate.DataPropertyName = "create_date";
            this.colCreateDate.HeaderText = "최초구매일";
            this.colCreateDate.Name = "colCreateDate";
            this.colCreateDate.ReadOnly = true;
            // 
            // colUpdateDate
            // 
            this.colUpdateDate.DataPropertyName = "update_date";
            this.colUpdateDate.HeaderText = "최종변경일";
            this.colUpdateDate.Name = "colUpdateDate";
            this.colUpdateDate.ReadOnly = true;
            // 
            // PurchasePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CalendarPageControls);
            this.Name = "PurchasePage";
            this.Size = new System.Drawing.Size(828, 680);
            this.CalendarPageControls.ResumeLayout(false);
            this.TopControlsPanel.ResumeLayout(false);
            this.TopControlsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGPurchase)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ContextMenuExtenderProvider contextMenuExtenderProvider1;
        private Panel CalendarPageControls;
		private Panel TopControlsPanel;
        private System.Windows.Forms.DataGridView DGPurchase;
        private Label label3;
        private Label lbProductName;
        private System.Windows.Forms.TextBox tbPurchaseAmount;
        private Label label7;
        private System.Windows.Forms.TextBox tbUpdateDate;
        private Label label6;
        private System.Windows.Forms.TextBox tbCreateDate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnInsert;
        private Label label8;
        private Label label2;
        private System.Windows.Forms.TextBox tbPurchaseId;
        private Label label1;
        private Label label11;
        private Label label10;
        private Label label9;
        private RadioButton rbUseFlagN;
        private RadioButton rbUseFlagY;
        private Label label4;
        private RadioButton rbPurchaseTypeCash;
        private RadioButton rbPurchaseTypeCard;
        private System.Windows.Forms.ComboBox CBProductDetail;
        private System.Windows.Forms.ComboBox CBUserDetail;
        private System.Windows.Forms.DateTimePicker DTPickerPurchaseDate;
        private Label label12;
        private System.Windows.Forms.TextBox TBTaskType;
        private Label label5;
        private System.Windows.Forms.TextBox TBSiteType;
        private System.Windows.Forms.TextBox TBDeviceType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPurchaseId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeviceType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSiteType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTaskType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPurchaseDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPurchaseAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPurchaseType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsedFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUpdateDate;
    }
}

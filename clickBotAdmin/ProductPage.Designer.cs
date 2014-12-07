namespace Elegant.Ui.Samples.ControlsSample
{
    partial class ProductPage
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
            this.CalendarHitTestContextMenu = new Elegant.Ui.ContextMenu(this.components);
            this.HitTestInfoButton = new Elegant.Ui.Button();
            this.contextMenuExtenderProvider1 = new Elegant.Ui.ContextMenuExtenderProvider(this.components);
            this.CalendarPageControls = new Elegant.Ui.Panel();
            this.TopControlsPanel = new Elegant.Ui.Panel();
            this.CBTaskType = new System.Windows.Forms.ComboBox();
            this.label2 = new Elegant.Ui.Label();
            this.label1 = new Elegant.Ui.Label();
            this.tbProductName = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.label7 = new Elegant.Ui.Label();
            this.tbUpdateDate = new System.Windows.Forms.TextBox();
            this.label6 = new Elegant.Ui.Label();
            this.tbCreateDate = new System.Windows.Forms.TextBox();
            this.label5 = new Elegant.Ui.Label();
            this.rbSiteTypeDaum = new Elegant.Ui.RadioButton();
            this.rbSiteTypeNaver = new Elegant.Ui.RadioButton();
            this.label4 = new Elegant.Ui.Label();
            this.label3 = new Elegant.Ui.Label();
            this.rbDeviceTypeWeb = new Elegant.Ui.RadioButton();
            this.rbDeviceTypeMobile = new Elegant.Ui.RadioButton();
            this.lbPrice = new Elegant.Ui.Label();
            this.tbPrice = new System.Windows.Forms.TextBox();
            this.lbProductName = new Elegant.Ui.Label();
            this.tbProductId = new System.Windows.Forms.TextBox();
            this.dgProduct = new System.Windows.Forms.DataGridView();
            this.colProductId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeviceType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSiteType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUpdateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.CalendarHitTestContextMenu)).BeginInit();
            this.CalendarPageControls.SuspendLayout();
            this.TopControlsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // CalendarHitTestContextMenu
            // 
            this.CalendarHitTestContextMenu.Items.AddRange(new System.Windows.Forms.Control[] {
            this.HitTestInfoButton});
            this.CalendarHitTestContextMenu.KeepPopupsWithOffsetPlacementWithinPlacementArea = false;
            this.CalendarHitTestContextMenu.PlacementMode = Elegant.Ui.PopupPlacementMode.Bottom;
            this.CalendarHitTestContextMenu.PlacementOffset = new System.Drawing.Size(25, 65);
            this.CalendarHitTestContextMenu.Size = new System.Drawing.Size(100, 100);
            // 
            // HitTestInfoButton
            // 
            this.HitTestInfoButton.Id = "ec277ed3-e9c2-45ad-be6d-cd78e24f746e";
            this.HitTestInfoButton.Location = new System.Drawing.Point(2, 2);
            this.HitTestInfoButton.Name = "HitTestInfoButton";
            this.HitTestInfoButton.Size = new System.Drawing.Size(138, 23);
            this.HitTestInfoButton.TabIndex = 3;
            this.HitTestInfoButton.Text = "button1";
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
            this.TopControlsPanel.Controls.Add(this.CBTaskType);
            this.TopControlsPanel.Controls.Add(this.label2);
            this.TopControlsPanel.Controls.Add(this.label1);
            this.TopControlsPanel.Controls.Add(this.tbProductName);
            this.TopControlsPanel.Controls.Add(this.btnDelete);
            this.TopControlsPanel.Controls.Add(this.btnSave);
            this.TopControlsPanel.Controls.Add(this.btnInsert);
            this.TopControlsPanel.Controls.Add(this.label7);
            this.TopControlsPanel.Controls.Add(this.tbUpdateDate);
            this.TopControlsPanel.Controls.Add(this.label6);
            this.TopControlsPanel.Controls.Add(this.tbCreateDate);
            this.TopControlsPanel.Controls.Add(this.label5);
            this.TopControlsPanel.Controls.Add(this.rbSiteTypeDaum);
            this.TopControlsPanel.Controls.Add(this.rbSiteTypeNaver);
            this.TopControlsPanel.Controls.Add(this.label4);
            this.TopControlsPanel.Controls.Add(this.label3);
            this.TopControlsPanel.Controls.Add(this.rbDeviceTypeWeb);
            this.TopControlsPanel.Controls.Add(this.rbDeviceTypeMobile);
            this.TopControlsPanel.Controls.Add(this.lbPrice);
            this.TopControlsPanel.Controls.Add(this.tbPrice);
            this.TopControlsPanel.Controls.Add(this.lbProductName);
            this.TopControlsPanel.Controls.Add(this.tbProductId);
            this.TopControlsPanel.Controls.Add(this.dgProduct);
            this.TopControlsPanel.Location = new System.Drawing.Point(17, 10);
            this.TopControlsPanel.Name = "TopControlsPanel";
            this.TopControlsPanel.Size = new System.Drawing.Size(794, 645);
            this.TopControlsPanel.TabIndex = 1;
            // 
            // CBTaskType
            // 
            this.CBTaskType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.CBTaskType.FormattingEnabled = true;
            this.CBTaskType.Location = new System.Drawing.Point(121, 551);
            this.CBTaskType.MaxDropDownItems = 50;
            this.CBTaskType.Name = "CBTaskType";
            this.CBTaskType.Size = new System.Drawing.Size(116, 20);
            this.CBTaskType.TabIndex = 41;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(28, 551);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 19);
            this.label2.TabIndex = 60;
            this.label2.Text = "작업종류";
            this.label2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(27, 432);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 19);
            this.label1.TabIndex = 31;
            this.label1.Text = "상품코드";
            this.label1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbProductName
            // 
            this.tbProductName.Location = new System.Drawing.Point(121, 456);
            this.tbProductName.MaxLength = 200;
            this.tbProductName.Name = "tbProductName";
            this.tbProductName.Size = new System.Drawing.Size(344, 21);
            this.tbProductName.TabIndex = 12;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(691, 595);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 53;
            this.btnDelete.Text = "삭제";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(610, 596);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 52;
            this.btnSave.Text = "저장";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(532, 597);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(75, 23);
            this.btnInsert.TabIndex = 51;
            this.btnInsert.Text = "새로 작성";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(26, 607);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 19);
            this.label7.TabIndex = 26;
            this.label7.Text = "최종수정일";
            this.label7.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbUpdateDate
            // 
            this.tbUpdateDate.Location = new System.Drawing.Point(122, 604);
            this.tbUpdateDate.Name = "tbUpdateDate";
            this.tbUpdateDate.ReadOnly = true;
            this.tbUpdateDate.Size = new System.Drawing.Size(209, 21);
            this.tbUpdateDate.TabIndex = 43;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(25, 581);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 19);
            this.label6.TabIndex = 24;
            this.label6.Text = "생성일";
            this.label6.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbCreateDate
            // 
            this.tbCreateDate.Location = new System.Drawing.Point(121, 578);
            this.tbCreateDate.Name = "tbCreateDate";
            this.tbCreateDate.ReadOnly = true;
            this.tbCreateDate.Size = new System.Drawing.Size(209, 21);
            this.tbCreateDate.TabIndex = 42;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(26, 529);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 19);
            this.label5.TabIndex = 22;
            this.label5.Text = "네이버/다음";
            this.label5.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rbSiteTypeDaum
            // 
            this.rbSiteTypeDaum.Id = "046534b4-5bc9-49e2-b722-16ec70f2e6f9";
            this.rbSiteTypeDaum.Location = new System.Drawing.Point(192, 525);
            this.rbSiteTypeDaum.Name = "rbSiteTypeDaum";
            this.rbSiteTypeDaum.RadioGroupName = "rgSiteType";
            this.rbSiteTypeDaum.Size = new System.Drawing.Size(104, 24);
            this.rbSiteTypeDaum.TabIndex = 32;
            this.rbSiteTypeDaum.Text = "다음";
            // 
            // rbSiteTypeNaver
            // 
            this.rbSiteTypeNaver.Id = "49a0afeb-751e-43da-b493-664e12875dd2";
            this.rbSiteTypeNaver.Location = new System.Drawing.Point(123, 525);
            this.rbSiteTypeNaver.Name = "rbSiteTypeNaver";
            this.rbSiteTypeNaver.RadioGroupName = "rgSiteType";
            this.rbSiteTypeNaver.Size = new System.Drawing.Size(104, 24);
            this.rbSiteTypeNaver.TabIndex = 31;
            this.rbSiteTypeNaver.Text = "네이버";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(210, 483);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 19);
            this.label4.TabIndex = 19;
            this.label4.Text = "원";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(26, 505);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 19);
            this.label3.TabIndex = 18;
            this.label3.Text = "모바일/웹";
            this.label3.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rbDeviceTypeWeb
            // 
            this.rbDeviceTypeWeb.Id = "de5a94b8-76e0-4eab-9689-25fcad250057";
            this.rbDeviceTypeWeb.Location = new System.Drawing.Point(123, 501);
            this.rbDeviceTypeWeb.Name = "rbDeviceTypeWeb";
            this.rbDeviceTypeWeb.RadioGroupName = "rgDeviceType";
            this.rbDeviceTypeWeb.Size = new System.Drawing.Size(51, 24);
            this.rbDeviceTypeWeb.TabIndex = 21;
            this.rbDeviceTypeWeb.Text = "웹";
            // 
            // rbDeviceTypeMobile
            // 
            this.rbDeviceTypeMobile.Id = "001999a7-6ac1-478c-bd0e-14651715ff46";
            this.rbDeviceTypeMobile.Location = new System.Drawing.Point(192, 501);
            this.rbDeviceTypeMobile.Name = "rbDeviceTypeMobile";
            this.rbDeviceTypeMobile.RadioGroupName = "rgDeviceType";
            this.rbDeviceTypeMobile.Size = new System.Drawing.Size(104, 24);
            this.rbDeviceTypeMobile.TabIndex = 22;
            this.rbDeviceTypeMobile.Text = "모바일";
            // 
            // lbPrice
            // 
            this.lbPrice.Location = new System.Drawing.Point(27, 483);
            this.lbPrice.Name = "lbPrice";
            this.lbPrice.Size = new System.Drawing.Size(85, 19);
            this.lbPrice.TabIndex = 15;
            this.lbPrice.Text = "가격";
            this.lbPrice.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbPrice
            // 
            this.tbPrice.Location = new System.Drawing.Point(121, 480);
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.Size = new System.Drawing.Size(86, 21);
            this.tbPrice.TabIndex = 14;
            this.tbPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPrice_KeyPress);
            // 
            // lbProductName
            // 
            this.lbProductName.Location = new System.Drawing.Point(27, 459);
            this.lbProductName.Name = "lbProductName";
            this.lbProductName.Size = new System.Drawing.Size(85, 19);
            this.lbProductName.TabIndex = 13;
            this.lbProductName.Text = "상품명";
            this.lbProductName.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbProductId
            // 
            this.tbProductId.Location = new System.Drawing.Point(121, 429);
            this.tbProductId.MaxLength = 8;
            this.tbProductId.Name = "tbProductId";
            this.tbProductId.Size = new System.Drawing.Size(86, 21);
            this.tbProductId.TabIndex = 11;
            // 
            // dgProduct
            // 
            this.dgProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProduct.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProductId,
            this.colProductName,
            this.colPrice,
            this.colDeviceType,
            this.colSiteType,
            this.colCreateDate,
            this.colUpdateDate});
            this.dgProduct.Location = new System.Drawing.Point(3, 3);
            this.dgProduct.MultiSelect = false;
            this.dgProduct.Name = "dgProduct";
            this.dgProduct.ReadOnly = true;
            this.dgProduct.RowHeadersVisible = false;
            this.dgProduct.RowTemplate.Height = 23;
            this.dgProduct.Size = new System.Drawing.Size(788, 405);
            this.dgProduct.TabIndex = 0;
            this.dgProduct.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgProduct_CellMouseClick);
            this.dgProduct.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgProduct_CellClick);
            this.dgProduct.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgProduct_CellContentClick);
            // 
            // colProductId
            // 
            this.colProductId.DataPropertyName = "product_id";
            this.colProductId.HeaderText = "상품코드";
            this.colProductId.Name = "colProductId";
            this.colProductId.ReadOnly = true;
            this.colProductId.Width = 80;
            // 
            // colProductName
            // 
            this.colProductName.DataPropertyName = "product_name";
            this.colProductName.FillWeight = 200F;
            this.colProductName.HeaderText = "상품";
            this.colProductName.Name = "colProductName";
            this.colProductName.ReadOnly = true;
            this.colProductName.Width = 200;
            // 
            // colPrice
            // 
            this.colPrice.DataPropertyName = "price";
            this.colPrice.FillWeight = 60F;
            this.colPrice.HeaderText = "가격";
            this.colPrice.Name = "colPrice";
            this.colPrice.ReadOnly = true;
            this.colPrice.Width = 60;
            // 
            // colDeviceType
            // 
            this.colDeviceType.DataPropertyName = "device_type";
            this.colDeviceType.HeaderText = "웹/모바일";
            this.colDeviceType.Name = "colDeviceType";
            this.colDeviceType.ReadOnly = true;
            this.colDeviceType.Width = 90;
            // 
            // colSiteType
            // 
            this.colSiteType.DataPropertyName = "site_type";
            this.colSiteType.HeaderText = "네이버/다음";
            this.colSiteType.Name = "colSiteType";
            this.colSiteType.ReadOnly = true;
            // 
            // colCreateDate
            // 
            this.colCreateDate.DataPropertyName = "create_date";
            this.colCreateDate.HeaderText = "생성일";
            this.colCreateDate.Name = "colCreateDate";
            this.colCreateDate.ReadOnly = true;
            this.colCreateDate.Width = 90;
            // 
            // colUpdateDate
            // 
            this.colUpdateDate.DataPropertyName = "update_date";
            this.colUpdateDate.HeaderText = "최종수정일";
            this.colUpdateDate.Name = "colUpdateDate";
            this.colUpdateDate.ReadOnly = true;
            this.colUpdateDate.Width = 90;
            // 
            // ProductPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CalendarPageControls);
            this.Name = "ProductPage";
            this.Size = new System.Drawing.Size(828, 680);
            ((System.ComponentModel.ISupportInitialize)(this.CalendarHitTestContextMenu)).EndInit();
            this.CalendarPageControls.ResumeLayout(false);
            this.TopControlsPanel.ResumeLayout(false);
            this.TopControlsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgProduct)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ContextMenu CalendarHitTestContextMenu;
        private ContextMenuExtenderProvider contextMenuExtenderProvider1;
        private Button HitTestInfoButton;
        private Panel CalendarPageControls;
		private Panel TopControlsPanel;
        private System.Windows.Forms.DataGridView dgProduct;
        private Label label3;
        private RadioButton rbDeviceTypeMobile;
        private RadioButton rbDeviceTypeWeb;
        private Label lbPrice;
        private System.Windows.Forms.TextBox tbPrice;
        private Label lbProductName;
        private System.Windows.Forms.TextBox tbProductName;
        private Label label4;
        private Label label7;
        private System.Windows.Forms.TextBox tbUpdateDate;
        private Label label6;
        private System.Windows.Forms.TextBox tbCreateDate;
        private Label label5;
        private RadioButton rbSiteTypeDaum;
        private RadioButton rbSiteTypeNaver;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnInsert;
        private Label label1;
        private System.Windows.Forms.TextBox tbProductId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeviceType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSiteType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUpdateDate;
        private System.Windows.Forms.ComboBox CBTaskType;
        private Label label2;
    }
}

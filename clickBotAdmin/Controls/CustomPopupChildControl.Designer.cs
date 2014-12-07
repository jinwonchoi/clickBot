namespace Elegant.Ui.Samples.ControlsSample
{
    partial class CustomPopupChildControl
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
			this.ControlsPanel = new Elegant.Ui.Panel();
			this.panel2 = new Elegant.Ui.Panel();
			this.CustomPopupTextBox = new Elegant.Ui.TextBox();
			this.CustomPopupDropDown = new Elegant.Ui.DropDown();
			this.popupMenu1 = new Elegant.Ui.PopupMenu();
			this.Item1Button = new Elegant.Ui.Button();
			this.Item2Button = new Elegant.Ui.Button();
			this.Item3Button = new Elegant.Ui.Button();
			this.Item4Button = new Elegant.Ui.Button();
			this.separator1 = new Elegant.Ui.Separator();
			this.ToggleItemToggleButton = new Elegant.Ui.ToggleButton();
			this.panel1 = new Elegant.Ui.Panel();
			this.CustomPopupLabel = new Elegant.Ui.Label();
			this.CustomPopupCalendar = new Elegant.Ui.Calendar();
			this.ControlsPanel.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.CustomPopupCalendar)).BeginInit();
			this.SuspendLayout();
			// 
			// ControlsPanel
			// 
			this.ControlsPanel.Controls.Add(this.panel2);
			this.ControlsPanel.Controls.Add(this.panel1);
			this.ControlsPanel.Controls.Add(this.CustomPopupCalendar);
			this.ControlsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ControlsPanel.Id = "b45853fe-2554-48a4-9ae9-bf2e9f57419c";
			this.ControlsPanel.Location = new System.Drawing.Point(0, 0);
			this.ControlsPanel.Name = "ControlsPanel";
			this.ControlsPanel.Padding = new System.Windows.Forms.Padding(1);
			this.ControlsPanel.Size = new System.Drawing.Size(275, 267);
			this.ControlsPanel.TabIndex = 0;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.CustomPopupTextBox);
			this.panel2.Controls.Add(this.CustomPopupDropDown);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Id = "edb45ce8-8848-47c0-87b2-2914923643d5";
			this.panel2.Location = new System.Drawing.Point(1, 233);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(273, 33);
			this.panel2.TabIndex = 6;
			this.panel2.Text = "panel2";
			// 
			// CustomPopupTextBox
			// 
			this.CustomPopupTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.CustomPopupTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.CustomPopupTextBox.Id = "6bea4501-3a8b-476d-8824-1a93f630f814";
			this.CustomPopupTextBox.LabelText = "";
			this.CustomPopupTextBox.Location = new System.Drawing.Point(34, 4);
			this.CustomPopupTextBox.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
			this.CustomPopupTextBox.Name = "CustomPopupTextBox";
			this.CustomPopupTextBox.Size = new System.Drawing.Size(111, 21);
			this.CustomPopupTextBox.TabIndex = 0;
			this.CustomPopupTextBox.Text = "Some Text";
			this.CustomPopupTextBox.TextEditorWidth = 105;
			// 
			// CustomPopupDropDown
			// 
			this.CustomPopupDropDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.CustomPopupDropDown.Id = "4e3b10aa-92e9-4e01-a85e-784838068501";
			this.CustomPopupDropDown.Location = new System.Drawing.Point(156, 3);
			this.CustomPopupDropDown.Name = "CustomPopupDropDown";
			this.CustomPopupDropDown.Popup = this.popupMenu1;
			this.CustomPopupDropDown.Size = new System.Drawing.Size(75, 23);
			this.CustomPopupDropDown.TabIndex = 2;
			this.CustomPopupDropDown.Text = "Drop-Down";
			// 
			// popupMenu1
			// 
			this.popupMenu1.Items.AddRange(new System.Windows.Forms.Control[] {
            this.Item1Button,
            this.Item2Button,
            this.Item3Button,
            this.Item4Button,
            this.separator1,
            this.ToggleItemToggleButton});
			this.popupMenu1.PlacementMode = Elegant.Ui.PopupPlacementMode.Bottom;
			this.popupMenu1.Size = new System.Drawing.Size(100, 100);
			// 
			// Item1Button
			// 
			this.Item1Button.Id = "eb749a5e-4c5e-47dc-99cb-5d629cd73e5f";
			this.Item1Button.Location = new System.Drawing.Point(2, 2);
			this.Item1Button.Name = "Item1Button";
			this.Item1Button.Size = new System.Drawing.Size(138, 23);
			this.Item1Button.TabIndex = 3;
			this.Item1Button.Text = "Item 1";
			// 
			// Item2Button
			// 
			this.Item2Button.Id = "63d56510-eeff-4579-b4b4-6d36fdd9dc6f";
			this.Item2Button.Location = new System.Drawing.Point(2, 25);
			this.Item2Button.Name = "Item2Button";
			this.Item2Button.Size = new System.Drawing.Size(138, 23);
			this.Item2Button.TabIndex = 4;
			this.Item2Button.Text = "Item 2";
			// 
			// Item3Button
			// 
			this.Item3Button.Id = "c2f96332-5fa7-4952-852a-10363c63f9be";
			this.Item3Button.Location = new System.Drawing.Point(2, 48);
			this.Item3Button.Name = "Item3Button";
			this.Item3Button.Size = new System.Drawing.Size(138, 23);
			this.Item3Button.TabIndex = 5;
			this.Item3Button.Text = "Item 3";
			// 
			// Item4Button
			// 
			this.Item4Button.Id = "286b2d91-8549-4ae9-8e99-2d817d0c1fde";
			this.Item4Button.Location = new System.Drawing.Point(2, 71);
			this.Item4Button.Name = "Item4Button";
			this.Item4Button.Size = new System.Drawing.Size(138, 23);
			this.Item4Button.TabIndex = 6;
			this.Item4Button.Text = "Item 4";
			// 
			// separator1
			// 
			this.separator1.Id = "07d2f3ab-669d-40cf-ab2d-d59363f182a9";
			this.separator1.Location = new System.Drawing.Point(2, 94);
			this.separator1.Name = "separator1";
			this.separator1.Orientation = Elegant.Ui.SeparatorOrientation.Horizontal;
			this.separator1.Size = new System.Drawing.Size(138, 5);
			this.separator1.TabIndex = 7;
			this.separator1.Text = "separator1";
			// 
			// ToggleItemToggleButton
			// 
			this.ToggleItemToggleButton.Id = "e4c2bdea-41c3-48df-846e-0f0809be78c1";
			this.ToggleItemToggleButton.Location = new System.Drawing.Point(2, 99);
			this.ToggleItemToggleButton.Name = "ToggleItemToggleButton";
			this.ToggleItemToggleButton.Pressed = true;
			this.ToggleItemToggleButton.Size = new System.Drawing.Size(138, 23);
			this.ToggleItemToggleButton.TabIndex = 8;
			this.ToggleItemToggleButton.Text = "Toggle Item";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.CustomPopupLabel);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Id = "f6aff34f-a5f2-44f6-9072-6828ef701a22";
			this.panel1.Location = new System.Drawing.Point(1, 1);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(273, 29);
			this.panel1.TabIndex = 5;
			this.panel1.Text = "panel1";
			// 
			// CustomPopupLabel
			// 
			this.CustomPopupLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.CustomPopupLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.CustomPopupLabel.Id = "69afe596-d134-4ed1-8396-bbf67d1f6f7f";
			this.CustomPopupLabel.Location = new System.Drawing.Point(0, 0);
			this.CustomPopupLabel.Name = "CustomPopupLabel";
			this.CustomPopupLabel.Size = new System.Drawing.Size(273, 29);
			this.CustomPopupLabel.TabIndex = 4;
			this.CustomPopupLabel.Text = "This is a custom popup";
			this.CustomPopupLabel.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// CustomPopupCalendar
			// 
			this.CustomPopupCalendar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)));
			this.CustomPopupCalendar.FirstVisibleMonth = new System.DateTime(2008, 1, 22, 12, 2, 30, 837);
			this.CustomPopupCalendar.Id = "69845877-b59e-40d3-a3fd-0c57d4392bf5";
			this.CustomPopupCalendar.Location = new System.Drawing.Point(59, 53);
			this.CustomPopupCalendar.Name = "CustomPopupCalendar";
			this.CustomPopupCalendar.SelectedDate = null;
			this.CustomPopupCalendar.Size = new System.Drawing.Size(151, 153);
			this.CustomPopupCalendar.TabIndex = 3;
			this.CustomPopupCalendar.Text = "CustomPopupCalendar";
			// 
			// CustomPopupChildControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.ControlsPanel);
			this.Name = "CustomPopupChildControl";
			this.Size = new System.Drawing.Size(275, 267);
			this.ControlsPanel.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.CustomPopupCalendar)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private Panel ControlsPanel;
        private DropDown CustomPopupDropDown;
        private TextBox CustomPopupTextBox;
        private Calendar CustomPopupCalendar;
        private Label CustomPopupLabel;
        private PopupMenu popupMenu1;
        private Button Item1Button;
        private Button Item2Button;
        private Button Item3Button;
        private Button Item4Button;
        private Separator separator1;
        private ToggleButton ToggleItemToggleButton;
		private Panel panel1;
		private Panel panel2;
    }
}

namespace CustomAction
{
    partial class FrmStatus
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmStatus));
            this.GrpBoxIntro = new System.Windows.Forms.GroupBox();
            this.RichTextBoxStatusMsg = new System.Windows.Forms.RichTextBox();
            this.LabelMsg = new System.Windows.Forms.Label();
            this.ButtonNext = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.GrpBoxIntro.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrpBoxIntro
            // 
            this.GrpBoxIntro.Controls.Add(this.RichTextBoxStatusMsg);
            this.GrpBoxIntro.Controls.Add(this.LabelMsg);
            this.GrpBoxIntro.Location = new System.Drawing.Point(32, 23);
            this.GrpBoxIntro.Name = "GrpBoxIntro";
            this.GrpBoxIntro.Size = new System.Drawing.Size(540, 336);
            this.GrpBoxIntro.TabIndex = 12;
            this.GrpBoxIntro.TabStop = false;
            // 
            // RichTextBoxStatusMsg
            // 
            this.RichTextBoxStatusMsg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RichTextBoxStatusMsg.Location = new System.Drawing.Point(24, 75);
            this.RichTextBoxStatusMsg.Name = "RichTextBoxStatusMsg";
            this.RichTextBoxStatusMsg.ReadOnly = true;
            this.RichTextBoxStatusMsg.Size = new System.Drawing.Size(493, 240);
            this.RichTextBoxStatusMsg.TabIndex = 1;
            this.RichTextBoxStatusMsg.Text = "";
            // 
            // LabelMsg
            // 
            this.LabelMsg.AutoSize = true;
            this.LabelMsg.Location = new System.Drawing.Point(27, 30);
            this.LabelMsg.Name = "LabelMsg";
            this.LabelMsg.Size = new System.Drawing.Size(181, 24);
            this.LabelMsg.TabIndex = 0;
            this.LabelMsg.Text = "WeDo Server설치가 진행됩니다.\r\n\r\n";
            // 
            // ButtonNext
            // 
            this.ButtonNext.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ButtonNext.Location = new System.Drawing.Point(393, 374);
            this.ButtonNext.Name = "ButtonNext";
            this.ButtonNext.Size = new System.Drawing.Size(87, 23);
            this.ButtonNext.TabIndex = 16;
            this.ButtonNext.Text = "다음 >";
            this.ButtonNext.UseVisualStyleBackColor = true;
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonCancel.Location = new System.Drawing.Point(485, 374);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(87, 23);
            this.ButtonCancel.TabIndex = 15;
            this.ButtonCancel.Text = "취소";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            // 
            // FrmStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 422);
            this.Controls.Add(this.ButtonNext);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.GrpBoxIntro);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmStatus";
            this.Text = "FrmStatus";
            this.Shown += new System.EventHandler(this.FrmStatus_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmStatus_FormClosing);
            this.GrpBoxIntro.ResumeLayout(false);
            this.GrpBoxIntro.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpBoxIntro;
        private System.Windows.Forms.RichTextBox RichTextBoxStatusMsg;
        private System.Windows.Forms.Label LabelMsg;
        private System.Windows.Forms.Button ButtonNext;
        private System.Windows.Forms.Button ButtonCancel;
    }
}
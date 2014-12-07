namespace CustomAction
{
    partial class FrmError
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmError));
            this.GrpBoxIntro = new System.Windows.Forms.GroupBox();
            this.RichTextBoxErrMsg = new System.Windows.Forms.RichTextBox();
            this.LabelMsg = new System.Windows.Forms.Label();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.GrpBoxIntro.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrpBoxIntro
            // 
            this.GrpBoxIntro.Controls.Add(this.RichTextBoxErrMsg);
            this.GrpBoxIntro.Controls.Add(this.LabelMsg);
            this.GrpBoxIntro.Location = new System.Drawing.Point(32, 23);
            this.GrpBoxIntro.Name = "GrpBoxIntro";
            this.GrpBoxIntro.Size = new System.Drawing.Size(540, 336);
            this.GrpBoxIntro.TabIndex = 11;
            this.GrpBoxIntro.TabStop = false;
            // 
            // RichTextBoxErrMsg
            // 
            this.RichTextBoxErrMsg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RichTextBoxErrMsg.Location = new System.Drawing.Point(24, 75);
            this.RichTextBoxErrMsg.Name = "RichTextBoxErrMsg";
            this.RichTextBoxErrMsg.ReadOnly = true;
            this.RichTextBoxErrMsg.Size = new System.Drawing.Size(493, 240);
            this.RichTextBoxErrMsg.TabIndex = 1;
            this.RichTextBoxErrMsg.Text = "";
            // 
            // LabelMsg
            // 
            this.LabelMsg.AutoSize = true;
            this.LabelMsg.Location = new System.Drawing.Point(27, 30);
            this.LabelMsg.Name = "LabelMsg";
            this.LabelMsg.Size = new System.Drawing.Size(337, 36);
            this.LabelMsg.TabIndex = 0;
            this.LabelMsg.Text = "WeDo Server설치중 오류가 발생하여 설치가 취소되었습니다.\r\n\r\n[오류내역]";
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonCancel.Location = new System.Drawing.Point(485, 376);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(87, 23);
            this.ButtonCancel.TabIndex = 12;
            this.ButtonCancel.Text = "설치취소";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            // 
            // FrmError
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 422);
            this.Controls.Add(this.GrpBoxIntro);
            this.Controls.Add(this.ButtonCancel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmError";
            this.ShowInTaskbar = false;
            this.Text = "FrmError";
            this.GrpBoxIntro.ResumeLayout(false);
            this.GrpBoxIntro.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpBoxIntro;
        private System.Windows.Forms.RichTextBox RichTextBoxErrMsg;
        private System.Windows.Forms.Label LabelMsg;
        private System.Windows.Forms.Button ButtonCancel;
    }
}
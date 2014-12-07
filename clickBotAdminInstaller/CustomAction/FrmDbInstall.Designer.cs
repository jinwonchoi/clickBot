namespace CustomAction
{
    partial class FrmDbInstall
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDbInstall));
            this.ButtonNext = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.GrpBoxIntro = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LabelDbDir = new System.Windows.Forms.Label();
            this.LabelMsg = new System.Windows.Forms.Label();
            this.CkBoxNeedDbDelete = new System.Windows.Forms.CheckBox();
            this.GrpBoxIntro.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonNext
            // 
            this.ButtonNext.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ButtonNext.Location = new System.Drawing.Point(394, 207);
            this.ButtonNext.Name = "ButtonNext";
            this.ButtonNext.Size = new System.Drawing.Size(87, 23);
            this.ButtonNext.TabIndex = 11;
            this.ButtonNext.Text = "다음 >";
            this.ButtonNext.UseVisualStyleBackColor = true;
            this.ButtonNext.Click += new System.EventHandler(this.ButtonNext_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonCancel.Location = new System.Drawing.Point(486, 207);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(87, 23);
            this.ButtonCancel.TabIndex = 10;
            this.ButtonCancel.Text = "취소";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            // 
            // GrpBoxIntro
            // 
            this.GrpBoxIntro.Controls.Add(this.panel1);
            this.GrpBoxIntro.Location = new System.Drawing.Point(33, 28);
            this.GrpBoxIntro.Name = "GrpBoxIntro";
            this.GrpBoxIntro.Size = new System.Drawing.Size(540, 173);
            this.GrpBoxIntro.TabIndex = 13;
            this.GrpBoxIntro.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.LabelDbDir);
            this.panel1.Controls.Add(this.LabelMsg);
            this.panel1.Controls.Add(this.CkBoxNeedDbDelete);
            this.panel1.Location = new System.Drawing.Point(31, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(470, 129);
            this.panel1.TabIndex = 7;
            // 
            // LabelDbDir
            // 
            this.LabelDbDir.AutoSize = true;
            this.LabelDbDir.Location = new System.Drawing.Point(9, 105);
            this.LabelDbDir.Name = "LabelDbDir";
            this.LabelDbDir.Size = new System.Drawing.Size(89, 12);
            this.LabelDbDir.TabIndex = 2;
            this.LabelDbDir.Text = "설치된 DB경로:";
            // 
            // LabelMsg
            // 
            this.LabelMsg.AutoSize = true;
            this.LabelMsg.Location = new System.Drawing.Point(3, 10);
            this.LabelMsg.Name = "LabelMsg";
            this.LabelMsg.Size = new System.Drawing.Size(310, 60);
            this.LabelMsg.TabIndex = 0;
            this.LabelMsg.Text = "이전에 설치된 DB에 데이터가 존재합니다. \r\n기존데이터를 삭제하시겠습니까? \r\n\r\n(데이터삭제를 선택하시면 기존 데이터는 별도백업되며, \r\n필요" +
                "시 복구가능합니다.)\r\n";
            // 
            // CkBoxNeedDbDelete
            // 
            this.CkBoxNeedDbDelete.AutoSize = true;
            this.CkBoxNeedDbDelete.Location = new System.Drawing.Point(11, 86);
            this.CkBoxNeedDbDelete.Name = "CkBoxNeedDbDelete";
            this.CkBoxNeedDbDelete.Size = new System.Drawing.Size(116, 16);
            this.CkBoxNeedDbDelete.TabIndex = 1;
            this.CkBoxNeedDbDelete.Text = "기존 데이터 삭제";
            this.CkBoxNeedDbDelete.UseVisualStyleBackColor = true;
            // 
            // FrmDbInstall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 245);
            this.Controls.Add(this.GrpBoxIntro);
            this.Controls.Add(this.ButtonNext);
            this.Controls.Add(this.ButtonCancel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmDbInstall";
            this.Text = "clickBot Admin프로그램 설치 - DB 설치";
            this.Shown += new System.EventHandler(this.FrmDbInstall_Shown);
            this.GrpBoxIntro.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ButtonNext;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.GroupBox GrpBoxIntro;
        private System.Windows.Forms.CheckBox CkBoxNeedDbDelete;
        private System.Windows.Forms.Label LabelMsg;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LabelDbDir;
    }
}
namespace CustomAction
{
    partial class FrmWinpcapInstall
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWinpcapInstall));
            this.GrpBoxIntro = new System.Windows.Forms.GroupBox();
            this.CkBoxInstallWinpcap = new System.Windows.Forms.CheckBox();
            this.LabelMsg = new System.Windows.Forms.Label();
            this.ButtonNext = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.GrpBoxIntro.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrpBoxIntro
            // 
            this.GrpBoxIntro.Controls.Add(this.CkBoxInstallWinpcap);
            this.GrpBoxIntro.Controls.Add(this.LabelMsg);
            this.GrpBoxIntro.Location = new System.Drawing.Point(33, 28);
            this.GrpBoxIntro.Name = "GrpBoxIntro";
            this.GrpBoxIntro.Size = new System.Drawing.Size(540, 336);
            this.GrpBoxIntro.TabIndex = 0;
            this.GrpBoxIntro.TabStop = false;
            // 
            // CkBoxInstallWinpcap
            // 
            this.CkBoxInstallWinpcap.AutoSize = true;
            this.CkBoxInstallWinpcap.Location = new System.Drawing.Point(31, 72);
            this.CkBoxInstallWinpcap.Name = "CkBoxInstallWinpcap";
            this.CkBoxInstallWinpcap.Size = new System.Drawing.Size(100, 16);
            this.CkBoxInstallWinpcap.TabIndex = 1;
            this.CkBoxInstallWinpcap.Text = "Winpcap 설치";
            this.CkBoxInstallWinpcap.UseVisualStyleBackColor = true;
            this.CkBoxInstallWinpcap.CheckedChanged += new System.EventHandler(this.CkBoxInstallWinpcap_CheckedChanged);
            // 
            // LabelMsg
            // 
            this.LabelMsg.AutoSize = true;
            this.LabelMsg.Location = new System.Drawing.Point(23, 30);
            this.LabelMsg.Name = "LabelMsg";
            this.LabelMsg.Size = new System.Drawing.Size(453, 24);
            this.LabelMsg.TabIndex = 0;
            this.LabelMsg.Text = "SIP 폰으로 설정할 경우, 제대로 작동하려면 WinPcap 프로그램을 설치해야 합니다.\r\n설치 하시겠습니까?";
            // 
            // ButtonNext
            // 
            this.ButtonNext.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ButtonNext.Location = new System.Drawing.Point(394, 376);
            this.ButtonNext.Name = "ButtonNext";
            this.ButtonNext.Size = new System.Drawing.Size(87, 23);
            this.ButtonNext.TabIndex = 8;
            this.ButtonNext.Text = "다음 >";
            this.ButtonNext.UseVisualStyleBackColor = true;
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonCancel.Location = new System.Drawing.Point(486, 376);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(87, 23);
            this.ButtonCancel.TabIndex = 7;
            this.ButtonCancel.Text = "취소";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            // 
            // FrmWinpcapInstall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 422);
            this.Controls.Add(this.ButtonNext);
            this.Controls.Add(this.GrpBoxIntro);
            this.Controls.Add(this.ButtonCancel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmWinpcapInstall";
            this.Text = "WeDo Server 설치 - WinPcap 설치";
            this.GrpBoxIntro.ResumeLayout(false);
            this.GrpBoxIntro.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpBoxIntro;
        private System.Windows.Forms.Button ButtonNext;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.Label LabelMsg;
        private System.Windows.Forms.CheckBox CkBoxInstallWinpcap;
    }
}
namespace CustomAction
{
    partial class FrmInstallList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInstallList));
            this.GrpBoxIntro = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CkBoxInstallAll = new System.Windows.Forms.CheckBox();
            this.CkBoxInstallMySql = new System.Windows.Forms.CheckBox();
            this.CkBoxInstallWeDoServer = new System.Windows.Forms.CheckBox();
            this.LabelMsg = new System.Windows.Forms.Label();
            this.ButtonNext = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.GrpBoxIntro.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrpBoxIntro
            // 
            this.GrpBoxIntro.Controls.Add(this.groupBox1);
            this.GrpBoxIntro.Controls.Add(this.LabelMsg);
            this.GrpBoxIntro.Location = new System.Drawing.Point(33, 28);
            this.GrpBoxIntro.Name = "GrpBoxIntro";
            this.GrpBoxIntro.Size = new System.Drawing.Size(540, 336);
            this.GrpBoxIntro.TabIndex = 0;
            this.GrpBoxIntro.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CkBoxInstallAll);
            this.groupBox1.Controls.Add(this.CkBoxInstallMySql);
            this.groupBox1.Controls.Add(this.CkBoxInstallWeDoServer);
            this.groupBox1.Location = new System.Drawing.Point(25, 117);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // CkBoxInstallAll
            // 
            this.CkBoxInstallAll.AutoSize = true;
            this.CkBoxInstallAll.Checked = true;
            this.CkBoxInstallAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CkBoxInstallAll.Location = new System.Drawing.Point(6, 0);
            this.CkBoxInstallAll.Name = "CkBoxInstallAll";
            this.CkBoxInstallAll.Size = new System.Drawing.Size(72, 16);
            this.CkBoxInstallAll.TabIndex = 5;
            this.CkBoxInstallAll.Text = "전체설치";
            this.CkBoxInstallAll.UseVisualStyleBackColor = true;
            this.CkBoxInstallAll.CheckedChanged += new System.EventHandler(this.CkBoxInstallAll_CheckedChanged);
            // 
            // CkBoxInstallMySql
            // 
            this.CkBoxInstallMySql.AutoSize = true;
            this.CkBoxInstallMySql.Checked = true;
            this.CkBoxInstallMySql.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CkBoxInstallMySql.Enabled = false;
            this.CkBoxInstallMySql.Location = new System.Drawing.Point(18, 28);
            this.CkBoxInstallMySql.Name = "CkBoxInstallMySql";
            this.CkBoxInstallMySql.Size = new System.Drawing.Size(136, 16);
            this.CkBoxInstallMySql.TabIndex = 3;
            this.CkBoxInstallMySql.Text = "MySql DB 서버 설치";
            this.CkBoxInstallMySql.UseVisualStyleBackColor = true;
            // 
            // CkBoxInstallWeDoServer
            // 
            this.CkBoxInstallWeDoServer.AutoSize = true;
            this.CkBoxInstallWeDoServer.Checked = true;
            this.CkBoxInstallWeDoServer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CkBoxInstallWeDoServer.Enabled = false;
            this.CkBoxInstallWeDoServer.Location = new System.Drawing.Point(18, 50);
            this.CkBoxInstallWeDoServer.Name = "CkBoxInstallWeDoServer";
            this.CkBoxInstallWeDoServer.Size = new System.Drawing.Size(160, 16);
            this.CkBoxInstallWeDoServer.TabIndex = 2;
            this.CkBoxInstallWeDoServer.Text = "운영자관리프로그램 설치";
            this.CkBoxInstallWeDoServer.UseVisualStyleBackColor = true;
            // 
            // LabelMsg
            // 
            this.LabelMsg.AutoSize = true;
            this.LabelMsg.Location = new System.Drawing.Point(23, 30);
            this.LabelMsg.Name = "LabelMsg";
            this.LabelMsg.Size = new System.Drawing.Size(371, 48);
            this.LabelMsg.TabIndex = 0;
            this.LabelMsg.Text = "다음과 같은 프로그램들을 설치합니다.\r\n처음 설치하는 경우, 전체 프로그램을 설치합니다.\r\n\r\n* 이미 설치한 후, 원하는 항목을 선택하여 각각 " +
                "설치할 수 있습니다.";
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
            // FrmInstallList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 422);
            this.Controls.Add(this.ButtonNext);
            this.Controls.Add(this.GrpBoxIntro);
            this.Controls.Add(this.ButtonCancel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmInstallList";
            this.Text = "바이럴프로그램 설치 - 설치항목선택";
            this.GrpBoxIntro.ResumeLayout(false);
            this.GrpBoxIntro.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpBoxIntro;
        private System.Windows.Forms.Button ButtonNext;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.Label LabelMsg;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox CkBoxInstallMySql;
        private System.Windows.Forms.CheckBox CkBoxInstallWeDoServer;
        private System.Windows.Forms.CheckBox CkBoxInstallAll;
    }
}
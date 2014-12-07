namespace JinnonsCode
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmStatus));
            this.NotifyIconTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.ContextMenuStripOnTray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItemRestore = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.ButtonNext = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.GrpBoxIntro = new System.Windows.Forms.GroupBox();
            this.LabelProgramEndMessage = new System.Windows.Forms.Label();
            this.RichTextBoxStatusMsg = new System.Windows.Forms.RichTextBox();
            this.LabelMsg = new System.Windows.Forms.Label();
            this.ContextMenuStripOnTray.SuspendLayout();
            this.GrpBoxIntro.SuspendLayout();
            this.SuspendLayout();
            // 
            // NotifyIconTray
            // 
            this.NotifyIconTray.ContextMenuStrip = this.ContextMenuStripOnTray;
            this.NotifyIconTray.Icon = ((System.Drawing.Icon)(resources.GetObject("NotifyIconTray.Icon")));
            this.NotifyIconTray.Text = "바이럴 마케팅 프로그램";
            this.NotifyIconTray.Visible = true;
            this.NotifyIconTray.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIconTray_MouseDoubleClick);
            // 
            // ContextMenuStripOnTray
            // 
            this.ContextMenuStripOnTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemRestore,
            this.ToolStripMenuItemExit});
            this.ContextMenuStripOnTray.Name = "contextMenuStrip1";
            this.ContextMenuStripOnTray.Size = new System.Drawing.Size(99, 48);
            // 
            // ToolStripMenuItemRestore
            // 
            this.ToolStripMenuItemRestore.Name = "ToolStripMenuItemRestore";
            this.ToolStripMenuItemRestore.Size = new System.Drawing.Size(98, 22);
            this.ToolStripMenuItemRestore.Text = "복귀";
            this.ToolStripMenuItemRestore.Click += new System.EventHandler(this.ToolStripMenuItemRestore_Click);
            // 
            // ToolStripMenuItemExit
            // 
            this.ToolStripMenuItemExit.Name = "ToolStripMenuItemExit";
            this.ToolStripMenuItemExit.Size = new System.Drawing.Size(98, 22);
            this.ToolStripMenuItemExit.Text = "종료";
            this.ToolStripMenuItemExit.Click += new System.EventHandler(this.ToolStripMenuItemExit_Click);
            // 
            // ButtonNext
            // 
            this.ButtonNext.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ButtonNext.Location = new System.Drawing.Point(376, 352);
            this.ButtonNext.Name = "ButtonNext";
            this.ButtonNext.Size = new System.Drawing.Size(87, 23);
            this.ButtonNext.TabIndex = 19;
            this.ButtonNext.Text = "현황보기";
            this.ButtonNext.UseVisualStyleBackColor = true;
            this.ButtonNext.Click += new System.EventHandler(this.ButtonNext_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonCancel.Location = new System.Drawing.Point(469, 352);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(98, 23);
            this.ButtonCancel.TabIndex = 18;
            this.ButtonCancel.Text = "작업취소(닫기)";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // GrpBoxIntro
            // 
            this.GrpBoxIntro.Controls.Add(this.LabelProgramEndMessage);
            this.GrpBoxIntro.Controls.Add(this.RichTextBoxStatusMsg);
            this.GrpBoxIntro.Controls.Add(this.LabelMsg);
            this.GrpBoxIntro.Location = new System.Drawing.Point(27, 1);
            this.GrpBoxIntro.Name = "GrpBoxIntro";
            this.GrpBoxIntro.Size = new System.Drawing.Size(540, 336);
            this.GrpBoxIntro.TabIndex = 17;
            this.GrpBoxIntro.TabStop = false;
            // 
            // LabelProgramEndMessage
            // 
            this.LabelProgramEndMessage.AutoSize = true;
            this.LabelProgramEndMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.LabelProgramEndMessage.Location = new System.Drawing.Point(27, 51);
            this.LabelProgramEndMessage.Name = "LabelProgramEndMessage";
            this.LabelProgramEndMessage.Size = new System.Drawing.Size(313, 12);
            this.LabelProgramEndMessage.TabIndex = 2;
            this.LabelProgramEndMessage.Text = "스케줄실행이 종료되었습니다. 프로그램을 종료하십시요.";
            this.LabelProgramEndMessage.Visible = false;
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
            this.LabelMsg.Size = new System.Drawing.Size(105, 12);
            this.LabelMsg.TabIndex = 0;
            this.LabelMsg.Text = "프로그램 상태보기";
            // 
            // FrmStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 385);
            this.Controls.Add(this.ButtonNext);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.GrpBoxIntro);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmStatus";
            this.Text = "clickBot 스케줄 작업수행";
            this.Shown += new System.EventHandler(this.FrmStatus_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmStatus_FormClosing);
            this.ContextMenuStripOnTray.ResumeLayout(false);
            this.GrpBoxIntro.ResumeLayout(false);
            this.GrpBoxIntro.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon NotifyIconTray;
        private System.Windows.Forms.ContextMenuStrip ContextMenuStripOnTray;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemRestore;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemExit;
        private System.Windows.Forms.Button ButtonNext;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.GroupBox GrpBoxIntro;
        private System.Windows.Forms.RichTextBox RichTextBoxStatusMsg;
        private System.Windows.Forms.Label LabelMsg;
        private System.Windows.Forms.Label LabelProgramEndMessage;
    }
}
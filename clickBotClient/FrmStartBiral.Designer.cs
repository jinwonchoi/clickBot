namespace JinnonsCode
{
    partial class FrmStartBiral
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmStartBiral));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.LBServerIdList = new System.Windows.Forms.ListBox();
            this.LabelMsg = new System.Windows.Forms.Label();
            this.cbIgnoreHistory = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CBUseProxy = new System.Windows.Forms.CheckBox();
            this.LinkLabelJDK = new System.Windows.Forms.LinkLabel();
            this.LabelJDK = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.LinkLabelIExplorer = new System.Windows.Forms.LinkLabel();
            this.LinkLabelFireFox = new System.Windows.Forms.LinkLabel();
            this.LinkLabelChrome = new System.Windows.Forms.LinkLabel();
            this.label6 = new System.Windows.Forms.Label();
            this.TextBoxServerIds = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.LabelIexplore = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.LabelFireFox = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.LabelChrome = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ButtonNext = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.CBUseMonkey = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.LBUseProxy = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LBUseProxy);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.CBUseMonkey);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.LBServerIdList);
            this.groupBox1.Controls.Add(this.LabelMsg);
            this.groupBox1.Controls.Add(this.cbIgnoreHistory);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.CBUseProxy);
            this.groupBox1.Controls.Add(this.LinkLabelJDK);
            this.groupBox1.Controls.Add(this.LabelJDK);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.LinkLabelIExplorer);
            this.groupBox1.Controls.Add(this.LinkLabelFireFox);
            this.groupBox1.Controls.Add(this.LinkLabelChrome);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.TextBoxServerIds);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.LabelIexplore);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.LabelFireFox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.LabelChrome);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(26, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(622, 561);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(412, 238);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 12);
            this.label9.TabIndex = 27;
            this.label9.Text = "수행ID리스트";
            // 
            // LBServerIdList
            // 
            this.LBServerIdList.FormattingEnabled = true;
            this.LBServerIdList.ItemHeight = 12;
            this.LBServerIdList.Location = new System.Drawing.Point(413, 253);
            this.LBServerIdList.Name = "LBServerIdList";
            this.LBServerIdList.Size = new System.Drawing.Size(69, 112);
            this.LBServerIdList.TabIndex = 26;
            this.LBServerIdList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LBServerIdList_MouseDoubleClick);
            // 
            // LabelMsg
            // 
            this.LabelMsg.AutoSize = true;
            this.LabelMsg.Location = new System.Drawing.Point(48, 483);
            this.LabelMsg.Name = "LabelMsg";
            this.LabelMsg.Size = new System.Drawing.Size(285, 12);
            this.LabelMsg.TabIndex = 25;
            this.LabelMsg.Text = "* 사    용: 즉시실행 ( 현재시점 작업한 것 반복실행)";
            // 
            // cbIgnoreHistory
            // 
            this.cbIgnoreHistory.AutoSize = true;
            this.cbIgnoreHistory.Location = new System.Drawing.Point(30, 462);
            this.cbIgnoreHistory.Name = "cbIgnoreHistory";
            this.cbIgnoreHistory.Size = new System.Drawing.Size(100, 16);
            this.cbIgnoreHistory.TabIndex = 5;
            this.cbIgnoreHistory.Text = "강제수행 사용";
            this.cbIgnoreHistory.UseVisualStyleBackColor = true;
            this.cbIgnoreHistory.CheckedChanged += new System.EventHandler(this.cbIgnoreHistory_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 393);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(401, 12);
            this.label3.TabIndex = 23;
            this.label3.Text = "* 사     용 : 마케팅용IP사용. \"청춘IP 프록시 서비스\" 실행 및 로그인 필수.";
            // 
            // CBUseProxy
            // 
            this.CBUseProxy.AutoSize = true;
            this.CBUseProxy.Location = new System.Drawing.Point(33, 374);
            this.CBUseProxy.Name = "CBUseProxy";
            this.CBUseProxy.Size = new System.Drawing.Size(95, 16);
            this.CBUseProxy.TabIndex = 22;
            this.CBUseProxy.Text = "프록시IP사용";
            this.CBUseProxy.UseVisualStyleBackColor = true;
            // 
            // LinkLabelJDK
            // 
            this.LinkLabelJDK.AutoSize = true;
            this.LinkLabelJDK.Location = new System.Drawing.Point(75, 205);
            this.LinkLabelJDK.Name = "LinkLabelJDK";
            this.LinkLabelJDK.Size = new System.Drawing.Size(525, 12);
            this.LinkLabelJDK.TabIndex = 21;
            this.LinkLabelJDK.TabStop = true;
            this.LinkLabelJDK.Text = "http://www.oracle.com/technetwork/java/javase/downloads/jdk7-downloads-1880260.ht" +
                "ml";
            // 
            // LabelJDK
            // 
            this.LabelJDK.AutoSize = true;
            this.LabelJDK.Location = new System.Drawing.Point(140, 182);
            this.LabelJDK.Name = "LabelJDK";
            this.LabelJDK.Size = new System.Drawing.Size(0, 12);
            this.LabelJDK.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(29, 182);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 12);
            this.label7.TabIndex = 19;
            this.label7.Text = "자바SDK:";
            // 
            // LinkLabelIExplorer
            // 
            this.LinkLabelIExplorer.AutoSize = true;
            this.LinkLabelIExplorer.Location = new System.Drawing.Point(75, 161);
            this.LinkLabelIExplorer.Name = "LinkLabelIExplorer";
            this.LinkLabelIExplorer.Size = new System.Drawing.Size(388, 12);
            this.LinkLabelIExplorer.TabIndex = 18;
            this.LinkLabelIExplorer.TabStop = true;
            this.LinkLabelIExplorer.Text = "http://windows.microsoft.com/ko-kr/internet-explorer/download-ie";
            // 
            // LinkLabelFireFox
            // 
            this.LinkLabelFireFox.AutoSize = true;
            this.LinkLabelFireFox.Location = new System.Drawing.Point(75, 114);
            this.LinkLabelFireFox.Name = "LinkLabelFireFox";
            this.LinkLabelFireFox.Size = new System.Drawing.Size(407, 12);
            this.LinkLabelFireFox.TabIndex = 17;
            this.LinkLabelFireFox.TabStop = true;
            this.LinkLabelFireFox.Text = "https://download.mozilla.org/?product=firefox-beta-stub&os=win&lang=ko";
            // 
            // LinkLabelChrome
            // 
            this.LinkLabelChrome.AutoSize = true;
            this.LinkLabelChrome.Location = new System.Drawing.Point(75, 66);
            this.LinkLabelChrome.Name = "LinkLabelChrome";
            this.LinkLabelChrome.Size = new System.Drawing.Size(256, 12);
            this.LinkLabelChrome.TabIndex = 16;
            this.LinkLabelChrome.TabStop = true;
            this.LinkLabelChrome.Text = "https://www.google.com/chrome/browser/";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(45, 262);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(337, 12);
            this.label6.TabIndex = 14;
            this.label6.Text = "우측 목록에서 선택. 다음과 같이 입력합니다. ex: 001,002,003";
            // 
            // TextBoxServerIds
            // 
            this.TextBoxServerIds.Location = new System.Drawing.Point(126, 237);
            this.TextBoxServerIds.Name = "TextBoxServerIds";
            this.TextBoxServerIds.Size = new System.Drawing.Size(246, 21);
            this.TextBoxServerIds.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 240);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "수행 프로그램ID:";
            // 
            // LabelIexplore
            // 
            this.LabelIexplore.AutoSize = true;
            this.LabelIexplore.Location = new System.Drawing.Point(140, 138);
            this.LabelIexplore.Name = "LabelIexplore";
            this.LabelIexplore.Size = new System.Drawing.Size(0, 12);
            this.LabelIexplore.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(29, 138);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 12);
            this.label8.TabIndex = 10;
            this.label8.Text = "인터넷익스플로어:";
            // 
            // LabelFireFox
            // 
            this.LabelFireFox.AutoSize = true;
            this.LabelFireFox.Location = new System.Drawing.Point(140, 92);
            this.LabelFireFox.Name = "LabelFireFox";
            this.LabelFireFox.Size = new System.Drawing.Size(0, 12);
            this.LabelFireFox.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "파이어폭스:";
            // 
            // LabelChrome
            // 
            this.LabelChrome.AutoSize = true;
            this.LabelChrome.Location = new System.Drawing.Point(140, 47);
            this.LabelChrome.Name = "LabelChrome";
            this.LabelChrome.Size = new System.Drawing.Size(0, 12);
            this.LabelChrome.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "크롬:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(481, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "clickBot 바이럴 프로그램을 실행하려면 다음과 같은 브라우저가 설치되어있어야 합니다.";
            // 
            // ButtonNext
            // 
            this.ButtonNext.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ButtonNext.Location = new System.Drawing.Point(479, 585);
            this.ButtonNext.Name = "ButtonNext";
            this.ButtonNext.Size = new System.Drawing.Size(87, 23);
            this.ButtonNext.TabIndex = 21;
            this.ButtonNext.Text = "다음 >";
            this.ButtonNext.UseVisualStyleBackColor = true;
            this.ButtonNext.Click += new System.EventHandler(this.ButtonNext_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonCancel.Location = new System.Drawing.Point(571, 585);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(87, 23);
            this.ButtonCancel.TabIndex = 20;
            this.ButtonCancel.Text = "취소";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(48, 552);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(213, 12);
            this.label10.TabIndex = 29;
            this.label10.Text = "프로그램의 자동웹서핑 기능을 활성화.";
            this.label10.Visible = false;
            // 
            // CBUseMonkey
            // 
            this.CBUseMonkey.AutoSize = true;
            this.CBUseMonkey.Enabled = false;
            this.CBUseMonkey.Location = new System.Drawing.Point(36, 533);
            this.CBUseMonkey.Name = "CBUseMonkey";
            this.CBUseMonkey.Size = new System.Drawing.Size(140, 16);
            this.CBUseMonkey.TabIndex = 28;
            this.CBUseMonkey.Text = "프로그램 랜덤 웹서핑";
            this.CBUseMonkey.UseVisualStyleBackColor = true;
            this.CBUseMonkey.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(187, 463);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(383, 12);
            this.label11.TabIndex = 30;
            this.label11.Text = "***실제 작업수행은 매시 55분에 생성된 수행계획에 따라 수행됩니다. ";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(48, 503);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(401, 12);
            this.label12.TabIndex = 31;
            this.label12.Text = "* 사용안함: 정상수행. 매시 55분이후 실행 (브라우저가 55분이후 기동됨).\r\n";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(45, 411);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(236, 12);
            this.label13.TabIndex = 32;
            this.label13.Text = "* 사용안함: 컴푸터 실제 IP사용.(테스트용)\r\n";
            // 
            // LBUseProxy
            // 
            this.LBUseProxy.AutoSize = true;
            this.LBUseProxy.ForeColor = System.Drawing.Color.Red;
            this.LBUseProxy.Location = new System.Drawing.Point(48, 433);
            this.LBUseProxy.Name = "LBUseProxy";
            this.LBUseProxy.Size = new System.Drawing.Size(314, 24);
            this.LBUseProxy.TabIndex = 33;
            this.LBUseProxy.Text = "\"청춘IP - 프록시 서비스\" 프로그램이 미실행 상태입니다. \r\n실행 및 로그인해야 마케팅용 IP를 사용할 수 있습니다.";
            this.LBUseProxy.Visible = false;
            // 
            // FrmStartBiral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 620);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ButtonNext);
            this.Controls.Add(this.ButtonCancel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmStartBiral";
            this.Text = "clickBot 스케줄 작업수행";
            this.Load += new System.EventHandler(this.FrmStartBiral_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmStartBiral_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label LabelChrome;
        private System.Windows.Forms.CheckBox cbIgnoreHistory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ButtonNext;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.Label LabelIexplore;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label LabelFireFox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TextBoxServerIds;
        private System.Windows.Forms.LinkLabel LinkLabelChrome;
        private System.Windows.Forms.LinkLabel LinkLabelIExplorer;
        private System.Windows.Forms.LinkLabel LinkLabelFireFox;
        private System.Windows.Forms.LinkLabel LinkLabelJDK;
        private System.Windows.Forms.Label LabelJDK;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox CBUseProxy;
        private System.Windows.Forms.Label LabelMsg;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ListBox LBServerIdList;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox CBUseMonkey;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label LBUseProxy;
    }
}
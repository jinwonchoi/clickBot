using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration.Install;

namespace CustomAction
{
    public partial class FrmWinpcapInstall : Form
    {
        System.Configuration.Install.InstallContext formContext;

        public FrmWinpcapInstall()
        {
            InitializeComponent();
        }

        public FrmWinpcapInstall(System.Configuration.Install.InstallContext context, string fileName)
        {
            formContext = context;
            InitializeComponent();
            this.CenterToScreen();
            LabelMsg.Text = "프로그램이 정상적으로 작동하려면 "+fileName+" 프로그램을 설치해야 합니다.\n"
                            +"설치 하시겠습니까?";
            CkBoxInstallWinpcap.Text = fileName +" 설치";
            this.Text = fileName + " 설치";
            ButtonNext.Enabled = false;
        }

        //폼 우측상단 버튼 안보임
        private const int WS_SYSMENU = 0x80000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style &= ~WS_SYSMENU;
                return cp;
            }
        }

        public bool NeedInstall()
        {
            return this.CkBoxInstallWinpcap.Checked;
        }

        private void CkBoxInstallWinpcap_CheckedChanged(object sender, EventArgs e)
        {
            ButtonNext.Enabled = CkBoxInstallWinpcap.Checked;
        }
    }
}

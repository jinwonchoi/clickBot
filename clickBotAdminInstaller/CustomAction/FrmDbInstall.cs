using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration.Install;
using WeDoCommon;

namespace CustomAction
{
    public partial class FrmDbInstall : Form
    {
        System.Configuration.Install.InstallContext formContext = null;
        InstallController ctrl = null;

        public FrmDbInstall()
        {
            InitializeComponent();
        }

        public FrmDbInstall(System.Configuration.Install.InstallContext context, InstallController ctrl)
        {
            Logger.info("FrmDbInstall");

            formContext = context;
            this.ctrl = ctrl;
            InitializeComponent();
            this.CenterToScreen();
        }

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

        private void Initialize()
        {
            //
        }

        public void SetPrevDbInfo(bool exists)
        {
            Logger.info("SetPrevDbInfo:"+exists);
            if (!exists)
            {
                LabelMsg.Text = "바이럴 프로그램이 사용할 데이터베이스를 설치합니다.";
            }
        }

        private void FrmDbInstall_Shown(object sender, EventArgs e)
        {
            Logger.info("FrmDbInstall_Shown");
            Initialize();
            if (ctrl != null)
            {
                SetPrevDbInfo(ctrl.prevDbExists());
            }
        }

        private void ButtonNext_Click(object sender, EventArgs e)
        {
            ctrl.NeedPrevDbRemove = CkBoxNeedDbDelete.Checked;
        }

    }
}

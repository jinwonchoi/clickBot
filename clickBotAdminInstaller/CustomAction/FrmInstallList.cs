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
    public partial class FrmInstallList : Form
    {
        System.Configuration.Install.InstallContext formContext;

        public FrmInstallList()
        {
            InitializeComponent();
        }

        public FrmInstallList(System.Configuration.Install.InstallContext context)
        {
            formContext = context;
            InitializeComponent();
            this.CenterToScreen();
        }

        public bool NeedWeDoServerInstall()
        {
            return this.CkBoxInstallWeDoServer.Checked;
        }
        
        public bool NeedMySqlInstall()
        {
            return this.CkBoxInstallMySql.Checked;
        }

        private void CkBoxInstallAll_CheckedChanged(object sender, EventArgs e)
        {
            if (CkBoxInstallAll.Checked)
            {
                CkBoxInstallMySql.Checked = true;
                CkBoxInstallWeDoServer.Checked = true;

                CkBoxInstallMySql.Enabled = false;
                CkBoxInstallWeDoServer.Enabled = false;
            }
            else
            {
                CkBoxInstallMySql.Enabled = true;
                CkBoxInstallWeDoServer.Enabled = true;
            }
        }
    }
}

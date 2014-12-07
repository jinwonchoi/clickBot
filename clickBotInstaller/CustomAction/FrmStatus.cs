using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeDoCommon;
using System.Threading;

namespace CustomAction
{
    public partial class FrmStatus : Form
    {
        System.Configuration.Install.InstallContext formContext;

        public delegate bool DelExecute();
        DelExecute delHandler = null;
        
        public delegate void DelAppendStatusMsg(string msg);
        DelAppendStatusMsg delAppendStatusMsg = null;

        Thread workerThread = null;

        public FrmStatus()
        {
            InitializeComponent();
        }

        public FrmStatus(System.Configuration.Install.InstallContext context,
            string barTitle, string headTitle, DelExecute method)
        {
            formContext = context;
            InitializeComponent();
            this.CenterToScreen();

            this.Text = barTitle;
            this.LabelMsg.Text = headTitle;
            this.delHandler = method;
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

        public void OnStatusWrite(object sender, StringEventArgs e)
        {
            Logger.info(e.EventString);

            this.BeginInvoke((MethodInvoker)delegate
            {
                delAppendStatusMsg = new DelAppendStatusMsg(this.RichTextBoxStatusMsg.AppendText);
                if (this.RichTextBoxStatusMsg.InvokeRequired)
                {
                    Invoke(delAppendStatusMsg, e.EventString);
                }
                else
                {
                    RichTextBoxStatusMsg.AppendText(e.EventString + "\n");
                }
                Logger.info(e.EventString);
            });
        }

        private void AppendStatusMsg(string msg)
        {
            RichTextBoxStatusMsg.AppendText(msg);
        }

        private void FrmStatus_Shown(object sender, EventArgs e)
        {
            workerThread = new Thread(WorkerThread);
            workerThread.Start();
        }

        private void WorkerThread(object data)
        {
            try
            {
                bool result = false;
                if (delHandler != null)
                {
                    Initialize();
                    result = delHandler();
                    SetButton(result);
                }
            }
            catch (Exception ex)
            {
                Logger.error("WorkerThread 실행중 에러발생 : " + ex.ToString());
                throw new Exception("WorkerThread 실행중 에러발생");
            }
        }

        private void Initialize()
        {
            this.ButtonNext.Enabled = false;
        }

        private void SetButton(bool completed)
        {
            this.ButtonNext.Enabled = completed;
        }

        private void FrmStatus_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (workerThread != null)
                workerThread.Abort();
        }
    }
}

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
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;

namespace JinnonsCode
{
    public partial class FrmStatus : Form
    {
        bool realClose = false;
        bool forcedRun = false;

        System.Diagnostics.Process pProcess = new System.Diagnostics.Process();

        public FrmStatus(bool forcedRun)
        {
            InitializeComponent();
            this.CenterToScreen();
            LogWriteHandler += this.OnStatusWrite;
            this.forcedRun = forcedRun;
        }

#region 트레이 처리
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmStatus_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!realClose)
            {
                this.WindowState = FormWindowState.Minimized;

                NotifyIconTray.BalloonTipIcon = ToolTipIcon.Info;
                NotifyIconTray.BalloonTipTitle = "바이럴마케팅 프로그램";
                NotifyIconTray.BalloonTipText = "현재 프로그램이 실행중입니다." +
                Environment.NewLine +
                "프로그램을 종료하려면 종료를 선택하세요.";

                NotifyIconTray.ShowBalloonTip(5000);

                e.Cancel = true;
            }
        }

        private void NotifyIconTray_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void ToolStripMenuItemRestore_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void ToolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            realClose = true;
            Close();
        }
#endregion

        #region 상태메시지처리
        //public delegate bool DelExecute();
        //DelExecute delHandler = null;

        public delegate void DelAppendStatusMsg(string msg);
        DelAppendStatusMsg delAppendStatusMsg = null;

        Thread workerThread = null;

        public event EventHandler<StringEventArgs> LogWriteHandler;

        public virtual void OnWriteLog(string msg)
        {
            Logger.info(msg);
            EventHandler<StringEventArgs> handler = this.LogWriteHandler;
            if (this.LogWriteHandler != null)
            {
                handler(this, new StringEventArgs(msg));
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

        #endregion

        private void FrmStatus_Shown(object sender, EventArgs e)
        {
            workerThread = new Thread(WorkerThread);
            workerThread.Start();
        }

        private void WorkerThread(object data)
        {
            try
            {
                this.OnWriteLog("테스트");
                ExecuteJavaProgram();
            }
            catch (Exception ex)
            {
                Logger.error("WorkerThread 실행중 에러발생 : " + ex.ToString());
                throw new Exception("WorkerThread 실행중 에러발생");
            }
        }
        
        /// <summary>
        /// set JAVA_OPTIONS=-Dapp_home=%APP_HOME% -Dforced=false
        /// java %JAVA_OPTIONS% -jar %app_home%\biralApp-1.0.0.jar
        /// </summary>
        private void ExecuteJavaProgram()
        {
            this.OnWriteLog("작업을 실행합니다.");
            string appHome = ConstDef.WORK_DIR;

            string forcedRunFlag = forcedRun ? "true" : "false";
            string strCommand = string.Format("java", appHome, forcedRunFlag);
            string strCommandParameters = string.Format("-Dapp_home={0} -Dforced={1} -jar {0}\\biralApp-1.0.0.jar", appHome, forcedRunFlag);
            this.OnWriteLog(strCommand + strCommandParameters);

            pProcess.StartInfo.FileName = strCommand;
            pProcess.StartInfo.Arguments = strCommandParameters;
            pProcess.StartInfo.UseShellExecute = false;
            pProcess.StartInfo.RedirectStandardOutput = true;
            //Optional
            pProcess.StartInfo.WorkingDirectory = appHome;

            pProcess.StartInfo.CreateNoWindow = true;
            pProcess.StartInfo.ErrorDialog = false;
            pProcess.StartInfo.UseShellExecute = false;
            pProcess.StartInfo.RedirectStandardError = true;
            pProcess.StartInfo.RedirectStandardInput = true;
            pProcess.StartInfo.RedirectStandardOutput = true;
            pProcess.EnableRaisingEvents = true;
            pProcess.OutputDataReceived += process_OutputDataReceived;
            pProcess.ErrorDataReceived += process_OutputDataReceived;
            pProcess.Exited += process_Exited;
            pProcess.Start();
            pProcess.BeginErrorReadLine();
            pProcess.BeginOutputReadLine();

            //Wait for process to finish
            pProcess.WaitForExit();

        }

        private void TerminateJavaProgram()
        {
            if (!pProcess.HasExited)
            {
                if (AttachConsole((uint)pProcess.Id))
                {
                    //Disable Ctrl-C handling for our program
                    SetConsoleCtrlHandler(null, true);
                    GenerateConsoleCtrlEvent(CtrlTypes.CTRL_C_EVENT, 0);

                    //Must wait here. If we don't and re-enable Ctrl-C
                    //handling below too fast, we might terminate ourselves.
                    pProcess.WaitForExit(2000);

                    FreeConsole();
                    //Re-enable Ctrl-C handling or any subsequently started
                    //programs will inherit the disabled state.
                    SetConsoleCtrlHandler(null, false); 

                    //pProcess.Exited -= process_Exited;
                    //pProcess.OutputDataReceived -= process_OutputDataReceived;
                    //pProcess.ErrorDataReceived -= process_OutputDataReceived;
                }
            }
            //GenerateConsoleCtrlEvent(ConsoleCtrlEvent.CTRL_C, pProcess.SessionId);  
        }

        //import in the declaration for GenerateConsoleCtrlEvent
        //[DllImport("kernel32.dll", SetLastError = true)]
        //static extern bool GenerateConsoleCtrlEvent(ConsoleCtrlEvent sigevent, int dwProcessGroupId);
        //public enum ConsoleCtrlEvent
        //{
        //    CTRL_C = 0,
        //    CTRL_BREAK = 1,
        //    CTRL_CLOSE = 2,
        //    CTRL_LOGOFF = 5,
        //    CTRL_SHUTDOWN = 6
        //}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        [DllImport("Kernel32")]
        private static extern bool SetConsoleCtrlHandler(EventHandler handler, bool add);

        private delegate bool EventHandler(CtrlTypes sig);
 
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool AttachConsole(uint dwProcessId);

        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        static extern bool FreeConsole();

        // Enumerated type for the control messages sent to the handler routine
        enum CtrlTypes : uint
        {
            CTRL_C_EVENT = 0,
            CTRL_BREAK_EVENT,
            CTRL_CLOSE_EVENT,
            CTRL_LOGOFF_EVENT = 5,
            CTRL_SHUTDOWN_EVENT
        }

        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GenerateConsoleCtrlEvent(CtrlTypes dwCtrlEvent, uint dwProcessGroupId);

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            if (LabelProgramEndMessage.Visible)
            {
                realClose = true;
                Close();
            }
            if (MessageBox.Show(string.Format("진행중인 작업스케줄을 중단합니다."
                                + "\n종료하시겠습니까?")
                    , "프로그램 종료"
                    , MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                TerminateJavaProgram();
                realClose = true;
                Close();
            }
        }

        void process_Exited(object sender, System.EventArgs e)
        {
            this.OnWriteLog("프로그램이 종료되었습니다.");
            try
            {
                if (LabelProgramEndMessage.InvokeRequired)
                {
                    LabelProgramEndMessage.Invoke(new MethodInvoker(
                        delegate { LabelProgramEndMessage.Visible = true; }));
                }
            }
            catch (Exception ex)
            {
                Logger.error("마케팅프로그램 종료 중 에러발생: " + ex.ToString());
            }
            //LabelProgramEndMessage.Visible = true;
        }

        void process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!realClose && e.Data != null && !e.Data.Contains("DEBUG"))
                this.OnWriteLog(e.Data.Replace('{', '[').Replace('}', ']'));
        }

        void process_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {

            if (!realClose && e.Data != null && !e.Data.Contains("DEBUG"))
                this.OnWriteLog(e.Data.Replace('{', '[').Replace('}', ']'));
        }

        private void ButtonNext_Click(object sender, EventArgs e)
        {

        }
    }
}

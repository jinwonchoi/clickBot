using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Threading;
using CustomAction;
using System.Windows.Forms;
using System.Diagnostics;
using WeDoCommon;


namespace PreDeployer
{
    [RunInstaller(true)]
    public partial class Installer1 : Installer
    {
        InstallController ctr = new InstallController();

        public Installer1()
        {
            InitializeComponent();
            // Attach the 'Committed' event. 
            this.Committed += new InstallEventHandler(MyInstaller_Committed);
            // Attach the 'Committing' event. 
            this.Committing += new InstallEventHandler(MyInstaller_Committing);
        }
        
        // Event handler for 'Committing' event. 
        private void MyInstaller_Committing(object sender, InstallEventArgs e)
        {            
            Logger.info("Committing Event occured.");
        }
        
        // Event handler for 'Committed' event. 
        private void MyInstaller_Committed(object sender, InstallEventArgs e)
        {
            Logger.info("Committed Event occured.");
        }

        public override void Commit(IDictionary savedState)
        {
            base.Commit(savedState);

            //인스톨 최종 완료 후에 작업
        }

        /// <summary>
        /// 1. DB설치
        /// 2. 데이터 생성
        /// </summary>
        /// <param name="stateSaver"></param>
        public override void Install(IDictionary stateSaver)
        {
            Logger.info("Install");

            WindowWrapper wrapper = GetWrapper();

            FlowController flowController = new FlowController(wrapper, this.Context);

            flowController.DoMain();

            
            //2. DB설치
            //Logger.info(Environment.CurrentDirectory);
            //foreach (string key in Environment.GetEnvironmentVariables().Keys) {
            //    Logger.info(key + ":"+ Environment.GetEnvironmentVariable(key) );
            //}


            
            //4.WeDo설치 <=== 실제 인스톨
            Logger.info("clickBot설치 시작.");
            base.Install(stateSaver);

            Logger.info("clickBot설치 완료.");

            //5.데이터 생성 : 
            
            //6.방화벽 설정
        }

        private WindowWrapper GetWrapper()
        {
            IntPtr hwnd = IntPtr.Zero;
            WindowWrapper wrapper = null;
            Process[] procs = Process.GetProcessesByName("msiexec");
            
            if (null != procs && procs.Length > 0) {
                foreach (Process proc in procs) {
                    if (proc.MainWindowTitle.Equals(this.Context.Parameters["prodName"].ToString()))
                    {
                        hwnd = proc.MainWindowHandle;
                        wrapper = new WindowWrapper(hwnd);

                    }
                }
            }
            return wrapper;
        }

        public override void Rollback(IDictionary savedState)
        {
            base.Rollback(savedState);
            Logger.info("Rollback");
        }

        public override void Uninstall(IDictionary savedState)
        {
            base.Uninstall(savedState);
            Logger.info("Uninstall");
        }

        protected override void OnBeforeInstall(IDictionary savedState)
        {
            base.OnBeforeInstall(savedState);
            Logger.info("OnBeforeInstall");
        }
        protected override void OnAfterInstall(IDictionary savedState)
        {
            base.OnAfterInstall(savedState);
            Logger.info("OnAfterInstall");
        }

    }
}

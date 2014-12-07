using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.ServiceProcess;

namespace WeDoCommon
{
    class WindowServiceHandler
    {
        public bool ServiceExists(string serviceName)
        {
            bool result = false;

            ServiceController[] controllers = ServiceController.GetServices();

            foreach (ServiceController ctrl in controllers)
            {
                if (ctrl.ServiceName.Equals(serviceName))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        public bool IsServiceRunning(string serviceName)
        {
            bool result = false;

            ServiceController[] controllers = ServiceController.GetServices();

            foreach (ServiceController ctrl in controllers)
            {
                if (ctrl.ServiceName.Equals(serviceName))
                {
                    result = (ctrl.Status.Equals(ServiceControllerStatus.Running));
                    break;
                }
            }
            return result;
        }

        //Gets the currently selected service
        private ServiceController GetService(string serviceName)
        {
            if (serviceName.Trim() != string.Empty)
                return new ServiceController(serviceName);
            else
                return null;
        }

        public void StopService(string serviceName)
        {
            System.ServiceProcess.ServiceController controller = GetService(serviceName);
            controller.Stop();
            controller.WaitForStatus(ServiceControllerStatus.Stopped,
                                new TimeSpan(0, 1, 0));
        }

        public void StartService(string serviceName)
        {
            System.ServiceProcess.ServiceController controller = GetService(serviceName);
            controller.Start();
            controller.WaitForStatus(ServiceControllerStatus.Running,
                                new TimeSpan(0, 1, 0));
        }

        public void InstallService(string ExeFilename, string commandLine)
        {

            //System.Configuration.Install.AssemblyInstaller Installer = new System.Configuration.Install.AssemblyInstaller(ExeFilename, commandLine);
            //Installer.UseNewContext = true;
            //Installer.Install(null);
            //Installer.Commit(null);
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = ExeFilename;
            startInfo.Arguments = commandLine;
            process.StartInfo = startInfo;
            if (!process.Start())
            {
                throw new Exception("Service등록중 에러발생");
            }

            process.WaitForExit(1000000);
        }

        public void UninstallService(string ExeFilename, string[] commandLine)
        {

            System.Configuration.Install.AssemblyInstaller Installer = new System.Configuration.Install.AssemblyInstaller(ExeFilename, commandLine);

            Installer.UseNewContext = true;

            Installer.Uninstall(null);

        }

        public string RunProcess(string cmd, string opt)
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.CreateNoWindow = true;
            startInfo.FileName = cmd;
            startInfo.Arguments = opt;
            startInfo.StandardOutputEncoding = Encoding.GetEncoding("euc-kr");
            process.StartInfo = startInfo;
            if (!process.Start())
            {
                throw new Exception(string.Format("[{0} {1}] 실행중 에러발생", cmd, opt));
            }

            string consoleText = process.StandardOutput.ReadToEnd();

            process.WaitForExit();

            if ((process.ExitCode != 0))
            {
                throw new Exception(string.Format("[{0} {1}] 실행중 에러발생. ExitCode[{2}]", cmd, opt, process.ExitCode));
            }

            return consoleText;
        }
    }
}

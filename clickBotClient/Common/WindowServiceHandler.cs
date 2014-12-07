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
                if (ctrl.ServiceName.Equals(serviceName)) {
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

        public bool StopService(string serviceName)
        {
            bool result = false;
            try
            {
                System.ServiceProcess.ServiceController controller = GetService(serviceName);
                controller.Stop();
                controller.WaitForStatus(ServiceControllerStatus.Stopped,
                                    new TimeSpan(0, 1, 0));
                result = true;
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }

            return result;
        }
 
        public bool StartService(string serviceName)
        {
            bool result = false;

            try
            {
                System.ServiceProcess.ServiceController controller = GetService(serviceName);
                controller.Start();
                controller.WaitForStatus(ServiceControllerStatus.Running,
                                    new TimeSpan(0, 1, 0));
                result = true;
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }
            
            return result;
        }


        public void InstallService(string ExeFilename)
        {

            System.Configuration.Install.AssemblyInstaller Installer = new System.Configuration.Install.AssemblyInstaller(ExeFilename, null);

            Installer.UseNewContext = true;

            Installer.Install(null);

            Installer.Commit(null);

        }
        public void UninstallService(string ExeFilename)
        {

            System.Configuration.Install.AssemblyInstaller Installer = new System.Configuration.Install.AssemblyInstaller(ExeFilename, null);

            Installer.UseNewContext = true;

            Installer.Uninstall(null);

        }

        //Installs and starts the service
        //ServiceInstaller.InstallAndStart("MyServiceName", "MyServiceDisplayName", "C:\PathToServiceFile.exe");

        ////Removes the service
        //ServiceInstaller.Uninstall("MyServiceName");

        ////Checks the status of the service
        //ServiceInstaller.GetServiceStatus("MyServiceName");

        ////Starts the service
        //ServiceInstaller.StartService("MyServiceName");

        ////Stops the service
        //ServiceInstaller.StopService("MyServiceName");

        ////Check if service is installed
        //ServiceInstaller.ServiceIsInstalled("MyServiceName");

    }
}

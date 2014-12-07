using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using NetFwTypeLib;

namespace WeDoCommon
{
    class FirewallHandler
    {
        private INetFwMgr _fwMgr;

        private const string PROGID_OPEN_PORT = "HNetCfg.FWOpenPort";
        // ProgID for the AuthorizedApplication object
        private const string PROGID_AUTHORIZED_APPLICATION = "HNetCfg.FwAuthorizedApplication";

        public FirewallHandler()
        {
        }

        public bool EnableFirewall()
        {
            return _SetEnableFirewall(true);
        }

        public bool DisableFirewall()
        {
            return _SetEnableFirewall(false);
        }

        public bool IsFirewallEnabled()
        {
            _fwMgr = _GetFirewallManager();

            return _fwMgr.LocalPolicy.CurrentProfile.FirewallEnabled;
        }

        private bool _SetEnableFirewall(bool enable)
        {
            _fwMgr = _GetFirewallManager();

            _fwMgr.LocalPolicy.CurrentProfile.FirewallEnabled = enable;

            return _fwMgr.LocalPolicy.CurrentProfile.FirewallEnabled;
        }

        private INetFwMgr _GetFirewallManager()
        {
            Type NetFwMgrType = Type.GetTypeFromProgID("HNetCfg.FwMgr", false);
            return (INetFwMgr)Activator.CreateInstance(NetFwMgrType);
        }


        public bool AddProgram(string title, string applicationPath)
        {
            bool result = false;
            INetFwAuthorizedApplication auth = _GetAuth(title, applicationPath);

            _fwMgr = _GetFirewallManager();

            try
            {
                _fwMgr.LocalPolicy.CurrentProfile.AuthorizedApplications.Add(auth);
                result = true;
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }
            return result;
        }

        public bool RemoveProgram(string applicationPath)
        {
            bool result = false;
            _fwMgr = _GetFirewallManager();

            try
            {
                _fwMgr.LocalPolicy.CurrentProfile.AuthorizedApplications.Remove(applicationPath);
                result = true;
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }
            return result;
        }


        private INetFwAuthorizedApplication _GetAuth(string title, string applicationPath)
        {
            // Create the type from prog id
            Type type = Type.GetTypeFromProgID(PROGID_AUTHORIZED_APPLICATION);
            INetFwAuthorizedApplication auth = Activator.CreateInstance(type)
                as INetFwAuthorizedApplication;
            auth.Name = title;
            auth.ProcessImageFileName = applicationPath;
            auth.Scope = NET_FW_SCOPE_.NET_FW_SCOPE_ALL;
            auth.IpVersion = NET_FW_IP_VERSION_.NET_FW_IP_VERSION_ANY;
            auth.Enabled = true;

            return auth;
        }

        public string GetByProgramPath(string fileName)
        {
            string programName = null;
            try
            {
                _fwMgr = _GetFirewallManager();
                foreach (INetFwAuthorizedApplication app in _fwMgr.LocalPolicy.CurrentProfile.AuthorizedApplications)
                {
                    if (fileName.ToLower().Equals(app.ProcessImageFileName.ToLower()))
                    {
                        programName = string.Format("{0}[{1}]", app.Name, app.ProcessImageFileName);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }
            return programName;
        }

        public List<string> GetProgramList()
        {
            List<string> aList = new List<string>();
            try
            {
                _fwMgr = _GetFirewallManager();
                foreach (INetFwAuthorizedApplication app in _fwMgr.LocalPolicy.CurrentProfile.AuthorizedApplications)
                {
                    aList.Add(app.Name + ":" + app.ProcessImageFileName);
                }
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }
            return aList;
        }

        public string GetByPort(int _port)
        {
            string portName = null;
            try
            {
                _fwMgr = _GetFirewallManager();
                foreach (INetFwOpenPort port in _fwMgr.LocalPolicy.CurrentProfile.GloballyOpenPorts)
                {
                    if (port.Port == _port)
                    {
                        portName = port.Name;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }
            return portName;
        }


        public List<string> GetPortList()
        {
            List<string> aList = new List<string>();
            try
            {
                _fwMgr = _GetFirewallManager();
                foreach (INetFwOpenPort port in _fwMgr.LocalPolicy.CurrentProfile.GloballyOpenPorts)
                {
                    aList.Add(port.Name + ":" + port.Port);
                }
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }
            return aList;
        }

        private INetFwOpenPort _GetPort(string title, int portNo, bool isUDP)
        {
            Type type = Type.GetTypeFromProgID(PROGID_OPEN_PORT);
            INetFwOpenPort port = Activator.CreateInstance(type)
                as INetFwOpenPort;

            port.Name = title;
            port.Port = portNo;
            port.Scope = NET_FW_SCOPE_.NET_FW_SCOPE_ALL;
            port.Protocol = isUDP ? NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_UDP : NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_TCP;
            port.IpVersion = NET_FW_IP_VERSION_.NET_FW_IP_VERSION_ANY;

            return port;
        }

        public bool AddPort(string title, int portNo, bool isUDP)
        {
            bool result = false;
            INetFwOpenPort port = _GetPort(title, portNo, isUDP);
            INetFwMgr manager = _GetFirewallManager();
            try
            {
                manager.LocalPolicy.CurrentProfile.GloballyOpenPorts.Add(port);
                result = true;
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }
            return result;
        }

        public bool RemovePort(int portNo, bool isUDP)
        {
            bool result = false;
            INetFwMgr manager = _GetFirewallManager();
            NET_FW_IP_PROTOCOL_ protocol = isUDP ? NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_UDP : NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_TCP;
            try
            {
                manager.LocalPolicy.CurrentProfile.GloballyOpenPorts.Remove(portNo, protocol);
                result = true;
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }
            return result;
        }

    }
}

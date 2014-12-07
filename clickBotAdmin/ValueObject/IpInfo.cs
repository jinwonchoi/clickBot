using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClickBot.ValueObject
{
    public class IpInfo
    {
        string ipAddress;
        public string IpAddress
        {
            get { return ipAddress; }
            set { ipAddress = value; }
        }
        string browserType;
        public string BrowserType
        {
            get { return browserType; }
            set { browserType = value; }
        }        
        string deviceType;
        public string DeviceType
        {
            get { return deviceType; }
            set { deviceType = value; }
        }
        string userType;
        public string UserType
        {
            get { return userType; }
            set { userType = value; }
        }
        string loginIdNaver;
        public string LoginIdNaver
        {
            get { return loginIdNaver; }
            set { loginIdNaver = value; }
        }
        string loginPwdNaver;
        public string LoginPwdNaver
        {
            get { return loginPwdNaver; }
            set { loginPwdNaver = value; }
        }
        string loginIdDaum;
        public string LoginIdDaum
        {
            get { return loginIdDaum; }
            set { loginIdDaum = value; }
        }
        string loginPwdDaum;
        public string LoginPwdDaum
        {
            get { return loginPwdDaum; }
            set { loginPwdDaum = value; }
        }
    }
}

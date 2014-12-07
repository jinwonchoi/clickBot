using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using System.Diagnostics;

namespace WeDoCommon
{
    class LicenseHandler
    {
        public const string LICENSE_FILE = "*license.ini";

        public event EventHandler<StringEventArgs> LogWriteHandler;

        public LicenseHandler(string dir)
        {
            this.dir = dir;
        }

        public LicenseHandler(FileInfo fileInfo)
        {
            dir = fileInfo.DirectoryName;
            fileName = fileInfo.Name;
        }

        string dir = @"\temp\";
        string fileName = "";

        string licenseKey;

        public string LicenseKey {
            get { return licenseKey; }
        }

        int userCnt = 0;

        public int UserCnt
        {
            get { return userCnt; }
        }

        string companyCode;

        public string CompanyCode
        {
            get { return companyCode; }
        }

        string companyName;

        public string CompanyName
        {
            get { return companyName; }
        }

        string expriationDate;

        public string ExpriationDate
        {
            get { return expriationDate; }
        }

        string macAddress;
        public string MacAddress
        {
            get { return macAddress; }
        }

        public string ResultMessage
        {
            get { return resultCode+"&"+companyName+"&"+expriationDate; }
        }

        int resultCode;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool ReadLicense()
        {
        //result = 코드&회사명&만료일자
        /* 
            ERR_NO_FILE = -3,
            ERR_INVALID_FILE = -2,
            ERR_UNREGISTERED = -1,
            ERR_EXPIRED = 0,
            SUCCESS = 1,
            WARN_30_DAYS = 2,
            WARN_7_DAYS = 3
        */

            bool result = true;
            try
            {
                this.macAddress = GetMacAddress();
                OnWriteLog(string.Format("license dir[{0}], mac address[{1}]", dir, macAddress));

                string fileName = GetFileName();
                if (fileName == null && fileName == "")
                {
                    OnWriteLog("License file name없음.");
                    resultCode = (int)LicenseResult.ERR_NO_FILE;
                    throw new Exception();
                }
                else
                {
                    OnWriteLog(string.Format("License file name[{0}]", fileName));
                }
                ReadFile(fileName);
                string decodedLicenseKey = Decode(licenseKey);
                OnWriteLog(string.Format("Decoded LicenseKey[{0}]", decodedLicenseKey.Trim('\0')));
                string[] keyItems = decodedLicenseKey.Split('_');

                if (keyItems.Length != 5)
                {
                    OnWriteLog("License file 미등록.");
                    resultCode = (int)LicenseResult.ERR_UNREGISTERED;
                    throw new Exception();
                }
                if (!companyCode.Equals(keyItems[0]))
                {
                    OnWriteLog("License file 회사코드 미등록.");
                    resultCode = (int)LicenseResult.ERR_UNREGISTERED;
                    throw new Exception();
                }
                
                if (!companyName.Equals(keyItems[1])) 
                {
                    OnWriteLog("License file 잘못된 회사명.");
                    resultCode = (int)LicenseResult.ERR_INVALID_FILE;
                    throw new Exception();
                }
                //if (!macAddress.Equals(keyItems[2])) result = false;
                if (!macAddress.Equals(keyItems[2]))
                {
                    OnWriteLog(string.Format("License file 잘못된 mac address값.실제 mac address[{0}]", macAddress));
                    resultCode = (int)LicenseResult.ERR_MAC_ADDR;
                    throw new Exception();
                }

                if (!Convert.ToString(userCnt).Equals(keyItems[3]))
                {
                    OnWriteLog("License file 잘못된 사용자값.");
                    resultCode = (int)LicenseResult.ERR_INVALID_FILE;
                    throw new Exception();
                }
                if (!expriationDate.Equals(keyItems[4].Substring(0, 8)))
                {
                    OnWriteLog("License file 잘못된 등록일자.");
                    resultCode = (int)LicenseResult.ERR_INVALID_FILE;
                    throw new Exception();
                }

                //기간 확인 30일전 7일전 성공
                try
                {
                    //만료 확인
                    int days = Utils.GetDayDiffFromNow(expriationDate);
                    if (days < 0)
                    {
                        OnWriteLog("License 만료일자 지남.");
                        resultCode = (int)LicenseResult.ERR_EXPIRED;
                        throw new Exception();
                    }
                    //7일이내 여부
                    if (days <= 7)
                    {
                        resultCode = (int)LicenseResult.WARN_7_DAYS;
                    }
                    //30일이내 여부
                    int months = Utils.GetMonthDiffFromNow(expriationDate);
                    if (months == 0)
                    {
                        resultCode = (int)LicenseResult.WARN_30_DAYS;
                    }
                    //ok
                    resultCode = (int)LicenseResult.SUCCESS;
                }
                catch (System.ArgumentOutOfRangeException e)
                {
                    OnWriteLog("License file 잘못된 등록일자.");
                    resultCode = (int)LicenseResult.ERR_INVALID_FILE;
                    throw new Exception();
                }

                if (result) OnWriteLog("라이센스 검증 성공.");
            }
            catch (Exception ex)
            {
                result = false;
                OnWriteLog("라이센스 검증 실패.");
                OnWriteLog(ex.ToString());
            }
            return result;
        }

        public bool ValidLicense()
        {
            return (resultCode == (int)LicenseResult.SUCCESS);
        }

        private void ReadFile(string fileName)
        {
            var data = new Dictionary<string, string>();
            foreach (var row in File.ReadAllLines(fileName, Encoding.Default))
                data.Add(row.Split('=')[0], string.Join("=", row.Split('=').Skip(1).ToArray()));

            foreach (var pair in data)
            {
                Console.WriteLine("{0}, {1}",
                pair.Key,
                pair.Value);

                switch (pair.Key)
                {
                    case "LicenseKey":
                        this.licenseKey = pair.Value;
                        break;
                    case "Users":
                        try
                        {
                            userCnt = Convert.ToInt32(pair.Value);
                        }
                        catch (FormatException e)
                        {
                            OnWriteLog(e.ToString());
                            OnWriteLog("Input string is not a sequence of digits.");
                        }
                        catch (OverflowException e)
                        {
                            OnWriteLog(e.ToString());
                            OnWriteLog("The number cannot fit in an Int32.");
                        }
                        break;
                    case "Company":
                        this.companyName = pair.Value;
                        break;
                    case "Code":
                        this.companyCode = pair.Value;
                        break;
                    case "ExpirationDate":
                        this.expriationDate = pair.Value;
                        break;

                }
            }

            //LicenseKey=FKFGAIAMGNPDPIJOJMIOINNLIKGLHEHJHFBNHJHMFICMHGHFHEHJHFBNADANFPFFADGLAHGMAGGLABAKFKFPAAAF
            //Users=5
            //Company=이클루스
            //Code=0088
            //ExpirationDate=20130901
        }


        private string GetMacAddress()
        {
            string macAddress = "";
            try
            {
                IPGlobalProperties computerProperties = IPGlobalProperties.GetIPGlobalProperties();
                NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
                OnWriteLog("Interface information for " +
                        computerProperties.HostName + ":" + computerProperties.DomainName);
                if (nics == null || nics.Length < 1)
                {
                    OnWriteLog("네트워크 어뎁터 검색 실패");
                    MessageBox.Show("현재 컴퓨터에서 네트워크 카드를 찾을수 없습니다.\\r\\n 서버가 종료됩니다.");
                    Process.GetCurrentProcess().Kill();
                }
                else
                {
                    OnWriteLog("  Number of interfaces : " + nics.Length);
                    foreach (NetworkInterface adapter in nics)
                    {
                        IPInterfaceProperties properties = adapter.GetIPProperties();
                        if (adapter.NetworkInterfaceType == NetworkInterfaceType.Ethernet || adapter.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 || adapter.NetworkInterfaceType == NetworkInterfaceType.GigabitEthernet)
                        {
                            OnWriteLog("Name : " + adapter.Name);
                            OnWriteLog("설명 : " + adapter.Description);
                            OnWriteLog(String.Empty.PadLeft(adapter.Description.Length, '='));
                            OnWriteLog("Interface type : " + adapter.NetworkInterfaceType);
                            OnWriteLog("Physical address : ");
                            PhysicalAddress address = adapter.GetPhysicalAddress();
                            macAddress = address.ToString();
                            OnWriteLog("MAC : " + macAddress);
                            foreach (UnicastIPAddressInformation ip in adapter.GetIPProperties().UnicastAddresses)
                            {
                                if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                                {
                                    OnWriteLog("IP address: " + ip.Address.ToString());
                                }
                            }
                            OnWriteLog("");
                            OnWriteLog("##################");
                            OnWriteLog("");
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                OnWriteLog(ex.ToString());
            }
            return macAddress;
        }

        private string GetFileName()
        {
            if (fileName != "") return dir + "\\" +fileName;

            string[] files = Directory.GetFiles(dir, LICENSE_FILE, SearchOption.TopDirectoryOnly);
            string result;
            if (files.Length == 0)
            {
                result = "";
            }
            else
            {
                result = files[0];
            }
            return result;

        }

        static string strKey = "jf04234[0945252";

        private string Decode(string src)
        {
            int l = 0, v;
            byte t, c = 0;
            string dest = "";
            byte[] bDest = new byte[2048];
            StringBuilder sb = new StringBuilder();

            //byte[] bSrc = new byte[src.Length];
            //System.Buffer.BlockCopy(src.ToCharArray(),0, bSrc, 0, bSrc.Length);
            byte[] bSrc = Encoding.ASCII.GetBytes(src);

            //byte[] bKey = new byte[strKey.Length];
            //System.Buffer.BlockCopy(strKey.ToCharArray(), 0, bKey, 0, bKey.Length);
            byte[] bKey = Encoding.ASCII.GetBytes(strKey);
            int nValid = 0;
            for (int i = 0; i < bSrc.Length; i++)
            {
                t = bSrc[i];
                if (t >= 'A' && t <= 'Q')
                    v = t - 'A';
                else
                    v = 0;
                c = (byte)(c << 4);
                c = (byte)(c | v);
                if (i % 2 == 1)
                {
                    c = (byte)(c ^ bKey[l]);
                    bDest[nValid++] = c;
                    //sb.Append((char)c);
                    c = 0;
                    l++;
                    l = l % 10;
                }
            }
            //return System.Text.Encoding.Default.GetString(bDest);
            return Encoding.Default.GetString(bDest, 0, bSrc.Length);
            //return sb.ToString();

        }


        public bool BackupLicenseFile(string targetDir)
        {
            bool result = false;

            try
            {
                if (!Directory.Exists(targetDir))
                    Directory.CreateDirectory(targetDir);

                string fileName = GetFileName();

                FileInfo fileInfo = new FileInfo(fileName);
                fileInfo.CopyTo(targetDir + fileInfo.Name);
                result = true;
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }
            return result;
        }

        public virtual void OnWriteLog(string msg)
        {
            Logger.info(msg);
            EventHandler<StringEventArgs> handler = this.LogWriteHandler;
            if (this.LogWriteHandler != null)
            {
                handler(this, new StringEventArgs(msg));
            }
        }
    }

    public enum LicenseResult
    {
        ERR_MAC_ADDR = -4,
        ERR_NO_FILE = -3,
        ERR_INVALID_FILE = -2,
        ERR_UNREGISTERED = -1,
        ERR_EXPIRED = 0,
        SUCCESS = 1,
        WARN_30_DAYS = 2,
        WARN_7_DAYS = 3
    }

    //C++ Enc/Dec 소스
    //CString Encoding(LPCTSTR src)
    //{
    //    int l=0;
    //    char tmp;
    //    BYTE t, t2;
    //    CString dest="";

    //    UINT nLen = strlen(src);

    //    for(UINT i = 0; i < nLen; i++)
    //    {
    //        t = src[i] ^ g_sKey[l];
    //        t2 = t & 0xF;
    //        t = t >> 4;
    //        tmp = 'A' + t;
    //        dest += tmp;
    //        tmp = 'A' + t2;
    //        dest += tmp;

    //        l++;
    //        l=l%10;		
    //    }
    //    return dest;
    //}


    //CString Decoding(LPCSTR src)
    //{		
    //    int l=0, v;
    //    BYTE t,	c=0;
    //    CString dest="";	

    //    for(UINT i=0; i<strlen(src); i++)
    //    {
    //        t=src[i];
    //        if(t>='A' && t<='Q')
    //            v = t-'A';
    //        else
    //            v = 0;

    //        c = c << 4;		
    //        c |= v;
    //        if(i%2==1)
    //        {
    //            c = c ^ g_sKey[l];
    //            dest += (char)c;
    //            c=0;
    //            l++;
    //            l = l%10;			
    //        }
    //    }
    //    return dest;
    //}
}

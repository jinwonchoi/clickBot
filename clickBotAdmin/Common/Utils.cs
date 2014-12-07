using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Drawing;
using WeDoCommon;

namespace ClickBot.Common
{
    public static class Utils
    {
        public static void Shuffle<T>(this IList<T> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public static DateTime GetDateTimeByYYYYMMDD(string strDate)
        {
            DateTime dt = new DateTime(Int32.Parse(strDate.Substring(0, 4)),
                Int32.Parse(strDate.Substring(4, 2)),
                Int32.Parse(strDate.Substring(6, 2)));
            return dt;
        }

        public static string LogFileName()
        {
            return DateTime.Now.ToString(ConstDef.LOG_FILE_FMT);
        }

        /// <summary>
        /// datetime형식 : yyyyMMdd
        /// </summary>
        /// <param name="timeKey">datetime형식 : yyyyMMddHHmmss</param>
        /// <returns></returns>
        public static string LogFileName(string timeKey)
        {
            if (timeKey.Length == 14)
                return timeKey.Substring(0, 8);
            else
                return "*";
        }

        public static bool IsAppInstalled(string p_machineName, string p_name)
        {
            string keyName;

            // search in: CurrentUser
            keyName = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            if (ExistsInRemoteSubKey(p_machineName, RegistryHive.CurrentUser, keyName, "DisplayName", p_name) == true)
            {
                return true;
            }

            // search in: LocalMachine_32
            keyName = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            if (ExistsInRemoteSubKey(p_machineName, RegistryHive.LocalMachine, keyName, "DisplayName", p_name) == true)
            {
                return true;
            }

            // search in: LocalMachine_64
            keyName = @"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall";
            if (ExistsInRemoteSubKey(p_machineName, RegistryHive.LocalMachine, keyName, "DisplayName", p_name) == true)
            {
                return true;
            }

            return false;
        }

        private static bool ExistsInRemoteSubKey(string p_machineName, RegistryHive p_hive, string p_subKeyName, string p_attributeName, string p_name)
        {
            RegistryKey subkey;
            string displayName;

            using (RegistryKey regHive = RegistryKey.OpenRemoteBaseKey(p_hive, p_machineName))
            {
                using (RegistryKey regKey = regHive.OpenSubKey(p_subKeyName))
                {
                    if (regKey != null)
                    {
                        foreach (string kn in regKey.GetSubKeyNames())
                        {
                            using (subkey = regKey.OpenSubKey(kn))
                            {
                                displayName = subkey.GetValue(p_attributeName) as string;
                                if (p_name.Equals(displayName, StringComparison.OrdinalIgnoreCase) == true) // key found!
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }

        public static int GetDayDiffFromNow(string yyyymmdd)
        {
            string year = yyyymmdd.Substring(0, 4);
            string month = yyyymmdd.Substring(4, 2);
            string days = yyyymmdd.Substring(6, 2);
            DateTime theDate = new DateTime(Convert.ToInt16(year),
                Convert.ToInt16(month),
                Convert.ToInt16(days));
            double daysLeft = theDate.Subtract(DateTime.Today).TotalDays;
            return (int)daysLeft;
        }

        public static int GetMonthDiffFromNow(string yyyymmdd)
        {
            DateTime theDate = new DateTime(Convert.ToInt16(yyyymmdd.Substring(0, 4)),
                Convert.ToInt16(yyyymmdd.Substring(4, 2)),
                Convert.ToInt16(yyyymmdd.Substring(6, 2)));
            return ((theDate.Year - DateTime.Now.Year) * 12) + theDate.Month - DateTime.Now.Month;
        }

        public static string GetFileName(string path)
        {
            string[] token = path.Split('\\');
            if (token.Length == 1) return path;
            return token[token.Length - 1];
        }

        public static string GetPath(string path)
        {
            if (path.LastIndexOf('\\') < 0) return path;
            return path.Substring(0, path.LastIndexOf('\\'));
        }

        public static string ShortenString(string myString, int width, Font font)
        {
            string result = string.Copy(myString);
            TextRenderer.MeasureText(result, font, new Size(width, 0), TextFormatFlags.EndEllipsis | TextFormatFlags.ModifyString);

            return result;
        }

        public static string ShortenDirString(string dirName)
        {
            string result;
            string[] filenameArray = dirName.Split('\\');
            if (filenameArray.Length > 2)
                result = filenameArray[0] + "\\..\\" + filenameArray[(filenameArray.Length - 1)];
            else result = dirName;
            return result;
        }

        public static string EncodeMsg(string msg)
        {
            StringBuilder b = new StringBuilder(msg);
            b.Replace("|", "&PIP");
            //b.Replace("_", "&UNS");
            return b.ToString();
        }

        public static string DecodeMsg(string msg)
        {
            StringBuilder b = new StringBuilder(msg);
            b.Replace("&PIP", "|");
            //b.Replace("_", "&UNS");
            return b.ToString();
        }
    }
    public class StringEventArgs : EventArgs
    {
        public string EventString { get; set; }

        public StringEventArgs(string value)
        {
            this.EventString = value;
        }
    }
}

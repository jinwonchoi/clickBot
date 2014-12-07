using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;
using System.ComponentModel;
using WeDoCommon;
using System.Globalization;
using Microsoft.Win32;

namespace WeDoCommon
{
    public class Utils
    {
        /// <summary>
        /// datetime형식 : yyyyMMddHHmmss
        /// </summary>
        /// <returns></returns>
        public static string TimeKey()
        {
            return DateTime.Now.ToString(ConstDef.TIME_KEY_FMT);
        }

        /// <summary>
        /// 시간차(초) : 나중시간(yyyyMMddHHmmss) - 시작시간(yyyyMMddHHmmss)
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public static int TimeGap(string endTime, string startTime)
        {
            DateTime start = DateTime.ParseExact(startTime, "yyyyMMddHHmmss", CultureInfo.InvariantCulture);
            DateTime end = DateTime.ParseExact(endTime, "yyyyMMddHHmmss", CultureInfo.InvariantCulture);
            return (end - start).Seconds;
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
        /* STAShowDialog takes a FileDialog and shows it on a background STA thread and returns the results.
         * Usage:
         *   OpenFileDialog d = new OpenFileDialog();
         *   DialogResult ret = STAShowDialog(d);
         *   if (ret == DialogResult.OK)
         *      MessageBox.Show(d.FileName);
         */
        public static DialogResult STAShowDialog(FileDialog dialog)
        {
            DialogState state = new DialogState();
            state.dialog = dialog;
            System.Threading.Thread t = new System.Threading.Thread(state.ThreadProcShowDialog);
            t.SetApartmentState(System.Threading.ApartmentState.STA);
            t.Start();
            t.Join();
            return state.result;
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

    public class CustomEventArgs : EventArgs
    {
        private System.Object obj;

        public CustomEventArgs() { }

        public CustomEventArgs(System.Object s)
        {
            obj = s;
        }

        public System.Object GetItem
        {
            get { return obj; }
        }
    }

    public class MsgrUserStatus
    {
        public const string BUSY = "busy";

        public const string AWAY = "away";

        public const string LOGOUT = "logout";
        public const string ONLINE = "online";
        public const string DND = "DND";//다른용무중
    }

    public class MsgColor {
        private Color MYCOLOR = SystemColors.WindowText;
        private Color USERCOLOR_1 = Color.RoyalBlue;
        private Color USERCOLOR_2 = Color.SaddleBrown;
        private Color USERCOLOR_3 = Color.DarkGreen;
        private Color USERCOLOR_4 = Color.Purple;
        private Color USERCOLOR_5 = Color.DodgerBlue;
        private Color USERCOLOR_6 = Color.Olive;
        private Color USERCOLOR_DEFAULT = SystemColors.WindowText;
        public Color GetColor(int userIndex) {
            switch (userIndex) {
                case 1:
                    return USERCOLOR_1;
                case 2:
                    return USERCOLOR_2;
                case 3:
                    return USERCOLOR_3;
                case 4:
                    return USERCOLOR_4;
                case 5:
                    return USERCOLOR_5;
                case 6:
                    return USERCOLOR_6;
                default:
                    return USERCOLOR_DEFAULT;
            }
        }

    }

    /* Helper class to hold state and return value in order to call FileDialog.ShowDialog on a background thread.
     * Usage:
     *   DialogState state = new DialogState();
     *   state.dialog = // <any class that derives from FileDialog>
     *   System.Threading.Thread t = new System.Threading.Thread(state.ThreadProcShowDialog);
     *   t.SetApartmentState(System.Threading.ApartmentState.STA);
     *   t.Start();
     *   t.Join();
     *   return state.result;
     */
    public class DialogState
    {
        public DialogResult result;
        public FileDialog dialog;


        public void ThreadProcShowDialog()
        {
            result = dialog.ShowDialog();
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

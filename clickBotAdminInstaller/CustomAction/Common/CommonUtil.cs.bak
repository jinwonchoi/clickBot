using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Windows.Forms;

namespace WeDoCommon
{
    class CommonUtil
    {
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

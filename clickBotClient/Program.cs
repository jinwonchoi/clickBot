using System;
using System.Windows.Forms;
using JinnonsCode;
using WeDoCommon;
using System.Reflection;
using System.IO;

namespace Elegant.Ui.Samples.ControlsSample
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
			Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            FrmStartBiral frmStartBiral = new FrmStartBiral(SetFlag);
            if (frmStartBiral.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new FrmStatus(Program.GetFlag().Equals("true")?true:false));
            }
        }

        static DelSetData delSetData;
        static string flag = "false";
        public static void SetFlag(string _flag)
        {
            flag = _flag;
        }

        public static string GetFlag()
        {
            return flag;
        }
    }
}
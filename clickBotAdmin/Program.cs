using System;
using System.Windows.Forms;

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
			ProcessDpiAwareSettings.IsProcessDpiAware = true;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
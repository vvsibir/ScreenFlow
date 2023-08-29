using System;
using System.Windows.Forms;

namespace ScreenFlowTest
{
    static class Program
    {
        public static string pathSettings = Application.ProductName + ".xml";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            settings.Load(pathSettings);
            Application.Run(new mainForm());
            settings.Save(pathSettings);
        }

    }
}

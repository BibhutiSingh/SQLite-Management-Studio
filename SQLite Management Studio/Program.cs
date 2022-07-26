using System;
using System.Windows.Forms;

namespace SQLite_Management_Studio
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }

        //static void connn()
        //{
        //    vals= 1427;
        //}
    }
}
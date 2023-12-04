using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Felix.Library.Common.Network;

namespace HR_Attendance_Module_Client
{
    static class Program
    {
        public static string __MySQLConnString = @"SERVER=192.168.27.61; DATABASE=lhkdb_hr; UID=root; PASSWORD=mis472560;respect binary flags=false; Compress=true; Pooling=true; Min Pool Size=0; Max Pool Size=100; Connection Lifetime=0";
        public static string __MySQLIP = "192.168.27.61";
        public static string __ExecutionMode = "Online";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            CommonNetwork COMMONNETWORK = new CommonNetwork();
            if (!COMMONNETWORK.PingTest(__MySQLIP))
            {
                __ExecutionMode = "Offline";
                MessageBox.Show("Cannot found Online Server, use Offline mode, if you believe this is in-error, please restart the application...");
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMain());
        }
    }
}
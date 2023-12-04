using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Felix.Library.Common.Network;
using Felix.Library.Common.DB;
using HR.Authentication;

namespace HR_Attendance_Module_Client
{
    public class Program
    {
        protected static string __MySQLConnString = @"SERVER=127.0.0.1; DATABASE=lhkdb_hr; UID=root; PASSWORD=outlet;respect binary flags=false; Compress=true; Pooling=true; Min Pool Size=0; Max Pool Size=100; Connection Lifetime=0";
        protected static string __MySQLIP = "127.0.0.1";
        protected static string __ExecutionMode = "Online";
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            NetworkTest();
            if (__ExecutionMode == "Online")
            {
                Application.Run(new FrmMain());
            }
            else
            {
                MessageBox.Show("Offline");
            }
        }

        private static void NetworkTest()
        {
            CommonNetwork COMMONNETWORK = new CommonNetwork();
            CommonDB TestDB = new CommonDB(__MySQLConnString);
            if (!COMMONNETWORK.PingTest(__MySQLIP) || !TestDB.TryConnection())
            {
                __ExecutionMode = "Offline";
                MessageBox.Show("Cannot found Online Server, use Offline mode, if you believe this is in-error, please restart the application...");
            }
        }
    }

    public class CoreKernel : Program
    {
        
        public static string GetMySQLConnString()
        {
            return __MySQLConnString;
        }

        public static string GetMySQLIP()
        {
            return __MySQLIP;
        }

        public static string GetExecutionMode()
        {
            return __ExecutionMode;
        }

        public static void SetExecutionMode(string Mode)
        {
            __ExecutionMode = Mode;
        }

        public static string GetDecryptedPassword(string pwd)
        {
            Authentication Auth = new Authentication();
            return Auth.ReturnUserPwd(pwd);
        }
    }
}
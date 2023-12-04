using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ClassEncryptionLib;

namespace LHK_Attandance
{
    static class Program
    {
        public static string
            AuthorName = "Felix", // Author Name
            // Create Salt Value
            global_key = "mis472560",
            // Create mySQL Value
            __mysql_url, // mySQL host
            __mysql_usr, // mySQL username
            __mysql_pwd, // mySQL password
            __PCName; // store the pc name
        private static string[]
            // Program Arguement
            args = Environment.GetCommandLineArgs();
        public static int
            // Program Arguement data, Set Offline Mode (use local ms access db, sync when administrator login)
            __mCoreConfigOfflineMode;
        public static bool
            // Program Arguement data, arguement -l = extra load
            __mArg_l = false,
            // Program Arguement data, arguement mcrypt = start crypt program
            __mCrypt = false;
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            __mCoreConfigOfflineMode = Properties.Settings.Default.mode;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Define a salt key for Protection Method
            ProtectionMethod.PasswordSalt = global_key;
            foreach (string arg in args)
            {
                switch (arg)
                {
                    case "-l":
                        __mArg_l = true;
                        break;
                    case "mcrypt":
                        if (__mArg_l)
                            __mCrypt = true;
                        break;
                }
            }
            
            // Variable Generator
            __PCName = System.Environment.MachineName; // Read the pc name

            // mcrypt module
            if (__mCrypt)
            {
                Application.Run(new frmCrypt());
            }
            else
            {

                __mysql_url = ProtectionMethod.Decrypt(Properties.Settings.Default.host);
                __mysql_usr = ProtectionMethod.Decrypt(Properties.Settings.Default.usr);
                __mysql_pwd = ProtectionMethod.Decrypt(Properties.Settings.Default.pwd);
                Application.Run(new frmMain());
            }
        }
    }
}

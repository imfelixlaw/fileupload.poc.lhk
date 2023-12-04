using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Bixolon_Printer
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
            Application.Run(new FormMain());
        }
    }

    public class myConn
    {
        public string Setting
        {
            get
            {
                return string.Format(@"SERVER={0};
                    DATABASE={1};
                    UID={2};
                    PASSWORD={3};
                    respect binary flags=false; Compress=true; Pooling=true; Min Pool Size=0; Max Pool Size=100; Connection Lifetime=0",
                        "10.8.10.8",
                        "lhkdb_init",
                        "lhkusr2",
                        "user4lhk8my");
            }
        }
    }
}

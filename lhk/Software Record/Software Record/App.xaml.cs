using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace Software_Record
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
    }

    public class dbms
    {
        public string MySetting
        {
            get
            {
                return string.Format(@"SERVER={0};
                    DATABASE={1};
                    UID={2};
                    PASSWORD={3};
                    respect binary flags=false; Compress=true; Pooling=true; Min Pool Size=0; Max Pool Size=100; Connection Lifetime=0",
                        "192.168.27.8",
                        "lhkdb_pcmanagement",
                        "root",
                        "dev01@lhk");
            }
        }
    }
}

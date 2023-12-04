using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.Diagnostics;
namespace HR_Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            using (Process thisProc = Process.GetCurrentProcess()) // Get Reference to the current Process
            {
                // Check how many total processes have the same name as the current one
                if (Process.GetProcessesByName(thisProc.ProcessName).Length > 1)
                {
                    using (WindowErrorDisplay WED = new WindowErrorDisplay("Application is already running."))
                    {   // If ther ise more than one, than it is already running.
                        WED.ShowDialog();
                        WED.Dispose();
                    }
                    Application.Current.Shutdown();
                    return;
                }
            }
            base.OnStartup(e);
        }
    }
}

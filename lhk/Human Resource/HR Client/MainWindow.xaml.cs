using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Globalization;
using System.Diagnostics;
using MySql.Data.MySqlClient;

using System.Web.Mvc.HtmlHelper;

namespace HR_Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //-- Storage Class -- Start -->
        private class storBranch
        {
            public int IDBranch { get; set; }
            public string BranchCode { get; set; }
            public string BranchName { get; set; }
        }

        private class storUser
        {
            public int IDUser { get; set; }
            public string UserAcc { get; set; }
        }

        private List<storBranch> BranchList = new List<storBranch>();
        private List<storUser> UserList = new List<storUser>();
        //-- Storage Class -- End -->

        private bool isLogin = false, isOffline = false, isDebug = false;
        private DateTime clockNow = DateTime.Now; // Setting clock to local time and refresh if database is connected
        private MySqlConnection myConn;
        private MySqlCommand myCmd;
        private MySqlDataAdapter myDa;
        private MySqlDataReader myDr;

        public MainWindow()
        {
            InitializeComponent();
            SQLConn();
            SQLite();
            StartUpInit();
            ShowClock();
            LoadingBranch();
            textBlockApplicationVersion.Text = "Version " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        private void SQLite()
        {
            try
            {
                //
            }
            catch(Exception ex)
            {
                //--> System executing error during isOffline execution
                using (WindowErrorDisplay WED = new WindowErrorDisplay(ex.Message))
                {
                    WED.ShowDialog();
                    WED.Dispose();
                }
            }
        }

        private void SQLConn()
        {
            try
            {
                string clock = string.Empty;
                //--> Create connection using setting store on app.config
                myConn = new MySqlConnection(string.Format(@"SERVER={0};
                    DATABASE={1};
                    UID={2};
                    PASSWORD={3};
                    respect binary flags=false; Compress=true; Pooling=true; Min Pool Size=0; Max Pool Size=100; Connection Lifetime=0",
                      Properties.Settings.Default.mysqlhost.ToString(),
                      Properties.Settings.Default.mysqltable.ToString(),
                      Properties.Settings.Default.mysqluser.ToString(),
                      Properties.Settings.Default.mysqlpass.ToString()));
                myConn.Open();
                //--> Fetching Server Time if Database is connected
                using (myCmd = new MySqlCommand("SELECT NOW();", myConn))
                {
                    using (myDr = myCmd.ExecuteReader())
                    {
                        if (myDr.Read())
                        {
                            clock = myDr.GetString(0); // Reading time
                        }
                    }
                }
                clockNow = Convert.ToDateTime(clock); // Refresh clockNow to use database time
            }
            catch(Exception ex)
            {
                isOffline = true; // Database Exception is found, offline is used
                if (isDebug) // Only display error when debug is on
                {
                    using (WindowErrorDisplay WED = new WindowErrorDisplay(ex.Message))
                    {
                        WED.ShowDialog();
                        WED.Dispose();
                    }
                }
            }
            finally
            {
                // nothing wrong with the connection and setting offline to off and close the connection
                isOffline = false;
                myConn.Close();
            }
        }

        private void ShowClock()
        {
            try
            {
                DispatcherTimer timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(1.0);
                timer.Start();
                timer.Tick += new EventHandler(delegate(object s, EventArgs a)
                {
                    clockNow = clockNow.AddSeconds(1);
                    textBoxServerTime.Text = "" + clockNow.ToString("T"); // Display Time
                });
            }
            catch (Exception ex)
            {
                if (isDebug) // Only display error when debug is on
                {
                    using (WindowErrorDisplay WED = new WindowErrorDisplay(ex.Message))
                    {
                        WED.ShowDialog();
                        WED.Dispose();
                    }
                }
            }
        }

        private void StartUpInit()
        {
            menuItemLogout.IsEnabled = (isLogin) ? true : false; // Setting Logoff enable
            buttonLogout.IsEnabled = false;
            buttonAuthentication.IsDefault = true;
            groupBoxAuthentication.IsEnabled = true;
            groupBoxAttendance.IsEnabled = false;
            groupBoxTask.IsEnabled = false;
            labelLoginAt.Visibility = Visibility.Hidden;
            labelOfflineMode.Visibility = (isOffline) ? Visibility.Visible : Visibility.Hidden; // Setting Offline Text
            textBoxLastLoginLocation.Clear();
            textBoxLastLoginTime.Clear();
            textBoxLoginLocation.Clear();
            textBoxUserAccName.Clear();
            passwordBoxPassword.Clear();
            checkBoxLoginOtherLocation.IsChecked = false;
            comboBoxListBranch.SelectedIndex = -1;
            comboBoxCurrentLoginLocation.SelectedIndex = -1;
            comboBoxCurrentLoginLocation.Visibility = Visibility.Hidden;
            comboBoxListUser.DataContext = null;
        }

        private void LoadingBranch()
        {
            try
            {
                if (!isOffline)
                {
                }
                else
                {
                }
            }
            catch(Exception ex)
            {
                if (isDebug) { MessageBox.Show(ex.Message); } // Only display error when debug is on
            }
        }

        private void LoadingUser(int FKIDBranch)
        {
            try
            {
                if (FKIDBranch == 0 || comboBoxListBranch.Items.Count == 0)
                {
                    throw new Exception("There is something wrong, no branch is found?"); // branch list is empty
                }
                if (!isOffline)
                {
                }
                else
                {
                }
                if (comboBoxListUser.Items.Count == 0)
                {
                    throw new Exception("There is something wrong, no user is found?");  // user list is empty
                }
            }
            catch (Exception ex)
            {
                if (isDebug) // Only display error when debug is on
                {
                    using (WindowErrorDisplay WED = new WindowErrorDisplay(ex.Message))
                    {
                        WED.ShowDialog();
                        WED.Dispose();
                    }
                }
            }
        }

        //-- Project Exit Point -- Start -->
        private void menuItemExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void buttonExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        //-- Project Exit Point -- End -->

        private void checkBoxLoginOtherLocation_Checked(object sender, RoutedEventArgs e)
        {
            labelLoginAt.Visibility = Visibility.Visible;
            comboBoxCurrentLoginLocation.Visibility = Visibility.Visible;
        }

        private void checkBoxLoginOtherLocation_Unchecked(object sender, RoutedEventArgs e)
        {
            labelLoginAt.Visibility = Visibility.Hidden;
            comboBoxCurrentLoginLocation.Visibility = Visibility.Hidden;
        }

        private void buttonAuthentication_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (passwordBoxPassword.Password.Length == 0)
                {
                    throw new Exception("Password cannot be empty");
                }
                groupBoxAuthentication.IsEnabled = false;
                groupBoxAttendance.IsEnabled = true;
                groupBoxTask.IsEnabled = true;
                buttonLogout.IsEnabled = true;
                buttonLoginAttendance.IsDefault = true;
                menuItemLogout.IsEnabled = true;
            }
            catch (Exception ex)
            {
                using (WindowErrorDisplay WED = new WindowErrorDisplay(ex.Message))
                {
                    WED.ShowDialog();
                    WED.Dispose();
                }
            }
        }

        //-- isLogging Out -- Start -->
        private void buttonLogout_Click(object sender, RoutedEventArgs e)
        {
            StartUpInit();
        }

        private void menuItemLogout_Click(object sender, RoutedEventArgs e)
        {
            StartUpInit();
        }
        //-- isLogging Out -- End -->

        private void buttonLoginAttendance_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Time is recorded...");
            groupBoxAttendance.IsEnabled = false;
            buttonLogout.IsDefault = true;
        }

        private void buttonExistingLoginTodayOnly_Click(object sender, RoutedEventArgs e)
        {
            using (WindowLoginHistory WLH = new WindowLoginHistory(1))
            {
                WLH.ShowDialog();
                WLH.Dispose();
            }
        }

        private void buttonExistingLoginThisMonth_Click(object sender, RoutedEventArgs e)
        {
            using (WindowLoginHistory WLH = new WindowLoginHistory(2))
            {
                WLH.ShowDialog();
                WLH.Dispose();
            }
        }

        private void buttonExistingLoginLastMonth_Click(object sender, RoutedEventArgs e)
        {
            using (WindowLoginHistory WLH = new WindowLoginHistory(3))
            {
                WLH.ShowDialog();
                WLH.Dispose();
            }
        }

        private void menuItemAbout_Click(object sender, RoutedEventArgs e)
        {
            using (WindowAbout WA = new WindowAbout())
            {
                WA.ShowDialog();
                WA.Dispose();
            }
        }
    }
}

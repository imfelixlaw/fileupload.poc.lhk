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
using System.Windows.Shapes;
//-- IDisposable -- Start -->
using System.ComponentModel;
//-- IDisposable -- End -->
using MySql.Data.MySqlClient;

namespace Product_Incentive_Report
{
    /// <summary>
    /// Interaction logic for WindowRenameOutletGroup.xaml
    /// </summary>
    public partial class WindowRenameOutletGroup : Window, IDisposable
    {
        private myConn m = new myConn();
        private MySqlConnection myConn; // Mysql Connection
        private MySqlCommand myCmd; // MySql Command
        private MySqlDataReader myDr; // MySql Data Reader
        
        //-- IDisposable -- Start -->
        private IntPtr handle;
        private Component component = new Component();
        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing) { component.Dispose(); }
                CloseHandle(handle);
                handle = IntPtr.Zero;
                disposed = true;
            }
        }

        [System.Runtime.InteropServices.DllImport("Kernel32")]
        private extern static Boolean CloseHandle(IntPtr handle);

        //--> Change to Object Name
        ~WindowRenameOutletGroup() { Dispose(false); }
        //-- IDisposable -- End -->

        private int iIDOutletGroup;
        public WindowRenameOutletGroup(int FKIDOutletGroup)
        {
            InitializeComponent();
            myConn = new MySqlConnection(m.Setting);
            iIDOutletGroup = FKIDOutletGroup;
            LoadOutletGroupName(iIDOutletGroup);
        }

        private void LoadOutletGroupName(int iFKIDOutletGroup)
        {
            try
            {
                myConn.Open();
                using (myCmd = new MySqlCommand(string.Format(@"SELECT `OutletGroupName`
                    FROM `lhkcommrpt`.`comm_outletgroup`
                    WHERE `IDOutletGroup` = {0}
                    AND`Active` = 'Y';", iFKIDOutletGroup), myConn))
                {
                    myCmd.CommandTimeout = 0;
                    using (myDr = myCmd.ExecuteReader())
                    {
                        if (myDr.Read()) { textBoxOldName.Text = myDr.GetString(0); }
                        else { throw new Exception("Please try again"); } // Generally no required but extra protection
                    }
                }
                myConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool SaveNewName()
        {
            try
            {
                string sNewName = textBoxNewName.Text; // New Name
                if (string.IsNullOrEmpty(sNewName)) { throw new Exception("Outlet Group Name cannot be empty"); }
                myConn.Open();
                using (myCmd = new MySqlCommand(string.Format(@"UPDATE `lhkcommrpt`.`comm_outletgroup`
                        SET `OutletGroupName` = '{0}' WHERE `IDOutletGroup` = {1};", sNewName, iIDOutletGroup), myConn))
                {
                    myCmd.CommandTimeout = 0;
                    myCmd.ExecuteNonQuery();
                }
                myConn.Close();
                return true; // success signal
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false; // fail signal
            }
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void buttonOK_Click(object sender, RoutedEventArgs e)
        {
            if (SaveNewName()) { this.Close(); } // Close if SaveNewName Complete successfully
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            try
            {
                if (myConn != null)
                {
                    myConn.Dispose();
                    myConn = null;
                }
            }
            catch { } // dismiss the error
        }
    }
}

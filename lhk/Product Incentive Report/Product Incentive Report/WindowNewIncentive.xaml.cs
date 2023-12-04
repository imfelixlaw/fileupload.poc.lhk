using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
//-- IDisposable -- Start -->
using System.ComponentModel;
//-- IDisposable -- End -->
namespace Product_Incentive_Report
{
    /// <summary>
    /// Interaction logic for WindowNewIncentive.xaml
    /// </summary>
    public partial class WindowNewIncentive : Window, IDisposable
    {
        private myConn m = new myConn();
        private MySqlConnection myConn; // Mysql Connection
        private MySqlCommand myCmd; // MySql Command

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
        ~WindowNewIncentive() { Dispose(false); }
        //-- IDisposable -- End -->

        private int iFKIDItemGroup, iFKIDOutletGroup;
        public WindowNewIncentive(int IDItemGroup, int IDOutletGroup, bool isEmptyIncentive = false)
        {
            InitializeComponent();
            iFKIDItemGroup = IDItemGroup;
            iFKIDOutletGroup = IDOutletGroup;
            if (isEmptyIncentive)
            {
                textBoxMinQty.Text = "1";
                textBoxMinQty.IsReadOnly = true;
            }
            myConn = new MySqlConnection(m.Setting);
        }
        
        //-- Only Accept Decimal -- TextBox -- Start -->
        private void textBoxMinQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key < Key.D0 || e.Key > Key.D9)
            {
                if (e.Key < Key.NumPad0 || e.Key > Key.NumPad9)
                {
                    if (e.Key != Key.Back) { e.Handled = true; }
                }
            }
        }

        private void textBoxIncentiveRate_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[.][0-9]+$|^[0-9]*[.]{0,1}[0-9]*$");
            e.Handled = !regex.IsMatch((sender as TextBox).Text.Insert((sender as TextBox).SelectionStart, e.Text));
        }
        //-- Only Accept Decimal -- TextBox -- End -->

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBoxIncentiveRate.Text)) { throw new Exception("Please enter the incentive rate"); }
                if (string.IsNullOrEmpty(textBoxMinQty.Text)) { throw new Exception("Please enter the minimal quantity to get this rate"); }
                myConn.Open();
                int iIncentiveRate = Convert.ToInt32(textBoxIncentiveRate.Text), // Incentive Rate
                    iMinQty = Convert.ToInt32(textBoxMinQty.Text); // MinQty
                using (myCmd = new MySqlCommand(string.Format(@"INSERT INTO `lhkcommrpt`.`comm_rate` (`IDCommRate`, `Rate`, `FKIDItemGroup`, `FKIDOutletGroup`, `MinQty`, `Active`) VALUES (NULL, {0}, {1}, {2}, {3}, 'Y');", iIncentiveRate, iFKIDItemGroup, iFKIDOutletGroup, iMinQty), myConn))
                {
                    myCmd.CommandTimeout = 0;
                    myCmd.ExecuteNonQuery();
                }
                myConn.Close();
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
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

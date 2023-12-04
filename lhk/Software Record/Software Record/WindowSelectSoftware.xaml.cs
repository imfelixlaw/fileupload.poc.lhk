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
using System.Data;
namespace Software_Record
{
    /// <summary>
    /// Interaction logic for WindowSelectSoftware.xaml
    /// </summary>
    public partial class WindowSelectSoftware : Window, IDisposable
    {
        private dbms mysqlconn = new dbms();
        private MySqlConnection myconn = null;
        private MySqlCommand mycmd = null;
        private MySqlDataAdapter myda = null;
        private MySqlDataReader mydr = null;

        //-- IDisposable -- Start -->
        //-- All other IDisposable code on other source code will skip the comment, please refer to here
        private IntPtr handle; // Pointer to an external unmanaged resource.
        private Component component = new Component(); // Other managed resource this class uses.
        private bool disposed = false; // Track whether Dispose has been called.

        public void Dispose()
        {
            Dispose(true);
            // This object will be cleaned up by the Dispose method.
            // Therefore, you should call GC.SupressFinalize to take this object off the finalization queue
            // and prevent finalization code for this object from executing a second time.
            GC.SuppressFinalize(this);
        }

        // Dispose(bool disposing) executes in two distinct scenarios.
        // If disposing equals true, the method has been called directly or indirectly by a user's code.
        // Managed and unmanaged resources can be disposed.
        // If disposing equals false, the method has been called by the runtime from inside the finalizer
        // and you should not reference other objects. Only unmanaged resources can be disposed.
        protected virtual void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (!this.disposed)
            {
                // If disposing equals true, dispose all managed and unmanaged resources.
                if (disposing)
                {
                    component.Dispose(); // Dispose managed resources.
                }
                // Call the appropriate methods to clean up unmanaged resources here.
                // If disposing is false, only the following code is executed.
                CloseHandle(handle);
                handle = IntPtr.Zero;
                disposed = true; // Note disposing has been done.
            }
        }

        // Use interop to call the method necessary to clean up the unmanaged resource.
        [System.Runtime.InteropServices.DllImport("Kernel32")]
        private extern static Boolean CloseHandle(IntPtr handle);

        // Use C# destructor syntax for finalization code.
        // This destructor will run only if the Dispose method does not get called.
        // It gives your base class the opportunity to finalize.
        // Do not provide destructors in types derived from this class.
        ~WindowSelectSoftware() //--> Change to Object Name
        {
            // Do not re-create Dispose clean-up code here.
            // Calling Dispose(false) is optimal in terms of readability and maintainability.
            Dispose(false);
        }
        //-- IDisposable -- End -->
        int IDPC;
        public WindowSelectSoftware(int FKIDPC)
        {
            InitializeComponent();
            IDPC = FKIDPC;
            FetchSoftware();
        }

        private void FetchSoftware()
        {
            try
            {
                using (myconn = new MySqlConnection(mysqlconn.MySetting))
                {
                    if (myconn.State == ConnectionState.Closed) { myconn.Open(); }
                    using (mycmd = new MySqlCommand(@"SELECT `IDSoftware`, `SoftwareName`, `ProductKey` FROM `list_software` WHERE `Status` = 'Y';", myconn))
                    {
                        using (myda = new MySqlDataAdapter(mycmd))
                        {
                            DataTable dt = new DataTable();
                            myda.Fill(dt);
                            listBoxSoftware.DataContext = dt;
                            listBoxSoftware.DisplayMemberPath = "SoftwareName";
                            if (listBoxSoftware.Items.Count > 0 && listBoxSoftware.SelectedIndex == -1)
                            {
                                listBoxSoftware.SelectedIndex = 0; // Selecting 1st data
                            }
                        }
                    }
                    if (myconn.State == ConnectionState.Open) { myconn.Close(); }
                }
            }
            catch { }
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void listBoxSoftware_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (listBoxSoftware.SelectedIndex != -1)
                {
                    DataRowView selectedSoftware = listBoxSoftware.SelectedItem as DataRowView;
                    if (selectedSoftware["ProductKey"].ToString() == "Y")
                    {
                        checkBoxWithOutProductKey.IsChecked = false;
                        checkBoxWithOutProductKey.IsEnabled = true;
                        listBoxProductKey.IsEnabled = true;
                        FetchProductKey(Convert.ToInt32(selectedSoftware["IDSoftware"]));
                    }
                    else
                    {
                        checkBoxWithOutProductKey.IsChecked = true;
                        checkBoxWithOutProductKey.IsEnabled = false;
                        listBoxProductKey.DataContext = null;
                        listBoxProductKey.IsEnabled = false;
                    }
                }
            }
            catch { }
        }

        private void FetchProductKey(int FKIDSoftware)
        {
            try
            {
                using (myconn = new MySqlConnection(mysqlconn.MySetting))
                {
                    if (myconn.State == ConnectionState.Closed) { myconn.Open(); }
                    using (mycmd = new MySqlCommand(string.Format(@"SELECT p.`IDProductKey`, p.`ProductKey`, (SELECT COUNT(pc.`IDPCSoftware`)
	                    FROM `pc_software` AS pc
	                    WHERE pc.`FKIDSoftware` = p.`FKIDSoftware`
	                    AND pc.`FKIDProductKey` = p.`IDProductKey`
	                    AND pc.`Status` = 'Y') AS `Qty`
                    FROM `list_productkey` AS p
                    WHERE p.`FKIDSoftware` = {0}
                    AND p.`IDProductKey` NOT IN (SELECT ps.`FKIDProductKey`
	                    FROM `pc_software` AS ps
	                    WHERE ps.`FKIDPC` = {1}
                        AND ps.`Status` = 'Y')
                    AND p.`Status` = 'Y'
                    GROUP BY p.`IDProductKey`, p.`ProductKey`, `Qty`;", FKIDSoftware, IDPC), myconn))
                    {
                        using (myda = new MySqlDataAdapter(mycmd))
                        {
                            DataTable dt = new DataTable();
                            myda.Fill(dt);
                            listBoxProductKey.DataContext = dt;
                            listBoxProductKey.DisplayMemberPath = "ProductKey";
                        }
                    }
                    if (myconn.State == ConnectionState.Open) { myconn.Close(); }
                }
                if (listBoxProductKey.Items.Count == 0)
                {
                    listBoxProductKey.IsEnabled = false;
                    checkBoxWithOutProductKey.IsChecked = true;
                    checkBoxWithOutProductKey.IsEnabled = false;
                    MessageBox.Show("No Product Key is Available.");
                }
                else
                {
                    listBoxProductKey.IsEnabled = true;
                    checkBoxWithOutProductKey.IsChecked = false;
                    checkBoxWithOutProductKey.IsEnabled = true;
                }
            }
            catch { }
        }

        private void listBoxProductKey_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataRowView selectedProductKey = listBoxProductKey.SelectedItem as DataRowView;
                int usedCount = Convert.ToInt32(selectedProductKey["Qty"]);
                if (usedCount > 0)
                {
                    MessageBox.Show(string.Format(@"This Product Key had used {0} time(s) before.", usedCount));
                    textBlockProductKeyIsUsed.Visibility = Visibility.Visible;
                }
                else
                {
                    textBlockProductKeyIsUsed.Visibility = Visibility.Hidden;
                }
            }
            catch { }
        }

        private void buttonSelect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (listBoxSoftware.SelectedIndex != -1 && (listBoxProductKey.SelectedIndex != -1 || checkBoxWithOutProductKey.IsChecked == true))
                {
                    DataRowView selectedSoftware = listBoxSoftware.SelectedItem as DataRowView;
                    int FKIDSoftware = Convert.ToInt32(selectedSoftware["IDSoftware"]);
                    int FKIDProductKey = 0;
                    if (checkBoxWithOutProductKey.IsChecked == false)
                    {
                        DataRowView selectedProductKey = listBoxProductKey.SelectedItem as DataRowView;
                        FKIDProductKey = Convert.ToInt32(selectedProductKey["IDProductKey"]);
                    }
                    int IDPCSoftware = 0;
                    using (myconn = new MySqlConnection(mysqlconn.MySetting))
                    {
                        if (myconn.State == ConnectionState.Closed) { myconn.Open(); }
                        using (mycmd = new MySqlCommand(string.Format(@"SELECT `IDPCSoftware`
                            FROM `pc_software`
                            WHERE `FKIDPC` = {0}
                            AND `FKIDSoftware` = {1}
                            AND `FKIDProductKey` = {2};", IDPC, FKIDSoftware, FKIDProductKey), myconn))
                        {
                            using (mydr = mycmd.ExecuteReader())
                            {
                                while (mydr.Read())
                                {
                                    IDPCSoftware = mydr.GetInt32(0);
                                }
                            }
                        }

                        if (IDPCSoftware == 0) // insert
                        {
                            using (mycmd = new MySqlCommand(string.Format(@"INSERT INTO `pc_software` (`IDPCSoftware`, `FKIDPC`, `FKIDSoftware`, `FKIDProductKey`, `Status`)
                                VALUES (NULL, {0}, {1}, {2}, 'Y');", IDPC, FKIDSoftware, FKIDProductKey), myconn))
                            {
                                mycmd.ExecuteNonQuery();
                            }
                        }
                        else // update
                        {
                            using (mycmd = new MySqlCommand(string.Format(@"UPDATE `pc_software` SET `Status` = 'Y' WHERE `IDPCSoftware` = {0};", IDPCSoftware), myconn))
                            {
                                mycmd.ExecuteNonQuery();
                            }
                        }
                        if (myconn.State == ConnectionState.Open) { myconn.Close(); }
                    }
                    MessageBox.Show("OK");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Please select software and/or product key properly");
                }
            }
            catch { }
        }

        private void checkBoxWithOutProductKey_Checked(object sender, RoutedEventArgs e)
        {
            listBoxProductKey.IsEnabled = false;
        }

        private void checkBoxWithOutProductKey_Unchecked(object sender, RoutedEventArgs e)
        {
            listBoxProductKey.IsEnabled = true;
        }
    }
}

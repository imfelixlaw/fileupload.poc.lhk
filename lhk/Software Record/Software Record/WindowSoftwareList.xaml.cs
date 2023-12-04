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
    /// Interaction logic for WindowSoftwareList.xaml
    /// </summary>
    public partial class WindowSoftwareList : Window, IDisposable
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
        ~WindowSoftwareList() //--> Change to Object Name
        {
            // Do not re-create Dispose clean-up code here.
            // Calling Dispose(false) is optimal in terms of readability and maintainability.
            Dispose(false);
        }
        //-- IDisposable -- End -->
        int IDPC;
        public WindowSoftwareList(int FKIDPC, string DisplayName)
        {
            InitializeComponent();

            /*
             */
            textBoxDisplayName.Text = DisplayName;
            IDPC = FKIDPC;
            FetchSoftwareList(IDPC);
        }


        private void FetchSoftwareList(int FKIDPC)
        {
            textBoxProductKey.Clear();
            listBoxSoftwareList.DataContext = null;
            using (myconn = new MySqlConnection(mysqlconn.MySetting))
            {
                if (myconn.State == ConnectionState.Closed) { myconn.Open(); }
                using (mycmd = new MySqlCommand(string.Format(@"SELECT ps.`IDPCSoftware`, s.`SoftwareName`, p.`ProductKey`
                    FROM `pc_software` AS ps
                    INNER JOIN `list_software` AS s ON s.`IDSoftware` = ps.`FKIDSoftware`
                    LEFT JOIN `list_productkey` AS p ON p.`IDProductKey` = ps.`FKIDProductKey`
                    WHERE ps.`FKIDPC` = {0}
                    AND ps.`Status` = 'Y';", FKIDPC), myconn))
                {
                    using (myda = new MySqlDataAdapter(mycmd))
                    {
                        DataTable dt = new DataTable();
                        myda.Fill(dt);
                        listBoxSoftwareList.DataContext = dt;
                        listBoxSoftwareList.DisplayMemberPath = "SoftwareName";
                        if (listBoxSoftwareList.Items.Count > 0 && listBoxSoftwareList.SelectedIndex == -1)
                        {
                            listBoxSoftwareList.SelectedIndex = 0; // Selecting 1st data
                        }
                    }
                }
                if (myconn.State == ConnectionState.Open) { myconn.Close(); }
            }
        }

        private void buttonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void listBoxSoftwareList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataRowView selectedSoftware = listBoxSoftwareList.SelectedItem as DataRowView;
                string ProductKey = (string.IsNullOrEmpty(selectedSoftware["ProductKey"].ToString())) ? "" : selectedSoftware["ProductKey"].ToString();
                textBoxProductKey.Text = ProductKey;
            }
            catch { }
        }

        private void buttonCopy_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxProductKey.Text.Length > 0)
            {
                Clipboard.SetDataObject(textBoxProductKey.Text, true);
                MessageBox.Show("Product Key has copy to clipboard");
            }
        }

        private void buttonRemove_Click(object sender, RoutedEventArgs e)
        {
            using (myconn = new MySqlConnection(mysqlconn.MySetting))
            {
                if (myconn.State == ConnectionState.Closed) { myconn.Open(); }
                DataRowView selectedSoftware = listBoxSoftwareList.SelectedItem as DataRowView;
                string ProductKey = (string.IsNullOrEmpty(selectedSoftware["ProductKey"].ToString())) ? "" : selectedSoftware["ProductKey"].ToString();

                int FKIDPCSoftware = Convert.ToInt32(selectedSoftware["IDPCSoftware"]);
                using (mycmd = new MySqlCommand(string.Format(@"UPDATE `pc_software`
                    SET `Status` = 'N'
                    WHERE `IDPCSoftware` = {0};", FKIDPCSoftware), myconn))
                {
                    mycmd.ExecuteNonQuery();
                }
                if (myconn.State == ConnectionState.Open) { myconn.Close(); }
            }
            FetchSoftwareList(IDPC);
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            using (WindowSelectSoftware wSS = new WindowSelectSoftware(IDPC))
            {
                wSS.Owner = this;
                wSS.ShowDialog();
            }
            FetchSoftwareList(IDPC);
        }
    }
}

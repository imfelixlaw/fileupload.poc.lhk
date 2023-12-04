using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for WindowSettingOutlet.xaml
    /// </summary>
    public partial class WindowSettingOutlet : Window, IDisposable
    {
        private myConn m = new myConn();
        private MySqlConnection myConn; // Mysql Connection
        private MySqlCommand myCmd; // MySql Command
        private MySqlDataAdapter myDa; // MySql Data Adapter

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
        ~WindowSettingOutlet() { Dispose(false); }
        //-- IDisposable -- End -->

        public WindowSettingOutlet()
        {
            InitializeComponent();
            myConn = new MySqlConnection(m.Setting);
            LoadingOutletGroup();
        }

        private void buttonOK_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void LoadingOutletInUsed(int iFKIDOutletGroup)
        {
            try
            {
                myConn.Open();
                using (myCmd = new MySqlCommand(string.Format(@"SELECT u.`IDBranch`, u.`BranchCode`
                    FROM `lhkdb_init`.`usr_branch` AS u
                    WHERE u.`Active` = 'Y'
                    AND u.`IDBranch` IN (SELECT o.`FKIDBranch` FROM `lhkcommrpt`.`comm_outlet` AS o WHERE o.`Active` = 'Y' AND o.`FKIDOutletGroup` = {0})
                    ORDER BY u.`BranchCode` ASC;", iFKIDOutletGroup), myConn))
                {
                    myCmd.CommandTimeout = 0;
                    using (myDa = new MySqlDataAdapter(myCmd))
                    {
                        DataTable dt = new DataTable();
                        myDa.Fill(dt);
                        listBoxAllOutletInGroup.DataContext = dt;
                        listBoxAllOutletInGroup.DisplayMemberPath = "BranchCode";
                    }
                }
                myConn.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void LoadingOutletNotInUsedGroup()
        {
            try
            {
                myConn.Open();
                using (myCmd = new MySqlCommand(@"SELECT u.`IDBranch`, u.`BranchCode`
                    FROM `lhkdb_init`.`usr_branch` AS u
                    WHERE u.`Active` = 'Y'
                    AND u.`IDBranch` NOT IN (SELECT o.`FKIDBranch` FROM `lhkcommrpt`.`comm_outlet` AS o WHERE o.`Active` = 'Y')
                    ORDER BY u.`BranchCode` ASC;", myConn))
                {
                    myCmd.CommandTimeout = 0;
                    using (myDa = new MySqlDataAdapter(myCmd))
                    {
                        DataTable dt = new DataTable();
                        myDa.Fill(dt);
                        listBoxAllOutletNotInGroup.DataContext = dt;
                        listBoxAllOutletNotInGroup.DisplayMemberPath = "BranchCode";
                    }
                }
                myConn.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void LoadingOutletGroup()
        {
            try
            {
                listBoxAllOutletInGroup.DataContext = null;
                listBoxAllOutletNotInGroup.DataContext = null;
                listBoxGroupOutlet.DataContext = null;
                myConn.Open();
                using (myCmd = new MySqlCommand(@"SELECT `IDOutletGroup`, `OutletGroupName` FROM `lhkcommrpt`.`comm_outletgroup`
                        WHERE `Active` = 'Y' ORDER BY `IDOutletGroup` ASC;", myConn))
                {
                    myCmd.CommandTimeout = 0;
                    using (myDa = new MySqlDataAdapter(myCmd))
                    {
                        DataTable dt = new DataTable();
                        myDa.Fill(dt);
                        listBoxGroupOutlet.DataContext = dt;
                        listBoxGroupOutlet.DisplayMemberPath = "OutletGroupName";
                    }
                }
                myConn.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void listBoxGroupOutlet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView selectedGroupOutlet = listBoxGroupOutlet.SelectedItem as DataRowView;
            if (selectedGroupOutlet != null)
            {
                textBlockGroupName.Text = selectedGroupOutlet["OutletGroupName"].ToString();
                int iIDOutletGroup = Convert.ToInt32(selectedGroupOutlet["IDOutletGroup"]);
                LoadingOutletNotInUsedGroup();
                LoadingOutletInUsed(iIDOutletGroup);
            }
        }

        private void buttonAddToGroup_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (listBoxGroupOutlet.SelectedIndex == -1) { throw new Exception("Please select one outlet group from the list at left side of this windows."); } // if not selection make
                if (listBoxAllOutletNotInGroup.SelectedIndex == -1) { throw new Exception("Please select one outlet to add from the list at left side of this button."); } // if not selection make
                DataRowView selectedOutlet = listBoxAllOutletNotInGroup.SelectedItem as DataRowView;
                DataRowView selectedOutletGroup = listBoxGroupOutlet.SelectedItem as DataRowView;
                int iListNotInGroupIndex = listBoxAllOutletNotInGroup.SelectedIndex,
                    iListInGroupIndex = listBoxAllOutletInGroup.SelectedIndex,
                    iIDBranch = Convert.ToInt32(selectedOutlet["IDBranch"]),
                    iIDOutletGroup = Convert.ToInt32(selectedOutletGroup["IDOutletGroup"]);
                myConn.Open();
                using (myCmd = new MySqlCommand(string.Format(@"REPLACE INTO `lhkcommrpt`.`comm_outlet` (`FKIDBranch`, `FKIDOutletGroup`, `Active`) VALUES ({0}, {1}, 'Y')", iIDBranch, iIDOutletGroup), myConn))
                {
                    myCmd.CommandTimeout = 0;
                    myCmd.ExecuteNonQuery();
                }
                myConn.Close();
                LoadingOutletInUsed(iIDOutletGroup);
                LoadingOutletNotInUsedGroup();
                listBoxAllOutletNotInGroup.SelectedIndex = iListNotInGroupIndex;
                listBoxAllOutletInGroup.SelectedIndex = iListInGroupIndex;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void buttonRemoveFromGroup_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (listBoxGroupOutlet.SelectedIndex == -1) { throw new Exception("Please select one outlet group from the list at left side of this windows."); } // if not selection make
                if (listBoxAllOutletInGroup.SelectedIndex == -1) { throw new Exception("Please select one outlet to remove from the list at left side of this button."); } // if not selection make
                DataRowView selectedOutlet = listBoxAllOutletInGroup.SelectedItem as DataRowView;
                DataRowView selectedOutletGroup = listBoxGroupOutlet.SelectedItem as DataRowView;
                int iListNotInGroupIndex = listBoxAllOutletNotInGroup.SelectedIndex,
                    iListInGroupIndex = listBoxAllOutletInGroup.SelectedIndex,
                    iIDBranch = Convert.ToInt32(selectedOutlet["IDBranch"]),
                    iIDOutletGroup = Convert.ToInt32(selectedOutletGroup["IDOutletGroup"]);
                myConn.Open();
                using (myCmd = new MySqlCommand(string.Format(@"REPLACE INTO `lhkcommrpt`.`comm_outlet` (`FKIDBranch`, `FKIDOutletGroup`, `Active`)
                    VALUES ({0}, {1},  'N');", iIDBranch, iIDOutletGroup), myConn))
                {
                    myCmd.CommandTimeout = 0;
                    myCmd.ExecuteNonQuery();
                }
                myConn.Close();
                LoadingOutletInUsed(iIDOutletGroup);
                LoadingOutletNotInUsedGroup();
                listBoxAllOutletNotInGroup.SelectedIndex = iListNotInGroupIndex;
                listBoxAllOutletInGroup.SelectedIndex = iListInGroupIndex;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void buttonRename_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (listBoxGroupOutlet.SelectedIndex == -1) { throw new Exception("Please select one outlet group to rename from the list above this button."); } // if not selection make
                DataRowView selectedOutletGroup = listBoxGroupOutlet.SelectedItem as DataRowView;
                int iIDOutletGroup = Convert.ToInt32(selectedOutletGroup["IDOutletGroup"]);
                using (WindowRenameOutletGroup wROG = new WindowRenameOutletGroup(iIDOutletGroup))
                {
                    wROG.Owner = this;
                    wROG.ShowDialog();
                    wROG.Dispose();
                }
                LoadingOutletGroup();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonNewGroup_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show("This will create new outlet group, are you sure to proceed?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    myConn.Open();
                    using (myCmd = new MySqlCommand(@"INSERT INTO `lhkcommrpt`.`comm_outletgroup` (`IDOutletGroup`, `OutletGroupName`, `Active`) VALUES (NULL, 'New Group', 'Y');", myConn))
                    {
                        myCmd.CommandTimeout = 0;
                        myCmd.ExecuteNonQuery();
                    }
                    myConn.Close();
                    LoadingOutletGroup();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void buttonDeleteGroup_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (listBoxGroupOutlet.SelectedIndex == -1) { throw new Exception("Please select one outlet group to delete from the list above this button."); } // if not selection make
                if (listBoxAllOutletInGroup.Items.Count > 0) { throw new Exception("This outlet group still contain outlet, to remove this outlet group, you must remove all outlet from this outlet group."); }
                if (MessageBox.Show("This will remove the selected outlet group, are you sure to proceed?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    myConn.Open();
                    DataRowView selectedOutletGroup = listBoxGroupOutlet.SelectedItem as DataRowView;
                    int iIDOutletGroup = Convert.ToInt32(selectedOutletGroup["IDOutletGroup"]);
                    using (myCmd = new MySqlCommand(string.Format(@"UPDATE `lhkcommrpt`.`comm_itemgroup` SET `Active` = 'N' WHERE `IDItemGroup` = {0};", iIDOutletGroup), myConn))
                    {
                        myCmd.CommandTimeout = 0;
                        myCmd.ExecuteNonQuery();
                    }
                    myConn.Close();
                    LoadingOutletGroup();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void WindowOutletSetting_Closed(object sender, EventArgs e)
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

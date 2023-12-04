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
using MySql.Data.MySqlClient;
//-- IDisposable -- Start -->
using System.ComponentModel;
//-- IDisposable -- End -->

namespace Product_Incentive_Report
{
    /// <summary>
    /// Interaction logic for WindowSettingProduct.xaml
    /// </summary>
    public partial class WindowSettingProduct : Window, IDisposable
    {
        private myConn m = new myConn();
        private MySqlConnection myConn; // Mysql Connection
        private MySqlCommand myCmd; // MySql Command
        private MySqlDataAdapter myDa; // MySql Data Adapter
        //private MySqlDataReader myDr; // MySql Data Reader

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
        ~WindowSettingProduct() { Dispose(false); }
        //-- IDisposable -- End -->

        public WindowSettingProduct()
        {
            InitializeComponent();
            myConn = new MySqlConnection(m.Setting);
            LoadingProductGroup();
        }

        private void LoadingProductGroup()
        {
            try
            {
                listBoxProductGroup.DataContext = null;
                listBoxProductNotInGroup.DataContext = null;
                listBoxProductInGroup.DataContext = null;
                myConn.Open();
                using (myCmd = new MySqlCommand(@"SELECT `IDItemGroup`, `ItemGroupName` FROM `lhkcommrpt`.`comm_itemgroup` WHERE `Active` = 'Y' ORDER BY `IDItemGroup` ASC;", myConn))
                {
                    myCmd.CommandTimeout = 0;
                    using (myDa = new MySqlDataAdapter(myCmd))
                    {
                        DataTable dt = new DataTable();
                        myDa.Fill(dt);
                        listBoxProductGroup.DataContext = dt;
                        listBoxProductGroup.DisplayMemberPath = "ItemGroupName";
                    }
                }
                myConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadingProductInUsed(int iFKIDProductGroup)
        {
            try
            {
                myConn.Open();
                using (myCmd = new MySqlCommand(string.Format(@"SELECT m.`IDMasterItem`, m.`ItemName` FROM `lhkdb_init`.`master_item` AS m
                    WHERE m.`Active` = 'Y' AND m.`Display` = 'Y'
                    AND m.`IDMasterItem` IN (SELECT i.`FKIDMasterItem` FROM `lhkcommrpt`.`comm_item` AS i WHERE i.`Active` = 'Y' AND i.`FKIDItemGroup` = {0})
                    ORDER BY m.`ItemName` ASC;", iFKIDProductGroup), myConn))
                {
                    myCmd.CommandTimeout = 0;
                    using (myDa = new MySqlDataAdapter(myCmd))
                    {
                        DataTable dt = new DataTable();
                        myDa.Fill(dt);
                        listBoxProductInGroup.DataContext = dt;
                        listBoxProductInGroup.DisplayMemberPath = "ItemName";
                    }
                }
                myConn.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void LoadingProductNotInUsedGroup()
        {
            try
            {
                myConn.Open();
                using (myCmd = new MySqlCommand(@"SELECT m.`IDMasterItem`, m.`ItemName` FROM `lhkdb_init`.`master_item` AS m
                    WHERE m.`Active` = 'Y' AND m.`Display` = 'Y'
                    AND m.`IDMasterItem` NOT IN (SELECT i.`FKIDMasterItem` FROM `lhkcommrpt`.`comm_item` AS i WHERE i.`Active` = 'Y' AND i.`FKIDItemGroup` = 1)
                    ORDER BY m.`ItemName` ASC;", myConn))
                {
                    myCmd.CommandTimeout = 0;
                    using (myDa = new MySqlDataAdapter(myCmd))
                    {
                        DataTable dt = new DataTable();
                        myDa.Fill(dt);
                        listBoxProductNotInGroup.DataContext = dt;
                        listBoxProductNotInGroup.DisplayMemberPath = "ItemName";
                    }
                }
                myConn.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void buttonOK_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void listBoxProductGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataRowView selectedGroupProduct = listBoxProductGroup.SelectedItem as DataRowView;
                if (selectedGroupProduct != null)
                {
                    string sItemGroupName = selectedGroupProduct["ItemGroupName"].ToString();
                    int iIDItemGroup = Convert.ToInt32(selectedGroupProduct["IDItemGroup"]);
                    textBlockGroupName.Text = sItemGroupName;
                    LoadingProductNotInUsedGroup();
                    LoadingProductInUsed(iIDItemGroup);
                }
                LoadingProductNotInUsedGroup();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void buttonAddToGroup_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (listBoxProductGroup.SelectedIndex == -1) { throw new Exception("Please select one product group from the list at left side of this windows."); } // if not selection make
                if (listBoxProductNotInGroup.SelectedIndex == -1) { throw new Exception("Please select one product to add from the list at left side of this button."); } // if not selection make
                DataRowView selectedProduct = listBoxProductNotInGroup.SelectedItem as DataRowView;
                DataRowView selectedProductGroup = listBoxProductGroup.SelectedItem as DataRowView;
                int iListNotInGroupIndex = listBoxProductNotInGroup.SelectedIndex,
                    iListInGroupIndex = listBoxProductInGroup.SelectedIndex,
                    iIDMasterItem = Convert.ToInt32(selectedProduct["IDMasterItem"]),
                    iIDItemGroup = Convert.ToInt32(selectedProductGroup["IDItemGroup"]);
                myConn.Open(); 
                using (myCmd = new MySqlCommand(string.Format(@"REPLACE INTO `lhkcommrpt`.`comm_item` (`FKIDMasterItem`, `FKIDItemGroup`, `Active`) VALUES ({0}, {1}, 'Y');", iIDMasterItem, iIDItemGroup), myConn))
                {
                    myCmd.CommandTimeout = 0;
                    myCmd.ExecuteNonQuery();
                }
                myConn.Close();
                LoadingProductNotInUsedGroup();
                LoadingProductInUsed(iIDItemGroup);
                listBoxProductNotInGroup.SelectedIndex = iListNotInGroupIndex;
                listBoxProductInGroup.SelectedIndex = iListInGroupIndex;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void buttonRemoveFromGroup_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (listBoxProductGroup.SelectedIndex == -1) { throw new Exception("Please select one product group from the list at left side of this windows."); } // if not selection make
                if (listBoxProductInGroup.SelectedIndex == -1) { throw new Exception("Please select one product to add from the list at left side of this button."); } // if not selection make
                DataRowView selectedProduct = listBoxProductInGroup.SelectedItem as DataRowView;
                DataRowView selectedProductGroup = listBoxProductGroup.SelectedItem as DataRowView;
                int iListNotInGroupIndex = listBoxProductNotInGroup.SelectedIndex,
                    iListInGroupIndex = listBoxProductInGroup.SelectedIndex,
                    iIDMasterItem = Convert.ToInt32(selectedProduct["IDMasterItem"]),
                    iIDItemGroup = Convert.ToInt32(selectedProductGroup["IDItemGroup"]);
                myConn.Open();
                using (myCmd = new MySqlCommand(string.Format(@"REPLACE INTO `lhkcommrpt`.`comm_item` (`FKIDMasterItem`, `FKIDItemGroup`, `Active`) VALUES ({0}, {1}, 'N');", iIDMasterItem, iIDItemGroup), myConn))
                {
                    myCmd.CommandTimeout = 0;
                    myCmd.ExecuteNonQuery();
                }
                myConn.Close();
                LoadingProductNotInUsedGroup();
                LoadingProductInUsed(iIDItemGroup);
                listBoxProductNotInGroup.SelectedIndex = iListNotInGroupIndex;
                listBoxProductInGroup.SelectedIndex = iListInGroupIndex;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void buttonNewGroup_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show("This will create new product group, are you sure to proceed?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    myConn.Open();
                    using (myCmd = new MySqlCommand(@"INSERT INTO `lhkcommrpt`.`comm_itemgroup` (`IDItemGroup`, `ItemGroupName`, `Active`) VALUES (NULL, 'New Product Group', 'Y');", myConn))
                    {
                        myCmd.CommandTimeout = 0;
                        myCmd.ExecuteNonQuery();
                    }
                    myConn.Close();
                    LoadingProductGroup();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void buttonDeleteGroup_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (listBoxProductGroup.SelectedIndex == -1) { throw new Exception("Please select one product group to delete from the list above this button."); }  // if not selection make
                if (listBoxProductInGroup.Items.Count > 0) { throw new Exception("This product group still contain product, to remove this product group, you must remove all product from this product group."); }
                if (MessageBox.Show("This will remove the selected outlet group, are you sure to proceed?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    DataRowView selectedProductGroup = listBoxProductGroup.SelectedItem as DataRowView;
                    int iIDItemGroup = Convert.ToInt32(selectedProductGroup["IDItemGroup"]);
                    myConn.Open();
                    using (myCmd = new MySqlCommand(string.Format(@"UPDATE `lhkcommrpt`.`comm_itemgroup` SET `Active` = 'N' WHERE `IDItemGroup` = {0};", iIDItemGroup), myConn))
                    {
                        myCmd.CommandTimeout = 0;
                        myCmd.ExecuteNonQuery();
                    }
                    myConn.Close();
                    LoadingProductGroup();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void buttonRename_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (listBoxProductGroup.SelectedIndex == -1) { throw new Exception("Please select one outlet group to rename from the list above this button."); }  // if not selection make
                DataRowView selectedOutletGroup = listBoxProductGroup.SelectedItem as DataRowView;
                int iIDItemGroup = Convert.ToInt32(selectedOutletGroup["IDItemGroup"]);
                using (WindowRenameProductGroup wRPG = new WindowRenameProductGroup(iIDItemGroup))
                {
                    wRPG.Owner = this;
                    wRPG.ShowDialog();
                    wRPG.Dispose();
                }
                LoadingProductGroup();
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

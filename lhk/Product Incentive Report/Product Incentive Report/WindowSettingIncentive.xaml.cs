using System;
using System.Collections.Generic;
using System.Data;
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
//-- IDisposable -- Start -->
using System.ComponentModel;
//-- IDisposable -- End -->
using MySql.Data.MySqlClient;

namespace Product_Incentive_Report
{
    /// <summary>
    /// Interaction logic for WindowSettingIncentive.xaml
    /// </summary>
    public partial class WindowSettingIncentive : Window, IDisposable
    {
        private bool bOutletSelected, bProductSelected;
        private myConn m = new myConn();
        private MySqlConnection myConn; // Mysql Connection
        private MySqlCommand myCmd; // MySql Command
        private MySqlDataAdapter myDa; // MySql Data Adapter
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
        ~WindowSettingIncentive() { Dispose(false); }
        //-- IDisposable -- End -->

        public WindowSettingIncentive()
        {
            InitializeComponent();
            myConn = new MySqlConnection(m.Setting);
            LoadingProductGroup();
            LoadingOutletGroup();
            checkSelection();
        }

        private void LoadingProductGroup()
        {
            try
            {
                myConn.Open();
                using (myCmd = new MySqlCommand(@"SELECT `IDItemGroup`, `ItemGroupName` FROM `lhkcommrpt`.`comm_itemgroup`
                    WHERE `Active` = 'Y' ORDER BY `IDItemGroup` ASC;", myConn))
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

        private void LoadingOutletGroup()
        {
            try
            {
                myConn.Open();
                using (myCmd = new MySqlCommand(@"SELECT `IDOutletGroup`, `OutletGroupName` FROM `lhkcommrpt`.`comm_outletgroup`
                        WHERE `Active` = 'Y' ORDER BY `IDOutletGroup` ASC;", myConn))
                {
                    myCmd.CommandTimeout = 0;
                    using (myDa = new MySqlDataAdapter(myCmd))
                    {
                        DataTable dt = new DataTable();
                        myDa.Fill(dt);
                        listBoxOutletGroup.DataContext = dt;
                        listBoxOutletGroup.DisplayMemberPath = "OutletGroupName";
                    }
                }
                myConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadingIncentiveGroup(int iIDItemGroup, int iIDOutletGroup)
        {
            try
            {
                buttonRemove.IsEnabled = false;
                myConn.Open();
                using (myCmd = new MySqlCommand(string.Format(@"SELECT `IDCommRate`, FORMAT(`Rate`, 2) AS `Rate`, `MinQty`
                    FROM `lhkcommrpt`.`comm_rate`
                    WHERE `FKIDItemGroup` = {0} AND `FKIDOutletGroup` = {1} AND `Active` = 'Y'
                    ORDER BY `MinQty` ASC;", iIDItemGroup, iIDOutletGroup), myConn))
                {
                    myCmd.CommandTimeout = 0;
                    using (myDa = new MySqlDataAdapter(myCmd))
                    {
                        DataTable dt = new DataTable();
                        myDa.Fill(dt);
                        listBoxIncentiveRate.DataContext = dt;
                        listBoxIncentiveRate.DisplayMemberPath = "Rate";
                    }
                }
                if (listBoxIncentiveRate.Items.Count > 0) { buttonRemove.IsEnabled = true; } // if list item > 0 only exist the function of remove item
                myConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listBoxProductGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBoxProductGroup.SelectedIndex != -1)
            {
                DataRowView selectedGroupProduct = listBoxProductGroup.SelectedItem as DataRowView;
                textBoxProductGroup.Text = selectedGroupProduct["ItemGroupName"].ToString();
                bProductSelected = true;
                checkSelection();
            }
        }

        private void listBoxOutletGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBoxOutletGroup.SelectedIndex != -1)
            {
                DataRowView selectedGroupOutlet = listBoxOutletGroup.SelectedItem as DataRowView;
                textBoxOutletGroup.Text = selectedGroupOutlet["OutletGroupName"].ToString();
                bOutletSelected = true;
                checkSelection();
            }
        }
        
        private void ReadingIncentiveData()
        {
            try
            {
                DataRowView selectedIncentiveGroup = listBoxIncentiveRate.SelectedItem as DataRowView;
                DataRowView selectedGroupProduct = listBoxProductGroup.SelectedItem as DataRowView;
                DataRowView selectedGroupOutlet = listBoxOutletGroup.SelectedItem as DataRowView;
                textBoxIncentiveRate.Clear();
                textBoxQtyMin.Clear();
                textBoxQtyMax.Clear();
                textBoxIncentiveRate.Text = selectedIncentiveGroup["Rate"].ToString();
                textBoxQtyMin.Text = selectedIncentiveGroup["MinQty"].ToString();
                myConn.Open();
                int iIDCommRate = Convert.ToInt32(selectedIncentiveGroup["IDCommRate"]),
                    iIDItemGroup = Convert.ToInt32(selectedGroupProduct["IDItemGroup"]),
                    iIDOutletGroup = Convert.ToInt32(selectedGroupOutlet["IDOutletGroup"]);
                using (myCmd = new MySqlCommand(string.Format(@"SELECT (`MinQty` - 1) AS `MaxQty`
                    FROM `lhkcommrpt`.`comm_rate`
                    WHERE `MinQty` > (SELECT `MinQty` FROM `lhkcommrpt`.`comm_rate` WHERE `IDCommRate` = {0} )
                    AND `FKIDItemGroup` = {1} AND `FKIDOutletGroup` = {2} AND `Active` = 'Y'
                    ORDER BY `MinQty` ASC LIMIT 1;", iIDCommRate, iIDItemGroup, iIDOutletGroup), myConn))
                {
                    myCmd.CommandTimeout = 0;
                    using (myDr = myCmd.ExecuteReader())
                    {
                        if (myDr.Read()) { textBoxQtyMax.Text = myDr.GetString(0); }
                    }
                }
                if (string.IsNullOrEmpty(textBoxQtyMax.Text)) { textBoxQtyMax.Text = "or Above"; } // if not bigger max mean this is the max
                myConn.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void checkSelection()
        {
            textBoxQtyMax.IsReadOnly = true;
            if (bOutletSelected && bProductSelected)
            {
                groupBoxIncentiveOptions.IsEnabled = true;
                listBoxIncentiveRate.IsEnabled = true;
                buttonAdd.IsEnabled = true;
                buttonRemove.IsEnabled = true;
                DataRowView selectedProductGroup = listBoxProductGroup.SelectedItem as DataRowView;
                DataRowView selectedOutletGroup = listBoxOutletGroup.SelectedItem as DataRowView;
                int iIDItemGroup = Convert.ToInt32(selectedProductGroup["IDItemGroup"]),
                    iIDOutletGroup = Convert.ToInt32(selectedOutletGroup["IDOutletGroup"]);
                LoadingIncentiveGroup(iIDItemGroup, iIDOutletGroup);
            }
            else
            {
                groupBoxIncentiveOptions.IsEnabled = false;
                listBoxIncentiveRate.IsEnabled = false;
                buttonAdd.IsEnabled = false;
                buttonRemove.IsEnabled = false;
            }

            if (listBoxIncentiveRate.SelectedIndex != -1)
            {
                buttonUpdate.IsEnabled = true;
                textBoxIncentiveRate.IsEnabled = true;
                textBoxQtyMin.IsEnabled = true;
            }
            else
            {
                textBoxIncentiveRate.Clear();
                textBoxQtyMin.Clear();
                textBoxQtyMax.Clear();
                buttonUpdate.IsEnabled = false;
                textBoxIncentiveRate.IsEnabled = false;
                textBoxQtyMin.IsEnabled = false;
            }
        }

        //-- Only Accept Decimal -- TextBox -- Start -->
        private void textBoxIncentiveRate_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[.][0-9]+$|^[0-9]*[.]{0,1}[0-9]*$");
            e.Handled = !regex.IsMatch((sender as TextBox).Text.Insert((sender as TextBox).SelectionStart, e.Text));
        }

        private void textBoxQtyMin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key < Key.D0 || e.Key > Key.D9)
            {
                if (e.Key < Key.NumPad0 || e.Key > Key.NumPad9)
                {
                    if (e.Key != Key.Back) { e.Handled = true; }
                }
            }
        }
        //-- Only Accept Decimal -- TextBox -- End -->

        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBoxIncentiveRate.Text)) { throw new Exception("Please enter the Incentive Rate"); }
                if (string.IsNullOrEmpty(textBoxQtyMin.Text)) { throw new Exception("Please enter the minimal quantity to get this rate"); }
                DataRowView selectedIncentiveGroup = listBoxIncentiveRate.SelectedItem as DataRowView;
                int iIDCommRate = Convert.ToInt32(selectedIncentiveGroup["IDCommRate"]);
                UpdateIncentiveData(iIDCommRate);
                checkSelection();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void UpdateIncentiveData(int iIDCommRate)
        {
            try
            {
                myConn.Open();
                int iIncentiveRate = Convert.ToInt32(textBoxIncentiveRate.Text),
                    iQtyMin = Convert.ToInt32(textBoxQtyMin.Text);
                using (myCmd = new MySqlCommand(string.Format(@"UPDATE `lhkcommrpt`.`comm_rate` SET `Rate` = {0}, `MinQty` = {1} WHERE `IDCommRate` = {2};", iIncentiveRate, iQtyMin, iIDCommRate), myConn))
                {
                    myCmd.CommandTimeout = 0;
                    myCmd.ExecuteNonQuery();
                }
                myConn.Close();
                MessageBox.Show("Update succesfully");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void buttonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void buttonRemove_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (listBoxIncentiveRate.SelectedIndex == -1) { throw new Exception("Please select an Incentive Rate"); }
                if (MessageBox.Show("This will remove the selected incentive rate group, are you sure to proceed?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    DataRowView selectedIncentiveGroup = listBoxIncentiveRate.SelectedItem as DataRowView;
                    int iIDCommRate = Convert.ToInt32(selectedIncentiveGroup["IDCommRate"]);
                    myConn.Open();
                    using (myCmd = new MySqlCommand(string.Format(@"UPDATE `lhkcommrpt`.`comm_rate` SET `Active` = 'N' WHERE `IDCommRate` = {0};", iIDCommRate), myConn))
                    {
                        myCmd.CommandTimeout = 0;
                        myCmd.ExecuteNonQuery();
                    }
                    myConn.Close();
                    checkSelection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listBoxIncentiveRate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBoxIncentiveRate.SelectedIndex != -1)
            {
                buttonUpdate.IsEnabled = true;
                textBoxIncentiveRate.IsEnabled = true;
                textBoxQtyMin.IsEnabled = true;
                ReadingIncentiveData();
                if (textBoxQtyMin.Text == "1")
                {
                    textBoxQtyMin.IsEnabled = false; // make sure there is having one min item
                    if (listBoxIncentiveRate.Items.Count != 1) // if the item count not only one, mean have other rate
                    {
                        buttonRemove.IsEnabled = false; // so i not allow to remove this min quantity
                    }
                    else
                    {
                        buttonRemove.IsEnabled = true; // but if is only 1 then sure can remove
                    }
                } 

            }
            else
            {
                textBoxIncentiveRate.Clear();
                textBoxQtyMin.Clear();
                textBoxQtyMax.Clear();
                buttonUpdate.IsEnabled = false;
                textBoxIncentiveRate.IsEnabled = false;
                textBoxQtyMin.IsEnabled = false;
            }
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            DataRowView selectedProductGroup = listBoxProductGroup.SelectedItem as DataRowView;
            DataRowView selectedOutletGroup = listBoxOutletGroup.SelectedItem as DataRowView;
            bool bIsEmptyIncentive = (listBoxIncentiveRate.Items.Count == 0) ? true : false;
            int iIDItemGroup = Convert.ToInt32(selectedProductGroup["IDItemGroup"]), 
                iIDOutletGroup = Convert.ToInt32(selectedOutletGroup["IDOutletGroup"]);
            using (WindowNewIncentive wNI = new WindowNewIncentive(iIDItemGroup, iIDOutletGroup, bIsEmptyIncentive))
            {
                wNI.Owner = this;
                wNI.ShowDialog();
            }
            checkSelection();
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

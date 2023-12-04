using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
//-- IDisposable -- Start -->
using System.ComponentModel;
//-- IDisposable -- End -->

namespace Product_Incentive_Report
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IDisposable
    {
        private myConn m = new myConn();
        private MySqlConnection myConn; // Mysql Connection
        private MySqlCommand myCmd; // MySql Command
        private MySqlDataAdapter myDa; // MySql Data Adapter
        private MySqlDataReader myDr; // MySql Data Reader
        private ClassMainWindow cMW = new ClassMainWindow();
        
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
        ~MainWindow() //--> Change to Object Name
        {
            // Do not re-create Dispose clean-up code here.
            // Calling Dispose(false) is optimal in terms of readability and maintainability.
            Dispose(false);
        }
        //-- IDisposable -- End -->

        public MainWindow()
        {
            InitializeComponent();
            myConn = new MySqlConnection(m.Setting); // Create MySQL Connection
            ListYearMonth(); // Generate Month Year Combobox
            ListOutlet(); // Generate Outlet List
        }

        private void ListYearMonth() // Initialize date variable and display year and month
        {
            DateTime Today = DateTime.Now; // Get Today
            int[] YearArray = new int[5], // Year
                  MonthArray = new int[12] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }; // Month
            for (int i = 0; i < 5; i++) { YearArray[i] = (Today.Year + 1) - i; } // Getting Year from -3 toyear +1
            comboBoxYear.DataContext = YearArray; // Storing Year
            comboBoxYear.SelectedIndex = 1; // Select ToYear
            comboBoxMonth.DataContext = MonthArray; // Storing Month
            comboBoxMonth.SelectedIndex = (Today.Month - 1); // Select ToMonth
        }

        private void ListOutlet()
        {
            try
            {
                if (myConn.State == ConnectionState.Closed) { myConn.Open(); } // Open Connection if is Closed
                using (myCmd = new MySqlCommand(@"SELECT `IDBranch`, `BranchCode`
                    FROM `lhkdb_init`.`usr_branch`
                    WHERE `Active` = 'Y'
                    AND `IDBranch` IN (SELECT `FKIDBranch` FROM `lhkcommrpt`.`comm_outlet` WHERE `Active` = 'Y')
                    ORDER BY `BranchCode`;", myConn))
                {
                    myCmd.CommandTimeout = 0;
                    using (myDa = new MySqlDataAdapter(myCmd))
                    {
                        DataTable dt = new DataTable();
                        myDa.Fill(dt);
                        comboBoxOutlet.DataContext = dt;
                        comboBoxOutlet.DisplayMemberPath = "BranchCode";
                        comboBoxOutlet.SelectedIndex = 0; // Selecting 1st data
                    }
                }
                if (myConn.State == ConnectionState.Open) { myConn.Close(); } // Close Connection if is Open
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonOutletSetting_Click(object sender, RoutedEventArgs e)
        {
            using (WindowSettingOutlet wSO = new WindowSettingOutlet())
            {
                wSO.Owner = this;
                wSO.ShowDialog();
            }
        }

        private void buttonExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(); // Exit this Application
        }

        private void buttonSettingProduct_Click(object sender, RoutedEventArgs e)
        {
            using (WindowSettingProduct wSP = new WindowSettingProduct())
            {
                wSP.Owner = this;
                wSP.ShowDialog();
            }
        }

        private void buttonSettingIncentive_Click(object sender, RoutedEventArgs e)
        {
            using (WindowSettingIncentive wSI = new WindowSettingIncentive())
            {
                wSI.Owner = this;
                wSI.ShowDialog();
            }
        }

        private void buttonGenerate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(comboBoxYear.Text) || comboBoxYear.SelectedIndex == -1) { throw new Exception("Please select year"); }
                if (string.IsNullOrEmpty(comboBoxMonth.Text) || comboBoxMonth.SelectedIndex == -1) { throw new Exception("Please select month"); }
                if (string.IsNullOrEmpty(comboBoxOutlet.Text) || comboBoxOutlet.SelectedIndex == -1) { throw new Exception("Please select outlet"); }
                if (checkBoxAllOutlet.IsChecked == false) // Only Process Selected Branch
                {
                    DataRowView selectedOutlet = comboBoxOutlet.SelectedItem as DataRowView;
                    int FKIDBranch = Convert.ToInt32(selectedOutlet["IDBranch"]), // Reading FKIDBranch from the outlet select combobox
                        Year = Convert.ToInt32(comboBoxYear.Text), // Reading Year from year combobox
                        Month = Convert.ToInt32(comboBoxMonth.Text); // Reading Month from month combobox
                    string BranchCode = selectedOutlet["BranchCode"].ToString(); // Reading BranchCode from outlet select combobox
                    InitializePrepareData(Year, Month, FKIDBranch, BranchCode);
                }
                else // Process All Branch
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Preparing Data
        /// </summary>
        private void InitializePrepareData(int Year, int Month, int iFKIDBranch, string sBranchCode)
        {
            try
            {
                //-- Getting save file name -- Start -->
                string sExcelFileName = cMW.SaveFilename(Year, Month, iFKIDBranch, sBranchCode); // Getting the user chosen file name
                if (string.IsNullOrEmpty(sExcelFileName)) { throw new Exception("Please specific file name and location you want to save the report"); }
                //-- Getting save file name -- End -->
                //-- Getting OutletGroup ID by IDBranch -- Start -->
                int iIDOutletGroup = GetOutletGroup(iFKIDBranch);
                if (iIDOutletGroup == 0) { throw new Exception("This selected outlet is not within the setting"); } // Generally no require but extra protection
                //-- Getting OutletGroup ID by IDBranch -- End -->
                //-- Getting List of ProductGroup ID -- Start -->
                List<int> ItemGroupList = new List<int>(); // Create list to storing ItemGroup
                ItemGroupList = GetRootItemGroup(); // Reading List of the group
                if (ItemGroupList.Count == 0) { throw new Exception("There is not any product has setting with incentive data"); }
                //-- Getting List of ProductGroup ID -- End -->
                //-- Generating Excel -- Start -->
                //-- Creating Excel App Object -- Start -->
                Microsoft.Office.Interop.Excel._Application appExcel = new Microsoft.Office.Interop.Excel.Application(); // creating Excel Application
                Microsoft.Office.Interop.Excel._Workbook workbook = appExcel.Workbooks.Add(Type.Missing); // creating new WorkBook within Excel application
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null; // creating new Excelsheet in workbook
                appExcel.Visible = false; // Hiding Excel
                // get the reference of first sheet.
                worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets["Sheet1"]; //  By default its name is Sheet1.
                worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.ActiveSheet; // Active this Sheet
                worksheet.Name = "Incentive Report"; // changing the name of active sheet
                //-- Creating Excel App Object -- End -->
                //-- Generating Title -- Start -->
                //Formating Column Width
                ((Microsoft.Office.Interop.Excel.Range)worksheet.Columns["A", Type.Missing]).ColumnWidth = 20;
                ((Microsoft.Office.Interop.Excel.Range)worksheet.Columns["B", Type.Missing]).ColumnWidth = 20;
                ((Microsoft.Office.Interop.Excel.Range)worksheet.Columns["C", Type.Missing]).ColumnWidth = 14;
                ((Microsoft.Office.Interop.Excel.Range)worksheet.Columns["D", Type.Missing]).ColumnWidth = 14;
                ((Microsoft.Office.Interop.Excel.Range)worksheet.Columns["E", Type.Missing]).ColumnWidth = 20;
                //Formating Row & Column
                worksheet.Cells[1, 1].EntireColumn.NumberFormat = "@"; // Make Product Name Column Reading Like Text
                worksheet.Cells[1, 1].EntireRow.NumberFormat = "@"; // Make Title Row Reading Like Text
                worksheet.Cells[1, 1].EntireRow.Font.Bold = true; // Make Font Bold
                worksheet.Cells[3, 1].EntireRow.NumberFormat = "@"; // Make Title Row Reading Like Text
                worksheet.Cells[3, 1].EntireRow.Font.Bold = true; // Make Font Bold
                worksheet.Cells[5, 1].EntireRow.NumberFormat = "@"; // Make Title Row Reading Like Text
                worksheet.Cells[5, 1].EntireRow.Font.Bold = true; // Make Font Bold
                worksheet.Cells[6, 1].EntireRow.NumberFormat = "@"; // Make Title Row Reading Like Text
                worksheet.Cells[6, 1].EntireRow.Font.Bold = true; // Make Font Bold
                worksheet.Cells[8, 1].EntireRow.NumberFormat = "@"; // Make Header Row Reading Like Text
                worksheet.Cells[8, 1].EntireRow.Font.Bold = true; // Make Font Bold
                // storing header part in Excel
                worksheet.Cells[1, 1].Value = "Product Incentive Report";
                worksheet.Cells[3, 1].Value = "Report for those products quantity able to achieved the specify target (By outlet):";
                worksheet.Cells[5, 1].Value = "Month:";
                worksheet.Cells[5, 2].Value = string.Format("{0} - {1}", cMW.GetMonthName(Year, Month), Year);
                worksheet.Cells[6, 1].Value = "Outlet:";
                worksheet.Cells[6, 2].Value = sBranchCode;
                //-- Generating Title -- End -->
                //-- Generating Row Header -- Start -->
                worksheet.Cells[8, 1].Value = "Product Name";
                worksheet.Cells[8, 2].Value = "Target (Qty)";
                worksheet.Cells[8, 3].Value = "Achieved (Qty)";
                worksheet.Cells[8, 4].Value = "Incentive (RM)";
                worksheet.Cells[8, 5].Value = "Incentive Payout (RM)";
                //-- Generating Row Header -- End -->
                int iCurrExcelSheetRowNumber = 9; // Current Row, Row Start On 9
                double dTotalIncentiveEarnForBranch = 0; // Total Earn
                //-- Getting List of Quantity
                foreach (int iIDItemGroup in ItemGroupList)
                {
                    worksheet.Cells[iCurrExcelSheetRowNumber, 1].EntireRow.Font.Bold = false;
                    string sProductName = GetItemGroupName(iIDItemGroup); // Product Name
                    int iQtySold = ReadingQuantitySoldByProductGroup(iIDItemGroup, iFKIDBranch, Year, Month);
                    int iIDCommRate = GetIDRate(iIDItemGroup, iIDOutletGroup, iQtySold);
                    string sCommRange = GetCommRange(iIDCommRate, iIDItemGroup, iIDOutletGroup);
                    double dCommRate = GetCommRate(iIDCommRate);
                    double dTotalPayout = (double)iQtySold * dCommRate;
                    dTotalIncentiveEarnForBranch += dTotalPayout;
                    worksheet.Cells[iCurrExcelSheetRowNumber, 1].Value = sProductName;
                    worksheet.Cells[iCurrExcelSheetRowNumber, 2].Value = sCommRange;
                    worksheet.Cells[iCurrExcelSheetRowNumber, 3].Value = iQtySold;
                    worksheet.Cells[iCurrExcelSheetRowNumber, 4].Value = dCommRate;
                    worksheet.Cells[iCurrExcelSheetRowNumber, 5].Value = dTotalPayout;
                    iCurrExcelSheetRowNumber++; // Increase One More Row
                }
                int dTotalIncentiveRow = ++iCurrExcelSheetRowNumber;
                worksheet.Cells[dTotalIncentiveRow, 5].Value = dTotalIncentiveEarnForBranch;
                worksheet.Cells[dTotalIncentiveRow, 1].EntireRow.Font.Bold = true;
                //-- Save Excel -- Start -->
                workbook.SaveAs(sExcelFileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                appExcel.Quit(); // Exit Excel
                MessageBox.Show("Excel file is successfully created");
                //-- Save Excel -- End -->
                //-- Generating Excel -- End -->
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string GetCommRange(int iFKIDCommRate, int iIDItemGroup, int iIDOutletGroup)
        {
            string sCommRange = string.Empty, sMaxQty = string.Empty;
            try
            {
                if (myConn.State == ConnectionState.Closed) { myConn.Open(); } // Open Connection if is Closed
                using (myCmd = new MySqlCommand(string.Format(@"SELECT `MinQty` FROM `lhkcommrpt`.`comm_rate`
                    WHERE `IDCommRate` = {0} ORDER BY `MinQty` ASC;", iFKIDCommRate), myConn))
                {
                    myCmd.CommandTimeout = 0;
                    using (myDr = myCmd.ExecuteReader())
                    {
                        if (myDr.Read()) { sCommRange = myDr.GetValue(0).ToString(); } // if found mean this is the Min Qty
                    }
                }
                using (myCmd = new MySqlCommand(string.Format(@"SELECT (`MinQty` - 1) AS `MaxQty` FROM `lhkcommrpt`.`comm_rate`
                    WHERE `MinQty` > (SELECT `MinQty` FROM `lhkcommrpt`.`comm_rate` WHERE `IDCommRate` = {0})
                    AND `Active` = 'Y' AND `FKIDItemGroup` = {1} AND `FKIDOutletGroup` = {2}
                    ORDER BY `MinQty` ASC LIMIT 1;", iFKIDCommRate, iIDItemGroup, iIDOutletGroup), myConn))
                {
                    myCmd.CommandTimeout = 0;
                    using (myDr = myCmd.ExecuteReader())
                    {
                        if (myDr.Read()) { sMaxQty = " - " + myDr.GetValue(0).ToString(); } // if found mean the Max Qty is found
                    }
                }
                if (string.IsNullOrEmpty(sMaxQty))
                {
                    sMaxQty = " or Above";
                }
                if (myConn.State == ConnectionState.Open) { myConn.Close(); } // Close Connection if is Open
            }
            catch { } // Dismiss Error
            return sCommRange + sMaxQty;
        }

        private double GetCommRate(int iFKIDCommRate)
        {
            double dRate = 0;
            try
            {
                if (myConn.State == ConnectionState.Closed) { myConn.Open(); } // Open Connection if is Closed
                using (myCmd = new MySqlCommand(string.Format(@"SELECT `Rate` FROM `lhkcommrpt`.`comm_rate` WHERE `IDCommRate` = {0};", iFKIDCommRate), myConn))
                {
                    myCmd.CommandTimeout = 0;
                    using (myDr = myCmd.ExecuteReader())
                    {
                        if (myDr.Read()) { dRate = myDr.GetDouble(0); } // if found mean this is the comm rate
                    }
                }
                if (myConn.State == ConnectionState.Open) { myConn.Close(); } // Close Connection if is Open
            }
            catch { } // Dismiss Error
            return dRate;
        }

        /// <summary>
        /// Get IDCommRate
        /// </summary>
        /// <param name="iFKIDItemGroup">ItemGroup</param>
        /// <param name="iFKIDOutletGroup">OutletGroup</param>
        /// <param name="iQty">Quantity</param>
        /// <returns>IDCommRate</returns>
        private int GetIDRate(int iFKIDItemGroup, int iFKIDOutletGroup, int iQty)
        {
            int iIDComm = 0;
            try
            {
                if (myConn.State == ConnectionState.Closed) { myConn.Open(); } // Open Connection if is Closed
                using (myCmd = new MySqlCommand(string.Format(@"SELECT `IDCommRate`, `MinQty` FROM `lhkcommrpt`.`comm_rate`
                    WHERE `FKIDItemGroup` = {0} AND `FKIDOutletGroup` = {1}
                    AND `Active` = 'Y' ORDER BY `MinQty`;", iFKIDItemGroup, iFKIDOutletGroup), myConn))
                {
                    myCmd.CommandTimeout = 0;
                    using (myDr = myCmd.ExecuteReader())
                    {
                        while (myDr.Read())
                        {
                            // if MinQty Get is small then the Quantity this must be the correct one,
                            // loop until the last one, if larger then will just skip
                            int iIDCommRate = myDr.GetInt32(0), iMinQty = myDr.GetInt32(1);
                            if (iMinQty < iQty) { iIDComm = iIDCommRate; } 
                        }
                    }
                }
                if (myConn.State == ConnectionState.Open) { myConn.Close(); } // Close Connection if is Open
            }
            catch { } // Dismiss Error
            return iIDComm;
        }

        private string GetItemGroupName(int iFKIDItemGroup)
        {
            string sItemGroupName = string.Empty;
            try
            {
                if (myConn.State == ConnectionState.Closed) { myConn.Open(); } // Open Connection if is Closed
                using (myCmd = new MySqlCommand(string.Format(@"SELECT `ItemGroupName` FROM `lhkcommrpt`.`comm_itemgroup`
                    WHERE `IDItemGroup` = {0} AND `Active` = 'Y';", iFKIDItemGroup), myConn))
                {
                    myCmd.CommandTimeout = 0;
                    using (myDr = myCmd.ExecuteReader())
                    {
                        if (myDr.Read()) { sItemGroupName = myDr.GetValue(0).ToString(); } // If Found this must be the only Item Group Name
                    }
                }
                if (myConn.State == ConnectionState.Open) { myConn.Close(); } // Close Connection if is Open
            }
            catch { } // dismiss error
            return sItemGroupName;
        }

        /// <summary>
        /// By Product Group
        /// </summary>
        /// <param name="iFKIDItemGroup">ProductGroupID</param>
        /// <param name="iFKIDBranch">IDBranch</param>
        /// <param name="Year">Year</param>
        /// <param name="Month">Month</param>
        /// <returns>Total Quantity in this Product Group</returns>
        private int ReadingQuantitySoldByProductGroup(int iFKIDItemGroup, int iFKIDBranch, int Year, int Month)
        {
            int iProductGroupQuantity = 0;
            try
            {
                List<int> IDMasterItemGroup = new List<int>();
                if (myConn.State == ConnectionState.Closed) { myConn.Open(); } // Open Connection if is Closed
                using (myCmd = new MySqlCommand(string.Format(@"SELECT `FKIDMasterItem` FROM `lhkcommrpt`.`comm_item` WHERE `FKIDItemGroup` = {0} AND `Active` = 'Y';", iFKIDItemGroup), myConn))
                {
                    myCmd.CommandTimeout = 0;
                    using (myDr = myCmd.ExecuteReader())
                    {
                        while (myDr.Read()) { IDMasterItemGroup.Add(myDr.GetInt32(0)); } // Add All IDMasterItem inside this group to List
                    }
                }
                if (myConn.State == ConnectionState.Open) { myConn.Close(); } // Close Connection if is Open

                foreach (int iFKIDMasterItem in IDMasterItemGroup)
                {
                    if (iFKIDMasterItem != 0 || iFKIDBranch != 0) // if IDMasterItem is 0 or IDBranch is 0 mean something wrong just skip
                    {
                        iProductGroupQuantity += ReadingQuantitySoldByProduct(iFKIDMasterItem, iFKIDBranch, Year, Month);
                    }
                }
                
            }
            catch { } // dismiss the error
            return iProductGroupQuantity;
        }

        /// <summary>
        /// Individual IDMasterItem
        /// </summary>
        /// <param name="iFKIDMasterItem">IDMasterItem</param>
        /// <param name="iFKIDBranch">IDBranch</param>
        /// <param name="Year">Year</param>
        /// <param name="Month">Month</param>
        /// <returns>Quantity of IDMaster Sold By IDBranch On Year and Month</returns>
        private int ReadingQuantitySoldByProduct(int iFKIDMasterItem, int iFKIDBranch, int Year, int Month)
        {
            int iSingleProductQuantity = 0;
            try
            {
                string sEarlyMonthYear = string.Format("{0}-{1}-1", Year, Month),
                       sEndMonthYear = string.Format("{0}-{1}-{2}", Year, Month, cMW.LastDayOfMonth(Month, Year));
                if (myConn.State == ConnectionState.Closed) { myConn.Open(); } // Open Connection if is Closed
                using (myCmd = new MySqlCommand(string.Format(@"SELECT FORMAT(SUM(si.`PurchaseQty`), 0) AS `Qty`
                    FROM `lhkdb_init`.`sale_item` AS si
                    INNER JOIN `lhkdb_init`.`stk_outlet_inventory_batch` AS soib ON soib.`IDInvBatch` = si.`FKIDInvBatch`
                    INNER JOIN `lhkdb_init`.`stk_outlet_inventory` AS soi ON soi.`IDOutletInventory` = soib.`FKIDOutletInventory`
                    INNER JOIN `lhkdb_init`.`sale_header` AS sh ON sh.`IDSaleHeader` = si.`FKIDSaleHeader`
                    WHERE soi.`FKIDBranch` = {0}
                    AND soi.`FKIDMasterItem` = {1}
                    AND sh.`SaleDate` BETWEEN '{2}' AND '{3}'
                    AND sh.`TranStatus` = 'Complete';", iFKIDBranch, iFKIDMasterItem, sEarlyMonthYear, sEndMonthYear), myConn))
                {
                    myCmd.CommandTimeout = 0;
                    using (myDr = myCmd.ExecuteReader())
                    {
                        if (myDr.Read())
                        {
                            if (!string.IsNullOrEmpty(myDr.GetValue(0).ToString())) { iSingleProductQuantity = myDr.GetInt32(0); } // is not empty then this is the quantity of this IDMasterItem for the branch inside the date range
                        }
                    }
                }
                if (myConn.State == ConnectionState.Open) { myConn.Close(); } // Close Connection if is Open
            }
            catch { } // dismiss the error
            return iSingleProductQuantity;
        }

        /// <summary>
        /// Getting List of Product Group
        /// </summary>
        /// <returns>Product Group List</returns>
        private List<int> GetRootItemGroup()
        {
            List<int> ItemGroupList = new List<int>(); // List of item group inside comm_itemgroup
            try
            {
                if (myConn.State == ConnectionState.Closed) { myConn.Open(); } // Open Connection if is Closed
                using (myCmd = new MySqlCommand(@"SELECT `IDItemGroup` FROM `lhkcommrpt`.`comm_itemgroup` AND `Active` = 'Y';", myConn))
                {
                    myCmd.CommandTimeout = 0;
                    using (myDr = myCmd.ExecuteReader())
                    {
                        while (myDr.Read()) { ItemGroupList.Add(myDr.GetInt32(0)); } // Add all founded active item to list
                    }
                }
                if (myConn.State == ConnectionState.Open) { myConn.Close(); } // Close Connection if is Open
            }
            catch { } // dismiss the error
            return ItemGroupList;
        }

        /// <summary>
        /// GetOutletGroup ID by Using IDBranch
        /// </summary>
        /// <param name="iFKIDBranch">IDBranch</param>
        /// <returns>IDOutletGroup</returns>
        private int GetOutletGroup(int iFKIDBranch)
        {
            int iIDOutletGroup = 0;
            try
            {
                if (myConn.State == ConnectionState.Closed) { myConn.Open(); } // Open Connection if is Closed
                using (myCmd = new MySqlCommand(string.Format(@"SELECT `FKIDOutletGroup` FROM `lhkcommrpt`.`comm_outlet`
                    WHERE `FKIDBranch` = {0} AND `Active` = 'Y';", iFKIDBranch), myConn))
                {
                    myCmd.CommandTimeout = 0;
                    using (myDr = myCmd.ExecuteReader())
                    {
                        if (myDr.Read()) { iIDOutletGroup = myDr.GetInt32(0); } // if is found then this must be the only one IDOutletGroup
                    }
                }
                if (myConn.State == ConnectionState.Open) { myConn.Close(); } // Close Connection if is Open
            }
            catch { } // dismiss the error
            return iIDOutletGroup;
        }

        private void checkBoxAllOutlet_Checked(object sender, RoutedEventArgs e)
        {
            comboBoxOutlet.IsEnabled = false;
        }

        private void checkBoxAllOutlet_Unchecked(object sender, RoutedEventArgs e)
        {
            comboBoxOutlet.IsEnabled = true;
        }
    }
}

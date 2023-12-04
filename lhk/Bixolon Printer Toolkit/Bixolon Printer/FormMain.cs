using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Forms;
using PrinterClassDll;
using MySql.Data.MySqlClient;
using System.Threading;
using System.Windows.Threading;

namespace Bixolon_Printer
{
    public partial class FormMain : Form
    {
        private MySqlConnection myconn;
        private MySqlCommand mycmd;
        private MySqlDataReader mydr;
        private myConn my = new myConn();
        private Win32PrintClass w32prn = new Win32PrintClass();
        private List<ReceiptDetails> RD = new List<ReceiptDetails>();
        private int LastID = 0;
        private string outlet = string.Empty;
        private bool myconnfail = true;
        List<string> newBranchAddr = new List<string>();
        private string BranchName = string.Empty, BranchAddr = string.Empty,
            BranchCity = string.Empty, BranchTel = string.Empty;

        public FormMain()
        {
            try
            {
                this.Icon = ResourceArtwork.AppIcon;
                InitializeComponent();
                myconn = new MySqlConnection(my.Setting);
                if (myconn.State == ConnectionState.Closed) { myconn.Open(); }
                using (mycmd = new MySqlCommand("SELECT NOW();", myconn))
                {
                    mycmd.CommandTimeout = 0;
                    using (mydr = mycmd.ExecuteReader())
                    {
                        if (mydr.Read())
                        {
                            myconnfail = false;
                        }
                    }
                }

                outlet = Properties.Settings.Default.Outlet;
                string ReadOnly = Properties.Settings.Default.ReadOnly;
                if (ReadOnly.ToLower() == "true")
                {
                    textBoxBranchCode.ReadOnly = true;
                }
                if (!string.IsNullOrEmpty(outlet))
                {
                    textBoxBranchCode.Text = outlet;
                    textBoxReceiptNo.Focus();
                }
                else
                {
                    MessageBox.Show("Please configure your branch code at config file");
                }
                FetchTodayReceipt(outlet);
                labelDate.Text = "Today : " + DateTime.Today.ToShortDateString();
                labelTotalSale.Text = "Total Sale Receipt : " + listBoxReceiptNo.Items.Count.ToString();

                string sql = string.Format(@"SELECT `BranchName`, `BranchAddr`, `BranchCity`, `BranchTel` FROM `usr_branch` WHERE `BranchCode` = '{0}';", outlet);
                if (myconn.State == ConnectionState.Closed) { myconn.Open(); }
                using (mycmd = new MySqlCommand(sql, myconn))
                {
                    mycmd.CommandTimeout = 0;
                    using (mydr = mycmd.ExecuteReader())
                    {
                        while (mydr.Read())
                        {
                            BranchName = mydr.GetString(0);
                            BranchAddr = mydr.GetString(1);
                            BranchCity = mydr.GetString(2);
                            BranchTel = mydr.GetString(3);
                        }
                    }
                }
                newBranchAddr = SplitString(BranchAddr, 30);
            }
            catch (Exception ex) { myconnfail = true; MessageBox.Show("Database connection fail..."); MessageBox.Show(ex.Message); }
            finally { if (myconn.State == ConnectionState.Open) { myconn.Close(); }  }
        }

        private void FetchTodayReceipt(string Outlet)
        {
            if (!string.IsNullOrEmpty(Outlet))
            {
                if (listBoxReceiptNo.Items.Count != 0)
                {
                    ReceiptDetails k = listBoxReceiptNo.Items[0] as ReceiptDetails;
                    LastID = k.IDSaleHeader;
                }
                else
                {
                    LastID = 0;
                }

                try
                {
                    if (myconnfail) { throw new Exception("die"); }
                    labelRefreshTime.Text = "Last Refresh : " + DateTime.Now.ToString(); 
                    if (myconn.State == ConnectionState.Closed) { myconn.Open(); }
                    string sql = string.Format(@"SELECT sh.`IDSaleHeader`, sh.`SaleNo`, CONCAT(sm.`LastName`, ' ', sm.`FirstName`)
                        FROM `sale_header` AS sh
                        LEFT JOIN `sale_member` AS sm ON sm.`IDMember` = sh.`FKIDMember`
                        WHERE sh.`SaleNoPrefix` = '{0}'
                        AND DATE(sh.`CreatedDT`) = DATE(NOW())
                        AND sh.`IDSaleHeader` > {1}
                        ORDER BY sh.`IDSaleHeader` DESC;", outlet, LastID);
                    //MessageBox.Show(sql);
                    using (mycmd = new MySqlCommand(sql, myconn))
                    {
                        mycmd.CommandTimeout = 0;
                        using (mydr = mycmd.ExecuteReader())
                        {
                            while (mydr.Read())
                            {
                                string ReceiptNo = outlet.ToUpper() + "-" + mydr.GetInt32(1);
                                RD.Add(new ReceiptDetails { IDSaleHeader = mydr.GetInt32(0), IDReceipt = mydr.GetInt32(1), ReceiptNo = ReceiptNo + " - " + mydr.GetString(2) });   
                            }
                        }
                    }
                    if (myconn.State == ConnectionState.Open) { myconn.Close(); }
                    RD = RD.OrderByDescending(x => x.IDReceipt).ToList();
                    listBoxReceiptNo.DataSource = RD;
                    listBoxReceiptNo.DisplayMember = "ReceiptNo";
                    listBoxReceiptNo.SelectedIndex = 0;
                    listBoxReceiptNo.Refresh();
                    labelTotalSale.Text = "Total Sale Receipt : " + listBoxReceiptNo.Items.Count.ToString();

                }
                catch { }
            }
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            PrintingReceipt();
        }

        private void PrintingReceipt()
        {
            try
            {
                if (myconnfail) { throw new Exception("There is something wrong, try close and reopen this toolkit"); }
                if (textBoxBranchCode.TextLength == 0) { throw new Exception("Branch code is empty"); }
                if (textBoxReceiptNo.TextLength == 0) { throw new Exception("Receipt no is empty"); }
                if (myconn.State == ConnectionState.Closed) { myconn.Open(); }
                int IDSaleHeader = 0, IDBranch = 0;
                string MemberName = string.Empty, MemberNo = string.Empty, MemberType = string.Empty,
                    SaleDate = string.Empty, UserAcc = string.Empty, StrReason = string.Empty,
                    SaleType = string.Empty, TranStatus = string.Empty, Remarks = string.Empty;
                decimal ActualTotal = 0, CashTotal = 0, PayAmount = 0, RoundAmount = 0, TotalAmount = 0, ChangeAmount = 0;
                string sql = string.Format(@"
                    SELECT sh.`IDSaleHeader`,
                        CONCAT(sm.`LastName`, ' ', sm.`FirstName`) AS `Member Name`,
                        CONCAT(sm.`MembershipNoPrefix`, '-', sm.`MemberShipNo`) AS `Member No`,
                        mmt.`MembershipTypeName`,
                        sh.`FKIDBranch`,
                        sh.`SaleDate`,
                        uu.`UserAcc`,
                        sh.`SaleType`,
                        sh.`TranStatus`,
                        sh.`Remarks`,
                        sh.`TotalAmount`,
                        sh.`PayAmount`,
                        sh.`ChangeAmount`,
                        sh.`RoundAmount`,
                        sv.`Reason`,
                        sh.`CashTotal`
                    FROM `lhkdb_init`.`sale_header` AS sh
                    INNER JOIN `lhkdb_init`.`usr_user` AS uu ON uu.`IDUser` = sh.`SaleBy`
                    INNER JOIN `lhkdb_init`.`sale_member` AS sm ON sm.`IDMember` = sh.`FKIDMember`
                    INNER JOIN `lhkdb_init`.`mkt_membership_type` AS mmt ON mmt.`IDMembershipType` = sm.`FKIDMembershipType`
                    LEFT JOIN  `lhkdb_init`.`sale_void` AS sv ON sv.`FKIDSaleHeader` = sh.`IDSaleHeader`
                    WHERE sh.`SaleNoPrefix` = '{0}'
                    AND sh.`SaleNo` = {1};", textBoxBranchCode.Text, textBoxReceiptNo.Text);
                using (mycmd = new MySqlCommand(sql, myconn))
                {
                    mycmd.CommandTimeout = 0;
                    using (mydr = mycmd.ExecuteReader())
                    {
                        int iReturnResult = 0;
                        while (mydr.Read())
                        {
                            iReturnResult++;
                            IDSaleHeader = mydr.GetInt32(0);
                            MemberName = mydr.GetValue(1).ToString();
                            MemberNo = mydr.GetValue(2).ToString();
                            MemberType = mydr.GetValue(3).ToString();
                            IDBranch = mydr.GetInt32(4);
                            SaleDate = Convert.ToDateTime(mydr.GetValue(5)).ToShortDateString();
                            UserAcc = mydr.GetValue(6).ToString();
                            SaleType = mydr.GetValue(7).ToString();
                            TranStatus = mydr.GetValue(8).ToString();
                            Remarks = mydr.GetValue(9).ToString();
                            TotalAmount = mydr.GetDecimal(10);
                            PayAmount = mydr.GetDecimal(11);
                            ChangeAmount = mydr.GetDecimal(12);
                            RoundAmount = mydr.GetDecimal(13);
                            StrReason = mydr.GetValue(14).ToString();
                            CashTotal = mydr.GetDecimal(15);
                            ActualTotal = TotalAmount - RoundAmount;
                        }
                        if (iReturnResult == 0)
                        {
                            throw new Exception("[0x0001] Cannot Found This Receipt Number...");
                        }
                    }
                }
                List<ItemDetails> ItemData = new List<ItemDetails>();
                sql = string.Format(@"SELECT si.`IDSaleItem`, si.`ItemType`, CONCAT(mi.`ItemName`), mu.`UOM`, soib.`BatchNo`, FORMAT(si.`PurchaseQty`,0), FORMAT(si.`OrgPrice`, 2), FORMAT(si.`DiscountRate`, 2), FORMAT(si.`UnitPrice`, 2)
                    FROM `lhkdb_init`.`sale_item` AS si
                    LEFT JOIN `lhkdb_init`.`stk_outlet_inventory` AS soi ON soi.`IDOutletInventory` = si.`FKIDOutletInventory`
                    LEFT JOIN `lhkdb_init`.`stk_outlet_inventory_batch` AS soib ON soib.`IDInvBatch` = si.`FKIDInvBatch`
                    LEFT JOIN `lhkdb_init`.`master_item` AS mi ON mi.`IDMasterItem` = soi.`FKIDMasterItem`
                    LEFT JOIN `lhkdb_init`.`master_uom` AS mu ON mu.`IDMasterUOM` = soi.`FKIDMasterUOM`
                    WHERE si.`FKIDSaleHeader` = {0};", IDSaleHeader);
                using (mycmd = new MySqlCommand(sql, myconn))
                {
                    mycmd.CommandTimeout = 0;
                    using (mydr = mycmd.ExecuteReader())
                    {
                        while (mydr.Read())
                        {
                            ItemData.Add(new ItemDetails
                            {
                                IDSaleItem = Convert.ToInt32(mydr.GetValue(0)),
                                ItemType = mydr.GetValue(1).ToString(),
                                ItemName = mydr.GetValue(2).ToString() + "/" + mydr.GetValue(3).ToString() + "/ " + mydr.GetValue(4).ToString(),
                                Qty = Convert.ToInt32(mydr.GetValue(5)),
                                OrgPrice = Convert.ToDecimal(mydr.GetValue(6)),
                                DiscRate = Convert.ToDecimal(mydr.GetValue(7)),
                                UnitPrice = Convert.ToDecimal(mydr.GetValue(8))
                            });
                        }
                    }
                }

                List<ItemDetails> ItemData2 = new List<ItemDetails>();

                foreach (ItemDetails id in ItemData)
                {
                    if (id.ItemType == "Item")
                    {
                        ItemData2.Add(new ItemDetails
                        {
                            IDSaleItem = id.IDSaleItem,
                            ItemType = id.ItemType,
                            ItemName = id.ItemName,
                            Qty = id.Qty,
                            OrgPrice = id.OrgPrice,
                            DiscRate = id.DiscRate,
                            UnitPrice = id.UnitPrice
                        });
                    }
                    else if (id.ItemType == "Package")
                    {
                        sql = string.Format(@"SELECT mb.`BundleName`
                            FROM `sale_item` AS si
                            INNER JOIN `mkt_bundle` AS mb ON mb.`IDBundle` = si.`FKIDBundle`
                            WHERE si.`ItemType` = 'Package'
                            AND si.`IDSaleItem` = {0};", id.IDSaleItem);
                        using (mycmd = new MySqlCommand(sql, myconn))
                        {
                            mycmd.CommandTimeout = 0;
                            using (mydr = mycmd.ExecuteReader())
                            {
                                while (mydr.Read())
                                {
                                    ItemData2.Add(new ItemDetails
                                    {
                                        IDSaleItem = id.IDSaleItem,
                                        ItemType = "Item",
                                        ItemName = mydr.GetValue(0).ToString(),
                                        Qty = id.Qty,
                                        OrgPrice = id.OrgPrice,
                                        DiscRate = id.DiscRate,
                                        UnitPrice = id.UnitPrice
                                    });
                                }
                            }
                        }
                        sql = string.Format(@"SELECT mi.`ItemName`, mu.`UOM`, soib.`BatchNo`, spi.`ItemQty`, spi.`UnitPrice`, spi.`ItemType`
                            FROM `sale_package_item` AS spi
                            LEFT JOIN `lhkdb_init`.`stk_outlet_inventory` AS soi ON soi.`IDOutletInventory` = spi.`FKIDOutletInventory`
                            LEFT JOIN `lhkdb_init`.`stk_outlet_inventory_batch` AS soib ON soib.`IDInvBatch` = spi.`FKIDInvBatch`
                            LEFT JOIN `lhkdb_init`.`master_item` AS mi ON mi.`IDMasterItem` = soi.`FKIDMasterItem`
                            LEFT JOIN `lhkdb_init`.`master_uom` AS mu ON mu.`IDMasterUOM` = soi.`FKIDMasterUOM`
                            WHERE `FKIDSaleItem` = {0};", id.IDSaleItem);
                        bool packagevoucher = false;
                        using (mycmd = new MySqlCommand(sql, myconn))
                        {
                            mycmd.CommandTimeout = 0;
                            using (mydr = mycmd.ExecuteReader())
                            {
                                while (mydr.Read())
                                {
                                    if (mydr.GetValue(5).ToString().Equals("Voucher"))
                                    {
                                        packagevoucher = true;
                                    }
                                    else // item
                                    {
                                        ItemData2.Add(new ItemDetails
                                        {
                                            IDSaleItem = id.IDSaleItem,
                                            ItemType = "Item",
                                            ItemName = "   * " + mydr.GetValue(0).ToString() + "/" + mydr.GetValue(1).ToString() + "/ " + mydr.GetValue(2).ToString(),
                                            Qty = Convert.ToInt32(mydr.GetValue(3)),
                                            OrgPrice = 0,
                                            DiscRate = 0,
                                            UnitPrice = 0
                                        });
                                    }
                                }

                            }
                        }
                        if (packagevoucher.Equals(true))
                        {
                            sql = string.Format(@"SELECT mi.`ItemName`, GROUP_CONCAT(sv.`VoucherNo` SEPARATOR ','), sv.`ValidThru`, COUNT(svl.`IDSaleVoucherLog`)
                                            FROM `sale_voucher_log` AS svl
                                            INNER JOIN `sale_voucher` AS sv ON sv.`IDSaleVoucher` = svl.`FKIDSaleVoucher`
                                            INNER JOIN `master_item` AS mi ON mi.`IDMasterItem` = sv.`FKIDMasterItem`
                                            WHERE svl.`FKIDSaleItem` = {0}
                                            GROUP BY mi.`ItemName`;", id.IDSaleItem);
                            using (mycmd = new MySqlCommand(sql, myconn))
                            {
                                mycmd.CommandTimeout = 0;
                                using (mydr = mycmd.ExecuteReader())
                                {
                                    while (mydr.Read())
                                    {
                                        ItemData2.Add(new ItemDetails
                                        {
                                            IDSaleItem = id.IDSaleItem,
                                            ItemType = "Item",
                                            ItemName = mydr.GetValue(0).ToString() + "[" + Convert.ToDateTime(mydr.GetValue(2)).ToShortDateString() + "]",
                                            Qty = Convert.ToInt32(mydr.GetValue(3)),
                                        });
                                        ItemData2.Add(new ItemDetails
                                        {
                                            IDSaleItem = id.IDSaleItem,
                                            ItemType = id.ItemType,
                                            ItemName = " - " + mydr.GetValue(1).ToString(),
                                        });
                                    }
                                }
                            }
                        }
                    }
                    else if (id.ItemType == "Voucher")
                    {
                        sql = string.Format(@"SELECT mi.`ItemName`, GROUP_CONCAT(sv.`VoucherNo` SEPARATOR ','), sv.`ValidThru`, COUNT(svl.`IDSaleVoucherLog`)
                                    FROM `sale_voucher_log` AS svl
                                    INNER JOIN `sale_voucher` AS sv ON sv.`IDSaleVoucher` = svl.`FKIDSaleVoucher`
                                    INNER JOIN `master_item` AS mi ON mi.`IDMasterItem` = sv.`FKIDMasterItem`
                                    WHERE svl.`FKIDSaleItem` = {0}
                                    GROUP BY mi.`ItemName`;", id.IDSaleItem);
                        using (mycmd = new MySqlCommand(sql, myconn))
                        {
                            mycmd.CommandTimeout = 0;
                            using (mydr = mycmd.ExecuteReader())
                            {
                                while (mydr.Read())
                                {
                                    ItemData2.Add(new ItemDetails
                                    {
                                        IDSaleItem = id.IDSaleItem,
                                        ItemType = "Item",
                                        ItemName = mydr.GetValue(0).ToString() + "[" + Convert.ToDateTime(mydr.GetValue(2)).ToShortDateString() + "]",
                                        Qty = Convert.ToInt32(mydr.GetValue(3)),
                                        OrgPrice = id.OrgPrice,
                                        DiscRate = id.DiscRate,
                                        UnitPrice = id.UnitPrice
                                    });
                                    ItemData2.Add(new ItemDetails
                                    {
                                        IDSaleItem = id.IDSaleItem,
                                        ItemType = id.ItemType,
                                        ItemName = " - " + mydr.GetValue(1).ToString(),
                                    });
                                }
                            }
                        }
                    }
                    else if (id.ItemType == "Redempt")
                    {
                        ItemData2.Add(new ItemDetails
                        {
                            IDSaleItem = id.IDSaleItem,
                            ItemType = "Item",
                            ItemName = "Redempt: " + id.ItemName,
                            Qty = id.Qty,
                            OrgPrice = id.OrgPrice,
                            DiscRate = id.DiscRate,
                            UnitPrice = id.UnitPrice
                        });
                        sql = string.Format(@"SELECT `VoucherNo` FROM `sale_voucher` WHERE `RedemptIDSaleItem` = {0};", id.IDSaleItem);
                        using (mycmd = new MySqlCommand(sql, myconn))
                        {
                            mycmd.CommandTimeout = 0;
                            using (mydr = mycmd.ExecuteReader())
                            {
                                while (mydr.Read())
                                {
                                    ItemData2.Add(new ItemDetails
                                    {
                                        IDSaleItem = id.IDSaleItem,
                                        ItemType = id.ItemType,
                                        ItemName = " * Redempt: " + mydr.GetValue(0).ToString(),
                                    });
                                }
                            }
                        }
                    }
                }

                List<DiscountDetails> DiscountData = new List<DiscountDetails>();
                foreach (ItemDetails idtmp in ItemData2)
                {
                    sql = string.Format(@"SELECT md.`DiscountTitle`, mi.`ItemName`, FORMAT(sid.`DiscountQty`, 0), FORMAT(sid.`DiscountRate`, 2), FORMAT(sid.`DiscountPrice`, 2)
                        FROM `lhkdb_init`.`sale_item_discount` AS sid
                        LEFT JOIN `lhkdb_init`.`sale_item` AS si ON si.`IDSaleItem` = sid.`FKIDSaleItem`
                        LEFT JOIN `lhkdb_init`.`stk_outlet_inventory` AS soi ON soi.`IDOutletInventory` = si.`FKIDOutletInventory`
                        LEFT JOIN `lhkdb_init`.`master_item` AS mi ON mi.`IDMasterItem` = soi.`FKIDMasterItem`
                        LEFT JOIN `lhkdb_init`.`mkt_discount` AS md ON md.`IDDiscount` = sid.IDRef
                        WHERE sid.`FKIDSaleItem` = {0};", idtmp.IDSaleItem);
                    using (mycmd = new MySqlCommand(sql, myconn))
                    {
                        mycmd.CommandTimeout = 0;
                        using (mydr = mycmd.ExecuteReader())
                        {
                            while (mydr.Read())
                            {
                                DiscountData.Add(new DiscountDetails
                                {
                                    DiscountTitle = mydr.GetString(0),
                                    ItemName = mydr.GetString(1),
                                    DiscountQty = mydr.GetDecimal(2),
                                    DiscountRate = mydr.GetDecimal(3),
                                    DiscountPrice = mydr.GetDecimal(4)
                                });
                            }
                        }
                    }
                }

                // Payment
                List<PaymentDetails> PaymentData = new List<PaymentDetails>();
                // Credit Card
                sql = string.Format(@"SELECT cc.Bank AS CCBank, c.CardNo, c.Amount AS CCAmount
                    FROM `sale_payment_cc` AS c 
                    LEFT JOIN `master_bank` AS cc ON cc.IDMasterBank = c.FKIDMasterBank 
                    WHERE c.FKIDSaleHeader = {0};", IDSaleHeader);
                using (mycmd = new MySqlCommand(sql, myconn))
                {
                    mycmd.CommandTimeout = 0;
                    using (mydr = mycmd.ExecuteReader())
                    {
                        while (mydr.Read())
                        {
                            string Bank = mydr.GetValue(0).ToString();
                            string CardNo = ReturnEncryptedString(mydr.GetValue(1).ToString());
                            decimal Amount = mydr.GetDecimal(2);
                            PaymentData.Add(new PaymentDetails
                            {
                                PaymentData = "CC " + Bank + "[" + CardNo.GetLast(4) + "]",
                                PaymentAmount = Amount
                            });
                        }
                    }
                }
                // Gift Voucher
                sql = string.Format(@"SELECT g.GiftVoucherName, g.GiftVoucherValue,v.Qty
                    FROM `sale_payment_gift_voucher` AS v 
                    LEFT JOIN `mkt_gift_voucher` AS g ON v.FKIDGiftVoucher = g.IDGiftVoucher 
                    WHERE v.FKIDSaleHeader = {0};", IDSaleHeader);
                using (mycmd = new MySqlCommand(sql, myconn))
                {
                    mycmd.CommandTimeout = 0;
                    using (mydr = mycmd.ExecuteReader())
                    {
                        while (mydr.Read())
                        {
                            string VName = mydr.GetValue(0).ToString().TruncateLongString(10) + " x " + mydr.GetValue(2).ToString();
                            decimal Amount = mydr.GetDecimal(1) * Convert.ToDecimal(mydr.GetValue(2));
                            PaymentData.Add(new PaymentDetails
                            {
                                PaymentData = "GV " + VName,
                                PaymentAmount = Amount
                            });
                        }
                    }
                }

                //Redempt Card
                sql = string.Format(@"SELECT mct.CardTypeName,
                    rc.NameOnCard,
                    rc.CardNo, 
                    rc.Amount
                    FROM `sale_payment_rc` AS rc 
                    INNER JOIN `mkt_card_type` AS mct
                    ON mct.IDCardType=rc.FKIDCardType 
                    WHERE rc.FKIDSaleHeader = {0};", IDSaleHeader);
                using (mycmd = new MySqlCommand(sql, myconn))
                {
                    mycmd.CommandTimeout = 0;
                    using (mydr = mycmd.ExecuteReader())
                    {
                        while (mydr.Read())
                        {
                            string VName = mydr.GetValue(0).ToString().TruncateLongString(10) + " " + mydr.GetValue(1).ToString() + " " + mydr.GetValue(2).ToString().GetLast(4);
                            decimal Amount = mydr.GetDecimal(3);
                            PaymentData.Add(new PaymentDetails
                            {
                                PaymentData = "RC " + VName,
                                PaymentAmount = Amount
                            });
                        }
                    }
                }

                //Other Method
                sql = string.Format(@"SELECT b.TranType, k.Bank, b.RefNo, b.Amount
                    FROM `sale_payment_others` AS b 
                    LEFT JOIN `master_bank` AS k ON k.IDMasterBank = b.FKIDMasterBank 
                    WHERE b.FKIDSaleHeader = {0};", IDSaleHeader);
                using (mycmd = new MySqlCommand(sql, myconn))
                {
                    mycmd.CommandTimeout = 0;
                    using (mydr = mycmd.ExecuteReader())
                    {
                        while (mydr.Read())
                        {
                            string VName = mydr.GetValue(0).ToString() + " " + mydr.GetValue(1).ToString().TruncateLongString(10) + " " + mydr.GetValue(2).ToString();
                            decimal Amount = mydr.GetDecimal(3);
                            PaymentData.Add(new PaymentDetails
                            {
                                PaymentData = VName,
                                PaymentAmount = Amount
                            });
                        }
                    }
                }

                // Void Data
                string VoidUser = string.Empty, VoidDate = string.Empty, VoidReason = string.Empty;

                if (TranStatus == "Void")
                {
                    sql = string.Format(@"SELECT uu.`UserAcc`, sv.`VoidDT`, sv.`Reason`
                        FROM `sale_void` AS sv
                        INNER JOIN `lhkdb_init`.`usr_user` AS uu ON uu.`IDUser` = sv.`VoidBy`
                        WHERE sv.`FKIDSaleHeader` = {0};", IDSaleHeader);
                    using (mycmd = new MySqlCommand(sql, myconn))
                    {
                        mycmd.CommandTimeout = 0;
                        using (mydr = mycmd.ExecuteReader())
                        {
                            while (mydr.Read())
                            {
                                VoidUser = mydr.GetString(0);
                                VoidDate = mydr.GetString(1);
                                VoidReason = mydr.GetString(2);
                            }
                        }
                    }
                }

                //--> Printing
                w32prn.SetPrinterName("BIXOLON SRP-275II");

                // Print Image
                w32prn.SetDeviceFont(9.5f, "FontControl", false, false);
                w32prn.PrintText("x");
                //w32prn.PrintText("G");
                //w32prn.PrintText("H");
                w32prn.SetDeviceFont(9.5f, "FontB2x1", false, true);
                w32prn.PrintText("Lo Hong Ka Sdn Bhd ");
                w32prn.SetDeviceFont(9.5f, "FontA1x1", false, false);
                w32prn.PrintText("(472560-X)");
                w32prn.PrintText(BranchName);
                foreach (string s in newBranchAddr)
                {
                    w32prn.PrintText(s);
                }
                w32prn.PrintText(BranchCity);
                w32prn.PrintText("");
                w32prn.SetDeviceFont(7f, "FontB2x1", false, true);
                w32prn.PrintText("Tel: " + BranchTel);
                w32prn.SetDeviceFont(9.5f, "FontControl", false, false);
                w32prn.PrintText("w");
                w32prn.SetDeviceFont(9.5f, "FontA1x1", false, false);
                w32prn.PrintText("---------------------------------");
                w32prn.PrintText("Receipt No  : " + textBoxBranchCode.Text.ToUpper() + "-" + textBoxReceiptNo.Text);
                w32prn.PrintText("Date        : " + SaleDate);
                w32prn.PrintText("Member Name : " + MemberName);
                w32prn.PrintText("Member No   : " + MemberNo);
                w32prn.PrintText("Member Type : " + MemberType);
                w32prn.PrintText("Served By   : " + UserAcc);
                w32prn.PrintText("Sale Type   : " + SaleType);
                w32prn.PrintText("Sale Status : " + TranStatus);
                w32prn.PrintText("Remark      : ");
                List<string> RemarksList = SplitString(Remarks, 30);
                foreach (string str in RemarksList)
                {
                    w32prn.PrintText("  " + str);
                }
                w32prn.SetDeviceFont(7f, "FontA1x1", false, false);
                w32prn.PrintText("---------------------------------");
                w32prn.PrintText("Item   Qty   Unit   Disc    Total");
                w32prn.PrintText("             (RM)    (%)     (RM)");
                w32prn.PrintText("---------------------------------");
                foreach (ItemDetails Data in ItemData2)
                {
                    List<string> newItemName = SplitString(Data.ItemName, 33);
                    foreach (string str in newItemName)
                    {
                        w32prn.PrintText(str);
                    }
                    if (Data.ItemType == "Item")
                    {
                        string Qty = (Data.Qty > 0) ? Data.Qty.ToString() : string.Empty;
                        string OrgPrice = (Data.OrgPrice > 0) ? Data.OrgPrice.ToString() : string.Empty;
                        string DiscRate = (Data.DiscRate > 0) ? Data.DiscRate.ToString() : string.Empty;
                        decimal TotalPrice = Data.UnitPrice * Data.Qty;
                        string TotalUnitPrice = (TotalPrice > 0) ? TotalPrice.ToString() : string.Empty;
                        w32prn.PrintText("      "
                            + Spacing(Qty, 3)
                            + Spacing(OrgPrice, 6)
                            + Spacing(DiscRate, 6)
                            + Spacing(TotalUnitPrice, 8));
                    }
                }

                foreach (DiscountDetails Data in DiscountData)
                {
                    List<string> newDiscName = SplitString(Data.DiscountTitle, 30);
                    int i = 0;
                    foreach (string str in newDiscName)
                    {
                        if (i.Equals(0))
                        {
                            w32prn.PrintText("*" + str);
                        }
                        else
                        {
                            w32prn.PrintText(str);
                        }
                        i++;
                    }
//                    w32prn.PrintText("*" + Data.DiscountTitle);
                    w32prn.PrintText("  ~" + Data.ItemName);
                    w32prn.PrintText("        "
                        + Spacing("(" + Data.DiscountQty.ToString() + ")", 4)
                        + " -"
                        + Spacing("(" + Data.DiscountRate.ToString() + ")", 8)
                        + Spacing("(" + Data.DiscountPrice.ToString() + ")", 8));
                }

                //w32prn.SetDeviceFont(9.5f, "FontA1x1", false, false);
                w32prn.PrintText("---------------------------------");
                w32prn.SetDeviceFont(9.5f, "FontA1x1", false, true);
                w32prn.PrintText("Total (RM)  :    " + Spacing(Math.Round(ActualTotal, 2).ToString(), 15));
                w32prn.PrintText("Rounding    :    " + Spacing(Math.Round(RoundAmount, 2).ToString(), 15));
                w32prn.PrintText("Actual Total:    " + Spacing(Math.Round(TotalAmount, 2).ToString(), 15));
                w32prn.PrintText("Pay Amount  :    " + Spacing(Math.Round(PayAmount, 2).ToString(), 15));
                w32prn.PrintText("Change      :    " + Spacing(Math.Round(ChangeAmount, 2).ToString(), 15));
                w32prn.PrintText("");
                w32prn.PrintText("Payment by  :");
                foreach (PaymentDetails pd in PaymentData)
                {
                    w32prn.PrintText(pd.PaymentData);
                    w32prn.PrintText(Spacing("RM " + Math.Round(pd.PaymentAmount, 2).ToString(), 32));
                }
                if (CashTotal > 0)
                {
                    w32prn.PrintText("Cash");
                    w32prn.PrintText(Spacing("RM " + Math.Round(CashTotal, 2).ToString(), 32));
                }
                w32prn.SetDeviceFont(9.5f, "FontA1x1", false, false);
                w32prn.PrintText("---------------------------------");
                w32prn.SetDeviceFont(9.5f, "FontControl", false, false);
                w32prn.PrintText("x");
                w32prn.PrintText("r");
                w32prn.SetDeviceFont(9.5f, "FontA1x1", false, false);

                if (TranStatus == "Void")
                {
                    w32prn.PrintText("*** Void Sale ***");
                    w32prn.PrintText("Done by : " + VoidUser);
                    w32prn.PrintText("Date at : " + VoidDate);
                    List<string> Reason = SplitString(VoidReason, 30);
                    w32prn.PrintText("Reason  : ");
                    foreach (string r in Reason)
                    {
                        w32prn.PrintText("  " + r);
                    }
                }
                else
                {
                    w32prn.PrintText("Goods sold are NOT returnable");
                    w32prn.PrintText(" NOR exchangeable ");
                    w32prn.PrintText("");
                    w32prn.PrintText("Customer's Signature");
                    w32prn.PrintText("");
                    w32prn.PrintText("");
                    w32prn.PrintText("");
                    w32prn.PrintText("");
                    w32prn.PrintText("--------------------");
                    w32prn.PrintText("Thank you for visit");
                    w32prn.PrintText("Please come again");
                }
                // Cut Receipt
                w32prn.SetDeviceFont(9.5f, "FontControl", false, false);
                w32prn.PrintText("P");

                // Print
                w32prn.EndDoc();
                MessageBox.Show("Print Complete...");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (myconn.State == ConnectionState.Open) { myconn.Close(); }
            }
        }

        public List<string> SplitString(String text, int lengths)
        {
            List<string> parts = new List<string>();
            
            string[] pieces = text.Split(' ');
            StringBuilder tempString = new StringBuilder("");

            foreach (var piece in pieces)
            {
                if (piece.Length + tempString.Length + 1 > lengths)
                {
                    parts.Add(tempString.ToString());
                    tempString.Clear();
                }
                tempString.Append((tempString.Length == 0 ? "" : " ") + piece);
            }
            if (tempString.Length > 0)
                parts.Add(tempString.ToString());

            return parts;
        }

        private string Spacing(string Text, int Length)
        {
            string output = string.Empty;
            for (int i = 0; i <= Length - Text.Length; i++)
            {
                output += " ";
            }
            output += Text;
            return output;
        }

        public string ReturnEncryptedString(string EncryptedString)
        {
            try
            {
                using (WebClient wc = new WebClient())
                {
                    return wc.DownloadString(string.Format("http://10.8.10.8/misupdate/cryptocc.php?no={0}", EncryptedString));
                } 
            }
            catch (WebException we) { throw new Exception(we.ToString()); } // operation fail
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void listBoxReceiptNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listBoxReceiptNo.SelectedIndex != -1)
                {
                    ReceiptDetails i = listBoxReceiptNo.SelectedItem as ReceiptDetails;
                    textBoxBranchCode.Text = outlet;
                    textBoxReceiptNo.Text = i.IDReceipt.ToString();
                }
            }
            catch { }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            if (myconnfail == false)
            {
                FetchTodayReceipt(outlet);
            }
        }

        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            if (myconnfail == false)
            {
                FetchTodayReceipt(outlet);
            }
        }
    }

    public static class StringExtension
    {
        public static string[] Wrap(this string text, int max)
        {
            var charCount = 0;
            var lines = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return lines.GroupBy(w => (charCount += w.Length + 1) / (max + 2)).Select(g => string.Join(" ", g.ToArray())).ToArray();
        }

        public static string TruncateLongString(this string str, int maxLength)
        {
            return str.Substring(0, Math.Min(str.Length, maxLength));
        }

        public static string GetLast(this string s, int tail_length)
        {
            if (tail_length >= s.Length)
                return s;
            return s.Substring(s.Length - tail_length);
        }
    }

    public class ItemDetails
    {
        public int IDSaleItem { get; set; }
        public string ItemType { get; set; }
        public string ItemName { get; set; }
        public int Qty { get; set; }
        public decimal OrgPrice { get; set; }
        public decimal DiscRate { get; set; }
        public decimal UnitPrice { get; set; }
    }

    public class DiscountDetails
    {
        public string DiscountTitle { get; set; }
        public string ItemName { get; set; }
        public decimal DiscountQty { get; set; }
        public decimal DiscountRate { get; set; }
        public decimal DiscountPrice { get; set; }
    }

    public class PaymentDetails
    {
        public string PaymentData { get; set; }
        public decimal PaymentAmount { get; set; }
    }

    public class ReceiptDetails
    {
        public int IDSaleHeader { get; set; }
        public int IDReceipt { get; set; }
        public string ReceiptNo { get; set; }
    }
}

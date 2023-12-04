using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LHK_Intranet_Application
{
    public partial class frmDowngradeMember : Form
    {
        // MySQL Connection
        MySqlConnection myconnection;
        MySqlCommand mycommand;
        MySqlDataReader myReader;
        /*string MyConString = @"SERVER=10.8.10.8; 
                DATABASE=lhkdb_init;
                UID=root;
                PASSWORD=rms01@lhk;respect binary flags=false;";*/
        const string MyIP = "10.8.10.8";
        string MyConString = string.Format(@"SERVER={0}; 
                DATABASE=lhkdb_init;
                UID=root;
                PASSWORD=rms01@lhk;respect binary flags=false;", MyIP);
        public frmDowngradeMember()
        {
            InitializeComponent();
            txtMsg.Text = "IP : " + MyIP;
            myconnection = new MySqlConnection(MyConString);
            mycommand = myconnection.CreateCommand();
        }

        private void frmDowngradeMember_Load(object sender, EventArgs e)
        {
            btnDowngrade.Enabled = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                txtMemberName.Text = null;
                txtMembership.Text = null;
                if (txtPrefix.TextLength > 0 && txtMemberID.TextLength > 0)
                {
                    int count = 0;
                    if (myconnection != null) myconnection.Close();
                    myconnection.Open();
                    mycommand.CommandText = string.Format(@"
                            SELECT CONCAT(sm.`LastName`, ' ', sm.`FirstName`) AS `Member Name`,
                            mt.`MembershipTypeName` AS `Membership Type`
                            FROM `sale_member` sm
                            INNER JOIN `mkt_membership_type` mt ON mt.`IDMembershipType` = sm.`FKIDMembershipType`
                            WHERE sm.`MembershipNoPrefix` = '{0}'
                            AND sm.`MemberShipNo` = {1};", txtPrefix.Text, int.Parse(txtMemberID.Text));
                    myReader = mycommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        count++;
                        txtMemberName.Text = myReader.GetValue(0).ToString();
                        txtMembership.Text = myReader.GetValue(1).ToString();
                    }
                    myconnection.Close();
                    if (count == 0)
                    {
                        txtMsg.Text = "No result found...";
                    }
                    else
                    {
                        btnSearch.Enabled = false;
                        txtPrefix.Enabled = false;
                        txtMemberID.Enabled = false;
                        btnDowngrade.Enabled = true;
                        this.AcceptButton = btnDowngrade;
                        txtMsg.Text = "Enter MIS authentication to downgrade this member.";
                    }
                }
                else
                    throw new Exception("Missing Parameter...");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtPrefix_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void btnDowngrade_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPrefix.TextLength > 0 && txtMemberID.TextLength > 0 && txtMemberName.TextLength > 0 && txtMembership.TextLength > 0)
                {
                    if (txtAuth.Text == "mis472560")
                    {
                        if (myconnection != null) myconnection.Close();
                        myconnection.Open();
                        mycommand.CommandText = string.Format(@"
                            UPDATE `sale_member` sm
                            SET sm.`FKIDMembershipType` = 1
                            WHERE sm.`MembershipNoPrefix` = '{0}'
                            AND sm.`MemberShipNo` = {1};", txtPrefix.Text, int.Parse(txtMemberID.Text));
                        mycommand.ExecuteNonQuery();
                        txtMsg.Text = "Downgrade complete";
                        btnDowngrade.Enabled = false;
                        btnSearch.Enabled = true;
                        txtPrefix.Enabled = true;
                        txtMemberID.Enabled = true;
                        txtMemberName.Text = null;
                        txtMembership.Text = null;
                        this.AcceptButton = btnSearch;
                    }
                    else
                        throw new Exception("Invalid authentication...");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            btnDowngrade.Enabled = false;
            btnSearch.Enabled = true;
            txtPrefix.Enabled = true;
            txtMemberID.Enabled = true;
            txtMemberName.Text = null;
            txtMembership.Text = null;
            this.AcceptButton = btnSearch;
            btnSearch.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace HR_Server
{
    public partial class frmUpdateStaffNo : Form
    {
        private MySqlConnection conn = null;
        private MySqlCommand cmd = null;
        private MySqlDataReader dr = null;
        private string ip = "10.8.10.8"; //10.8.10.8
        private static string lhkdb_init = @"SERVER=10.8.10.8;
                DATABASE=lhkdb_init;
                UID=root;
                PASSWORD=rms01@lhk;respect binary flags=false;";

        private struct node
        {
            public int id;
            public string data;
        }


        public frmUpdateStaffNo()
        {
            InitializeComponent();
            lblIP.Text = "Using " + ip;
        }

        private void frmUpdateStaffNo_Load(object sender, EventArgs e)
        {
            try
            {
                if (!ping("10.8.10.8")) { throw new Exception("Cannot connect database."); }
                conn = new MySqlConnection(lhkdb_init);
                cmd = conn.CreateCommand();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                Application.Exit();
            }
        }

        private bool ping(string IP)
        {
            Ping x = new Ping();
            PingReply r = x.Send(IPAddress.Parse(IP));
            // if replied ping return true not return false
            return (r.Status == IPStatus.Success);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtSearch.Text)) { throw new Exception("Missing name."); }
                gData.Visible = false;
                txtSearch.Enabled = false;
                string sql = string.Format(@"SELECT `IDUser`, `UserAcc` FROM `usr_user` WHERE `UserStatus` = 'Y' AND `UserAcc` LIKE '%{0}%';", txtSearch.Text);
                dgResult.Rows.Clear();
                conn.Open();
                cmd.CommandText = sql;
                dr = cmd.ExecuteReader();
                int record = 0;
                while (dr.Read())
                {
                    int i = dgResult.Rows.Add();
                    dgResult.Rows[i].Cells[0].Value = dr.GetInt32(0);
                    dgResult.Rows[i].Cells[1].Value = dr.GetValue(1).ToString();
                    record++;
                }
                conn.Close();
                txtSearch.Enabled = true;
                if (record == 0) { throw new Exception("No such staff name " + txtSearch.Text); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int IDUser = 0; // make it zero to detect later if fail
                int.TryParse(dgResult.Rows[dgResult.CurrentCell.RowIndex].Cells["IDUser"].Value.ToString(), out IDUser); // get the user id from the datagridview
                if (IDUser == 0) { throw new Exception("Data Generate Error!"); } // operation fail
                string sql = string.Format(@"SELECT u.`UserStaffNo`, b.`BranchCode`, r.`RoleDesc`, u.`UserEmail`, u.`UserTel`, u.`UserHP` FROM `usr_user` u INNER JOIN `usr_branch` b ON b.`IDBranch` = u.`FKIDBranch` INNER JOIN `usr_role` r ON r.`IDRole` = u.`FKIDRole` WHERE u.`IDUser` = {0};", IDUser);
                txtUserID.Text = IDUser.ToString();
                txtBranchCode.Clear();
                txtEmail.Clear();
                txtHP.Clear();
                txtRole.Clear();
                txtStaffNo.Clear();
                txtStaffNo.Enabled = true;
                txtTel.Clear();
                conn.Open();
                cmd.CommandText = sql;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    txtStaffNo.Text = dr.GetValue(0).ToString();
                    txtBranchCode.Text = dr.GetValue(1).ToString();
                    txtRole.Text = dr.GetValue(2).ToString();
                    txtEmail.Text = dr.GetValue(3).ToString();
                    txtTel.Text = dr.GetValue(4).ToString();
                    txtHP.Text = dr.GetValue(5).ToString();
                }
                conn.Close();
                gData.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtSearch_MouseHover(object sender, EventArgs e)
        {
            txtStatus.Text = "Enter the staff name, support wildcard format...";
        }

        private void btnSearch_MouseHover(object sender, EventArgs e)
        {
            txtStatus.Text = "Search this staff?";
        }

        private void dgResult_MouseHover(object sender, EventArgs e)
        {
            txtStatus.Text = "Here is showing the result, select a staff to show the staff data...";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                txtStaffNo.Enabled = false;
                if (string.IsNullOrEmpty(txtUserID.Text)) { throw new Exception("Unknown Error (0x0001)"); }
                if (string.IsNullOrEmpty(txtStaffNo.Text)) { throw new Exception("The Staff No field is empty"); }
                string sql = string.Format(@"UPDATE `usr_user` u SET u.`UserStaffNo` = '{0}' WHERE u.`IDUser` = '{1}';", txtStaffNo.Text, txtUserID.Text);
                conn.Open();
                cmd.CommandText = sql;
                txtStaffNo.Enabled = true;
                if (cmd.ExecuteNonQuery() == 0) { conn.Close(); throw new Exception("Operation fail, please try again."); }
                conn.Close();
                if (chkUpdatePunchCard.Checked == true)
                {
                    UpdatePunchCard(txtUserID.Text);
                    //if (!) { throw new Exception("Operation update punch card fail"); }
                }
                MessageBox.Show("Record is saved");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdatePunchCard(string uid)
        {
            List<node> listdata = new List<node>();
            conn.Open();
            cmd = conn.CreateCommand();
            string sql2 = string.Format(@"SELECT `IDPunchCard`, `PunchCardNo`
                                    FROM `lhkdb_hr`.`punch_card`
                                    WHERE `FKIDUser` = {0}
                                    AND `Status` IN ('New', 'Verified', 'Approved');", uid);
            cmd.CommandText = sql2;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                int IDPunchCard = dr.GetInt32(0);
                string data = dr.GetValue(1).ToString(),
                       newline = null;
                string[] sep = new string[] { "/" }, res;
                res = data.Split(sep, StringSplitOptions.None);
                newline = res[0] + "/" + res[1] + "/" + txtStaffNo.Text + "/" + res[3];
                listdata.Add(new node { id = IDPunchCard, data = newline });
            }
            conn.Close();
            string sql3 = @"UPDATE `lhkdb_hr`.`punch_card` p SET p.`PunchCardNo` = '{0}' WHERE p.`IDPunchCard` = '{1}';";
            foreach(node n in listdata)
            {
                conn.Open();
                cmd.CommandText = string.Format(sql3, n.data, n.id);
                if (cmd.ExecuteNonQuery() == 0) { conn.Close(); throw new Exception("Update Punchcard error!"); };
                conn.Close();
            }
        }
        
        private void btnSave_MouseHover(object sender, EventArgs e)
        {
            txtStatus.Text = "Save the changes?";
        }

        private void txtStaffNo_MouseHover(object sender, EventArgs e)
        {
            txtStatus.Text = "Enter new staff no?";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnExit_MouseHover(object sender, EventArgs e)
        {
            txtStatus.Text = "Exit?";
        }

        private void chkUpdatePunchCard_MouseHover(object sender, EventArgs e)
        {
            txtStatus.Text = "Tick if want update punch card data (affect 'New', 'Verified' & 'Approved' only).";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdatePunchCard(txtUserID.Text);
        }

        private void frmUpdateStaffNo_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (conn != null)
            {
                conn.Close();
                conn = null;
            }
        }
   }
}

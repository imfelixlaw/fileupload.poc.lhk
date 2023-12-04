using System;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;
// Class Encryption
using ClassLibEncryption;
using ClassLogFunction;

namespace FYP_Campaign_Project
{
    public partial class frmLogin : Form
    {
        // Disable close button -- start
        const int MF_BYPOSITION = 0x400;
        [DllImport("User32")]
        private static extern int RemoveMenu(IntPtr hMenu, int nPosition, int wFlags);
        [DllImport("User32")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        [DllImport("User32")]
        private static extern int GetMenuItemCount(IntPtr hWnd);
        // Disable close button -- end

        // fetch external ip address
        static string ip = null;

        public frmLogin()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Exit entire project
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to close?", "Confirm Close", MessageBoxButtons.YesNo) == DialogResult.Yes) Application.Exit();
        }

        /// <summary>
        /// Check username length
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUsername_Leave(object sender, EventArgs e)
        {
            // if empty or else is < Program._CONST_MinAuthenticationChar
            if (txtUsername.TextLength < Program._CONST_MinAuthenticationChar || txtUsername.Text.Contains(" "))
            {
                txtSystemMessage.Text = ((txtUsername.TextLength == 0) ? "Username cannot be empty" : "Username length should at least " + Program._CONST_MinAuthenticationChar + " character") + " and space is not allow";
                txtUsername.Focus(); // set focus
            }
        }

        /// <summary>
        /// check password length
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPassword_Leave(object sender, EventArgs e)
        {
            // Password imposible will empty or Password < Program._CONST_MinAuthenticationChar
            if (txtPassword.TextLength < Program._CONST_MinAuthenticationChar || txtPassword.Text.Contains(" "))
            {
                txtSystemMessage.Text = ((txtPassword.TextLength == 0) ? "Password cannot be empty" : "Password length should at least " + Program._CONST_MinAuthenticationChar + " characters") + " and space is not allow";
                txtPassword.Focus(); // set focus
            }
        }

        /// <summary>
        /// Enable login button if data is sufficient
        /// </summary>
        private void EnableLogin()
        {
            btnLogin.Enabled = (txtUsername.TextLength >= Program._CONST_MinAuthenticationChar && txtPassword.TextLength >= Program._CONST_MinAuthenticationChar) ? true : false;
        }

        /// <summary>
        /// call EnableLogin()
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUsername_KeyUp(object sender, KeyEventArgs e)
        {
            EnableLogin();
        }

        /// <summary>
        /// call EnableLogin()
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            EnableLogin();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            tryLogin_Execution();
        }

        private void tryLogin_Execution()
        {
            try
            {
                // verify
                Program.myReader = Program._MySQL.MySQLExecuteReader(string.Format(@"SELECT `iduser`, `status`, `permission` FROM `cms_users` WHERE `username` = '{0}' AND `password` = '{1}';", txtUsername.Text, ProtectionMethod.Encrypt(txtPassword.Text)));
                while (Program.myReader.Read())
                {
                    Program.__UserID = int.Parse(string.Format("{0}", Program.myReader.GetValue(0)));
                    Program.__UserStatus = string.Format("{0}", Program.myReader.GetValue(1));
                    Program.__UserPermission = int.Parse(string.Format("{0}", Program.myReader.GetValue(2)));
                }
                // Authentication success
                if (Program._Func.StringToUpper(Program.__UserStatus) == Program._CONST_UserStatus_ACTIVE && Program.__UserID != Program._CONST_DISABLED)
                {
                    Program._MySQL.MySQLExecuteNonQuery(string.Format(@"DELETE FROM `cms_loginfail` WHERE `ip` = '{0}';", ip));
                    MessageBox.Show("Welcome " + txtUsername.Text);
                    Program._WriteToLog.Log(txtUsername.Text + " from IP [" + ip + "] has logon to system");
                    this.Close();
                    Thread newCampaignMDI = new Thread(new ThreadStart(ThreadProc));
                    newCampaignMDI.Start();
                }
                else // Authentication fail ady
                {
                    if (fetchFail() >= Program._LoginFailLimit) throw new Exception("Fail login count limit exceed.\nPlease Wait another 15 min.");
                    // create failsafe
                    Program._MySQL.MySQLExecuteNonQuery(string.Format("UPDATE `cms_loginfail` SET `count` = `count` + 1, `datetime` = NOW() WHERE ip = '{0}';", ip));
                    resetVar();
                    txtSystemMessage.Text = "Authentication Fail.";
                    throw new Exception("Authentication Fail");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Program._WriteToLog.Log(ex.Message, LogFunction.Error);
            }
        }

        private static void ThreadProc()
        {
            Application.Run(new frmMDIMain());
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                // Disable close button :: start
                IntPtr hMenu = GetSystemMenu(this.Handle, false);
                int menuItemCount = GetMenuItemCount(hMenu);
                RemoveMenu(hMenu, menuItemCount - 1, MF_BYPOSITION);
                // Disable close button :: end
                ip = Program._Func.GetExternalIP();
                // reset everything
                resetVar();

                // Clear old entries
                Program._MySQL.MySQLExecuteNonQuery(@"DELETE FROM `cms_loginfail` WHERE `datetime` < DATE_SUB(NOW(), INTERVAL 15 MINUTE);");
                if (fetchFail() >= Program._LoginFailLimit) throw new Exception("Fail login count limit exceed.\nPlease Wait another 15 min.");
                // create failsafe
                Program._MySQL.MySQLExecuteNonQuery(string.Format(@"INSERT IGNORE INTO `cms_loginfail` SET `ip` = '{0}', `datetime` = NOW();", ip));
                Program._WriteToLog.Log("Login Form is opened", LogFunction.Debug);
                txtUsername.Focus();
                btnLogin.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Program._WriteToLog.Log(ex.Message, LogFunction.Error);
                Application.Exit();
            }
        }

        private void resetVar()
        {
            Program.__UserID = Program._CONST_DISABLED;
            Program.__UserStatus = Program._CONST_UserStatus_DEACTIVE;
            Program.__UserPermission = Program._CONST_Permission_DISABLED;
        }

        private int fetchFail()
        {
            try
            {
                int count = 0;
                Program.myReader = Program._MySQL.MySQLExecuteReader(string.Format(@"SELECT `count` FROM `cms_loginfail` WHERE `ip` = '{0}';", ip));
                while (Program.myReader.Read())
                    count = int.Parse(string.Format("{0}", Program.myReader.GetValue(0)));
                return count;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

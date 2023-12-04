using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Language.Client;
using Felix.Library.Common;
using Felix.Library.Common.WinForm;
using Felix.Library.Common.DB;
using Felix.Library.Common.Encryption;
using MySql.Data.MySqlClient;

namespace HR_Attendance_Module_Client
{
    public partial class FrmMain : Form
    {
        // branch storage
        private class Branch
        {
            public int IDBranch { get; set; }
            public string BranchCode { get; set; }
            public string BranchName { get; set; }
        }

        // user storage
        private class User
        {
            public int IDUser { get; set; }
            public int IDBranch { get; set; }
            public string UserAcc { get; set; }
            public string Password { get; set; }
            //public string LastPunch { get; set; }
            //public string LastPunchLocation { get; set; }
        }

        private ClientLanguage Lang = new ClientLanguage("FrmMain");
        private CommonWinForm CWF = new CommonWinForm();
        private CommonDB COMMONDB = null;
        private CommonEncryption CE = new CommonEncryption("HRRM");
        private Common COMMON = null;
        private List<Branch> BranchList = new List<Branch>();
        private List<User> UserList = new List<User>();
        private List<User> AllUserList = new List<User>();
        private MySqlDataReader dr = null;
        private int Count = 0;

        //private bool UserListDone = false;

        public FrmMain()
        {
            InitializeComponent();
            this.Icon = Resource.AppIcon;
            this.labelVersion.Text = Application.ProductVersion;
            FormInitialization();
            LanguageInitialization();
            FetchAllBranch();
            FetchAllUser();
            Branch selectedBranch = comboBoxBranch.SelectedItem as Branch; // to get cbbox selected iduser
            GetUserList(selectedBranch.IDBranch);
        }

        private void FetchAllUser()
        {
            try
            {
                AllUserList.Clear();
                dr = COMMONDB.MySQLExecuteReader(string.Format(
                   @"SELECT `hru`.`IDUser`,
                        `hru`.`FKIDBranch`,
	                    `hru`.`UserAcc`,
	                    `hru`.`UserPwd`
                    FROM `hr_user` AS `hru`
                    WHERE `hru`.`UserStatus` = 'Y'
                    ORDER BY `hru`.`UserAcc` ASC;"));
                for (Count = 0; dr.Read(); Count++)
                {
                    AllUserList.Add(new User
                    {
                        IDUser = string.IsNullOrEmpty(dr.GetValue(0).ToString()) ? 0 : dr.GetInt32(0),
                        IDBranch = string.IsNullOrEmpty(dr.GetValue(1).ToString())? 0 : dr.GetInt32(1),
                        UserAcc = dr.GetValue(2).ToString(),
                        Password = CE.Encrypt(CoreKernel.GetDecryptedPassword(dr.GetValue(3).ToString())),
                    });
                }
            }
            catch (Exception ex)
            {
                textBoxSystemMessage.Text += "[" + DateTime.Now.ToString() + "] " + ex.Message + Environment.NewLine;
            }
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                COMMONDB.MySQLClose();
                COMMONDB = null;
            }
            catch { } // do nothing
        }
        
        private void comboBoxLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            LanguageInitialization();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LanguageInitialization()
        {
            this.Text = Lang.GetLang("FrmMain", comboBoxLanguage.SelectedIndex);
            groupBoxBranch.Text = Lang.GetLang("groupBoxBranch", comboBoxLanguage.SelectedIndex);
            groupBoxUser.Text = Lang.GetLang("groupBoxUser", comboBoxLanguage.SelectedIndex);
            groupBoxPassword.Text = Lang.GetLang("groupBoxPassword", comboBoxLanguage.SelectedIndex);
            groupBoxAction.Text = Lang.GetLang("groupBoxAction", comboBoxLanguage.SelectedIndex);
            groupBoxLanguage.Text = Lang.GetLang("groupBoxLanguage", comboBoxLanguage.SelectedIndex);
            labelPasswordRequired.Text = Lang.GetLang("labelPasswordRequired", comboBoxLanguage.SelectedIndex);
            labelLastAttendance.Text = Lang.GetLang("labelLastAttendance", comboBoxLanguage.SelectedIndex);
            labelSystemMessage.Text = Lang.GetLang("labelSystemMessage", comboBoxLanguage.SelectedIndex);
            labelOfflineMode.Text = Lang.GetLang("labelOfflineMode", comboBoxLanguage.SelectedIndex);
            buttonAuthentication.Text = Lang.GetLang("buttonAuthentication", comboBoxLanguage.SelectedIndex);
            buttonPunchAttendance.Text = Lang.GetLang("buttonPunchAttendance", comboBoxLanguage.SelectedIndex);
            buttonClose.Text = Lang.GetLang("buttonClose", comboBoxLanguage.SelectedIndex);
            checkBoxUnmaskPassword.Text = Lang.GetLang("checkBoxUnmaskPassword", comboBoxLanguage.SelectedIndex);
        }

        private void FormInitialization()
        {
            try
            {
                COMMON = new Common();
                this.AcceptButton = buttonAuthentication;
                comboBoxLanguage.Items.Clear();
                foreach (string Language in Lang.SupportedLanguage()) { comboBoxLanguage.Items.Add(Language); } // Add supported language
                comboBoxLanguage.SelectedIndex = 0;
                labelLastAttendanceTime.Text = null;
                labelLastAttendanceBranch.Text = null;
                groupBoxAction.Enabled = false;
                groupBoxBranch.Enabled = true;
                groupBoxUser.Enabled = true;
                groupBoxPassword.Enabled = true;
                checkBoxUnmaskPassword.Checked = false;
                textBoxPassword.UseSystemPasswordChar = true;
                textBoxSystemMessage.Clear();
                textBoxPassword.Clear();
                logOffToolStripMenuItem.Enabled = false;
                userToolStripMenuItem.Enabled = false;
                if (CoreKernel.GetExecutionMode() == "Offline") // offline mode detected
                {
                    labelOfflineMode.Visible = true;
                }
                else // since is not offline must be online
                {
                    COMMONDB = new CommonDB(CoreKernel.GetMySQLConnString());
                }
            }
            catch (Exception ex) { COMMON.DisplayError(ex.Message); }
        }

        private void FetchAllBranch()
        {
            try
            {
                comboBoxBranch.DataSource = null;
                comboBoxBranch.Items.Clear();
                dr = COMMONDB.MySQLExecuteReader(@" SELECT `IDBranch`, `BranchCode`, `BranchName`
                                                FROM `hr_branch`
                                                WHERE `BranchStatus` = 'Y'
                                                ORDER BY `BranchCode` ASC;");
                for (Count = 0; dr.Read(); Count++)
                {
                    BranchList.Add(new Branch
                    {
                        IDBranch = dr.GetInt32(0),
                        BranchCode = dr.GetValue(1).ToString(),
                        BranchName = "[" + dr.GetValue(1).ToString() + "] " + dr.GetValue(2).ToString()
                    });
                }

                if (Count > 0)
                {
                    comboBoxBranch.DataSource = BranchList;
                    comboBoxBranch.DisplayMember = "BranchName";
                    comboBoxBranch.SelectedIndex = 0;
                }
                else
                {
                    throw new Exception(Lang.GetLang("ErrMsgNoBranchData", comboBoxLanguage.SelectedIndex));
                }
            }
            catch (Exception ex)
            {
                COMMON.DisplayError(ex.Message);
                textBoxSystemMessage.Text += "[" + DateTime.Now.ToString() + "] " + ex.Message + Environment.NewLine;
            }
        }

        private void GetUserList(int x)
        {
            List<User> TempUL = new List<User>();
            foreach (User EachUser in AllUserList) { if (EachUser.IDBranch == x) { TempUL.Add(EachUser); } }
            comboBoxUser.DataSource = null;
            comboBoxUser.Items.Clear();
            comboBoxUser.DataSource = TempUL;
            comboBoxUser.DisplayMember = "UserAcc";
        }

        private void buttonPunchAttendance_Click(object sender, EventArgs e)
        {
            //INSERT INTO `hr_att` SELECT NULL, 744, 2012, 3, '2012/03/0000', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'Created By System'
            //FROM DUAL WHERE NOT EXISTS (SELECT * FROM `hr_att`  WHERE `FKIDUser` = 744 AND `ForYear` = 2012 AND `ForMonth` = 3)
        }

        private void buttonTodayAttendanceHistory_Click(object sender, EventArgs e)
        {
            User selectedUser = comboBoxUser.SelectedItem as User;
            CWF.OpenForm(this, new FrmHistory(selectedUser.IDUser), true, true);
        }

        private void comboBoxBranch_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void buttonAuthentication_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("You don't have any checklist or punchcard is found for this month");
            try
            {
                if (textBoxPassword.TextLength == 0)
                {
                    throw new Exception(Lang.GetLang("ErrMsgPasswordEmpty", comboBoxLanguage.SelectedIndex));
                }

                if (comboBoxUser.SelectedIndex >= 0)
                {
                    User selectedUser = comboBoxUser.SelectedItem as User; // to get cbbox selected iduser
                    if (CE.Encrypt(textBoxPassword.Text) == selectedUser.Password.ToString())
                    {
                        userToolStripMenuItem.Enabled = true;
                        groupBoxBranch.Enabled = false;
                        groupBoxUser.Enabled = false;
                        groupBoxAction.Enabled = true;
                        groupBoxPassword.Enabled = false;
                        logOffToolStripMenuItem.Enabled = true;
                        this.AcceptButton = buttonPunchAttendance;
                        textBoxPassword.Clear();
                        WritingAttendanceInfo();
                    }
                    else
                    {
                        throw new Exception("Password No OK");
                    }
                }
            }
            catch (Exception ex)
            {
                COMMON.DisplayError(ex.Message);
                textBoxSystemMessage.Text += "[" + DateTime.Now.ToString() + "] " + ex.Message + Environment.NewLine;
            }
        }

        private void logOffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormInitialization();
        }

        private void WritingAttendanceInfo()
        {
            labelLastAttendanceTime.Text = null;
            if (comboBoxUser.SelectedIndex >= 0)
            {
                User selectedUser = comboBoxUser.SelectedItem as User; // to get cbbox selected iduser
                string sql = string.Format(@"SELECT hrac.`CheckTime`, hrb.`BranchCode`
                    FROM `hr_att_check` AS hrac
                    INNER JOIN `hr_att` AS hra ON hra.`IDAtt` = hrac.`FKIDAtt`
                    INNER JOIN `hr_branch` AS hrb ON hrb.`IDBranch` = hrac.`FKIDBranch`
                    INNER JOIN ( SELECT MAX(`CheckTime`) AS `Last` FROM `hr_att_check`) AS LastValue ON hrac.`CheckTime` = LastValue.`Last`
                    WHERE hra.`FKIDUser` = {0}
                    LIMIT 1;", selectedUser.IDUser);
                dr = COMMONDB.MySQLExecuteReader(sql);
                if (dr.Read())
                {
                    labelLastAttendanceTime.Text = dr.GetValue(0).ToString();
                    labelLastAttendanceBranch.Text = dr.GetValue(1).ToString();
                }
            }
        }

        private void FetchLastCheck(int IDUser)
        {
            string sql = string.Format(@"SELECT hrac.`CheckTime`, hrb.`BranchCode`
                    FROM `hr_att_check` AS hrac
                    INNER JOIN `hr_att` AS hra ON hra.`IDAtt` = hrac.`FKIDAtt`
                    INNER JOIN `hr_branch` AS hrb ON hrb.`IDBranch` = hrac.`FKIDBranch`
                    INNER JOIN ( SELECT MAX(`CheckTime`) AS `Last` FROM `hr_att_check`) AS LastValue ON hrac.`CheckTime` = LastValue.`Last`
                    WHERE hra.`FKIDUser` = {0};", IDUser);
        }

        private void checkBoxUnmaskPassword_CheckedChanged(object sender, EventArgs e)
        {
            textBoxPassword.UseSystemPasswordChar = (checkBoxUnmaskPassword.Checked == false) ? true : false;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void comboBoxBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            Branch selectedBranch = comboBoxBranch.SelectedItem as Branch; // to get cbbox selected iduser
            GetUserList(selectedBranch.IDBranch);
        }
    }
}
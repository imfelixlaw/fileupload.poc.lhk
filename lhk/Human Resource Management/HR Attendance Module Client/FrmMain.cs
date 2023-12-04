using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Language.Client;
using Felix.Library.Common;
using Felix.Library.Common.DB;

namespace HR_Attendance_Module_Client
{
    public partial class FrmMain : Form
    {
        private ClientLanguage Lang = new ClientLanguage("FrmMain");
        private CommonDB COMMONDB = null;
        private Common COMMON = null;
        public FrmMain()
        {
            InitializeComponent();
            this.Icon = Resource.AppIcon;
            this.labelVersion.Text = Application.ProductVersion;
            FormInitialization();
            LanguageInitialization();
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
        }

        private void FormInitialization()
        {
            try
            {
                COMMON = new Common();
                string[] SupportedLanguage = Lang.SupportedLanguage();
                foreach (string Language in SupportedLanguage) { comboBoxLanguage.Items.Add(Language); } // Add supported language
                comboBoxLanguage.SelectedIndex = 0;
                groupBoxAction.Enabled = false;
                this.AcceptButton = buttonAuthentication;
                labelLastAttendanceTime.Text = null;
                labelLastAttendanceMode.Text = null;
                if (Program.__ExecutionMode == "Offline") // offline mode detected
                {
                    labelOfflineMode.Visible = true;
                }
                else // since is not offline must be online
                {
                    COMMONDB = new CommonDB(Program.__MySQLConnString);
                }
                ComboBoxBranchGenerator();

            }
            catch (Exception ex) { COMMON.DisplayError(ex.Message); }
        }

        private void ComboBoxBranchGenerator()
        {
            comboBoxBranch.Items.Clear();
        }
    }
}
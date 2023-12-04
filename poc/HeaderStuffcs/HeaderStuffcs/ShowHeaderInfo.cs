using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Office = Microsoft.Office.Core;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace HeaderStuffcs
{
    partial class ShowHeaderInfo
    {
        #region Form Region Factory

        [Microsoft.Office.Tools.Outlook.FormRegionMessageClass(Microsoft.Office.Tools.Outlook.FormRegionMessageClassAttribute.Note)]
        [Microsoft.Office.Tools.Outlook.FormRegionName("HeaderStuffcs.ShowHeaderInfo")]
        public partial class ShowHeaderInfoFactory
        {
            // Occurs before the form region is initialized.
            // To prevent the form region from appearing, set e.Cancel to true.
            // Use e.OutlookItem to get a reference to the current Outlook item.
            private void ShowHeaderInfoFactory_FormRegionInitializing(object sender, Microsoft.Office.Tools.Outlook.FormRegionInitializingEventArgs e)
            {
            }
        }

        #endregion
        string emailbody, emailheader;
        string sql_ip, sql_hyperlink;
        Outlook.MailItem curMail;
        System.Data.OleDb.OleDbConnection con;
        System.Data.OleDb.OleDbCommand command;
        System.Data.OleDb.OleDbDataReader reader;
        System.Data.OleDb.OleDbDataAdapter adapter;
        List<string> header_database = new List<string>();
        List<string> hyperlink_database = new List<string>();

        private void button1_Click(object sender, EventArgs e)
        {
            // get a reference to our mail item
            curMail = (Outlook.MailItem)this.OutlookItem;
            emailheader = ((string)curMail.PropertyAccessor.GetProperty("http://schemas.microsoft.com/mapi/proptag/0x007D001E"));
            emailbody = (((Microsoft.Office.Interop.Outlook.MailItem)this.OutlookItem).Body);
            init();
        }

        public void init()
        {
            try
            {
                con = new System.Data.OleDb.OleDbConnection();
                con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/db/HeaderStuffcs.accdb;Persist Security Info=False;";
                con.Open();
                adapter = new System.Data.OleDb.OleDbDataAdapter();
                //fetch official ip table
                sql_ip = "SELECT ip FROM ip;";

                command = new System.Data.OleDb.OleDbCommand(sql_ip, con);
                reader = command.ExecuteReader();
                //read ip address database
                while (reader.Read())
                {
                    header_database.Add(reader["ip"].ToString());
                }
                
                //fetch custom ip table
                sql_ip = "SELECT ip FROM c_ip;";

                command = new System.Data.OleDb.OleDbCommand(sql_ip, con);
                reader = command.ExecuteReader();
                //read ip address database
                while (reader.Read())
                {
                    header_database.Add(reader["ip"].ToString());
                }

                //fetch official hyperlink table
                sql_hyperlink = "SELECT link FROM hyperlink;";

                command = new System.Data.OleDb.OleDbCommand(sql_hyperlink, con);
                reader = command.ExecuteReader();
                //read hyperlink database
                while (reader.Read())
                {
                    hyperlink_database.Add(reader["link"].ToString());
                }

                //fetch custom hyperlink table
                sql_hyperlink = "SELECT link FROM c_hyperlink;";

                command = new System.Data.OleDb.OleDbCommand(sql_hyperlink, con);
                reader = command.ExecuteReader();
                //read hyperlink database
                while (reader.Read())
                {
                    hyperlink_database.Add(reader["link"].ToString());
                }
                con.Close();

                //check header
                Boolean k = check_header(header_database);
                //check hyperlink
                Boolean o = check_hyperLink(hyperlink_database);
                DialogResult result;

                if (k)
                {
                    if (o)
                    {
                        MessageBox.Show("The mail is safe to be open", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                    else
                    {
                        result = MessageBox.Show("The sender is safe but contain non-safe contents, do you want to block unsafe contents", "Warning Message", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        if (result == DialogResult.Yes)
                        {
                            //get current body
                            string body = curMail.Body.ToString();

                            //replace string
                            foreach (string r in hyperlink_database)
                            {
                                body = Regex.Replace(body, @r, "[BLOCKED]");
                            }
                            //set current body
                            curMail.Body = body;
                        }
                    }
                }
                else
                {
                    if (o)
                    {
                        MessageBox.Show("The sender is non-safe but no unsafe contents", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    }
                    else
                    {
                        result = MessageBox.Show("The sender is blacklisted! \n It may contain phishing link, do you want to delete it? ", "Warning Message", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        if (result == DialogResult.Yes)
                        {
                            Outlook._Application outlookApp = new Outlook.Application();
                            Outlook.MAPIFolder destFolder = (Outlook.MAPIFolder)outlookApp.Session.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderDeletedItems);
                            curMail.Move(destFolder);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public Boolean check_header(List<string> header_db)
        {
            List<string> headerlist = new List<string>();
            Boolean copy = false;
            int counter = 0;
            char pw;
            CharEnumerator charEnum = emailheader.GetEnumerator();
            StringBuilder list = new StringBuilder();

            //extract ip address
            while (charEnum.MoveNext())
            {
                pw = Convert.ToChar(emailheader[counter]);
                if (pw.Equals('['))
                {
                    copy = true;
                    
                }
                if (copy)
                {
                    list.Append(pw.ToString());
                }
                if (pw.Equals(']'))
                {
                    copy = false;
                    headerlist.Add(list.ToString());
                    list.Clear();
                }
                counter++;
            }

            //test ip and database
            foreach (string r in headerlist)
            {
                foreach (string s in header_db)
                {
                    //no safe
                    if (s == r)
                    {
                        return false;
                    }
                }
            }
            //safe
            return true;
        }

        public Boolean check_hyperLink(List<string> body_db)
        {
            string[] bodylist = Regex.Split(emailbody, "\r\n");
            foreach (string r in bodylist)
            {
                foreach (string s in body_db)
                {
                    if (Regex.IsMatch(r, s))
                    {
                        return false;
                    }
                }
            }
            //safe
            return true;
        }
    }
}
       


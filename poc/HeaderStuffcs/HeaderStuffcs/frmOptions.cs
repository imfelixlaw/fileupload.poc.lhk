using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Net;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace HeaderStuffcs
{
    public partial class frmOptions : Form
    {
        public frmOptions()
        {
            InitializeComponent();
        }

        private bool IsNumeric(string chkNumeric)
        {
            int intOutVal;
            bool isValidNumeric = false;
            isValidNumeric = int.TryParse(chkNumeric, out intOutVal);
            return isValidNumeric;
        }

        private int storeIP(string ipformat, string iptable)
        {
            try
            {
                string sql_ip;
                System.Data.OleDb.OleDbConnection con;
                System.Data.OleDb.OleDbCommand command;
                System.Data.OleDb.OleDbDataReader reader;
                StringBuilder stb = new StringBuilder();

                con = new System.Data.OleDb.OleDbConnection();
                con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/db/HeaderStuffcs.accdb;Persist Security Info=False;";
                con.Open();
                //check official table
                sql_ip = "SELECT ip FROM ip;";
                
                command = new System.Data.OleDb.OleDbCommand(sql_ip, con);
                reader = command.ExecuteReader();
                //read ip address database
                while (reader.Read())
                {
                    if (reader["ip"].ToString() == ipformat)
                    {
                        command.Dispose();
                        con.Close();
                        return 0;
                    }
                }

                //check custom table
                sql_ip = "SELECT ip FROM c_ip;";

                command = new System.Data.OleDb.OleDbCommand(sql_ip, con);
                reader = command.ExecuteReader();
                //read ip address database
                while (reader.Read())
                {
                    if (reader["ip"].ToString() == ipformat)
                    {
                        command.Dispose();
                        con.Close();
                        return 0;
                    }
                }

                stb.Append("INSERT INTO " + iptable + " ([ip]) VALUES('" + ipformat + "')");
                command = con.CreateCommand();
                command.CommandText = stb.ToString();
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
                command.Dispose();
                con.Close();
                return 1;
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            catch (OverflowException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            return 0;
        }

        private void btnAddIP_Click(object sender, EventArgs e)
        {
            try
            {
                // var
                string strIP1, strIP2, strIP3, strIP4, ipformat;
                int iip1, iip2, iip3, iip4;
                strIP1 = ip1.Text.Trim();
                strIP2 = ip2.Text.Trim();
                strIP3 = ip3.Text.Trim();
                strIP4 = ip4.Text.Trim();

                //test empty
                if( strIP1 == string.Empty ||strIP2 == string.Empty ||strIP3 == string.Empty ||strIP4 == string.Empty )
                {
                    MessageBox.Show("IP cannot be empty");
                }
                else 
                {
                    //test numeric
                    if(IsNumeric(strIP1) && IsNumeric(strIP2) && IsNumeric(strIP3) && IsNumeric(strIP4))
                    {
                        iip1 = Convert.ToInt32(strIP1);
                        iip2 = Convert.ToInt32(strIP2);
                        iip3 = Convert.ToInt32(strIP3);
                        iip4 = Convert.ToInt32(strIP4);
                        //test range
                        if (iip1 < 0 || iip1 > 255 || iip2 < 0 || iip2 > 255 || iip3 < 0 || iip3 > 255 || iip4 < 0 || iip4 > 255)
                        {
                            MessageBox.Show("IP cannot small then 0 or great then 255");
                        }
                        else
                        {
                            ipformat = "[" + strIP1 + "." + strIP2 + "." + strIP3 + "." + strIP4 + "]";
                            if (storeIP(ipformat, "c_ip") == 0)
                            {
                                MessageBox.Show("IP address : " + ipformat + " is already exist.");
                            }
                            else
                            {
                                ip1.ResetText();
                                ip2.ResetText();
                                ip3.ResetText();
                                ip4.ResetText();
                                MessageBox.Show("IP address : " + ipformat + " is add successfully");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("IP only accept number from 1 to 255");
                    }
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            catch (OverflowException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private int storeHyper(string strHyper, string hypertable)
        {
            try
            {
                string sql_hyper;
                System.Data.OleDb.OleDbConnection con;
                System.Data.OleDb.OleDbCommand command;
                System.Data.OleDb.OleDbDataReader reader;
                StringBuilder stb = new StringBuilder();

                //test numeric
                con = new System.Data.OleDb.OleDbConnection();
                con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/db/HeaderStuffcs.accdb;Persist Security Info=False;";
                con.Open();

                //check official table
                sql_hyper = "SELECT link FROM hyperlink;";
                command = new System.Data.OleDb.OleDbCommand(sql_hyper, con);
                reader = command.ExecuteReader();
                //read ip address database
                while (reader.Read())
                {
                    if (reader["link"].ToString() == strHyper)
                    {
                        command.Dispose();
                        con.Close();
                        return 0;
                    }
                }
                //check custom table
                sql_hyper = "SELECT link FROM c_hyperlink;";
                command = new System.Data.OleDb.OleDbCommand(sql_hyper, con);
                reader = command.ExecuteReader();
                //read ip address database
                while (reader.Read())
                {
                    if (reader["link"].ToString() == strHyper)
                    {
                        command.Dispose();
                        con.Close();
                        return 0;
                    }
                }

                stb.Append("INSERT INTO " + hypertable + " ([link]) VALUES('" + strHyper + "')");
                command = con.CreateCommand();
                command.CommandText = stb.ToString();
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
                command.Dispose();
                con.Close();
                return 1;
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            catch (OverflowException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            return 0;
        }

        private void btnAddHyper_Click(object sender, EventArgs e)
        {
            try
            {
                // var
                string strHyper;
                strHyper = hyper1.Text.Trim();

                //test empty
                if (strHyper == string.Empty)
                {
                    MessageBox.Show("Link cannot be empty");
                }
                else
                {
                    if (storeHyper(strHyper, "c_hyperlink") == 0)
                    {
                        MessageBox.Show("Link address : " + strHyper + " is exist...");
                    }
                    else
                    {
                        hyper1.ResetText();
                        MessageBox.Show("Link address : " + strHyper + " is add successfully...");
                    }
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            catch (OverflowException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> ipList, hyperList;
                string url_ip, url_hyper, txt_ip, txt_hyper;
                int ic, hc;
                Uri uri_ip, uri_hyper;
                WebRequest req_ip, req_hyper;
                WebResponse resp_ip, resp_hyper;
                Stream stream_ip, stream_hyper;
                StreamReader sr_ip, sr_hyper;

                lblUpdateStatus.Text = "Locating update server...";
                //progress bar
                UpdateProgressBar.Minimum = 0;
                UpdateProgressBar.Maximum = 100;
                lblUpdateStatus.Text = "Contacting update server...";

                url_ip = "http://stuweb.cms.gre.ac.uk/~lk944/update/ip.txt";
                url_hyper = "http://stuweb.cms.gre.ac.uk/~lk944/update/link.txt";
                UpdateProgressBar.Value = 2;
                                
                uri_ip = new Uri(url_ip);
                uri_hyper = new Uri(url_hyper);
                UpdateProgressBar.Value = 3;
                lblUpdateStatus.Text = "Connecting update server...";

                req_ip = WebRequest.Create(uri_ip);
                req_hyper = WebRequest.Create(uri_hyper);
                UpdateProgressBar.Value = 4;

                resp_ip = req_ip.GetResponse();
                resp_hyper = req_hyper.GetResponse();
                UpdateProgressBar.Value = 6;

                stream_ip = resp_ip.GetResponseStream();
                stream_hyper = resp_hyper.GetResponseStream();
                UpdateProgressBar.Value = 7;

                sr_ip = new StreamReader(stream_ip);
                sr_hyper = new StreamReader(stream_hyper);
                lblUpdateStatus.Text = "Getting data from update server...";
                UpdateProgressBar.Value = 9;

                hyperList = new List<string>();
                ipList = new List<string>();
                lblUpdateStatus.Text = "Processing data from update server...";
                UpdateProgressBar.Value = 10;

                //fetch text file into list
                while ( ( txt_ip = sr_ip.ReadLine() ) != null )
                {
                    ipList.Add(txt_ip);
                }
                UpdateProgressBar.Value = 15;
                while ((txt_hyper = sr_hyper.ReadLine()) != null)
                {
                    hyperList.Add(txt_hyper);
                }
                UpdateProgressBar.Value = 20;

                ic = 1 / ipList.Count() * 40;
                hc = 1 / hyperList.Count() * 40;

                lblUpdateStatus.Text = "Updating data...";
                foreach (string s in ipList)
                {
                    storeIP(s, "ip");
                    UpdateProgressBar.Value = Convert.ToInt32(UpdateProgressBar.Value) + ic;
                }
                foreach (string s in hyperList)
                {
                    storeHyper(s, "hyperlink");
                    UpdateProgressBar.Value = Convert.ToInt32(UpdateProgressBar.Value) + hc;
                }
                UpdateProgressBar.Value = 100;
                lblUpdateStatus.Text = "Database is update successfully...";
                //store to database
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            catch (OverflowException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void frmOptions_Load(object sender, EventArgs e)
        {
            int frm_width = this.Width;
            int frm_height = this.Height;

            //Get the Width and Height (resolution) of the screen
            System.Windows.Forms.Screen src = System.Windows.Forms.Screen.PrimaryScreen;
            int src_height = src.Bounds.Height;
            int src_width = src.Bounds.Width;

            //put the form in the center
            this.Left = (src_width - frm_width) / 2;
            this.Top = (src_height - frm_height) / 2;
        }

        private void btnManage_Click(object sender, EventArgs e)
        {
            new frmManage().ShowDialog();
        }

    }
}

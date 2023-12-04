using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using classLibIniParser;

namespace FYP_Campaign_Project
{
    public partial class frmUpdate : Form
    {
        public frmUpdate()
        {
            InitializeComponent();
            try
            {
                IniReader updateini = new IniReader("update.ini") ;
                if (!updateini.Read()) throw new Exception("Configuration file read error");
                string l = updateini.Get("server", "url");
                //updateini.Write("server", "url", "test");
                //updateini.Save();
                MessageBox.Show(l);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

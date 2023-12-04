using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LHK_Attandance
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            MessageBox.Show(Program.__mysql_url);
            MessageBox.Show(Program.__mysql_usr);
            MessageBox.Show(Program.__mysql_pwd);
        }
    }
}

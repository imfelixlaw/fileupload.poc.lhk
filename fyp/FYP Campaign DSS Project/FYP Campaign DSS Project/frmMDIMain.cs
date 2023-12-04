using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FYP.Library.Common; // Common C# Custom Library

namespace FYP_Campaign_DSS_Project
{
    public partial class frmMDIMain : Form
    {
        CommonWinForm CWF = new CommonWinForm(); // Common C# Windows Form Custom Library
        CommonFunction CF = new CommonFunction(); // Common C# Function Custom Library
        public frmMDIMain()
        {
            this.Icon = Resource.Appicon;
            CWF.FormOpenAsMDIChild(this, new frmLogin(), true, true);
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CWF.FormOpenAsMDIChild(this, new frmOptions(), true, false);
        }

        private void projectListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CWF.FormOpenAsMDIChild(this, new frmProject(), true, false);
        }

        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CWF.FormCloseAllMDIChild(this);
        }

        private void addNewProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CWF.FormOpenAsMDIChild(this, new frmProject_AddNew(), true, false);
        }
    }
}

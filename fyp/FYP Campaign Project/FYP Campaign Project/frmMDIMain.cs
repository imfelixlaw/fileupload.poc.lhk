using System;
using System.Data;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace FYP_Campaign_Project
{
    public partial class frmMDIMain : Form
    {
        public frmMDIMain()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Exit this
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close(); // close this MDI
            // start new login form as new thread
            Thread newLoginFrm = new Thread(new ThreadStart(ThreadProc));
            newLoginFrm.Start(); // open the login form
        }

        private static void ThreadProc()
        {
            Application.Run(new frmLogin()); // this is to run login form
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAboutBox about = new frmAboutBox(); // show about from
            about.ShowDialog();
        }

        private void listAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListEvent ListEvent = new frmListEvent();
            ListEvent.MdiParent = this;
            ListEvent.Show();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdate Update = new frmUpdate();
            Update.MdiParent = this;
            Update.Show();
        }
    }
}

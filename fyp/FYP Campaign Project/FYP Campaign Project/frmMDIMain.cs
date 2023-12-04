using System;
using System.Data;
using System.Windows.Forms;
using System.Threading;

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
            // close this MDI
            this.Close();
            // start new login form
            Thread newLoginFrm = new Thread(new ThreadStart(ThreadProc));
            newLoginFrm.Start();
        }

        private static void ThreadProc()
        {
            Application.Run(new frmLogin()); // this is to run login form
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAboutBox about = new frmAboutBox();
            about.MdiParent = this;
            about.ShowDialog();
        }

        private void listAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListEvent ListEvent = new frmListEvent();
            ListEvent.MdiParent = this;
            ListEvent.Show();
        }
    }
}

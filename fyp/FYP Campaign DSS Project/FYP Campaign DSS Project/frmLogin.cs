using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using FYP.Library.Common;

namespace FYP_Campaign_DSS_Project
{
    public partial class frmLogin : Form
    {
        // Disable close button :: start
        [DllImport("User32")] private static extern int RemoveMenu(IntPtr hMenu, int nPosition, int wFlags);
        [DllImport("User32")] private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        [DllImport("User32")] private static extern int GetMenuItemCount(IntPtr hWnd);
        // Disable close button :: end
        CommonFunction CF = new CommonFunction();

        // to present a valid login, if not will exit the application
        bool ValidLogin = false;

        public frmLogin()
        {
            InitializeComponent();
            // using resource app icons, go to Resource.resx for details.
            this.Icon = Resource.Appicon;
            // Disable close button :: start
            IntPtr hMenu = GetSystemMenu(this.Handle, false);
            RemoveMenu(hMenu, GetMenuItemCount(hMenu) - 1, 0x400);
            // Disable close button :: end
        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            // if not valid login, i will exit the program
            if (!ValidLogin) { Application.Exit(); }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // close this form when btnExit is pressed
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text)) { throw new Exception("Username or password is empty."); }
                // the login is valid.
                ValidLogin = true;
                // since valid, then this will close.
                this.Close();
            }
            catch (Exception ex)
            {
                CF.DisplayError(ex.Message); // OMG there is some error!!!
            }
        }
    }
}

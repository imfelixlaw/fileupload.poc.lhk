using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using FYP.Library.Common;

namespace FYP_Campaign_DSS_Project
{
    public partial class frmProject_AddNew : Form
    {
        // Disable close button :: start
        [DllImport("User32")]
        private static extern int RemoveMenu(IntPtr hMenu, int nPosition, int wFlags);
        [DllImport("User32")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        [DllImport("User32")]
        private static extern int GetMenuItemCount(IntPtr hWnd);
        // Disable close button :: end
        CommonFunction CF = new CommonFunction();

        public frmProject_AddNew()
        {
            // Disable close button :: start
            IntPtr hMenu = GetSystemMenu(this.Handle, false);
            RemoveMenu(hMenu, GetMenuItemCount(hMenu) - 1, 0x400);
            // Disable close button :: end
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (string.IsNullOrEmpty(txtProjectName.Text)) { throw new Exception("Project name cannot be empty..."); }
                if (txtProjectName.TextLength < 10) { throw new Exception("Project name need at least 10 characters..."); }
                if (string.IsNullOrEmpty(cbManageBy.Text))
                {
                    // if user select cancel stop remaining action
                    if (MessageBox.Show("Project Administrator is empty, click \"OK\" will setting you as Project Administrator, or \"Cancel\" to select another user as Project Administrator.", "Empty Project Administrator", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.Cancel) { return; }
                }
                MessageBox.Show("OK");
            }
            catch (Exception ex)
            {
                CF.DisplayError(ex.Message); // OMG there is some error!!!
            }
        }
    }
}

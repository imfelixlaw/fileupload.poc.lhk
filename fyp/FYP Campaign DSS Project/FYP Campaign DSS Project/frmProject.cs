using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace FYP_Campaign_DSS_Project
{
    public partial class frmProject : Form
    {
        // Disable close button :: start
        [DllImport("User32")]
        private static extern int RemoveMenu(IntPtr hMenu, int nPosition, int wFlags);
        [DllImport("User32")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        [DllImport("User32")]
        private static extern int GetMenuItemCount(IntPtr hWnd);
        // Disable close button :: end

        public frmProject()
        {
            InitializeComponent();
            this.Icon = Resource.Appicon;
            // Disable close button :: start
            IntPtr hMenu = GetSystemMenu(this.Handle, false);
            RemoveMenu(hMenu, GetMenuItemCount(hMenu) - 1, 0x400);
            // Disable close button :: end
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HR_Attendance_Module_Control_Center
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void punchcardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(new FormAttendancePunchcard());
        }

        private void usersListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(new FormUserManagement());
        }

        //Show new form
        private bool ShowForm(Form Target)
        {
            Form[] MDIChild = this.MdiChildren; // get all of the MDI children in an array 
            foreach (Form Child in MDIChild)
            {
                if (Child.Name == Target.Name)
                {
                    Child.Activate();
                    return false;
                }
            }
            Target.MdiParent = this;
            Target.Show();
            return true;
        }

        private void requestListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(new FormAttendanceRequestList());
        }

        private void checklistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(new FormAttendanceChecklist());
        }
    }
}

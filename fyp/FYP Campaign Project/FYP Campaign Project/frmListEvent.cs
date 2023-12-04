using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FYP_Campaign_Project
{
    public partial class frmListEvent : Form
    {
        public frmListEvent()
        {
            InitializeComponent();
            dgvEvent.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListEvent_Load(object sender, EventArgs e)
        {
            btnDeleteEvent.Enabled = false;
            btnCloseEvent.Enabled = false;
            btnNewEvent.Enabled = false;
            btnAddRespone.Enabled = false;
            btnReplyRespone.Enabled = false;
            btnViewEventDetail.Enabled = false;
            btnDeleteRespone.Enabled = false;
            switch (Program.__UserPermission)
            {
                case Program._CONST_Permission_ADMIN:
                    btnDeleteEvent.Enabled = true;
                    btnDeleteRespone.Enabled = true;
                    btnCloseEvent.Enabled = true;
                    goto case Program._CONST_Permission_READWRITE;
                case Program._CONST_Permission_READWRITE:
                    btnNewEvent.Enabled = true;
                    btnAddRespone.Enabled = true;
                    btnReplyRespone.Enabled = true;
                    goto case Program._CONST_Permission_READ;
                case Program._CONST_Permission_READ:
                    btnViewEventDetail.Enabled = true;
                    break;
            }
        }

    }
}

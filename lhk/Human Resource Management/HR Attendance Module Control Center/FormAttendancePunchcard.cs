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
    public partial class FormAttendancePunchcard : Form
    {
        public FormAttendancePunchcard()
        {
            InitializeComponent();
            dataGridViewData.Rows[0].Cells[0].Value = "11/11/1111";
            dataGridViewData.Rows[0].Cells[1].Value = "1";
            dataGridViewData.Rows[0].Cells[2].Value = "12:34";
        }

        private void dataGridViewData_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewData.CurrentCell.ColumnIndex == 0)
            {
                buttonEditTime.Enabled = false;
            }
            else
            {
                int RowIndex = dataGridViewData.CurrentCell.RowIndex;
                int CellIndex = dataGridViewData.CurrentCell.ColumnIndex;
                if (dataGridViewData.Rows[RowIndex].Cells[CellIndex].Value == null)
                    buttonEditTime.Enabled = false;
                else
                    buttonEditTime.Enabled = true;

            }
            //Convert.ToInt32(dataGridViewData.SelectedIndex.ToString());
            //dataGridViewData.Rows
            //if(dataGridViewData)
        }
    }
}

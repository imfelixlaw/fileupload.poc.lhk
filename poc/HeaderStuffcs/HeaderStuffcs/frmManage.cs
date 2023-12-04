using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HeaderStuffcs
{
    public partial class frmManage : Form
    {
        System.Data.OleDb.OleDbConnection con;
        System.Data.OleDb.OleDbDataAdapter dAdapter, dAdapter2;
        System.Data.OleDb.OleDbCommandBuilder cBuilder, cBuilder2;
        //for hyperlink
        BindingSource bSource = new BindingSource();
        DataTable dTable = new DataTable();
        //for ip
        BindingSource bSource2 = new BindingSource();
        DataTable dTable2 = new DataTable();

        public frmManage()
        {
            InitializeComponent();
        }
        private void frmManage_Load(object sender, EventArgs e)
        {
            int frm_width = this.Width;
            int frm_height = this.Height;

            //Get the Width and Height (resolution) of the screen
            System.Windows.Forms.Screen src = System.Windows.Forms.Screen.PrimaryScreen;
            int src_height = src.Bounds.Height;
            int src_width = src.Bounds.Width;

            //put the form in the center
            this.Left = (src_width - frm_width) / 2;
            this.Top = (src_height - frm_height) / 2;

            con = new System.Data.OleDb.OleDbConnection();
            con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/db/HeaderStuffcs.accdb;Persist Security Info=False;";
            con.Open();
            string sql = "SELECT * FROM c_hyperlink;";
            string sql2 = "SELECT * FROM c_ip;";

            dAdapter = new System.Data.OleDb.OleDbDataAdapter(sql, con);
            cBuilder = new System.Data.OleDb.OleDbCommandBuilder(dAdapter);
            dAdapter.Fill(dTable);
            //the DataGridView
            dAdapter2 = new System.Data.OleDb.OleDbDataAdapter(sql2, con);
            cBuilder2 = new System.Data.OleDb.OleDbCommandBuilder(dAdapter2);
            dAdapter2.Fill(dTable2);

            //BindingSource to sync DataTable and DataGridView

            this.bSource.DataSource = dTable;
            this.gGvHyper.DataSource = bSource;
            this.gGvHyper.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.gGvHyper.Columns[0].Name = "Row ID";
            this.gGvHyper.Columns[1].Name = "Blacklisted Hyperlink";

            this.bSource2.DataSource = dTable2;
            this.gGvIP.DataSource = bSource2;
            this.gGvIP.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.gGvIP.Columns[0].Name = "Row ID";
            this.gGvIP.Columns[1].Name = "Blacklisted IP";

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.gGvHyper.SelectedRows.Count > 0)
            {
                this.gGvHyper.Rows.RemoveAt(this.gGvHyper.SelectedRows[0].Index);
                dAdapter.Update(dTable);
            }
            else
            {
                MessageBox.Show("Please select one row");
            }
        }

        private void btnDeleteIP_Click(object sender, EventArgs e)
        {
            if (this.gGvIP.SelectedRows.Count > 0)
            {
                this.gGvIP.Rows.RemoveAt(this.gGvIP.SelectedRows[0].Index);
                dAdapter2.Update(dTable2);
            }
            else
            {
                MessageBox.Show("Please select one row");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}

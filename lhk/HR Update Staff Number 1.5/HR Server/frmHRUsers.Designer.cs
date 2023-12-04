namespace HR_Server
{
    partial class frmHRUsers
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.statusbar = new System.Windows.Forms.StatusStrip();
            this.tsStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.gbUsersList = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.FKIDUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusbar.SuspendLayout();
            this.gbUsersList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // statusbar
            // 
            this.statusbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsStatus});
            this.statusbar.Location = new System.Drawing.Point(0, 270);
            this.statusbar.Name = "statusbar";
            this.statusbar.Size = new System.Drawing.Size(716, 22);
            this.statusbar.TabIndex = 0;
            this.statusbar.Text = "statusStrip1";
            // 
            // tsStatus
            // 
            this.tsStatus.Name = "tsStatus";
            this.tsStatus.Size = new System.Drawing.Size(38, 17);
            this.tsStatus.Text = "Status";
            // 
            // gbUsersList
            // 
            this.gbUsersList.Controls.Add(this.dataGridView1);
            this.gbUsersList.Location = new System.Drawing.Point(12, 12);
            this.gbUsersList.Name = "gbUsersList";
            this.gbUsersList.Size = new System.Drawing.Size(200, 244);
            this.gbUsersList.TabIndex = 1;
            this.gbUsersList.TabStop = false;
            this.gbUsersList.Text = "Users List";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FKIDUser,
            this.Name});
            this.dataGridView1.Location = new System.Drawing.Point(9, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(185, 219);
            this.dataGridView1.TabIndex = 0;
            // 
            // FKIDUser
            // 
            this.FKIDUser.HeaderText = "IDUser";
            this.FKIDUser.Name = "FKIDUser";
            this.FKIDUser.ReadOnly = true;
            this.FKIDUser.Visible = false;
            // 
            // Name
            // 
            this.Name.HeaderText = "Name";
            this.Name.Name = "Name";
            this.Name.ReadOnly = true;
            this.Name.Width = 120;
            // 
            // frmHRUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 292);
            this.Controls.Add(this.gbUsersList);
            this.Controls.Add(this.statusbar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmHRUsers";
            this.Text = "HR Users Management";
            this.statusbar.ResumeLayout(false);
            this.statusbar.PerformLayout();
            this.gbUsersList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusbar;
        private System.Windows.Forms.ToolStripStatusLabel tsStatus;
        private System.Windows.Forms.GroupBox gbUsersList;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn FKIDUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
    }
}
namespace FYP_Campaign_DSS_Project
{
    partial class frmProject
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProject));
            this.gSearchFilter = new System.Windows.Forms.GroupBox();
            this.chkActiveProjectOnly = new System.Windows.Forms.CheckBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearchFilter = new System.Windows.Forms.TextBox();
            this.lblFilterByName = new System.Windows.Forms.Label();
            this.gProjectList = new System.Windows.Forms.GroupBox();
            this.dgvProjectList = new System.Windows.Forms.DataGridView();
            this.gProjectAction = new System.Windows.Forms.GroupBox();
            this.btnProjectDelete = new System.Windows.Forms.Button();
            this.btnProjectView = new System.Windows.Forms.Button();
            this.btnProjectClose = new System.Windows.Forms.Button();
            this.btnProjectNew = new System.Windows.Forms.Button();
            this.gSystemAction = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblFormMessage = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Project = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ManageBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gSearchFilter.SuspendLayout();
            this.gProjectList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProjectList)).BeginInit();
            this.gProjectAction.SuspendLayout();
            this.gSystemAction.SuspendLayout();
            this.SuspendLayout();
            // 
            // gSearchFilter
            // 
            this.gSearchFilter.Controls.Add(this.chkActiveProjectOnly);
            this.gSearchFilter.Controls.Add(this.btnSearch);
            this.gSearchFilter.Controls.Add(this.txtSearchFilter);
            this.gSearchFilter.Controls.Add(this.lblFilterByName);
            this.gSearchFilter.Location = new System.Drawing.Point(12, 69);
            this.gSearchFilter.Name = "gSearchFilter";
            this.gSearchFilter.Size = new System.Drawing.Size(566, 71);
            this.gSearchFilter.TabIndex = 0;
            this.gSearchFilter.TabStop = false;
            this.gSearchFilter.Text = "Search Filter";
            // 
            // chkActiveProjectOnly
            // 
            this.chkActiveProjectOnly.AutoSize = true;
            this.chkActiveProjectOnly.Location = new System.Drawing.Point(161, 47);
            this.chkActiveProjectOnly.Name = "chkActiveProjectOnly";
            this.chkActiveProjectOnly.Size = new System.Drawing.Size(142, 17);
            this.chkActiveProjectOnly.TabIndex = 3;
            this.chkActiveProjectOnly.Text = "Only show active project";
            this.chkActiveProjectOnly.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(413, 18);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // txtSearchFilter
            // 
            this.txtSearchFilter.Location = new System.Drawing.Point(161, 21);
            this.txtSearchFilter.Name = "txtSearchFilter";
            this.txtSearchFilter.Size = new System.Drawing.Size(246, 20);
            this.txtSearchFilter.TabIndex = 1;
            // 
            // lblFilterByName
            // 
            this.lblFilterByName.AutoSize = true;
            this.lblFilterByName.Location = new System.Drawing.Point(83, 24);
            this.lblFilterByName.Name = "lblFilterByName";
            this.lblFilterByName.Size = new System.Drawing.Size(72, 13);
            this.lblFilterByName.TabIndex = 0;
            this.lblFilterByName.Text = "Filter by name";
            // 
            // gProjectList
            // 
            this.gProjectList.Controls.Add(this.dgvProjectList);
            this.gProjectList.Location = new System.Drawing.Point(12, 209);
            this.gProjectList.Name = "gProjectList";
            this.gProjectList.Size = new System.Drawing.Size(690, 341);
            this.gProjectList.TabIndex = 1;
            this.gProjectList.TabStop = false;
            this.gProjectList.Text = "Project List";
            // 
            // dgvProjectList
            // 
            this.dgvProjectList.AllowUserToAddRows = false;
            this.dgvProjectList.AllowUserToDeleteRows = false;
            this.dgvProjectList.AllowUserToResizeColumns = false;
            this.dgvProjectList.AllowUserToResizeRows = false;
            this.dgvProjectList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvProjectList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgvProjectList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProjectList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.ID,
            this.Project,
            this.StartDate,
            this.ManageBy});
            this.dgvProjectList.Location = new System.Drawing.Point(8, 17);
            this.dgvProjectList.MultiSelect = false;
            this.dgvProjectList.Name = "dgvProjectList";
            this.dgvProjectList.RowHeadersVisible = false;
            this.dgvProjectList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvProjectList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProjectList.ShowCellErrors = false;
            this.dgvProjectList.ShowCellToolTips = false;
            this.dgvProjectList.ShowEditingIcon = false;
            this.dgvProjectList.ShowRowErrors = false;
            this.dgvProjectList.Size = new System.Drawing.Size(676, 318);
            this.dgvProjectList.TabIndex = 0;
            // 
            // gProjectAction
            // 
            this.gProjectAction.Controls.Add(this.btnProjectDelete);
            this.gProjectAction.Controls.Add(this.btnProjectView);
            this.gProjectAction.Controls.Add(this.btnProjectClose);
            this.gProjectAction.Controls.Add(this.btnProjectNew);
            this.gProjectAction.Location = new System.Drawing.Point(12, 146);
            this.gProjectAction.Name = "gProjectAction";
            this.gProjectAction.Size = new System.Drawing.Size(566, 57);
            this.gProjectAction.TabIndex = 2;
            this.gProjectAction.TabStop = false;
            this.gProjectAction.Text = "Actions";
            // 
            // btnProjectDelete
            // 
            this.btnProjectDelete.Location = new System.Drawing.Point(388, 20);
            this.btnProjectDelete.Name = "btnProjectDelete";
            this.btnProjectDelete.Size = new System.Drawing.Size(102, 23);
            this.btnProjectDelete.TabIndex = 3;
            this.btnProjectDelete.Text = "Delete Project";
            this.btnProjectDelete.UseVisualStyleBackColor = true;
            // 
            // btnProjectView
            // 
            this.btnProjectView.Location = new System.Drawing.Point(172, 20);
            this.btnProjectView.Name = "btnProjectView";
            this.btnProjectView.Size = new System.Drawing.Size(102, 23);
            this.btnProjectView.TabIndex = 2;
            this.btnProjectView.Text = "View Project";
            this.btnProjectView.UseVisualStyleBackColor = true;
            // 
            // btnProjectClose
            // 
            this.btnProjectClose.Location = new System.Drawing.Point(280, 20);
            this.btnProjectClose.Name = "btnProjectClose";
            this.btnProjectClose.Size = new System.Drawing.Size(102, 23);
            this.btnProjectClose.TabIndex = 1;
            this.btnProjectClose.Text = "Close Project";
            this.btnProjectClose.UseVisualStyleBackColor = true;
            // 
            // btnProjectNew
            // 
            this.btnProjectNew.Location = new System.Drawing.Point(64, 20);
            this.btnProjectNew.Name = "btnProjectNew";
            this.btnProjectNew.Size = new System.Drawing.Size(102, 23);
            this.btnProjectNew.TabIndex = 0;
            this.btnProjectNew.Text = "New Project";
            this.btnProjectNew.UseVisualStyleBackColor = true;
            // 
            // gSystemAction
            // 
            this.gSystemAction.Controls.Add(this.btnRefresh);
            this.gSystemAction.Controls.Add(this.btnClose);
            this.gSystemAction.Location = new System.Drawing.Point(584, 69);
            this.gSystemAction.Name = "gSystemAction";
            this.gSystemAction.Size = new System.Drawing.Size(118, 134);
            this.gSystemAction.TabIndex = 3;
            this.gSystemAction.TabStop = false;
            this.gSystemAction.Text = "System";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(22, 51);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // lblFormMessage
            // 
            this.lblFormMessage.Location = new System.Drawing.Point(12, 9);
            this.lblFormMessage.Name = "lblFormMessage";
            this.lblFormMessage.Size = new System.Drawing.Size(690, 60);
            this.lblFormMessage.TabIndex = 4;
            this.lblFormMessage.Text = resources.GetString("lblFormMessage.Text");
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(22, 22);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // No
            // 
            this.No.HeaderText = "No";
            this.No.Name = "No";
            this.No.ReadOnly = true;
            this.No.Width = 40;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // Project
            // 
            this.Project.HeaderText = "Project";
            this.Project.Name = "Project";
            this.Project.ReadOnly = true;
            this.Project.Width = 350;
            // 
            // StartDate
            // 
            this.StartDate.HeaderText = "Start Date";
            this.StartDate.Name = "StartDate";
            this.StartDate.ReadOnly = true;
            // 
            // ManageBy
            // 
            this.ManageBy.HeaderText = "Manage By";
            this.ManageBy.Name = "ManageBy";
            this.ManageBy.ReadOnly = true;
            this.ManageBy.Width = 150;
            // 
            // frmProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 562);
            this.Controls.Add(this.lblFormMessage);
            this.Controls.Add(this.gSystemAction);
            this.Controls.Add(this.gProjectAction);
            this.Controls.Add(this.gProjectList);
            this.Controls.Add(this.gSearchFilter);
            this.Name = "frmProject";
            this.Text = "Project";
            this.gSearchFilter.ResumeLayout(false);
            this.gSearchFilter.PerformLayout();
            this.gProjectList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProjectList)).EndInit();
            this.gProjectAction.ResumeLayout(false);
            this.gSystemAction.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gSearchFilter;
        private System.Windows.Forms.Label lblFilterByName;
        private System.Windows.Forms.TextBox txtSearchFilter;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox gProjectList;
        private System.Windows.Forms.DataGridView dgvProjectList;
        private System.Windows.Forms.CheckBox chkActiveProjectOnly;
        private System.Windows.Forms.GroupBox gProjectAction;
        private System.Windows.Forms.Button btnProjectNew;
        private System.Windows.Forms.Button btnProjectDelete;
        private System.Windows.Forms.Button btnProjectView;
        private System.Windows.Forms.Button btnProjectClose;
        private System.Windows.Forms.GroupBox gSystemAction;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblFormMessage;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Project;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ManageBy;
    }
}
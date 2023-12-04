namespace FYP_Campaign_DSS_Project
{
    partial class frmProject_EventList
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
            this.gEventofProject = new System.Windows.Forms.GroupBox();
            this.txtProjectName = new System.Windows.Forms.TextBox();
            this.lblProjectName = new System.Windows.Forms.Label();
            this.gListofEvent = new System.Windows.Forms.GroupBox();
            this.dgvEventList = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDEvent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EventName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstimateCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CostExact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ratio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gAction = new System.Windows.Forms.GroupBox();
            this.btnEventNew = new System.Windows.Forms.Button();
            this.btnEventDelete = new System.Windows.Forms.Button();
            this.btnEventUpdateExactCost = new System.Windows.Forms.Button();
            this.btnEventUpdateRatio = new System.Windows.Forms.Button();
            this.btnEventInsertComment = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.gEventofProject.SuspendLayout();
            this.gListofEvent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEventList)).BeginInit();
            this.gAction.SuspendLayout();
            this.SuspendLayout();
            // 
            // gEventofProject
            // 
            this.gEventofProject.Controls.Add(this.txtProjectName);
            this.gEventofProject.Controls.Add(this.lblProjectName);
            this.gEventofProject.Location = new System.Drawing.Point(20, 16);
            this.gEventofProject.Name = "gEventofProject";
            this.gEventofProject.Size = new System.Drawing.Size(567, 56);
            this.gEventofProject.TabIndex = 0;
            this.gEventofProject.TabStop = false;
            this.gEventofProject.Text = "Event of Project";
            // 
            // txtProjectName
            // 
            this.txtProjectName.BackColor = System.Drawing.SystemColors.Window;
            this.txtProjectName.Location = new System.Drawing.Point(147, 22);
            this.txtProjectName.Name = "txtProjectName";
            this.txtProjectName.ReadOnly = true;
            this.txtProjectName.Size = new System.Drawing.Size(338, 20);
            this.txtProjectName.TabIndex = 1;
            // 
            // lblProjectName
            // 
            this.lblProjectName.AutoSize = true;
            this.lblProjectName.Location = new System.Drawing.Point(51, 25);
            this.lblProjectName.Name = "lblProjectName";
            this.lblProjectName.Size = new System.Drawing.Size(71, 13);
            this.lblProjectName.TabIndex = 0;
            this.lblProjectName.Text = "Project Name";
            // 
            // gListofEvent
            // 
            this.gListofEvent.Controls.Add(this.dgvEventList);
            this.gListofEvent.Location = new System.Drawing.Point(20, 78);
            this.gListofEvent.Name = "gListofEvent";
            this.gListofEvent.Size = new System.Drawing.Size(567, 333);
            this.gListofEvent.TabIndex = 1;
            this.gListofEvent.TabStop = false;
            this.gListofEvent.Text = "List of Event";
            // 
            // dgvEventList
            // 
            this.dgvEventList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEventList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.IDEvent,
            this.EventName,
            this.EstimateCost,
            this.CostExact,
            this.Ratio});
            this.dgvEventList.Location = new System.Drawing.Point(9, 18);
            this.dgvEventList.Name = "dgvEventList";
            this.dgvEventList.RowHeadersVisible = false;
            this.dgvEventList.ShowCellErrors = false;
            this.dgvEventList.ShowCellToolTips = false;
            this.dgvEventList.ShowEditingIcon = false;
            this.dgvEventList.ShowRowErrors = false;
            this.dgvEventList.Size = new System.Drawing.Size(548, 309);
            this.dgvEventList.TabIndex = 0;
            // 
            // No
            // 
            this.No.HeaderText = "No";
            this.No.Name = "No";
            this.No.Width = 40;
            // 
            // IDEvent
            // 
            this.IDEvent.HeaderText = "Event ID";
            this.IDEvent.Name = "IDEvent";
            this.IDEvent.ReadOnly = true;
            this.IDEvent.Visible = false;
            // 
            // EventName
            // 
            this.EventName.HeaderText = "Name";
            this.EventName.Name = "EventName";
            this.EventName.ReadOnly = true;
            this.EventName.Width = 200;
            // 
            // EstimateCost
            // 
            this.EstimateCost.HeaderText = "Cost (est)";
            this.EstimateCost.Name = "EstimateCost";
            this.EstimateCost.ReadOnly = true;
            // 
            // CostExact
            // 
            this.CostExact.HeaderText = "Cost (exact)";
            this.CostExact.Name = "CostExact";
            this.CostExact.ReadOnly = true;
            // 
            // Ratio
            // 
            this.Ratio.HeaderText = "Ratio";
            this.Ratio.Name = "Ratio";
            this.Ratio.ReadOnly = true;
            this.Ratio.Width = 80;
            // 
            // gAction
            // 
            this.gAction.Controls.Add(this.btnClose);
            this.gAction.Controls.Add(this.btnEventInsertComment);
            this.gAction.Controls.Add(this.btnEventUpdateRatio);
            this.gAction.Controls.Add(this.btnEventUpdateExactCost);
            this.gAction.Controls.Add(this.btnEventDelete);
            this.gAction.Controls.Add(this.btnEventNew);
            this.gAction.Location = new System.Drawing.Point(593, 16);
            this.gAction.Name = "gAction";
            this.gAction.Size = new System.Drawing.Size(111, 395);
            this.gAction.TabIndex = 2;
            this.gAction.TabStop = false;
            this.gAction.Text = "Action";
            // 
            // btnEventNew
            // 
            this.btnEventNew.Location = new System.Drawing.Point(6, 19);
            this.btnEventNew.Name = "btnEventNew";
            this.btnEventNew.Size = new System.Drawing.Size(99, 46);
            this.btnEventNew.TabIndex = 1;
            this.btnEventNew.Text = "New Event";
            this.btnEventNew.UseVisualStyleBackColor = true;
            // 
            // btnEventDelete
            // 
            this.btnEventDelete.Location = new System.Drawing.Point(6, 71);
            this.btnEventDelete.Name = "btnEventDelete";
            this.btnEventDelete.Size = new System.Drawing.Size(99, 46);
            this.btnEventDelete.TabIndex = 2;
            this.btnEventDelete.Text = "Delete Event";
            this.btnEventDelete.UseVisualStyleBackColor = true;
            // 
            // btnEventUpdateExactCost
            // 
            this.btnEventUpdateExactCost.Location = new System.Drawing.Point(6, 123);
            this.btnEventUpdateExactCost.Name = "btnEventUpdateExactCost";
            this.btnEventUpdateExactCost.Size = new System.Drawing.Size(99, 46);
            this.btnEventUpdateExactCost.TabIndex = 3;
            this.btnEventUpdateExactCost.Text = "Update Exact Cost";
            this.btnEventUpdateExactCost.UseVisualStyleBackColor = true;
            // 
            // btnEventUpdateRatio
            // 
            this.btnEventUpdateRatio.Location = new System.Drawing.Point(6, 175);
            this.btnEventUpdateRatio.Name = "btnEventUpdateRatio";
            this.btnEventUpdateRatio.Size = new System.Drawing.Size(99, 46);
            this.btnEventUpdateRatio.TabIndex = 4;
            this.btnEventUpdateRatio.Text = "Update Ratio";
            this.btnEventUpdateRatio.UseVisualStyleBackColor = true;
            // 
            // btnEventInsertComment
            // 
            this.btnEventInsertComment.Location = new System.Drawing.Point(6, 227);
            this.btnEventInsertComment.Name = "btnEventInsertComment";
            this.btnEventInsertComment.Size = new System.Drawing.Size(99, 46);
            this.btnEventInsertComment.TabIndex = 5;
            this.btnEventInsertComment.Text = "Insert Comment";
            this.btnEventInsertComment.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(6, 343);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(99, 46);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmProject_EventList
            // 
            this.AcceptButton = this.btnEventNew;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(725, 423);
            this.Controls.Add(this.gAction);
            this.Controls.Add(this.gListofEvent);
            this.Controls.Add(this.gEventofProject);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProject_EventList";
            this.Text = "Event List for {0}";
            this.gEventofProject.ResumeLayout(false);
            this.gEventofProject.PerformLayout();
            this.gListofEvent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEventList)).EndInit();
            this.gAction.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gEventofProject;
        private System.Windows.Forms.Label lblProjectName;
        private System.Windows.Forms.TextBox txtProjectName;
        private System.Windows.Forms.GroupBox gListofEvent;
        private System.Windows.Forms.DataGridView dgvEventList;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDEvent;
        private System.Windows.Forms.DataGridViewTextBoxColumn EventName;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstimateCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn CostExact;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ratio;
        private System.Windows.Forms.GroupBox gAction;
        private System.Windows.Forms.Button btnEventNew;
        private System.Windows.Forms.Button btnEventDelete;
        private System.Windows.Forms.Button btnEventUpdateExactCost;
        private System.Windows.Forms.Button btnEventUpdateRatio;
        private System.Windows.Forms.Button btnEventInsertComment;
        private System.Windows.Forms.Button btnClose;
    }
}
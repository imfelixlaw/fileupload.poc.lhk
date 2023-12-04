namespace FYP_Campaign_Project
{
    partial class frmListEvent
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
            this.dgvEvent = new System.Windows.Forms.DataGridView();
            this.gbEventStatus = new System.Windows.Forms.GroupBox();
            this.gbEventAction = new System.Windows.Forms.GroupBox();
            this.btnNewEvent = new System.Windows.Forms.Button();
            this.btnReplyRespone = new System.Windows.Forms.Button();
            this.btnCloseEvent = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDeleteEvent = new System.Windows.Forms.Button();
            this.btnAddRespone = new System.Windows.Forms.Button();
            this.btnViewEventDetail = new System.Windows.Forms.Button();
            this.gbEventList = new System.Windows.Forms.GroupBox();
            this.S = new System.Windows.Forms.GroupBox();
            this.dgRespone = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDeleteRespone = new System.Windows.Forms.Button();
            this.DGR_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGR_Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGR_Respone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DG_EventID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DG_EventName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DG_EventOwner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DG_EventCreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvent)).BeginInit();
            this.gbEventAction.SuspendLayout();
            this.gbEventList.SuspendLayout();
            this.S.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRespone)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvEvent
            // 
            this.dgvEvent.AllowUserToDeleteRows = false;
            this.dgvEvent.AllowUserToResizeColumns = false;
            this.dgvEvent.AllowUserToResizeRows = false;
            this.dgvEvent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvEvent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvEvent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DG_EventID,
            this.DG_EventName,
            this.DG_EventOwner,
            this.DG_EventCreateDate});
            this.dgvEvent.Location = new System.Drawing.Point(6, 19);
            this.dgvEvent.MultiSelect = false;
            this.dgvEvent.Name = "dgvEvent";
            this.dgvEvent.ReadOnly = true;
            this.dgvEvent.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvEvent.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dgvEvent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEvent.Size = new System.Drawing.Size(714, 219);
            this.dgvEvent.TabIndex = 1;
            // 
            // gbEventStatus
            // 
            this.gbEventStatus.Location = new System.Drawing.Point(744, 259);
            this.gbEventStatus.Name = "gbEventStatus";
            this.gbEventStatus.Size = new System.Drawing.Size(243, 273);
            this.gbEventStatus.TabIndex = 1;
            this.gbEventStatus.TabStop = false;
            this.gbEventStatus.Text = "Event Status";
            // 
            // gbEventAction
            // 
            this.gbEventAction.Controls.Add(this.btnDeleteRespone);
            this.gbEventAction.Controls.Add(this.btnNewEvent);
            this.gbEventAction.Controls.Add(this.btnReplyRespone);
            this.gbEventAction.Controls.Add(this.btnCloseEvent);
            this.gbEventAction.Controls.Add(this.btnClose);
            this.gbEventAction.Controls.Add(this.btnDeleteEvent);
            this.gbEventAction.Controls.Add(this.btnAddRespone);
            this.gbEventAction.Controls.Add(this.btnViewEventDetail);
            this.gbEventAction.Location = new System.Drawing.Point(744, 9);
            this.gbEventAction.Name = "gbEventAction";
            this.gbEventAction.Size = new System.Drawing.Size(240, 244);
            this.gbEventAction.TabIndex = 2;
            this.gbEventAction.TabStop = false;
            this.gbEventAction.Text = "Event Action";
            // 
            // btnNewEvent
            // 
            this.btnNewEvent.Location = new System.Drawing.Point(6, 145);
            this.btnNewEvent.Name = "btnNewEvent";
            this.btnNewEvent.Size = new System.Drawing.Size(112, 36);
            this.btnNewEvent.TabIndex = 6;
            this.btnNewEvent.Text = "Create New Event";
            this.btnNewEvent.UseVisualStyleBackColor = true;
            // 
            // btnReplyRespone
            // 
            this.btnReplyRespone.Location = new System.Drawing.Point(6, 61);
            this.btnReplyRespone.Name = "btnReplyRespone";
            this.btnReplyRespone.Size = new System.Drawing.Size(112, 36);
            this.btnReplyRespone.TabIndex = 4;
            this.btnReplyRespone.Text = "Reply to Respone";
            this.btnReplyRespone.UseVisualStyleBackColor = true;
            // 
            // btnCloseEvent
            // 
            this.btnCloseEvent.Location = new System.Drawing.Point(6, 103);
            this.btnCloseEvent.Name = "btnCloseEvent";
            this.btnCloseEvent.Size = new System.Drawing.Size(112, 36);
            this.btnCloseEvent.TabIndex = 5;
            this.btnCloseEvent.Text = "Close this Event";
            this.btnCloseEvent.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(124, 202);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(112, 36);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDeleteEvent
            // 
            this.btnDeleteEvent.Location = new System.Drawing.Point(124, 103);
            this.btnDeleteEvent.Name = "btnDeleteEvent";
            this.btnDeleteEvent.Size = new System.Drawing.Size(112, 36);
            this.btnDeleteEvent.TabIndex = 8;
            this.btnDeleteEvent.Text = "Delete this Event";
            this.btnDeleteEvent.UseVisualStyleBackColor = true;
            // 
            // btnAddRespone
            // 
            this.btnAddRespone.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAddRespone.Location = new System.Drawing.Point(6, 19);
            this.btnAddRespone.Name = "btnAddRespone";
            this.btnAddRespone.Size = new System.Drawing.Size(112, 36);
            this.btnAddRespone.TabIndex = 3;
            this.btnAddRespone.Text = "Add New Respone";
            this.btnAddRespone.UseVisualStyleBackColor = true;
            // 
            // btnViewEventDetail
            // 
            this.btnViewEventDetail.Location = new System.Drawing.Point(124, 19);
            this.btnViewEventDetail.Name = "btnViewEventDetail";
            this.btnViewEventDetail.Size = new System.Drawing.Size(112, 36);
            this.btnViewEventDetail.TabIndex = 7;
            this.btnViewEventDetail.Text = "View Event Details";
            this.btnViewEventDetail.UseVisualStyleBackColor = true;
            // 
            // gbEventList
            // 
            this.gbEventList.Controls.Add(this.dgvEvent);
            this.gbEventList.Location = new System.Drawing.Point(12, 9);
            this.gbEventList.Name = "gbEventList";
            this.gbEventList.Size = new System.Drawing.Size(726, 244);
            this.gbEventList.TabIndex = 3;
            this.gbEventList.TabStop = false;
            this.gbEventList.Text = "List of Event";
            // 
            // S
            // 
            this.S.Controls.Add(this.dgRespone);
            this.S.Location = new System.Drawing.Point(12, 259);
            this.S.Name = "S";
            this.S.Size = new System.Drawing.Size(726, 249);
            this.S.TabIndex = 2;
            this.S.TabStop = false;
            this.S.Text = "Event Respone";
            // 
            // dgRespone
            // 
            this.dgRespone.AllowUserToDeleteRows = false;
            this.dgRespone.AllowUserToResizeColumns = false;
            this.dgRespone.AllowUserToResizeRows = false;
            this.dgRespone.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgRespone.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgRespone.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGR_ID,
            this.DGR_Type,
            this.DGR_Respone,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.dgRespone.Location = new System.Drawing.Point(6, 19);
            this.dgRespone.MultiSelect = false;
            this.dgRespone.Name = "dgRespone";
            this.dgRespone.ReadOnly = true;
            this.dgRespone.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgRespone.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dgRespone.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgRespone.Size = new System.Drawing.Size(714, 219);
            this.dgRespone.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(12, 514);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(726, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "(Type) : R = Respone, RR = Reply to Respone";
            // 
            // btnDeleteRespone
            // 
            this.btnDeleteRespone.Location = new System.Drawing.Point(124, 61);
            this.btnDeleteRespone.Name = "btnDeleteRespone";
            this.btnDeleteRespone.Size = new System.Drawing.Size(112, 36);
            this.btnDeleteRespone.TabIndex = 10;
            this.btnDeleteRespone.Text = "Delete this Respone";
            this.btnDeleteRespone.UseVisualStyleBackColor = true;
            // 
            // DGR_ID
            // 
            this.DGR_ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DGR_ID.HeaderText = "ID";
            this.DGR_ID.Name = "DGR_ID";
            this.DGR_ID.ReadOnly = true;
            this.DGR_ID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DGR_ID.Width = 40;
            // 
            // DGR_Type
            // 
            this.DGR_Type.HeaderText = "Type";
            this.DGR_Type.Name = "DGR_Type";
            this.DGR_Type.ReadOnly = true;
            this.DGR_Type.Width = 40;
            // 
            // DGR_Respone
            // 
            this.DGR_Respone.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DGR_Respone.HeaderText = "Respone";
            this.DGR_Respone.Name = "DGR_Respone";
            this.DGR_Respone.ReadOnly = true;
            this.DGR_Respone.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DGR_Respone.Width = 370;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn3.HeaderText = "Respone By";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn4.HeaderText = "Date";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // DG_EventID
            // 
            this.DG_EventID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DG_EventID.HeaderText = "ID";
            this.DG_EventID.Name = "DG_EventID";
            this.DG_EventID.ReadOnly = true;
            this.DG_EventID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DG_EventID.Width = 40;
            // 
            // DG_EventName
            // 
            this.DG_EventName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DG_EventName.HeaderText = "Event Name";
            this.DG_EventName.Name = "DG_EventName";
            this.DG_EventName.ReadOnly = true;
            this.DG_EventName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DG_EventName.Width = 410;
            // 
            // DG_EventOwner
            // 
            this.DG_EventOwner.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DG_EventOwner.HeaderText = "CreateBy";
            this.DG_EventOwner.Name = "DG_EventOwner";
            this.DG_EventOwner.ReadOnly = true;
            this.DG_EventOwner.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // DG_EventCreateDate
            // 
            this.DG_EventCreateDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DG_EventCreateDate.HeaderText = "CreateDate";
            this.DG_EventCreateDate.Name = "DG_EventCreateDate";
            this.DG_EventCreateDate.ReadOnly = true;
            this.DG_EventCreateDate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // frmListEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(993, 541);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.S);
            this.Controls.Add(this.gbEventList);
            this.Controls.Add(this.gbEventAction);
            this.Controls.Add(this.gbEventStatus);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmListEvent";
            this.Text = "Event List";
            this.Load += new System.EventHandler(this.frmListEvent_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvent)).EndInit();
            this.gbEventAction.ResumeLayout(false);
            this.gbEventList.ResumeLayout(false);
            this.S.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgRespone)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEvent;
        private System.Windows.Forms.GroupBox gbEventStatus;
        private System.Windows.Forms.GroupBox gbEventAction;
        private System.Windows.Forms.Button btnViewEventDetail;
        private System.Windows.Forms.Button btnAddRespone;
        private System.Windows.Forms.Button btnDeleteEvent;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnCloseEvent;
        private System.Windows.Forms.Button btnReplyRespone;
        private System.Windows.Forms.Button btnNewEvent;
        private System.Windows.Forms.GroupBox gbEventList;
        private System.Windows.Forms.GroupBox S;
        private System.Windows.Forms.DataGridView dgRespone;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDeleteRespone;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGR_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGR_Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGR_Respone;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn DG_EventID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DG_EventName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DG_EventOwner;
        private System.Windows.Forms.DataGridViewTextBoxColumn DG_EventCreateDate;
    }
}
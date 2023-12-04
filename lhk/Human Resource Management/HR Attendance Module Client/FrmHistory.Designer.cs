namespace HR_Attendance_Module_Client
{
    partial class FrmHistory
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
            this.dataGridViewHistory = new System.Windows.Forms.DataGridView();
            this.IDAttCheck = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CheckTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.gbRequest = new System.Windows.Forms.GroupBox();
            this.btnChangeTime = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistory)).BeginInit();
            this.gbRequest.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewHistory
            // 
            this.dataGridViewHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDAttCheck,
            this.CheckTime});
            this.dataGridViewHistory.Location = new System.Drawing.Point(12, 52);
            this.dataGridViewHistory.Name = "dataGridViewHistory";
            this.dataGridViewHistory.RowHeadersVisible = false;
            this.dataGridViewHistory.ShowCellErrors = false;
            this.dataGridViewHistory.ShowCellToolTips = false;
            this.dataGridViewHistory.ShowEditingIcon = false;
            this.dataGridViewHistory.ShowRowErrors = false;
            this.dataGridViewHistory.Size = new System.Drawing.Size(176, 203);
            this.dataGridViewHistory.TabIndex = 0;
            // 
            // IDAttCheck
            // 
            this.IDAttCheck.HeaderText = "IDAttCheck";
            this.IDAttCheck.Name = "IDAttCheck";
            this.IDAttCheck.ReadOnly = true;
            this.IDAttCheck.Visible = false;
            // 
            // CheckTime
            // 
            this.CheckTime.HeaderText = "CheckTime";
            this.CheckTime.Name = "CheckTime";
            this.CheckTime.ReadOnly = true;
            this.CheckTime.Width = 150;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(359, 232);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(101, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // lblInfo
            // 
            this.lblInfo.Location = new System.Drawing.Point(12, 9);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(448, 40);
            this.lblInfo.TabIndex = 2;
            this.lblInfo.Text = "This show the today time record history, you may remove the time, but only take e" +
    "ffective after review by person in-charge.";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(14, 145);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(101, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // gbRequest
            // 
            this.gbRequest.Controls.Add(this.label2);
            this.gbRequest.Controls.Add(this.textBox1);
            this.gbRequest.Controls.Add(this.label1);
            this.gbRequest.Controls.Add(this.btnChangeTime);
            this.gbRequest.Controls.Add(this.btnDelete);
            this.gbRequest.Location = new System.Drawing.Point(202, 52);
            this.gbRequest.Name = "gbRequest";
            this.gbRequest.Size = new System.Drawing.Size(258, 174);
            this.gbRequest.TabIndex = 4;
            this.gbRequest.TabStop = false;
            this.gbRequest.Text = "Request";
            // 
            // btnChangeTime
            // 
            this.btnChangeTime.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnChangeTime.Location = new System.Drawing.Point(151, 145);
            this.btnChangeTime.Name = "btnChangeTime";
            this.btnChangeTime.Size = new System.Drawing.Size(101, 23);
            this.btnChangeTime.TabIndex = 4;
            this.btnChangeTime.Text = "Change Time";
            this.btnChangeTime.UseVisualStyleBackColor = true;
            this.btnChangeTime.Click += new System.EventHandler(this.btnChangeTime_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Reason";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(14, 32);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(238, 71);
            this.textBox1.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Request to ... for selected Check Time";
            // 
            // FrmHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(472, 270);
            this.ControlBox = false;
            this.Controls.Add(this.gbRequest);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dataGridViewHistory);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmHistory";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Check Time History";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistory)).EndInit();
            this.gbRequest.ResumeLayout(false);
            this.gbRequest.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewHistory;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.GroupBox gbRequest;
        private System.Windows.Forms.Button btnChangeTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDAttCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn CheckTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
    }
}
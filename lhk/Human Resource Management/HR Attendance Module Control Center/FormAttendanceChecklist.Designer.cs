namespace HR_Attendance_Module_Control_Center
{
    partial class FormAttendanceChecklist
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
            this.dataGridViewData = new System.Windows.Forms.DataGridView();
            this.groupBoxControl = new System.Windows.Forms.GroupBox();
            this.labelDeleteTime = new System.Windows.Forms.Label();
            this.buttonDeleteTime = new System.Windows.Forms.Button();
            this.buttonEditTime = new System.Windows.Forms.Button();
            this.labelEditTime = new System.Windows.Forms.Label();
            this.groupBoxInformation = new System.Windows.Forms.GroupBox();
            this.labelRemark = new System.Windows.Forms.Label();
            this.textBoxRemark = new System.Windows.Forms.TextBox();
            this.buttonSaveReasonCode = new System.Windows.Forms.Button();
            this.comboBoxReasonCode = new System.Windows.Forms.ComboBox();
            this.labelReasonCode = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxUser = new System.Windows.Forms.ComboBox();
            this.labelUser = new System.Windows.Forms.Label();
            this.comboBoxDefaultBranch = new System.Windows.Forms.ComboBox();
            this.labelDefaultBranch = new System.Windows.Forms.Label();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FKIDBranch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_IN1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IN1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_OUT1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OUT1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewData)).BeginInit();
            this.groupBoxControl.SuspendLayout();
            this.groupBoxInformation.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewData
            // 
            this.dataGridViewData.AllowUserToDeleteRows = false;
            this.dataGridViewData.AllowUserToResizeColumns = false;
            this.dataGridViewData.AllowUserToResizeRows = false;
            this.dataGridViewData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Date,
            this.FKIDBranch,
            this.ID_IN1,
            this.IN1,
            this.ID_OUT1,
            this.OUT1,
            this.WT,
            this.TT,
            this.Remark});
            this.dataGridViewData.Location = new System.Drawing.Point(12, 64);
            this.dataGridViewData.MultiSelect = false;
            this.dataGridViewData.Name = "dataGridViewData";
            this.dataGridViewData.ReadOnly = true;
            this.dataGridViewData.RowHeadersVisible = false;
            this.dataGridViewData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewData.ShowCellErrors = false;
            this.dataGridViewData.ShowCellToolTips = false;
            this.dataGridViewData.ShowEditingIcon = false;
            this.dataGridViewData.ShowRowErrors = false;
            this.dataGridViewData.Size = new System.Drawing.Size(445, 434);
            this.dataGridViewData.TabIndex = 9;
            // 
            // groupBoxControl
            // 
            this.groupBoxControl.Controls.Add(this.labelDeleteTime);
            this.groupBoxControl.Controls.Add(this.buttonDeleteTime);
            this.groupBoxControl.Controls.Add(this.buttonEditTime);
            this.groupBoxControl.Controls.Add(this.labelEditTime);
            this.groupBoxControl.Location = new System.Drawing.Point(463, 64);
            this.groupBoxControl.Name = "groupBoxControl";
            this.groupBoxControl.Size = new System.Drawing.Size(149, 121);
            this.groupBoxControl.TabIndex = 10;
            this.groupBoxControl.TabStop = false;
            this.groupBoxControl.Text = "Control";
            // 
            // labelDeleteTime
            // 
            this.labelDeleteTime.AutoSize = true;
            this.labelDeleteTime.Location = new System.Drawing.Point(15, 73);
            this.labelDeleteTime.Name = "labelDeleteTime";
            this.labelDeleteTime.Size = new System.Drawing.Size(109, 13);
            this.labelDeleteTime.TabIndex = 3;
            this.labelDeleteTime.Text = "Delete Selected Time";
            // 
            // buttonDeleteTime
            // 
            this.buttonDeleteTime.Location = new System.Drawing.Point(28, 89);
            this.buttonDeleteTime.Name = "buttonDeleteTime";
            this.buttonDeleteTime.Size = new System.Drawing.Size(107, 23);
            this.buttonDeleteTime.TabIndex = 2;
            this.buttonDeleteTime.Text = "Delete";
            this.buttonDeleteTime.UseVisualStyleBackColor = true;
            // 
            // buttonEditTime
            // 
            this.buttonEditTime.Location = new System.Drawing.Point(28, 37);
            this.buttonEditTime.Name = "buttonEditTime";
            this.buttonEditTime.Size = new System.Drawing.Size(107, 23);
            this.buttonEditTime.TabIndex = 1;
            this.buttonEditTime.Text = "Edit";
            this.buttonEditTime.UseVisualStyleBackColor = true;
            // 
            // labelEditTime
            // 
            this.labelEditTime.AutoSize = true;
            this.labelEditTime.Location = new System.Drawing.Point(15, 21);
            this.labelEditTime.Name = "labelEditTime";
            this.labelEditTime.Size = new System.Drawing.Size(96, 13);
            this.labelEditTime.TabIndex = 0;
            this.labelEditTime.Text = "Edit Selected Time";
            // 
            // groupBoxInformation
            // 
            this.groupBoxInformation.Controls.Add(this.labelRemark);
            this.groupBoxInformation.Controls.Add(this.textBoxRemark);
            this.groupBoxInformation.Controls.Add(this.buttonSaveReasonCode);
            this.groupBoxInformation.Controls.Add(this.comboBoxReasonCode);
            this.groupBoxInformation.Controls.Add(this.labelReasonCode);
            this.groupBoxInformation.Location = new System.Drawing.Point(463, 191);
            this.groupBoxInformation.Name = "groupBoxInformation";
            this.groupBoxInformation.Size = new System.Drawing.Size(149, 307);
            this.groupBoxInformation.TabIndex = 11;
            this.groupBoxInformation.TabStop = false;
            this.groupBoxInformation.Text = "Information";
            // 
            // labelRemark
            // 
            this.labelRemark.AutoSize = true;
            this.labelRemark.Location = new System.Drawing.Point(15, 56);
            this.labelRemark.Name = "labelRemark";
            this.labelRemark.Size = new System.Drawing.Size(44, 13);
            this.labelRemark.TabIndex = 6;
            this.labelRemark.Text = "Remark";
            // 
            // textBoxRemark
            // 
            this.textBoxRemark.Location = new System.Drawing.Point(18, 72);
            this.textBoxRemark.Multiline = true;
            this.textBoxRemark.Name = "textBoxRemark";
            this.textBoxRemark.Size = new System.Drawing.Size(117, 117);
            this.textBoxRemark.TabIndex = 5;
            // 
            // buttonSaveReasonCode
            // 
            this.buttonSaveReasonCode.Location = new System.Drawing.Point(60, 195);
            this.buttonSaveReasonCode.Name = "buttonSaveReasonCode";
            this.buttonSaveReasonCode.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveReasonCode.TabIndex = 4;
            this.buttonSaveReasonCode.Text = "Save";
            this.buttonSaveReasonCode.UseVisualStyleBackColor = true;
            // 
            // comboBoxReasonCode
            // 
            this.comboBoxReasonCode.FormattingEnabled = true;
            this.comboBoxReasonCode.Location = new System.Drawing.Point(18, 32);
            this.comboBoxReasonCode.Name = "comboBoxReasonCode";
            this.comboBoxReasonCode.Size = new System.Drawing.Size(117, 21);
            this.comboBoxReasonCode.TabIndex = 1;
            // 
            // labelReasonCode
            // 
            this.labelReasonCode.AutoSize = true;
            this.labelReasonCode.Location = new System.Drawing.Point(15, 16);
            this.labelReasonCode.Name = "labelReasonCode";
            this.labelReasonCode.Size = new System.Drawing.Size(72, 13);
            this.labelReasonCode.TabIndex = 0;
            this.labelReasonCode.Text = "Reason Code";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxUser);
            this.groupBox1.Controls.Add(this.labelUser);
            this.groupBox1.Controls.Add(this.comboBoxDefaultBranch);
            this.groupBox1.Controls.Add(this.labelDefaultBranch);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(600, 46);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select User";
            // 
            // comboBoxUser
            // 
            this.comboBoxUser.FormattingEnabled = true;
            this.comboBoxUser.Location = new System.Drawing.Point(342, 18);
            this.comboBoxUser.Name = "comboBoxUser";
            this.comboBoxUser.Size = new System.Drawing.Size(121, 21);
            this.comboBoxUser.TabIndex = 4;
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Location = new System.Drawing.Point(307, 21);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(29, 13);
            this.labelUser.TabIndex = 3;
            this.labelUser.Text = "User";
            // 
            // comboBoxDefaultBranch
            // 
            this.comboBoxDefaultBranch.FormattingEnabled = true;
            this.comboBoxDefaultBranch.Location = new System.Drawing.Point(122, 18);
            this.comboBoxDefaultBranch.Name = "comboBoxDefaultBranch";
            this.comboBoxDefaultBranch.Size = new System.Drawing.Size(121, 21);
            this.comboBoxDefaultBranch.TabIndex = 2;
            // 
            // labelDefaultBranch
            // 
            this.labelDefaultBranch.AutoSize = true;
            this.labelDefaultBranch.Location = new System.Drawing.Point(38, 21);
            this.labelDefaultBranch.Name = "labelDefaultBranch";
            this.labelDefaultBranch.Size = new System.Drawing.Size(78, 13);
            this.labelDefaultBranch.TabIndex = 1;
            this.labelDefaultBranch.Text = "Default Branch";
            // 
            // Date
            // 
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            this.Date.Width = 70;
            // 
            // FKIDBranch
            // 
            this.FKIDBranch.HeaderText = "Location";
            this.FKIDBranch.Name = "FKIDBranch";
            this.FKIDBranch.ReadOnly = true;
            this.FKIDBranch.Width = 50;
            // 
            // ID_IN1
            // 
            this.ID_IN1.HeaderText = "ID_IN1";
            this.ID_IN1.Name = "ID_IN1";
            this.ID_IN1.ReadOnly = true;
            this.ID_IN1.Visible = false;
            this.ID_IN1.Width = 25;
            // 
            // IN1
            // 
            this.IN1.HeaderText = "IN1";
            this.IN1.Name = "IN1";
            this.IN1.ReadOnly = true;
            this.IN1.Width = 40;
            // 
            // ID_OUT1
            // 
            this.ID_OUT1.HeaderText = "ID_OUT1";
            this.ID_OUT1.Name = "ID_OUT1";
            this.ID_OUT1.ReadOnly = true;
            this.ID_OUT1.Visible = false;
            this.ID_OUT1.Width = 25;
            // 
            // OUT1
            // 
            this.OUT1.HeaderText = "OUT1";
            this.OUT1.Name = "OUT1";
            this.OUT1.ReadOnly = true;
            this.OUT1.Width = 40;
            // 
            // WT
            // 
            this.WT.HeaderText = "WT";
            this.WT.Name = "WT";
            this.WT.ReadOnly = true;
            this.WT.Width = 40;
            // 
            // TT
            // 
            this.TT.HeaderText = "TT";
            this.TT.Name = "TT";
            this.TT.ReadOnly = true;
            this.TT.Width = 40;
            // 
            // Remark
            // 
            this.Remark.HeaderText = "Remark";
            this.Remark.Name = "Remark";
            this.Remark.ReadOnly = true;
            // 
            // FormAttendanceChecklist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 511);
            this.Controls.Add(this.dataGridViewData);
            this.Controls.Add(this.groupBoxControl);
            this.Controls.Add(this.groupBoxInformation);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormAttendanceChecklist";
            this.Text = "Attendance List :: Checklist";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewData)).EndInit();
            this.groupBoxControl.ResumeLayout(false);
            this.groupBoxControl.PerformLayout();
            this.groupBoxInformation.ResumeLayout(false);
            this.groupBoxInformation.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewData;
        private System.Windows.Forms.GroupBox groupBoxControl;
        private System.Windows.Forms.Label labelDeleteTime;
        private System.Windows.Forms.Button buttonDeleteTime;
        private System.Windows.Forms.Button buttonEditTime;
        private System.Windows.Forms.Label labelEditTime;
        private System.Windows.Forms.GroupBox groupBoxInformation;
        private System.Windows.Forms.Label labelRemark;
        private System.Windows.Forms.TextBox textBoxRemark;
        private System.Windows.Forms.Button buttonSaveReasonCode;
        private System.Windows.Forms.ComboBox comboBoxReasonCode;
        private System.Windows.Forms.Label labelReasonCode;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBoxUser;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.ComboBox comboBoxDefaultBranch;
        private System.Windows.Forms.Label labelDefaultBranch;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn FKIDBranch;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_IN1;
        private System.Windows.Forms.DataGridViewTextBoxColumn IN1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_OUT1;
        private System.Windows.Forms.DataGridViewTextBoxColumn OUT1;
        private System.Windows.Forms.DataGridViewTextBoxColumn WT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remark;

    }
}
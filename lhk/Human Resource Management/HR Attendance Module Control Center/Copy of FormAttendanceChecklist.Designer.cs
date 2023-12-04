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
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FKIDBranch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_IN1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IN1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_OUT1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OUT1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxControl = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxUser = new System.Windows.Forms.ComboBox();
            this.labelUser = new System.Windows.Forms.Label();
            this.comboBoxDefaultBranch = new System.Windows.Forms.ComboBox();
            this.labelDefaultBranch = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewData)).BeginInit();
            this.groupBoxControl.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
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
            // groupBoxControl
            // 
            this.groupBoxControl.Controls.Add(this.button3);
            this.groupBoxControl.Controls.Add(this.button2);
            this.groupBoxControl.Controls.Add(this.button1);
            this.groupBoxControl.Location = new System.Drawing.Point(463, 64);
            this.groupBoxControl.Name = "groupBoxControl";
            this.groupBoxControl.Size = new System.Drawing.Size(149, 121);
            this.groupBoxControl.TabIndex = 10;
            this.groupBoxControl.TabStop = false;
            this.groupBoxControl.Text = "Control";
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(37, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Approve";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(37, 49);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Verify";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(37, 78);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Check";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button5);
            this.groupBox2.Controls.Add(this.button6);
            this.groupBox2.Location = new System.Drawing.Point(463, 191);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(149, 85);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Reporting";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(37, 49);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 1;
            this.button5.Text = "PDF";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(37, 19);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 0;
            this.button6.Text = "Print";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Controls.Add(this.button7);
            this.groupBox3.Location = new System.Drawing.Point(463, 282);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(149, 85);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Manage";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(37, 49);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 1;
            this.button4.Text = "Close";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(37, 19);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 0;
            this.button7.Text = "Delete";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // FormAttendanceChecklist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 511);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dataGridViewData);
            this.Controls.Add(this.groupBoxControl);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormAttendanceChecklist";
            this.Text = "Managing Attendance List :: Checklist";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewData)).EndInit();
            this.groupBoxControl.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewData;
        private System.Windows.Forms.GroupBox groupBoxControl;
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
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button7;

    }
}
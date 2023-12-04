namespace HR_Attendance_Module_Control_Center
{
    partial class FormAttendance_EditTime
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxHour = new System.Windows.Forms.TextBox();
            this.textBoxMinute = new System.Windows.Forms.TextBox();
            this.labelDivider = new System.Windows.Forms.Label();
            this.textBoxCurrentValue = new System.Windows.Forms.TextBox();
            this.labelHHMM2 = new System.Windows.Forms.Label();
            this.labelHHMM1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelHHMM1);
            this.groupBox1.Controls.Add(this.textBoxCurrentValue);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(183, 51);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Current Value";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelHHMM2);
            this.groupBox2.Controls.Add(this.labelDivider);
            this.groupBox2.Controls.Add(this.textBoxMinute);
            this.groupBox2.Controls.Add(this.textBoxHour);
            this.groupBox2.Location = new System.Drawing.Point(12, 69);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(183, 54);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "New Value";
            // 
            // textBoxHour
            // 
            this.textBoxHour.Location = new System.Drawing.Point(90, 19);
            this.textBoxHour.Name = "textBoxHour";
            this.textBoxHour.Size = new System.Drawing.Size(20, 20);
            this.textBoxHour.TabIndex = 2;
            // 
            // textBoxMinute
            // 
            this.textBoxMinute.Location = new System.Drawing.Point(132, 19);
            this.textBoxMinute.Name = "textBoxMinute";
            this.textBoxMinute.Size = new System.Drawing.Size(20, 20);
            this.textBoxMinute.TabIndex = 3;
            // 
            // labelDivider
            // 
            this.labelDivider.AutoSize = true;
            this.labelDivider.Location = new System.Drawing.Point(116, 22);
            this.labelDivider.Name = "labelDivider";
            this.labelDivider.Size = new System.Drawing.Size(10, 13);
            this.labelDivider.TabIndex = 2;
            this.labelDivider.Text = ":";
            // 
            // textBoxCurrentValue
            // 
            this.textBoxCurrentValue.Location = new System.Drawing.Point(90, 19);
            this.textBoxCurrentValue.Name = "textBoxCurrentValue";
            this.textBoxCurrentValue.ReadOnly = true;
            this.textBoxCurrentValue.Size = new System.Drawing.Size(62, 20);
            this.textBoxCurrentValue.TabIndex = 2;
            // 
            // labelHHMM2
            // 
            this.labelHHMM2.AutoSize = true;
            this.labelHHMM2.Location = new System.Drawing.Point(21, 22);
            this.labelHHMM2.Name = "labelHHMM2";
            this.labelHHMM2.Size = new System.Drawing.Size(44, 13);
            this.labelHHMM2.TabIndex = 2;
            this.labelHHMM2.Text = "HH:MM";
            // 
            // labelHHMM1
            // 
            this.labelHHMM1.AutoSize = true;
            this.labelHHMM1.Location = new System.Drawing.Point(21, 22);
            this.labelHHMM1.Name = "labelHHMM1";
            this.labelHHMM1.Size = new System.Drawing.Size(44, 13);
            this.labelHHMM1.TabIndex = 3;
            this.labelHHMM1.Text = "HH:MM";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 129);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Update";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(120, 129);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // FormAttendanceUser_EditTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(214, 167);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAttendanceUser_EditTime";
            this.Text = "Edit Time";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxMinute;
        private System.Windows.Forms.TextBox textBoxHour;
        private System.Windows.Forms.Label labelDivider;
        private System.Windows.Forms.TextBox textBoxCurrentValue;
        private System.Windows.Forms.Label labelHHMM2;
        private System.Windows.Forms.Label labelHHMM1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}
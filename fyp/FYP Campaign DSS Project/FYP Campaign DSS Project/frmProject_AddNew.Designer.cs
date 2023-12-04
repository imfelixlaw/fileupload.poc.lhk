namespace FYP_Campaign_DSS_Project
{
    partial class frmProject_AddNew
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProject_AddNew));
            this.gProjectNew = new System.Windows.Forms.GroupBox();
            this.lblProjectName = new System.Windows.Forms.Label();
            this.txtProjectName = new System.Windows.Forms.TextBox();
            this.lblProjectStartDate = new System.Windows.Forms.Label();
            this.lblManageBy = new System.Windows.Forms.Label();
            this.dtStartDate = new System.Windows.Forms.DateTimePicker();
            this.cbManageBy = new System.Windows.Forms.ComboBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblFormMessage2 = new System.Windows.Forms.Label();
            this.lblFormMessage1 = new System.Windows.Forms.Label();
            this.gProjectNew.SuspendLayout();
            this.SuspendLayout();
            // 
            // gProjectNew
            // 
            this.gProjectNew.Controls.Add(this.lblFormMessage2);
            this.gProjectNew.Controls.Add(this.btnCancel);
            this.gProjectNew.Controls.Add(this.btnCreate);
            this.gProjectNew.Controls.Add(this.cbManageBy);
            this.gProjectNew.Controls.Add(this.dtStartDate);
            this.gProjectNew.Controls.Add(this.lblManageBy);
            this.gProjectNew.Controls.Add(this.lblProjectStartDate);
            this.gProjectNew.Controls.Add(this.txtProjectName);
            this.gProjectNew.Controls.Add(this.lblProjectName);
            this.gProjectNew.Location = new System.Drawing.Point(16, 31);
            this.gProjectNew.Name = "gProjectNew";
            this.gProjectNew.Size = new System.Drawing.Size(400, 289);
            this.gProjectNew.TabIndex = 0;
            this.gProjectNew.TabStop = false;
            this.gProjectNew.Text = "New Project";
            // 
            // lblProjectName
            // 
            this.lblProjectName.AutoSize = true;
            this.lblProjectName.Location = new System.Drawing.Point(31, 163);
            this.lblProjectName.Name = "lblProjectName";
            this.lblProjectName.Size = new System.Drawing.Size(71, 13);
            this.lblProjectName.TabIndex = 0;
            this.lblProjectName.Text = "Project Name";
            // 
            // txtProjectName
            // 
            this.txtProjectName.Location = new System.Drawing.Point(130, 160);
            this.txtProjectName.Name = "txtProjectName";
            this.txtProjectName.Size = new System.Drawing.Size(237, 20);
            this.txtProjectName.TabIndex = 1;
            // 
            // lblProjectStartDate
            // 
            this.lblProjectStartDate.AutoSize = true;
            this.lblProjectStartDate.Location = new System.Drawing.Point(31, 190);
            this.lblProjectStartDate.Name = "lblProjectStartDate";
            this.lblProjectStartDate.Size = new System.Drawing.Size(55, 13);
            this.lblProjectStartDate.TabIndex = 2;
            this.lblProjectStartDate.Text = "Start Date";
            // 
            // lblManageBy
            // 
            this.lblManageBy.AutoSize = true;
            this.lblManageBy.Location = new System.Drawing.Point(31, 215);
            this.lblManageBy.Name = "lblManageBy";
            this.lblManageBy.Size = new System.Drawing.Size(61, 13);
            this.lblManageBy.TabIndex = 3;
            this.lblManageBy.Text = "Manage By";
            // 
            // dtStartDate
            // 
            this.dtStartDate.CustomFormat = "dd - MMM - yyyy";
            this.dtStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtStartDate.Location = new System.Drawing.Point(130, 186);
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Size = new System.Drawing.Size(237, 20);
            this.dtStartDate.TabIndex = 2;
            // 
            // cbManageBy
            // 
            this.cbManageBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbManageBy.FormattingEnabled = true;
            this.cbManageBy.Location = new System.Drawing.Point(130, 212);
            this.cbManageBy.Name = "cbManageBy";
            this.cbManageBy.Size = new System.Drawing.Size(237, 21);
            this.cbManageBy.TabIndex = 3;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(120, 248);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 4;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(210, 248);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblFormMessage2
            // 
            this.lblFormMessage2.Location = new System.Drawing.Point(16, 18);
            this.lblFormMessage2.Name = "lblFormMessage2";
            this.lblFormMessage2.Size = new System.Drawing.Size(366, 124);
            this.lblFormMessage2.TabIndex = 6;
            this.lblFormMessage2.Text = resources.GetString("lblFormMessage2.Text");
            // 
            // lblFormMessage1
            // 
            this.lblFormMessage1.Location = new System.Drawing.Point(13, 9);
            this.lblFormMessage1.Name = "lblFormMessage1";
            this.lblFormMessage1.Size = new System.Drawing.Size(399, 19);
            this.lblFormMessage1.TabIndex = 7;
            this.lblFormMessage1.Text = "User can create new project here.\r\n";
            // 
            // frmProject_AddNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 336);
            this.Controls.Add(this.lblFormMessage1);
            this.Controls.Add(this.gProjectNew);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProject_AddNew";
            this.Text = "Add New Project";
            this.gProjectNew.ResumeLayout(false);
            this.gProjectNew.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gProjectNew;
        private System.Windows.Forms.Label lblProjectName;
        private System.Windows.Forms.TextBox txtProjectName;
        private System.Windows.Forms.Label lblProjectStartDate;
        private System.Windows.Forms.Label lblManageBy;
        private System.Windows.Forms.DateTimePicker dtStartDate;
        private System.Windows.Forms.ComboBox cbManageBy;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblFormMessage2;
        private System.Windows.Forms.Label lblFormMessage1;
    }
}
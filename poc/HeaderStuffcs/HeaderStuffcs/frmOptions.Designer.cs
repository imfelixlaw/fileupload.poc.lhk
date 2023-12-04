namespace HeaderStuffcs
{
    partial class frmOptions
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
            this.label1 = new System.Windows.Forms.Label();
            this.hyper1 = new System.Windows.Forms.TextBox();
            this.btnAddHyper = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.ip1 = new System.Windows.Forms.TextBox();
            this.ip2 = new System.Windows.Forms.TextBox();
            this.ip3 = new System.Windows.Forms.TextBox();
            this.ip4 = new System.Windows.Forms.TextBox();
            this.btnAddIP = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.UpdateProgressBar = new System.Windows.Forms.ProgressBar();
            this.lblUpdateStatus = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnManage = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Blacklist new hyperlink";
            // 
            // hyper1
            // 
            this.hyper1.Location = new System.Drawing.Point(137, 13);
            this.hyper1.Name = "hyper1";
            this.hyper1.Size = new System.Drawing.Size(226, 20);
            this.hyper1.TabIndex = 1;
            // 
            // btnAddHyper
            // 
            this.btnAddHyper.Location = new System.Drawing.Point(369, 11);
            this.btnAddHyper.Name = "btnAddHyper";
            this.btnAddHyper.Size = new System.Drawing.Size(75, 23);
            this.btnAddHyper.TabIndex = 2;
            this.btnAddHyper.Text = "Add";
            this.btnAddHyper.UseVisualStyleBackColor = true;
            this.btnAddHyper.Click += new System.EventHandler(this.btnAddHyper_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Blacklist new IP address";
            // 
            // ip1
            // 
            this.ip1.Location = new System.Drawing.Point(137, 52);
            this.ip1.Name = "ip1";
            this.ip1.Size = new System.Drawing.Size(28, 20);
            this.ip1.TabIndex = 4;
            this.ip1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ip2
            // 
            this.ip2.Location = new System.Drawing.Point(171, 52);
            this.ip2.Name = "ip2";
            this.ip2.Size = new System.Drawing.Size(28, 20);
            this.ip2.TabIndex = 5;
            this.ip2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ip3
            // 
            this.ip3.Location = new System.Drawing.Point(205, 52);
            this.ip3.Name = "ip3";
            this.ip3.Size = new System.Drawing.Size(28, 20);
            this.ip3.TabIndex = 6;
            this.ip3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ip4
            // 
            this.ip4.Location = new System.Drawing.Point(239, 52);
            this.ip4.Name = "ip4";
            this.ip4.Size = new System.Drawing.Size(28, 20);
            this.ip4.TabIndex = 7;
            this.ip4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnAddIP
            // 
            this.btnAddIP.Location = new System.Drawing.Point(369, 50);
            this.btnAddIP.Name = "btnAddIP";
            this.btnAddIP.Size = new System.Drawing.Size(75, 23);
            this.btnAddIP.TabIndex = 8;
            this.btnAddIP.Text = "Add";
            this.btnAddIP.UseVisualStyleBackColor = true;
            this.btnAddIP.Click += new System.EventHandler(this.btnAddIP_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(381, 203);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnManage);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.hyper1);
            this.groupBox1.Controls.Add(this.btnAddIP);
            this.groupBox1.Controls.Add(this.btnAddHyper);
            this.groupBox1.Controls.Add(this.ip4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ip3);
            this.groupBox1.Controls.Add(this.ip1);
            this.groupBox1.Controls.Add(this.ip2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(454, 116);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Custom Blacklist";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblStatus);
            this.groupBox2.Controls.Add(this.lblUpdateStatus);
            this.groupBox2.Controls.Add(this.UpdateProgressBar);
            this.groupBox2.Controls.Add(this.btnUpdate);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(14, 134);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(452, 63);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Update";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(367, 15);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Update via Internet";
            // 
            // UpdateProgressBar
            // 
            this.UpdateProgressBar.Location = new System.Drawing.Point(111, 15);
            this.UpdateProgressBar.Name = "UpdateProgressBar";
            this.UpdateProgressBar.Size = new System.Drawing.Size(252, 23);
            this.UpdateProgressBar.TabIndex = 2;
            // 
            // lblUpdateStatus
            // 
            this.lblUpdateStatus.AutoSize = true;
            this.lblUpdateStatus.Location = new System.Drawing.Point(108, 41);
            this.lblUpdateStatus.Name = "lblUpdateStatus";
            this.lblUpdateStatus.Size = new System.Drawing.Size(46, 13);
            this.lblUpdateStatus.TabIndex = 3;
            this.lblUpdateStatus.Text = "Pending";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(7, 41);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(37, 13);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "Status";
            // 
            // btnManage
            // 
            this.btnManage.Location = new System.Drawing.Point(137, 78);
            this.btnManage.Name = "btnManage";
            this.btnManage.Size = new System.Drawing.Size(75, 23);
            this.btnManage.TabIndex = 9;
            this.btnManage.Text = "Manage";
            this.btnManage.UseVisualStyleBackColor = true;
            this.btnManage.Click += new System.EventHandler(this.btnManage_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Manage Blacklist";
            // 
            // frmOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 235);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmOptions";
            this.Text = "HeaderStuffcs Options";
            this.Load += new System.EventHandler(this.frmOptions_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox hyper1;
        private System.Windows.Forms.Button btnAddHyper;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ip1;
        private System.Windows.Forms.TextBox ip2;
        private System.Windows.Forms.TextBox ip3;
        private System.Windows.Forms.TextBox ip4;
        private System.Windows.Forms.Button btnAddIP;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ProgressBar UpdateProgressBar;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblUpdateStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnManage;
    }
}
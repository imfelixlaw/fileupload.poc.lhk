namespace LHK_Intranet_Application
{
    partial class frmDowngradeMember
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtPrefix = new System.Windows.Forms.TextBox();
            this.txtMemberID = new System.Windows.Forms.TextBox();
            this.lblMember = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtMemberName = new System.Windows.Forms.TextBox();
            this.btnDowngrade = new System.Windows.Forms.Button();
            this.txtAuth = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMsg = new System.Windows.Forms.Label();
            this.lblMembership = new System.Windows.Forms.Label();
            this.txtMembership = new System.Windows.Forms.TextBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(251, 10);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(88, 23);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtPrefix
            // 
            this.txtPrefix.Location = new System.Drawing.Point(94, 12);
            this.txtPrefix.MaxLength = 3;
            this.txtPrefix.Name = "txtPrefix";
            this.txtPrefix.Size = new System.Drawing.Size(44, 20);
            this.txtPrefix.TabIndex = 1;
            this.txtPrefix.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPrefix.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrefix_KeyPress);
            // 
            // txtMemberID
            // 
            this.txtMemberID.Location = new System.Drawing.Point(144, 12);
            this.txtMemberID.MaxLength = 8;
            this.txtMemberID.Name = "txtMemberID";
            this.txtMemberID.Size = new System.Drawing.Size(101, 20);
            this.txtMemberID.TabIndex = 2;
            this.txtMemberID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblMember
            // 
            this.lblMember.AutoSize = true;
            this.lblMember.Location = new System.Drawing.Point(12, 15);
            this.lblMember.Name = "lblMember";
            this.lblMember.Size = new System.Drawing.Size(59, 13);
            this.lblMember.TabIndex = 3;
            this.lblMember.Text = "Member ID";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 47);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(76, 13);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "Member Name";
            // 
            // txtMemberName
            // 
            this.txtMemberName.Location = new System.Drawing.Point(94, 44);
            this.txtMemberName.Name = "txtMemberName";
            this.txtMemberName.ReadOnly = true;
            this.txtMemberName.Size = new System.Drawing.Size(151, 20);
            this.txtMemberName.TabIndex = 5;
            // 
            // btnDowngrade
            // 
            this.btnDowngrade.Location = new System.Drawing.Point(94, 148);
            this.btnDowngrade.Name = "btnDowngrade";
            this.btnDowngrade.Size = new System.Drawing.Size(152, 23);
            this.btnDowngrade.TabIndex = 6;
            this.btnDowngrade.Text = "Downgrade to Non-Member";
            this.btnDowngrade.UseVisualStyleBackColor = true;
            this.btnDowngrade.Click += new System.EventHandler(this.btnDowngrade_Click);
            // 
            // txtAuth
            // 
            this.txtAuth.Location = new System.Drawing.Point(94, 122);
            this.txtAuth.Name = "txtAuth";
            this.txtAuth.PasswordChar = '*';
            this.txtAuth.Size = new System.Drawing.Size(151, 20);
            this.txtAuth.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Authentication";
            // 
            // txtMsg
            // 
            this.txtMsg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtMsg.Location = new System.Drawing.Point(251, 63);
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.Size = new System.Drawing.Size(87, 79);
            this.txtMsg.TabIndex = 9;
            this.txtMsg.Text = "Downgrade Member Toolkit";
            // 
            // lblMembership
            // 
            this.lblMembership.AutoSize = true;
            this.lblMembership.Location = new System.Drawing.Point(12, 74);
            this.lblMembership.Name = "lblMembership";
            this.lblMembership.Size = new System.Drawing.Size(64, 13);
            this.lblMembership.TabIndex = 10;
            this.lblMembership.Text = "Membership";
            // 
            // txtMembership
            // 
            this.txtMembership.Location = new System.Drawing.Point(94, 71);
            this.txtMembership.Name = "txtMembership";
            this.txtMembership.ReadOnly = true;
            this.txtMembership.Size = new System.Drawing.Size(151, 20);
            this.txtMembership.TabIndex = 11;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(251, 37);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(88, 23);
            this.btnReset.TabIndex = 12;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(250, 148);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(88, 23);
            this.btnExit.TabIndex = 13;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmDowngradeMember
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(351, 182);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.txtMembership);
            this.Controls.Add(this.lblMembership);
            this.Controls.Add(this.txtMsg);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtAuth);
            this.Controls.Add(this.btnDowngrade);
            this.Controls.Add(this.txtMemberName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblMember);
            this.Controls.Add(this.txtMemberID);
            this.Controls.Add(this.txtPrefix);
            this.Controls.Add(this.btnSearch);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDowngradeMember";
            this.Text = "Downgrade Member";
            this.Load += new System.EventHandler(this.frmDowngradeMember_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtPrefix;
        private System.Windows.Forms.TextBox txtMemberID;
        private System.Windows.Forms.Label lblMember;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtMemberName;
        private System.Windows.Forms.Button btnDowngrade;
        private System.Windows.Forms.TextBox txtAuth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txtMsg;
        private System.Windows.Forms.Label lblMembership;
        private System.Windows.Forms.TextBox txtMembership;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnExit;
    }
}


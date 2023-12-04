namespace HR_Server
{
    partial class frmUpdateStaffNo
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
            this.dgResult = new System.Windows.Forms.DataGridView();
            this.IDUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserAcc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblSbn = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.gData = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.chkUpdatePunchCard = new System.Windows.Forms.CheckBox();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtHP = new System.Windows.Forms.TextBox();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtRole = new System.Windows.Forms.TextBox();
            this.txtBranchCode = new System.Windows.Forms.TextBox();
            this.txtStaffNo = new System.Windows.Forms.TextBox();
            this.lblr = new System.Windows.Forms.Label();
            this.lblbc = new System.Windows.Forms.Label();
            this.lblemail = new System.Windows.Forms.Label();
            this.lbltel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblStn = new System.Windows.Forms.Label();
            this.statusbar = new System.Windows.Forms.StatusStrip();
            this.lblIP = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgResult)).BeginInit();
            this.gData.SuspendLayout();
            this.statusbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgResult
            // 
            this.dgResult.AllowUserToAddRows = false;
            this.dgResult.AllowUserToDeleteRows = false;
            this.dgResult.AllowUserToResizeColumns = false;
            this.dgResult.AllowUserToResizeRows = false;
            this.dgResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDUser,
            this.UserAcc});
            this.dgResult.Location = new System.Drawing.Point(12, 74);
            this.dgResult.MultiSelect = false;
            this.dgResult.Name = "dgResult";
            this.dgResult.ReadOnly = true;
            this.dgResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgResult.ShowCellErrors = false;
            this.dgResult.ShowEditingIcon = false;
            this.dgResult.ShowRowErrors = false;
            this.dgResult.Size = new System.Drawing.Size(254, 148);
            this.dgResult.TabIndex = 0;
            this.dgResult.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgResult_CellClick);
            this.dgResult.MouseHover += new System.EventHandler(this.dgResult_MouseHover);
            // 
            // IDUser
            // 
            this.IDUser.HeaderText = "IDUser";
            this.IDUser.Name = "IDUser";
            this.IDUser.ReadOnly = true;
            this.IDUser.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.IDUser.Visible = false;
            // 
            // UserAcc
            // 
            this.UserAcc.HeaderText = "Name";
            this.UserAcc.Name = "UserAcc";
            this.UserAcc.ReadOnly = true;
            this.UserAcc.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.UserAcc.Width = 180;
            // 
            // lblSbn
            // 
            this.lblSbn.AutoSize = true;
            this.lblSbn.Location = new System.Drawing.Point(9, 9);
            this.lblSbn.Name = "lblSbn";
            this.lblSbn.Size = new System.Drawing.Size(86, 13);
            this.lblSbn.TabIndex = 1;
            this.lblSbn.Text = "Search by Name";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(12, 25);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(173, 20);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.MouseHover += new System.EventHandler(this.txtSearch_MouseHover);
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(9, 58);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(37, 13);
            this.lblResult.TabIndex = 3;
            this.lblResult.Text = "Result";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(191, 23);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            this.btnSearch.MouseHover += new System.EventHandler(this.btnSearch_MouseHover);
            // 
            // gData
            // 
            this.gData.Controls.Add(this.button1);
            this.gData.Controls.Add(this.chkUpdatePunchCard);
            this.gData.Controls.Add(this.txtUserID);
            this.gData.Controls.Add(this.btnSave);
            this.gData.Controls.Add(this.txtHP);
            this.gData.Controls.Add(this.txtTel);
            this.gData.Controls.Add(this.txtEmail);
            this.gData.Controls.Add(this.txtRole);
            this.gData.Controls.Add(this.txtBranchCode);
            this.gData.Controls.Add(this.txtStaffNo);
            this.gData.Controls.Add(this.lblr);
            this.gData.Controls.Add(this.lblbc);
            this.gData.Controls.Add(this.lblemail);
            this.gData.Controls.Add(this.lbltel);
            this.gData.Controls.Add(this.label1);
            this.gData.Controls.Add(this.lblStn);
            this.gData.Location = new System.Drawing.Point(276, 12);
            this.gData.Name = "gData";
            this.gData.Size = new System.Drawing.Size(241, 239);
            this.gData.TabIndex = 5;
            this.gData.TabStop = false;
            this.gData.Text = "Data";
            this.gData.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(173, 210);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(47, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chkUpdatePunchCard
            // 
            this.chkUpdatePunchCard.AutoSize = true;
            this.chkUpdatePunchCard.Location = new System.Drawing.Point(36, 187);
            this.chkUpdatePunchCard.Name = "chkUpdatePunchCard";
            this.chkUpdatePunchCard.Size = new System.Drawing.Size(184, 17);
            this.chkUpdatePunchCard.TabIndex = 14;
            this.chkUpdatePunchCard.Text = "Update PunchCard Data as well?";
            this.chkUpdatePunchCard.UseVisualStyleBackColor = true;
            this.chkUpdatePunchCard.MouseHover += new System.EventHandler(this.chkUpdatePunchCard_MouseHover);
            // 
            // txtUserID
            // 
            this.txtUserID.Enabled = false;
            this.txtUserID.Location = new System.Drawing.Point(9, 212);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(49, 20);
            this.txtUserID.TabIndex = 13;
            this.txtUserID.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(91, 210);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.MouseHover += new System.EventHandler(this.btnSave_MouseHover);
            // 
            // txtHP
            // 
            this.txtHP.Location = new System.Drawing.Point(81, 149);
            this.txtHP.Name = "txtHP";
            this.txtHP.ReadOnly = true;
            this.txtHP.Size = new System.Drawing.Size(154, 20);
            this.txtHP.TabIndex = 11;
            // 
            // txtTel
            // 
            this.txtTel.Location = new System.Drawing.Point(81, 123);
            this.txtTel.Name = "txtTel";
            this.txtTel.ReadOnly = true;
            this.txtTel.Size = new System.Drawing.Size(154, 20);
            this.txtTel.TabIndex = 10;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(81, 97);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(154, 20);
            this.txtEmail.TabIndex = 9;
            // 
            // txtRole
            // 
            this.txtRole.Location = new System.Drawing.Point(81, 71);
            this.txtRole.Name = "txtRole";
            this.txtRole.ReadOnly = true;
            this.txtRole.Size = new System.Drawing.Size(154, 20);
            this.txtRole.TabIndex = 8;
            // 
            // txtBranchCode
            // 
            this.txtBranchCode.Location = new System.Drawing.Point(81, 45);
            this.txtBranchCode.Name = "txtBranchCode";
            this.txtBranchCode.ReadOnly = true;
            this.txtBranchCode.Size = new System.Drawing.Size(154, 20);
            this.txtBranchCode.TabIndex = 7;
            // 
            // txtStaffNo
            // 
            this.txtStaffNo.Location = new System.Drawing.Point(81, 19);
            this.txtStaffNo.Name = "txtStaffNo";
            this.txtStaffNo.Size = new System.Drawing.Size(154, 20);
            this.txtStaffNo.TabIndex = 6;
            this.txtStaffNo.MouseHover += new System.EventHandler(this.txtStaffNo_MouseHover);
            // 
            // lblr
            // 
            this.lblr.AutoSize = true;
            this.lblr.Location = new System.Drawing.Point(6, 74);
            this.lblr.Name = "lblr";
            this.lblr.Size = new System.Drawing.Size(29, 13);
            this.lblr.TabIndex = 5;
            this.lblr.Text = "Role";
            // 
            // lblbc
            // 
            this.lblbc.AutoSize = true;
            this.lblbc.Location = new System.Drawing.Point(6, 48);
            this.lblbc.Name = "lblbc";
            this.lblbc.Size = new System.Drawing.Size(69, 13);
            this.lblbc.TabIndex = 4;
            this.lblbc.Text = "Branch Code";
            // 
            // lblemail
            // 
            this.lblemail.AutoSize = true;
            this.lblemail.Location = new System.Drawing.Point(6, 100);
            this.lblemail.Name = "lblemail";
            this.lblemail.Size = new System.Drawing.Size(32, 13);
            this.lblemail.TabIndex = 3;
            this.lblemail.Text = "Email";
            // 
            // lbltel
            // 
            this.lbltel.AutoSize = true;
            this.lbltel.Location = new System.Drawing.Point(6, 126);
            this.lbltel.Name = "lbltel";
            this.lbltel.Size = new System.Drawing.Size(22, 13);
            this.lbltel.TabIndex = 2;
            this.lbltel.Text = "Tel";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "HP";
            // 
            // lblStn
            // 
            this.lblStn.AutoSize = true;
            this.lblStn.Location = new System.Drawing.Point(6, 22);
            this.lblStn.Name = "lblStn";
            this.lblStn.Size = new System.Drawing.Size(46, 13);
            this.lblStn.TabIndex = 0;
            this.lblStn.Text = "Staff No";
            // 
            // statusbar
            // 
            this.statusbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblIP,
            this.txtStatus});
            this.statusbar.Location = new System.Drawing.Point(0, 260);
            this.statusbar.Name = "statusbar";
            this.statusbar.Size = new System.Drawing.Size(525, 22);
            this.statusbar.TabIndex = 6;
            this.statusbar.Text = "statusbar";
            // 
            // lblIP
            // 
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(17, 17);
            this.lblIP.Text = "IP";
            // 
            // txtStatus
            // 
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(35, 17);
            this.txtStatus.Text = "Done";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(85, 228);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            this.btnExit.MouseHover += new System.EventHandler(this.btnExit_MouseHover);
            // 
            // frmUpdateStaffNo
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 282);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.statusbar);
            this.Controls.Add(this.gData);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblSbn);
            this.Controls.Add(this.dgResult);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUpdateStaffNo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LHK Intranet - Update Staff No <Private and Confidential>";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmUpdateStaffNo_FormClosed);
            this.Load += new System.EventHandler(this.frmUpdateStaffNo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgResult)).EndInit();
            this.gData.ResumeLayout(false);
            this.gData.PerformLayout();
            this.statusbar.ResumeLayout(false);
            this.statusbar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgResult;
        private System.Windows.Forms.Label lblSbn;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox gData;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserAcc;
        private System.Windows.Forms.Label lblStn;
        private System.Windows.Forms.Label lblemail;
        private System.Windows.Forms.Label lbltel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblr;
        private System.Windows.Forms.Label lblbc;
        private System.Windows.Forms.TextBox txtHP;
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtRole;
        private System.Windows.Forms.TextBox txtBranchCode;
        private System.Windows.Forms.TextBox txtStaffNo;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.StatusStrip statusbar;
        private System.Windows.Forms.ToolStripStatusLabel txtStatus;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.CheckBox chkUpdatePunchCard;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripStatusLabel lblIP;
    }
}


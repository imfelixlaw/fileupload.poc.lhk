namespace HR_Attendance_Module_Control_Center
{
    partial class FormMain
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
            this.menuStripFrmMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.attendanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usersListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checklistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.punchcardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.requestListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStripFrmMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripFrmMain
            // 
            this.menuStripFrmMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.attendanceToolStripMenuItem,
            this.userManagementToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStripFrmMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripFrmMain.Name = "menuStripFrmMain";
            this.menuStripFrmMain.Size = new System.Drawing.Size(922, 24);
            this.menuStripFrmMain.TabIndex = 1;
            this.menuStripFrmMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // attendanceToolStripMenuItem
            // 
            this.attendanceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checklistToolStripMenuItem,
            this.punchcardToolStripMenuItem,
            this.toolStripSeparator1,
            this.requestListToolStripMenuItem});
            this.attendanceToolStripMenuItem.Name = "attendanceToolStripMenuItem";
            this.attendanceToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.attendanceToolStripMenuItem.Text = "Attendance";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // usersListToolStripMenuItem
            // 
            this.usersListToolStripMenuItem.Name = "usersListToolStripMenuItem";
            this.usersListToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.usersListToolStripMenuItem.Text = "Users List";
            this.usersListToolStripMenuItem.Click += new System.EventHandler(this.usersListToolStripMenuItem_Click);
            // 
            // userManagementToolStripMenuItem
            // 
            this.userManagementToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usersListToolStripMenuItem});
            this.userManagementToolStripMenuItem.Name = "userManagementToolStripMenuItem";
            this.userManagementToolStripMenuItem.Size = new System.Drawing.Size(106, 20);
            this.userManagementToolStripMenuItem.Text = "User Management";
            // 
            // checklistToolStripMenuItem
            // 
            this.checklistToolStripMenuItem.Name = "checklistToolStripMenuItem";
            this.checklistToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.checklistToolStripMenuItem.Text = "Checklist";
            this.checklistToolStripMenuItem.Click += new System.EventHandler(this.checklistToolStripMenuItem_Click);
            // 
            // punchcardToolStripMenuItem
            // 
            this.punchcardToolStripMenuItem.Name = "punchcardToolStripMenuItem";
            this.punchcardToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.punchcardToolStripMenuItem.Text = "Punchcard";
            this.punchcardToolStripMenuItem.Click += new System.EventHandler(this.punchcardToolStripMenuItem_Click);
            // 
            // requestListToolStripMenuItem
            // 
            this.requestListToolStripMenuItem.Name = "requestListToolStripMenuItem";
            this.requestListToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.requestListToolStripMenuItem.Text = "Request List";
            this.requestListToolStripMenuItem.Click += new System.EventHandler(this.requestListToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 439);
            this.Controls.Add(this.menuStripFrmMain);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStripFrmMain;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Attendance Module Control Center";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStripFrmMain.ResumeLayout(false);
            this.menuStripFrmMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripFrmMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem attendanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userManagementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usersListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checklistToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem punchcardToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem requestListToolStripMenuItem;
    }
}


namespace LHK_Attandance
{
    partial class frmBugReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBugReport));
            this.gboxBugReport = new System.Windows.Forms.GroupBox();
            this.lblAddtionalMessage = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cboxExtraData = new System.Windows.Forms.CheckBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.lblMsg = new System.Windows.Forms.Label();
            this.lblErrMsg = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.gboxBugReport.SuspendLayout();
            this.SuspendLayout();
            // 
            // gboxBugReport
            // 
            this.gboxBugReport.Controls.Add(this.btnExit);
            this.gboxBugReport.Controls.Add(this.label1);
            this.gboxBugReport.Controls.Add(this.lblErrMsg);
            this.gboxBugReport.Controls.Add(this.lblMsg);
            this.gboxBugReport.Controls.Add(this.btnSend);
            this.gboxBugReport.Controls.Add(this.cboxExtraData);
            this.gboxBugReport.Controls.Add(this.textBox1);
            this.gboxBugReport.Controls.Add(this.lblAddtionalMessage);
            this.gboxBugReport.Location = new System.Drawing.Point(12, 12);
            this.gboxBugReport.Name = "gboxBugReport";
            this.gboxBugReport.Size = new System.Drawing.Size(564, 391);
            this.gboxBugReport.TabIndex = 0;
            this.gboxBugReport.TabStop = false;
            this.gboxBugReport.Text = "Report";
            // 
            // lblAddtionalMessage
            // 
            this.lblAddtionalMessage.Location = new System.Drawing.Point(12, 251);
            this.lblAddtionalMessage.Name = "lblAddtionalMessage";
            this.lblAddtionalMessage.Size = new System.Drawing.Size(60, 54);
            this.lblAddtionalMessage.TabIndex = 0;
            this.lblAddtionalMessage.Text = "Additional Message";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(93, 248);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(454, 105);
            this.textBox1.TabIndex = 1;
            // 
            // cboxExtraData
            // 
            this.cboxExtraData.AutoSize = true;
            this.cboxExtraData.Checked = true;
            this.cboxExtraData.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cboxExtraData.Location = new System.Drawing.Point(220, 359);
            this.cboxExtraData.Name = "cboxExtraData";
            this.cboxExtraData.Size = new System.Drawing.Size(104, 17);
            this.cboxExtraData.TabIndex = 2;
            this.cboxExtraData.Text = "Send Extra Data";
            this.cboxExtraData.UseVisualStyleBackColor = true;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(372, 355);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            // 
            // lblMsg
            // 
            this.lblMsg.Location = new System.Drawing.Point(12, 16);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(546, 110);
            this.lblMsg.TabIndex = 4;
            this.lblMsg.Text = resources.GetString("lblMsg.Text");
            // 
            // lblErrMsg
            // 
            this.lblErrMsg.AutoSize = true;
            this.lblErrMsg.Location = new System.Drawing.Point(12, 143);
            this.lblErrMsg.Name = "lblErrMsg";
            this.lblErrMsg.Size = new System.Drawing.Size(75, 13);
            this.lblErrMsg.TabIndex = 5;
            this.lblErrMsg.Text = "Error Message";
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(93, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(454, 94);
            this.label1.TabIndex = 6;
            this.label1.Text = "label1";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(453, 355);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Don\'t Send";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmBugReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 416);
            this.Controls.Add(this.gboxBugReport);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBugReport";
            this.Text = "Error Reporting";
            this.gboxBugReport.ResumeLayout(false);
            this.gboxBugReport.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gboxBugReport;
        private System.Windows.Forms.Label lblAddtionalMessage;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox cboxExtraData;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Label lblErrMsg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExit;
    }
}
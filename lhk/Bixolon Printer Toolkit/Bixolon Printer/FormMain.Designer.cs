namespace Bixolon_Printer
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
            this.components = new System.ComponentModel.Container();
            this.textBoxBranchCode = new System.Windows.Forms.TextBox();
            this.textBoxReceiptNo = new System.Windows.Forms.TextBox();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.listBoxReceiptNo = new System.Windows.Forms.ListBox();
            this.labelReceiptToday = new System.Windows.Forms.Label();
            this.labelMsg = new System.Windows.Forms.Label();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            this.labelRefreshTime = new System.Windows.Forms.Label();
            this.labelReceiptNo = new System.Windows.Forms.Label();
            this.labelTotalSale = new System.Windows.Forms.Label();
            this.labelDate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxBranchCode
            // 
            this.textBoxBranchCode.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxBranchCode.Location = new System.Drawing.Point(115, 12);
            this.textBoxBranchCode.Name = "textBoxBranchCode";
            this.textBoxBranchCode.Size = new System.Drawing.Size(68, 20);
            this.textBoxBranchCode.TabIndex = 0;
            // 
            // textBoxReceiptNo
            // 
            this.textBoxReceiptNo.Location = new System.Drawing.Point(189, 12);
            this.textBoxReceiptNo.Name = "textBoxReceiptNo";
            this.textBoxReceiptNo.Size = new System.Drawing.Size(100, 20);
            this.textBoxReceiptNo.TabIndex = 1;
            // 
            // buttonPrint
            // 
            this.buttonPrint.Location = new System.Drawing.Point(214, 38);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(75, 23);
            this.buttonPrint.TabIndex = 2;
            this.buttonPrint.Text = "Print";
            this.buttonPrint.UseVisualStyleBackColor = true;
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(215, 267);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 3;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // listBoxReceiptNo
            // 
            this.listBoxReceiptNo.FormattingEnabled = true;
            this.listBoxReceiptNo.Location = new System.Drawing.Point(41, 79);
            this.listBoxReceiptNo.Name = "listBoxReceiptNo";
            this.listBoxReceiptNo.Size = new System.Drawing.Size(248, 160);
            this.listBoxReceiptNo.TabIndex = 4;
            this.listBoxReceiptNo.SelectedIndexChanged += new System.EventHandler(this.listBoxReceiptNo_SelectedIndexChanged);
            // 
            // labelReceiptToday
            // 
            this.labelReceiptToday.AutoSize = true;
            this.labelReceiptToday.Location = new System.Drawing.Point(38, 63);
            this.labelReceiptToday.Name = "labelReceiptToday";
            this.labelReceiptToday.Size = new System.Drawing.Size(84, 13);
            this.labelReceiptToday.TabIndex = 5;
            this.labelReceiptToday.Text = "Today\'s Receipt";
            // 
            // labelMsg
            // 
            this.labelMsg.AutoSize = true;
            this.labelMsg.Location = new System.Drawing.Point(38, 277);
            this.labelMsg.Name = "labelMsg";
            this.labelMsg.Size = new System.Drawing.Size(171, 13);
            this.labelMsg.TabIndex = 6;
            this.labelMsg.Text = "Report bug to felix@lohongka.com";
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(134, 38);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(75, 23);
            this.buttonRefresh.TabIndex = 7;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // timerRefresh
            // 
            this.timerRefresh.Enabled = true;
            this.timerRefresh.Interval = 30000;
            this.timerRefresh.Tick += new System.EventHandler(this.timerRefresh_Tick);
            // 
            // labelRefreshTime
            // 
            this.labelRefreshTime.AutoSize = true;
            this.labelRefreshTime.Location = new System.Drawing.Point(38, 242);
            this.labelRefreshTime.Name = "labelRefreshTime";
            this.labelRefreshTime.Size = new System.Drawing.Size(89, 13);
            this.labelRefreshTime.TabIndex = 8;
            this.labelRefreshTime.Text = "labelRefreshTime";
            // 
            // labelReceiptNo
            // 
            this.labelReceiptNo.AutoSize = true;
            this.labelReceiptNo.Location = new System.Drawing.Point(38, 15);
            this.labelReceiptNo.Name = "labelReceiptNo";
            this.labelReceiptNo.Size = new System.Drawing.Size(61, 13);
            this.labelReceiptNo.TabIndex = 9;
            this.labelReceiptNo.Text = "Receipt No";
            // 
            // labelTotalSale
            // 
            this.labelTotalSale.AutoSize = true;
            this.labelTotalSale.Location = new System.Drawing.Point(38, 260);
            this.labelTotalSale.Name = "labelTotalSale";
            this.labelTotalSale.Size = new System.Drawing.Size(74, 13);
            this.labelTotalSale.TabIndex = 10;
            this.labelTotalSale.Text = "labelTotalSale";
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Location = new System.Drawing.Point(186, 63);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(52, 13);
            this.labelDate.TabIndex = 11;
            this.labelDate.Text = "labelDate";
            // 
            // FormMain
            // 
            this.AcceptButton = this.buttonPrint;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(329, 299);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.labelTotalSale);
            this.Controls.Add(this.labelReceiptNo);
            this.Controls.Add(this.labelRefreshTime);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.labelMsg);
            this.Controls.Add(this.labelReceiptToday);
            this.Controls.Add(this.listBoxReceiptNo);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonPrint);
            this.Controls.Add(this.textBoxReceiptNo);
            this.Controls.Add(this.textBoxBranchCode);
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Bixolon Printer Printing Toolkit";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxBranchCode;
        private System.Windows.Forms.TextBox textBoxReceiptNo;
        private System.Windows.Forms.Button buttonPrint;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.ListBox listBoxReceiptNo;
        private System.Windows.Forms.Label labelReceiptToday;
        private System.Windows.Forms.Label labelMsg;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Timer timerRefresh;
        private System.Windows.Forms.Label labelRefreshTime;
        private System.Windows.Forms.Label labelReceiptNo;
        private System.Windows.Forms.Label labelTotalSale;
        private System.Windows.Forms.Label labelDate;
    }
}


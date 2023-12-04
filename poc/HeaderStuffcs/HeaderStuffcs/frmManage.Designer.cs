namespace HeaderStuffcs
{
    partial class frmManage
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
            this.gGvHyper = new System.Windows.Forms.DataGridView();
            this.btnDeleteHyper = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gGvIP = new System.Windows.Forms.DataGridView();
            this.btnDeleteIP = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gGvHyper)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gGvIP)).BeginInit();
            this.SuspendLayout();
            // 
            // gGvHyper
            // 
            this.gGvHyper.AllowUserToAddRows = false;
            this.gGvHyper.AllowUserToDeleteRows = false;
            this.gGvHyper.AllowUserToOrderColumns = true;
            this.gGvHyper.AllowUserToResizeColumns = false;
            this.gGvHyper.AllowUserToResizeRows = false;
            this.gGvHyper.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gGvHyper.Location = new System.Drawing.Point(6, 19);
            this.gGvHyper.Name = "gGvHyper";
            this.gGvHyper.ReadOnly = true;
            this.gGvHyper.Size = new System.Drawing.Size(313, 148);
            this.gGvHyper.TabIndex = 0;
            // 
            // btnDeleteHyper
            // 
            this.btnDeleteHyper.Location = new System.Drawing.Point(327, 19);
            this.btnDeleteHyper.Name = "btnDeleteHyper";
            this.btnDeleteHyper.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteHyper.TabIndex = 1;
            this.btnDeleteHyper.Text = "Delete";
            this.btnDeleteHyper.UseVisualStyleBackColor = true;
            this.btnDeleteHyper.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gGvHyper);
            this.groupBox1.Controls.Add(this.btnDeleteHyper);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(408, 180);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Custom Hyperlink";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDeleteIP);
            this.groupBox2.Controls.Add(this.gGvIP);
            this.groupBox2.Location = new System.Drawing.Point(12, 198);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(408, 179);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Custom IP";
            // 
            // gGvIP
            // 
            this.gGvIP.AllowUserToAddRows = false;
            this.gGvIP.AllowUserToDeleteRows = false;
            this.gGvIP.AllowUserToOrderColumns = true;
            this.gGvIP.AllowUserToResizeColumns = false;
            this.gGvIP.AllowUserToResizeRows = false;
            this.gGvIP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gGvIP.Location = new System.Drawing.Point(6, 19);
            this.gGvIP.Name = "gGvIP";
            this.gGvIP.ReadOnly = true;
            this.gGvIP.Size = new System.Drawing.Size(313, 148);
            this.gGvIP.TabIndex = 1;
            // 
            // btnDeleteIP
            // 
            this.btnDeleteIP.Location = new System.Drawing.Point(325, 19);
            this.btnDeleteIP.Name = "btnDeleteIP";
            this.btnDeleteIP.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteIP.TabIndex = 2;
            this.btnDeleteIP.Text = "Delete";
            this.btnDeleteIP.UseVisualStyleBackColor = true;
            this.btnDeleteIP.Click += new System.EventHandler(this.btnDeleteIP_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(339, 383);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 424);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmManage";
            this.Text = "Custom Blacklist Management";
            this.Load += new System.EventHandler(this.frmManage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gGvHyper)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gGvIP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gGvHyper;
        private System.Windows.Forms.Button btnDeleteHyper;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnDeleteIP;
        private System.Windows.Forms.DataGridView gGvIP;
        private System.Windows.Forms.Button btnClose;

    }
}
namespace ClassLibEncryption
{
    partial class frmCrypt
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
            this.txtInput = new System.Windows.Forms.TextBox();
            this.lblInput = new System.Windows.Forms.Label();
            this.lblOutput = new System.Windows.Forms.Label();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.btnProcess = new System.Windows.Forms.Button();
            this.cbxMethod = new System.Windows.Forms.ComboBox();
            this.btnCopy = new System.Windows.Forms.Button();
            this.lblMethod = new System.Windows.Forms.Label();
            this.lblPasskey = new System.Windows.Forms.Label();
            this.txtPasskey = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(69, 38);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(211, 20);
            this.txtInput.TabIndex = 1;
            // 
            // lblInput
            // 
            this.lblInput.AutoSize = true;
            this.lblInput.Location = new System.Drawing.Point(12, 41);
            this.lblInput.Name = "lblInput";
            this.lblInput.Size = new System.Drawing.Size(31, 13);
            this.lblInput.TabIndex = 1;
            this.lblInput.Text = "Input";
            // 
            // lblOutput
            // 
            this.lblOutput.AutoSize = true;
            this.lblOutput.Location = new System.Drawing.Point(12, 67);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(39, 13);
            this.lblOutput.TabIndex = 2;
            this.lblOutput.Text = "Output";
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(69, 64);
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.Size = new System.Drawing.Size(211, 20);
            this.txtResult.TabIndex = 3;
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(69, 117);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(211, 48);
            this.btnProcess.TabIndex = 4;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // cbxMethod
            // 
            this.cbxMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMethod.FormattingEnabled = true;
            this.cbxMethod.Items.AddRange(new object[] {
            "Encrypt",
            "Decrypt"});
            this.cbxMethod.Location = new System.Drawing.Point(69, 90);
            this.cbxMethod.Name = "cbxMethod";
            this.cbxMethod.Size = new System.Drawing.Size(107, 21);
            this.cbxMethod.TabIndex = 3;
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(182, 90);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(98, 23);
            this.btnCopy.TabIndex = 5;
            this.btnCopy.Text = "Copy Result";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // lblMethod
            // 
            this.lblMethod.AutoSize = true;
            this.lblMethod.Location = new System.Drawing.Point(12, 95);
            this.lblMethod.Name = "lblMethod";
            this.lblMethod.Size = new System.Drawing.Size(43, 13);
            this.lblMethod.TabIndex = 7;
            this.lblMethod.Text = "Method";
            // 
            // lblPasskey
            // 
            this.lblPasskey.AutoSize = true;
            this.lblPasskey.Location = new System.Drawing.Point(12, 15);
            this.lblPasskey.Name = "lblPasskey";
            this.lblPasskey.Size = new System.Drawing.Size(47, 13);
            this.lblPasskey.TabIndex = 8;
            this.lblPasskey.Text = "Passkey";
            // 
            // txtPasskey
            // 
            this.txtPasskey.Location = new System.Drawing.Point(69, 12);
            this.txtPasskey.Name = "txtPasskey";
            this.txtPasskey.Size = new System.Drawing.Size(211, 20);
            this.txtPasskey.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(69, 171);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(211, 47);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmCrypt
            // 
            this.AcceptButton = this.btnProcess;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(292, 230);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtPasskey);
            this.Controls.Add(this.lblPasskey);
            this.Controls.Add(this.lblMethod);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.cbxMethod);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.lblOutput);
            this.Controls.Add(this.lblInput);
            this.Controls.Add(this.txtInput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCrypt";
            this.Text = "Encryption Creation";
            this.Load += new System.EventHandler(this.frmCrypt_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Label lblInput;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.ComboBox cbxMethod;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Label lblMethod;
        private System.Windows.Forms.Label lblPasskey;
        private System.Windows.Forms.TextBox txtPasskey;
        private System.Windows.Forms.Button btnClose;
    }
}
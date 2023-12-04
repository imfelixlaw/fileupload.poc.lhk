using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using PrinterClassDll;

namespace SampleProgram
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(192, 64);
            this.button1.TabIndex = 0;
            this.button1.Text = "Print";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(211, 82);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "BIXOLON";
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			Win32PrintClass w32prn = new Win32PrintClass();
			
			w32prn.SetPrinterName("BIXOLON SRP-350plus");
			
			// Open CashDrawer
			w32prn.OpenCashdrawer(2);	// 2 pin cashdrawer
			w32prn.OpenCashdrawer(5);	// 5 pin cashdrawer			
		
			// Print Image
			w32prn.SetDeviceFont(9.5f, "FontControl", false, false);
			w32prn.PrintText("x");
			w32prn.PrintText("G");		// 1st NV Image
			w32prn.PrintText("H");		// 2nd NV Image
			
			// Print Receipt
			w32prn.SetDeviceFont(9.5f, "FontA2x1", false, true);
			w32prn.PrintText("BIXOLON's MALL");
			w32prn.SetDeviceFont(9.5f, "FontA1x1", false, false);
			w32prn.PrintText("Buy Online or call");
			w32prn.PrintText("");
			w32prn.SetDeviceFont(7f, "FontB2x1", false, true);
			w32prn.PrintText("1-800-915-3355");
			w32prn.SetDeviceFont(9.5f, "FontControl", false, false);
			w32prn.PrintText("w");
			w32prn.SetDeviceFont(9.5f, "FontA1x1", false, false);
			w32prn.PrintText("------------------------------------------");			
			w32prn.PrintText("BIXOLON SRP-350 Printer               $999");
			w32prn.PrintText("SRP-770 Label Printer                 $749");
			w32prn.PrintText("SRP-370 Thermal Receipt Printer     $1,299");
			w32prn.PrintText("SRP-270 Impact Receipt Printer      $1,299");
			w32prn.PrintText("RIF-BT10                              $949");
			w32prn.PrintText("SMP600                                $349");
			w32prn.PrintText("SRP-500 Inkjet Receipt Printer        $249");
			w32prn.PrintText("------------------------------------------");
			w32prn.SetDeviceFont(9.5f, "FontA1x1", false, true);
			w32prn.PrintText("Total purchase :                    $5,893");
			w32prn.PrintText("Visa :                              $5,893");
			w32prn.SetDeviceFont(9.5f, "FontA1x1", false, false);
			w32prn.PrintText("------------------------------------------");
			w32prn.SetDeviceFont(9.5f, "FontControl", false, false);
			w32prn.PrintText("x");			
			w32prn.PrintText("r");
			w32prn.SetDeviceFont(20f, "Code128", false, false);
			w32prn.PrintText("{A{S12235884584645");
			w32prn.SetDeviceFont(9.5f, "FontA1x1", false, false);
			w32prn.PrintText("Date : 04/08/2003     Time : 09:32");
			w32prn.PrintText("No : 00018857302");
			w32prn.PrintText("");
			w32prn.PrintText("");
			w32prn.PrintText("FREE 2nd Bay Interface ");
			w32prn.PrintText("With Purchase of ANY Dimension Desktop");
			w32prn.PrintText("Ends Today !");
			
			// Print Image
			w32prn.PrintImage("sample.bmp");
			w32prn.PrintImage("sample2.bmp");		
			
			// Cut Receipt
			//w32prn.SetDeviceFont(9.5f, "FontControl", false, false);
			//w32prn.PrintText("P");
			
			// Print
			w32prn.EndDoc();
		}
	}
}

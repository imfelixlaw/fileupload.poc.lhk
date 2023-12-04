namespace HeaderStuffcs
{
    partial class HeaderStuffcs_ribbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public HeaderStuffcs_ribbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabHScs = this.Factory.CreateRibbonTab();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.btnOption = this.Factory.CreateRibbonButton();
            this.group2 = this.Factory.CreateRibbonGroup();
            this.btnAbout = this.Factory.CreateRibbonButton();
            this.tabHScs.SuspendLayout();
            this.group1.SuspendLayout();
            this.group2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabHScs
            // 
            this.tabHScs.Groups.Add(this.group1);
            this.tabHScs.Groups.Add(this.group2);
            this.tabHScs.Label = "Header Stuff CS";
            this.tabHScs.Name = "tabHScs";
            // 
            // group1
            // 
            this.group1.Items.Add(this.btnOption);
            this.group1.Label = "Options";
            this.group1.Name = "group1";
            // 
            // btnOption
            // 
            this.btnOption.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnOption.Image = global::HeaderStuffcs.Properties.Resources.check_button;
            this.btnOption.Label = "Options";
            this.btnOption.Name = "btnOption";
            this.btnOption.ShowImage = true;
            this.btnOption.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnOption_Click);
            // 
            // group2
            // 
            this.group2.Items.Add(this.btnAbout);
            this.group2.Label = "About";
            this.group2.Name = "group2";
            // 
            // btnAbout
            // 
            this.btnAbout.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnAbout.Image = global::HeaderStuffcs.Properties.Resources.about;
            this.btnAbout.Label = "About";
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.ShowImage = true;
            this.btnAbout.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnAbout_Click);
            // 
            // HeaderStuffcs_ribbon
            // 
            this.Name = "HeaderStuffcs_ribbon";
            this.RibbonType = "Microsoft.Outlook.Explorer";
            this.Tabs.Add(this.tabHScs);
            this.tabHScs.ResumeLayout(false);
            this.tabHScs.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.group2.ResumeLayout(false);
            this.group2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tabHScs;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnOption;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnAbout;
    }

    partial class ThisRibbonCollection
    {
        internal HeaderStuffcs_ribbon Ribbon1
        {
            get { return this.GetRibbon<HeaderStuffcs_ribbon>(); }
        }
    }
}

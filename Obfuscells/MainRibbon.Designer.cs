namespace Obfuscells {
    partial class MainRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public MainRibbon()
            : base(Globals.Factory.GetRibbonFactory()) {
            InitializeComponent();
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainRibbon));
            this.tab1 = this.Factory.CreateRibbonTab();
            this.Obfuscells = this.Factory.CreateRibbonGroup();
            this.Lockbtn = this.Factory.CreateRibbonButton();
            this.Unlockbtn = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.Obfuscells.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.Obfuscells);
            this.tab1.Label = "TabAddIns";
            this.tab1.Name = "tab1";
            // 
            // Obfuscells
            // 
            this.Obfuscells.Items.Add(this.Lockbtn);
            this.Obfuscells.Items.Add(this.Unlockbtn);
            this.Obfuscells.Label = "Obfuscells";
            this.Obfuscells.Name = "Obfuscells";
            // 
            // Lockbtn
            // 
            this.Lockbtn.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.Lockbtn.Image = ((System.Drawing.Image)(resources.GetObject("Lockbtn.Image")));
            this.Lockbtn.Label = "Encrypt";
            this.Lockbtn.Name = "Lockbtn";
            this.Lockbtn.ShowImage = true;
            this.Lockbtn.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Lockbtn_Click);
            // 
            // Unlockbtn
            // 
            this.Unlockbtn.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.Unlockbtn.Image = ((System.Drawing.Image)(resources.GetObject("Unlockbtn.Image")));
            this.Unlockbtn.Label = "Decrypt";
            this.Unlockbtn.Name = "Unlockbtn";
            this.Unlockbtn.ShowImage = true;
            this.Unlockbtn.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Unlockbtn_Click);
            // 
            // MainRibbon
            // 
            this.Name = "MainRibbon";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon1_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.Obfuscells.ResumeLayout(false);
            this.Obfuscells.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup Obfuscells;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Lockbtn;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Unlockbtn;
    }

    partial class ThisRibbonCollection {
        internal MainRibbon Ribbon1 {
            get { return this.GetRibbon<MainRibbon>(); }
        }
    }
}

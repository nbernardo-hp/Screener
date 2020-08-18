namespace Screener
{
    partial class frmScreener
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Basic Materials", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Communication Services", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Consumer Cyclical", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("Consumer Defensive", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup5 = new System.Windows.Forms.ListViewGroup("Energy", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup6 = new System.Windows.Forms.ListViewGroup("Financial", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup7 = new System.Windows.Forms.ListViewGroup("Healthcare", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup8 = new System.Windows.Forms.ListViewGroup("Industrials", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup9 = new System.Windows.Forms.ListViewGroup("Real Estate", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup10 = new System.Windows.Forms.ListViewGroup("Technology", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup11 = new System.Windows.Forms.ListViewGroup("Utilities", System.Windows.Forms.HorizontalAlignment.Left);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSave = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmExit = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAttribution = new System.Windows.Forms.ToolStripMenuItem();
            this.lstvStocks = new System.Windows.Forms.ListView();
            this.Symbol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Industry = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Fund = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Growth = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Valuation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.High52W = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Recom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CurrentRatio = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EarningsDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TotalScore = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ttpColumns = new System.Windows.Forms.ToolTip(this.components);
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAny = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmBasicMaterials = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCommunicationServices = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmConsumerCyclical = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmConsumerDefensive = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmEnergy = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmFinancial = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmHealthcare = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmIndustrials = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRealEstate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmTechnology = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmUtilities = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(893, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmSave,
            this.tsmPrint,
            this.tsmExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // tsmSave
            // 
            this.tsmSave.Name = "tsmSave";
            this.tsmSave.Size = new System.Drawing.Size(180, 22);
            this.tsmSave.Text = "Save";
            this.tsmSave.Click += new System.EventHandler(this.tsmSave_Click);
            // 
            // tsmPrint
            // 
            this.tsmPrint.Name = "tsmPrint";
            this.tsmPrint.Size = new System.Drawing.Size(180, 22);
            this.tsmPrint.Text = "Print";
            this.tsmPrint.Click += new System.EventHandler(this.tsmPrint_Click);
            // 
            // tsmExit
            // 
            this.tsmExit.Name = "tsmExit";
            this.tsmExit.Size = new System.Drawing.Size(180, 22);
            this.tsmExit.Text = "Exit";
            this.tsmExit.Click += new System.EventHandler(this.tsmExit_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmAbout,
            this.tsmAttribution});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.aboutToolStripMenuItem.Text = "Info";
            // 
            // tsmAbout
            // 
            this.tsmAbout.Name = "tsmAbout";
            this.tsmAbout.Size = new System.Drawing.Size(132, 22);
            this.tsmAbout.Text = "About";
            // 
            // tsmAttribution
            // 
            this.tsmAttribution.Name = "tsmAttribution";
            this.tsmAttribution.Size = new System.Drawing.Size(132, 22);
            this.tsmAttribution.Text = "Attribution";
            // 
            // lstvStocks
            // 
            this.lstvStocks.BackColor = System.Drawing.SystemColors.Window;
            this.lstvStocks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Symbol,
            this.Industry,
            this.Fund,
            this.Growth,
            this.Valuation,
            this.High52W,
            this.Recom,
            this.CurrentRatio,
            this.EarningsDate,
            this.TotalScore});
            this.lstvStocks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstvStocks.FullRowSelect = true;
            listViewGroup1.Header = "Basic Materials";
            listViewGroup1.Name = "Basic Materials";
            listViewGroup2.Header = "Communication Services";
            listViewGroup2.Name = "Communication Services";
            listViewGroup3.Header = "Consumer Cyclical";
            listViewGroup3.Name = "Consumer Cyclical";
            listViewGroup4.Header = "Consumer Defensive";
            listViewGroup4.Name = "Consumer Defensive";
            listViewGroup5.Header = "Energy";
            listViewGroup5.Name = "Energy";
            listViewGroup6.Header = "Financial";
            listViewGroup6.Name = "Financial";
            listViewGroup7.Header = "Healthcare";
            listViewGroup7.Name = "Healthcare";
            listViewGroup8.Header = "Industrials";
            listViewGroup8.Name = "Industrials";
            listViewGroup9.Header = "Real Estate";
            listViewGroup9.Name = "Real Estate";
            listViewGroup10.Header = "Technology";
            listViewGroup10.Name = "Technology";
            listViewGroup11.Header = "Utilities";
            listViewGroup11.Name = "Utilities";
            this.lstvStocks.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3,
            listViewGroup4,
            listViewGroup5,
            listViewGroup6,
            listViewGroup7,
            listViewGroup8,
            listViewGroup9,
            listViewGroup10,
            listViewGroup11});
            this.lstvStocks.HideSelection = false;
            this.lstvStocks.Location = new System.Drawing.Point(0, 24);
            this.lstvStocks.Name = "lstvStocks";
            this.lstvStocks.ShowItemToolTips = true;
            this.lstvStocks.Size = new System.Drawing.Size(893, 373);
            this.lstvStocks.TabIndex = 1;
            this.lstvStocks.UseCompatibleStateImageBehavior = false;
            this.lstvStocks.View = System.Windows.Forms.View.Details;
            // 
            // Symbol
            // 
            this.Symbol.Text = "Symbol";
            this.Symbol.Width = 53;
            // 
            // Industry
            // 
            this.Industry.Text = "Industry";
            this.Industry.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Industry.Width = 205;
            // 
            // Fund
            // 
            this.Fund.Text = "CM Fund";
            this.Fund.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Fund.Width = 66;
            // 
            // Growth
            // 
            this.Growth.Text = "CM Growth";
            this.Growth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Growth.Width = 71;
            // 
            // Valuation
            // 
            this.Valuation.Text = "CM Valuation";
            this.Valuation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Valuation.Width = 76;
            // 
            // High52W
            // 
            this.High52W.Text = "52 W High";
            this.High52W.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.High52W.Width = 71;
            // 
            // Recom
            // 
            this.Recom.Text = "Finviz Recom";
            this.Recom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Recom.Width = 79;
            // 
            // CurrentRatio
            // 
            this.CurrentRatio.Text = "Current Ratio";
            this.CurrentRatio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CurrentRatio.Width = 82;
            // 
            // EarningsDate
            // 
            this.EarningsDate.Text = "Earnings Date";
            this.EarningsDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.EarningsDate.Width = 82;
            // 
            // TotalScore
            // 
            this.TotalScore.Text = "Total Score";
            this.TotalScore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TotalScore.Width = 83;
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmAny,
            this.tsmBasicMaterials,
            this.tsmCommunicationServices,
            this.tsmConsumerCyclical,
            this.tsmConsumerDefensive,
            this.tsmEnergy,
            this.tsmFinancial,
            this.tsmHealthcare,
            this.tsmIndustrials,
            this.tsmRealEstate,
            this.tsmTechnology,
            this.tsmUtilities});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // tsmAny
            // 
            this.tsmAny.Name = "tsmAny";
            this.tsmAny.Size = new System.Drawing.Size(206, 22);
            this.tsmAny.Text = "Any";
            this.tsmAny.Click += new System.EventHandler(this.tsmAny_Click);
            // 
            // tsmBasicMaterials
            // 
            this.tsmBasicMaterials.Name = "tsmBasicMaterials";
            this.tsmBasicMaterials.Size = new System.Drawing.Size(206, 22);
            this.tsmBasicMaterials.Text = "Basic Materials";
            this.tsmBasicMaterials.Click += new System.EventHandler(this.tsmBasicMaterials_Click);
            // 
            // tsmCommunicationServices
            // 
            this.tsmCommunicationServices.Name = "tsmCommunicationServices";
            this.tsmCommunicationServices.Size = new System.Drawing.Size(206, 22);
            this.tsmCommunicationServices.Text = "Communication Services";
            this.tsmCommunicationServices.Click += new System.EventHandler(this.tsmCommunicationServices_Click);
            // 
            // tsmConsumerCyclical
            // 
            this.tsmConsumerCyclical.Name = "tsmConsumerCyclical";
            this.tsmConsumerCyclical.Size = new System.Drawing.Size(206, 22);
            this.tsmConsumerCyclical.Text = "Consumer Cyclical";
            this.tsmConsumerCyclical.Click += new System.EventHandler(this.tsmConsumerCyclical_Click);
            // 
            // tsmConsumerDefensive
            // 
            this.tsmConsumerDefensive.Name = "tsmConsumerDefensive";
            this.tsmConsumerDefensive.Size = new System.Drawing.Size(206, 22);
            this.tsmConsumerDefensive.Text = "Consumer Defensive";
            this.tsmConsumerDefensive.Click += new System.EventHandler(this.tsmConsumerDefensive_Click);
            // 
            // tsmEnergy
            // 
            this.tsmEnergy.Name = "tsmEnergy";
            this.tsmEnergy.Size = new System.Drawing.Size(206, 22);
            this.tsmEnergy.Text = "Energy";
            this.tsmEnergy.Click += new System.EventHandler(this.tsmEnergy_Click);
            // 
            // tsmFinancial
            // 
            this.tsmFinancial.Name = "tsmFinancial";
            this.tsmFinancial.Size = new System.Drawing.Size(206, 22);
            this.tsmFinancial.Text = "Financial";
            this.tsmFinancial.Click += new System.EventHandler(this.tsmFinancial_Click);
            // 
            // tsmHealthcare
            // 
            this.tsmHealthcare.Name = "tsmHealthcare";
            this.tsmHealthcare.Size = new System.Drawing.Size(206, 22);
            this.tsmHealthcare.Text = "Healthcare";
            this.tsmHealthcare.Click += new System.EventHandler(this.tsmHealthcare_Click);
            // 
            // tsmIndustrials
            // 
            this.tsmIndustrials.Name = "tsmIndustrials";
            this.tsmIndustrials.Size = new System.Drawing.Size(206, 22);
            this.tsmIndustrials.Text = "Industrials";
            this.tsmIndustrials.Click += new System.EventHandler(this.tsmIndustrials_Click);
            // 
            // tsmRealEstate
            // 
            this.tsmRealEstate.Name = "tsmRealEstate";
            this.tsmRealEstate.Size = new System.Drawing.Size(206, 22);
            this.tsmRealEstate.Text = "Real Estate";
            this.tsmRealEstate.Click += new System.EventHandler(this.tsmRealEstate_Click);
            // 
            // tsmTechnology
            // 
            this.tsmTechnology.Name = "tsmTechnology";
            this.tsmTechnology.Size = new System.Drawing.Size(206, 22);
            this.tsmTechnology.Text = "Technology";
            this.tsmTechnology.Click += new System.EventHandler(this.tsmTechnology_Click);
            // 
            // tsmUtilities
            // 
            this.tsmUtilities.Name = "tsmUtilities";
            this.tsmUtilities.Size = new System.Drawing.Size(206, 22);
            this.tsmUtilities.Text = "Utilities";
            this.tsmUtilities.Click += new System.EventHandler(this.tsmUtilities_Click);
            // 
            // frmScreener
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 397);
            this.Controls.Add(this.lstvStocks);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmScreener";
            this.Text = "Screener";
            this.Load += new System.EventHandler(this.frmScreener_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmSave;
        private System.Windows.Forms.ToolStripMenuItem tsmPrint;
        private System.Windows.Forms.ToolStripMenuItem tsmExit;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmAbout;
        private System.Windows.Forms.ToolStripMenuItem tsmAttribution;
        private System.Windows.Forms.ListView lstvStocks;
        private System.Windows.Forms.ColumnHeader Symbol;
        private System.Windows.Forms.ColumnHeader Industry;
        private System.Windows.Forms.ColumnHeader Fund;
        private System.Windows.Forms.ColumnHeader Growth;
        private System.Windows.Forms.ColumnHeader Valuation;
        private System.Windows.Forms.ColumnHeader High52W;
        private System.Windows.Forms.ColumnHeader Recom;
        private System.Windows.Forms.ColumnHeader CurrentRatio;
        private System.Windows.Forms.ColumnHeader EarningsDate;
        private System.Windows.Forms.ColumnHeader TotalScore;
        private System.Windows.Forms.ToolTip ttpColumns;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmAny;
        private System.Windows.Forms.ToolStripMenuItem tsmBasicMaterials;
        private System.Windows.Forms.ToolStripMenuItem tsmCommunicationServices;
        private System.Windows.Forms.ToolStripMenuItem tsmConsumerCyclical;
        private System.Windows.Forms.ToolStripMenuItem tsmConsumerDefensive;
        private System.Windows.Forms.ToolStripMenuItem tsmEnergy;
        private System.Windows.Forms.ToolStripMenuItem tsmFinancial;
        private System.Windows.Forms.ToolStripMenuItem tsmHealthcare;
        private System.Windows.Forms.ToolStripMenuItem tsmIndustrials;
        private System.Windows.Forms.ToolStripMenuItem tsmRealEstate;
        private System.Windows.Forms.ToolStripMenuItem tsmTechnology;
        private System.Windows.Forms.ToolStripMenuItem tsmUtilities;
    }
}
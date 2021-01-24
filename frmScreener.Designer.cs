﻿namespace Screener
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmScreener));
            System.Windows.Forms.ListViewGroup listViewGroup12 = new System.Windows.Forms.ListViewGroup("Basic Materials", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup13 = new System.Windows.Forms.ListViewGroup("Communication Services", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup14 = new System.Windows.Forms.ListViewGroup("Consumer Cyclical", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup15 = new System.Windows.Forms.ListViewGroup("Consumer Defensive", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup16 = new System.Windows.Forms.ListViewGroup("Energy", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup17 = new System.Windows.Forms.ListViewGroup("Financial", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup18 = new System.Windows.Forms.ListViewGroup("Healthcare", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup19 = new System.Windows.Forms.ListViewGroup("Industrials", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup20 = new System.Windows.Forms.ListViewGroup("Real Estate", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup21 = new System.Windows.Forms.ListViewGroup("Technology", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup22 = new System.Windows.Forms.ListViewGroup("Utilities", System.Windows.Forms.HorizontalAlignment.Left);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmPrintPreview = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmExit = new System.Windows.Forms.ToolStripMenuItem();
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
            this.ZacksRank = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TotalScore = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ttpColumns = new System.Windows.Forms.ToolTip(this.components);
            this.pdlogStocks = new System.Windows.Forms.PrintDialog();
            this.pdocStocks = new System.Drawing.Printing.PrintDocument();
            this.pprevStocks = new System.Windows.Forms.PrintPreviewDialog();
            this.pnlNoStocksToDisplay = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tabScreeners = new System.Windows.Forms.TabControl();
            this.tabScreener = new System.Windows.Forms.TabPage();
            this.tabScreener2 = new System.Windows.Forms.TabPage();
            this.lstvStocks2 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip1.SuspendLayout();
            this.pnlNoStocksToDisplay.SuspendLayout();
            this.tabScreeners.SuspendLayout();
            this.tabScreener.SuspendLayout();
            this.tabScreener2.SuspendLayout();
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
            this.menuStrip1.Size = new System.Drawing.Size(987, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmSave,
            this.toolStripSeparator1,
            this.tsmPrintPreview,
            this.tsmPrint,
            this.toolStripSeparator2,
            this.tsmExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // tsmSave
            // 
            this.tsmSave.Name = "tsmSave";
            this.tsmSave.Size = new System.Drawing.Size(143, 22);
            this.tsmSave.Text = "Save";
            this.tsmSave.Click += new System.EventHandler(this.tsmSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(140, 6);
            // 
            // tsmPrintPreview
            // 
            this.tsmPrintPreview.Name = "tsmPrintPreview";
            this.tsmPrintPreview.Size = new System.Drawing.Size(143, 22);
            this.tsmPrintPreview.Text = "Print Preview";
            this.tsmPrintPreview.Click += new System.EventHandler(this.tsmPrintPreview_Click);
            // 
            // tsmPrint
            // 
            this.tsmPrint.Name = "tsmPrint";
            this.tsmPrint.Size = new System.Drawing.Size(143, 22);
            this.tsmPrint.Text = "Print";
            this.tsmPrint.Click += new System.EventHandler(this.tsmPrint_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(140, 6);
            // 
            // tsmExit
            // 
            this.tsmExit.Name = "tsmExit";
            this.tsmExit.Size = new System.Drawing.Size(143, 22);
            this.tsmExit.Text = "Exit";
            this.tsmExit.Click += new System.EventHandler(this.tsmExit_Click);
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
            this.tsmAbout.Click += new System.EventHandler(this.tsmAbout_Click);
            // 
            // tsmAttribution
            // 
            this.tsmAttribution.Name = "tsmAttribution";
            this.tsmAttribution.Size = new System.Drawing.Size(132, 22);
            this.tsmAttribution.Text = "Attribution";
            this.tsmAttribution.Click += new System.EventHandler(this.tsmAttribution_Click);
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
            this.ZacksRank,
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
            this.lstvStocks.Location = new System.Drawing.Point(3, 3);
            this.lstvStocks.Name = "lstvStocks";
            this.lstvStocks.ShowItemToolTips = true;
            this.lstvStocks.Size = new System.Drawing.Size(973, 375);
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
            // ZacksRank
            // 
            this.ZacksRank.Text = "Zacks Rank";
            this.ZacksRank.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ZacksRank.Width = 92;
            // 
            // TotalScore
            // 
            this.TotalScore.Text = "Total Score";
            this.TotalScore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TotalScore.Width = 83;
            // 
            // pdlogStocks
            // 
            this.pdlogStocks.UseEXDialog = true;
            // 
            // pdocStocks
            // 
            this.pdocStocks.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pdocStocks_PrintPage);
            // 
            // pprevStocks
            // 
            this.pprevStocks.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.pprevStocks.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.pprevStocks.ClientSize = new System.Drawing.Size(400, 300);
            this.pprevStocks.Document = this.pdocStocks;
            this.pprevStocks.Enabled = true;
            this.pprevStocks.Icon = ((System.Drawing.Icon)(resources.GetObject("pprevStocks.Icon")));
            this.pprevStocks.Name = "pprevStocks";
            this.pprevStocks.Visible = false;
            // 
            // pnlNoStocksToDisplay
            // 
            this.pnlNoStocksToDisplay.Controls.Add(this.label1);
            this.pnlNoStocksToDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlNoStocksToDisplay.Location = new System.Drawing.Point(0, 24);
            this.pnlNoStocksToDisplay.Name = "pnlNoStocksToDisplay";
            this.pnlNoStocksToDisplay.Size = new System.Drawing.Size(987, 407);
            this.pnlNoStocksToDisplay.TabIndex = 2;
            this.pnlNoStocksToDisplay.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(278, 161);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(423, 50);
            this.label1.TabIndex = 0;
            this.label1.Text = "No Stocks to Display\r\n***Adjust the settings and re-run the program***";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabScreeners
            // 
            this.tabScreeners.Controls.Add(this.tabScreener);
            this.tabScreeners.Controls.Add(this.tabScreener2);
            this.tabScreeners.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabScreeners.Location = new System.Drawing.Point(0, 24);
            this.tabScreeners.Name = "tabScreeners";
            this.tabScreeners.SelectedIndex = 0;
            this.tabScreeners.Size = new System.Drawing.Size(987, 407);
            this.tabScreeners.TabIndex = 3;
            // 
            // tabScreener
            // 
            this.tabScreener.Controls.Add(this.lstvStocks);
            this.tabScreener.Location = new System.Drawing.Point(4, 22);
            this.tabScreener.Name = "tabScreener";
            this.tabScreener.Padding = new System.Windows.Forms.Padding(3);
            this.tabScreener.Size = new System.Drawing.Size(979, 381);
            this.tabScreener.TabIndex = 0;
            this.tabScreener.Text = "Screener";
            this.tabScreener.UseVisualStyleBackColor = true;
            // 
            // tabScreener2
            // 
            this.tabScreener2.Controls.Add(this.lstvStocks2);
            this.tabScreener2.Location = new System.Drawing.Point(4, 22);
            this.tabScreener2.Name = "tabScreener2";
            this.tabScreener2.Padding = new System.Windows.Forms.Padding(3);
            this.tabScreener2.Size = new System.Drawing.Size(979, 381);
            this.tabScreener2.TabIndex = 1;
            this.tabScreener2.Text = "Screener 2";
            this.tabScreener2.UseVisualStyleBackColor = true;
            // 
            // lstvStocks2
            // 
            this.lstvStocks2.BackColor = System.Drawing.SystemColors.Window;
            this.lstvStocks2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11});
            this.lstvStocks2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstvStocks2.FullRowSelect = true;
            listViewGroup12.Header = "Basic Materials";
            listViewGroup12.Name = "Basic Materials";
            listViewGroup13.Header = "Communication Services";
            listViewGroup13.Name = "Communication Services";
            listViewGroup14.Header = "Consumer Cyclical";
            listViewGroup14.Name = "Consumer Cyclical";
            listViewGroup15.Header = "Consumer Defensive";
            listViewGroup15.Name = "Consumer Defensive";
            listViewGroup16.Header = "Energy";
            listViewGroup16.Name = "Energy";
            listViewGroup17.Header = "Financial";
            listViewGroup17.Name = "Financial";
            listViewGroup18.Header = "Healthcare";
            listViewGroup18.Name = "Healthcare";
            listViewGroup19.Header = "Industrials";
            listViewGroup19.Name = "Industrials";
            listViewGroup20.Header = "Real Estate";
            listViewGroup20.Name = "Real Estate";
            listViewGroup21.Header = "Technology";
            listViewGroup21.Name = "Technology";
            listViewGroup22.Header = "Utilities";
            listViewGroup22.Name = "Utilities";
            this.lstvStocks2.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup12,
            listViewGroup13,
            listViewGroup14,
            listViewGroup15,
            listViewGroup16,
            listViewGroup17,
            listViewGroup18,
            listViewGroup19,
            listViewGroup20,
            listViewGroup21,
            listViewGroup22});
            this.lstvStocks2.HideSelection = false;
            this.lstvStocks2.Location = new System.Drawing.Point(3, 3);
            this.lstvStocks2.Name = "lstvStocks2";
            this.lstvStocks2.ShowItemToolTips = true;
            this.lstvStocks2.Size = new System.Drawing.Size(973, 375);
            this.lstvStocks2.TabIndex = 2;
            this.lstvStocks2.UseCompatibleStateImageBehavior = false;
            this.lstvStocks2.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Symbol";
            this.columnHeader1.Width = 53;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Industry";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 205;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "CM Fund";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 66;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "CM Growth";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 71;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "CM Valuation";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 76;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "EPS Next Y";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader6.Width = 71;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Finviz Recom";
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader7.Width = 79;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Target Price";
            this.columnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader8.Width = 82;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Earnings Date";
            this.columnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader9.Width = 82;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Zacks Rank";
            this.columnHeader10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader10.Width = 92;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Total Score";
            this.columnHeader11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader11.Width = 83;
            // 
            // frmScreener
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 431);
            this.Controls.Add(this.pnlNoStocksToDisplay);
            this.Controls.Add(this.tabScreeners);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmScreener";
            this.Text = "Screener";
            this.Load += new System.EventHandler(this.frmScreener_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlNoStocksToDisplay.ResumeLayout(false);
            this.pnlNoStocksToDisplay.PerformLayout();
            this.tabScreeners.ResumeLayout(false);
            this.tabScreener.ResumeLayout(false);
            this.tabScreener2.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmPrintPreview;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.PrintDialog pdlogStocks;
        private System.Drawing.Printing.PrintDocument pdocStocks;
        private System.Windows.Forms.PrintPreviewDialog pprevStocks;
        private System.Windows.Forms.ColumnHeader ZacksRank;
        private System.Windows.Forms.Panel pnlNoStocksToDisplay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabScreeners;
        private System.Windows.Forms.TabPage tabScreener;
        private System.Windows.Forms.TabPage tabScreener2;
        private System.Windows.Forms.ListView lstvStocks2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
    }
}
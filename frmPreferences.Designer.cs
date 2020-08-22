namespace Screener
{
    partial class frmPreferences
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
            this.cmbSector = new System.Windows.Forms.ComboBox();
            this.cmbPE = new System.Windows.Forms.ComboBox();
            this.errPreferences = new System.Windows.Forms.ErrorProvider(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbPrice = new System.Windows.Forms.ComboBox();
            this.cmbAverageVolume = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbRSI = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbCurrentRatio = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSaved = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkCustomPE = new System.Windows.Forms.CheckBox();
            this.chkCustomRSI = new System.Windows.Forms.CheckBox();
            this.pnlCustomPE = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.nudPEMax = new System.Windows.Forms.NumericUpDown();
            this.nudPEMin = new System.Windows.Forms.NumericUpDown();
            this.pnlCustomRSI = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.nudRSIMax = new System.Windows.Forms.NumericUpDown();
            this.nudRSIMin = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbHigh52W = new System.Windows.Forms.ComboBox();
            this.cmbSMA20 = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbSMA50 = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errPreferences)).BeginInit();
            this.pnlCustomPE.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPEMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPEMin)).BeginInit();
            this.pnlCustomRSI.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRSIMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRSIMin)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbSector
            // 
            this.cmbSector.FormattingEnabled = true;
            this.cmbSector.Items.AddRange(new object[] {
            "Any",
            "Basic Materials",
            "Communication Services",
            "Consumer Cyclical",
            "Consumer Defensive",
            "Energy",
            "Financial",
            "Healthcare",
            "Industrials",
            "Real Estate",
            "Technology",
            "Utilities"});
            this.cmbSector.Location = new System.Drawing.Point(242, 59);
            this.cmbSector.Name = "cmbSector";
            this.cmbSector.Size = new System.Drawing.Size(150, 21);
            this.cmbSector.TabIndex = 0;
            this.cmbSector.SelectedIndexChanged += new System.EventHandler(this.cmbSector_SelectedIndexChanged);
            // 
            // cmbPE
            // 
            this.cmbPE.FormattingEnabled = true;
            this.cmbPE.Items.AddRange(new object[] {
            "Any",
            "Low (<15)",
            "Profitable (<0)",
            "High (>50)",
            "Under 5",
            "Under 10",
            "Under 15",
            "Under 20",
            "Under 25",
            "Under 30",
            "Under 35",
            "Under 40",
            "Under 45",
            "Under 50",
            "Over 5",
            "Over 10",
            "Over 15",
            "Over 20",
            "Over 25",
            "Over 30",
            "Over 35",
            "Over 40",
            "Over 45",
            "Over 50"});
            this.cmbPE.Location = new System.Drawing.Point(52, 113);
            this.cmbPE.Name = "cmbPE";
            this.cmbPE.Size = new System.Drawing.Size(121, 21);
            this.cmbPE.TabIndex = 1;
            this.cmbPE.SelectedIndexChanged += new System.EventHandler(this.cmbPE_SelectedIndexChanged);
            // 
            // errPreferences
            // 
            this.errPreferences.ContainerControl = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "P/E:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 173);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Price:";
            // 
            // cmbPrice
            // 
            this.cmbPrice.FormattingEnabled = true;
            this.cmbPrice.Items.AddRange(new object[] {
            "Any",
            "Under $1",
            "Under $2",
            "Under $3",
            "Under $4",
            "Under $5",
            "Under $7",
            "Under $10",
            "Under $15",
            "Under $20",
            "Under $30",
            "Under $40",
            "Under $50",
            "Over $1",
            "Over $2",
            "Over $3",
            "Over $4",
            "Over $5",
            "Over $7",
            "Over $10",
            "Over $15",
            "Over $20",
            "Over $30",
            "Over $40",
            "Over $50",
            "Over $60",
            "Over $70",
            "Over $80",
            "Over $90",
            "Over $100",
            "$1 to $5",
            "$1 to $10",
            "$1 to $20",
            "$5 to $10",
            "$5 to $20",
            "$5 to $50",
            "$10 to $20",
            "$10 to $50",
            "$20 to $50",
            "$50 to $100"});
            this.cmbPrice.Location = new System.Drawing.Point(52, 169);
            this.cmbPrice.Name = "cmbPrice";
            this.cmbPrice.Size = new System.Drawing.Size(121, 21);
            this.cmbPrice.TabIndex = 3;
            this.cmbPrice.SelectedIndexChanged += new System.EventHandler(this.cmbPrice_SelectedIndexChanged);
            // 
            // cmbAverageVolume
            // 
            this.cmbAverageVolume.FormattingEnabled = true;
            this.cmbAverageVolume.Items.AddRange(new object[] {
            "Any",
            "Under 50K",
            "Under 100K",
            "Under 500K",
            "Under 750K",
            "Under 1M",
            "Over 50K",
            "Over 100K",
            "Over 200K",
            "Over 300K",
            "Over 400K",
            "Over 500K",
            "Over 750K",
            "Over 1M",
            "Over 2M",
            "100K to 500K,",
            "100K to 1M",
            "500K to 1M",
            "500K to 10M"});
            this.cmbAverageVolume.Location = new System.Drawing.Point(381, 173);
            this.cmbAverageVolume.Name = "cmbAverageVolume";
            this.cmbAverageVolume.Size = new System.Drawing.Size(121, 21);
            this.cmbAverageVolume.TabIndex = 4;
            this.cmbAverageVolume.SelectedIndexChanged += new System.EventHandler(this.cmbAverageVolume_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(287, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Average Volume:";
            // 
            // cmbRSI
            // 
            this.cmbRSI.FormattingEnabled = true;
            this.cmbRSI.Items.AddRange(new object[] {
            "Any",
            "Overbought (90)",
            "Overbought (80)",
            "Overbought (70)",
            "Overbought (60)",
            "Oversold (40)",
            "Oversold (30)",
            "Oversold (20)",
            "Oversold (10)",
            "Not Overbought (<60)",
            "Not Overbought (<50)",
            "Not Oversold (>50)",
            "Not Oversold (>40)"});
            this.cmbRSI.Location = new System.Drawing.Point(57, 217);
            this.cmbRSI.Name = "cmbRSI";
            this.cmbRSI.Size = new System.Drawing.Size(133, 21);
            this.cmbRSI.TabIndex = 6;
            this.cmbRSI.SelectedIndexChanged += new System.EventHandler(this.cmbRSI_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 221);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "RSI:";
            // 
            // cmbCurrentRatio
            // 
            this.cmbCurrentRatio.FormattingEnabled = true;
            this.cmbCurrentRatio.Items.AddRange(new object[] {
            "Any",
            "High (>3)",
            "Low (<1)",
            "Under 1",
            "Under 0.5",
            "Over 0.5",
            "Over 1",
            "Over 1.5",
            "Over 2",
            "Over 3",
            "Over 4",
            "Over 5",
            "Over 10"});
            this.cmbCurrentRatio.Location = new System.Drawing.Point(381, 116);
            this.cmbCurrentRatio.Name = "cmbCurrentRatio";
            this.cmbCurrentRatio.Size = new System.Drawing.Size(121, 21);
            this.cmbCurrentRatio.TabIndex = 8;
            this.cmbCurrentRatio.SelectedIndexChanged += new System.EventHandler(this.cmbCurrentRatio_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(303, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Current Ratio:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(585, 26);
            this.label6.TabIndex = 10;
            this.label6.Text = "Configure the preferences used for each Sector.  Preferences will be saved and us" +
    "ed at the start of loading the application.\r\nIndividual Sector preferences are s" +
    "aved when changing a filter selection.";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(195, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Sector:";
            // 
            // btnSaved
            // 
            this.btnSaved.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSaved.Location = new System.Drawing.Point(216, 319);
            this.btnSaved.Name = "btnSaved";
            this.btnSaved.Size = new System.Drawing.Size(75, 23);
            this.btnSaved.TabIndex = 12;
            this.btnSaved.Text = "Save";
            this.btnSaved.UseVisualStyleBackColor = true;
            this.btnSaved.Click += new System.EventHandler(this.btnSaved_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(315, 319);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // chkCustomPE
            // 
            this.chkCustomPE.AutoSize = true;
            this.chkCustomPE.Location = new System.Drawing.Point(52, 139);
            this.chkCustomPE.Name = "chkCustomPE";
            this.chkCustomPE.Size = new System.Drawing.Size(61, 17);
            this.chkCustomPE.TabIndex = 14;
            this.chkCustomPE.Text = "Custom";
            this.chkCustomPE.UseVisualStyleBackColor = true;
            this.chkCustomPE.CheckedChanged += new System.EventHandler(this.chkCustomPE_CheckedChanged);
            // 
            // chkCustomRSI
            // 
            this.chkCustomRSI.AutoSize = true;
            this.chkCustomRSI.Location = new System.Drawing.Point(52, 244);
            this.chkCustomRSI.Name = "chkCustomRSI";
            this.chkCustomRSI.Size = new System.Drawing.Size(61, 17);
            this.chkCustomRSI.TabIndex = 14;
            this.chkCustomRSI.Text = "Custom";
            this.chkCustomRSI.UseVisualStyleBackColor = true;
            this.chkCustomRSI.CheckedChanged += new System.EventHandler(this.chkCustomRSI_CheckedChanged);
            // 
            // pnlCustomPE
            // 
            this.pnlCustomPE.Controls.Add(this.label9);
            this.pnlCustomPE.Controls.Add(this.label8);
            this.pnlCustomPE.Controls.Add(this.nudPEMax);
            this.pnlCustomPE.Controls.Add(this.nudPEMin);
            this.pnlCustomPE.Location = new System.Drawing.Point(47, 112);
            this.pnlCustomPE.Name = "pnlCustomPE";
            this.pnlCustomPE.Size = new System.Drawing.Size(197, 24);
            this.pnlCustomPE.TabIndex = 15;
            this.pnlCustomPE.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(102, 5);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Max:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Min:";
            // 
            // nudPEMax
            // 
            this.nudPEMax.Location = new System.Drawing.Point(132, 2);
            this.nudPEMax.Name = "nudPEMax";
            this.nudPEMax.Size = new System.Drawing.Size(59, 20);
            this.nudPEMax.TabIndex = 1;
            this.nudPEMax.ValueChanged += new System.EventHandler(this.nudPEMax_ValueChanged);
            // 
            // nudPEMin
            // 
            this.nudPEMin.Location = new System.Drawing.Point(33, 2);
            this.nudPEMin.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nudPEMin.Name = "nudPEMin";
            this.nudPEMin.Size = new System.Drawing.Size(59, 20);
            this.nudPEMin.TabIndex = 0;
            this.nudPEMin.ValueChanged += new System.EventHandler(this.nudPEMin_ValueChanged);
            // 
            // pnlCustomRSI
            // 
            this.pnlCustomRSI.Controls.Add(this.label10);
            this.pnlCustomRSI.Controls.Add(this.label11);
            this.pnlCustomRSI.Controls.Add(this.nudRSIMax);
            this.pnlCustomRSI.Controls.Add(this.nudRSIMin);
            this.pnlCustomRSI.Location = new System.Drawing.Point(53, 215);
            this.pnlCustomRSI.Name = "pnlCustomRSI";
            this.pnlCustomRSI.Size = new System.Drawing.Size(197, 24);
            this.pnlCustomRSI.TabIndex = 15;
            this.pnlCustomRSI.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(102, 5);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(30, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Max:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 5);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(27, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "Min:";
            // 
            // nudRSIMax
            // 
            this.nudRSIMax.Location = new System.Drawing.Point(132, 2);
            this.nudRSIMax.Name = "nudRSIMax";
            this.nudRSIMax.Size = new System.Drawing.Size(59, 20);
            this.nudRSIMax.TabIndex = 1;
            this.nudRSIMax.ValueChanged += new System.EventHandler(this.nudRSIMax_ValueChanged);
            // 
            // nudRSIMin
            // 
            this.nudRSIMin.Location = new System.Drawing.Point(33, 2);
            this.nudRSIMin.Name = "nudRSIMin";
            this.nudRSIMin.Size = new System.Drawing.Size(59, 20);
            this.nudRSIMin.TabIndex = 0;
            this.nudRSIMin.ValueChanged += new System.EventHandler(this.nudRSIMin_ValueChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(271, 218);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(104, 13);
            this.label12.TabIndex = 16;
            this.label12.Text = "52 Week High/Low:";
            // 
            // cmbHigh52W
            // 
            this.cmbHigh52W.FormattingEnabled = true;
            this.cmbHigh52W.Items.AddRange(new object[] {
            "Any",
            "New High",
            "New Low",
            "5% or more below High",
            "10% or more below High",
            "15% or more below High",
            "20% or more below High",
            "30% or more below High",
            "40% or more below High",
            "50% or more below High",
            "60% or more below High",
            "70% or more below High",
            "80% or more below High",
            "90% or more below High",
            "0-3% below High",
            "0-5% below High",
            "0-5% below High",
            "5% or more above Low",
            "10% or more above Low",
            "15% or more above Low",
            "20% or more above Low",
            "30% or more above Low",
            "40% or more above Low",
            "50% or more above Low",
            "60% or more above Low",
            "70% or more above Low",
            "80% or more above Low",
            "90% or more above Low",
            "100% or more above Low",
            "120% or more above Low",
            "150% or more above Low",
            "200% or more above Low",
            "300% or more above Low",
            "500% or more above Low",
            "0-3% above Low",
            "0-5% above Low",
            "0-10% above Low"});
            this.cmbHigh52W.Location = new System.Drawing.Point(381, 215);
            this.cmbHigh52W.Name = "cmbHigh52W";
            this.cmbHigh52W.Size = new System.Drawing.Size(202, 21);
            this.cmbHigh52W.TabIndex = 17;
            // 
            // cmbSMA20
            // 
            this.cmbSMA20.FormattingEnabled = true;
            this.cmbSMA20.Items.AddRange(new object[] {
            "Any",
            "Price below SMA20",
            "Price 10% below SMA20",
            "Price 20% below SMA20",
            "Price 30% below SMA20",
            "Price 40% below SMA20",
            "Price 50% below SMA20",
            "Price above SMA20",
            "Price 10% above SMA20",
            "Price 20% above SMA20",
            "Price 30% above SMA20",
            "Price 40% above SMA20",
            "Price 50% above SMA20",
            "Price crossed SMA20",
            "Price crossed SMA20 above",
            "Price crossed SMA20 below",
            "SMA20 crossed SMA50",
            "SMA20 crossed SMA50 above",
            "SMA20 crossed SMA50 below",
            "SMA20 crossed SMA200",
            "SMA20 crossed SMA200 above",
            "SMA20 crossed SMA200 below",
            "SMA20 above SMA50",
            "SMA20 below SMA50",
            "SMA20 above SMA200",
            "SMA20 below SMA200"});
            this.cmbSMA20.Location = new System.Drawing.Point(88, 272);
            this.cmbSMA20.Name = "cmbSMA20";
            this.cmbSMA20.Size = new System.Drawing.Size(187, 21);
            this.cmbSMA20.TabIndex = 18;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 276);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(70, 13);
            this.label13.TabIndex = 19;
            this.label13.Text = "20-Day SMA:";
            // 
            // cmbSMA50
            // 
            this.cmbSMA50.FormattingEnabled = true;
            this.cmbSMA50.Items.AddRange(new object[] {
            "Any",
            "Price below SMA50",
            "Price 10% below SMA50",
            "Price 20% below SMA50",
            "Price 30% below SMA50",
            "Price 40% below SMA50",
            "Price 50% below SMA50",
            "Price above SMA50",
            "Price 10% above SMA50",
            "Price 20% above SMA50",
            "Price 30% above SMA50",
            "Price 40% above SMA50",
            "Price 50% above SMA50",
            "Price crossed SMA50",
            "Price crossed SMA50 above",
            "Price crossed SMA50 below",
            "SMA50 crossed SMA20",
            "SMA50 crossed SMA20 above",
            "SMA50 crossed SMA20 below",
            "SMA50 crossed SMA200",
            "SMA50 crossed SMA200 above",
            "SMA50 crossed SMA200 below",
            "SMA50 above SMA20",
            "SMA50 below SMA20",
            "SMA50 above SMA200",
            "SMA50 below SMA200"});
            this.cmbSMA50.Location = new System.Drawing.Point(379, 272);
            this.cmbSMA50.Name = "cmbSMA50";
            this.cmbSMA50.Size = new System.Drawing.Size(187, 21);
            this.cmbSMA50.TabIndex = 18;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(303, 276);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(70, 13);
            this.label14.TabIndex = 19;
            this.label14.Text = "50-Day SMA:";
            // 
            // frmPreferences
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 365);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cmbSMA50);
            this.Controls.Add(this.cmbSMA20);
            this.Controls.Add(this.cmbHigh52W);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.pnlCustomRSI);
            this.Controls.Add(this.pnlCustomPE);
            this.Controls.Add(this.chkCustomRSI);
            this.Controls.Add(this.chkCustomPE);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSaved);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbCurrentRatio);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbRSI);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbAverageVolume);
            this.Controls.Add(this.cmbPrice);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbPE);
            this.Controls.Add(this.cmbSector);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPreferences";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Preferences";
            ((System.ComponentModel.ISupportInitialize)(this.errPreferences)).EndInit();
            this.pnlCustomPE.ResumeLayout(false);
            this.pnlCustomPE.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPEMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPEMin)).EndInit();
            this.pnlCustomRSI.ResumeLayout(false);
            this.pnlCustomRSI.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRSIMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRSIMin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbSector;
        private System.Windows.Forms.ComboBox cmbPE;
        private System.Windows.Forms.ErrorProvider errPreferences;
        private System.Windows.Forms.ComboBox cmbPrice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbRSI;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbAverageVolume;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbCurrentRatio;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSaved;
        private System.Windows.Forms.Panel pnlCustomRSI;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown nudRSIMax;
        private System.Windows.Forms.NumericUpDown nudRSIMin;
        private System.Windows.Forms.Panel pnlCustomPE;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nudPEMax;
        private System.Windows.Forms.NumericUpDown nudPEMin;
        private System.Windows.Forms.CheckBox chkCustomRSI;
        private System.Windows.Forms.CheckBox chkCustomPE;
        private System.Windows.Forms.ComboBox cmbHigh52W;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbSMA20;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cmbSMA50;
    }
}


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
            ((System.ComponentModel.ISupportInitialize)(this.errPreferences)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbSector
            // 
            this.errPreferences.SetError(this.cmbSector, "You must select a valid Sector");
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
            this.cmbSector.Location = new System.Drawing.Point(177, 76);
            this.cmbSector.Name = "cmbSector";
            this.cmbSector.Size = new System.Drawing.Size(150, 21);
            this.cmbSector.TabIndex = 0;
            // 
            // cmbPE
            // 
            this.errPreferences.SetError(this.cmbPE, "Select a value for P/E from the dropdown menu!");
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
            this.cmbPE.Location = new System.Drawing.Point(52, 130);
            this.cmbPE.Name = "cmbPE";
            this.cmbPE.Size = new System.Drawing.Size(121, 21);
            this.cmbPE.TabIndex = 1;
            // 
            // errPreferences
            // 
            this.errPreferences.ContainerControl = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "P/E:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 183);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Price:";
            // 
            // cmbPrice
            // 
            this.errPreferences.SetError(this.cmbPrice, "Select a value for Price from the dropdown menu!");
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
            this.cmbPrice.Location = new System.Drawing.Point(52, 179);
            this.cmbPrice.Name = "cmbPrice";
            this.cmbPrice.Size = new System.Drawing.Size(121, 21);
            this.cmbPrice.TabIndex = 3;
            // 
            // cmbAverageVolume
            // 
            this.errPreferences.SetError(this.cmbAverageVolume, "Select a value for Average Volume from the dropdown menu!");
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
            this.cmbAverageVolume.Location = new System.Drawing.Point(325, 180);
            this.cmbAverageVolume.Name = "cmbAverageVolume";
            this.cmbAverageVolume.Size = new System.Drawing.Size(121, 21);
            this.cmbAverageVolume.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(231, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Average Volume:";
            // 
            // cmbRSI
            // 
            this.errPreferences.SetError(this.cmbRSI, "Select a value for RSI from the dropdown menu!");
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
            this.cmbRSI.Location = new System.Drawing.Point(186, 241);
            this.cmbRSI.Name = "cmbRSI";
            this.cmbRSI.Size = new System.Drawing.Size(121, 21);
            this.cmbRSI.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(148, 245);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "RSI:";
            // 
            // cmbCurrentRatio
            // 
            this.errPreferences.SetError(this.cmbCurrentRatio, "Select a value for Current Ratio from the dropdown menu!");
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
            this.cmbCurrentRatio.Location = new System.Drawing.Point(325, 130);
            this.cmbCurrentRatio.Name = "cmbCurrentRatio";
            this.cmbCurrentRatio.Size = new System.Drawing.Size(121, 21);
            this.cmbCurrentRatio.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(247, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Current Ratio:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(91, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(295, 26);
            this.label6.TabIndex = 10;
            this.label6.Text = "Configure the preferences used for each sector.  Preferences\r\nwill be saved and u" +
    "sed at the start of loading the application.";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(130, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Sector:";
            // 
            // btnSaved
            // 
            this.btnSaved.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSaved.Location = new System.Drawing.Point(151, 295);
            this.btnSaved.Name = "btnSaved";
            this.btnSaved.Size = new System.Drawing.Size(75, 23);
            this.btnSaved.TabIndex = 12;
            this.btnSaved.Text = "Save";
            this.btnSaved.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(250, 295);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // frmPreferences
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 336);
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
            this.Name = "frmPreferences";
            this.Text = "Preferences";
            ((System.ComponentModel.ISupportInitialize)(this.errPreferences)).EndInit();
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
    }
}


namespace Screener
{
    partial class frmSplash
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
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnScrape = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pgbProgress = new System.Windows.Forms.ProgressBar();
            this.pnlStart = new System.Windows.Forms.Panel();
            this.chkScreener2 = new System.Windows.Forms.CheckBox();
            this.chkScreener = new System.Windows.Forms.CheckBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.pnlProgress = new System.Windows.Forms.Panel();
            this.lblProgress = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.bgwScrape = new System.ComponentModel.BackgroundWorker();
            this.pnlStart.SuspendLayout();
            this.pnlProgress.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(15)))), ((int)(((byte)(53)))));
            this.btnSettings.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSettings.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnSettings.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDark;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettings.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSettings.Location = new System.Drawing.Point(40, 72);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(112, 38);
            this.btnSettings.TabIndex = 0;
            this.btnSettings.Text = "Change Scrape Settings";
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnScrape
            // 
            this.btnScrape.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(15)))), ((int)(((byte)(53)))));
            this.btnScrape.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnScrape.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnScrape.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDark;
            this.btnScrape.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnScrape.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScrape.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnScrape.Location = new System.Drawing.Point(189, 80);
            this.btnScrape.Name = "btnScrape";
            this.btnScrape.Size = new System.Drawing.Size(75, 23);
            this.btnScrape.TabIndex = 1;
            this.btnScrape.Text = "Scrape";
            this.btnScrape.UseVisualStyleBackColor = false;
            this.btnScrape.Click += new System.EventHandler(this.btnScrape_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(15)))), ((int)(((byte)(53)))));
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDark;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCancel.Location = new System.Drawing.Point(188, 81);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pgbProgress
            // 
            this.pgbProgress.Location = new System.Drawing.Point(26, 39);
            this.pgbProgress.Name = "pgbProgress";
            this.pgbProgress.Size = new System.Drawing.Size(399, 23);
            this.pgbProgress.TabIndex = 3;
            // 
            // pnlStart
            // 
            this.pnlStart.BackColor = System.Drawing.Color.Transparent;
            this.pnlStart.Controls.Add(this.chkScreener2);
            this.pnlStart.Controls.Add(this.chkScreener);
            this.pnlStart.Controls.Add(this.btnSettings);
            this.pnlStart.Controls.Add(this.btnExit);
            this.pnlStart.Controls.Add(this.btnScrape);
            this.pnlStart.Location = new System.Drawing.Point(160, 114);
            this.pnlStart.Name = "pnlStart";
            this.pnlStart.Size = new System.Drawing.Size(305, 167);
            this.pnlStart.TabIndex = 4;
            // 
            // chkScreener2
            // 
            this.chkScreener2.AutoSize = true;
            this.chkScreener2.Location = new System.Drawing.Point(189, 20);
            this.chkScreener2.Name = "chkScreener2";
            this.chkScreener2.Size = new System.Drawing.Size(101, 17);
            this.chkScreener2.TabIndex = 3;
            this.chkScreener2.Text = "Run Screener 2";
            this.chkScreener2.UseVisualStyleBackColor = true;
            this.chkScreener2.CheckedChanged += new System.EventHandler(this.chkScreener2_CheckedChanged);
            // 
            // chkScreener
            // 
            this.chkScreener.AutoSize = true;
            this.chkScreener.Location = new System.Drawing.Point(40, 23);
            this.chkScreener.Name = "chkScreener";
            this.chkScreener.Size = new System.Drawing.Size(98, 17);
            this.chkScreener.TabIndex = 2;
            this.chkScreener.Text = "Run Screener?";
            this.chkScreener.UseVisualStyleBackColor = true;
            this.chkScreener.CheckedChanged += new System.EventHandler(this.chkScreener_CheckedChanged);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(15)))), ((int)(((byte)(53)))));
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDark;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnExit.Location = new System.Drawing.Point(115, 129);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // pnlProgress
            // 
            this.pnlProgress.BackColor = System.Drawing.Color.Transparent;
            this.pnlProgress.Controls.Add(this.lblProgress);
            this.pnlProgress.Controls.Add(this.lblStatus);
            this.pnlProgress.Controls.Add(this.pgbProgress);
            this.pnlProgress.Controls.Add(this.btnCancel);
            this.pnlProgress.Location = new System.Drawing.Point(87, 134);
            this.pnlProgress.Name = "pnlProgress";
            this.pnlProgress.Size = new System.Drawing.Size(450, 127);
            this.pnlProgress.TabIndex = 5;
            this.pnlProgress.Visible = false;
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgress.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblProgress.Location = new System.Drawing.Point(402, 23);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(23, 13);
            this.lblProgress.TabIndex = 5;
            this.lblProgress.Text = "0%";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblStatus.Location = new System.Drawing.Point(26, 23);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(41, 13);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "label1";
            // 
            // bgwScrape
            // 
            this.bgwScrape.WorkerReportsProgress = true;
            this.bgwScrape.WorkerSupportsCancellation = true;
            this.bgwScrape.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwScrape_DoWork);
            this.bgwScrape.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwScrape_RunWorkerCompleted);
            // 
            // frmSplash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Screener.Properties.Resources.s_Bull_versus_Bear___Financial_Markets_Concept;
            this.ClientSize = new System.Drawing.Size(624, 395);
            this.ControlBox = false;
            this.Controls.Add(this.pnlStart);
            this.Controls.Add(this.pnlProgress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSplash";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSplash";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSplash_FormClosing);
            this.Load += new System.EventHandler(this.frmSplash_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmSplash_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmSplash_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.frmSplash_MouseUp);
            this.pnlStart.ResumeLayout(false);
            this.pnlStart.PerformLayout();
            this.pnlProgress.ResumeLayout(false);
            this.pnlProgress.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnScrape;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ProgressBar pgbProgress;
        private System.Windows.Forms.Panel pnlStart;
        private System.Windows.Forms.Panel pnlProgress;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Label lblStatus;
        private System.ComponentModel.BackgroundWorker bgwScrape;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.CheckBox chkScreener2;
        private System.Windows.Forms.CheckBox chkScreener;
    }
}
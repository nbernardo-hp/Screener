namespace Screener
{
    partial class frmAttribution
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
            this.label1 = new System.Windows.Forms.Label();
            this.lnkIcon = new System.Windows.Forms.LinkLabel();
            this.btnOK = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lnkFlaticon = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Application Icon By:";
            // 
            // lnkIcon
            // 
            this.lnkIcon.AutoSize = true;
            this.lnkIcon.Location = new System.Drawing.Point(119, 9);
            this.lnkIcon.Name = "lnkIcon";
            this.lnkIcon.Size = new System.Drawing.Size(42, 13);
            this.lnkIcon.TabIndex = 1;
            this.lnkIcon.TabStop = true;
            this.lnkIcon.Text = "Freepik";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(86, 98);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(167, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "hosted on";
            // 
            // lnkFlaticon
            // 
            this.lnkFlaticon.AutoSize = true;
            this.lnkFlaticon.Location = new System.Drawing.Point(227, 9);
            this.lnkFlaticon.Name = "lnkFlaticon";
            this.lnkFlaticon.Size = new System.Drawing.Size(67, 13);
            this.lnkFlaticon.TabIndex = 1;
            this.lnkFlaticon.TabStop = true;
            this.lnkFlaticon.Text = "Flaticon.com";
            // 
            // frmAttribution
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 298);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lnkFlaticon);
            this.Controls.Add(this.lnkIcon);
            this.Controls.Add(this.label1);
            this.Name = "frmAttribution";
            this.Text = "frmAttribution";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel lnkIcon;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel lnkFlaticon;
    }
}
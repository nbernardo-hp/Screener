using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Screener
{
    public partial class frmSelectBrowser : Form
    {
        private string browser;
        public frmSelectBrowser()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.screenerIcon;
        }

        public string GetBrowserString() { return browser; }

        private void btnChrome_Click(object sender, EventArgs e)
        {
            browser = "c";
            this.Close();
        }

        private void btnFirefox_Click(object sender, EventArgs e)
        {
            browser = "f";
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }//end frmSelectBrowser
}//end Screener

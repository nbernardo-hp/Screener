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
    public partial class frmSplash : Form
    {
        Preferences splashPref;
        public frmSplash()
        {
            InitializeComponent();
        }//end default constructor

        public frmSplash(Preferences pref)
        {
            InitializeComponent();
            splashPref = pref;
        }//end one argument constructor

        private void frmSplash_Load(object sender, EventArgs e)
        {
            if(!splashPref.GetLoaded())
            {
                pnlStart.Visible = false;
                pnlProgress.Visible = true;
                //TODO START BACKGROUNDWORKER TO SCRAPE WEB
            }
        }//end frmSplash_Load

        private void btnSettings_Click(object sender, EventArgs e)
        {

        }//end btnSettings_Click

        private void btnScrape_Click(object sender, EventArgs e)
        {
            var urls = splashPref.GetFinvizUrls();
            foreach(var u in urls)
            {
                Console.WriteLine(u);
            }
            WebScraper scraper = new WebScraper(splashPref.BrowserValue);
            scraper.Start(urls);
            scraper.ParseInformation();
            pnlProgress.Visible = true;
            pnlStart.Visible = false;
        }//end btnScrape_Click

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }//end btnCancel_Click
    }//end frmSplash
}//end namespace

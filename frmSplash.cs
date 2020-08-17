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
        private Preferences splashPref;
        private WebScraper scraper;
        private bool mouseDown = false;
        private Point lastLocation;
        private Point formLocation;
        private Stack<string> urls = new Stack<string>();
        private static Dictionary<string, Dictionary<string, Stock>> stocks;
        public frmSplash()
        {
            InitializeComponent();
        }//end default constructor

        public frmSplash(Preferences pref)
        {
            InitializeComponent();
            splashPref = pref;
        }//end one argument constructor

        public Dictionary<string, Dictionary<string, Stock>> GetStocks() { return stocks; }
        private void frmSplash_Load(object sender, EventArgs e)
        {
            SetControlMouseEvents(this.Controls);
            formLocation = this.Location;
            if (!splashPref.GetLoaded())
            {
                StartWork();
            }//end if
        }//end frmSplash_Load

        private void btnSettings_Click(object sender, EventArgs e)
        {
            if (formLocation == this.Location)
            {
                frmPreferences frmPref = new frmPreferences(splashPref.GetSectorMapCopy());
                if (frmPref.ShowDialog() == DialogResult.OK)
                {
                    splashPref.SetSectorMap(frmPref.GetPreferences());
                }//end 2x nested if
            }//end if
        }//end btnSettings_Click

        private void btnScrape_Click(object sender, EventArgs e)
        {
            if(formLocation == this.Location)
            {
                StartWork();
            }
        }//end btnScrape_Click

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (formLocation == this.Location)
            {
                bgwScrape.CancelAsync();
            }
        }//end btnCancel_Click

        private void bgwScrape_DoWork(object sender, DoWorkEventArgs e)
        {
            foreach (var u in urls)
            {
                Console.WriteLine(u);
            }

            if(scraper == null)
            {
                scraper = new WebScraper(splashPref.BrowserValue);
                scraper.OnProgressUpdate += scraper_OnProgressUpdate;
            }

            scraper.Start(urls);
            scraper.ParseInformation();
        }//end bgwScrape_DoWork

        private void bgwScrape_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            stocks = scraper.GetStocks();
            this.Close();
        }//end bgwScrape_RunWorkerCompleted

        private void frmSplash_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }//end frmSplash_MouseDown

        private void frmSplash_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);
                this.Update();
            }
        }//end frmSplash_MouseMove

        private void frmSplash_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
            formLocation = this.Location;
        }//end frmSplash_MouseUp

        private void scraper_OnProgressUpdate(int val)
        {
            base.Invoke((Action)delegate
            {
                if(pgbProgress.Value < pgbProgress.Maximum)
                {
                    pgbProgress.Value += val;
                    lblStatus.Text = scraper.GetStatus();
                    lblProgress.Text = String.Format("{0}%", pgbProgress.Value);
                    if (pgbProgress.Value == 10 || pgbProgress.Value == 100)
                    {
                        lblProgress.Location = new Point(lblProgress.Location.X - 7, lblProgress.Location.Y);
                    }//end if
                }//end if
            });
        }//end scraper_OnProgressUpdate

        private void StartWork()
        {
            pnlProgress.Visible = true;
            pnlStart.Visible = false;
            lblStatus.Text = "Initializing...";
            urls = splashPref.GetFinvizUrls();
            bgwScrape.RunWorkerAsync();
        }//end StartWork

        private void SetControlMouseEvents(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                Console.WriteLine(control.Name + "\t" + control.GetType().ToString());
                control.MouseDown += this.frmSplash_MouseDown;
                control.MouseUp += this.frmSplash_MouseUp;
                control.MouseMove += this.frmSplash_MouseMove;
                if(control.GetType().Name == "Panel")
                {
                    SetControlMouseEvents(control.Controls);
                }
            }//end foreach
        }//end SetMoustControlEvents
    }//end frmSplash
}//end namespace

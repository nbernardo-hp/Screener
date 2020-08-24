﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
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
            try
            {
                InitializeComponent();
                this.Icon = Properties.Resources.screenerIcon;
            } catch
            {

            }
        }//end default constructor

        public frmSplash(Preferences pref)
        {
            try
            {
                InitializeComponent();
                this.Icon = Properties.Resources.screenerIcon;
                splashPref = pref;
            } catch
            {

            }
        }//end one argument constructor

        public Dictionary<string, Dictionary<string, Stock>> GetStocks() { return stocks; }
        private void frmSplash_Load(object sender, EventArgs e)
        {
            try
            {
                SetControlMouseEvents(this.Controls);
                formLocation = this.Location;
                if (!splashPref.GetLoaded())
                {
                    StartWork();
                }//end if
            } catch
            {

            }
        }//end frmSplash_Load

        private void btnSettings_Click(object sender, EventArgs e)
        {
            try
            {
                if (formLocation == this.Location)
                {
                    frmPreferences frmPref = new frmPreferences(splashPref.GetSectorMapCopy());
                    if (frmPref.ShowDialog() == DialogResult.OK)
                    {
                        splashPref.SetSectorMap(frmPref.GetPreferences());
                    }//end 2x nested if
                }//end if
            } catch
            {

            }
        }//end btnSettings_Click

        private void btnScrape_Click(object sender, EventArgs e)
        {
            try
            {
                if (formLocation == this.Location)
                {
                    StartWork();
                }
            } catch
            {

            }
        }//end btnScrape_Click

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (formLocation == this.Location)
                {
                    bgwScrape.CancelAsync();
                }
                if (bgwScrape.IsBusy == false)
                {
                    Application.Exit();
                }
            } catch
            {

            }
        }//end btnCancel_Click

        private void bgwScrape_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                foreach (var u in urls)
                {
                    Console.WriteLine(u);
                }
                
                if (scraper == null)
                {
                    scraper = new WebScraper(splashPref.BrowserValue, splashPref.GetPEArray(), splashPref.GetRSIArray());
                    scraper.OnProgressUpdate += scraper_OnProgressUpdate;
                }

                scraper.Start(urls);
                scraper.ParseInformation();
            } catch
            {

            }
        }//end bgwScrape_DoWork

        private void bgwScrape_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                stocks = scraper.GetStocks();
                foreach (var sector in stocks.Values)
                {
                    foreach (var stock in sector.Values)
                    {
                        stock.CalculateTotalScore();
                    }//end nested foreach
                }//end foreach
                this.Close();
            } catch
            {

            }
        }//end bgwScrape_RunWorkerCompleted

        private void frmSplash_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                mouseDown = true;
                lastLocation = e.Location;
            } catch
            {

            }
        }//end frmSplash_MouseDown

        private void frmSplash_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (mouseDown)
                {
                    this.Location = new Point(
                        (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);
                    this.Update();
                }
            } catch
            {

            }
        }//end frmSplash_MouseMove

        private void frmSplash_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                mouseDown = false;
                formLocation = this.Location;
            } catch
            {

            }
        }//end frmSplash_MouseUp

        private void scraper_OnProgressUpdate(int val, string update, int change)
        {
            base.Invoke((Action)delegate
            {
                pgbProgress.Maximum += change;
                if(pgbProgress.Value < pgbProgress.Maximum)
                {
                    pgbProgress.Value = (update != "Finalizing..." ? pgbProgress.Value + val : pgbProgress.Maximum);
                    lblStatus.Text = update;
                    lblProgress.Text = String.Format("{0:0.0}%", (update != "Finalizing..." ? ((double)pgbProgress.Value / (double)pgbProgress.Maximum) * 100 : 100));
                    if (pgbProgress.Value == 10 || pgbProgress.Value == 100)
                    {
                        lblProgress.Location = new Point(lblProgress.Location.X - 7, lblProgress.Location.Y);
                    }//end if
                }//end if
            });
        }//end scraper_OnProgressUpdate(int, string)

        private void GetDriver(string browser)
        {
            try
            {
                string file = "chromedriver_win32.zip";
                string path = AppDomain.CurrentDomain.BaseDirectory;
                string url = "https://chromedriver.storage.googleapis.com/84.0.4147.30/chromedriver_win32.zip";

                if (browser == "f")
                {
                    file = String.Format("geckodriver-v0.27.0-win{0}.zip", (Environment.Is64BitOperatingSystem ? "64" : "32"));
                    url = "https://github.com/mozilla/geckodriver/releases/download/v0.27.0/" + file;
                }//end if

                WebClient client = new WebClient();
                client.DownloadFile(url, Path.Combine(path, file));


                //System.IO.Compression.ZipFile.ExtractToDirectory(zipPath, extractPath);
            } catch
            {

            }//end try-catch
        }//end GetDriver
        private void StartWork()
        {
            try
            {
                pnlProgress.Visible = true;
                pnlStart.Visible = false;
                urls = splashPref.GetFinvizUrls();
                bgwScrape.RunWorkerAsync();
            } catch
            {

            }//end try-catch
        }//end StartWork

        private void SetControlMouseEvents(Control.ControlCollection controls)
        {
            try
            {
                foreach (Control control in controls)
                {
                    control.MouseDown += this.frmSplash_MouseDown;
                    control.MouseUp += this.frmSplash_MouseUp;
                    control.MouseMove += this.frmSplash_MouseMove;
                    if (control.GetType().Name == "Panel")
                    {
                        SetControlMouseEvents(control.Controls);
                    }
                }//end foreach
            } catch
            {
                
            }
        }//end SetMoustControlEvents
    }//end frmSplash
}//end namespace
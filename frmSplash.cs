using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Windows.Forms;

namespace Screener
{
    public partial class frmSplash : Form
    {
        private Preferences splashPref;
        private WebScraper scraper;
        public static bool cancelled = false;
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
            } catch (Exception ex)
            {
                frmScreener.ErrorMessage(ex);
            }
        }//end default constructor

        public frmSplash(Preferences pref)
        {
            try
            {
                InitializeComponent();
                this.Icon = Properties.Resources.screenerIcon;
                splashPref = pref;
            } catch (Exception ex)
            {
                frmScreener.ErrorMessage(ex);
            }
        }//end one argument constructor

        public bool CancelledValue
        {
            get { return cancelled; }
            set { cancelled = value; }
        }
        public static bool GetCancelled() { return cancelled; }
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
            } catch (Exception ex)
            {
                frmScreener.ErrorMessage(ex);
            }
        }//end frmSplash_Load

        private void btnSettings_Click(object sender, EventArgs e)
        {
            try
            {
                if (formLocation == this.Location)
                {
                    frmPreferences frmPref = new frmPreferences(splashPref.GetSectorMapCopy(), splashPref.DontShowAgainValue);
                    if (frmPref.ShowDialog() == DialogResult.OK)
                    {
                        splashPref.SetSectorMap(frmPref.GetPreferences());
                        splashPref.DontShowAgainValue = frmPref.GetDontShowAgain();
                    }//end 2x nested if
                }//end if
            } catch (Exception ex)
            {
                frmScreener.ErrorMessage(ex);
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
            } catch (Exception ex)
            {
                frmScreener.ErrorMessage(ex);
            }
        }//end btnScrape_Click

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (formLocation == this.Location)
                {
                    CancelledValue = true;
                    bgwScrape.CancelAsync();
                }
                if (bgwScrape.IsBusy == false)
                {
                    Environment.Exit(0);
                }
            } catch (Exception ex)
            {
                frmScreener.ErrorMessage(ex);
            }
        }//end btnCancel_Click

        private void bgwScrape_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if(bgwScrape.CancellationPending == true)
                {
                    e.Cancel = true;
                } else
                {
                    foreach (var u in urls)
                    {
                        Console.WriteLine(u);
                    }

                    if (!splashPref.GetLoaded())
                    {
                        GetDriver(splashPref.BrowserValue);
                    }

                    if (scraper == null)
                    {
                        scraper = new WebScraper(splashPref.BrowserValue, splashPref.GetPEArray(), splashPref.GetRSIArray());
                        scraper.OnProgressUpdate += scraper_OnProgressUpdate;
                    }

                    scraper.Start(urls);
                    scraper.ParseInformation();
                }//end if-else
            } catch (Exception ex)
            {
                frmScreener.ErrorMessage(ex);
            }
        }//end bgwScrape_DoWork

        private void bgwScrape_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if(bgwScrape.CancellationPending)
                {
                    Environment.Exit(0);
                } else
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
                }//end if-else
            } catch (Exception ex)
            {
                frmScreener.ErrorMessage(ex);
            }
        }//end bgwScrape_RunWorkerCompleted

        private void frmSplash_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                mouseDown = true;
                lastLocation = e.Location;
            } catch (Exception ex)
            {
                frmScreener.ErrorMessage(ex);
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
            } catch (Exception ex)
            {
                frmScreener.ErrorMessage(ex);
            }
        }//end frmSplash_MouseMove

        private void frmSplash_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                mouseDown = false;
                formLocation = this.Location;
            } catch (Exception ex)
            {
                frmScreener.ErrorMessage(ex);
            }
        }//end frmSplash_MouseUp

        private void scraper_OnProgressUpdate(int val, string update, int change)
        {
            base.Invoke((Action)delegate
            {
                pgbProgress.Maximum += change;
                if(pgbProgress.Value < pgbProgress.Maximum)
                {
                    pgbProgress.Value = (update != "Finalizing..." && update != "Cancelling..." ? pgbProgress.Value + val : pgbProgress.Maximum);
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

                if(!File.Exists(Path.Combine(path, (browser == "f" ? "geckodriver.exe" : "chromedriver.exe"))))
                {
                    WebClient client = new WebClient();
                    client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgress);
                    client.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadComplete);
                    client.DownloadFile(url, Path.Combine(path, file));
                }//end if

                ZipFile.ExtractToDirectory(Path.Combine(path, file), path);
                //System.IO.Compression.ZipFile.ExtractToDirectory(zipPath, extractPath);
            } catch(Exception ex)
            {
                frmScreener.ErrorMessage(ex);
            }//end try-catch
        }//end GetDriver

        private void DownloadComplete(object sender, AsyncCompletedEventArgs e)
        {

        }//end DownloadComplete
        private void DownloadProgress(object sender, DownloadProgressChangedEventArgs e)
        {
            pgbProgress.Maximum = (int)e.TotalBytesToReceive;
            lblProgress.Text = e.ProgressPercentage.ToString();
        }//end DownloadProgress

        private void StartWork()
        {
            try
            {
                pnlProgress.Visible = true;
                pnlStart.Visible = false;
                lblStatus.Text = "Initializing...";
                urls = splashPref.GetFinvizUrls();
                bgwScrape.RunWorkerAsync();
            } catch (Exception ex)
            {
                frmScreener.ErrorMessage(ex);
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
            } catch (Exception ex)
            {
                frmScreener.ErrorMessage(ex);
            }
        }//end SetMoustControlEvents
    }//end frmSplash
}//end namespace
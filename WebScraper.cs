using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace Screener
{
    class WebScraper
    {
        public delegate void ProgressUpdate(int i, string update, int change);
        public event ProgressUpdate OnProgressUpdate;
        private Dictionary<string, Dictionary<string, Stock>> stocks;
        private dynamic driver;
        private dynamic options;
        private int timeOuts = 0;
        private List<object[]> chartMillRows = new List<object[]>();
        private List<string[]> finvizRows = new List<string[]>();
        private List<string[]> zacksText = new List<string[]>();
        private List<string> symbols = new List<string>();
        private Stack<string> urls = new Stack<string>();
        private Stack<string> proxies = new Stack<string>();
        private string status = "";
        private string[] chartMillUrl = new string[2] { "https://www.chartmill.com/stock/stock-charts?ticker=", "&v=16&s=t&sd=ASC" };
        private string[] sectorHeaders = { "Basic Materials", "Communication Services", "Consumer Cyclical", "Consumer Defensive", "Energy", "Financial", "Healthcare", "Industrials", "Real Estate", "Technology", "Utilities" };
        private string[] zacksUrl = new String[2] { "https://www.zacks.com/stock/quote/", "?q=" };
        private string[] pe;
        private string[] rsi;
        public WebScraper(string browser, string[] pe, string[] rsi)
        {
            if (browser == "c")
            {
                options = new ChromeOptions();
                options.AddArgument("--incognito");
                driver = new ChromeDriver(options);
            }
            else
            {
                options = new FirefoxOptions();
                options.AddArgument("-private");
                driver = new FirefoxDriver(options);
            }//end if-else
            this.pe = pe;
            this.rsi = rsi;
        }//end one argument constructor

        public void Start(Stack<string> urls)
        {
            this.urls = urls;
            GetProxies();
            ScrapeFinviz();
            foreach (var f in finvizRows)
            {
                Console.WriteLine(String.Format("{0} {1} {2} {3} {4} {5} {6} {7} {8}", f[0], f[1], f[2], f[3], f[4], f[5], f[6], f[7], f[8]));
            }

            if (symbols != null && symbols.Count > 0)
            {

                ScrapeChartMill();
            }//end if

            if(chartMillRows != null && chartMillRows.Count > 0)
            {
                ScrapeZacks();
            }//end if

            ChangeProgress(1, "Finalizing...");
            driver.Close();
            driver.Dispose();
            driver.Quit();
        }//end Start

        public void ParseInformation()
        {
            stocks = new Dictionary<string, Dictionary<string, Stock>>()
            {
                ["Basic Materials"] = new Dictionary<string, Stock>(),
                ["Communication Services"] = new Dictionary<string, Stock>(),
                ["Consumer Cyclical"] = new Dictionary<string, Stock>(),
                ["Consumer Defensive"] = new Dictionary<string, Stock>(),
                ["Energy"] = new Dictionary<string, Stock>(),
                ["Financial"] = new Dictionary<string, Stock>(),
                ["Healthcare"] = new Dictionary<string, Stock>(),
                ["Industrials"] = new Dictionary<string, Stock>(),
                ["Real Estate"] = new Dictionary<string, Stock>(),
                ["Technology"] = new Dictionary<string, Stock>(),
                ["Utilities"] = new Dictionary<string, Stock>()
            };
            for (int i = 0; i < chartMillRows.Count; i++)
            {
                string symbol = chartMillRows[i][0].ToString();
                ChangeProgress(1, String.Format("Parsing Stock information - {0}  {1}/{2}", symbol, i + 1, finvizRows.Count));
                int fundValue = (int)(double.Parse(chartMillRows[i][1].ToString()) * 2);
                if (fundValue >= 5)
                {
                    var finvizRow = finvizRows.Select(x => x).Where(x => x[0].Equals(symbol)).First();
                    Stock temp = new Stock();
                    temp.SymbolValue = symbol;
                    temp.FundValue = fundValue;
                    temp.GrowthValue = (int)(double.Parse(chartMillRows[i][2].ToString()) * 2);
                    temp.ValuationValue = (int)(double.Parse(chartMillRows[i][3].ToString()) * 2);
                    temp.IndustryValue = finvizRow[2];
                    temp.CurrentRatioValue = (finvizRow[4] != "-" ? double.Parse(finvizRow[4]) : Double.MinValue);

                    var high = finvizRow[5].Remove(finvizRow[5].IndexOf("%"));
                    temp.High52WValue = (high != "-" ? double.Parse(high) : Double.MinValue);
                    temp.RecomValue = (finvizRow[7] != "-" ? double.Parse(finvizRow[7]) : Double.MinValue);
                    temp.SetEarningsDate(finvizRow[8]);
                    temp.ZacksRankValue = int.Parse(zacksText[i][0]);
                    temp.ZacksStringValue = zacksText[i][1];

                    stocks[finvizRow[1]].Add(temp.SymbolValue, temp);
                }//end if
            }//end for
        }//end ParseInformation

        /// <summary>
        /// Returns the status string to the calling function
        /// </summary>
        /// <returns>The status string</returns>
        public string GetStatus() { return status; }

        /// <summary>
        /// Returns the Dictionary containing all the Stock information to the calling program
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, Dictionary<string, Stock>> GetStocks() { return stocks; }

        /// <summary>
        /// Filters the stocks scraped from ChartMill to determine if they should be scraped on Zacks as well
        /// </summary>
        private void FilterChartMillStocks()
        {
            symbols = new List<string>();
            /*Loop through each element in chartMillRows and determine if the Fund value is >= 2.5.  If not remove the row
             *from the List.  If it is increment the counter to move to the next Stock object and add the symbol to a List*/
            int i = 0;
            while(i < chartMillRows.Count)
            {
                if(double.Parse(chartMillRows[i].ElementAt(1).ToString()) < 2.5)
                {
                    chartMillRows.RemoveAt(i);
                } else
                {
                    symbols.Add(chartMillRows[i].ElementAt(0).ToString());
                    i++;
                }//end if
            }//end while
        }//end FilterChartMillStocks

        /// <summary>
        /// Loops through the items after scraping Finviz to determine if they should be scraped on ChartMill or removed
        /// </summary>
        private void FilterFinvizStocks()
        {
            int[] peIndexes = GetCustomIndexes(pe);
            int[] rsiIndexes = GetCustomIndexes(rsi);
            for (int i = 0; i < sectorHeaders.Length; i++)
            {
                //start at i+1 because GetCustomIndexes will include the Any Sector as an option at index 0.  Always want to exclude
                if (peIndexes.Contains(i + 1) || rsiIndexes.Contains(i + 1))
                {
                    var check = finvizRows.Select(s => s).Where(s => s[1].Equals(sectorHeaders[i])).ToList();
                    for (int j = 0; j < check.Count; j++)
                    {
                        bool[] isValid = new bool[] { true, true };

                        //Check the PE value of all Stocks in the current Sector if the index is in the array
                        if (peIndexes.Contains(i + 1))
                        {
                            isValid[0] = (check[j][3] != "-" ? CheckPEOrRSI(double.Parse(check[j][3]), pe[i + 1]) : false);
                        }//end if

                        //Check the RSI value of all Stocks in the current Sector if the index is in the array
                        if (rsiIndexes.Contains(i + 1))
                        {
                            isValid[1] = (check[j][3] != "-" ? CheckPEOrRSI(double.Parse(check[j][6]), rsi[i + 1]) : false);
                        }//end if

                        Console.WriteLine(String.Format("pe filter={0}  rsi filter={1} - pe={2} rsi={3} - isValid[0]={4} isValid[1]={5}", pe[i + 1], rsi[i + 1], check[j][3], check[j][6], isValid[0], isValid[1]));
                        //Remove the Stock from finvizRows if either of comes back false
                        if (!isValid[0] || !isValid[1])
                        {
                            finvizRows.Remove(finvizRows.Find(s => s[0].Equals(check[j][0])));
                            Console.WriteLine(check[j][0] + " removed");
                        }
                    }//end nested for
                }//end if
            }//end for
        }//end FilterFinvizStocks

        private int[] GetCustomIndexes(string[] filter)
        {
            var temp = Array.FindAll(filter, s => s.Contains("/"));
            int[] res = new int[temp.Length];
            int i = 0;
            foreach (var t in temp)
            {
                res[i] = Array.FindIndex(filter, x => x.Equals(t));
                i++;
            }
            return res;
        }//end GetIndexes

        private bool CheckPEOrRSI(double value, string filter)
        {
            var temp = filter.Split('/');
            //Holds the min and max values, min index 0   max index 1
            double[] minMax = new double[] { double.Parse(temp[0]), double.Parse(temp[1]) };
            if (value < minMax[0] || minMax[1] < value)
            {
                return false;
            }
            return true;
        }//end CheckPEOrRSI

        private void GetProxies()
        {

            driver.Url = "https://free-proxy-list.net/";
            driver.Navigate();
            for (int p = 0; p < 10; p++)
            {
                System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> rows = driver.FindElements(By.CssSelector("tr[role=\"row\"]"));

                for (int i = 1; i < rows.Count; i++)
                {
                    ChangeProgress(0, String.Format("Getting proxy IP addresses {0}/200...", proxies.Count + 1));
                    var temp = rows[i].Text.Split(' ');
                    proxies.Push(temp[0]);
                }//end for
                driver.FindElement(By.CssSelector("#proxylisttable_next > a:nth-child(1)")).Click();
            }
            SetProxy();
        }//end GetProxies()

        private void SetProxy()
        {
            Proxy proxy = new Proxy();
            if (proxies.Count() > 0)
            {
                ChangeProgress(0, String.Format("Setting proxy IP address {0}...", proxies.Peek()));
                proxy.HttpProxy = proxies.Pop();
                options.Proxy = proxy;
            }
            else
            {
                GetProxies();
            }//end if-else
        }//end SetProxy
        private void ScrapeFinviz()
        {
            int current = 0;
            int sect = 0;
            while (urls.Count > 0)
            {
                ChangeProgress(1, String.Format("Scraping Finviz - {0}", sectorHeaders[sect]));
                int i = 0;
                int pages = 0;
                driver.Url = urls.Pop();
                driver.Navigate();
                var pagination = new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(ExpectedConditions.ElementExists(By.ClassName("screener_pagination")));
                System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> sectorPages = driver.FindElements(By.ClassName("screener-pages"));

                if (sectorPages != null && sectorPages.Count > 0)
                {
                    pages = int.Parse(sectorPages.Last().Text);
                }//end if

                //TakeScreenshot().Save(Path.Combine("C:\\Users\\N\\Pictures\\Run3", String.Format("{0}Page{1}.png", sectorHeaders[sect], i + 1)), ImageFormat.Png);

                do
                {
                    try
                    {
                        Console.WriteLine("In try");
                        ChangeProgress(0, String.Format("Scraping Finviz - {0}", sectorHeaders[sect]));
                        var table = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#screener-content > table:nth-child(1) > tbody:nth-child(1) > tr:nth-child(4) > td:nth-child(1) > table:nth-child(1) > tbody:nth-child(1)")));
                        var rows = table.FindElements(By.TagName("tr"));
                        for (int j = 1; j < rows.Count; j++)
                        {
                            var split = rows.ElementAt(j).Text.Split(new char[] { '\r', '\n' });
                            var temp = from s in split
                                       where s != ""
                                       select s;
                            ChangeProgress(1, String.Format("Scraping Finviz - {0} - {1} {2}/{3}", sectorHeaders[sect], temp.ElementAt(0), j + 1, rows.Count - 1));
                            finvizRows.Add(temp.ToArray());
                        }//end for

                        ChangeProgress(0, String.Format("Scraping Finviz - {0}", sectorHeaders[sect]), finvizRows.Count - current);
                        current = finvizRows.Count;

                        /*if (IsElementPresent(By.ClassName("modal-elite-ad_content")))
                        {
                            driver.FindElement(By.ClassName("modal-elite-ad_content")).Click();
                        }//end if*/

                        SetProxy();
                        if (i < pages)
                        {
                            string temp = driver.Url;
                            int end = temp.LastIndexOf('&');
                            temp = temp.Remove(end) + String.Format("&r={0}", (i + 1) * 20 + 1) + temp.Remove(0, end);
                            driver.Url = temp;
                            driver.Navigate();
                        }
                        i++;
                    } catch (TimeoutException)
                    {
                        timeOuts++;
                        Console.WriteLine("In Finviz catch.  timeOuts = " + timeOuts.ToString());
                        if(timeOuts > 4)
                        {
                            frmScreener.ErrorMessage(new Exception("Number of browser timeouts exceded.  Consider taking the following actions and try again.\n1. Clear the browsers cached images and files.\n2. Download an Ad Blocker extension.\n3. Close open browsers.\n4. Close additional running applications."));
                            Environment.Exit(1);
                        }
                    }//end try-catch
                } while (i < pages);//end do while
                sect++;
            }//end while
            FilterFinvizStocks();
            symbols = (from f in finvizRows select f.ElementAt(0)).ToList();
            symbols.Sort();
        }//end ScrapeFinviz

        /// <summary>
        /// Determines if the element is present on the page or not to prevent freezing when shown
        /// </summary>
        /// <param name="by"></param>
        /// <returns></returns>
        private bool IsElementPresent(By by)
        {
            try
            {
                return driver.FindElement(by).Displayed;
            } catch (NoSuchElementException)
            {
                return false;
            }//end try-catch

        }//end IsElementPresent
        private void ScrapeChartMill()
        {
            int numSymbols = 20;
            int currentStock = 0;
            int symbolsCount = symbols.Count;
            for (int i = 0; i < symbolsCount; i += numSymbols)
            {
                try
                {
                    Console.WriteLine("In ChartMill try");
                    ChangeProgress(0, "Loading ChartMill page...");
                    if (numSymbols > symbolsCount)
                    {
                        numSymbols = symbolsCount - 1;
                    }
                    else if (i + numSymbols > symbolsCount)
                    {
                        numSymbols = symbolsCount - i;
                    }

                    string url = GetChartMillUrl(symbols.GetRange(i, numSymbols));
                    driver.Url = url;
                    driver.Navigate();

                    var table = new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/app-root/app-menu/div/mat-sidenav-container/mat-sidenav-content/app-stockcharts/app-results/div[2]/div/div/app-property-display/div/div/div/mat-card/mat-card-content/div/table/tbody")));
                    var rows = table.FindElements(By.TagName("tr"));
                    foreach (IWebElement r in rows)
                    {
                        var sym = r.FindElement(By.ClassName("text-primary")).Text;
                        var fund = r.FindElements(By.ClassName("cdk-column-fa"));
                        var growth = r.FindElements(By.ClassName("cdk-column-gr"));
                        var val = r.FindElements(By.ClassName("cdk-column-val"));

                        ChangeProgress(1, String.Format("Scraping ChartMill - {0} {1}/{2}", sym, currentStock + 1, finvizRows.Count));

                        chartMillRows.Add(new object[4]);
                        chartMillRows[currentStock][0] = sym;
                        for (int k = 1; k < 4; k++)
                        {
                            var stars = (k == 1 ? fund : k == 2 ? growth : val);
                            var full = stars.ElementAt(0).FindElements(By.CssSelector("svg[data-icon=\"star\"]")).Select(f => f).Where(f => f.GetAttribute("data-prefix") == "fas");
                            var half = stars.ElementAt(0).FindElements(By.ClassName("fa-star-half-alt"));
                            double fullCount = full.Count();
                            double halfCount = (half != null ? (half.Count * 0.5) : 0);
                            chartMillRows[currentStock][k] = fullCount + halfCount;
                        }//end nested for
                        Console.WriteLine(String.Format("{0}   fund={1}   growth={2}   val={3}", chartMillRows[currentStock][0], chartMillRows[currentStock][1], chartMillRows[currentStock][2], chartMillRows[currentStock][3]));
                        currentStock++;
                    }
                    if (rows != null && rows.Count == 3)
                    {
                        numSymbols = 3;
                    }//end if
                    SetProxy();
                } catch (TimeoutException)
                {
                    numSymbols = 0;
                    timeOuts++;
                    Console.WriteLine("In ChartMill catch.  timeOuts = " + timeOuts.ToString());
                    if (timeOuts > 4)
                    {
                        frmScreener.ErrorMessage(new Exception("Number of browser timeouts exceded.  Consider taking the following actions and try again.\n1. Clear the browsers cached images and files.\n2. Download an Ad Blocker extension.\n3. Close open browsers.\n4. Close additional running applications."));
                        Environment.Exit(1);
                    }
                }//end try-catch
            }//end for
            FilterChartMillStocks();
        }//end ScrapeChartMill

        private string GetChartMillUrl(List<string> s) { return chartMillUrl[0] + String.Join(" ", s) + chartMillUrl[1]; }

        private int ChangeProgress(int val, string update, int change = 0)
        {
            //status = update;
            if (OnProgressUpdate != null)
            {
                OnProgressUpdate(val, update, change);
            }//end if

            return val;
        }//end changeProgress

        private void ScrapeZacks()
        {
            Console.WriteLine("In Zacks try");
            ChangeProgress(0, "Loading Zacks...", chartMillRows.Count);
            for(int i = 0; i < symbols.Count; i++)
            {
                try
                {
                    string url = String.Format("{0}{1}{2}{3}", zacksUrl[0], symbols[i], zacksUrl[1], symbols[i]);
                    ChangeProgress(1, String.Format("Scraping Zacks - {0}", symbols[i]));
                    driver.Url = url;
                    driver.Navigate();
                    zacksText.Add(driver.FindElement(By.ClassName("rank_view")).Text.Split(new char[] { '-', '\r', '\n' }));
                } catch (TimeoutException)
                {
                    i--;
                    timeOuts++;
                    Console.WriteLine("In Zacks catch.  timeOuts = " + timeOuts.ToString());
                    if (timeOuts > 4)
                    {
                        frmScreener.ErrorMessage(new Exception("Number of browser timeouts exceded.  Consider taking the following actions and try again.\n1. Clear the browsers cached images and files.\n2. Download an Ad Blocker extension.\n3. Close open browsers.\n4. Close additional running applications."));
                        Environment.Exit(1);
                    }
                }//end try-catch
            }//end for
            foreach (var s in symbols)
            {
                
            }//end foreach
        }//end ScrapeZacks

        private Bitmap TakeScreenshot()
        {
            // Get the total size of the page
            var totalWidth = (int)(long)((IJavaScriptExecutor)driver).ExecuteScript("return document.body.offsetWidth"); //documentElement.scrollWidth");
            var totalHeight = (int)(long)((IJavaScriptExecutor)driver).ExecuteScript("return  document.body.parentNode.scrollHeight");
            // Get the size of the viewport
            var viewportWidth = (int)(long)((IJavaScriptExecutor)driver).ExecuteScript("return document.body.clientWidth"); //documentElement.scrollWidth");
            var viewportHeight = (int)(long)((IJavaScriptExecutor)driver).ExecuteScript("return window.innerHeight"); //documentElement.scrollWidth");

            // We only care about taking multiple images together if it doesn't already fit
            if (totalWidth <= viewportWidth && totalHeight <= viewportHeight)
            {
                var screenshot = driver.GetScreenshot();
                return ScreenshotToImage(screenshot);
            }
            // Split the screen in multiple Rectangles
            var rectangles = new List<Rectangle>();
            // Loop until the totalHeight is reached
            for (var y = 0; y < totalHeight; y += viewportHeight)
            {
                var newHeight = viewportHeight;
                // Fix if the height of the element is too big
                if (y + viewportHeight > totalHeight)
                {
                    newHeight = totalHeight - y;
                }
                // Loop until the totalWidth is reached
                for (var x = 0; x < totalWidth; x += viewportWidth)
                {
                    var newWidth = viewportWidth;
                    // Fix if the Width of the Element is too big
                    if (x + viewportWidth > totalWidth)
                    {
                        newWidth = totalWidth - x;
                    }
                    // Create and add the Rectangle
                    var currRect = new Rectangle(x, y, newWidth, newHeight);
                    rectangles.Add(currRect);
                }
            }
            // Build the Image
            var stitchedImage = new Bitmap(totalWidth, totalHeight);
            // Get all Screenshots and stitch them together
            var previous = Rectangle.Empty;
            foreach (var rectangle in rectangles)
            {
                // Calculate the scrolling (if needed)
                if (previous != Rectangle.Empty)
                {
                    var xDiff = rectangle.Right - previous.Right;
                    var yDiff = rectangle.Bottom - previous.Bottom;
                    // Scroll
                    ((IJavaScriptExecutor)driver).ExecuteScript(String.Format("window.scrollBy({0}, {1})", xDiff, yDiff));
                }
                // Take Screenshot
                var screenshot = driver.GetScreenshot();
                // Build an Image out of the Screenshot
                var screenshotImage = ScreenshotToImage(screenshot);
                // Calculate the source Rectangle
                var sourceRectangle = new Rectangle(viewportWidth - rectangle.Width, viewportHeight - rectangle.Height, rectangle.Width, rectangle.Height);
                // Copy the Image
                using (var graphics = Graphics.FromImage(stitchedImage))
                {
                    graphics.DrawImage(screenshotImage, rectangle, sourceRectangle, GraphicsUnit.Pixel);
                }
                // Set the Previous Rectangle
                previous = rectangle;
            }
            return stitchedImage;
        }

        private static Image ScreenshotToImage(Screenshot screenshot)
        {
            Image screenshotImage;
            using (var memStream = new MemoryStream(screenshot.AsByteArray))
            {
                screenshotImage = Image.FromStream(memStream);
            }
            return screenshotImage;
        }
    }//end class
}//end namespace

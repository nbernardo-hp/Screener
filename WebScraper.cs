using System;
using System.Collections.Generic;
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
        public delegate void ProgressUpdate(int i);
        public event ProgressUpdate OnProgressUpdate;
        private List<string[]> finvizRows = new List<string[]>();
        private List<object[]> chartMillRows = new List<object[]>();
        private List<string> symbols = new List<string>();
        private Stack<string> urls = new Stack<string>();
        private Stack<string> proxies = new Stack<string>();
        private Dictionary<string, Dictionary<string, Stock>> stocks;
        private dynamic driver;
        private dynamic options;
        private string status = "";
        private string[] chartMillUrl = new string[2] { "https://www.chartmill.com/stock/stock-charts?ticker=", "&v=16&s=t&sd=ASC" };
        private string[] sectorHeaders = { "Basic Materials", "Communication Services", "Consumer Cyclical", "Consumer Defensive", "Energy", "Financial", "Healthcare", "Industrials", "Real Estate", "Technology", "Utilities" };

        public WebScraper(string browser)
        {
            if(browser == "c")
            {
                options = new ChromeOptions();
                driver = new ChromeDriver(options);
            } else
            {
                options = new FirefoxOptions();
                options.AddArgument("-private");
                driver = new FirefoxDriver(options);
            }//end if-else
        }//end one argument constructor

        public void Start(Stack<string> urls)
        {
            this.urls = urls;
            this.urls.Reverse();
            GetProxies();
            ScrapeFinviz();

            foreach (var f in finvizRows)
            {
                Console.WriteLine(String.Format("{0} {1} {2} {3} {4} {5} {6} {7} {8}", f[0], f[1], f[2], f[3], f[4], f[5], f[6], f[7], f[8]));
            }

            if(symbols != null && symbols.Count > 0)
            {

                ScrapeChartMill();
            }//end if
            ChangeProgress(1, "Finalizing...");
            driver.Close();
            driver.Dispose();
            driver.Quit();
        }//end Start

        public void ParseInformation()
        {
            stocks = new Dictionary<string, Dictionary<string, Stock>>();
            for(int i = 0; i < chartMillRows.Count; i++)
            {
                string symbol = chartMillRows[i][0].ToString();
                ChangeProgress(1, String.Format("Parsing Stock information - {0}  {1}/{2}", symbol, i + 1, finvizRows.Count));
                int fundValue = (int)(double.Parse(chartMillRows[i][1].ToString()) * 2);
                if(fundValue >= 5)
                {
                    if(!stocks.ContainsKey(finvizRows[i][1]))
                    {
                        stocks.Add(finvizRows[i][1], new Dictionary<string, Stock>());
                    }//end if

                    Stock temp = new Stock();
                    temp.SymbolValue = symbol;
                    temp.FundValue = fundValue;
                    temp.GrowthValue = (int)(double.Parse(chartMillRows[i][2].ToString()) * 2);
                    temp.ValuationValue = (int)(double.Parse(chartMillRows[i][3].ToString()) * 2);
                    temp.IndustryValue = finvizRows[i][2];
                    temp.CurrentRatioValue = (finvizRows[i][4] != "-" ? double.Parse(finvizRows[i][4]) : 0);

                    var high = finvizRows[i][5].Remove(finvizRows[i][5].IndexOf("%"));
                    temp.High52WValue = (high != "-" ? double.Parse(high) : 100);
                    temp.RecomValue = (finvizRows[i][7] != "-" ? double.Parse(finvizRows[i][7]) : 10);
                    temp.SetEarningsDate(finvizRows[i][8]);

                    stocks[finvizRows[i][1]].Add(temp.SymbolValue, temp);
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
            } else
            {
                GetProxies();
            }//end if-else
        }//end SetProxy
        private void ScrapeFinviz()
        {
            int sect = 0;
            while(urls.Count > 0)
            {
                ChangeProgress(1, String.Format("Scraping Finviz - {0}", sectorHeaders[sect]));
                int i = 0;
                int pages = 0;
                driver.Url = urls.Pop();
                driver.Navigate();

                System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> sectorPages = driver.FindElements(By.ClassName("screener-pages"));
                if (sectorPages != null && sectorPages.Count > 0)
                {
                    pages = int.Parse(sectorPages.Last().Text);
                }//end if

                do
                {
                    ChangeProgress(0, String.Format("Scraping Finviz - {0}", sectorHeaders[sect]));
                    var table = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#screener-content > table:nth-child(1) > tbody:nth-child(1) > tr:nth-child(4) > td:nth-child(1) > table:nth-child(1) > tbody:nth-child(1)")));
                    var rows = table.FindElements(By.TagName("tr"));
                    for (int j = 1; j < rows.Count; j++)
                    {
                        var split = rows.ElementAt(j).Text.Split(new char[] { '\r', '\n' });
                        var temp = from s in split
                                   where s != ""
                                   select s;
                        ChangeProgress(1, String.Format("Scraping Finviz - {0} - {1} {2}/{3}", sectorHeaders[sect], temp.ElementAt(0), j+1, rows.Count - 1));
                        finvizRows.Add(temp.ToArray());
                    }//end for

                    SetProxy();
                    if (i < pages)
                    {
                        //var tabLink = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.Elem)
                        System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> tabLink = driver.FindElements(By.ClassName("tab-link"));
                        tabLink.Last().Click();
                    }
                    i++;
                } while (i < pages);//end do while
                sect++;
            }//end while

            finvizRows.Sort((a, b) => a[0].CompareTo(b[0]));
            symbols = (from f in finvizRows select f.ElementAt(0)).ToList();
        }//end ScrapeFinviz

        private void ScrapeChartMill()
        {
            symbols.Sort();
            int numSymbols = 20;
            int currentStock = 0;
            int symbolsCount = symbols.Count;
            for (int i = 0; i < symbolsCount; i += numSymbols)
            {
                ChangeProgress(0, "Loading ChartMill page...");
                if (numSymbols > symbolsCount)
                {
                    numSymbols = symbolsCount - 1;
                } else if(i + numSymbols > symbolsCount)
                {
                    numSymbols = symbolsCount - i;
                }
                
                string url = GetChartMillUrl(symbols.GetRange(i, numSymbols));
                driver.Url = url;
                driver.Navigate();

                var table = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/app-root/app-menu/div/mat-sidenav-container/mat-sidenav-content/app-stockcharts/app-results/div[2]/div/div/app-property-display/div/div/div/mat-card/mat-card-content/div/table/tbody")));
                var rows = table.FindElements(By.TagName("tr"));
                foreach(IWebElement r in rows)
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
                if(rows != null && rows.Count == 3)
                {
                    numSymbols = 3;
                }//end if
            }//end for
        }//end ScrapeChartMill

        private string GetChartMillUrl(List<string> s) { return chartMillUrl[0] + String.Join(" ", s) + chartMillUrl[1]; }

        private int ChangeProgress(int val, string update)
        {
            status = update;
            if (OnProgressUpdate != null)
            {
                OnProgressUpdate(val);
            }//end if

            return val;
        }//end changeProgress
    }//end class
}//end namespace

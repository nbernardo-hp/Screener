using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Collections.Generic;

namespace Screener
{
    class WebScraper
    {
        private List<string[]> finvizRows = new List<string[]>();
        private List<object[]> chartMillRows = new List<object[]>();
        private List<string> symbols = new List<string>();
        private Stack<string> urls = new Stack<string>();
        private Stack<string> proxies = new Stack<string>();
        private dynamic driver;
        private dynamic options;
        private string status = "";
        private string[] chartMillUrl = new string[2] { "https://www.chartmill.com/stock/stock-charts?ticker=", "&v=16&s=t&sd=ASC" };

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
            GetProxies();
            ScrapeFinviz();

            foreach(var f in finvizRows)
            {
                Console.WriteLine(String.Format("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9}", f[0], f[1], f[2], f[3], f[4], f[5], f[6], f[7], f[8], f[9]));
            }

            if(symbols != null && symbols.Count > 0)
            {
                ScrapeChartMill();
            }//end if
        }//end Start

        private void GetProxies()
        {
            status = "Getting proxy IP addresses...";
            driver.Url = "https://free-proxy-list.net/";
            driver.Navigate();
            for (int p = 0; p < 10; p++)
            {
                System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> rows = driver.FindElements(By.CssSelector("tr[role=\"row\"]"));
                
                for (int i = 1; i < rows.Count; i++)
                {
                    var temp = rows[i].Text.Split(' ');
                    proxies.Push(temp[0]);
                }//end for
                driver.FindElement(By.CssSelector("#proxylisttable_next > a:nth-child(1)")).Click();
            }
            SetProxy();
        }//end GetProxies()

        private void SetProxy()
        {
            status = "Setting proxy IP address...";
            Proxy proxy = new Proxy();
            if (proxies.Count() > 0)
            {
                proxy.HttpProxy = proxies.Pop();
                options.Proxy = proxy;
            } else
            {
                GetProxies();
            }//end if-else
        }//end SetProxy
        private void ScrapeFinviz()
        {
            while(urls.Count > 0)
            {
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
                    IWebElement table = driver.FindElement(By.CssSelector("#screener-content > table:nth-child(1) > tbody:nth-child(1) > tr:nth-child(4) > td:nth-child(1) > table:nth-child(1) > tbody:nth-child(1)"));
                    var rows = table.FindElements(By.TagName("tr"));
                    for (int j = 1; j < rows.Count; j++)
                    {
                        finvizRows.Add(rows.ElementAt(j).Text.Split(new char[] { '\r', '\n' }));
                    }//end for

                    SetProxy();
                    if (i < pages)
                    {
                        var tabLink = driver.FindElements(By.ClassName("tab-link"));
                        tabLink.Last().Click();
                    }
                    i++;
                } while (i < pages);//end do while
            }//end while

            symbols = (from f in finvizRows select f.ElementAt(0)).ToList();
        }//end ScrapeFinviz

        private void ScrapeChartMill()
        {
            symbols.Sort();
            int numSymbols = 20;
            int symbolsCount = symbols.Count;
            int currentSymbol = 0;
            for (int i = 0; i < symbolsCount; i += numSymbols)
            {
                if(numSymbols > symbolsCount)
                {
                    numSymbols = symbolsCount;
                } else if(i + numSymbols > symbolsCount)
                {
                    numSymbols = (i + numSymbols) - symbolsCount;
                }
                
                string url = GetChartMillUrl(symbols.GetRange(i, numSymbols));
                driver.Url = url;
                driver.Navigate();

                IWebElement table = driver.FindElement(By.CssSelector(".mat-table > tbody:nth-child(2)"));
                var sym = table.FindElements(By.ClassName("text-primary"));
                var fund = table.FindElements(By.ClassName("cdk-column-fa"));
                var growth = table.FindElements(By.ClassName("cdk-column-gr"));
                var val = table.FindElements(By.ClassName("cdk-column-val"));

                if(sym.Count == 3)
                {
                    numSymbols = 3;
                }//end if

                for(int j = 0; j < sym.Count; j++)
                {
                    //sym = 0   fund = 4, growth = 5, val = 7
                }
            }//end for
        }//end ScrapeChartMill

        private string GetChartMillUrl(List<string> s) { return chartMillUrl[0] + String.Join(" ", s) + chartMillUrl[1]; }
    }//end class
}//end namespace

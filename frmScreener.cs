﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Screener
{
    public partial class frmScreener : Form
    {
        private Dictionary<string, Dictionary<string, Stock>> stocks;
        private Dictionary<string, Dictionary<string, string>> stocksAdditionalInfo;
        Preferences preferences;
        int currentSector = 0;
        int currentStock = 0;
        int screenerType;
        private string pdfPath;
        public frmScreener()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.screenerIcon;
        }//end default constructor

        public frmScreener(Dictionary<string, Dictionary<string, Stock>> stocks, Preferences pref)
        {
            InitializeComponent();
            this.Icon = Properties.Resources.screenerIcon;
            this.stocks = stocks;
            preferences = pref;
        }//end two argument constructor

        public frmScreener(Dictionary<string, Dictionary<string, Stock>> stocks, Preferences pref, Dictionary<string, Dictionary<string, string>> stocksAdditionalInfo, int screenerType)
        {
            InitializeComponent();
            this.Icon = Properties.Resources.screenerIcon;
            this.stocks = stocks;
            this.stocksAdditionalInfo = stocksAdditionalInfo;
            preferences = pref;
            this.screenerType = screenerType;
        }//end two argument constructor

        public static void ErrorMessage(Exception ex)
        {
            MessageBox.Show(String.Format("Error!  {0}", ex.Message), ex.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
        }//end ErrorMessage
        public static void OpenBrowserToUrl(string url)
        {
            try
            {

                Process.Start(url);
            }
            catch
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    url = url.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    Process.Start("xdg-open", url);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Process.Start("open", url);
                }
                else
                {
                    throw;
                }//end if-else if-else if-else
            }//end try-catch
        }//end OpenBrowserToUrl

        /// <summary>
        /// Sorts and returns the Stock objects in the provided Sector by multiple different criteria.
        /// </summary>
        /// <param name="sector"></param>
        /// <returns>The ordered Stock objects from the Sector</returns>
        public static IOrderedEnumerable<Stock> SortSectorDictionary(Dictionary<string, Stock> sector, bool secondScreener = false)
        {
            if(secondScreener)
            {
                return sector.Values.OrderByDescending(s => s.TotalScore2Value).ThenByDescending(s => s.FundValue)
                .ThenByDescending(s => s.GrowthValue).ThenByDescending(s => s.ValuationValue).ThenBy(s => s.EPSThisYValue)
                .ThenBy(s => s.EPSNextYValue).ThenByDescending(s => s.RecomValue).ThenByDescending(s => s.TargetPriceValue);
            } else
            {
                return sector.Values.OrderByDescending(s => s.TotalScoreValue).ThenByDescending(s => s.FundValue)
                .ThenByDescending(s => s.GrowthValue).ThenByDescending(s => s.ValuationValue).ThenBy(s => s.High52WValue)
                .ThenBy(s => s.RecomValue).ThenByDescending(s => s.CurrentRatioValue).ThenByDescending(s => s.GetEarningsDate());
            }//end if-else
        }//end SortStockDictionary

        /// <summary>
        /// Returns an ordered object of the Sectors from the Dictionary
        /// </summary>
        /// <param name="sectors"></param>
        /// <returns>Ordered Sectors</returns>
        public static IOrderedEnumerable<string> SortSectorKeys(IEnumerable<string> sectors)
        {
            return sectors.OrderBy(s => s);
        }//end SortSectorKeys
        private void frmScreener_Load(object sender, EventArgs e)
        {
            try
            {
                if(stocks.Count > 0)
                {
                    PopulateListView();
                    if(screenerType == 0)
                    {
                        pnlScreener1NoStocks.Visible = true;
                    } else if (screenerType == 2)
                    {
                        pnlScreener2NoStocks.Visible = true;
                    }
                    LoadFinvizWithStocks();
                } else
                {
                    pnlNoStocksToDisplay.Visible = true;
                }
                pdocStocks.DefaultPageSettings.Landscape = true;
                pdocStocks.DefaultPageSettings.Margins.Left = 10;
                pdocStocks.DefaultPageSettings.Margins.Right = 10;
                pdocStocks.DefaultPageSettings.Margins.Top = 10;
                pdocStocks.DefaultPageSettings.Margins.Bottom = 10;
            } catch (Exception ex)
            {
                ErrorMessage(ex);
            }
        }//end frmScreener_Load

        private void tsmAny_Click(object sender, EventArgs e)
        {
            LoadPreferencesForm("Any");
        }//end tsmAny_Click

        private void tsmBasicMaterials_Click(object sender, EventArgs e)
        {
            LoadPreferencesForm("Basic Materials");
        }//end tsmBasicMaterials_Click

        private void tsmCommunicationServices_Click(object sender, EventArgs e)
        {
            LoadPreferencesForm("Communication Services");
        }//end tsmCommunicationServices_Click

        private void tsmConsumerCyclical_Click(object sender, EventArgs e)
        {
            LoadPreferencesForm("Consumer Cyclical");
        }//end tsmConsumerCyclical_Click

        private void tsmConsumerDefensive_Click(object sender, EventArgs e)
        {
            LoadPreferencesForm("Consumer Defensive");
        }//end tsmConsumerDefensive_Click

        private void tsmEnergy_Click(object sender, EventArgs e)
        {
            LoadPreferencesForm("Energy");
        }//end tsmEnergy_Click

        private void tsmFinancial_Click(object sender, EventArgs e)
        {
            LoadPreferencesForm("Financial");
        }//end tsmFinancial_Click

        private void tsmHealthcare_Click(object sender, EventArgs e)
        {
            LoadPreferencesForm("Healthcare");
        }//end tsmHealthcare_Click

        private void tsmIndustrials_Click(object sender, EventArgs e)
        {
            LoadPreferencesForm("Industrials");
        }//end tsmIndustrials_Click

        private void tsmRealEstate_Click(object sender, EventArgs e)
        {
            LoadPreferencesForm("Real Estate");
        }//end tsmRealEstate_Click

        private void tsmTechnology_Click(object sender, EventArgs e)
        {
            LoadPreferencesForm("Technology");
        }//end tsmTechnology_Click

        private void tsmUtilities_Click(object sender, EventArgs e)
        {
            LoadPreferencesForm("Utilities");
        }//end tsmUtilities_Click

        private void tsmSave_Click(object sender, EventArgs e)
        {
            try
            {
                if((tabScreeners.SelectedTab == tabScreener2 && !pnlScreener2NoStocks.Visible) || (tabScreeners.SelectedTab == tabScreener && !pnlScreener1NoStocks.Visible))
                {
                    SaveDocument document;
                    SaveFileDialog save = new SaveFileDialog();
                    save.AddExtension = true;
                    save.Filter = "Excel files (*xlsx)|*.xlsx|Word files (*.docx)|*docx|Xml files (*.xml)|*.xml|Html files (*.html)|*.html";
                    if (save.ShowDialog() == DialogResult.OK)
                    {
                        string path = save.FileName;
                        string extension = path.Remove(0, path.LastIndexOf('.') + 1);
                        save.DefaultExt = extension;

                        document = new SaveDocument(path.Remove(path.LastIndexOf('\\')), path.Remove(0, path.LastIndexOf('\\') + 1));
                        if (extension == "xlsx")
                        {
                            OfficeDocumentProgressForm(document, extension);
                        }
                        else if (extension == "docx")
                        {
                            OfficeDocumentProgressForm(document, extension);
                        }
                        else if (extension == "xml")
                        {
                            document.SaveXmlDocument((tabScreeners.SelectedTab == tabScreener2 ? CreateTempDictionary(stocksAdditionalInfo.Values.Select(s => s["source"]).Distinct()) : stocks), (tabScreeners.SelectedTab == tabScreener2 ? true : false));
                        }
                        else if (extension == "pdf")
                        {
                            pdfPath = Path.Combine(path.Remove(path.LastIndexOf('\\')), path.Remove(0, path.LastIndexOf('\\') + 1));
                            tsmPrint.PerformClick();
                        }
                        else
                        {
                            document.SaveHtmlDocument((tabScreeners.SelectedTab == tabScreener2 ? CreateTempDictionary(stocksAdditionalInfo.Values.Select(s => s["source"]).Distinct()) : stocks), (tabScreeners.SelectedTab == tabScreener2 ? true : false));
                        }
                    }//end nested if
                } else
                {
                    MessageBox.Show("There are no stocks to save on this screener", "Unable to Save", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }//end if-else
                
            }
            catch (Exception ex)
            {
                ErrorMessage(ex);
            }
        }//end tsmSave_Click

        private void OfficeDocumentProgressForm(SaveDocument doc, string extension)
        {
            try
            {
                var secondScreener = (tabScreeners.SelectedTab == tabScreener2 ? true : false);
                frmOfficeDocumentProgress frm;
                if (extension == "xlsx")
                {
                    frm = new frmOfficeDocumentProgress(doc, (secondScreener ? CreateTempDictionary(stocksAdditionalInfo.Values.Select(s => s["source"]).Distinct()) : stocks), secondScreener);
                }
                else
                {
                    int rows = (secondScreener ? stocksAdditionalInfo.Values.Select(s => s["source"]).Distinct().Count() : stocks.Keys.Count()) + 1;
                    if(secondScreener)
                    {
                        rows += stocksAdditionalInfo.Keys.Count;
                    } else
                    {
                        foreach (var kvp in stocks.Values)
                        {
                            rows += kvp.Values.Count();
                        }
                    }
                    frm = new frmOfficeDocumentProgress(doc, (secondScreener ? CreateTempDictionary(stocksAdditionalInfo.Values.Select(s => s["source"]).Distinct()) : stocks), rows, secondScreener);
                }//end if-else
                frm.ShowDialog();
            } catch (Exception ex)
            {
                ErrorMessage(ex);
            }
        }//end OfficeDocumentProgressForm
        private void tsmPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if((tabScreeners.SelectedTab == tabScreener2 && !pnlScreener2NoStocks.Visible) || (tabScreeners.SelectedTab == tabScreener && !pnlScreener1NoStocks.Visible))
                {
                    pdlogStocks.Document = pdocStocks;
                    pdlogStocks.AllowSelection = false;
                    if (pdlogStocks.ShowDialog() == DialogResult.OK)
                    {
                        if (!pdlogStocks.PrinterSettings.DefaultPageSettings.Landscape)
                        {
                            MessageBox.Show("Portrait layout printing not supported.");
                        }
                        else
                        {
                            pdocStocks.Print();
                        }//end 3x nested if-else
                    }//end 2x nested if
                } else
                {
                    MessageBox.Show("There are no stocks to print on this screener", "Unable to Print", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }//end if-else
            }
            catch (Exception ex)
            {
                pdfPath = "";
                ErrorMessage(ex);
            }//end try-catch
        }//end tsmPrint_Click

        private void tsmExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }//end tsmExit_Click

        /// <summary>
        /// Instantiates a new frmPreferences to view or edit the preferences for each Sector.  If saved, gets the new preferences
        /// Dictionary and sets the Preferences Dictionary attributes for future uses.
        /// </summary>
        /// <param name="sector"></param>
        private void LoadPreferencesForm(string sector)
        {
            try
            {
                frmPreferences frm = new frmPreferences(preferences.GetSectorMapCopy(), sector, preferences.DontShowAgainValue);
                if(frm.ShowDialog() == DialogResult.OK)
                {
                    preferences.SetSectorMap(frm.GetPreferences());
                    preferences.DontShowAgainValue = frm.GetDontShowAgain();
                }//end if
            } catch (Exception ex)
            {
                ErrorMessage(ex);
            }
        }//end LoadPreferencesForm

        private void PopulateListView()
        {
            try
            {
                if(screenerType == 1 || screenerType == 2)
                {
                    foreach (var sector in stocks.Keys)
                    {
                        var temp = from s in stocks[sector].Values
                                   where s.GetInScreener(0) == true && s.TotalScoreValue >= 16 
                                   select s;
                        Dictionary<string, Stock> tempDictionary = new Dictionary<string, Stock>();
                        foreach (var s in temp)
                        {
                            if (!tempDictionary.ContainsKey(s.SymbolValue))
                            {
                                tempDictionary.Add(s.SymbolValue, s);
                            }//end if
                        }//end foreach
                        AddListViewItem(SortSectorDictionary(tempDictionary), sector, lstvStocks);
                    }//end foreach
                }
                
                if(stocksAdditionalInfo != null)
                {
                    //Gets all the distinct source names so that they can be added to the listview
                    var temp = stocksAdditionalInfo.Values.Select(s => s["source"]).Where(s => s != "").Distinct();
                    foreach(var t in temp)
                    {
                        var group = new ListViewGroup(t.Trim(), t.Trim());
                        lstvStocks2.Groups.Add(group);
                        var tempDictionary = new Dictionary<string, Stock>();
                        //TODO FIX CODE SO IT ACTUALLY PULLS THE STOCKS THAT HAVE THE SPECIFIC SOURCE
                        foreach(var key in stocksAdditionalInfo.Keys)
                        {
                            if(!tempDictionary.ContainsKey(key) && stocksAdditionalInfo[key]["source"] == t)
                            {
                                var sec = stocksAdditionalInfo[key]["sector"].Trim();
                                if(sec != "" && stocks.ContainsKey(sec) && stocks[sec].ContainsKey(key))
                                {
                                    tempDictionary.Add(key, stocks[sec][key]);
                                }
                            }//end if
                        }//end foreach
                        /*var stocksInT = from s in stocksAdditionalInfo
                                        where s.Value["source"] == t
                                        select stocks[s.Value["sector"]][s.Key];*/
                        AddListViewItem(SortSectorDictionary(tempDictionary, true), t.Trim(), lstvStocks2, true);
                    }//end nested for
                }//end if
            } catch (Exception ex)
            {
                ErrorMessage(ex);
            }//end try-catch
        }//end PopulateListView

        private Dictionary<string, Dictionary<string, Stock>> CreateTempDictionary(IEnumerable<string> sectors)
        {
            if (sectors == null) { return null; }
            Dictionary<string, Dictionary<string, Stock>> res = new Dictionary<string, Dictionary<string, Stock>>();
            foreach (var t in sectors)
            {
                if(!res.ContainsKey(t))
                {
                    res.Add(t, new Dictionary<string, Stock>());
                }
                var query = from s in stocksAdditionalInfo.Keys
                            where stocksAdditionalInfo[s]["source"] == t && stocksAdditionalInfo[s]["sector"] != ""
                            select stocks[stocksAdditionalInfo[s]["sector"]][s];
                foreach(var q in query)
                {
                    if(!res[t].ContainsKey(q.SymbolValue) && stocks[stocksAdditionalInfo[q.SymbolValue]["sector"]].ContainsKey(q.SymbolValue))
                    {
                        res[t].Add(q.SymbolValue, q);
                    }//end nested if
                }//end nested foreach
            }//end foreach
            return res;
        }//end CreateTempDictionary

        /// <summary>
        /// Adds the sorted Sector kvp to the ListView
        /// </summary>
        /// <param name="sector">The sorted Sector kvp</param>
        private void AddListViewItem(IOrderedEnumerable<Stock> stocks, string sector, ListView view, bool isScreener2 = false)
        {
            try
            {
                int i = 0;
                foreach (var stock in stocks)
                {
                    ListViewItem row;
                    if (isScreener2)
                    {
                        row = new ListViewItem(new string[] { stock.SymbolValue, stock.IndustryValue,
                        stock.FundValue.ToString(), stock.GrowthValue.ToString(), stock.ValuationValue.ToString(),
                        (stock.EPSThisYValue != Double.MinValue ? stock.EPSThisYValue.ToString() : "NA"),
                        (stock.EPSNextYValue != Double.MinValue ? stock.EPSNextYValue.ToString() : "NA"),
                        (stock.RecomValue != Double.MinValue ? stock.RecomValue.ToString() : "NA"),
                        (stock.TargetPriceValue != Double.MinValue ? stock.TargetPriceValue.ToString() : "NA"),
                        (stock.GetEarningsDate() == new DateTime(0) ? "NA" : stock.GetEarningsDateString()), stock.ZacksStringValue,
                        stock.TotalScore2Value.ToString() });
                    } else
                    {
                        row = new ListViewItem(new string[] { stock.SymbolValue, stock.IndustryValue,
                        stock.FundValue.ToString(), stock.GrowthValue.ToString(), stock.ValuationValue.ToString(),
                        (stock.High52WValue != Double.MinValue ? stock.High52WValue.ToString() + "%" : "NA"),
                        (stock.RecomValue != Double.MinValue ? stock.RecomValue.ToString() : "NA"),
                        (stock.CurrentRatioValue != Double.MinValue ? stock.CurrentRatioValue.ToString() : "NA"),
                        (stock.GetEarningsDate() == new DateTime(0) ? "NA" : stock.GetEarningsDateString()), stock.ZacksStringValue,
                        stock.TotalScoreValue.ToString() });
                    }//end nested if-else
                    
                    if (i % 2 != 0)
                    {
                        row.BackColor = SystemColors.Control;
                    }
                    if (stock.TotalScoreValue >= 18)
                    {
                        row.UseItemStyleForSubItems = false;
                        if (i % 2 != 0)
                        {
                            row.SubItems[0].BackColor = SystemColors.Control;
                            row.SubItems[1].BackColor = SystemColors.Control;
                            row.SubItems[10].BackColor = SystemColors.Control;
                        }
                        var colors = stock.GetFormattingColors(isScreener2);
                        int j = 2;
                        foreach (var c in colors)
                        {
                            row.SubItems[j].BackColor = c;
                            j++;
                        }//end foreach
                    }//end if
                    view.Groups[sector].Items.Add(row);
                    view.Items.Add(row);
                    i++;
                }//end foreach
            } catch (Exception ex)
            {
                ErrorMessage(ex);
            }
        }//end AddListViewItem

        private void LoadFinvizWithStocks()
        {
            try
            {
                List<string> symbols = new List<string>();
                foreach (var key in stocks.Keys)
                {
                    foreach (var stock in stocks[key].Keys)
                    {
                        symbols.Add(stock);
                    }//end nested foreach
                }//end foreach
                var url = preferences.GetFinvizUrlAfterScraping(symbols.AsEnumerable());
                OpenBrowserToUrl(url);
            } catch (Exception ex)
            {
                ErrorMessage(ex);
            }
        }//end LoadFinvizWithStocks

        private void pdocStocks_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                var secondScreener = (tabScreeners.SelectedTab == tabScreener2 ? true : false);
                Font font = new Font("Arial", 11, FontStyle.Regular, GraphicsUnit.Pixel);
                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Center;
                format.LineAlignment = StringAlignment.Center;
                bool skip = false;
                int headerHeight = 65;
                int bodyCellHeight = 20;
                int[] cellWidths = { 43, 275, 79, 79, 79, 107, 80, 78, 86, 76, 81 };
                int fullRowWidth = 43 + 275 + 79 + 79 + 79 + 107 + 80 + 78 + 86 + 76 + 81;
                int pages = 0;
                int x = e.MarginBounds.Left;
                int y = e.MarginBounds.Top;
                int width = 0;

                string[] headerText = new string[] { "CM Fund\n7-10 = Green\n4-6 = Yellow\n0-3 = Red",
                    "CM Growth\n7-10 = Green\n4-6 = Yellow\n0-3 = Red",
                    "CM Valuation\n5-10 = Green\n3-4 = Yellow\n0-2 = Red",
                    (!secondScreener ? "52W High\n-90 to -10 = Green\n-29 to -10 = Yellow\n-9 to + = Red" : "EPS Next Y\nx >= 25% = G\n25% > x >= 0% = Y\nx < 0% = R"),
                    "Finviz Recom\n1-2 = Green\n2.1-3.0 = Yellow\n3.1-5 = Red",
                    (!secondScreener ? "Curr_Ratio\n>3.0 = Green\n1-3 = Yellow\n0-.9 = Red" : "Target Price\nx > Actual price = Green\nx < Actual price = Red"),
                    "Earnings Date\n" + (secondScreener ? "No scoring for\nthis screener" : "*See end of\ndocument"),
                    "Zacks Rank\n" + (secondScreener ? "" : "*") + "*See end of\ndocument",
                    "Total\n" + (secondScreener ? "" : "*") + "**See end of\ndocument" };
                
                for (int j = 0; j < 11; j++)
                {
                    if (j < 2)
                    {
                        width += cellWidths[j];
                    }

                    if (j >= 2)
                    {
                        if (e.PageBounds.Width > (x + cellWidths[j]))
                        {
                            var stringSize = e.Graphics.MeasureString(headerText[j - 2], font);
                            float w = stringSize.Width;
                            float height = stringSize.Height;
                            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(x, y, cellWidths[j], headerHeight));
                            e.Graphics.DrawString(headerText[j - 2], font, Brushes.Black, new RectangleF(x, y, cellWidths[j], headerHeight), format);
                            //e.Graphics.DrawString(headerText[j - 2], font, Brushes.Black, x + (cellWidths[j] / 2) - (w / 2), y + (height / 2));
                            x += cellWidths[j];
                        }
                    }
                    else if (j == 1)
                    {
                        e.Graphics.DrawRectangle(Pens.Black, new Rectangle(x, y, width, headerHeight));
                        x += width;
                    }
                }//end for
                y += headerHeight;
                var halfHeight = bodyCellHeight / 2;

                var sectors = frmScreener.SortSectorKeys(stocks.Keys);

                while(currentSector < sectors.Count())
                {
                    x = e.MarginBounds.Left;
                    int cell = 0;
                    float stringWidth = 0;
                    float stringHeight = 0;
                    format.Alignment = StringAlignment.Far;

                    if (y < e.MarginBounds.Bottom && y + bodyCellHeight < e.MarginBounds.Bottom)
                    {
                        string header = String.Format("{0} {1}", DateTime.Today.ToShortDateString(), sectors.ElementAt(currentSector));

                        e.Graphics.FillRectangle(Brushes.Silver, x, y, fullRowWidth, bodyCellHeight);
                        e.Graphics.DrawRectangle(Pens.Black, x, y, cellWidths[0] + cellWidths[1], bodyCellHeight);
                        e.Graphics.DrawRectangle(Pens.Black, x, y, fullRowWidth, bodyCellHeight);
                        e.Graphics.DrawString(header, font, Brushes.Black, new RectangleF(x, y, cellWidths[0] + cellWidths[1], bodyCellHeight), format);
                        y += bodyCellHeight;
                    }
                    else
                    {
                        e.HasMorePages = true;
                        pages++;
                        break;
                    }//end if-else

                    var sorted = SortSectorDictionary(stocks[sectors.ElementAt(currentSector)]);
                    while (currentStock < sorted.Count())
                    {
                        format.Alignment = StringAlignment.Center;
                        x = e.MarginBounds.Left;
                        cell = 0;

                        if (y < e.MarginBounds.Bottom && y + bodyCellHeight < e.MarginBounds.Bottom)
                        {
                            if (currentStock % 2 != 0)
                            {
                                e.Graphics.FillRectangle(Brushes.Gainsboro, e.MarginBounds.Left, y, fullRowWidth, bodyCellHeight);
                            }

                            var attributes = sorted.ElementAt(currentStock).GetAttributesEnumerable(secondScreener);
                            var colors = (18 <= sorted.ElementAt(currentStock).TotalScoreValue ? sorted.ElementAt(currentStock).GetFormattingColors(secondScreener) : null);

                            foreach (var a in attributes)
                            {
                                var val = (a.ToString() != Double.MinValue.ToString() ? a.ToString() : "NA");
                                stringWidth = getStringDimension('w', val, font, e);
                                stringHeight = getStringDimension('h', val, font, e);
                                
                                if(colors != null && (2 <= cell && cell <= 9))
                                {
                                    Brush attributeBG = (colors[cell - 2].Name == "Green" ? Brushes.Green : colors[cell - 2].Name == "Yellow" ? Brushes.Yellow : colors[cell - 2].Name == "Red" ? Brushes.Red : colors[cell - 2].Name == "Blue" ? Brushes.Blue : Brushes.Orange);
                                    e.Graphics.FillRectangle(attributeBG, (x + (cellWidths[cell] / 2)) - (stringWidth / 2), (y + halfHeight) - (stringHeight / 2), stringWidth, stringHeight);
                                }
                                e.Graphics.DrawRectangle(Pens.Black, x, y, cellWidths[cell], bodyCellHeight);

                                if(5 <= cell && cell <= 7)
                                {
                                    val = (val != Double.MinValue.ToString() ? val : "NA");
                                }
                                e.Graphics.DrawString(val, font, Brushes.Black, new RectangleF(x, y, cellWidths[cell], bodyCellHeight), format);

                                x += cellWidths[cell];
                                cell++;
                            }//end 2x nested foreach
                            y += bodyCellHeight;
                            currentStock++;
                        }
                        else
                        {
                            e.HasMorePages = true;
                            pages++;
                            skip = true;
                            break;
                        }//end if-else
                    }//end while

                    if(!skip)
                    {
                        currentStock = 0;
                        currentSector++;
                    }//end if
                }//end while

                int i = 0;
                x = e.MarginBounds.Left;
                string[] scoreExplanations = new string[] {
                    (!secondScreener ? "*Earnings Date: 1 <= x <= 70 days = Green, 71 days <= x < 4 months = Yellow, After 4mo = Red." : "*Zacks Rank: Green = +6, Blue = +4, Yellow = +2, Orange = -2, Red = -4."),
                    (!secondScreener ? "*Earnings Date Same Day: Before close - before 9:30am = Red, after 9:30am = Green; After close - before 4:00pm = Red, after = Green." : "**Total score is calculated using a weight for each color and multiplying the original score by the new weight."),
                    (!secondScreener ? "**Zacks Rank: Green = +6, Blue = +4, Yellow = +2, Orange = -2, Red = -4." : "**CM Fund = *5, CM Growth = *3, CM Valuation = *2, EPS Next Y = *5, Recom = *3, Target Price = *2, Zacks = *10"),
                    (!secondScreener ? "***Total score is calculated using a weight for each color." : "***Excluding Zacks Rank: Green = +4, Yellow = +2, Red = -2."),
                    "***Excluding Zacks Rank: Green = +4, Yellow = +2, Red = -2."
                };
                while(i < scoreExplanations.Length)
                {
                    if(y + (int)getStringDimension('h', scoreExplanations[i],  font, e) < e.MarginBounds.Bottom)
                    {
                        float height = getStringDimension('h', scoreExplanations[i], font, e);
                        e.Graphics.DrawString(scoreExplanations[i], font, Brushes.Black, x, y);
                        y += (int)height;
                        i++;
                    } else
                    {
                        e.HasMorePages = true;
                        pages++;
                        break;
                    }//end if-else
                }//end for
            }
            catch (Exception ex)
            {
                ErrorMessage(ex);
            }//end try-catch
        }//end pdocStocks_PrintPage

        private float getStringDimension(char dimension, string val, Font font, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                var size = e.Graphics.MeasureString(val, font);
                if (dimension == 'w')
                {
                    return size.Width;
                }
                else
                {
                    return size.Height;
                }
            }
            catch
            {
                return 0;
            }
        }//end getStringDimension

        private void tsmPrintPreview_Click(object sender, EventArgs e)
        {
            try
            {
                pprevStocks.ShowDialog();
                currentSector = 0;//reset the sector flag for the PrintDocument object so the print document can be generated again
            } catch (Exception ex)
            {
                ErrorMessage(ex);
            }
        }//end tsmPrintPreview_Click

        private void tsmAbout_Click(object sender, EventArgs e)
        {
            try
            {
                string message = String.Format("A stock screening application used for selecting stocks.\nThe application scrapes three websites; Finviz, ChartMill, and Zacks.\n" +
                    "Then evaluates the stocks to determine if they should be included in the table.\n\nProgrammer: Nicholas Bernardo\nVersion: {0}",
                    System.Reflection.Assembly.GetExecutingAssembly().GetName().Version);
                MessageBox.Show(message);
            }
            catch (Exception ex)
            {
                ErrorMessage(ex);
            }
        }//end tsmAbout_Click

        private void tsmAttribution_Click(object sender, EventArgs e)
        {
            try
            {
                new frmAttribution().ShowDialog();
            }
            catch (Exception ex)
            {
                ErrorMessage(ex);
            }
        }//end tsmAttribution_Click
    }//end class
}//end namespace

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
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
        Preferences preferences;
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

        private void frmScreener_Load(object sender, EventArgs e)
        {
            try
            {
                PopulateListView();
                LoadFinvizWithStocks();
            } catch
            {

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
                SaveDocument document;
                SaveFileDialog save = new SaveFileDialog();
                save.AddExtension = true;
                save.Filter = "Excel files (*xlsx)|*.xlsx|Word files (*.docx)|*docx|Xml files (*.xml)|*.xml|Html files (*.html)|*.html";

                if (save.ShowDialog() == DialogResult.OK)
                {
                    string path = save.FileName;
                    string extension = path.Remove(0, path.LastIndexOf('.') + 1);

                    document = new SaveDocument(path.Remove(path.LastIndexOf('\\')), path.Remove(0, path.LastIndexOf('\\') + 1));

                    if (extension == "xlsx")
                    {
                        document.SaveExcelDocument(stocks);
                    }
                    else if (extension == "docx")
                    {
                        int rows = stocks.Keys.Count() + 1;
                        foreach(var kvp in stocks.Values)
                        {
                            rows += kvp.Values.Count();
                        }
                        document.SaveWordDocument(stocks, rows);
                    }
                    else if (extension == "xml")
                    {
                        document.SaveXmlDocument(stocks);
                    }
                    else
                    {
                        document.SaveHtmlDocument(stocks);
                    }
                }//end if
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }//end tsmSave_Click

        private void tsmPrint_Click(object sender, EventArgs e)
        {
            //TODO
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
                frmPreferences frm = new frmPreferences(preferences.GetSectorMapCopy(), sector);
                if(frm.ShowDialog() == DialogResult.OK)
                {
                    preferences.SetSectorMap(frm.GetPreferences());
                }//end if
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }//end LoadPreferencesForm

        private void PopulateListView()
        {
            foreach(var sector in stocks.Keys)
            {
                AddListViewItem(SortSectorDictionary(stocks[sector]), sector);
            }//end foreach
        }//end PopulateListView

        /// <summary>
        /// Adds the sorted Sector kvp to the ListView
        /// </summary>
        /// <param name="sector">The sorted Sector kvp</param>
        private void AddListViewItem(IOrderedEnumerable<Stock> stocks, string sector)
        {
            int i = 0;
            foreach (var stock in stocks)
            {
                var row = new ListViewItem(new string[] { stock.SymbolValue, stock.IndustryValue, stock.FundValue.ToString(), stock.GrowthValue.ToString(), stock.ValuationValue.ToString(), stock.High52WValue.ToString() + "%", stock.RecomValue.ToString(), stock.CurrentRatioValue.ToString(), (stock.GetEarningsDate() == new DateTime(0) ? "NA" : stock.GetEarningsDateString()), stock.TotalScoreValue.ToString() });
                if (i % 2 != 0)
                {
                    row.UseItemStyleForSubItems = false;
                    row.BackColor = SystemColors.Control;
                }
                lstvStocks.Groups[sector].Items.Add(row);
                lstvStocks.Items.Add(row);
            }//end foreach
        }//end AddListViewItem

        private void LoadFinvizWithStocks()
        {
            List<string> symbols = new List<string>();
            foreach(var key in stocks.Keys)
            {
                foreach(var stock in stocks[key].Keys)
                {
                    symbols.Add(stock);
                }//end nested foreach
            }//end foreach
            var url = preferences.GetFinvizURLAfterScraping(symbols.AsEnumerable());
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
        }
        public static IOrderedEnumerable<Stock> SortSectorDictionary(Dictionary<string, Stock> sector)
        {
            return sector.Values.OrderByDescending(s => s.TotalScoreValue).ThenByDescending(s => s.FundValue)
                .ThenByDescending(s => s.GrowthValue).ThenByDescending(s => s.ValuationValue).ThenBy(s => s.High52WValue)
                .ThenBy(s => s.RecomValue).ThenByDescending(s => s.CurrentRatioValue).ThenByDescending(s => s.GetEarningsDate());
        }//end SortStockDictionary

        public static IOrderedEnumerable<string> SortSectorKeys(IEnumerable<string> sectors)
        {
            return sectors.OrderBy(s => s);
        }//end SortSectorKeys
    }//end class
}//end namespace

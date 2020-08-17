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
    public partial class frmScreener : Form
    {
        private Dictionary<string, Dictionary<string, Stock>> stocks;
        public frmScreener()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.screenerIcon;
        }//end default constructor

        public frmScreener(Dictionary<string, Dictionary<string, Stock>> stocks)
        {
            InitializeComponent();
            this.Icon = Properties.Resources.screenerIcon;
            this.stocks = stocks;
        }//end one argument constructor

        private void frmScreener_Load(object sender, EventArgs e)
        {
            PopulateListView();
        }

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
            foreach (var stock in stocks)
            {
                var row = new ListViewItem(new string[] { stock.SymbolValue, stock.IndustryValue, stock.FundValue.ToString(), stock.GrowthValue.ToString(), stock.ValuationValue.ToString(), stock.High52WValue.ToString() + "%", stock.RecomValue.ToString(), stock.CurrentRatioValue.ToString(), (stock.GetEarningsDate() == new DateTime(0) ? "NA" : stock.GetEarningsDateString()), stock.TotalScoreValue.ToString() });
                lstvStocks.Groups[sector].Items.Add(row);
                lstvStocks.Items.Add(row);
            }//end foreach
        }//end AddListViewItem

        private IOrderedEnumerable<Stock> SortSectorDictionary(Dictionary<string, Stock> sector)
        {
            return sector.Values.OrderByDescending(s => s.TotalScoreValue).ThenByDescending(s => s.FundValue)
                .ThenByDescending(s => s.GrowthValue).ThenByDescending(s => s.ValuationValue).ThenBy(s => s.High52WValue)
                .ThenBy(s => s.RecomValue).ThenByDescending(s => s.CurrentRatioValue).ThenByDescending(s => s.GetEarningsDate());
        }//end SortStockDictionary
    }//end class
}//end namespace

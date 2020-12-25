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
    public partial class frmSaveStocks : Form
    {
        Dictionary<string, Dictionary<string, Stock>> stocks = new Dictionary<string, Dictionary<string, Stock>>();
        public frmSaveStocks()
        {
            InitializeComponent();
        }//end default constructor

        public frmSaveStocks(Dictionary<string, Dictionary<string, Stock>> stocks)
        {
            InitializeComponent();
            this.stocks = stocks;
        }//end one argument constructor

        private void btnSave_Click(object sender, EventArgs e)
        {

        }//end btnSave_Click

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }//end btnCancel_Click

        private void frmSaveStocks_Load(object sender, EventArgs e)
        {

        }//end frmSaveStocks_Load

        private void populateListView()
        {

        }//end populateListView
    }//end class
}//end namespace

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
    public partial class frmPreferences : Form
    {
        Dictionary<string, Dictionary<string, string>> preferences;
        bool[] saved = new bool[11]; //Tells the program whether all the sectors are saved or not
        string currentSector = "";
        bool loadingSector;
        public frmPreferences()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.screenerIcon;
            cmbSector.SelectedIndex = 0;
        }//end default constructor

        public frmPreferences(Dictionary<string, Dictionary<string, string>> pref)
        {
            InitializeComponent();
            this.Icon = Properties.Resources.screenerIcon;
            preferences = pref;
            cmbSector.SelectedIndex = 0;
        }//end one argument constructor

        public frmPreferences(Dictionary<string, Dictionary<string, string>> pref, string sector)
        {
            InitializeComponent();
            this.Icon = Properties.Resources.screenerIcon;
            preferences = pref;
            cmbSector.SelectedItem = sector;
        }//end two argument constructor

        public Dictionary<string, Dictionary<string, string>> GetPreferences() { return preferences; }

        /// <summary>
        /// Sets the initial selection of all the ComboBoxes on the form to Any
        /// </summary>
        private void SetInitialSelection(string sector)
        {
            //cmbPE.SelectedItem = (preferences[sector]["pe"] != "" ? preferences[sector]["pe"] : "Any");
            cmbPrice.SelectedItem = (preferences[sector]["price"] != "" ? preferences[sector]["price"] : "Any");
            cmbAverageVolume.SelectedItem = (preferences[sector]["averageVolume"] != "" ? preferences[sector]["averageVolume"] : "Any");
            //cmbRSI.SelectedItem = (preferences[sector]["rsi"] != "" ? preferences[sector]["rsi"] : "Any");
            cmbCurrentRatio.SelectedItem = (preferences[sector]["currentRatio"] != "" ? preferences[sector]["currentRatio"] : "Any");
            cmbHigh52W.SelectedItem = (preferences[sector]["high"] != "" ? preferences[sector]["high"] : "Any");
            cmbSMA20.SelectedItem = (preferences[sector]["sma20"] != "" ? preferences[sector]["sma20"] : "Any");
            cmbSMA50.SelectedItem = (preferences[sector]["sma50"] != "" ? preferences[sector]["sma50"] : "Any");
            SetPEOrRSIInitialSelection(cmbPE, chkCustomPE, pnlCustomPE, preferences[sector]["pe"]);
            SetPEOrRSIInitialSelection(cmbRSI, chkCustomRSI, pnlCustomRSI, preferences[sector]["rsi"]);
            loadingSector = false;
        }//end SetInitialSelection

        private void SetPEOrRSIInitialSelection(ComboBox cmb, CheckBox chk, Panel panel, string pref)
        {
            if (pref.Contains("/"))
            {
                var temp = pref.Split('/');
                panel.Controls.OfType<NumericUpDown>().Select(x => x).Where(x => x.Name.Contains("Min")).First().Value = int.Parse(temp[0]);
                panel.Controls.OfType<NumericUpDown>().Select(x => x).Where(x => x.Name.Contains("Max")).First().Value = int.Parse(temp[1]);
                chk.Checked = true;
            }
            else
            {
                cmb.SelectedItem = (pref != "" ? pref : "Any");
                chk.Checked = false;
            }

        }//end SetPEOrRSIInitialSelection
        private void cmbSector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSector.SelectedIndex < 0)
            {
                errPreferences.SetError(cmbSector, "You must select a valid Sector");
                return;
            }
            loadingSector = true;
            currentSector = cmbSector.SelectedItem.ToString();
            SetInitialSelection(currentSector);
        }//end cmbSector_SelectedIndexChanged

        private void cmbPE_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxIndexChanged(cmbPE, "P/E", "pe");
        }//end cmbPE_SelectedIndexChanged

        private void cmbPrice_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxIndexChanged(cmbPrice, "Price", "price");
        }//end cmbPrice_SelectedIndexChanged

        private void cmbCurrentRatio_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxIndexChanged(cmbCurrentRatio, "Current Ratio", "currentRatio");
        }//end cmbCurrentRatio_SelectedIndexChanged

        private void cmbAverageVolume_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxIndexChanged(cmbAverageVolume, "averageVolume", "averageVolume");
        }//end cmbAverageVolume_SelectedIndexChanged

        private void cmbRSI_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxIndexChanged(cmbRSI, "rsi", "rsi");
        }//end cmbRSI_SelectedIndexChanged

        private void btnSaved_Click(object sender, EventArgs e)
        {
            if (cmbSector.SelectedItem.ToString() == "Any")
            {

            }
            else
            {
                if (CheckErrors())
                {

                }
                else
                {
                    this.Close();
                }//end nested if-else
            }//end if-else
        }//end btnSaved_Click

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }//end btnCancel_Click

        private bool CheckErrors()
        {
            return (preferences.Select(x => x).Where(x => x.Value.Values.Contains(""))).Count() > 0;
        }

        /// <summary>
        /// Sets the filter value in the Dictionary local to the form
        /// </summary>
        /// <param name="box">The ComboBox being used</param>
        /// <param name="name">The Dictionary key of the filter</param>
        private void SetFilterValue(ComboBox box, string name)
        {
            if (currentSector == "Any")
            {
                for (int i = 0; i < preferences.Count(); i++)
                {
                    preferences[preferences.ElementAt(i).Key][name] = box.SelectedItem.ToString();
                }//end for
            }
            else
            {
                preferences[currentSector][name] = box.SelectedItem.ToString();
            }//end if-else
        }//end SetFilterValue

        private void chkCustomPE_CheckedChanged(object sender, EventArgs e)
        {
            CheckChangePEOrRSI(cmbPE, chkCustomPE, pnlCustomPE, preferences[currentSector]["pe"]);
        }//end chkCustomPE_CheckedChanged

        private void chkCustomRSI_CheckedChanged(object sender, EventArgs e)
        {
            CheckChangePEOrRSI(cmbRSI, chkCustomRSI, pnlCustomRSI, preferences[currentSector]["rsi"]);
        }//end chkCustomRSI_CheckedChanged

        private void CheckChangePEOrRSI(ComboBox cmb, CheckBox chk, Panel pnl, string pref)
        {
            if (chk.Checked)
            {
                pnl.Visible = true;
            }
            else
            {
                pnl.Visible = false;
                if (pref.Contains("/")) { cmb.SelectedIndex = 0; }
            }//end if-else
        }//end CheckChangePEOrRSI

        private void nudPEMin_ValueChanged(object sender, EventArgs e)
        {
            if (!loadingSector)
            {
                SetFilterValue(nudPEMin, nudPEMax, "pe");
            }
        }//end nudPEMin_ValueChanged

        private void nudPEMax_ValueChanged(object sender, EventArgs e)
        {
            if(!loadingSector)
            {
                SetFilterValue(nudPEMin, nudPEMax, "pe");
            }
        }//end nudPEMax_ValueChanged

        private void nudRSIMin_ValueChanged(object sender, EventArgs e)
        {
            if (!loadingSector)
            {
                SetFilterValue(nudRSIMin, nudRSIMax, "rsi");
            }
        }//end nudRSIMin_ValueChanged

        private void nudRSIMax_ValueChanged(object sender, EventArgs e)
        {
            if (!loadingSector)
            {
                SetFilterValue(nudRSIMin, nudRSIMax, "rsi");
            }
        }//end nudRSIMax_ValueChanged

        /// <summary>
        /// The essential function of each ComboBox.  Checks to make sure a valid index is selected and sets the value in
        /// the Preferences Dictionary if the Sector has already been loaded
        /// </summary>
        /// <param name="cmb">The ComboBox being changed</param>
        /// <param name="name">The name of the filter</param>
        /// <param name="filterIdentifier">The filter string used in the Dictionary.  Camel case with no special characters; ex. pe, currentRatio, sma20</param>
        private void ComboBoxIndexChanged(ComboBox cmb, string name, string filterIdentifier)
        {
            if (cmb.SelectedIndex < 0) { errPreferences.SetError(cmb, String.Format("Select a value for {0} filter from the dropdown menu!", name)); }
            else if (!loadingSector)
            {
                SetFilterValue(cmb, filterIdentifier);
            }//end if-else
        }

        /// <summary>
        /// Sets the filter value in the Dictionary local to the form
        /// </summary>
        /// <param name="min">Minimum value of the filter</param>
        /// <param name="max">Maximum value of the filter</param>
        /// <param name="filter">The name of the filter</param>
        private void SetFilterValue(NumericUpDown min, NumericUpDown max, string filter)
        {
            if (currentSector == "Any")
            {
                for (int i = 0; i < preferences.Count(); i++)
                {
                    preferences[preferences.ElementAt(i).Key][filter] = String.Format("{0}/{1}", min.Value, max.Value);
                }//end for
            }
            else
            {
                preferences[currentSector][filter] = String.Format("{0}/{1}", min.Value, max.Value);
            }//end if-else
        }//end SetFilterValue
    }//end frmPreferences
}//end Screener
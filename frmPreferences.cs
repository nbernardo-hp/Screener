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
        bool[] saved; //Tells the program whether all the sectors are saved or not
        string currentSector = "";
        bool loadingSector;
        public frmPreferences()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.screenerIcon;
            cmbSector.SelectedIndex = 0;
            saved = new bool[11];
        }//end default constructor

        public frmPreferences(Dictionary<string, Dictionary<string, string>> pref)
        {
            InitializeComponent();
            this.Icon = Properties.Resources.screenerIcon;
            preferences = pref;
            cmbSector.SelectedIndex = 0;
            saved = new bool[11];
        }//end one argument constructor

        public frmPreferences(Dictionary<string, Dictionary<string, string>> pref, string sector)
        {
            InitializeComponent();
            this.Icon = Properties.Resources.screenerIcon;
            preferences = pref;
            cmbSector.SelectedItem = sector;
            saved = new bool[11] { true, true, true, true, true, true, true, true, true, true, true };
        }//end two argument constructor

        public Dictionary<string, Dictionary<string, string>> GetPreferences() { return preferences; }

        private void SetSectorFiltersSet(string sector)
        {
            var sectorKeys = preferences.Keys.ToList();
            if (sector == "Any" && chkReplaceAll.Checked)
            {
                for(int i = 1; i < sectorKeys.Count; i++)
                {
                    SetSaved(sectorKeys[i], i - 1);
                }//end for
            } else if(sector != "Any")
            {
                SetSaved(sector, sectorKeys.IndexOf(sector) - 1);
            }//end if-else
        }//end SetSectorFiltersSet

        private void SetSaved(string sector, int index)
        {
            var values = preferences[sector].Values.Select(x => x).Where(x => x.Equals("") || x.Equals("..."));
            var containsBlanks = values.Count() > 0;
            if (containsBlanks)
            {
                saved[index] = false;
            }
            else
            {
                saved[index] = true;
            }
        }//end SetSaved

        /// <summary>
        /// Sets the initial selection of all the ComboBoxes on the form to Any
        /// </summary>
        private void SetInitialSelection(string sector)
        {
            //cmbPE.SelectedItem = (preferences[sector]["pe"] != "" ? preferences[sector]["pe"] : "Any");
            cmbPrice.SelectedItem = (preferences[sector]["price"] != "" ? preferences[sector]["price"] : "...");
            cmbAverageVolume.SelectedItem = (preferences[sector]["averageVolume"] != "" ? preferences[sector]["averageVolume"] : "...");
            //cmbRSI.SelectedItem = (preferences[sector]["rsi"] != "" ? preferences[sector]["rsi"] : "Any");
            cmbCurrentRatio.SelectedItem = (preferences[sector]["currentRatio"] != "" ? preferences[sector]["currentRatio"] : "...");
            cmbHigh52W.SelectedItem = (preferences[sector]["high"] != "" ? preferences[sector]["high"] : "...");
            cmbSMA20.SelectedItem = (preferences[sector]["sma20"] != "" ? preferences[sector]["sma20"] : "...");
            cmbSMA50.SelectedItem = (preferences[sector]["sma50"] != "" ? preferences[sector]["sma50"] : "...");
            SetPEOrRSIInitialSelection(cmbPE, chkCustomPE, pnlCustomPE, preferences[sector]["pe"]);
            SetPEOrRSIInitialSelection(cmbRSI, chkCustomRSI, pnlCustomRSI, preferences[sector]["rsi"]);
            loadingSector = false;
            errPreferences.Clear();
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
                cmb.SelectedItem = (pref != "" ? pref : "...");
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
            if(currentSector == "Any")
            {
                chkReplaceAll.Enabled = true;
            } else
            {
                chkReplaceAll.Enabled = false;
            }
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
            try
            {
                if (cmbSector.SelectedIndex == 0 && chkReplaceAll.Checked)
                {
                    var keys = preferences.Keys;
                    for(int i = 1 ; i < keys.Count; i++)
                    {
                        preferences[keys.ElementAt(i)] = preferences["Any"];
                    }//end for
                }
                else
                {
                    if(chkCustomPE.Checked)
                    {
                        SetFilterValue(nudPEMin, nudPEMax, "pe");
                    } else
                    {
                        ComboBoxIndexChanged(cmbPE, "P/E", "pe");
                    }//end PE if-else

                    if(chkCustomRSI.Checked)
                    {
                        SetFilterValue(nudRSIMin, nudRSIMax, "rsi");
                    } else
                    {
                        ComboBoxIndexChanged(cmbRSI, "RSI", "rsi");
                    }//end RSI if-else

                    ComboBoxIndexChanged(cmbPrice, "Price", "price");
                    ComboBoxIndexChanged(cmbPE, "Current Ratio", "currentRatio");
                    ComboBoxIndexChanged(cmbPE, "Average Volume", "averageVolume");
                    ComboBoxIndexChanged(cmbPE, "52 Week High", "high");
                    ComboBoxIndexChanged(cmbPE, "SMA 20", "sma20");
                    ComboBoxIndexChanged(cmbPE, "SMA 50", "sma50");

                    if(CheckAllSaved())
                    {
                        this.Close();
                    }
                }//end if-else
            } catch
            {

            }
        }//end btnSaved_Click

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }//end btnCancel_Click

        /// <summary>
        /// Determines if all the Sectors have been saved of not
        /// </summary>
        /// <returns>Returns false if any Sectors have not been saved</returns>
        private bool CheckAllSaved()
        {
            return Array.TrueForAll(saved, s => s == true);
        }

        private bool CheckErrors()
        {
            if(cmbSector.SelectedIndex == 0)
            {
                return (preferences.Select(x => x).Where(x => x.Value.Values.Contains(""))).Count() > 0;
            } else
            {
                var x = preferences[cmbSector.SelectedItem.ToString()].Values;
                
                return (x.Select(y => y).Where(y => y.Equals(""))).Count() > 0;
            }
        }

        /// <summary>
        /// Sets the filter value in the Dictionary local to the form
        /// </summary>
        /// <param name="box">The ComboBox being used</param>
        /// <param name="name">The Dictionary key of the filter</param>
        private void SetFilterValue(ComboBox box, string name)
        {
            if (currentSector == "Any" && chkReplaceAll.Checked)
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

        private void cmbHigh52W_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxIndexChanged(cmbHigh52W, "52 Week High", "high");
        }//end cmbHigh52W_SelectedIndexChanged

        private void cmbSMA20_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxIndexChanged(cmbSMA20, "SMA 20", "sma20");
        }//end cmbSMA20_SelectedIndexChanged

        private void cmbSMA50_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxIndexChanged(cmbSMA50, "SMA 50", "sma50");
        }//end cmbSMA50_SelectedIndexChanged

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
            if (cmb.SelectedIndex < 1) { errPreferences.SetError(cmb, String.Format("Select a value for {0} filter from the dropdown menu!", name)); }
            else if (!loadingSector)
            {
                errPreferences.SetError(cmb, "");
                SetFilterValue(cmb, filterIdentifier);
                SetSectorFiltersSet(currentSector);
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
            if(min.Value > max.Value) { this.errPreferences.SetError((filter == "pe" ? pnlCustomPE : pnlCustomRSI), String.Format("The maximum value for {0} must be greater than the minimum value!", filter.ToUpper())); }
            else
            {
                errPreferences.SetError((filter == "pe" ? pnlCustomPE : pnlCustomRSI), "");
                if (currentSector == "Any" && chkReplaceAll.Checked)
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
                SetSectorFiltersSet(currentSector);
            }
        }//end SetFilterValue
    }//end frmPreferences
}//end Screener
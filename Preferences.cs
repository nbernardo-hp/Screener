using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Screener
{
    public class Preferences
    {
        private bool loaded = false;
        private string browser;
        private string finvizStartUrl = "https://www.finviz.com/screener.ashx?v=151&f=an_recom_buybetter,geo_usa";
        private string finvizEndUrl = "&ft=4&c=1,3,4,7,35,57,59,62,63,68";
        private string preferencesPath = AppDomain.CurrentDomain.BaseDirectory + @"\preferences";
        private string preferencesFile = "preferences.xml";

        /// <summary>
        /// The Dictionary that contains the url strings for specific filters on Finviz
        /// </summary>
        private Dictionary<string, Dictionary<string, string>> finvizMap = new Dictionary<string, Dictionary<string, string>>()
        {
            ["pe"] = new Dictionary<string, string>()
            {
                ["Low (<15)"] = "fa_pe_low",
                ["Profitable (<0)"] = "fa_pe_profitable",
                ["High (>50)"] = "fa_pe_high",
                ["Under 5"] = "fa_pe_u5",
                ["Under 10"] = "fa_pe_u10",
                ["Under 15"] = "fa_pe_u15",
                ["Under 20"] = "fa_pe_u20",
                ["Under 25"] = "fa_pe_u25",
                ["Under 30"] = "fa_pe_u30",
                ["Under 35"] = "fa_pe_u35",
                ["Under 40"] = "fa_pe_u40",
                ["Under 45"] = "fa_pe_u45",
                ["Under 50"] = "fa_pe_u50",
                ["Over 5"] = "fa_pe_o5",
                ["Over 10"] = "fa_pe_o10",
                ["Over 15"] = "fa_pe_o15",
                ["Over 20"] = "fa_pe_o20",
                ["Over 25"] = "fa_pe_o25",
                ["Over 30"] = "fa_pe_o30",
                ["Over 35"] = "fa_pe_o35",
                ["Over 40"] = "fa_pe_o40",
                ["Over 45"] = "fa_pe_o45",
                ["Over 50"] = "fa_pe_o50"
            },
            ["price"] = new Dictionary<string, string>()
            {
                ["Under $1"] = "sh_price_u1",
                ["Under $2"] = "sh_price_u2",
                ["Under $3"] = "sh_price_u3",
                ["Under $4"] = "sh_price_u4",
                ["Under $5"] = "sh_price_u5",
                ["Under $7"] = "sh_price_u7",
                ["Under $10"] = "sh_price_u10",
                ["Under $15"] = "sh_price_u15",
                ["Under $20"] = "sh_price_u20",
                ["Under $30"] = "sh_price_u30",
                ["Under $40"] = "sh_price_u40",
                ["Under $50"] = "sh_price_u50",
                ["Over $1"] = "sh_price_o1",
                ["Over $2"] = "sh_price_o2",
                ["Over $3"] = "sh_price_o3",
                ["Over $4"] = "sh_price_o4",
                ["Over $5"] = "sh_price_o5",
                ["Over $7"] = "sh_price_o7",
                ["Over $10"] = "sh_price_o10",
                ["Over $15"] = "sh_price_o15",
                ["Over $20"] = "sh_price_o20",
                ["Over $30"] = "sh_price_o30",
                ["Over $40"] = "sh_price_o40",
                ["Over $50"] = "sh_price_o50",
                ["Over $60"] = "sh_price_o60",
                ["Over $70"] = "sh_price_o70",
                ["Over $80"] = "sh_price_o80",
                ["Over $90"] = "sh_price_o90",
                ["Over $100"] = "sh_price_o100",
                ["$1 to $5"] = "sh_price_1to5",
                ["$1 to $10"] = "sh_price_1to10",
                ["$1 to $20"] = "sh_price_1to20",
                ["$5 to $10"] = "sh_price_5to10",
                ["$5 to $20"] = "sh_price_5to20",
                ["$5 to $50"] = "sh_price_5to50",
                ["$10 to $20"] = "sh_price_10to20",
                ["$10 to $50"] = "sh_price_10to50",
                ["$20 to $50"] = "sh_price_20to50",
                ["$50 to $100"] = "sh_price_50to100"
            },
            ["averageVolume"] = new Dictionary<string, string>()
            {
                ["Under 50K"] = "sh_avgvol_u50",
                ["Under 100K"] = "sh_avgvol_u100",
                ["Under 500K"] = "sh_avgvol_u500",
                ["Under 750K"] = "sh_avgvol_u750",
                ["Under 1M"] = "sh_avgvol_u1000",
                ["Over 50K"] = "sh_avgvol_o50",
                ["Over 100K"] = "sh_avgvol_o100",
                ["Over 200K"] = "sh_avgvol_o200",
                ["Over 300K"] = "sh_avgvol_o300",
                ["Over 400K"] = "sh_avgvol_o400",
                ["Over 500K"] = "sh_avgvol_o500",
                ["Over 750K"] = "sh_avgvol_o750",
                ["Over 1M"] = "sh_avgvol_o1000",
                ["Over 2M"] = "sh_avgvol_o2000",
                ["100K to 500K"] = "sh_avgvol_100to500",
                ["100K to 1M"] = "sh_avgvol_100to1000",
                ["500K to 1M"] = "sh_avgvol_500to1000",
                ["500K to 10M"] = "sh_avgvol_500to10000"
            },
            ["rsi"] = new Dictionary<string, string>()
            {
                ["Overbought (90)"] = "ta_rsi_ob90",
                ["Overbought (80)"] = "ta_rsi_ob80",
                ["Overbought (70)"] = "ta_rsi_ob70",
                ["Overbought (60)"] = "ta_rsi_ob60",
                ["Oversold (40)"] = "ta_rsi_os40",
                ["Oversold (30)"] = "ta_rsi_os30",
                ["Oversold (20)"] = "ta_rsi_os20",
                ["Oversold (10)"] = "ta_rsi_os10",
                ["Not Overbought (<60)"] = "ta_rsi_nob60",
                ["Not Overbought (<50)"] = "ta_rsi_nob50",
                ["Not Oversold (>50)"] = "ta_rsi_nos50",
                ["Not Oversold (>40)"] = "ta_rsi_nos40"
            },
            ["currentRatio"] = new Dictionary<string, string>()
            {
                ["High (>3)"] = "fa_curratio_high",
                ["Low (<1)"] = "fa_curratio_low",
                ["Under 1"] = "fa_curratio_u1",
                ["Under 0.5"] = "fa_curratio_u0.5",
                ["Over 0.5"] = "fa_curratio_o0.5",
                ["Over 1"] = "fa_curratio_o1",
                ["Over 1.5"] = "fa_curratio_o1.5",
                ["Over 2"] = "fa_curratio_o2",
                ["Over 3"] = "fa_curratio_o3",
                ["Over 4"] = "fa_curratio_o4",
                ["Over 5"] = "fa_curratio_o5",
                ["Over 10"] = "fa_curratio_o10"
            },
            ["sector"] = new Dictionary<string, string>()
            {
                ["Basic Materials"] = "sec_basicmaterials",
                ["Communication Services"] = "sec_communicationservices",
                ["Consumer Cyclical"] = "sec_consumercyclical",
                ["Consumer Defensive"] = "sec_consumerdefensive",
                ["Energy"] = "sec_energy",
                ["Financial"] = "sec_financial",
                ["Healthcare"] = "sec_healthcare",
                ["Industrials"] = "sec_industrials",
                ["Real Estate"] = "sec_realestate",
                ["Technology"] = "sec_technology",
                ["Utilities"] = "sec_utilities"
            }
        };

        /// <summary>
        /// The Dictionary that contains the saved preferences for each Sector
        /// </summary>
        private Dictionary<string, Dictionary<string, string>> sectorMap = new Dictionary<string, Dictionary<string, string>>()
        {
            ["Any"] = new Dictionary<string, string>()
            {
                ["pe"] = "Any",
                ["price"] = "Any",
                ["averageVolume"] = "Any",
                ["rsi"] = "Any",
                ["currentRatio"] = "Any",
            },
            ["Basic Materials"] = new Dictionary<string, string>()
            {
                ["pe"] = "",
                ["price"] = "",
                ["averageVolume"] = "",
                ["rsi"] = "",
                ["currentRatio"] = "",
            },
            ["Communication Services"] = new Dictionary<string, string>()
            {
                ["pe"] = "",
                ["price"] = "",
                ["averageVolume"] = "",
                ["rsi"] = "",
                ["currentRatio"] = "",
            },
            ["Consumer Cyclical"] = new Dictionary<string, string>()
            {
                ["pe"] = "",
                ["price"] = "",
                ["averageVolume"] = "",
                ["rsi"] = "",
                ["currentRatio"] = "",
            },
            ["Consumer Defensive"] = new Dictionary<string, string>()
            {
                ["pe"] = "",
                ["price"] = "",
                ["averageVolume"] = "",
                ["rsi"] = "",
                ["currentRatio"] = "",
            },
            ["Energy"] = new Dictionary<string, string>()
            {
                ["pe"] = "",
                ["price"] = "",
                ["averageVolume"] = "",
                ["rsi"] = "",
                ["currentRatio"] = "",
            },
            ["Financial"] = new Dictionary<string, string>()
            {
                ["pe"] = "",
                ["price"] = "",
                ["averageVolume"] = "",
                ["rsi"] = "",
                ["currentRatio"] = "",
            },
            ["Healthcare"] = new Dictionary<string, string>()
            {
                ["pe"] = "",
                ["price"] = "",
                ["averageVolume"] = "",
                ["rsi"] = "",
                ["currentRatio"] = "",
            },
            ["Industrials"] = new Dictionary<string, string>()
            {
                ["pe"] = "",
                ["price"] = "",
                ["averageVolume"] = "",
                ["rsi"] = "",
                ["currentRatio"] = "",
            },
            ["Real Estate"] = new Dictionary<string, string>()
            {
                ["pe"] = "",
                ["price"] = "",
                ["averageVolume"] = "",
                ["rsi"] = "",
                ["currentRatio"] = "",
            },
            ["Technology"] = new Dictionary<string, string>()
            {
                ["pe"] = "",
                ["price"] = "",
                ["averageVolume"] = "",
                ["rsi"] = "",
                ["currentRatio"] = "",
            },
            ["Utilities"] = new Dictionary<string, string>()
            {
                ["pe"] = "",
                ["price"] = "",
                ["averageVolume"] = "",
                ["rsi"] = "",
                ["currentRatio"] = "",
            }
        };

        public string BrowserValue
        {
            get { return browser; }
            set { browser = value; }
        }

        /// <summary>
        /// Calls GetFinvizUrl to create and return the specific URL for each Sector.  Returns the list containing every URL
        /// </summary>
        /// <returns>The list of URLs to be used in webscraping</returns>
        public Stack<string> GetFinvizUrls()
        {
            Stack<string> urls = new Stack<string>();

            foreach(var key in sectorMap.Keys.Where(s => s != "Any"))
            {
                urls.Push(GetFinvizUrl(key));
            }

            return urls;
        }

        /// <summary>
        /// Creates the individual URL for each sector by accessing the Dictionary with the saved filter strings.
        /// </summary>
        /// <param name="sector">The Sector to scrape</param>
        /// <returns>The URL for the specific Sector</returns>
        public string GetFinvizUrl(string sector)
        {
            StringBuilder url = new StringBuilder().Append(finvizStartUrl);

            /*Loops through the KeyValuePairs in the sectorMap to append each url segement.  The key is used to access finvizMap
             *to get the appropriate attribute and the value selects the proper filter string*/
            foreach(var kvp in sectorMap[sector])
            {
                url.Append("," + finvizMap[kvp.Key][kvp.Value]);
            }

            return url.Append(","+finvizMap["sector"][sector]+ finvizEndUrl).ToString();
        }

        /// <summary>
        /// Returns a bool to tell the program if preferences were loaded or no
        /// </summary>
        /// <returns>Indicates whether preferences were loaded</returns>
        public bool GetLoaded() { return loaded; }

        /// <summary>
        /// Returns the Dictionary containing the preferences for each Sector to the calling function
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, Dictionary<string, string>> GetSectorMap() { return sectorMap; }
        public Dictionary<string, Dictionary<string, string>> GetSectorMapCopy()
        {
            Dictionary<string, Dictionary<string, string>> res = new Dictionary<string, Dictionary<string, string>>();
            foreach(var sector in sectorMap)
            {
                res.Add(sector.Key, sector.Value);
            }
            return res;
        }

        public void SetSectorMap(Dictionary<string, Dictionary<string, string>> map)
        {
            sectorMap = map;
            SavePreferences();
        }

        /// <summary>
        /// Loads the preferences from the specified Directory.  If loaded sets a flag to let the program know if it can begin
        /// scraping or not.
        /// </summary>
        public void LoadPreferences()
        {
            if(Directory.Exists(preferencesPath) && File.Exists(Path.Combine(preferencesPath, preferencesFile)))
            {
                XmlData xml = new XmlData();
                for(int i = 0; i < sectorMap.Count; i++)
                {
                    string key = sectorMap.ElementAt(i).Key;
                    sectorMap[key] = xml.LoadPreferences((key.Contains(" ") ? String.Join("_", key.Split(' ')) : key), preferencesPath, preferencesFile);
                }//end for

                browser = xml.LoadBrowserPreference(preferencesPath, preferencesFile);
                loaded = true;
            }//end if
        }//end LoadPreferences

        /// <summary>
        /// Saves the preferences for each Sector to an Xml file
        /// </summary>
        public void SavePreferences()
        {
            XmlData xml = new XmlData();
            xml.SavePreferences(sectorMap, browser, preferencesPath, preferencesFile);
        }//end SavePreferences
    }//Preferences
}//Screener

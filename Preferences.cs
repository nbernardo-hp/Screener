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
        private bool dontShowAgain = false;
        private bool loaded = false;
        private string browser;
        private string finvizStartUrl = "https://www.finviz.com/screener.ashx?v=151&f=an_recom_buybetter,geo_usa";
        private string finvizEndUrl = "&ft=4&c=1,3,4,7,17,18,35,57,59,62,65,68,69";
        private string finvizURLAfterScraping = "https://www.finviz.com/screener.ashx?v=111&t=";
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
            },
            ["high"] = new Dictionary<string, string>()
            {
                ["New High"] = "ta_highlow52w_nh",
                ["New Low"] = "ta_highlow52w_nl",
                ["5% or more below High"] = "ta_highlow52w_b5h",
                ["10% or more below High"] = "ta_highlow52w_b10h",
                ["15% or more below High"] = "ta_highlow52w_b15h",
                ["20% or more below High"] = "ta_highlow52w_b20h",
                ["30% or more below High"] = "ta_highlow52w_b30h",
                ["40% or more below High"] = "ta_highlow52w_b40h",
                ["50% or more below High"] = "ta_highlow52w_b50h",
                ["60% or more below High"] = "ta_highlow52w_b60h",
                ["70% or more below High"] = "ta_highlow52w_b70h",
                ["80% or more below High"] = "ta_highlow52w_b80h",
                ["90% or more below High"] = "ta_highlow52w_b90h",
                ["0-3% below High"] = "ta_highlow52w_b0to3h",
                ["0-5% below High"] = "ta_highlow52w_b0to5h",
                ["0-10% below High"] = "ta_highlow52w_b0to10h",
                ["5% or more above Low"] = "ta_highlow52w_a5h",
                ["10% or more above Low"] = "ta_highlow52w_a10h",
                ["15% or more above Low"] = "ta_highlow52w_a15h",
                ["20% or more above Low"] = "ta_highlow52w_a20h",
                ["30% or more above Low"] = "ta_highlow52w_a30h",
                ["40% or more above Low"] = "ta_highlow52w_a40h",
                ["50% or more above Low"] = "ta_highlow52w_a50h",
                ["60% or more above Low"] = "ta_highlow52w_a60h",
                ["70% or more above Low"] = "ta_highlow52w_a70h",
                ["80% or more above Low"] = "ta_highlow52w_a80h",
                ["90% or more above Low"] = "ta_highlow52w_a90h",
                ["100% or more above Low"] = "ta_highlow52w_a100h",
                ["120% or more above Low"] = "ta_highlow52w_a120h",
                ["150% or more above Low"] = "ta_highlow52w_a150h",
                ["200% or more above Low"] = "ta_highlow52w_a200h",
                ["300% or more above Low"] = "ta_highlow52w_a300h",
                ["500% or more above Low"] = "ta_highlow52w_a500h",
                ["0-3% above Low"] = "ta_highlow52w_a0to3h",
                ["0-5% above Low"] = "ta_highlow52w_a0to5h",
                ["0-10% above Low"] = "ta_highlow52w_a0to10h"
            },
            ["sma20"] = new Dictionary<string, string>()
            {
                ["Price below SMA20"] = "ta_sma20_pb",
                ["Price 10% below SMA20"] = "ta_sma20_pb10",
                ["Price 20% below SMA20"] = "ta_sma20_pb20",
                ["Price 30% below SMA20"] = "ta_sma20_pb30",
                ["Price 40% below SMA20"] = "ta_sma20_pb40",
                ["Price 50% below SMA20"] = "ta_sma20_pb50",
                ["Price above SMA20"] = "ta_sma20_pa",
                ["Price 10% above SMA20"] = "ta_sma20_pa10",
                ["Price 20% above SMA20"] = "ta_sma20_pa20",
                ["Price 30% above SMA20"] = "ta_sma20_pa30",
                ["Price 40% above SMA20"] = "ta_sma20_pa40",
                ["Price 50% above SMA20"] = "ta_sma20_pa50",
                ["Price crossed SMA20"] = "ta_sma20_pc",
                ["Price crossed SMA20 above"] = "ta_sma20_pca",
                ["Price crossed SMA20 below"] = "ta_sma20_pcb",
                ["SMA20 crossed SMA50"] = "ta_sma20_cross50",
                ["SMA20 crossed SMA50 above"] = "ta_sma20_cross50a",
                ["SMA20 crossed SMA50 below"] = "ta_sma20_cross50b",
                ["SMA20 crossed SMA200"] = "ta_sma20_cross200",
                ["SMA20 crossed SMA200 above"] = "ta_sma20_cross200a",
                ["SMA20 crossed SMA200 below"] = "ta_sma20_cross200b",
                ["SMA20 above SMA50"] = "ta_sma20_sa50",
                ["SMA20 below SMA50"] = "ta_sma20_sb50",
                ["SMA20 above SMA200"] = "ta_sma20_sa200",
                ["SMA20 below SMA200"] = "ta_sma20_sab200",
            },
            ["sma50"] = new Dictionary<string, string>()
            {
                ["Price below SMA50"] = "ta_sma50_pb",
                ["Price 10% below SMA50"] = "ta_sma50_pb10",
                ["Price 20% below SMA50"] = "ta_sma50_pb20",
                ["Price 30% below SMA50"] = "ta_sma50_pb30",
                ["Price 40% below SMA50"] = "ta_sma50_pb40",
                ["Price 50% below SMA50"] = "ta_sma50_pb50",
                ["Price above SMA50"] = "ta_sma50_pa",
                ["Price 10% above SMA50"] = "ta_sma50_pa10",
                ["Price 20% above SMA50"] = "ta_sma50_pa20",
                ["Price 30% above SMA50"] = "ta_sma50_pa30",
                ["Price 40% above SMA50"] = "ta_sma50_pa40",
                ["Price 50% above SMA50"] = "ta_sma50_pa50",
                ["Price crossed SMA50"] = "ta_sma50_pc",
                ["Price crossed SMA50 above"] = "ta_sma50_pca",
                ["Price crossed SMA50 below"] = "ta_sma50_pcb",
                ["SMA50 crossed SMA20"] = "ta_sma50_cross20",
                ["SMA50 crossed SMA20 above"] = "ta_sma50_cross20a",
                ["SMA50 crossed SMA20 below"] = "ta_sma50_cross20b",
                ["SMA50 crossed SMA200"] = "ta_sma50_cross200",
                ["SMA50 crossed SMA200 above"] = "ta_sma50_cross200a",
                ["SMA50 crossed SMA200 below"] = "ta_sma50_cross200b",
                ["SMA50 above SMA20"] = "ta_sma50_sa20",
                ["SMA50 below SMA20"] = "ta_sma50_sb20",
                ["SMA50 above SMA200"] = "ta_sma50_sa200",
                ["SMA50 below SMA200"] = "ta_sma50_sab200",
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
                ["high"] = "Any",
                ["sma20"] = "Any",
                ["sma50"] = "Any"
            },
            ["Basic Materials"] = new Dictionary<string, string>()
            {
                ["pe"] = "",
                ["price"] = "",
                ["averageVolume"] = "",
                ["rsi"] = "",
                ["currentRatio"] = "",
                ["high"] = "",
                ["sma20"] = "",
                ["sma50"] = ""
            },
            ["Communication Services"] = new Dictionary<string, string>()
            {
                ["pe"] = "",
                ["price"] = "",
                ["averageVolume"] = "",
                ["rsi"] = "",
                ["currentRatio"] = "",
                ["high"] = "",
                ["sma20"] = "",
                ["sma50"] = ""
            },
            ["Consumer Cyclical"] = new Dictionary<string, string>()
            {
                ["pe"] = "",
                ["price"] = "",
                ["averageVolume"] = "",
                ["rsi"] = "",
                ["currentRatio"] = "",
                ["high"] = "",
                ["sma20"] = "",
                ["sma50"] = ""
            },
            ["Consumer Defensive"] = new Dictionary<string, string>()
            {
                ["pe"] = "",
                ["price"] = "",
                ["averageVolume"] = "",
                ["rsi"] = "",
                ["currentRatio"] = "",
                ["high"] = "",
                ["sma20"] = "",
                ["sma50"] = ""
            },
            ["Energy"] = new Dictionary<string, string>()
            {
                ["pe"] = "",
                ["price"] = "",
                ["averageVolume"] = "",
                ["rsi"] = "",
                ["currentRatio"] = "",
                ["high"] = "",
                ["sma20"] = "",
                ["sma50"] = ""
            },
            ["Financial"] = new Dictionary<string, string>()
            {
                ["pe"] = "",
                ["price"] = "",
                ["averageVolume"] = "",
                ["rsi"] = "",
                ["currentRatio"] = "",
                ["high"] = "",
                ["sma20"] = "",
                ["sma50"] = ""
            },
            ["Healthcare"] = new Dictionary<string, string>()
            {
                ["pe"] = "",
                ["price"] = "",
                ["averageVolume"] = "",
                ["rsi"] = "",
                ["currentRatio"] = "",
                ["high"] = "",
                ["sma20"] = "",
                ["sma50"] = ""
            },
            ["Industrials"] = new Dictionary<string, string>()
            {
                ["pe"] = "",
                ["price"] = "",
                ["averageVolume"] = "",
                ["rsi"] = "",
                ["currentRatio"] = "",
                ["high"] = "",
                ["sma20"] = "",
                ["sma50"] = ""
            },
            ["Real Estate"] = new Dictionary<string, string>()
            {
                ["pe"] = "",
                ["price"] = "",
                ["averageVolume"] = "",
                ["rsi"] = "",
                ["currentRatio"] = "",
                ["high"] = "",
                ["sma20"] = "",
                ["sma50"] = ""
            },
            ["Technology"] = new Dictionary<string, string>()
            {
                ["pe"] = "",
                ["price"] = "",
                ["averageVolume"] = "",
                ["rsi"] = "",
                ["currentRatio"] = "",
                ["high"] = "",
                ["sma20"] = "",
                ["sma50"] = ""
            },
            ["Utilities"] = new Dictionary<string, string>()
            {
                ["pe"] = "",
                ["price"] = "",
                ["averageVolume"] = "",
                ["rsi"] = "",
                ["currentRatio"] = "",
                ["high"] = "",
                ["sma20"] = "",
                ["sma50"] = ""
            }
        };

        public string BrowserValue
        {
            get { return browser; }
            set { browser = value; }
        }

        public bool DontShowAgainValue
        {
            get { return dontShowAgain; }
            set { dontShowAgain = value; }
        }

        /// <summary>
        /// Calls GetFinvizUrl to create and return the specific URL for each Sector.  Returns the list containing every URL
        /// </summary>
        /// <returns>The list of URLs to be used in webscraping</returns>
        public Stack<string> GetFinvizUrls()
        {
            Stack<string> urls = new Stack<string>();

            foreach (var key in sectorMap.Keys.Where(s => s != "Any").Reverse())
            {
                urls.Push(CreateFinvizUrl(key));
            }

            return urls;
        }

        /// <summary>
        /// Returns the url to be used in Finviz so that the charts can be viewed on the website.
        /// </summary>
        /// <param name="symbols"></param>
        /// <returns></returns>
        public string GetFinvizUrlAfterScraping(IEnumerable<string> symbols)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(finvizURLAfterScraping);
            int symbolsCount = symbols.Count();
            foreach (string s in symbols)
            {
                sb.Append(s);
                if (symbolsCount > 1) { sb.Append(","); }
                symbolsCount--;
            }//end foreach

            return sb.ToString();
        }

        /// <summary>
        /// Creates the individual URL for each sector by accessing the Dictionary with the saved filter strings.
        /// </summary>
        /// <param name="sector">The Sector to scrape</param>
        /// <returns>The URL for the specific Sector</returns>
        public string CreateFinvizUrl(string sector, int page = 0)
        {
            StringBuilder url = new StringBuilder().Append(finvizStartUrl);

            /*Loops through the KeyValuePairs in the sectorMap to append each url segement.  The key is used to access finvizMap
             *to get the appropriate attribute and the value selects the proper filter string*/
            foreach (var kvp in sectorMap[sector])
            {
                if (kvp.Value != "Any" && kvp.Value != "" && kvp.Value !="...")
                {
                    if(!kvp.Value.Contains("/"))
                    {
                        url.Append("," + finvizMap[kvp.Key][kvp.Value]);
                    } else
                    {
                        var temp = kvp.Value.Split('/');
                        if(kvp.Key == "pe")
                        {
                            url.Append(String.Format(",fa_pe_{0}to{1}", temp[0], temp[1]));
                        } else
                        {
                            url.Append(String.Format(",ta_rsi_{0}to{1}", temp[0], temp[1]));
                        }//end 2x nested if-else
                    }//end nested if-else
                }//end if
            }//end foreach
            return url.Append("," + finvizMap["sector"][sector] + finvizEndUrl).ToString();
        }//end CreateFinvizUrl

        public string CreateFinvizUrlForScreener2(List<string> symbols)
        {
            StringBuilder url = new StringBuilder().Append(finvizStartUrl.Remove(finvizStartUrl.LastIndexOf('&'))+"&t=");
            int symbolsLen = symbols.Count;
            for(int i = 0; i < symbolsLen; i++)
            {
                url.Append(symbols[i]);
                if(i < symbolsLen - 1) { url.Append(","); }
            }//end for
            return url.Append(finvizEndUrl.Remove(0, finvizEndUrl.LastIndexOf('&'))).ToString();
        }//end CreateFinvizUrlFroScreener2

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
            foreach (var sector in sectorMap)
            {
                res.Add(sector.Key, new Dictionary<string, string>());
                foreach (var s in sector.Value)
                {
                    res[sector.Key].Add(s.Key, s.Value);
                }//end nested foreach
            }//end foreach
            return res;
        }//end GetSectorMapCopy

        public string[] GetPEArray() { return (from f in sectorMap.Values select f["pe"]).ToArray(); }
        public string[] GetRSIArray() { return (from f in sectorMap.Values select f["rsi"]).ToArray(); }
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
            if (Directory.Exists(preferencesPath) && File.Exists(Path.Combine(preferencesPath, preferencesFile)))
            {
                XmlData xml = new XmlData();
                for (int i = 0; i < sectorMap.Count; i++)
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

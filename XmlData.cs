using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Screener
{
    public class XmlData
    {
        private XmlWriter writer;
        
        public string LoadBrowserPreference(string path, string file)
        {
            if (!File.Exists(Path.Combine(path, file))) { return null; }

            var doc = XDocument.Load(Path.Combine(path, file));
            return doc.Descendants("PREFERENCES").Elements("BROWSER").First().Value;
        }
        /// <summary>
        /// Loads the preferences for the specific Sector from the specified file and path
        /// </summary>
        /// <param name="sector">The specific Sector to get the preferences fomr</param>
        /// <param name="path">The file path</param>
        /// <param name="file">The file name</param>
        /// <returns></returns>
        public Dictionary<string, string> LoadPreferences(string sector, string path, string file)
        {
            if(!File.Exists(Path.Combine(path, file))) { return null; }
            Dictionary<string, string> res = new Dictionary<string, string>();

            var doc = XDocument.Load(Path.Combine(path, file));

            var elements = doc.Element("PREFERENCES").Element(sector).Elements();

            foreach(var e in elements)
            {
                res.Add(e.Name.ToString(), e.Value);
            }

            return res;
        }//end LoadPreferences

        /// <summary>
        /// Saves the Preferences for each Sector to an XML file at the specified file
        /// </summary>
        /// <param name="map">The Preferences Dictionary</param>
        /// <param name="path">The directory the file should be saved in</param>
        /// <param name="file">The file name</param>
        public void SavePreferences(Dictionary<string, Dictionary<string, string>> map, string browser, string path, string file)
        {
            CreateDirectory(path);

            using (writer = XmlWriter.Create(Path.Combine(path, file)))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("PREFERENCES");
                foreach(var key in map.Keys)
                {
                    string sector = (key.Contains(" ") ? String.Join("_", key.Split(' ')) : key);
                    writer.WriteStartElement(sector);
                       
                    foreach(var kvp in map[key])
                    {
                        writer.WriteElementString(kvp.Key, kvp.Value);
                    }//end nested foreach

                    writer.WriteEndElement();
                }//end foreach
                writer.WriteElementString("BROWSER", browser);
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }//end using
        }//end SavePreferences

        /// <summary>
        /// Saves the stocks at the user specified path from the SaveFileDialog
        /// </summary>
        /// <param name="stocks">Dictionary containing the Stock objects</param>
        /// <param name="filePath">The folder path to save the file</param>
        /// <param name="fileName">The file name containing the extension to use</param>
        public void SaveStocks(Dictionary<string, Dictionary<string, Stock>> map, string filePath, string fileName)
        {
            string combinedPath = Path.Combine(filePath, fileName);
            if (File.Exists(combinedPath)) { File.Delete(combinedPath); }
            using (writer = XmlWriter.Create(combinedPath))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("STOCKS");
                foreach(var sector in frmScreener.SortSectorKeys(map.Keys))
                {
                    writer.WriteStartElement("SECTOR");
                    writer.WriteAttributeString("NAME", sector);
                    IOrderedEnumerable<Stock> stocks = frmScreener.SortSectorDictionary(map[sector]);
                    foreach(var s in stocks)
                    {
                        writer.WriteStartElement("STOCK");
                        writer.WriteElementString("SYMBOL", s.SymbolValue);
                        writer.WriteElementString("INDUSTRY", s.IndustryValue);
                        writer.WriteElementString("FUND", s.FundValue.ToString());
                        writer.WriteElementString("GROWTH", s.GrowthValue.ToString());
                        writer.WriteElementString("VALUATION", s.ValuationValue.ToString());
                        writer.WriteElementString("HIGH_52W", s.High52WValue.ToString());
                        writer.WriteElementString("RECOM", s.RecomValue.ToString());
                        writer.WriteElementString("CURRENT_RATIO", s.CurrentRatioValue.ToString());
                        writer.WriteElementString("EARNINGS_DATE", s.GetEarningsDateString());
                        writer.WriteElementString("TOTAL_SCORE", s.TotalScoreValue.ToString());
                        writer.WriteEndElement();
                    }//end nest foreach

                    writer.WriteEndElement();
                }//end foreach
                
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }//end using
        }//end SaveStocks

        /// <summary>
        /// Creates the specified directory if it doesn't exist
        /// </summary>
        /// <param name="path">The path of the directory</param>
        private void CreateDirectory(string path)
        {
            if(!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }//end if
        }//end CreateDirectory
    }//end XmlData
}//end Screener

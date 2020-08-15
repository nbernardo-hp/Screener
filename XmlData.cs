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

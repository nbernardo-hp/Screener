﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Microsoft.Office.Interop.Word;

using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;
using System.Drawing;

namespace Screener
{
    public class SaveDocument
    {
        public delegate void ProgressUpdate(int change, string update, int max = 0);
        public event ProgressUpdate OnProgressUpdate;
        string filePath;
        string fileName;

        public SaveDocument()
        {
            filePath = AppDomain.CurrentDomain.BaseDirectory + @"\backup\";
            fileName = "untitled";
        }//Default constructor

        public SaveDocument(string path, string name)
        {
            filePath = path;
            fileName = name;
        }//two argument constructor

        public void SaveExcelDocument(Dictionary<string, Dictionary<string, Stock>> map, bool secondScreener)
        {
            ChangeProgress(0, "Initializing...", (map.Count + map.Values.Count));
            Excel.Application app = new Excel.Application();

            if(app == null)
            {
                throw new Exception("Excel is not properly installed!");
            }

            ChangeProgress(1, "Creating Workbook...");
            Excel.Workbook workbook = app.Workbooks.Add();

            ChangeProgress(1, "Creating Worksheet...");
            Excel.Worksheet worksheet = worksheet = (Excel.Worksheet)workbook.Worksheets[1];

            Excel.Style style = workbook.Styles.Add("style");
            style.Font.Name = "Arial";
            style.Font.Size = 10;

            //Sets the column width of each column and the header text for each column
            ChangeProgress(1, "Writing header rows...");
            var headerText = GetHeaderText(secondScreener);
            Excel.Range formatRange = GetRange(worksheet, 1, 1, 1, 10);
            formatRange.EntireRow.RowHeight = 51.75;
            SetColumnWidth(ref worksheet, 1, 1, 1, 1, 6.14);
            SetColumnWidth(ref worksheet, 1, 2, 1, 2, 36.71);
            MergeCells(ref worksheet, 1, 1, 1, 2);
            worksheet.Cells[1, 3] = headerText[0];
            SetColumnWidth(ref worksheet, 1, 3, 1, 3, 11.29);
            worksheet.Cells[1, 4] = headerText[1];
            SetColumnWidth(ref worksheet, 1, 4, 1, 4, 11.29);
            worksheet.Cells[1, 5] = headerText[2];
            SetColumnWidth(ref worksheet, 1, 5, 1, 5, 12.14);
            worksheet.Cells[1, 6] = headerText[3];
            SetColumnWidth(ref worksheet, 1, 6, 1, 6, 16.57);
            worksheet.Cells[1, 7] = headerText[4];
            SetColumnWidth(ref worksheet, 1, 7, 1, 7, 14.14);
            worksheet.Cells[1, 8] = headerText[5];
            SetColumnWidth(ref worksheet, 1, 8, 1, 8, 11.14);
            worksheet.Cells[1, 9] = headerText[6];
            SetColumnWidth(ref worksheet, 1, 9, 1, 9, 12.71);
            worksheet.Cells[1, 10] = headerText[7];
            SetColumnWidth(ref worksheet, 1, 10, 1, 10, 11.71);
            worksheet.Cells[1, 11] = headerText[8];
            SetColumnWidth(ref worksheet, 1, 11, 1, 11, 12.86);
            if(secondScreener)
            {
                worksheet.Cells[1, 12] = headerText[9];
                SetColumnWidth(ref worksheet, 1, 12, 1, 12, 12.86);
                worksheet.Cells[1, 13] = headerText[9];
                SetColumnWidth(ref worksheet, 1, 12, 1, 12, 12.86);
            }

            //formatRange = GetRange(worksheet, 2, 7, 2, 8);
            //formatRange.EntireColumn.NumberFormat = "#.#";
            formatRange = GetRange(worksheet, 1, 2, 1, 11);
            formatRange.EntireColumn.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            int i = 2;//indicates the current row to begin on.  Excel starts indexing at 1
            foreach (var sector in frmScreener.SortSectorKeys(map.Keys))
            {
                if(!secondScreener)
                {
                    ChangeProgress(1, String.Format("Writing and formatting {0} header", sector));
                    /*Sets the background color and text alignment of the Sector header row.  Merges the first two columns
                     *together and the last 8 together.  Sets the header text for the Sector and increments the current row*/
                    formatRange = GetRange(worksheet, i, 1, i, 11);
                    formatRange.EntireRow.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Silver);
                    formatRange.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    MergeCells(ref worksheet, i, 1, i, 2);
                    MergeCells(ref worksheet, i, 3, i, 11);
                    worksheet.Cells[i, 1] = String.Format("{0} {1}", DateTime.Today.ToShortDateString(), sector);
                    i++;
                }//end if

                /*Gets the ordered Stock objects for the Sector and loops through the objects.  Gets the attributes for the
                 *current object to loop through.  Loops through each attribute and sets the cell text to the attribute.  If
                 *the current row is odd, changes the background color for easier reading.  Increases the current row*/
                IOrderedEnumerable<Stock> stocks = frmScreener.SortSectorDictionary(map[sector], secondScreener);
                int k = 0;
                foreach (var s in stocks)
                {
                    ChangeProgress(1, String.Format("Writing {0} information", s.SymbolValue));
                    if (k % 2 != 0)
                    {
                        formatRange = GetRange(worksheet, i, 1, i, 11);
                        formatRange.EntireRow.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Gainsboro);
                    }
                    var colors = (s.TotalScoreValue >= 18 ? s.GetFormattingColors(secondScreener) : null);
                    var attributes = s.GetAttributesEnumerable(secondScreener);
                    for (int j = 1; j <= attributes.Count(); j++)
                    {
                        if(colors != null && 3 <= j && j <= (secondScreener ? 11 : 10))
                        {
                            formatRange = GetRange(worksheet, i, j, i, j);
                            formatRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(colors[j - 3]);
                        }
                        var val = attributes.ElementAt(j - 1).ToString();
                        if(val == Double.MinValue.ToString())
                        {
                            val = "NA";
                        }
                        worksheet.Cells[i, j] = val;
                    }//end for
                    if(secondScreener)
                    {
                        worksheet.Cells[i, 13] = sector;
                    }
                    k++;
                    i++;
                }//end nested foreach
            }//end foreach

            ChangeProgress(1, "Formatting borders...");
            //Add a border around every cell on in the table
            formatRange = worksheet.UsedRange;
            formatRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            formatRange.Borders.Weight = 2d;

            ChangeProgress(1, "Adding Earnings Date, Zacks score explaination...");
            //Merge rows at the botom of the document and add the scoring explanation
            for(int j = 1; j < (!secondScreener ? 6 : 5); j++)
            {
                MergeCells(ref worksheet, i, 1, i, 11);
                worksheet.Cells[i, 1] = GetScoreExplanation(j, secondScreener);
                i++;
            }

            ChangeProgress(1, "Finializing...");
            //Save the document and close the workbook and application
            File.Delete(Path.Combine(filePath, fileName));
            workbook.SaveAs(Path.Combine(filePath, fileName));
            workbook.Close();
            app.Quit();
        }//end

        public void SaveHtmlDocument(Dictionary<string, Dictionary<string, Stock>> map, bool secondScreener)
        {
            string file = Path.Combine(filePath, fileName);
            if(Directory.Exists(filePath) && File.Exists(file)) { File.Delete(file); }

            using(FileStream fs = new FileStream(file, FileMode.Create))
            {
                using(StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine("<html><head><style>\n" +
                        "table, th, tr, td { border-collapse: collapse; text-align: center; }\n" +
                        "table { width: 100%; }\n" +
                        ".sectorHeader { background-color: silver; }\n" +
                        "th, td { border: 1px solid black; }\n" +
                        "</style></head>\n" +
                        "<body>\n");
                    sw.WriteLine("<table>");
                    sw.WriteLine("<tr>");
                    sw.WriteLine("<th colspan=\"2\"></th>");
                    sw.WriteLine("<th>CM Fund<br>7-10 = +4<br>4-6 = +2<br>0-3 = -2</th>");
                    sw.WriteLine("<th>CM Growth<br>7-10 = +4<br>4-6 = +2<br>0-3 = -2</th>");
                    sw.WriteLine("<th>CM Valuation<br>5-10 = +4<br>3-4 = +2<br>0-2 = -2</th>");
                    if(secondScreener)
                    {
                        sw.WriteLine("<th>EPS This Y<br>x >= 25% = +4<br>25% > x >= 0% = +2<br>x < 0% = -2</th>");
                    }
                    sw.WriteLine((secondScreener ? "<th>EPS Next Y<br>x >= 25% = +4<br>25% > x >= 0% = +2<br>x < 0% = -2</th>" : "<th>52 Week High<br>-90 to -30 = +4<br>-29 to -10 = +2<br>-9 to + = -2</th>"));
                    sw.WriteLine("<th>Finviz Recom<br>1-2 = +4<br>2.1-3.0 = +2<br>3.1-5 = -2</th>");
                    sw.WriteLine((secondScreener ? "<th>Target Price<br>x > Actual price = +4<br>x < Actual price = -2</th>" : "<th>Current Ratio<br>> 3.0 = +4<br>1-3 = +2<br>0-.9 = -2</th>"));
                    sw.WriteLine("<th>Earnings Date<br>" + (secondScreener ? "*No score for this screener" : "*See scoring below </ th >"));
                    sw.WriteLine("<th>Zacks Rank<br>" + (secondScreener ? "" : "*") + "*See scoring below</th>");
                    sw.WriteLine("<th>Total Score<br>" + (secondScreener ? "" : "*") + "**See scoring below</th>");
                    sw.WriteLine("</tr>");

                    foreach(var sector in frmScreener.SortSectorKeys(map.Keys))
                    {
                        sw.Write(String.Format("<tr style=\"text-align:right\" class=\"sectorHeader\"><th colspan=\"2\">{0} {1}</th><th colspan=\"9\"/></tr>", DateTime.Today.ToShortDateString(), sector));

                        int i = 0;
                        IOrderedEnumerable<Stock> stocks = frmScreener.SortSectorDictionary(map[sector], secondScreener);
                        foreach(var s in stocks)
                        {
                            if((secondScreener && s.GetInScreener(1) == true) || (!secondScreener && s.TotalScoreValue >= 16))
                            {
                                sw.WriteLine(String.Format("<tr{0}>", (i % 2 != 0 ? " style=\"background-color:gainsboro\"" : "")));

                                var attributes = s.GetAttributesEnumerable(secondScreener);
                                var colors = (s.TotalScoreValue >= 18 ? s.GetFormattingColors(secondScreener) : null);
                                for (int j = 0; j < attributes.Count(); j++)
                                {
                                    string val = attributes.ElementAt(j).ToString();
                                    if (5 <= j && j <= (secondScreener ? 8 : 7) && val == Double.MinValue.ToString()) { val = "NA"; }
                                    sw.WriteLine(String.Format("<td{0}>{1}</td>",
                                        (colors != null && 2 <= j && j <= 9 ?
                                            String.Format(" style=\"background-color:{0}\"", colors[j - 2].Name.ToLower()) :
                                            ""),
                                        val));
                                }//end for

                                sw.WriteLine("</tr>");
                                i++;
                            }
                        }//end nested foreach
                    }//end foreach

                    sw.WriteLine("</table>");
                    sw.WriteLine(String.Format("<p>{0}</p><p>{1}</p><p>{2}</p><p>{3}</p>", GetScoreExplanation(1, secondScreener), GetScoreExplanation(2, secondScreener), GetScoreExplanation(3, secondScreener), GetScoreExplanation(4, secondScreener)));
                    if(!secondScreener)
                    {
                        sw.WriteLine(String.Format("<p>{0}</p>", GetScoreExplanation(5, secondScreener)));
                    }
                    sw.WriteLine("</body>");
                    sw.WriteLine("</html>");
                }//end nested using
            }//end using
        }//end saveHtmlDocument

        /// <summary>
        /// Saves a .docx file of the table to the Directory returned from the SaveFileDialog
        /// </summary>
        /// <param name="stocks">The Stock objects to be used</param>
        public void SaveWordDocument(Dictionary<string, Dictionary<string, Stock>> map, int numRows, bool secondScreener)
        {
            /*starts a new instance of Word and checks to verify that the instance is created.  Sets the visibility and animation to false.
             *Creates a new Word document, adjusts the orientation, and creates a new paragraph*/
            ChangeProgress(0, "Initializing...", (map.Count + map.Values.Count));
            Word.Application app = new Word.Application();
            if(app == null)
            {
                throw new Exception("Word is not properly installed!");
            }

            app.ShowAnimation = false;
            app.Visible = false;

            ChangeProgress(1, "Creating Word document...");
            Word.Document document = app.Documents.Add();

            document.PageSetup.Orientation = WdOrientation.wdOrientLandscape;
            Word.Paragraph paragraph = document.Content.Paragraphs.Add();

            //Adds a new Word table to the paragraph created and enables the borders
            Table table = document.Tables.Add(paragraph.Range, numRows, (secondScreener ? 12 : 11));
            table.Borders.Enable = 1;

            ChangeProgress(1, "Writing header rows...");
            /*Loops through the first row and sets the text to the string returned from GetHeaderText.  Aligns the
             *paragraph text and merges the first 2 cells of the table*/
            var headerText = GetHeaderText(secondScreener);
            for (int i = 3; i < table.Columns.Count + 1; i++)
            {
                table.Cell(1, i).Range.Text = headerText[i-3];
            }//end for
            table.Rows[1].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            MergeCells(ref table, 1, 1, 1, 2);

            int row = 2;

            /*Loops through each Sector that is in the Stock object Dictionary.  Creates the Sector header for each Sector
             *in the table.  Merges the last rows and then the first 2, sets the background color, aligment, and text.*/
             foreach(var sector in frmScreener.SortSectorKeys(map.Keys))
            {
                ChangeProgress(1, String.Format("Writing and formatting {0} header", sector));
                MergeCells(ref table, row, 3, row, 11);
                MergeCells(ref table, row, 1, row, 2);
                table.Rows[row].Range.Shading.BackgroundPatternColor = WdColor.wdColorGray15;
                table.Rows[row].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                table.Cell(row, 1).Range.Text = String.Format("{0} {1}", DateTime.Today.ToShortDateString(), sector);
                row++;

                IOrderedEnumerable<Stock> stocks = frmScreener.SortSectorDictionary(map[sector], secondScreener);

                /*Iterates through each Stock object in the current Sector.  Gets the attributes of the current Stock object and loops
                 *through each attribute.  Sets the cell text to the current attribute string. Aligns the row after inserting all the
                 *object information.  Increment the current row after adding a new Stock*/
                int j = 0;
                foreach (var s in stocks)
                {
                    ChangeProgress(1, String.Format("Writing {0} information", s.SymbolValue));
                    if (j%2 != 0)
                    {
                        table.Rows[row].Range.Shading.BackgroundPatternColor = WdColor.wdColorGray05;
                    }
                    var attributes = s.GetAttributesEnumerable(secondScreener);
                    var colors = (s.TotalScoreValue >= 18 ? s.GetFormattingColors(secondScreener) : null);
                    for(int i = 0; i < attributes.Count(); i++)
                    {
                        string val = attributes.ElementAt(i).ToString();
                        if(5 <= i && i <= (secondScreener ? 8 : 7) && val == Double.MinValue.ToString()) { val = "NA"; }
                        table.Cell(row, i+1).Range.Text = val;
                        if (colors != null && 2 <= i && i <= 9)
                        {
                            var name = colors[i - 2].Name;
                            table.Cell(row, i + 1).Range.Shading.BackgroundPatternColor = (name == "Green" ? WdColor.wdColorGreen :
                                name == "Yellow" ? WdColor.wdColorYellow : name == "Red" ? WdColor.wdColorRed : name == "Blue" ?
                                WdColor.wdColorBlue : WdColor.wdColorOrange);
                        }
                    }//end for
                    j++;
                    row++;
                }//end nested foreach
            }//end foreach

            ChangeProgress(1, "Adding Earnings Date score explaination...");
            /*Adds a new paragraph containing the explanation for the earningsDate scoring*/
            Word.Paragraph scoreExplanation = document.Content.Paragraphs.Add();
            scoreExplanation.Range.Text = String.Format("{0}\n{1}\n{2}\n{3}", GetScoreExplanation(1,secondScreener), GetScoreExplanation(2, secondScreener), GetScoreExplanation(3, secondScreener), GetScoreExplanation(4, secondScreener));
            if(!secondScreener)
            {
                scoreExplanation.Range.Text = String.Format("\n{0}", GetScoreExplanation(5, secondScreener));
            }
            scoreExplanation.Range.InsertParagraphAfter();

            ChangeProgress(1, "Finializing...");
            //Saves the document to the path provided when instantiating the SaveDocument object and closes the Word instance
            object file = Path.Combine(filePath, fileName);
            File.Delete(Path.Combine(filePath, fileName));
            document.SaveAs2(ref file);
            document.Close();
            app.Quit();
        }//end SaveWordDocument

        public void SaveXmlDocument(Dictionary<string, Dictionary<string, Stock>> stocks, bool secondScreener)
        {
            XmlData xml = new XmlData();
            xml.SaveStocks(stocks, filePath, fileName, secondScreener);
        }//end SaveXmlDocument

        private int ChangeProgress(int val, string update, int max = 0)
        {            if (OnProgressUpdate != null)
            {
                OnProgressUpdate(val, update, max);
            }//end if

            return val;
        }//end changeProgress

        private void MergeCells(ref Table table, int row1, int cell1, int row2, int cell2)
        {
            table.Rows[row1].Cells[cell1].Merge(table.Rows[row2].Cells[cell2]);
        }//end MergeCells

        /// <summary>
        /// Returns the header text for the specified column 3 to 10
        /// </summary>
        /// <param name="col">The column from 3 to 10</param>
        /// <returns></returns>
        private string[] GetHeaderText(bool secondScreener)
        {
            if(secondScreener)
            {
                return new string[] { "CM Fund\n7-10 = Green\n4-6 = Yellow\n0-3 = Red",
                    "CM Growth\n7-10 = Green\n4-6 = Yellow\n0-3 = Red", "CM Valuation\n5-10 = Green\n3-4 = Yellow\n0-2 = Red",
                    "EPS This Y\nx >= 25% = Green\n25% > x >= 0% = Yellow\nx < 0% = Red", "EPS Next Y\nx >= 25% = Green\n25% > x >= 0% = Yellow\nx < 0% = Red",
                    "Finviz Recom\n1-2 = Green\n2.1-3.0 = Yellow\n3.1-5 = Red", "Target Price\nx > Actual price = Green\nx < Actual price = Red",
                    "Earnings Date\n" + (secondScreener ? "No scoring for\nthis screener" : "*See end of\ndocument"),
                    "Zacks Rank\n" + (secondScreener ? "" : "*") + "*See end of\ndocument",
                    "Total\n" + (secondScreener ? "" : "*") + "**See end of\ndocument" };
            } else
            {
                return new string[] { "CM Fund\n7-10 = Green\n4-6 = Yellow\n0-3 = Red",
                    "CM Growth\n7-10 = Green\n4-6 = Yellow\n0-3 = Red", "CM Valuation\n5-10 = Green\n3-4 = Yellow\n0-2 = Red",
                    "52W High\n-90 to -10 = Green\n-29 to -10 = Yellow\n-9 to + = Red", "Finviz Recom\n1-2 = Green\n2.1-3.0 = Yellow\n3.1-5 = Red",
                    "Curr_Ratio\n>3.0 = Green\n1-3 = Yellow\n0-.9 = Red", "Earnings Date\n" + (secondScreener ? "No scoring for\nthis screener" : "*See end of\ndocument"),
                    "Zacks Rank\n" + (secondScreener ? "" : "*") + "*See end of\ndocument",
                    "Total\n" + (secondScreener ? "" : "*") + "**See end of\ndocument" };
            }
        }//end GetHeaderText

        /// <summary>
        /// Returns the Earnings Date scoring explaination.
        /// </summary>
        /// <param name="line">The line requested.  1 for the first, 2 for the second</param>
        /// <returns>The requested line</returns>
        private string GetScoreExplanation(int line, bool secondScreener)
        {
            switch(line)
            {
                case 1:
                    return (!secondScreener ? "*Earnings Date: 1 <= x <= 70 days = Green, 71 days <= x < 4 months = Yellow, After 4mo = Red." : "*Zacks Rank: Green = +6, Blue = +4, Yellow = +2, Orange = -2, Red = -4.");
                case 2:
                    return (!secondScreener ? "*Earnings Date Same Day: Before close - before 9:30am = Red, after 9:30am = Green; After close - before 4:00pm = Red, after = Green." : "**Total score is calculated using a weight for each color and multiplying the original score by the new weight.");
                case 3:
                    return (!secondScreener ? "**Zacks Rank: Green = +6, Blue = +4, Yellow = +2, Orange = -2, Red = -4." : "**CM Fund = *5, CM Growth = *3, CM Valuation = *2, EPS Next Y = *5, Recom = *3, Target Price = *2, Zacks = *10");
                case 4:
                    return (!secondScreener ? "***Total score is calculated using a weight for each color." : "***Excluding Zacks Rank: Green = +4, Yellow = +2, Red = -2.");
                case 5:
                    return "***Excluding Zacks Rank: Green = +4, Yellow = +2, Red = -2.";
                default:
                    return "";
            }
        }//end GetEarningsDateText

        private int GetStockCount(Dictionary<string, Dictionary<string, string>> map)
        {
            return (from m in map.Values select m.Values).Count() + 12;
        }

        /// <summary>
        /// Returns the cell range from the worksheet
        /// </summary>
        /// <param name="worksheet">The worksheet being used</param>
        /// <param name="row1">The row of the first cell</param>
        /// <param name="col1">The column of the first cell</param>
        /// <param name="row2">The row of the second cell (if only one cell set to the same value as row1)</param>
        /// <param name="col2">The column of the second cell (if only one cell set to the same value as col1)</param>
        /// <returns></returns>
        private Excel.Range GetRange(Excel.Worksheet worksheet, int row1, int col1, int row2, int col2)
        {
            return worksheet.Range[worksheet.Cells[row1, col1], worksheet.Cells[row2, col2]];
        }//end GetRange

        /// <summary>
        /// Merges the desired cells together
        /// </summary>
        /// <param name="sheet">The worksheet being used</param>
        /// <param name="row1">The row of the first cell</param>
        /// <param name="col1">The column of the first cell</param>
        /// <param name="row2">The row of the second cell</param>
        /// <param name="col2">The column of the second cell</param>
        private void MergeCells(ref Excel.Worksheet sheet, int row1, int col1, int row2, int col2)
        {
            Excel.Range range = GetRange(sheet, row1, col1, row2, col2);
            range.Merge(true);
        }//end MergeCells

        /// <summary>
        /// Sets the width of the given column range
        /// </summary>
        /// <param name="worksheet">The worksheet being used</param>
        /// <param name="row1">The row of the first cell</param>
        /// <param name="col1">The column of the first cell</param>
        /// <param name="row2">The row of the second cell (if only one cell set to the same value as row1)</param>
        /// <param name="col2">The column of the second cell (if only one cell set to the same value as col1)</param>
        /// <param name="width">The desired width of the column</param>
        private void SetColumnWidth(ref Excel.Worksheet worksheet, int row1, int col1, int row2, int col2, double width)
        {
            var range = GetRange(worksheet, row1, col1, row2, col2);
            range.EntireColumn.ColumnWidth = width;
        }//end SetColumnWidth
    }//end SaveDocument
}//end namespace

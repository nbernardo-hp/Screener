using System;
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
        public delegate void ProgressUpdate(object[] update);
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

        public void SaveExcelDocument(Dictionary<string, Dictionary<string, Stock>> map)
        {
            ChangeProgress(0, "Initializing...");
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
            style.Font.Size = 9;

            //Sets the column width of each column and the header text for each column
            ChangeProgress(1, "Writing header rows...");
            Excel.Range formatRange = GetRange(worksheet, 1, 1, 1, 10);
            formatRange.EntireRow.RowHeight = 60.00;
            SetColumnWidth(ref worksheet, 1, 1, 1, 1, 5.14);
            SetColumnWidth(ref worksheet, 1, 2, 1, 2, 26.29);
            MergeCells(ref worksheet, 1, 1, 1, 2);
            worksheet.Cells[1, 3] = GetHeaderText(3);
            SetColumnWidth(ref worksheet, 1, 3, 1, 3, 9.14);
            worksheet.Cells[1, 4] = GetHeaderText(4);
            SetColumnWidth(ref worksheet, 1, 4, 1, 4, 10.86);
            worksheet.Cells[1, 5] = GetHeaderText(5);
            SetColumnWidth(ref worksheet, 1, 5, 1, 5, 12.14);
            worksheet.Cells[1, 6] = GetHeaderText(6);
            SetColumnWidth(ref worksheet, 1, 6, 1, 6, 13.43);
            worksheet.Cells[1, 7] = GetHeaderText(7);
            SetColumnWidth(ref worksheet, 1, 7, 1, 7, 13.57);
            worksheet.Cells[1, 8] = GetHeaderText(8);
            SetColumnWidth(ref worksheet, 1, 8, 1, 8, 9.57);
            worksheet.Cells[1, 9] = GetHeaderText(9);
            SetColumnWidth(ref worksheet, 1, 9, 1, 9, 12.43);
            worksheet.Cells[1, 10] = GetHeaderText(10);
            SetColumnWidth(ref worksheet, 1, 10, 1, 10, 7.71);

            formatRange = GetRange(worksheet, 2, 7, 2, 8);
            formatRange.EntireColumn.NumberFormat = "#.#";
            formatRange = GetRange(worksheet, 1, 2, 1, 10);
            formatRange.EntireColumn.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            //formatRange = GetRange(worksheet, 3, 9, 3, 9);
            //formatRange.EntireColumn.NumberFormat = "mm/dd/yyyy";

            int i = 2;//indicates the current row to begin on.  Excel starts indexing at 1
            foreach (var sector in frmScreener.SortSectorKeys(map.Keys))
            {
                ChangeProgress(1, String.Format("Writing and formatting {0} header", sector));
                /*Sets the background color and text alignment of the Sector header row.  Merges the first two columns
                 *together and the last 8 together.  Sets the header text for the Sector and increments the current row*/
                formatRange = GetRange(worksheet, i, 1, i, 10);
                formatRange.EntireRow.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Silver);
                formatRange.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                MergeCells(ref worksheet, i, 1, i, 2);
                MergeCells(ref worksheet, i, 3, i, 10);
                worksheet.Cells[i, 1] = String.Format("{0} {1}", DateTime.Today.ToShortDateString(), sector);
                i++;

                /*Gets the ordered Stock objects for the Sector and loops through the objects.  Gets the attributes for the
                 *current object to loop through.  Loops through each attribute and sets the cell text to the attribute.  If
                 *the current row is odd, changes the background color for easier reading.  Increases the current row*/
                IOrderedEnumerable<Stock> stocks = frmScreener.SortSectorDictionary(map[sector]);
                int k = 0;
                foreach (var s in stocks)
                {
                    ChangeProgress(1, String.Format("Writing {0} information", s.SymbolValue));
                    if (k % 2 != 0)
                    {
                        formatRange = GetRange(worksheet, i, 1, i, 10);
                        formatRange.EntireRow.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Gainsboro);
                    }

                    var attributes = s.GetAttributesEnumerable();
                    for (int j = 1; j <= attributes.Count(); j++)
                    {
                        worksheet.Cells[i, j] = attributes.ElementAt(j - 1).ToString();
                    }//end for
                    k++;
                    i++;
                }//end nested foreach
            }//end foreach

            ChangeProgress(1, "Formatting borders...");
            //Add a border around every cell on in the table
            formatRange = worksheet.UsedRange;
            formatRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            formatRange.Borders.Weight = 2d;

            ChangeProgress(1, "Adding Earnings Date score explaination...");
            //Merge two cells at the botom of the document and add the earnings date explanation
            MergeCells(ref worksheet, i, 1, i, 10);
            MergeCells(ref worksheet, i+1, 1, i+1, 10);
            worksheet.Cells[i, 1] = GetEarningsDateText(1);
            worksheet.Cells[i+1, 1] = GetEarningsDateText(2);

            ChangeProgress(1, "Finializing...");
            //Save the document and close the workbook and application
            File.Delete(Path.Combine(filePath, fileName));
            workbook.SaveAs(Path.Combine(filePath, fileName));
            workbook.Close();
            app.Quit();
        }//end

        public void SaveHtmlDocument(Dictionary<string, Dictionary<string, Stock>> map)
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
                    sw.WriteLine("<th>52 Week High<br>-90 to -30 = +4<br>-29 to -10 = +2<br>-9 to + = -2</th>");
                    sw.WriteLine("<th>Finviz Recom<br>1-2 = +4<br>2.1-3.0 = +2<br>3.1-5 = -2</th>");
                    sw.WriteLine("<th>Current Ratio<br>> 3.0 = +4<br>1-3 = +2<br>0-.9 = -2</th>");
                    sw.WriteLine("<th>Earnings Date<br>See scoring below</th>");
                    sw.WriteLine("<th>Total Score<br>The sum of the scoring<br>from each column</th>");
                    sw.WriteLine("</tr>");

                    foreach(var sector in frmScreener.SortSectorKeys(map.Keys))
                    {
                        sw.Write(String.Format("<tr style=\"text-align:right\" class=\"sectorHeader\"><th colspan=\"2\">{0} {1}</th><th colspan=\"8\"/></tr>", DateTime.Today.ToShortDateString(), sector));

                        int i = 0;
                        IOrderedEnumerable<Stock> stocks = frmScreener.SortSectorDictionary(map[sector]);
                        foreach(var s in stocks)
                        {
                            sw.WriteLine(String.Format("<tr{0}>", (i % 2 != 0 ? " style=\"background-color:gainsboro\"" : "")));

                            var attributes = s.GetAttributesEnumerable();
                            for (int j = 0; j < attributes.Count(); j++)
                            {
                                sw.WriteLine(String.Format("<td>{0}</td>", attributes.ElementAt(j)));
                            }//end for

                            sw.WriteLine("</tr>");
                            i++;
                        }//end nested foreach
                    }//end foreach

                    sw.WriteLine("</table>");
                    sw.WriteLine(String.Format("<p>{0}</p><p>{1}</p>", GetEarningsDateText(1), GetEarningsDateText(2)));
                    sw.WriteLine("</body>");
                    sw.WriteLine("</html>");
                }//end nested using
            }//end using
        }//end saveHtmlDocument

        /// <summary>
        /// Saves a .docx file of the table to the Directory returned from the SaveFileDialog
        /// </summary>
        /// <param name="stocks">The Stock objects to be used</param>
        public void SaveWordDocument(Dictionary<string, Dictionary<string, Stock>> map, int numRows)
        {
            /*starts a new instance of Word and checks to verify that the instance is created.  Sets the visibility and animation to false.
             *Creates a new Word document, adjusts the orientation, and creates a new paragraph*/
            ChangeProgress(0, "Initializing...");
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
            Table table = document.Tables.Add(paragraph.Range, numRows, 10);
            table.Borders.Enable = 1;

            ChangeProgress(1, "Writing header rows...");
            /*Loops through the first row and sets the text to the string returned from GetHeaderText.  Aligns the
             *paragraph text and merges the first 2 cells of the table*/
            for (int i = 3; i < 11; i++)
            {
                table.Cell(1, i).Range.Text = GetHeaderText(i);
            }//end for
            table.Rows[1].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            MergeCells(ref table, 1, 1, 1, 2);

            int row = 2;

            /*Loops through each Sector that is in the Stock object Dictionary.  Creates the Sector header for each Sector
             *in the table.  Merges the last rows and then the first 2, sets the background color, aligment, and text.*/
             foreach(var sector in frmScreener.SortSectorKeys(map.Keys))
            {
                ChangeProgress(1, String.Format("Writing and formatting {0} header", sector));
                MergeCells(ref table, row, 3, row, 10);
                MergeCells(ref table, row, 1, row, 2);
                table.Rows[row].Range.Shading.BackgroundPatternColor = WdColor.wdColorGray15;
                table.Rows[row].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                table.Cell(row, 1).Range.Text = String.Format("{0} {1}", DateTime.Today.ToShortDateString(), sector);
                row++;

                IOrderedEnumerable<Stock> stocks = frmScreener.SortSectorDictionary(map[sector]);

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
                    var attributes = s.GetAttributesEnumerable();
                    for(int i = 0; i < attributes.Count(); i++)
                    {
                        table.Cell(row, i+1).Range.Text = attributes.ElementAt(i).ToString();
                    }//end for
                    j++;
                    row++;
                }//end nested foreach
            }//end foreach

            ChangeProgress(1, "Adding Earnings Date score explaination...");
            /*Adds a new paragraph containing the explanation for the earningsDate scoring*/
            Word.Paragraph earningsDate = document.Content.Paragraphs.Add();
            earningsDate.Range.Text = String.Format("{0}\n{1}", GetEarningsDateText(1), GetEarningsDateText(2));
            earningsDate.Range.InsertParagraphAfter();

            ChangeProgress(1, "Finializing...");
            //Saves the document to the path provided when instantiating the SaveDocument object and closes the Word instance
            object file = Path.Combine(filePath, fileName);
            File.Delete(Path.Combine(filePath, fileName));
            document.SaveAs2(ref file);
            document.Close();
            app.Quit();
        }//end SaveWordDocument

        public void SaveXmlDocument(Dictionary<string, Dictionary<string, Stock>> stocks)
        {
            XmlData xml = new XmlData();
            xml.SaveStocks(stocks, filePath, fileName);
        }//end SaveXmlDocument

        private object[] ChangeProgress(int val, string update)
        {
            object[] change = { val, update };
            if (OnProgressUpdate != null)
            {
                OnProgressUpdate(change);
            }//end if

            return change;
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
        private string GetHeaderText(int col)
        {
            switch(col)
            {
                case 3:
                    return "CM Fund\n7-10 = +4\n4-6 = +2\n0-3 = -2";
                case 4:
                    return "CM Growth\n7-10 = +4\n4-6 = +2\n0-3 = -2";
                case 5:
                    return "CM Valuation\n5-10 = +4\n3-4 = +2\n0-2 = -2";
                case 6:
                    return "52W High\n-90 to -10 = +4\n-29 to -10 = +2\n-9 to + = -2";
                case 7:
                    return "Finviz Recom\n1-2 = +4\n2.1-3.0 = +2\n3.1-5 = -2";
                case 8:
                    return "Curr_Ratio\n>3.0 = +4\n1-3 = +2\n0-.9 = -2";
                case 9:
                    return "Earnings Date\n**See end of\ndocument";
                case 10:
                    return "Total\nThe sum of the scoring\nfrom each column";
                default:
                    return "";
            }//end switch
        }//end GetHeaderText

        /// <summary>
        /// Returns the Earnings Date scoring explaination.
        /// </summary>
        /// <param name="line">The line requested.  1 for the first, 2 for the second</param>
        /// <returns>The requested line</returns>
        private string GetEarningsDateText(int line)
        {
            if(line == 1)
            {
                return "**Earnings Date: 1 <= x <= 70 days = +4, 71 days <= x < 4 months = +2, After 4mo = -2";
            } else
            {
                return "**Earnings Date Same Day: Before close - before 9:30am = -2, after 9:30am = +4; After close - before 4:00pm = -2, after = +4";
            }
        }//end GetEarningsDateText

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

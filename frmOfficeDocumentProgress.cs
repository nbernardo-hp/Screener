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
    public partial class frmOfficeDocumentProgress : Form
    {
        public frmOfficeDocumentProgress()
        {
            InitializeComponent();
        }//end default constructor

        /// <summary>
        /// Constructor used for saving Excel files
        /// </summary>
        /// <param name="doc">The SaveDocument object being used</param>
        /// <param name="map">The Stock object dictionary to use</param>
        public frmOfficeDocumentProgress(SaveDocument doc, Dictionary<string, Dictionary<string, Stock>> map)
        {
            try
            {
                InitializeComponent();
                Run(doc, map);
            } catch
            {

            }//end try-catch
        }//end 2 argument constructor

        /// <summary>
        /// Constructor used for creating Word documents
        /// </summary>
        /// <param name="doc">The SaveDocument object being used</param>
        /// <param name="map">The Stock object dictionary to use</param>
        /// <param name="rows">The number of rows for the table</param>
        public frmOfficeDocumentProgress(SaveDocument doc, Dictionary<string, Dictionary<string, Stock>> map, int rows)
        {
            try
            {
                InitializeComponent();
                Run(doc, map, rows);
            } catch
            {

            }//end try-catch
        }//end 3 argument constructor

        private List<object> AddArguments(SaveDocument doc, Dictionary<string, Dictionary<string, Stock>> map, int rows = -1)
        {
            List<object> arguments = new List<object>();
            arguments.Add(doc);
            arguments.Add(map);
            arguments.Add(rows);
            return arguments;
        }//end AddArguments

        /// <summary>
        /// Runs the basic functions of the from.  Assigns the value of the initial message and text of the form.  Creates the argument
        /// object and calls RunWorkerAsync with the arguments.
        /// </summary>
        /// <param name="doc">The SaveDocument object being used</param>
        /// <param name="map">The Stock object dictionary to use</param>
        /// <param name="rows">The number of rows for the table</param>
        private void Run(SaveDocument doc, Dictionary<string, Dictionary<string, Stock>> map, int rows = -1)
        {
            lblMessage.Text = String.Format("This may take a moment.  The file is being saved as a{0} file.", (rows == -1 ? "n Excel" : " Word"));
            this.Text = String.Format("Saving {0} Document", (rows == -1 ? "Excel" : "Word"));
            var args = AddArguments(doc, map, rows);
            bgwSaveDocument.RunWorkerAsync(args);
        }//end Run

        /// <summary>
        /// Starts the save process for saving an Excel or Word file by calling the appropriate SaveDocument function.
        /// </summary>
        /// <param name="doc">The SaveDocument object being used</param>
        /// <param name="map">The Stock object dictionary to use</param>
        /// <param name="rows">The number of rows for the table.  If anything other than -1 calls SaveWordDocument</param>
        private void StartSave(SaveDocument doc, Dictionary<string, Dictionary<string, Stock>> map, int rows = -1)
        {
            doc.OnProgressUpdate += doc_OnProgressUpdate;
            if (rows == -1)
            {
                doc.SaveExcelDocument(map);
            } else
            {
                doc.SaveWordDocument(map, rows);
            }//end if-else
        }//end StartSave

        private void bgwSaveDocument_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                List<object> objs = (List<object>)e.Argument;
                SaveDocument doc = (SaveDocument)objs[0];
                Dictionary<string, Dictionary<string, Stock>> map = (Dictionary<string, Dictionary<string, Stock>>)objs[1];
                int rows = (int)objs[2];

                StartSave(doc, map, rows);
            } catch
            {

            }//end try-catch
        }//end bgwSaveDocument_DoWork

        private void doc_OnProgressUpdate(object[] change)
        {
            base.Invoke((Action)delegate
            {
                if (pgbProgress.Value < pgbProgress.Maximum)
                {
                    pgbProgress.Value += int.Parse(change[0].ToString());
                    lblStatus.Text = change[1].ToString();
                    lblProgress.Text = String.Format("{0}%", pgbProgress.Value);
                    if (pgbProgress.Value == 10 || pgbProgress.Value == 100)
                    {
                        lblProgress.Location = new Point(lblProgress.Location.X - 7, lblProgress.Location.Y);
                    }//end if
                    if (lblStatus.Text == "Finializing...")
                    {
                        pgbProgress.Value = pgbProgress.Maximum;
                        lblProgress.Text = String.Format("{0}%", pgbProgress.Value);
                    }
                }//end if
            });
        }//end scraper_OnProgressUpdate

        private void bgwSaveDocument_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                MessageBox.Show("File saved successfully", "Success", MessageBoxButtons.OK);
                this.Close();
            } catch
            {

            }
        }//end bgwSaveDocument_RunWorkerCompleted
    }//end Form
}//end namespace

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Screener
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                StartProgram();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }//end try-catch
        }//end Main

        private static void StartProgram()
        {
            /**/
            Preferences pref = new Preferences();
            pref.LoadPreferences();
            if (pref.GetLoaded())
            {
                LoadForms(pref);
            }
            else
            {
                frmSelectBrowser frmSelect = new frmSelectBrowser();
                Application.Run(frmSelect);
                if (frmSelect.DialogResult == DialogResult.OK)
                {
                    pref.BrowserValue = frmSelect.GetBrowserString();
                    frmPreferences frmPref = new frmPreferences(pref.GetSectorMapCopy());
                    Application.Run(frmPref);
                    if (frmPref.DialogResult == DialogResult.OK)
                    {
                        pref.SetSectorMap(frmPref.GetPreferences());
                        LoadForms(pref);
                    }//end 2x nested if
                }//end nested if
            }//end if-else
        }//end StartProgram

        private static void LoadForms(Preferences preferences)
        {
            frmSplash splash = new frmSplash(preferences);
            Application.Run(splash);
            frmScreener screener = new frmScreener(splash.GetStocks(), preferences);
            Application.Run(screener);
        }//end LoadForms
    }//end class Program
}//end Screener

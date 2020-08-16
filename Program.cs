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

                /**/
                Preferences pref = new Preferences();
                pref.LoadPreferences();
                if(pref.GetLoaded())
                {
                    frmSplash splash = new frmSplash(pref);
                    Application.Run(splash);
                } else
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
                            var x = 4;
                            pref.SetSectorMap(frmPref.GetPreferences());
                        }//end 2x nested if
                    }//end nested if
                }//end if-else
            } catch
            {

            }//end try-catch
        }//end Main
    }//end class Program
}//end Screener

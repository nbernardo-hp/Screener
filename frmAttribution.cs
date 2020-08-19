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
    public partial class frmAttribution : Form
    {
        public frmAttribution()
        {
            try
            {
                InitializeComponent();
                this.Icon = Properties.Resources.screenerIcon;
            } catch
            {

            }
        }//end default constructor

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }//end btnOK_Click

        private void lnkIcon_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {

            } catch
            {

            }
        }//end lnkIcon_LinkClicked

        private void lnkFlaticon_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {

            } catch
            {

            }
        }//end lnkFlaticon_LinkClicked

        private void lnkJackMoreh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {

            }
            catch
            {

            }
        }//end lnkJackMoreh_LinkClicked

        private void lnkTitle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {

            }
            catch
            {

            }
        }//end lnkTitle_LinkClicked

        private void lnkStockvault_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {

            }
            catch
            {

            }
        }//end lnkStockvault_LinkClicked
    }//end class
}//end namespace

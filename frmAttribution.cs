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
            InitializeComponent();
            this.Icon = Properties.Resources.screenerIcon;
        }//end default constructor

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }//end btnOK_Click
    }//end class
}//end namespace

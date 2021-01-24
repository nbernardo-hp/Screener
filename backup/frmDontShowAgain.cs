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
    public partial class frmDontShowAgain : Form
    {
        public frmDontShowAgain()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.screenerIcon;
        }

        public bool GetDontShowAgain() { return chkDontShowAgain.Checked; }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

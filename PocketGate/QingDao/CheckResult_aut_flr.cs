using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PocketGate.QingDao
{
    public partial class CheckResult_aut_flr : Form
    {
        public CheckResult_aut_flr()
        {
            InitializeComponent();
            FullScreen.HideHHTaskBar();
            this.WindowState = FormWindowState.Maximized;
        }

        private void CheckResult_aut_flr_Load(object sender, EventArgs e)
        {

        }

        private void CheckResult_aut_flr_Closed(object sender, EventArgs e)
        {
            FullScreen.ShowHHTaskBar();
        }
    }
}
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
    public partial class CheckScan : Form
    {
        protected string appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);//获取路径
        public CheckScan()
        {
            InitializeComponent();
            FullScreen.HideHHTaskBar();
            this.WindowState = FormWindowState.Maximized;
        }

        private void CheckScan_Load(object sender, EventArgs e)
        {

        }

        private void CheckScan_Closed(object sender, EventArgs e)
        {
            FullScreen.ShowHHTaskBar();
        }
    }
}
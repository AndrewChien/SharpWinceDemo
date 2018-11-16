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
    public partial class CheckManual : Form
    {
        protected string appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);//获取路径
        public CheckManual()
        {
            InitializeComponent();
            this.picCheckManul.Image = new Bitmap(appPath + @"\Pics\chkent.png");
            this.picDo.Image = new Bitmap(appPath + @"\Pics\chkentchk.png");
            this.picBack.Image = new Bitmap(appPath + @"\Pics\tckback.png");
            this.pic_logout.Image = new Bitmap(appPath + @"\Pics\chkentcancel.png");
            FullScreen.HideHHTaskBar();
            this.WindowState = FormWindowState.Maximized;
        }

        private void CheckManual_Load(object sender, EventArgs e)
        {

        }

        private void CheckManual_Closed(object sender, EventArgs e)
        {
            FullScreen.ShowHHTaskBar();
        }
    }
}
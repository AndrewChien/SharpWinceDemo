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
    public partial class CheckMain : Form
    {
        protected string appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);//获取路径
        public CheckMain()
        {
            InitializeComponent();
            this.picCheckMain.Image = new Bitmap(@"\Program Files\PocketGate\Pics\chkmain.png");
            this.pic_auto.Image = new Bitmap(@"\Program Files\PocketGate\Pics\chkmainbtn.png");
            this.pic_manul.Image = new Bitmap(@"\Program Files\PocketGate\Pics\chkmainbtn.png");
            this.pic_logout.Image = new Bitmap(@"\Program Files\PocketGate\Pics\chkmaincancel.png");
            FullScreen.HideHHTaskBar();
            this.WindowState = FormWindowState.Maximized;
        }

        private void pic_aotochk_Click(object sender, EventArgs e)
        {
            new CheckScan().Show();
            Close();
        }

        private void pic_handchk_Click(object sender, EventArgs e)
        {
            new CheckManual().Show();
            Close();
        }

        private void pic_cancel_Click(object sender, EventArgs e)
        {
            new Login().Show();
            Close();
        }

        private void CheckMain_Load(object sender, EventArgs e)
        {

        }

        private void CheckMain_Closed(object sender, EventArgs e)
        {
            FullScreen.ShowHHTaskBar();
            this.picCheckMain.Image.Dispose();
            this.pic_auto.Image.Dispose();
            this.pic_manul.Image.Dispose();
            this.pic_logout.Image.Dispose();
            Dispose();
        }
    }
}
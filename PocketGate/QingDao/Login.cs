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
    public partial class Login : Form
    {
        Configuration Config = null;
        protected string appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);//获取路径
        public Login()
        {
            //Graphics m_graphics = this.CreateGraphics();
            //Bitmap bm = new Bitmap("logo.png");
            //m_graphics.DrawImage(bm, 100, 100);
            //Bitmap bt = new Bitmap(50, 50);
            //Graphics gg = Graphics.FromImage(bt);
            InitializeComponent();
            this.picLoginMain.Image = new Bitmap(@"\Program Files\PocketGate\Pics\login.png");//\Program Files\PocketGate\Pics\login.png
            this.picLogin.Image = new Bitmap(@"\Program Files\PocketGate\Pics\loginbtn.png");
            FullScreen.HideHHTaskBar();
            this.WindowState = FormWindowState.Maximized;
            Config = Configuration.ReadConfig();
            if (Config == null)
                this.Close();
        }

        private void TckChk_QD_Load(object sender, EventArgs e)
        {

        }

        private void picLogin_Click(object sender, EventArgs e)
        {
            new CheckMain().Show();
        }

        private void Login_Closed(object sender, EventArgs e)
        {
            FullScreen.ShowHHTaskBar();
            this.picLoginMain.Image.Dispose();
            this.picLogin.Image.Dispose();
            Dispose();
        }
    }
}
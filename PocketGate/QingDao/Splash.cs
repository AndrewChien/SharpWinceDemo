using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Reflection;
using System.Runtime.InteropServices;

namespace PocketGate.QingDao
{
    public partial class Splash : Form
    {
        public Splash(string msg)
        {
            InitializeComponent();
            this.BringToFront();
            this.TopMost = true;
            this.Location = new Point(60, 100);
            this.lblmsg.Text = msg;
        }
    }
}
﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PocketGate.QingDao
{
    public partial class CheckResult_ent_flr : Form
    {
        public CheckResult_ent_flr()
        {
            InitializeComponent();
            FullScreen.HideHHTaskBar();
            this.WindowState = FormWindowState.Maximized;
        }

        private void CheckResult_ent_flr_Load(object sender, EventArgs e)
        {

        }

        private void CheckResult_ent_flr_Closed(object sender, EventArgs e)
        {
            FullScreen.ShowHHTaskBar();
        }
    }
}
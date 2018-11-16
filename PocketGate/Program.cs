using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using PocketGate.QingDao;

namespace PocketGate
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [MTAThread]
        static void Main()
        {
            //Application.Run(new MainForm());
            Application.Run(new Main_QD());
        }
    }
}
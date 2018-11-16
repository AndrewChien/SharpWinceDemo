using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.IO;
using System.Reflection;

namespace PocketGate.Helper
{
    public static class SoundHelper
    {
        //public static uint SND_ASYNC = 0x0001;
        //public static uint SND_FILENAME = 0x00020000;
        //[DllImport("winmm.dll")]
        //public static extern uint mciSendString(string lpstrCommand,
        //string lpstrReturnString, uint uReturnLength, uint hWndCallback);
        //public static void Play(string file)
        //{
        //    mciSendString(@"close temp_alias", null, 0, 0);
        //    mciSendString("open \".\\" + file + "\" alias temp_alias", null, 0, 0);
        //    mciSendString("play temp_alias", null, 0, 0);
        //} 

        public static void Play(string file)
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
            System.Media.SoundPlayer sp = new SoundPlayer();
            sp.SoundLocation = path + @"\Sounds\" + file;
            
            sp.Play();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace GameLauncher
{
    class Launcher
    {
        public static void PlayGame1()
        {
            Process.Start("C:\\Program Files\\Microsoft Games\\Chess\\Chess.exe");
        }
        public static void playGame2()
        {
            Process.Start("C:\\Program Files\\Microsoft Games\\FreeCell\\FreeCell.exe");
        }
        public static void playGame3()
        {
            Process.Start("notepad.exe");
        }
    }
}

using System;
using System.Windows.Forms;
using KartLauncher.Data.Forms;
using  KartLauncher.Data.Forms;

namespace KartLauncher
{
    internal static class Program
    {
        public static Launcher LauncherDlg;
        public static GetKart GetKartDlg;
        public static int MAX_EQP_P;
        public static bool SpeedPatch;
        public static bool PreventItem;
        public static bool Developer_Name;

        static Program()
        {
            MAX_EQP_P = 32;
            Developer_Name = true;
        }

        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Launcher StartLauncher = new Launcher();
            LauncherDlg = StartLauncher;
            Application.Run(StartLauncher);
        }
    }
}
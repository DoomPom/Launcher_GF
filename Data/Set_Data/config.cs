using KartLauncher;
using System;
using System.IO;

namespace KartLauncher.Data.Set_Data
{
    public static class config
    {
        public static byte PreventItem_Use = 0;
        public static byte SpeedPatch_Use = 0;

        public static void Load_PreventItem()
        {
            string Load_PreventItem = FileName.config_LoadFile + FileName.config_PreventItem + FileName.Extension;
            if (File.Exists(Load_PreventItem))
            {
                string textValue = File.ReadAllText(Load_PreventItem);
                PreventItem_Use = byte.Parse(textValue);
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(Load_PreventItem, false))
                {
                    streamWriter.Write(PreventItem_Use);
                }
            }
            Check_PreventItem();
        }

        public static void Load_SpeedPatch()
        {
            string Load_SpeedPatch = FileName.config_LoadFile + FileName.config_SpeedPatch + FileName.Extension;
            if (File.Exists(Load_SpeedPatch))
            {
                string textValue = File.ReadAllText(Load_SpeedPatch);
                SpeedPatch_Use = byte.Parse(textValue);
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(Load_SpeedPatch, false))
                {
                    streamWriter.Write(SpeedPatch_Use);
                }
            }
            Check_SpeedPatch();
        }

        public static void Check_PreventItem()
        {
            if (PreventItem_Use == 0)
            {
                Program.PreventItem = false;
            }
            else
            {
                Program.PreventItem = true;
            }
        }

        public static void Check_SpeedPatch()
        {
            if (SpeedPatch_Use == 0)
            {
                Program.SpeedPatch = false;
                Program.LauncherDlg.Text = "Launcher";
            }
            else
            {
                Program.SpeedPatch = true;
                Program.LauncherDlg.Text = "Launcher (속도 패치)";
            }
        }

        public static void Load_ALL()
        {
            Load_PreventItem();
            Load_SpeedPatch();
        }
    }
}
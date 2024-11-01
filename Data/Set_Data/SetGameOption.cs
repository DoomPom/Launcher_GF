using System;
using System.IO;

namespace KartLauncher.Data.Set_Data
{
    public static class SetGameOption
    {
        public static ushort Version;
        public static float Set_BGM = 1f;
        public static float Set_Sound = 1f;
        public static byte Main_BGM = 0;
        public static byte Sound_effect = 1;
        public static byte Full_screen = 1;
        public static byte Unk1 = 1;
        public static byte Unk2 = 1;
        public static byte Unk3 = 1;
        public static byte Unk4 = 1;
        public static byte Unk5 = 0;
        public static byte Unk6 = 0;
        public static byte Unk7 = 0;
        public static byte Unk8 = 1;
        public static byte Unk9 = 1;
        public static byte Unk10 = 1;
        public static byte Unk11 = 14; //녹화 품질
        public static byte BGM_Check = 1;
        public static byte Sound_Check = 1;
        public static byte Unk12 = 1;
        public static byte Unk13 = 1;
        public static byte GameType = 0;
        public static byte SetGhost = 1;
        public static byte SpeedType = 7;
        public static byte Unk14 = 1;
        public static byte Unk15 = 1;
        public static byte Unk16 = 1;
        public static byte Unk17 = 1;
        public static byte Set_screen = 0;
        public static byte Unk18 = 0;

        public static void Save_SetGameOption()
        {
            using (StreamWriter streamWriter = new StreamWriter(FileName.SetGameOption_LoadFile + FileName.SetGameOption_Set_BGM + FileName.Extension, false))
            {
                streamWriter.Write(Set_BGM);
            }
            using (StreamWriter streamWriter = new StreamWriter(FileName.SetGameOption_LoadFile + FileName.SetGameOption_Set_Sound + FileName.Extension, false))
            {
                streamWriter.Write(Set_Sound);
            }
            using (StreamWriter streamWriter = new StreamWriter(FileName.SetGameOption_LoadFile + FileName.SetGameOption_Main_BGM + FileName.Extension, false))
            {
                streamWriter.Write(Main_BGM);
            }
            using (StreamWriter streamWriter = new StreamWriter(FileName.SetGameOption_LoadFile + FileName.SetGameOption_Sound_effect + FileName.Extension, false))
            {
                streamWriter.Write(Sound_effect);
            }
            using (StreamWriter streamWriter = new StreamWriter(FileName.SetGameOption_LoadFile + FileName.SetGameOption_Full_screen + FileName.Extension, false))
            {
                streamWriter.Write(Full_screen);
            }
            using (StreamWriter streamWriter = new StreamWriter(FileName.SetGameOption_LoadFile + FileName.SetGameOption_Unk1 + FileName.Extension, false))
            {
                streamWriter.Write(Unk1);
            }
            using (StreamWriter streamWriter = new StreamWriter(FileName.SetGameOption_LoadFile + FileName.SetGameOption_Unk2 + FileName.Extension, false))
            {
                streamWriter.Write(Unk2);
            }
            using (StreamWriter streamWriter = new StreamWriter(FileName.SetGameOption_LoadFile + FileName.SetGameOption_Unk3 + FileName.Extension, false))
            {
                streamWriter.Write(Unk3);
            }
            using (StreamWriter streamWriter = new StreamWriter(FileName.SetGameOption_LoadFile + FileName.SetGameOption_Unk4 + FileName.Extension, false))
            {
                streamWriter.Write(Unk4);
            }
            using (StreamWriter streamWriter = new StreamWriter(FileName.SetGameOption_LoadFile + FileName.SetGameOption_Unk5 + FileName.Extension, false))
            {
                streamWriter.Write(Unk5);
            }
            using (StreamWriter streamWriter = new StreamWriter(FileName.SetGameOption_LoadFile + FileName.SetGameOption_Unk6 + FileName.Extension, false))
            {
                streamWriter.Write(Unk6);
            }
            using (StreamWriter streamWriter = new StreamWriter(FileName.SetGameOption_LoadFile + FileName.SetGameOption_Unk7 + FileName.Extension, false))
            {
                streamWriter.Write(Unk7);
            }
            using (StreamWriter streamWriter = new StreamWriter(FileName.SetGameOption_LoadFile + FileName.SetGameOption_Unk8 + FileName.Extension, false))
            {
                streamWriter.Write(Unk8);
            }
            using (StreamWriter streamWriter = new StreamWriter(FileName.SetGameOption_LoadFile + FileName.SetGameOption_Unk9 + FileName.Extension, false))
            {
                streamWriter.Write(Unk9);
            }
            using (StreamWriter streamWriter = new StreamWriter(FileName.SetGameOption_LoadFile + FileName.SetGameOption_Unk10 + FileName.Extension, false))
            {
                streamWriter.Write(Unk10);
            }
            using (StreamWriter streamWriter = new StreamWriter(FileName.SetGameOption_LoadFile + FileName.SetGameOption_Unk11 + FileName.Extension, false))
            {
                streamWriter.Write(Unk11);
            }
            using (StreamWriter streamWriter = new StreamWriter(FileName.SetGameOption_LoadFile + FileName.SetGameOption_BGM_Check + FileName.Extension, false))
            {
                streamWriter.Write(BGM_Check);
            }
            using (StreamWriter streamWriter = new StreamWriter(FileName.SetGameOption_LoadFile + FileName.SetGameOption_Sound_Check + FileName.Extension, false))
            {
                streamWriter.Write(Sound_Check);
            }
            using (StreamWriter streamWriter = new StreamWriter(FileName.SetGameOption_LoadFile + FileName.SetGameOption_Unk12 + FileName.Extension, false))
            {
                streamWriter.Write(Unk12);
            }
            using (StreamWriter streamWriter = new StreamWriter(FileName.SetGameOption_LoadFile + FileName.SetGameOption_Unk13 + FileName.Extension, false))
            {
                streamWriter.Write(Unk13);
            }
            using (StreamWriter streamWriter = new StreamWriter(FileName.SetGameOption_LoadFile + FileName.SetGameOption_GameType + FileName.Extension, false))
            {
                streamWriter.Write(GameType);
            }
            using (StreamWriter streamWriter = new StreamWriter(FileName.SetGameOption_LoadFile + FileName.SetGameOption_SetGhost + FileName.Extension, false))
            {
                streamWriter.Write(SetGhost);
            }
            using (StreamWriter streamWriter = new StreamWriter(FileName.SetGameOption_LoadFile + FileName.SetGameOption_SpeedType + FileName.Extension, false))
            {
                streamWriter.Write(SpeedType);
            }
            using (StreamWriter streamWriter = new StreamWriter(FileName.SetGameOption_LoadFile + FileName.SetGameOption_Unk14 + FileName.Extension, false))
            {
                streamWriter.Write(Unk14);
            }
            using (StreamWriter streamWriter = new StreamWriter(FileName.SetGameOption_LoadFile + FileName.SetGameOption_Unk15 + FileName.Extension, false))
            {
                streamWriter.Write(Unk15);
            }
            using (StreamWriter streamWriter = new StreamWriter(FileName.SetGameOption_LoadFile + FileName.SetGameOption_Unk16 + FileName.Extension, false))
            {
                streamWriter.Write(Unk16);
            }
            using (StreamWriter streamWriter = new StreamWriter(FileName.SetGameOption_LoadFile + FileName.SetGameOption_Unk17 + FileName.Extension, false))
            {
                streamWriter.Write(Unk17);
            }
            using (StreamWriter streamWriter = new StreamWriter(FileName.SetGameOption_LoadFile + FileName.SetGameOption_Set_screen + FileName.Extension, false))
            {
                streamWriter.Write(Set_screen);
            }
            using (StreamWriter streamWriter = new StreamWriter(FileName.SetGameOption_LoadFile + FileName.SetGameOption_Unk18 + FileName.Extension, false))
            {
                streamWriter.Write(Unk18);
            }
            using (StreamWriter streamWriter = new StreamWriter(FileName.SetGameOption_LoadFile + FileName.SetGameOption_Version + FileName.Extension, false))
            {
                streamWriter.Write(Version);
            }
        }

        public static void Load_SetGameOption()
        {
            string Load_Set_BGM = FileName.SetGameOption_LoadFile + FileName.SetGameOption_Set_BGM + FileName.Extension;
            if (File.Exists(Load_Set_BGM))
            {
                string textValue = File.ReadAllText(Load_Set_BGM);
                Set_BGM = float.Parse(textValue);
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(Load_Set_BGM, false))
                {
                    streamWriter.Write(Set_BGM);
                }
            }
            //-------------------------------------------------------------------------
            string Load_Set_Sound = FileName.SetGameOption_LoadFile + FileName.SetGameOption_Set_Sound + FileName.Extension;
            if (File.Exists(Load_Set_Sound))
            {
                string textValue = File.ReadAllText(Load_Set_Sound);
                Set_Sound = float.Parse(textValue);
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(Load_Set_Sound, false))
                {
                    streamWriter.Write(Set_Sound);
                }
            }
            //-------------------------------------------------------------------------
            string Load_Main_BGM = FileName.SetGameOption_LoadFile + FileName.SetGameOption_Main_BGM + FileName.Extension;
            if (File.Exists(Load_Main_BGM))
            {
                string textValue = File.ReadAllText(Load_Main_BGM);
                Main_BGM = byte.Parse(textValue);
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(Load_Main_BGM, false))
                {
                    streamWriter.Write(Main_BGM);
                }
            }
            //-------------------------------------------------------------------------
            string Load_Sound_effect = FileName.SetGameOption_LoadFile + FileName.SetGameOption_Sound_effect + FileName.Extension;
            if (File.Exists(Load_Sound_effect))
            {
                string textValue = File.ReadAllText(Load_Sound_effect);
                Sound_effect = byte.Parse(textValue);
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(Load_Sound_effect, false))
                {
                    streamWriter.Write(Sound_effect);
                }
            }
            //-------------------------------------------------------------------------
            string Load_Full_screen = FileName.SetGameOption_LoadFile + FileName.SetGameOption_Full_screen + FileName.Extension;
            if (File.Exists(Load_Full_screen))
            {
                string textValue = File.ReadAllText(Load_Full_screen);
                Full_screen = byte.Parse(textValue);
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(Load_Full_screen, false))
                {
                    streamWriter.Write(Full_screen);
                }
            }
            //-------------------------------------------------------------------------
            string Load_Unk1 = FileName.SetGameOption_LoadFile + FileName.SetGameOption_Unk1 + FileName.Extension;
            if (File.Exists(Load_Unk1))
            {
                string textValue = File.ReadAllText(Load_Unk1);
                Unk1 = byte.Parse(textValue);
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(Load_Unk1, false))
                {
                    streamWriter.Write(Unk1);
                }
            }
            //-------------------------------------------------------------------------
            string Load_Unk2 = FileName.SetGameOption_LoadFile + FileName.SetGameOption_Unk2 + FileName.Extension;
            if (File.Exists(Load_Unk2))
            {
                string textValue = File.ReadAllText(Load_Unk2);
                Unk2 = byte.Parse(textValue);
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(Load_Unk2, false))
                {
                    streamWriter.Write(Unk2);
                }
            }
            //-------------------------------------------------------------------------
            string Load_Unk3 = FileName.SetGameOption_LoadFile + FileName.SetGameOption_Unk3 + FileName.Extension;
            if (File.Exists(Load_Unk3))
            {
                string textValue = File.ReadAllText(Load_Unk3);
                Unk3 = byte.Parse(textValue);
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(Load_Unk3, false))
                {
                    streamWriter.Write(Unk3);
                }
            }
            //-------------------------------------------------------------------------
            string Load_Unk4 = FileName.SetGameOption_LoadFile + FileName.SetGameOption_Unk4 + FileName.Extension;
            if (File.Exists(Load_Unk4))
            {
                string textValue = File.ReadAllText(Load_Unk4);
                Unk4 = byte.Parse(textValue);
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(Load_Unk4, false))
                {
                    streamWriter.Write(Unk4);
                }
            }
            //-------------------------------------------------------------------------
            string Load_Unk5 = FileName.SetGameOption_LoadFile + FileName.SetGameOption_Unk5 + FileName.Extension;
            if (File.Exists(Load_Unk5))
            {
                string textValue = File.ReadAllText(Load_Unk5);
                Unk5 = byte.Parse(textValue);
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(Load_Unk5, false))
                {
                    streamWriter.Write(Unk5);
                }
            }
            //-------------------------------------------------------------------------
            string Load_Unk6 = FileName.SetGameOption_LoadFile + FileName.SetGameOption_Unk6 + FileName.Extension;
            if (File.Exists(Load_Unk6))
            {
                string textValue = File.ReadAllText(Load_Unk6);
                Unk6 = byte.Parse(textValue);
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(Load_Unk6, false))
                {
                    streamWriter.Write(Unk6);
                }
            }
            //-------------------------------------------------------------------------
            string Load_Unk7 = FileName.SetGameOption_LoadFile + FileName.SetGameOption_Unk7 + FileName.Extension;
            if (File.Exists(Load_Unk7))
            {
                string textValue = File.ReadAllText(Load_Unk7);
                Unk7 = byte.Parse(textValue);
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(Load_Unk7, false))
                {
                    streamWriter.Write(Unk7);
                }
            }
            //-------------------------------------------------------------------------
            string Load_Unk8 = FileName.SetGameOption_LoadFile + FileName.SetGameOption_Unk8 + FileName.Extension;
            if (File.Exists(Load_Unk8))
            {
                string textValue = File.ReadAllText(Load_Unk8);
                Unk8 = byte.Parse(textValue);
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(Load_Unk8, false))
                {
                    streamWriter.Write(Unk8);
                }
            }
            //-------------------------------------------------------------------------
            string Load_Unk9 = FileName.SetGameOption_LoadFile + FileName.SetGameOption_Unk9 + FileName.Extension;
            if (File.Exists(Load_Unk9))
            {
                string textValue = File.ReadAllText(Load_Unk9);
                Unk9 = byte.Parse(textValue);
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(Load_Unk9, false))
                {
                    streamWriter.Write(Unk9);
                }
            }
            //-------------------------------------------------------------------------
            string Load_Unk10 = FileName.SetGameOption_LoadFile + FileName.SetGameOption_Unk10 + FileName.Extension;
            if (File.Exists(Load_Unk10))
            {
                string textValue = File.ReadAllText(Load_Unk10);
                Unk10 = byte.Parse(textValue);
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(Load_Unk10, false))
                {
                    streamWriter.Write(Unk10);
                }
            }
            //-------------------------------------------------------------------------
            string Load_Unk11 = FileName.SetGameOption_LoadFile + FileName.SetGameOption_Unk11 + FileName.Extension;
            if (File.Exists(Load_Unk11))
            {
                string textValue = File.ReadAllText(Load_Unk11);
                Unk11 = byte.Parse(textValue);
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(Load_Unk11, false))
                {
                    streamWriter.Write(Unk11);
                }
            }
            //-------------------------------------------------------------------------
            string Load_BGM_Check = FileName.SetGameOption_LoadFile + FileName.SetGameOption_BGM_Check + FileName.Extension;
            if (File.Exists(Load_BGM_Check))
            {
                string textValue = File.ReadAllText(Load_BGM_Check);
                BGM_Check = byte.Parse(textValue);
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(Load_BGM_Check, false))
                {
                    streamWriter.Write(BGM_Check);
                }
            }
            //-------------------------------------------------------------------------
            string Load_Sound_Check = FileName.SetGameOption_LoadFile + FileName.SetGameOption_Sound_Check + FileName.Extension;
            if (File.Exists(Load_Sound_Check))
            {
                string textValue = File.ReadAllText(Load_Sound_Check);
                Sound_Check = byte.Parse(textValue);
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(Load_Sound_Check, false))
                {
                    streamWriter.Write(Sound_Check);
                }
            }
            //-------------------------------------------------------------------------
            string Load_Unk12 = FileName.SetGameOption_LoadFile + FileName.SetGameOption_Unk12 + FileName.Extension;
            if (File.Exists(Load_Unk12))
            {
                string textValue = File.ReadAllText(Load_Unk12);
                Unk12 = byte.Parse(textValue);
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(Load_Unk12, false))
                {
                    streamWriter.Write(Unk12);
                }
            }
            //-------------------------------------------------------------------------
            string Load_Unk13 = FileName.SetGameOption_LoadFile + FileName.SetGameOption_Unk13 + FileName.Extension;
            if (File.Exists(Load_Unk13))
            {
                string textValue = File.ReadAllText(Load_Unk13);
                Unk13 = byte.Parse(textValue);
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(Load_Unk13, false))
                {
                    streamWriter.Write(Unk13);
                }
            }
            //-------------------------------------------------------------------------
            string Load_GameType = FileName.SetGameOption_LoadFile + FileName.SetGameOption_GameType + FileName.Extension;
            if (File.Exists(Load_GameType))
            {
                string textValue = File.ReadAllText(Load_GameType);
                GameType = byte.Parse(textValue);
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(Load_GameType, false))
                {
                    streamWriter.Write(GameType);
                }
            }
            //-------------------------------------------------------------------------
            string Load_SetGhost = FileName.SetGameOption_LoadFile + FileName.SetGameOption_SetGhost + FileName.Extension;
            if (File.Exists(Load_SetGhost))
            {
                string textValue = File.ReadAllText(Load_SetGhost);
                SetGhost = byte.Parse(textValue);
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(Load_SetGhost, false))
                {
                    streamWriter.Write(SetGhost);
                }
            }
            //-------------------------------------------------------------------------
            string Load_SpeedType = FileName.SetGameOption_LoadFile + FileName.SetGameOption_SpeedType + FileName.Extension;
            if (File.Exists(Load_SpeedType))
            {
                string textValue = File.ReadAllText(Load_SpeedType);
                SpeedType = byte.Parse(textValue);
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(Load_SpeedType, false))
                {
                    streamWriter.Write(SpeedType);
                }
            }
            //-------------------------------------------------------------------------
            string Load_Unk14 = FileName.SetGameOption_LoadFile + FileName.SetGameOption_Unk14 + FileName.Extension;
            if (File.Exists(Load_Unk14))
            {
                string textValue = File.ReadAllText(Load_Unk14);
                Unk14 = byte.Parse(textValue);
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(Load_Unk14, false))
                {
                    streamWriter.Write(Unk14);
                }
            }
            //-------------------------------------------------------------------------
            string Load_Unk15 = FileName.SetGameOption_LoadFile + FileName.SetGameOption_Unk15 + FileName.Extension;
            if (File.Exists(Load_Unk15))
            {
                string textValue = File.ReadAllText(Load_Unk15);
                Unk15 = byte.Parse(textValue);
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(Load_Unk15, false))
                {
                    streamWriter.Write(Unk15);
                }
            }
            //-------------------------------------------------------------------------
            string Load_Unk16 = FileName.SetGameOption_LoadFile + FileName.SetGameOption_Unk16 + FileName.Extension;
            if (File.Exists(Load_Unk16))
            {
                string textValue = File.ReadAllText(Load_Unk16);
                Unk16 = byte.Parse(textValue);
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(Load_Unk16, false))
                {
                    streamWriter.Write(Unk16);
                }
            }
            //-------------------------------------------------------------------------
            string Load_Unk17 = FileName.SetGameOption_LoadFile + FileName.SetGameOption_Unk17 + FileName.Extension;
            if (File.Exists(Load_Unk17))
            {
                string textValue = File.ReadAllText(Load_Unk17);
                Unk17 = byte.Parse(textValue);
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(Load_Unk17, false))
                {
                    streamWriter.Write(Unk17);
                }
            }
            //-------------------------------------------------------------------------
            string Load_Set_screen = FileName.SetGameOption_LoadFile + FileName.SetGameOption_Set_screen + FileName.Extension;
            if (File.Exists(Load_Set_screen))
            {
                string textValue = File.ReadAllText(Load_Set_screen);
                Set_screen = byte.Parse(textValue);
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(Load_Set_screen, false))
                {
                    streamWriter.Write(Set_screen);
                }
            }
            //-------------------------------------------------------------------------
            string Load_Unk18 = FileName.SetGameOption_LoadFile + FileName.SetGameOption_Unk18 + FileName.Extension;
            if (File.Exists(Load_Unk18))
            {
                string textValue = File.ReadAllText(Load_Unk18);
                Unk18 = byte.Parse(textValue);
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(Load_Unk18, false))
                {
                    streamWriter.Write(Unk18);
                }
            }
            //-------------------------------------------------------------------------
            string Load_Version = FileName.SetGameOption_LoadFile + FileName.SetGameOption_Version + FileName.Extension;
            if (File.Exists(Load_Version))
            {
                string textValue = File.ReadAllText(Load_Version);
                Version = ushort.Parse(textValue);
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(Load_Version, false))
                {
                    streamWriter.Write(Version);
                }
            }
        }
    }
}

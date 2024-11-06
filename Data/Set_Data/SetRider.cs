using System;
using System.IO;
using KartLauncher.Server;

namespace KartLauncher.Data.Set_Data
{
    public static class SetRider
    {
        public static int ClubCode = 10000;
        public static int ClubMark_LOGO = 0;//343 베로
        public static int ClubMark_LINE = 0;
        public static string ClubName = " KartLauncher.Data.Forms";
        public static string UserID = "Yany";
        public static uint UserNO = 614990519;
        public static string Nickname = "Yany";
        public static string RiderIntro = "";
        public static short Emblem1 = 0;
        public static short Emblem2 = 0;
        public static uint Lucci = 1000000;
        public static int RP = 2000000000;
        public static uint Koin = 10000;
        public static int Premium = 5;//100
        public static byte Ranker = 0;
        public static short SlotChanger = 30000;
        public static uint pmap = 0;//3130 //1068 //2520
        public static byte IdentificationType = 1;

        public static void Save_SetRider()
        {
            using (StreamWriter streamWriter = new StreamWriter(FileName.SetRider_LoadFile + FileName.SetRider_Nickname + FileName.Extension, false))
            {
                streamWriter.Write(Nickname);
            }
            using (StreamWriter streamWriter = new StreamWriter(FileName.SetRider_LoadFile + FileName.SetRider_RiderIntro + FileName.Extension, false))
            {
                streamWriter.Write(RiderIntro);
            }
            using (StreamWriter streamWriter = new StreamWriter(FileName.SetRider_LoadFile + FileName.SetRider_Emblem1 + FileName.Extension, false))
            {
                streamWriter.Write(Emblem1);
            }
            using (StreamWriter streamWriter = new StreamWriter(FileName.SetRider_LoadFile + FileName.SetRider_Emblem2 + FileName.Extension, false))
            {
                streamWriter.Write(Emblem2);
            }
            using (StreamWriter streamWriter = new StreamWriter(FileName.SetRider_LoadFile + FileName.SetRider_Lucci + FileName.Extension, false))
            {
                streamWriter.Write(Lucci);
            }
            using (StreamWriter streamWriter = new StreamWriter(FileName.SetRider_LoadFile + FileName.SetRider_RP + FileName.Extension, false))
            {
                streamWriter.Write(RP);
            }
            using (StreamWriter streamWriter = new StreamWriter(FileName.SetRider_LoadFile + FileName.SetRider_Koin + FileName.Extension, false))
            {
                streamWriter.Write(Koin);
            }
            using (StreamWriter streamWriter = new StreamWriter(FileName.SetRider_LoadFile + FileName.SetRider_Premium + FileName.Extension, false))
            {
                streamWriter.Write(Premium);
            }
            using (StreamWriter streamWriter = new StreamWriter(FileName.SetRider_LoadFile + FileName.SetRider_SlotChanger + FileName.Extension, false))
            {
                streamWriter.Write(SlotChanger);
            }
            using (StreamWriter streamWriter = new StreamWriter(FileName.SetRider_LoadFile + FileName.SetRider_ClubMark_LOGO + FileName.Extension, false))
            {
                streamWriter.Write(ClubMark_LOGO);
            }
            using (StreamWriter streamWriter = new StreamWriter(FileName.SetRider_LoadFile + FileName.SetRider_ClubMark_LINE + FileName.Extension, false))
            {
                streamWriter.Write(ClubMark_LINE);
            }
            using (StreamWriter streamWriter = new StreamWriter(FileName.SetRider_LoadFile + FileName.SetRider_ClubName + FileName.Extension, false))
            {
                streamWriter.Write(ClubName);
            }
        }

        public static void Load_SetRider()
        {
            string Load_Nickname = FileName.SetRider_LoadFile + FileName.SetRider_Nickname + FileName.Extension;
            if (File.Exists(Load_Nickname))
            {
                string textValue = File.ReadAllText(Load_Nickname);
                Nickname = textValue;
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(Load_Nickname, false))
                {
                    streamWriter.Write(Nickname);
                }
            }
            //-------------------------------------------------------------------------
            string Load_RiderIntro = FileName.SetRider_LoadFile + FileName.SetRider_RiderIntro + FileName.Extension;
            if (File.Exists(Load_RiderIntro))
            {
                string textValue = File.ReadAllText(Load_RiderIntro);
                RiderIntro = textValue;
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(Load_RiderIntro, false))
                {
                    streamWriter.Write(RiderIntro);
                }
            }
            //-------------------------------------------------------------------------
            string Load_Emblem1 = FileName.SetRider_LoadFile + FileName.SetRider_Emblem1 + FileName.Extension;
            if (File.Exists(Load_Emblem1))
            {
                string textValue = File.ReadAllText(Load_Emblem1);
                Emblem1 = short.Parse(textValue);
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(Load_Emblem1, false))
                {
                    streamWriter.Write(Emblem1);
                }
            }
            //-------------------------------------------------------------------------
            string Load_Emblem2 = FileName.SetRider_LoadFile + FileName.SetRider_Emblem2 + FileName.Extension;
            if (File.Exists(Load_Emblem2))
            {
                string textValue = File.ReadAllText(Load_Emblem2);
                Emblem2 = short.Parse(textValue);
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(Load_Emblem2, false))
                {
                    streamWriter.Write(Emblem2);
                }
            }
            //-------------------------------------------------------------------------
            string Load_Lucci = FileName.SetRider_LoadFile + FileName.SetRider_Lucci + FileName.Extension;
            if (File.Exists(Load_Lucci))
            {
                string textValue = File.ReadAllText(Load_Lucci);
                Lucci = uint.Parse(textValue);
                if (Lucci > SessionGroup.LucciMax)
                {
                    Lucci = SessionGroup.LucciMax;
                    using (StreamWriter streamWriter = new StreamWriter(Load_Lucci, false))
                    {
                        streamWriter.Write(SessionGroup.LucciMax);
                    }
                }
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(Load_Lucci, false))
                {
                    streamWriter.Write(Lucci);
                }
            }
            //-------------------------------------------------------------------------
            string Load_RP = FileName.SetRider_LoadFile + FileName.SetRider_RP + FileName.Extension;
            if (File.Exists(Load_RP))
            {
                string textValue = File.ReadAllText(Load_RP);
                RP = int.Parse(textValue);
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(Load_RP, false))
                {
                    streamWriter.Write(RP);
                }
            }
            //-------------------------------------------------------------------------
            string Load_Koin = FileName.SetRider_LoadFile + FileName.SetRider_Koin + FileName.Extension;
            if (File.Exists(Load_Koin))
            {
                string textValue = File.ReadAllText(Load_Koin);
                Koin = uint.Parse(textValue);
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(Load_Koin, false))
                {
                    streamWriter.Write(Koin);
                }
            }
            //-------------------------------------------------------------------------
            string Load_Premium = FileName.SetRider_LoadFile + FileName.SetRider_Premium + FileName.Extension;
            if (File.Exists(Load_Premium))
            {
                string textValue = File.ReadAllText(Load_Premium);
                Premium = int.Parse(textValue);
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(Load_Premium, false))
                {
                    streamWriter.Write(Premium);
                }
            }
            //-------------------------------------------------------------------------
            string Load_SlotChanger = FileName.SetRider_LoadFile + FileName.SetRider_SlotChanger + FileName.Extension;
            if (File.Exists(Load_SlotChanger))
            {
                string textValue = File.ReadAllText(Load_SlotChanger);
                SlotChanger = short.Parse(textValue);
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(Load_SlotChanger, false))
                {
                    streamWriter.Write(SlotChanger);
                }
            }
            //-------------------------------------------------------------------------
            string Load_ClubMark_LOGO = FileName.SetRider_LoadFile + FileName.SetRider_ClubMark_LOGO + FileName.Extension;
            if (File.Exists(Load_ClubMark_LOGO))
            {
                string textValue = File.ReadAllText(Load_ClubMark_LOGO);
                ClubMark_LOGO = int.Parse(textValue);
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(Load_ClubMark_LOGO, false))
                {
                    streamWriter.Write(ClubMark_LOGO);
                }
            }
            //-------------------------------------------------------------------------
            string Load_ClubMark_LINE = FileName.SetRider_LoadFile + FileName.SetRider_ClubMark_LINE + FileName.Extension;
            if (File.Exists(Load_ClubMark_LINE))
            {
                string textValue = File.ReadAllText(Load_ClubMark_LINE);
                ClubMark_LINE = int.Parse(textValue);
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(Load_ClubMark_LINE, false))
                {
                    streamWriter.Write(ClubMark_LINE);
                }
            }
            //-------------------------------------------------------------------------
            string Load_ClubName = FileName.SetRider_LoadFile + FileName.SetRider_ClubName + FileName.Extension;
            if (File.Exists(Load_ClubName))
            {
                string textValue = File.ReadAllText(Load_ClubName);
                ClubName = textValue;
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(Load_ClubName, false))
                {
                    streamWriter.Write(ClubName);
                }
            }
        }
    }
}
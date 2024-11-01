using System;
using System.IO;

namespace KartLauncher.Data.Set_Data
{
    public static class Set_ETC
    {
        public static byte DataPack_Use = 0;

        public static void Load_DataPack()
        {
            string Load_DataPack = FileName.config_LoadFile + FileName.SetETC_DataPack + FileName.Extension;
            if (File.Exists(Load_DataPack))
            {
                string textValue = File.ReadAllText(Load_DataPack);
                DataPack_Use = byte.Parse(textValue);
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(Load_DataPack, false))
                {
                    streamWriter.Write(DataPack_Use);
                }
            }
        }

        public static void Load_DataPack2()
        {
            string Load_DataPack = FileName.config_LoadFile + FileName.SetETC_DataPack + FileName.Extension;
            if (File.Exists(Load_DataPack))
            {
                string textValue = File.ReadAllText(Load_DataPack);
                DataPack_Use = byte.Parse(textValue);
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(Load_DataPack, false))
                {
                    streamWriter.Write(DataPack_Use);
                }
            }
        }

        public static void Save_DataPack()
        {
            string LoadFile = FileName.config_LoadFile + FileName.SetETC_DataPack + FileName.Extension;
            using (StreamWriter streamWriter = new StreamWriter(LoadFile, false))
            {
                streamWriter.Write(DataPack_Use);
            }
        }

        public static void Load_ALL()
        {
            Load_DataPack();
        }

        public static void Load_ALL2()
        {
            Load_DataPack2();
        }
    }
}
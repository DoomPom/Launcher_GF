using System;
using System.IO;

namespace KartLauncher.Data.Set_Data
{
    public static class SetMyRoom
    {
        public static short MyRoom = 0;
        public static byte MyRoomBGM = 0;
        public static byte UseRoomPwd = 0;
        public static byte UseItemPwd = 0;
        public static byte TalkLock = 1;
        public static string RoomPwd = "";
        public static string ItemPwd = "";
        public static short MyRoomKart1 = 0;
        public static short MyRoomKart2 = 0;

        public static void Save_SetMyRoom()
        {
            using (StreamWriter streamWriter = new StreamWriter(FileName.SetMyRoom_LoadFile + FileName.SetMyRoom_MyRoom + FileName.Extension, false))
            {
                streamWriter.Write(MyRoom);
            }
            using (StreamWriter streamWriter = new StreamWriter(FileName.SetMyRoom_LoadFile + FileName.SetMyRoom_MyRoomBGM + FileName.Extension, false))
            {
                streamWriter.Write(MyRoomBGM);
            }
            using (StreamWriter streamWriter = new StreamWriter(FileName.SetMyRoom_LoadFile + FileName.SetMyRoom_UseRoomPwd + FileName.Extension, false))
            {
                streamWriter.Write(UseRoomPwd);
            }
            using (StreamWriter streamWriter = new StreamWriter(FileName.SetMyRoom_LoadFile + FileName.SetMyRoom_UseItemPwd + FileName.Extension, false))
            {
                streamWriter.Write(UseItemPwd);
            }
            using (StreamWriter streamWriter = new StreamWriter(FileName.SetMyRoom_LoadFile + FileName.SetMyRoom_TalkLock + FileName.Extension, false))
            {
                streamWriter.Write(TalkLock);
            }
            using (StreamWriter streamWriter = new StreamWriter(FileName.SetMyRoom_LoadFile + FileName.SetMyRoom_RoomPwd + FileName.Extension, false))
            {
                streamWriter.Write(RoomPwd);
            }
            using (StreamWriter streamWriter = new StreamWriter(FileName.SetMyRoom_LoadFile + FileName.SetMyRoom_ItemPwd + FileName.Extension, false))
            {
                streamWriter.Write(ItemPwd);
            }
            using (StreamWriter streamWriter = new StreamWriter(FileName.SetMyRoom_LoadFile + FileName.SetMyRoom_MyRoomKart1 + FileName.Extension, false))
            {
                streamWriter.Write(MyRoomKart1);
            }
            using (StreamWriter streamWriter = new StreamWriter(FileName.SetMyRoom_LoadFile + FileName.SetMyRoom_MyRoomKart2 + FileName.Extension, false))
            {
                streamWriter.Write(MyRoomKart2);
            }
        }

        public static void Load_SetMyRoom()
        {
            string Load_MyRoom = FileName.SetMyRoom_LoadFile + FileName.SetMyRoom_MyRoom + FileName.Extension;
            if (File.Exists(Load_MyRoom))
            {
                string textValue = File.ReadAllText(Load_MyRoom);
                MyRoom = short.Parse(textValue);
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(Load_MyRoom, false))
                {
                    streamWriter.Write(MyRoom);
                }
            }
            //-------------------------------------------------------------------------
            string Load_MyRoomBGM = FileName.SetMyRoom_LoadFile + FileName.SetMyRoom_MyRoomBGM + FileName.Extension;
            if (File.Exists(Load_MyRoomBGM))
            {
                string textValue = File.ReadAllText(Load_MyRoomBGM);
                MyRoomBGM = byte.Parse(textValue);
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(Load_MyRoomBGM, false))
                {
                    streamWriter.Write(MyRoomBGM);
                }
            }
            //-------------------------------------------------------------------------
            string Load_UseRoomPwd = FileName.SetMyRoom_LoadFile + FileName.SetMyRoom_UseRoomPwd + FileName.Extension;
            if (File.Exists(Load_UseRoomPwd))
            {
                string textValue = File.ReadAllText(Load_UseRoomPwd);
                UseRoomPwd = byte.Parse(textValue);
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(Load_UseRoomPwd, false))
                {
                    streamWriter.Write(UseRoomPwd);
                }
            }
            //-------------------------------------------------------------------------
            string Load_UseItemPwd = FileName.SetMyRoom_LoadFile + FileName.SetMyRoom_UseItemPwd + FileName.Extension;
            if (File.Exists(Load_UseItemPwd))
            {
                string textValue = File.ReadAllText(Load_UseItemPwd);
                UseItemPwd = byte.Parse(textValue);
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(Load_UseItemPwd, false))
                {
                    streamWriter.Write(UseItemPwd);
                }
            }
            //-------------------------------------------------------------------------
            string Load_TalkLock = FileName.SetMyRoom_LoadFile + FileName.SetMyRoom_TalkLock + FileName.Extension;
            if (File.Exists(Load_TalkLock))
            {
                string textValue = File.ReadAllText(Load_TalkLock);
                TalkLock = byte.Parse(textValue);
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(Load_TalkLock, false))
                {
                    streamWriter.Write(TalkLock);
                }
            }
            //-------------------------------------------------------------------------
            string Load_RoomPwd = FileName.SetMyRoom_LoadFile + FileName.SetMyRoom_RoomPwd + FileName.Extension;
            if (File.Exists(Load_RoomPwd))
            {
                string textValue = File.ReadAllText(Load_RoomPwd);
                RoomPwd = textValue;
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(Load_RoomPwd, false))
                {
                    streamWriter.Write(RoomPwd);
                }
            }
            //-------------------------------------------------------------------------
            string Load_ItemPwd = FileName.SetMyRoom_LoadFile + FileName.SetMyRoom_ItemPwd + FileName.Extension;
            if (File.Exists(Load_ItemPwd))
            {
                string textValue = File.ReadAllText(Load_ItemPwd);
                ItemPwd = textValue;
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(Load_ItemPwd, false))
                {
                    streamWriter.Write(ItemPwd);
                }
            }
            //-------------------------------------------------------------------------
            string Load_MyRoomKart1 = FileName.SetMyRoom_LoadFile + FileName.SetMyRoom_MyRoomKart1 + FileName.Extension;
            if (File.Exists(Load_MyRoomKart1))
            {
                string textValue = File.ReadAllText(Load_MyRoomKart1);
                MyRoomKart1 = short.Parse(textValue);
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(Load_MyRoomKart1, false))
                {
                    streamWriter.Write(MyRoomKart1);
                }
            }
            //-------------------------------------------------------------------------
            string Load_MyRoomKart2 = FileName.SetMyRoom_LoadFile + FileName.SetMyRoom_MyRoomKart2 + FileName.Extension;
            if (File.Exists(Load_MyRoomKart2))
            {
                string textValue = File.ReadAllText(Load_MyRoomKart2);
                MyRoomKart2 = short.Parse(textValue);
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(Load_MyRoomKart2, false))
                {
                    streamWriter.Write(MyRoomKart2);
                }
            }
        }
    }
}
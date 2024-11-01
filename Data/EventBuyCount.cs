using System;
using KartLauncher.Common.KartRider.IO;
using KartLauncher.Data.Server;

namespace KartLauncher.Data
{
    public static class EventBuyCount
    {
        public static int BuyCount = 0;
        public static int ShopItem1 = 0;
        public static int ShopItem2 = 0;
        public static int ShopItem3 = 0;
        public static int ShopItem4 = 0;
        public static int ShopItem5 = 0;
        public static int ShopItem6 = 0;
        public static int ShopItem7 = 0;
        public static int ShopItem8 = 0;
        public static int ShopItem9 = 0;
        public static int ShopItem10 = 0;
        public static int ShopItem11 = 0;
        public static int ShopItem12 = 0;
        public static int ShopItem13 = 0;
        public static int ShopItem14 = 0;
        public static int ShopItem15 = 0;
        public static int ShopItem16 = 0;
        public static int ShopItem17 = 0;
        public static int ShopItem18 = 0;
        public static int ShopItem19 = 0;
        public static int ShopItem20 = 0;

        public static void PrEventBuyCount()
        {
            using (OutPacket outPacket = new OutPacket("PrEventBuyCount"))
            {
                outPacket.WriteInt(BuyCount);
                if (BuyCount >= 1)
                {
                    outPacket.WriteInt(ShopItem1);
                    outPacket.WriteInt(0);
                }
                if (BuyCount >= 2)
                {
                    outPacket.WriteInt(ShopItem2);
                    outPacket.WriteInt(0);
                }
                if (BuyCount >= 3)
                {
                    outPacket.WriteInt(ShopItem3);
                    outPacket.WriteInt(0);
                }
                if (BuyCount >= 4)
                {
                    outPacket.WriteInt(ShopItem4);
                    outPacket.WriteInt(0);
                }
                if (BuyCount >= 5)
                {
                    outPacket.WriteInt(ShopItem5);
                    outPacket.WriteInt(0);
                }
                if (BuyCount >= 6)
                {
                    outPacket.WriteInt(ShopItem6);
                    outPacket.WriteInt(0);
                }
                if (BuyCount >= 7)
                {
                    outPacket.WriteInt(ShopItem7);
                    outPacket.WriteInt(0);
                }
                if (BuyCount >= 8)
                {
                    outPacket.WriteInt(ShopItem8);
                    outPacket.WriteInt(0);
                }
                if (BuyCount >= 9)
                {
                    outPacket.WriteInt(ShopItem9);
                    outPacket.WriteInt(0);
                }
                if (BuyCount >= 10)
                {
                    outPacket.WriteInt(ShopItem10);
                    outPacket.WriteInt(0);
                }
                if (BuyCount >= 11)
                {
                    outPacket.WriteInt(ShopItem11);
                    outPacket.WriteInt(0);
                }
                if (BuyCount >= 12)
                {
                    outPacket.WriteInt(ShopItem12);
                    outPacket.WriteInt(0);
                }
                if (BuyCount >= 13)
                {
                    outPacket.WriteInt(ShopItem13);
                    outPacket.WriteInt(0);
                }
                if (BuyCount >= 14)
                {
                    outPacket.WriteInt(ShopItem14);
                    outPacket.WriteInt(0);
                }
                if (BuyCount >= 15)
                {
                    outPacket.WriteInt(ShopItem15);
                    outPacket.WriteInt(0);
                }
                if (BuyCount >= 16)
                {
                    outPacket.WriteInt(ShopItem16);
                    outPacket.WriteInt(0);
                }
                if (BuyCount >= 17)
                {
                    outPacket.WriteInt(ShopItem17);
                    outPacket.WriteInt(0);
                }
                if (BuyCount >= 18)
                {
                    outPacket.WriteInt(ShopItem18);
                    outPacket.WriteInt(0);
                }
                if (BuyCount >= 19)
                {
                    outPacket.WriteInt(ShopItem19);
                    outPacket.WriteInt(0);
                }
                if (BuyCount >= 20)
                {
                    outPacket.WriteInt(ShopItem20);
                    outPacket.WriteInt(0);
                }
                RouterListener.MySession.Client.Send(outPacket);
            }
        }
    }
}
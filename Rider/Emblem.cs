﻿using System;
using System.Xml;
using KartLauncher.Common.IO;
using KartLauncher.Server;

namespace KartLauncher.Rider
{
    public static class Emblem
    {
        public static void RmOwnerEmblemPacket()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"Profile\Item.xml");
            if (!(doc.GetElementsByTagName("emblem") == null))
            {
                XmlNodeList lis = doc.GetElementsByTagName("emblem");
                int All_Emblem = lis.Count;
                using (OutPacket outPacket = new OutPacket("RmOwnerEmblemPacket"))
                {
                    outPacket.WriteInt(1);
                    outPacket.WriteInt(1);
                    outPacket.WriteInt(All_Emblem);
                    foreach (XmlNode xn in lis)
                    {
                        XmlElement xe = (XmlElement)xn;
                        short i = short.Parse(xe.GetAttribute("id"));
                        outPacket.WriteShort(i);
                    }
                    RouterListener.MySession.Client.Send(outPacket);
                }
            }
        }
    }
}
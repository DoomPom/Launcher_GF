using System;
using System.Xml;
using KartLauncher.Common.Common.Utilities;
using KartLauncher.ExcData;
using KartLauncher.KartSpec;

namespace KartLauncher.Data
{
    public class RandomTrack
    {
        public static string GameType = "item";
        public static string SetRandomTrack = "allRandom";
        public static string GameTrack = "forest_I01";

        public static void SetGameType()
        {
            if (StartGameData.StartTimeAttack_RandomTrackGameType == 0)
            {
                GameType = "speed";
            }
            else if (StartGameData.StartTimeAttack_RandomTrackGameType == 1)
            {
                GameType = "item";
            }
            SetRandomType();
        }

        public static void SetRandomType()
        {
            if (StartGameData.StartTimeAttack_Track == 0)
            {
                SetRandomTrack = "allRandom";
            }
            else if (StartGameData.StartTimeAttack_Track == 1)
            {
                SetRandomTrack = "leagueRandom";
            }
            else if (StartGameData.StartTimeAttack_Track == 3)
            {
                SetRandomTrack = "hot1Random";
            }
            else if (StartGameData.StartTimeAttack_Track == 4)
            {
                SetRandomTrack = "hot2Random";
            }
            else if (StartGameData.StartTimeAttack_Track == 5)
            {
                SetRandomTrack = "hot3Random";
            }
            else if (StartGameData.StartTimeAttack_Track == 6)
            {
                SetRandomTrack = "hot4Random";
            }
            else if (StartGameData.StartTimeAttack_Track == 7)
            {
                SetRandomTrack = "hot5Random";
            }
            else if (StartGameData.StartTimeAttack_Track == 8)
            {
                SetRandomTrack = "newRandom";
            }
            else if (StartGameData.StartTimeAttack_Track == 30)
            {
                SetRandomTrack = "reverseRandom";
            }
            else if (StartGameData.StartTimeAttack_Track == 40)
            {
                SetRandomTrack = "speedAllRandom";
            }
            else
            {
                SetRandomTrack = "Unknown";
            }
            RandomTrackSetList();
        }

        public static void RandomTrackSetList()
        {
            Random random = new Random();
            if (SetRandomTrack == "allRandom")
            {
                if (GameType == "item")
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(@"Profile\RandomTrack.xml");
                    XmlNodeList lis = doc.GetElementsByTagName("allitem");
                    int track = random.Next(0, lis.Count);
                    XmlNode xn = lis[track];
                    XmlElement xe = (XmlElement)xn;
                    GameTrack = xe.GetAttribute("Track");
                }
                else if (GameType == "speed")
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(@"Profile\RandomTrack.xml");
                    XmlNodeList lis = doc.GetElementsByTagName("allspeed");
                    int track = random.Next(0, lis.Count);
                    XmlNode xn = lis[track];
                    XmlElement xe = (XmlElement)xn;
                    GameTrack = xe.GetAttribute("Track");
                }
            }
            else if (SetRandomTrack == "leagueRandom")
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(@"Profile\RandomTrack.xml");
                XmlNodeList lis = doc.GetElementsByTagName("league");
                int track = random.Next(0, lis.Count);
                XmlNode xn = lis[track];
                XmlElement xe = (XmlElement)xn;
                GameTrack = xe.GetAttribute("Track");
            }
            else if (SetRandomTrack == "hot1Random")
            {
                if (GameType == "item")
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(@"Profile\RandomTrack.xml");
                    XmlNodeList lis = doc.GetElementsByTagName("hot1item");
                    int track = random.Next(0, lis.Count);
                    XmlNode xn = lis[track];
                    XmlElement xe = (XmlElement)xn;
                    GameTrack = xe.GetAttribute("Track");

                }
                else if (GameType == "speed")
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(@"Profile\RandomTrack.xml");
                    XmlNodeList lis = doc.GetElementsByTagName("hot1speed");
                    int track = random.Next(0, lis.Count);
                    XmlNode xn = lis[track];
                    XmlElement xe = (XmlElement)xn;
                    GameTrack = xe.GetAttribute("Track");
                }
            }
            else if (SetRandomTrack == "hot2Random")
            {
                if (GameType == "item")
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(@"Profile\RandomTrack.xml");
                    XmlNodeList lis = doc.GetElementsByTagName("hot2item");
                    int track = random.Next(0, lis.Count);
                    XmlNode xn = lis[track];
                    XmlElement xe = (XmlElement)xn;
                    GameTrack = xe.GetAttribute("Track");
                }
                else if (GameType == "speed")
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(@"Profile\RandomTrack.xml");
                    XmlNodeList lis = doc.GetElementsByTagName("hot2speed");
                    int track = random.Next(0, lis.Count);
                    XmlNode xn = lis[track];
                    XmlElement xe = (XmlElement)xn;
                    GameTrack = xe.GetAttribute("Track");
                }
            }
            else if (SetRandomTrack == "hot3Random")
            {
                if (GameType == "item")
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(@"Profile\RandomTrack.xml");
                    XmlNodeList lis = doc.GetElementsByTagName("hot3item");
                    int track = random.Next(0, lis.Count);
                    XmlNode xn = lis[track];
                    XmlElement xe = (XmlElement)xn;
                    GameTrack = xe.GetAttribute("Track");
                }
                else if (GameType == "speed")
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(@"Profile\RandomTrack.xml");
                    XmlNodeList lis = doc.GetElementsByTagName("hot3speed");
                    int track = random.Next(0, lis.Count);
                    XmlNode xn = lis[track];
                    XmlElement xe = (XmlElement)xn;
                    GameTrack = xe.GetAttribute("Track");
                }
            }
            else if (SetRandomTrack == "hot4Random")
            {
                if (GameType == "item")
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(@"Profile\RandomTrack.xml");
                    XmlNodeList lis = doc.GetElementsByTagName("hot4item");
                    int track = random.Next(0, lis.Count);
                    XmlNode xn = lis[track];
                    XmlElement xe = (XmlElement)xn;
                    GameTrack = xe.GetAttribute("Track");
                }
                else if (GameType == "speed")
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(@"Profile\RandomTrack.xml");
                    XmlNodeList lis = doc.GetElementsByTagName("hot4speed");
                    int track = random.Next(0, lis.Count);
                    XmlNode xn = lis[track];
                    XmlElement xe = (XmlElement)xn;
                    GameTrack = xe.GetAttribute("Track");
                }
            }
            else if (SetRandomTrack == "hot5Random")
            {
                if (GameType == "item")
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(@"Profile\RandomTrack.xml");
                    XmlNodeList lis = doc.GetElementsByTagName("hot5item");
                    int track = random.Next(0, lis.Count);
                    XmlNode xn = lis[track];
                    XmlElement xe = (XmlElement)xn;
                    GameTrack = xe.GetAttribute("Track");
                }
                else if (GameType == "speed")
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(@"Profile\RandomTrack.xml");
                    XmlNodeList lis = doc.GetElementsByTagName("hot5speed");
                    int track = random.Next(0, lis.Count);
                    XmlNode xn = lis[track];
                    XmlElement xe = (XmlElement)xn;
                    GameTrack = xe.GetAttribute("Track");
                }
            }
            else if (SetRandomTrack == "newRandom")
            {
                if (GameType == "item")
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(@"Profile\RandomTrack.xml");
                    XmlNodeList lis = doc.GetElementsByTagName("newitem");
                    int track = random.Next(0, lis.Count);
                    XmlNode xn = lis[track];
                    XmlElement xe = (XmlElement)xn;
                    GameTrack = xe.GetAttribute("Track");
                }
                else if (GameType == "speed")
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(@"Profile\RandomTrack.xml");
                    XmlNodeList lis = doc.GetElementsByTagName("newspeed");
                    int track = random.Next(0, lis.Count);
                    XmlNode xn = lis[track];
                    XmlElement xe = (XmlElement)xn;
                    GameTrack = xe.GetAttribute("Track");
                }
            }
            else if (SetRandomTrack == "reverseRandom")
            {
                if (GameType == "item")
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(@"Profile\RandomTrack.xml");
                    XmlNodeList lis = doc.GetElementsByTagName("reverseitem");
                    int track = random.Next(0, lis.Count);
                    XmlNode xn = lis[track];
                    XmlElement xe = (XmlElement)xn;
                    GameTrack = xe.GetAttribute("Track");
                }
                else if (GameType == "speed")
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(@"Profile\RandomTrack.xml");
                    XmlNodeList lis = doc.GetElementsByTagName("reversespeed");
                    int track = random.Next(0, lis.Count);
                    XmlNode xn = lis[track];
                    XmlElement xe = (XmlElement)xn;
                    GameTrack = xe.GetAttribute("Track");
                }
            }
            else if (SetRandomTrack == "speedAllRandom")
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(@"Profile\RandomTrack.xml");
                XmlNodeList lis = doc.GetElementsByTagName("speedAll");
                int track = random.Next(0, lis.Count);
                XmlNode xn = lis[track];
                XmlElement xe = (XmlElement)xn;
                GameTrack = xe.GetAttribute("Track");
            }
            if (SetRandomTrack != "Unknown")
            {
                StartGameData.StartTimeAttack_Track = Adler32Helper.GenerateAdler32_UNICODE(GameTrack, 0);
                Console.WriteLine("RandomTrack: {0} / {1} / {2}", GameType, SetRandomTrack, GameTrack);
            }
            SpeedType.SpeedTypeData();
        }
    }
}
using System;
using System.Xml;

namespace KartLauncher.Data.KartSpec
{
    public class FlyingPet
    {
        public static float DragFactor;
        public static float ForwardAccelForce;
        public static float DriftEscapeForce;
        public static float CornerDrawFactor;
        public static float NormalBoosterTime;
        public static float ItemBoosterTime;
        public static float TeamBoosterTime;
        public static float StartForwardAccelForceItem;
        public static float StartForwardAccelForceSpeed;

        public static void FlyingPet_Spec()
        {
            if (StartGameData.FlyingPet_id == 0)
            {
                DragFactor = 0f;
                ForwardAccelForce = 0f;
                DriftEscapeForce = 0f;
                CornerDrawFactor = 0f;
                NormalBoosterTime = 0f;
                ItemBoosterTime = 0f;
                TeamBoosterTime = 0f;
                StartForwardAccelForceItem = 0f;
                StartForwardAccelForceSpeed = 0f;
            }
            else
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(@"Profile\FlyingPetSpec.xml");
                if (!(doc.GetElementsByTagName("id" + StartGameData.FlyingPet_id.ToString()) == null))
                {
                    XmlNodeList lis = doc.GetElementsByTagName("id" + StartGameData.FlyingPet_id.ToString());
                    foreach (XmlNode xn in lis)
                    {
                        XmlElement xe = (XmlElement)xn;
                        DragFactor = float.Parse(xe.GetAttribute("DragFactor"));
                        ForwardAccelForce = float.Parse(xe.GetAttribute("ForwardAccelForce"));
                        DriftEscapeForce = float.Parse(xe.GetAttribute("DriftEscapeForce"));
                        CornerDrawFactor = float.Parse(xe.GetAttribute("CornerDrawFactor"));
                        NormalBoosterTime = float.Parse(xe.GetAttribute("NormalBoosterTime"));
                        ItemBoosterTime = float.Parse(xe.GetAttribute("ItemBoosterTime"));
                        TeamBoosterTime = float.Parse(xe.GetAttribute("TeamBoosterTime"));
                        StartForwardAccelForceItem = float.Parse(xe.GetAttribute("StartForwardAccelForceItem"));
                        StartForwardAccelForceSpeed = float.Parse(xe.GetAttribute("StartForwardAccelForceSpeed"));
                    }
                }
                else
                {
                    DragFactor = 0f;
                    ForwardAccelForce = 0f;
                    DriftEscapeForce = 0f;
                    CornerDrawFactor = 0f;
                    NormalBoosterTime = 0f;
                    ItemBoosterTime = 0f;
                    TeamBoosterTime = 0f;
                    StartForwardAccelForceItem = 0f;
                    StartForwardAccelForceSpeed = 0f;
                }
            }
            Kart_Spec.KartAll();
        }
    }
}
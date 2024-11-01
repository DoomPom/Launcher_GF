using System;
using System.Linq;

namespace KartLauncher.Data.ExcData
{
    public class TuneSpec
    {
        public static float Tune_DragFactor = 0f;
        public static float Tune_ForwardAccel = 0f;
        public static float Tune_CornerDrawFactor = 0f;
        public static float Tune_TeamBoosterTime = 0f;
        public static float Tune_NormalBoosterTime = 0f;
        public static float Tune_StartBoosterTimeSpeed = 0f;
        public static float Tune_TransAccelFactor = 0f;
        public static float Tune_DriftMaxGauge = 0f;
        public static float Tune_DriftEscapeForce = 0f;

        public static float Plant43_TransAccelFactor = 0f;
        public static float Plant43_DragFactor = 0f;
        public static float Plant43_StartForwardAccelSpeed = 0f;
        public static float Plant43_ForwardAccel = 0f;
        public static float Plant43_StartBoosterTimeSpeed = 0f;

        public static float Plant44_SlipBrake = 0f;
        public static float Plant44_GripBrake = 0f;
        public static float Plant44_RearGripFactor = 0f;
        public static float Plant44_FrontGripFactor = 0f;
        public static float Plant44_CornerDrawFactor = 0f;
        public static float Plant44_SteerConstraint = 0f;

        public static float Plant45_DriftEscapeForce = 0f;
        public static float Plant45_DriftMaxGauge = 0f;
        public static float Plant45_CornerDrawFactor = 0f;
        public static float Plant45_SlipBrake = 0f;
        public static float Plant45_AnimalBoosterTime = 0f;
        public static float Plant45_AntiCollideBalance = 0f;
        public static float Plant45_DragFactor = 0f;

        public static float Plant46_DriftMaxGauge = 0f;
        public static float Plant46_NormalBoosterTime = 0f;
        public static float Plant46_DriftSlipFactor = 0f;
        public static float Plant46_ForwardAccel = 0f;
        public static float Plant46_AnimalBoosterTime = 0f;
        public static float Plant46_TeamBoosterTime = 0f;
        public static float Plant46_StartForwardAccelSpeed = 0f;
        public static float Plant46_StartForwardAccelItem = 0f;
        public static float Plant46_StartBoosterTimeSpeed = 0f;
        public static float Plant46_StartBoosterTimeItem = 0f;
        public static byte Plant46_ItemSlotCapacity = 0;
        public static byte Plant46_SpeedSlotCapacity = 0;
        public static float Plant46_GripBrake = 0f;
        public static float Plant46_SlipBrake = 0f;

        public static float KartLevel_DragFactor = 0f;
        public static float KartLevel_ForwardAccel = 0f;
        public static float KartLevel_CornerDrawFactor = 0f;
        public static float KartLevel_SteerConstraint = 0f;
        public static float KartLevel_DriftEscapeForce = 0f;
        public static float KartLevel_TransAccelFactor = 0f;
        public static float KartLevel_StartBoosterTimeSpeed = 0f;
        public static float KartLevel_StartBoosterTimeItem = 0f;
        public static float KartLevel_BoostAccelFactorOnlyItem = 0f;

        public static float PartSpec_TransAccelFactor = 0f; //엔진
        public static float PartSpec_SteerConstraint = 0f; //핸들
        public static float PartSpec_DriftEscapeForce = 0f; //바퀴
        public static float PartSpec_NormalBoosterTime = 0f; //부스터

        public static void Reset_PartSpec_SpecData()
        {
            PartSpec_TransAccelFactor = 0f;
            PartSpec_SteerConstraint = 0f;
            PartSpec_DriftEscapeForce = 0f;
            PartSpec_NormalBoosterTime = 0f;
            Console.WriteLine("Part_Spec: OFF");
        }

        public static void Reset_Tune_SpecData()
        {
            Tune_DragFactor = 0f;
            Tune_ForwardAccel = 0f;
            Tune_CornerDrawFactor = 0f;
            Tune_TeamBoosterTime = 0f;
            Tune_NormalBoosterTime = 0f;
            Tune_StartBoosterTimeSpeed = 0f;
            Tune_TransAccelFactor = 0f;
            Tune_DriftMaxGauge = 0f;
            Tune_DriftEscapeForce = 0f;
            Console.WriteLine("Tune_Type: OFF");
        }

        public static void Reset_Plant_SpecData()
        {
            Plant43_TransAccelFactor = 0f;
            Plant43_DragFactor = 0f;
            Plant43_StartForwardAccelSpeed = 0f;
            Plant43_ForwardAccel = 0f;
            Plant43_StartBoosterTimeSpeed = 0f;

            Plant44_SlipBrake = 0f;
            Plant44_GripBrake = 0f;
            Plant44_RearGripFactor = 0f;
            Plant44_FrontGripFactor = 0f;
            Plant44_CornerDrawFactor = 0f;
            Plant44_SteerConstraint = 0f;

            Plant45_DriftEscapeForce = 0f;
            Plant45_DriftMaxGauge = 0f;
            Plant45_CornerDrawFactor = 0f;
            Plant45_SlipBrake = 0f;
            Plant45_AnimalBoosterTime = 0f;
            Plant45_AntiCollideBalance = 0f;
            Plant45_DragFactor = 0f;

            Plant46_DriftMaxGauge = 0f;
            Plant46_NormalBoosterTime = 0f;
            Plant46_DriftSlipFactor = 0f;
            Plant46_ForwardAccel = 0f;
            Plant46_AnimalBoosterTime = 0f;
            Plant46_TeamBoosterTime = 0f;
            Plant46_StartForwardAccelSpeed = 0f;
            Plant46_StartForwardAccelItem = 0f;
            Plant46_StartBoosterTimeSpeed = 0f;
            Plant46_StartBoosterTimeItem = 0f;
            Plant46_ItemSlotCapacity = 0;
            Plant46_SpeedSlotCapacity = 0;
            Plant46_GripBrake = 0f;
            Plant46_SlipBrake = 0f;
            Console.WriteLine("Plant_Spec: OFF");
        }

        public static void Reset_KartLevel_SpecData()
        {
            KartLevel_DragFactor = 0f;
            KartLevel_ForwardAccel = 0f;
            KartLevel_CornerDrawFactor = 0f;
            KartLevel_SteerConstraint = 0f;
            KartLevel_DriftEscapeForce = 0f;
            KartLevel_TransAccelFactor = 0f;
            KartLevel_StartBoosterTimeSpeed = 0f;
            KartLevel_StartBoosterTimeItem = 0f;
            KartLevel_BoostAccelFactorOnlyItem = 0f;
            Console.WriteLine("Level_Spec: OFF");
        }

        public static void Use_TuneSpec(short Set_Kart, short Set_KartSN)
        {
            var kartAndSN = new { Kart = Set_Kart, SN = Set_KartSN };
            var tuneList = KartExcData.TuneList;
            var existingTune = tuneList.FirstOrDefault(list => list[0] == kartAndSN.Kart && list[1] == kartAndSN.SN);
            if (existingTune != null)
            {
                if (existingTune[2] == 103 || existingTune[3] == 103 || existingTune[4] == 103)
                {
                    Tune_DragFactor = -0.0022f;
                }
                else if (existingTune[2] == 203 || existingTune[3] == 203 || existingTune[4] == 203)
                {
                    Tune_ForwardAccel = 3.5f;
                }
                else if (existingTune[2] == 303 || existingTune[3] == 303 || existingTune[4] == 303)
                {
                    Tune_CornerDrawFactor = 0.0020f;
                }
                else if (existingTune[2] == 403 || existingTune[3] == 403 || existingTune[4] == 403)
                {
                    Tune_TeamBoosterTime = 250f;
                }
                else if (existingTune[2] == 503 || existingTune[3] == 503 || existingTune[4] == 503)
                {
                    Tune_NormalBoosterTime = 190f;
                }
                else if (existingTune[2] == 603 || existingTune[3] == 603 || existingTune[4] == 603)
                {
                    Tune_StartBoosterTimeSpeed = 800f;
                }
                else if (existingTune[2] == 703 || existingTune[3] == 703 || existingTune[4] == 703)
                {
                    Tune_TransAccelFactor = 0.018f;
                }
                else if (existingTune[2] == 803 || existingTune[3] == 803 || existingTune[4] == 803)
                {
                    Tune_DriftMaxGauge = -200f;
                }
                else if (existingTune[2] == 903 || existingTune[3] == 903 || existingTune[4] == 903)
                {
                    Tune_DriftEscapeForce = 210f;
                }
            }
            else
            {
                Reset_Tune_SpecData();
            }
        }

        public static void Use_PlantSpec(short Set_Kart, short Set_KartSN)
        {
            var kartAndSN = new { Kart = Set_Kart, SN = Set_KartSN };
            var plantList = KartExcData.PlantList;
            var existingPlant = plantList.FirstOrDefault(list => list[0] == kartAndSN.Kart && list[1] == kartAndSN.SN);
            if (existingPlant != null)
            {
                if (existingPlant[2] == 43)
                {
                    if (existingPlant[3] == 1)
                    {
                        Plant43_TransAccelFactor = 0.02f;
                        Plant43_DragFactor = -0.0007f;
                        Plant43_StartForwardAccelSpeed = 0.02f;
                        Plant43_ForwardAccel = 0f;
                        Plant43_StartBoosterTimeSpeed = 0f;
                    }
                    else if (existingPlant[3] == 2)
                    {
                        Plant43_TransAccelFactor = 0.02f;
                        Plant43_DragFactor = 0f;
                        Plant43_StartForwardAccelSpeed = 0f;
                        Plant43_ForwardAccel = 2f;
                        Plant43_StartBoosterTimeSpeed = 0f;
                    }
                    else if (existingPlant[3] == 3)
                    {
                        Plant43_TransAccelFactor = 0f;
                        Plant43_DragFactor = 0f;
                        Plant43_StartForwardAccelSpeed = 0.02f;
                        Plant43_ForwardAccel = 0f;
                        Plant43_StartBoosterTimeSpeed = 15f;
                    }
                    else if (existingPlant[3] == 4 || existingPlant[3] == 5)
                    {
                        Plant43_TransAccelFactor = 0f;
                        Plant43_DragFactor = 0f;
                        Plant43_StartForwardAccelSpeed = 0.04f;
                        Plant43_ForwardAccel = 0f;
                        Plant43_StartBoosterTimeSpeed = 0f;
                    }
                    else if (existingPlant[3] == 6)
                    {
                        Plant43_TransAccelFactor = 0f;
                        Plant43_DragFactor = -0.0021f;
                        Plant43_StartForwardAccelSpeed = 0f;
                        Plant43_ForwardAccel = 0f;
                        Plant43_StartBoosterTimeSpeed = 0f;
                    }
                    else if (existingPlant[3] == 7)
                    {
                        Plant43_TransAccelFactor = 0f;
                        Plant43_DragFactor = -0.0014f;
                        Plant43_StartForwardAccelSpeed = 0f;
                        Plant43_ForwardAccel = 0f;
                        Plant43_StartBoosterTimeSpeed = 0f;
                    }
                    else if (existingPlant[3] == 8)
                    {
                        Plant43_TransAccelFactor = 0f;
                        Plant43_DragFactor = 0f;
                        Plant43_StartForwardAccelSpeed = 0.02f;
                        Plant43_ForwardAccel = 1f;
                        Plant43_StartBoosterTimeSpeed = 0f;
                    }
                    else if (existingPlant[3] == 9)
                    {
                        Plant43_TransAccelFactor = 0f;
                        Plant43_DragFactor = 0f;
                        Plant43_StartForwardAccelSpeed = 0.02f;
                        Plant43_ForwardAccel = 1f;
                        Plant43_StartBoosterTimeSpeed = 0f;
                    }
                    else if (existingPlant[3] == 10)
                    {
                        Plant43_TransAccelFactor = 0f;
                        Plant43_DragFactor = 0f;
                        Plant43_StartForwardAccelSpeed = 0f;
                        Plant43_ForwardAccel = 2f;
                        Plant43_StartBoosterTimeSpeed = 0f;
                    }
                    else if (existingPlant[3] == 11)
                    {
                        Plant43_TransAccelFactor = 0f;
                        Plant43_DragFactor = 0f;
                        Plant43_StartForwardAccelSpeed = 0f;
                        Plant43_ForwardAccel = 2f;
                        Plant43_StartBoosterTimeSpeed = 0f;
                    }
                    else if (existingPlant[3] == 12)
                    {
                        Plant43_TransAccelFactor = 0f;
                        Plant43_DragFactor = -0.0007f;
                        Plant43_StartForwardAccelSpeed = 0f;
                        Plant43_ForwardAccel = 1f;
                        Plant43_StartBoosterTimeSpeed = 0f;
                    }
                    else if (existingPlant[3] == 13)
                    {
                        Plant43_TransAccelFactor = 0f;
                        Plant43_DragFactor = -0.0007f;
                        Plant43_StartForwardAccelSpeed = 0f;
                        Plant43_ForwardAccel = 1f;
                        Plant43_StartBoosterTimeSpeed = 0f;
                    }
                    else if (existingPlant[3] == 14)
                    {
                        Plant43_TransAccelFactor = 0f;
                        Plant43_DragFactor = -0.0007f;
                        Plant43_StartForwardAccelSpeed = 0f;
                        Plant43_ForwardAccel = 0f;
                        Plant43_StartBoosterTimeSpeed = 0f;
                    }
                    else if (existingPlant[3] == 15)
                    {
                        Plant43_TransAccelFactor = 0f;
                        Plant43_DragFactor = -0.0014f;
                        Plant43_StartForwardAccelSpeed = 0f;
                        Plant43_ForwardAccel = 0f;
                        Plant43_StartBoosterTimeSpeed = 0f;
                    }
                    else if (existingPlant[3] == 16)
                    {
                        Plant43_TransAccelFactor = 0.0002f;
                        Plant43_DragFactor = -0.0014f;
                        Plant43_StartForwardAccelSpeed = 0f;
                        Plant43_ForwardAccel = 0f;
                        Plant43_StartBoosterTimeSpeed = 0f;
                    }
                    else if (existingPlant[3] == 17)
                    {
                        Plant43_TransAccelFactor = 0.0004f;
                        Plant43_DragFactor = -0.0007f;
                        Plant43_StartForwardAccelSpeed = 0f;
                        Plant43_ForwardAccel = 0f;
                        Plant43_StartBoosterTimeSpeed = 0f;
                    }
                    else if (existingPlant[3] == 18)
                    {
                        Plant43_TransAccelFactor = 0.0002f;
                        Plant43_DragFactor = 0f;
                        Plant43_StartForwardAccelSpeed = 0f;
                        Plant43_ForwardAccel = 2f;
                        Plant43_StartBoosterTimeSpeed = 0f;
                    }
                    else if (existingPlant[3] == 19)
                    {
                        Plant43_TransAccelFactor = 0.0004f;
                        Plant43_DragFactor = 0f;
                        Plant43_StartForwardAccelSpeed = 0f;
                        Plant43_ForwardAccel = 1f;
                        Plant43_StartBoosterTimeSpeed = 0f;
                    }
                    else if (existingPlant[3] == 20)
                    {
                        Plant43_TransAccelFactor = 0.0006f;
                        Plant43_DragFactor = 0f;
                        Plant43_StartForwardAccelSpeed = 0f;
                        Plant43_ForwardAccel = 1f;
                        Plant43_StartBoosterTimeSpeed = 0f;
                    }
                    else if (existingPlant[3] == 21)
                    {
                        Plant43_TransAccelFactor = 0.0008f;
                        Plant43_DragFactor = 0f;
                        Plant43_StartForwardAccelSpeed = 0f;
                        Plant43_ForwardAccel = 0f;
                        Plant43_StartBoosterTimeSpeed = 0f;
                    }
                    else if (existingPlant[3] == 22)
                    {
                        Plant43_TransAccelFactor = 0.0012f;
                        Plant43_DragFactor = -0.0014f;
                        Plant43_StartForwardAccelSpeed = 0f;
                        Plant43_ForwardAccel = 0f;
                        Plant43_StartBoosterTimeSpeed = 0f;
                    }
                    else if (existingPlant[3] == 23)
                    {
                        Plant43_TransAccelFactor = 0.002f;
                        Plant43_DragFactor = 0f;
                        Plant43_StartForwardAccelSpeed = 0f;
                        Plant43_ForwardAccel = 1f;
                        Plant43_StartBoosterTimeSpeed = 30f;
                    }
                    else
                    {
                        Plant43_TransAccelFactor = 0f;
                        Plant43_DragFactor = 0f;
                        Plant43_StartForwardAccelSpeed = 0f;
                        Plant43_ForwardAccel = 0f;
                        Plant43_StartBoosterTimeSpeed = 0f;
                    }
                }
                else if (existingPlant[4] == 44)
                {
                    if (existingPlant[5] == 1)
                    {
                        Plant44_SlipBrake = -40f;
                        Plant44_GripBrake = -40f;
                        Plant44_RearGripFactor = 0.2f;
                        Plant44_FrontGripFactor = 0.2f;
                        Plant44_CornerDrawFactor = 0.0005f;
                        Plant44_SteerConstraint = 0f;
                    }
                    else if (existingPlant[5] == 2)
                    {
                        Plant44_SlipBrake = -12f;
                        Plant44_GripBrake = 0f;
                        Plant44_RearGripFactor = 0.3f;
                        Plant44_FrontGripFactor = 0.3f;
                        Plant44_CornerDrawFactor = 0.001f;
                        Plant44_SteerConstraint = 0f;
                    }
                    else if (existingPlant[5] == 3)
                    {
                        Plant44_SlipBrake = -10f;
                        Plant44_GripBrake = 0f;
                        Plant44_RearGripFactor = 0.2f;
                        Plant44_FrontGripFactor = 0.2f;
                        Plant44_CornerDrawFactor = 0f;
                        Plant44_SteerConstraint = 0f;
                    }
                    else if (existingPlant[5] == 4)
                    {
                        Plant44_SlipBrake = 0f;
                        Plant44_GripBrake = 0f;
                        Plant44_RearGripFactor = 0.1f;
                        Plant44_FrontGripFactor = 0.1f;
                        Plant44_CornerDrawFactor = 0f;
                        Plant44_SteerConstraint = 0f;
                    }
                    else if (existingPlant[5] == 5)
                    {
                        Plant44_SlipBrake = 0f;
                        Plant44_GripBrake = -20f;
                        Plant44_RearGripFactor = 0.05f;
                        Plant44_FrontGripFactor = 0.05f;
                        Plant44_CornerDrawFactor = 0f;
                        Plant44_SteerConstraint = 0f;
                    }
                    else if (existingPlant[5] == 6)
                    {
                        Plant44_SlipBrake = 0f;
                        Plant44_GripBrake = -20f;
                        Plant44_RearGripFactor = 0f;
                        Plant44_FrontGripFactor = 0f;
                        Plant44_CornerDrawFactor = 0f;
                        Plant44_SteerConstraint = 0f;
                    }
                    else if (existingPlant[5] == 7)
                    {
                        Plant44_SlipBrake = 0f;
                        Plant44_GripBrake = -15f;
                        Plant44_RearGripFactor = 0f;
                        Plant44_FrontGripFactor = 0f;
                        Plant44_CornerDrawFactor = 0f;
                        Plant44_SteerConstraint = 0f;
                    }
                    else if (existingPlant[5] == 8)
                    {
                        Plant44_SlipBrake = 0f;
                        Plant44_GripBrake = 0f;
                        Plant44_RearGripFactor = 0f;
                        Plant44_FrontGripFactor = 0f;
                        Plant44_CornerDrawFactor = 0f;
                        Plant44_SteerConstraint = 0.2f;
                    }
                    else if (existingPlant[5] == 9)
                    {
                        Plant44_SlipBrake = 0f;
                        Plant44_GripBrake = 0f;
                        Plant44_RearGripFactor = 0f;
                        Plant44_FrontGripFactor = 0f;
                        Plant44_CornerDrawFactor = 0f;
                        Plant44_SteerConstraint = 0.4f;
                    }
                    else if (existingPlant[5] == 10)
                    {
                        Plant44_SlipBrake = 0f;
                        Plant44_GripBrake = 0f;
                        Plant44_RearGripFactor = 0f;
                        Plant44_FrontGripFactor = 0f;
                        Plant44_CornerDrawFactor = 0f;
                        Plant44_SteerConstraint = 0.8f;
                    }
                    else if (existingPlant[5] == 11)
                    {
                        Plant44_SlipBrake = 0f;
                        Plant44_GripBrake = 0f;
                        Plant44_RearGripFactor = 0f;
                        Plant44_FrontGripFactor = 0f;
                        Plant44_CornerDrawFactor = 0f;
                        Plant44_SteerConstraint = -0.4f;
                    }
                    else if (existingPlant[5] == 12)
                    {
                        Plant44_SlipBrake = -8f;
                        Plant44_GripBrake = -5f;
                        Plant44_RearGripFactor = 0f;
                        Plant44_FrontGripFactor = 0f;
                        Plant44_CornerDrawFactor = 0f;
                        Plant44_SteerConstraint = 0f;
                    }
                    else if (existingPlant[5] == 13)
                    {
                        Plant44_SlipBrake = -6f;
                        Plant44_GripBrake = -7f;
                        Plant44_RearGripFactor = 0f;
                        Plant44_FrontGripFactor = 0f;
                        Plant44_CornerDrawFactor = 0f;
                        Plant44_SteerConstraint = 0f;
                    }
                    else if (existingPlant[5] == 14)
                    {
                        Plant44_SlipBrake = -4f;
                        Plant44_GripBrake = -9f;
                        Plant44_RearGripFactor = 0f;
                        Plant44_FrontGripFactor = 0f;
                        Plant44_CornerDrawFactor = 0f;
                        Plant44_SteerConstraint = 0f;
                    }
                    else if (existingPlant[5] == 15)
                    {
                        Plant44_SlipBrake = -2f;
                        Plant44_GripBrake = -11f;
                        Plant44_RearGripFactor = 0f;
                        Plant44_FrontGripFactor = 0f;
                        Plant44_CornerDrawFactor = 0f;
                        Plant44_SteerConstraint = 0f;
                    }
                    else
                    {
                        Plant44_SlipBrake = 0f;
                        Plant44_GripBrake = 0f;
                        Plant44_RearGripFactor = 0f;
                        Plant44_FrontGripFactor = 0f;
                        Plant44_CornerDrawFactor = 0f;
                        Plant44_SteerConstraint = 0f;
                    }
                }
                else if (existingPlant[6] == 45)
                {
                    if (existingPlant[7] == 0)
                    {
                        Plant45_DriftEscapeForce = 0f;
                        Plant45_DriftMaxGauge = 0f;
                        Plant45_CornerDrawFactor = 0f;
                        Plant45_SlipBrake = 0f;
                        Plant45_AnimalBoosterTime = 0f;
                        Plant45_AntiCollideBalance = 0f;
                        Plant45_DragFactor = 0f;
                    }
                    else if (existingPlant[7] == 1)
                    {
                        Plant45_DriftEscapeForce = 70f;
                        Plant45_DriftMaxGauge = -40f;
                        Plant45_CornerDrawFactor = 0.001f;
                        Plant45_SlipBrake = 0f;
                        Plant45_AnimalBoosterTime = 0f;
                        Plant45_AntiCollideBalance = 0f;
                        Plant45_DragFactor = 0f;
                    }
                    else if (existingPlant[7] == 2)
                    {
                        Plant45_DriftEscapeForce = 0f;
                        Plant45_DriftMaxGauge = -60f;
                        Plant45_CornerDrawFactor = 0f;
                        Plant45_SlipBrake = -192f;
                        Plant45_AnimalBoosterTime = 0f;
                        Plant45_AntiCollideBalance = 0f;
                        Plant45_DragFactor = 0f;
                    }
                    else if (existingPlant[7] == 3)
                    {
                        Plant45_DriftEscapeForce = 70f;
                        Plant45_DriftMaxGauge = 0f;
                        Plant45_CornerDrawFactor = 0f;
                        Plant45_SlipBrake = 0f;
                        Plant45_AnimalBoosterTime = 100f;
                        Plant45_AntiCollideBalance = 0f;
                        Plant45_DragFactor = 0f;
                    }
                    else if (existingPlant[7] == 4)
                    {
                        Plant45_DriftEscapeForce = 0f;
                        Plant45_DriftMaxGauge = -60f;
                        Plant45_CornerDrawFactor = 0f;
                        Plant45_SlipBrake = 0f;
                        Plant45_AnimalBoosterTime = 0f;
                        Plant45_AntiCollideBalance = 0f;
                        Plant45_DragFactor = 0f;
                    }
                    else if (existingPlant[7] == 5)
                    {
                        Plant45_DriftEscapeForce = 0f;
                        Plant45_DriftMaxGauge = -40f;
                        Plant45_CornerDrawFactor = 0f;
                        Plant45_SlipBrake = 0f;
                        Plant45_AnimalBoosterTime = 100f;
                        Plant45_AntiCollideBalance = 0f;
                        Plant45_DragFactor = 0f;
                    }
                    else if (existingPlant[7] == 6)
                    {
                        Plant45_DriftEscapeForce = 50f;
                        Plant45_DriftMaxGauge = 0f;
                        Plant45_CornerDrawFactor = 0f;
                        Plant45_SlipBrake = 0f;
                        Plant45_AnimalBoosterTime = 0f;
                        Plant45_AntiCollideBalance = 0f;
                        Plant45_DragFactor = 0f;
                    }
                    else if (existingPlant[7] == 7)
                    {
                        Plant45_DriftEscapeForce = 30f;
                        Plant45_DriftMaxGauge = 0f;
                        Plant45_CornerDrawFactor = 0.0005f;
                        Plant45_SlipBrake = 0f;
                        Plant45_AnimalBoosterTime = 0f;
                        Plant45_AntiCollideBalance = 0f;
                        Plant45_DragFactor = 0f;
                    }
                    else if (existingPlant[7] == 8)
                    {
                        Plant45_DriftEscapeForce = 0f;
                        Plant45_DriftMaxGauge = -40f;
                        Plant45_CornerDrawFactor = 0f;
                        Plant45_SlipBrake = 0f;
                        Plant45_AnimalBoosterTime = 0f;
                        Plant45_AntiCollideBalance = 0f;
                        Plant45_DragFactor = 0f;
                    }
                    else if (existingPlant[7] == 9)
                    {
                        Plant45_DriftEscapeForce = -20f;
                        Plant45_DriftMaxGauge = -60f;
                        Plant45_CornerDrawFactor = 0f;
                        Plant45_SlipBrake = 0f;
                        Plant45_AnimalBoosterTime = 0f;
                        Plant45_AntiCollideBalance = 0f;
                        Plant45_DragFactor = 0f;
                    }
                    else if (existingPlant[7] == 10)
                    {
                        Plant45_DriftEscapeForce = -60f;
                        Plant45_DriftMaxGauge = -100f;
                        Plant45_CornerDrawFactor = 0f;
                        Plant45_SlipBrake = 0f;
                        Plant45_AnimalBoosterTime = 0f;
                        Plant45_AntiCollideBalance = 0f;
                        Plant45_DragFactor = 0f;
                    }
                    else if (existingPlant[7] == 11)
                    {
                        Plant45_DriftEscapeForce = -40f;
                        Plant45_DriftMaxGauge = -80f;
                        Plant45_CornerDrawFactor = 0f;
                        Plant45_SlipBrake = 0f;
                        Plant45_AnimalBoosterTime = 0f;
                        Plant45_AntiCollideBalance = 0f;
                        Plant45_DragFactor = 0f;
                    }
                    else if (existingPlant[7] == 12)
                    {
                        Plant45_DriftEscapeForce = 10f;
                        Plant45_DriftMaxGauge = 0f;
                        Plant45_CornerDrawFactor = 0f;
                        Plant45_SlipBrake = 0f;
                        Plant45_AnimalBoosterTime = 0f;
                        Plant45_AntiCollideBalance = 0f;
                        Plant45_DragFactor = 0f;
                    }
                    else if (existingPlant[7] == 13)
                    {
                        Plant45_DriftEscapeForce = 30f;
                        Plant45_DriftMaxGauge = 0f;
                        Plant45_CornerDrawFactor = 0f;
                        Plant45_SlipBrake = 0f;
                        Plant45_AnimalBoosterTime = 0f;
                        Plant45_AntiCollideBalance = 0f;
                        Plant45_DragFactor = 0f;
                    }
                    else if (existingPlant[7] == 14)
                    {
                        Plant45_DriftEscapeForce = 50f;
                        Plant45_DriftMaxGauge = 40f;
                        Plant45_CornerDrawFactor = 0f;
                        Plant45_SlipBrake = 0f;
                        Plant45_AnimalBoosterTime = 0f;
                        Plant45_AntiCollideBalance = 0f;
                        Plant45_DragFactor = 0f;
                    }
                    else if (existingPlant[7] == 15)
                    {
                        Plant45_DriftEscapeForce = 70f;
                        Plant45_DriftMaxGauge = 60f;
                        Plant45_CornerDrawFactor = 0f;
                        Plant45_SlipBrake = 0f;
                        Plant45_AnimalBoosterTime = 0f;
                        Plant45_AntiCollideBalance = 0f;
                        Plant45_DragFactor = 0f;
                    }
                    else if (existingPlant[7] == 16)
                    {
                        Plant45_DriftEscapeForce = 0f;
                        Plant45_DriftMaxGauge = 0f;
                        Plant45_CornerDrawFactor = 0.0005f;
                        Plant45_SlipBrake = 0f;
                        Plant45_AnimalBoosterTime = 0f;
                        Plant45_AntiCollideBalance = -0.005f;
                        Plant45_DragFactor = 0f;
                    }
                    else if (existingPlant[7] == 17)
                    {
                        Plant45_DriftEscapeForce = 0f;
                        Plant45_DriftMaxGauge = 0f;
                        Plant45_CornerDrawFactor = 0f;
                        Plant45_SlipBrake = 0f;
                        Plant45_AnimalBoosterTime = 0f;
                        Plant45_AntiCollideBalance = -0.005f;
                        Plant45_DragFactor = -0.0007f;
                    }
                    else if (existingPlant[7] == 18)
                    {
                        Plant45_DriftEscapeForce = 0f;
                        Plant45_DriftMaxGauge = -40f;
                        Plant45_CornerDrawFactor = 0f;
                        Plant45_SlipBrake = 0f;
                        Plant45_AnimalBoosterTime = 0f;
                        Plant45_AntiCollideBalance = -0.005f;
                        Plant45_DragFactor = 0f;
                    }
                    else if (existingPlant[7] == 19)
                    {
                        Plant45_DriftEscapeForce = 0f;
                        Plant45_DriftMaxGauge = 0f;
                        Plant45_CornerDrawFactor = 0f;
                        Plant45_SlipBrake = 0f;
                        Plant45_AnimalBoosterTime = 0f;
                        Plant45_AntiCollideBalance = -0.01f;
                        Plant45_DragFactor = 0f;
                    }
                    else if (existingPlant[7] == 20)
                    {
                        Plant45_DriftEscapeForce = 0f;
                        Plant45_DriftMaxGauge = -30f;
                        Plant45_CornerDrawFactor = 0f;
                        Plant45_SlipBrake = 0f;
                        Plant45_AnimalBoosterTime = 0f;
                        Plant45_AntiCollideBalance = -0.01f;
                        Plant45_DragFactor = 0f;
                    }
                    else if (existingPlant[7] == 21)
                    {
                        Plant45_DriftEscapeForce = 0f;
                        Plant45_DriftMaxGauge = 0f;
                        Plant45_CornerDrawFactor = 0f;
                        Plant45_SlipBrake = 0f;
                        Plant45_AnimalBoosterTime = 0f;
                        Plant45_AntiCollideBalance = -0.015f;
                        Plant45_DragFactor = 0f;
                    }
                    else if (existingPlant[7] == 22)
                    {
                        Plant45_DriftEscapeForce = 0f;
                        Plant45_DriftMaxGauge = 30f;
                        Plant45_CornerDrawFactor = 0f;
                        Plant45_SlipBrake = 0f;
                        Plant45_AnimalBoosterTime = 0f;
                        Plant45_AntiCollideBalance = -0.02f;
                        Plant45_DragFactor = 0f;
                    }
                    else if (existingPlant[7] == 23)
                    {
                        Plant45_DriftEscapeForce = 90f;
                        Plant45_DriftMaxGauge = 0f;
                        Plant45_CornerDrawFactor = 0.0005f;
                        Plant45_SlipBrake = 0f;
                        Plant45_AnimalBoosterTime = 0f;
                        Plant45_AntiCollideBalance = 0f;
                        Plant45_DragFactor = 0f;
                    }
                    else
                    {
                        Plant45_DriftEscapeForce = 0f;
                        Plant45_DriftMaxGauge = 0f;
                        Plant45_CornerDrawFactor = 0f;
                        Plant45_SlipBrake = 0f;
                        Plant45_AnimalBoosterTime = 0f;
                        Plant45_AntiCollideBalance = 0f;
                        Plant45_DragFactor = 0f;
                    }
                }
                else if (existingPlant[8] == 46)
                {
                    if (existingPlant[9] == 1)
                    {
                        Plant46_DriftMaxGauge = -80f;
                        Plant46_NormalBoosterTime = 120f;
                        Plant46_DriftSlipFactor = 0f;
                        Plant46_ForwardAccel = 0f;
                        Plant46_AnimalBoosterTime = 0f;
                        Plant46_TeamBoosterTime = 0f;
                        Plant46_StartForwardAccelSpeed = 0f;
                        Plant46_StartForwardAccelItem = 0f;
                        Plant46_StartBoosterTimeSpeed = 0f;
                        Plant46_StartBoosterTimeItem = 0f;
                        Plant46_ItemSlotCapacity = 0;
                        Plant46_SpeedSlotCapacity = 0;
                        Plant46_GripBrake = 0f;
                        Plant46_SlipBrake = 0f;
                    }
                    else if (existingPlant[9] == 2)
                    {
                        Plant46_DriftMaxGauge = 0f;
                        Plant46_NormalBoosterTime = 0f;
                        Plant46_DriftSlipFactor = -0.03f;
                        Plant46_ForwardAccel = 2f;
                        Plant46_AnimalBoosterTime = 0f;
                        Plant46_TeamBoosterTime = 0f;
                        Plant46_StartForwardAccelSpeed = 0f;
                        Plant46_StartForwardAccelItem = 0f;
                        Plant46_StartBoosterTimeSpeed = 0f;
                        Plant46_StartBoosterTimeItem = 0f;
                        Plant46_ItemSlotCapacity = 0;
                        Plant46_SpeedSlotCapacity = 0;
                        Plant46_GripBrake = 0f;
                        Plant46_SlipBrake = 0f;
                    }
                    else if (existingPlant[9] == 3)
                    {
                        Plant46_DriftMaxGauge = 0f;
                        Plant46_NormalBoosterTime = 0f;
                        Plant46_DriftSlipFactor = 0f;
                        Plant46_ForwardAccel = 0f;
                        Plant46_AnimalBoosterTime = 200f;
                        Plant46_TeamBoosterTime = 0f;
                        Plant46_StartForwardAccelSpeed = 0f;
                        Plant46_StartForwardAccelItem = 0f;
                        Plant46_StartBoosterTimeSpeed = 0f;
                        Plant46_StartBoosterTimeItem = 0f;
                        Plant46_ItemSlotCapacity = 0;
                        Plant46_SpeedSlotCapacity = 0;
                        Plant46_GripBrake = 0f;
                        Plant46_SlipBrake = 0f;
                    }
                    else if (existingPlant[9] == 5)
                    {
                        Plant46_DriftMaxGauge = 0f;
                        Plant46_NormalBoosterTime = 90f;
                        Plant46_DriftSlipFactor = 0f;
                        Plant46_ForwardAccel = 0f;
                        Plant46_AnimalBoosterTime = 50f;
                        Plant46_TeamBoosterTime = 60f;
                        Plant46_StartForwardAccelSpeed = 0.02f;
                        Plant46_StartForwardAccelItem = 0.02f;
                        Plant46_StartBoosterTimeSpeed = 0f;
                        Plant46_StartBoosterTimeItem = 0f;
                        Plant46_ItemSlotCapacity = 0;
                        Plant46_SpeedSlotCapacity = 0;
                        Plant46_GripBrake = 0f;
                        Plant46_SlipBrake = 0f;
                    }
                    else if (existingPlant[9] == 7)
                    {
                        Plant46_DriftMaxGauge = 0f;
                        Plant46_NormalBoosterTime = 0f;
                        Plant46_DriftSlipFactor = 0f;
                        Plant46_ForwardAccel = 0f;
                        Plant46_AnimalBoosterTime = 0f;
                        Plant46_TeamBoosterTime = 0f;
                        Plant46_StartForwardAccelSpeed = 0f;
                        Plant46_StartForwardAccelItem = 0f;
                        Plant46_StartBoosterTimeSpeed = 105f;
                        Plant46_StartBoosterTimeItem = 0f;
                        Plant46_ItemSlotCapacity = 0;
                        Plant46_SpeedSlotCapacity = 0;
                        Plant46_GripBrake = 0f;
                        Plant46_SlipBrake = 0f;
                    }
                    else if (existingPlant[9] == 8)
                    {
                        Plant46_DriftMaxGauge = 0f;
                        Plant46_NormalBoosterTime = 0f;
                        Plant46_DriftSlipFactor = 0f;
                        Plant46_ForwardAccel = 0f;
                        Plant46_AnimalBoosterTime = 0f;
                        Plant46_TeamBoosterTime = 0f;
                        Plant46_StartForwardAccelSpeed = 0f;
                        Plant46_StartForwardAccelItem = 0f;
                        Plant46_StartBoosterTimeSpeed = 0f;
                        Plant46_StartBoosterTimeItem = 105f;
                        Plant46_ItemSlotCapacity = 0;
                        Plant46_SpeedSlotCapacity = 0;
                        Plant46_GripBrake = 0f;
                        Plant46_SlipBrake = 0f;
                    }
                    else if (existingPlant[9] == 11)
                    {
                        Plant46_DriftMaxGauge = 0f;
                        Plant46_NormalBoosterTime = 0f;
                        Plant46_DriftSlipFactor = 0f;
                        Plant46_ForwardAccel = 0f;
                        Plant46_AnimalBoosterTime = 0f;
                        Plant46_TeamBoosterTime = 0f;
                        Plant46_StartForwardAccelSpeed = 0f;
                        Plant46_StartForwardAccelItem = 0f;
                        Plant46_StartBoosterTimeSpeed = 0f;
                        Plant46_StartBoosterTimeItem = 0f;
                        Plant46_ItemSlotCapacity = 3;
                        Plant46_SpeedSlotCapacity = 0;
                        Plant46_GripBrake = 0f;
                        Plant46_SlipBrake = 0f;
                    }
                    else if (existingPlant[9] == 12)
                    {
                        Plant46_DriftMaxGauge = 0f;
                        Plant46_NormalBoosterTime = 0f;
                        Plant46_DriftSlipFactor = 0f;
                        Plant46_ForwardAccel = 0f;
                        Plant46_AnimalBoosterTime = 0f;
                        Plant46_TeamBoosterTime = 0f;
                        Plant46_StartForwardAccelSpeed = 0f;
                        Plant46_StartForwardAccelItem = 0f;
                        Plant46_StartBoosterTimeSpeed = 0f;
                        Plant46_StartBoosterTimeItem = 0f;
                        Plant46_ItemSlotCapacity = 0;
                        Plant46_SpeedSlotCapacity = 3;
                        Plant46_GripBrake = 0f;
                        Plant46_SlipBrake = 0f;
                    }
                    else if (existingPlant[9] == 15 || existingPlant[9] == 16)
                    {
                        Plant46_DriftMaxGauge = 0f;
                        Plant46_NormalBoosterTime = 0f;
                        Plant46_DriftSlipFactor = 0f;
                        Plant46_ForwardAccel = 0f;
                        Plant46_AnimalBoosterTime = 100f;
                        Plant46_TeamBoosterTime = 0f;
                        Plant46_StartForwardAccelSpeed = 0f;
                        Plant46_StartForwardAccelItem = 0f;
                        Plant46_StartBoosterTimeSpeed = 0f;
                        Plant46_StartBoosterTimeItem = 0f;
                        Plant46_ItemSlotCapacity = 0;
                        Plant46_SpeedSlotCapacity = 0;
                        Plant46_GripBrake = 10f;
                        Plant46_SlipBrake = 0f;
                    }
                    else if (existingPlant[9] == 17)
                    {
                        Plant46_DriftMaxGauge = 0f;
                        Plant46_NormalBoosterTime = 0f;
                        Plant46_DriftSlipFactor = 0f;
                        Plant46_ForwardAccel = 0f;
                        Plant46_AnimalBoosterTime = 100f;
                        Plant46_TeamBoosterTime = 0f;
                        Plant46_StartForwardAccelSpeed = 0f;
                        Plant46_StartForwardAccelItem = 0f;
                        Plant46_StartBoosterTimeSpeed = 0f;
                        Plant46_StartBoosterTimeItem = 0f;
                        Plant46_ItemSlotCapacity = 0;
                        Plant46_SpeedSlotCapacity = 0;
                        Plant46_GripBrake = 9f;
                        Plant46_SlipBrake = 0f;
                    }
                    else if (existingPlant[9] == 18)
                    {
                        Plant46_DriftMaxGauge = 0f;
                        Plant46_NormalBoosterTime = 0f;
                        Plant46_DriftSlipFactor = 0f;
                        Plant46_ForwardAccel = 0f;
                        Plant46_AnimalBoosterTime = 120f;
                        Plant46_TeamBoosterTime = 0f;
                        Plant46_StartForwardAccelSpeed = 0f;
                        Plant46_StartForwardAccelItem = 0f;
                        Plant46_StartBoosterTimeSpeed = 0f;
                        Plant46_StartBoosterTimeItem = 0f;
                        Plant46_ItemSlotCapacity = 0;
                        Plant46_SpeedSlotCapacity = 0;
                        Plant46_GripBrake = 0f;
                        Plant46_SlipBrake = 0f;
                    }
                    else if (existingPlant[9] == 23)
                    {
                        Plant46_DriftMaxGauge = 0f;
                        Plant46_NormalBoosterTime = 0f;
                        Plant46_DriftSlipFactor = 0f;
                        Plant46_ForwardAccel = 0f;
                        Plant46_AnimalBoosterTime = 60f;
                        Plant46_TeamBoosterTime = 0f;
                        Plant46_StartForwardAccelSpeed = 0f;
                        Plant46_StartForwardAccelItem = 0f;
                        Plant46_StartBoosterTimeSpeed = 0f;
                        Plant46_StartBoosterTimeItem = 0f;
                        Plant46_ItemSlotCapacity = 0;
                        Plant46_SpeedSlotCapacity = 0;
                        Plant46_GripBrake = 0f;
                        Plant46_SlipBrake = 0f;
                    }
                    else if (existingPlant[9] == 24)
                    {
                        Plant46_DriftMaxGauge = 0f;
                        Plant46_NormalBoosterTime = 0f;
                        Plant46_DriftSlipFactor = 0f;
                        Plant46_ForwardAccel = 0f;
                        Plant46_AnimalBoosterTime = 0f;
                        Plant46_TeamBoosterTime = 60f;
                        Plant46_StartForwardAccelSpeed = 0f;
                        Plant46_StartForwardAccelItem = 0f;
                        Plant46_StartBoosterTimeSpeed = 0f;
                        Plant46_StartBoosterTimeItem = 0f;
                        Plant46_ItemSlotCapacity = 0;
                        Plant46_SpeedSlotCapacity = 0;
                        Plant46_GripBrake = 0f;
                        Plant46_SlipBrake = 0f;
                    }
                    else if (existingPlant[9] == 25)
                    {
                        Plant46_DriftMaxGauge = 0f;
                        Plant46_NormalBoosterTime = 90f;
                        Plant46_DriftSlipFactor = 0f;
                        Plant46_ForwardAccel = 0f;
                        Plant46_AnimalBoosterTime = 0f;
                        Plant46_TeamBoosterTime = -30f;
                        Plant46_StartForwardAccelSpeed = 0f;
                        Plant46_StartForwardAccelItem = 0f;
                        Plant46_StartBoosterTimeSpeed = 0f;
                        Plant46_StartBoosterTimeItem = 0f;
                        Plant46_ItemSlotCapacity = 0;
                        Plant46_SpeedSlotCapacity = 0;
                        Plant46_GripBrake = 0f;
                        Plant46_SlipBrake = 0f;
                    }
                    else if (existingPlant[9] == 26)
                    {
                        Plant46_DriftMaxGauge = 0f;
                        Plant46_NormalBoosterTime = -30f;
                        Plant46_DriftSlipFactor = 0f;
                        Plant46_ForwardAccel = 0f;
                        Plant46_AnimalBoosterTime = 0f;
                        Plant46_TeamBoosterTime = 90f;
                        Plant46_StartForwardAccelSpeed = 0f;
                        Plant46_StartForwardAccelItem = 0f;
                        Plant46_StartBoosterTimeSpeed = 0f;
                        Plant46_StartBoosterTimeItem = 0f;
                        Plant46_ItemSlotCapacity = 0;
                        Plant46_SpeedSlotCapacity = 0;
                        Plant46_GripBrake = 0f;
                        Plant46_SlipBrake = 0f;
                    }
                    else
                    {
                        Plant46_DriftMaxGauge = 0f;
                        Plant46_NormalBoosterTime = 0f;
                        Plant46_DriftSlipFactor = 0f;
                        Plant46_ForwardAccel = 0f;
                        Plant46_AnimalBoosterTime = 0f;
                        Plant46_TeamBoosterTime = 0f;
                        Plant46_StartForwardAccelSpeed = 0f;
                        Plant46_StartForwardAccelItem = 0f;
                        Plant46_StartBoosterTimeSpeed = 0f;
                        Plant46_StartBoosterTimeItem = 0f;
                        Plant46_ItemSlotCapacity = 0;
                        Plant46_SpeedSlotCapacity = 0;
                        Plant46_GripBrake = 0f;
                        Plant46_SlipBrake = 0f;
                    }
                }
            }
            else
            {
                Reset_Plant_SpecData();
            }
        }

        public static void Use_KartLevelSpec(short Set_Kart, short Set_KartSN)
        {
            var kartAndSN = new { Kart = Set_Kart, SN = Set_KartSN };
            var levelList = KartExcData.LevelList;
            var existingLevel = levelList.FirstOrDefault(list => list[0] == kartAndSN.Kart && list[1] == kartAndSN.SN);
            if (existingLevel != null)
            {
                if (existingLevel[4] == 0)
                {
                    KartLevel_DragFactor = 0f;
                    KartLevel_ForwardAccel = 0f;
                }
                else if (existingLevel[4] == 1)
                {
                    KartLevel_DragFactor = -0.0001f;
                    KartLevel_ForwardAccel = 0.1f;
                }
                else if (existingLevel[4] == 2)
                {
                    KartLevel_DragFactor = -0.0002f;
                    KartLevel_ForwardAccel = 0.2f;
                }
                else if (existingLevel[4] == 3)
                {
                    KartLevel_DragFactor = -0.0003f;
                    KartLevel_ForwardAccel = 0.3f;
                }
                else if (existingLevel[4] == 4)
                {
                    KartLevel_DragFactor = -0.0004f;
                    KartLevel_ForwardAccel = 0.4f;
                }
                else if (existingLevel[4] == 5)
                {
                    KartLevel_DragFactor = -0.0005f;
                    KartLevel_ForwardAccel = 0.5f;
                }
                else if (existingLevel[4] == 6)
                {
                    KartLevel_DragFactor = -0.0006f;
                    KartLevel_ForwardAccel = 0.6f;
                }
                else if (existingLevel[4] == 7)
                {
                    KartLevel_DragFactor = -0.0007f;
                    KartLevel_ForwardAccel = 0.7f;
                }
                else if (existingLevel[4] == 8)
                {
                    KartLevel_DragFactor = -0.0008f;
                    KartLevel_ForwardAccel = 0.8f;
                }
                else if (existingLevel[4] == 9)
                {
                    KartLevel_DragFactor = -0.001f;
                    KartLevel_ForwardAccel = 1f;
                }
                else if (existingLevel[4] == 10)
                {
                    KartLevel_DragFactor = -0.0012f;
                    KartLevel_ForwardAccel = 1.5f;
                }
                if (existingLevel[5] == 0)
                {
                    KartLevel_CornerDrawFactor = 0f;
                    KartLevel_SteerConstraint = 0f;
                }
                else if (existingLevel[5] == 1)
                {
                    KartLevel_CornerDrawFactor = 0.0001f;
                    KartLevel_SteerConstraint = 0.01f;
                }
                else if (existingLevel[5] == 2)
                {
                    KartLevel_CornerDrawFactor = 0.0002f;
                    KartLevel_SteerConstraint = 0.02f;
                }
                else if (existingLevel[5] == 3)
                {
                    KartLevel_CornerDrawFactor = 0.0003f;
                    KartLevel_SteerConstraint = 0.03f;
                }
                else if (existingLevel[5] == 4)
                {
                    KartLevel_CornerDrawFactor = 0.0004f;
                    KartLevel_SteerConstraint = 0.04f;
                }
                else if (existingLevel[5] == 5)
                {
                    KartLevel_CornerDrawFactor = 0.0005f;
                    KartLevel_SteerConstraint = 0.05f;
                }
                else if (existingLevel[5] == 6)
                {
                    KartLevel_CornerDrawFactor = 0.0006f;
                    KartLevel_SteerConstraint = 0.06f;
                }
                else if (existingLevel[5] == 7)
                {
                    KartLevel_CornerDrawFactor = 0.0007f;
                    KartLevel_SteerConstraint = 0.08f;
                }
                else if (existingLevel[5] == 8)
                {
                    KartLevel_CornerDrawFactor = 0.0008f;
                    KartLevel_SteerConstraint = 0.11f;
                }
                else if (existingLevel[5] == 9)
                {
                    KartLevel_CornerDrawFactor = 0.0009f;
                    KartLevel_SteerConstraint = 0.15f;
                }
                else if (existingLevel[5] == 10)
                {
                    KartLevel_CornerDrawFactor = 0.001f;
                    KartLevel_SteerConstraint = 0.2f;
                }
                if (existingLevel[6] == 0)
                {
                    KartLevel_DriftEscapeForce = 0f;
                }
                else if (existingLevel[6] == 1)
                {
                    KartLevel_DriftEscapeForce = 1f;
                }
                else if (existingLevel[6] == 2)
                {
                    KartLevel_DriftEscapeForce = 3f;
                }
                else if (existingLevel[6] == 3)
                {
                    KartLevel_DriftEscapeForce = 6f;
                }
                else if (existingLevel[6] == 4)
                {
                    KartLevel_DriftEscapeForce = 10f;
                }
                else if (existingLevel[6] == 5)
                {
                    KartLevel_DriftEscapeForce = 15f;
                }
                else if (existingLevel[6] == 6)
                {
                    KartLevel_DriftEscapeForce = 20f;
                }
                else if (existingLevel[6] == 7)
                {
                    KartLevel_DriftEscapeForce = 26f;
                }
                else if (existingLevel[6] == 8)
                {
                    KartLevel_DriftEscapeForce = 33f;
                }
                else if (existingLevel[6] == 9)
                {
                    KartLevel_DriftEscapeForce = 40f;
                }
                else if (existingLevel[6] == 10)
                {
                    KartLevel_DriftEscapeForce = 50f;
                }
                if (existingLevel[7] == 0)
                {
                    KartLevel_TransAccelFactor = 0f;
                    KartLevel_StartBoosterTimeSpeed = 0f;
                    KartLevel_StartBoosterTimeItem = 0f;
                    KartLevel_BoostAccelFactorOnlyItem = 0f;
                }
                else if (existingLevel[7] == 1)
                {
                    KartLevel_TransAccelFactor = 0.0001f;
                    KartLevel_StartBoosterTimeSpeed = 5f;
                    KartLevel_StartBoosterTimeItem = 5f;
                    KartLevel_BoostAccelFactorOnlyItem = 0.001f;
                }
                else if (existingLevel[7] == 2)
                {
                    KartLevel_TransAccelFactor = 0.0003f;
                    KartLevel_StartBoosterTimeSpeed = 10f;
                    KartLevel_StartBoosterTimeItem = 10f;
                    KartLevel_BoostAccelFactorOnlyItem = 0.003f;
                }
                else if (existingLevel[7] == 3)
                {
                    KartLevel_TransAccelFactor = 0.0006f;
                    KartLevel_StartBoosterTimeSpeed = 15f;
                    KartLevel_StartBoosterTimeItem = 15f;
                    KartLevel_BoostAccelFactorOnlyItem = 0.005f;
                }
                else if (existingLevel[7] == 4)
                {
                    KartLevel_TransAccelFactor = 0.001f;
                    KartLevel_StartBoosterTimeSpeed = 20f;
                    KartLevel_StartBoosterTimeItem = 20f;
                    KartLevel_BoostAccelFactorOnlyItem = 0.009f;
                }
                else if (existingLevel[7] == 5)
                {
                    KartLevel_TransAccelFactor = 0.0014f;
                    KartLevel_StartBoosterTimeSpeed = 30f;
                    KartLevel_StartBoosterTimeItem = 30f;
                    KartLevel_BoostAccelFactorOnlyItem = 0.013f;
                }
                else if (existingLevel[7] == 6)
                {
                    KartLevel_TransAccelFactor = 0.0019f;
                    KartLevel_StartBoosterTimeSpeed = 40f;
                    KartLevel_StartBoosterTimeItem = 40f;
                    KartLevel_BoostAccelFactorOnlyItem = 0.019f;
                }
                else if (existingLevel[7] == 7)
                {
                    KartLevel_TransAccelFactor = 0.0025f;
                    KartLevel_StartBoosterTimeSpeed = 50f;
                    KartLevel_StartBoosterTimeItem = 50f;
                    KartLevel_BoostAccelFactorOnlyItem = 0.025f;
                }
                else if (existingLevel[7] == 8)
                {
                    KartLevel_TransAccelFactor = 0.0032f;
                    KartLevel_StartBoosterTimeSpeed = 65f;
                    KartLevel_StartBoosterTimeItem = 65f;
                    KartLevel_BoostAccelFactorOnlyItem = 0.033f;
                }
                else if (existingLevel[7] == 9)
                {
                    KartLevel_TransAccelFactor = 0.004f;
                    KartLevel_StartBoosterTimeSpeed = 80f;
                    KartLevel_StartBoosterTimeItem = 80f;
                    KartLevel_BoostAccelFactorOnlyItem = 0.041f;
                }
                else if (existingLevel[7] == 10)
                {
                    KartLevel_TransAccelFactor = 0.005f;
                    KartLevel_StartBoosterTimeSpeed = 100f;
                    KartLevel_StartBoosterTimeItem = 100f;
                    KartLevel_BoostAccelFactorOnlyItem = 0.05f;
                }
            }
            else
            {
                Reset_KartLevel_SpecData();
            }
        }

        public static void Use_PartsSpec(short id, short sn)
        {
            var kartAndSN = new { Id = id, Sn = sn };
            var partsList = KartExcData.PartsList;
            var existingParts = partsList.FirstOrDefault(list => list[0] == kartAndSN.Id && list[1] == kartAndSN.Sn);
            if (existingParts != null)
            {
                for (short i = 63; i < 67; i++)
                {
                    if (i == 63)
                    {
                        short Item_Id = existingParts[2];
                        short Grade = existingParts[3];
                        short PartsValue = existingParts[4];
                        if (PartsValue != 0)
                        {
                            PartSpec_TransAccelFactor = (existingParts[4] * 1.0f - 800.0f) / 25000.0f + 1.85f + -0.205f;
                        }
                        else
                        {
                            PartSpec_TransAccelFactor = 0f;
                        }
                    }
                    else if (i == 64)
                    {
                        short Item_Id = existingParts[5];
                        short Grade = (byte)existingParts[6];
                        short PartsValue = existingParts[7];
                        if (PartsValue != 0)
                        {
                            PartSpec_SteerConstraint = (existingParts[7] * 1.0f - 800.0f) / 250.0f + 2.1f + 20.3f;
                        }
                        else
                        {
                            PartSpec_SteerConstraint = 0f;
                        }
                    }
                    else if (i == 65)
                    {
                        short Item_Id = existingParts[8];
                        short Grade = (byte)existingParts[9];
                        short PartsValue = existingParts[10];
                        if (PartsValue != 0)
                        {
                            PartSpec_DriftEscapeForce = existingParts[10] * 2.0f + 2200.0f;
                        }
                        else
                        {
                            PartSpec_DriftEscapeForce = 0f;
                        }
                    }
                    else if (i == 66)
                    {
                        short Item_Id = existingParts[11];
                        short Grade = (byte)existingParts[12];
                        short PartsValue = existingParts[13];
                        if (PartsValue != 0)
                        {
                            PartSpec_NormalBoosterTime = existingParts[13] * 1.0f - 940.0f + 3000.0f;
                        }
                        else
                        {
                            PartSpec_NormalBoosterTime = 0f;
                        }
                    }
                    Console.WriteLine("-------------------------------------------------------------");
                    Console.WriteLine("TransAccelFactor:{0}", PartSpec_TransAccelFactor);
                    Console.WriteLine("SteerConstraint:{0}", PartSpec_SteerConstraint);
                    Console.WriteLine("DriftEscapeForce:{0}", PartSpec_DriftEscapeForce);
                    Console.WriteLine("NormalBoosterTime:{0}", PartSpec_NormalBoosterTime);
                    Console.WriteLine("-------------------------------------------------------------");
                }
            }
            else
            {
                Reset_PartSpec_SpecData();
            }
        }
    }
}

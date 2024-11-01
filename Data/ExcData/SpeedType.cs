using System;
using KartLauncher.Data;
using KartLauncher.Data.KartSpec;

namespace KartLauncher.Data.ExcData
{
    public class SpeedType
    {
        public static float AddSpec_TransAccelFactor = 0f;
        public static float AddSpec_SteerConstraint = 0f;
        public static float AddSpec_DriftEscapeForce = 0f;

        public static float DragFactor = 0f;
        public static float ForwardAccelForce = 0f;
        public static float BackwardAccelForce = 0f;
        public static float GripBrakeForce = 0f;
        public static float SlipBrakeForce = 0f;
        public static float SteerConstraint = 0f;
        public static float DriftEscapeForce = 0f;
        public static float CornerDrawFactor = 0f;
        public static float DriftMaxGauge = 0f;
        public static float TransAccelFactor = 0f;
        public static float BoostAccelFactor = 0f;
        public static float StartForwardAccelForceItem = 0f;
        public static float StartForwardAccelForceSpeed = 0f;

        public static void SpeedTypeData()
        {
            if (StartGameData.StartTimeAttack_SpeedType == 3)//S0 보통
            {
                AddSpec_SteerConstraint = -0.3f;
                AddSpec_DriftEscapeForce = -350f;
                AddSpec_TransAccelFactor = -0.015f;
                DragFactor = -0.05f;
                ForwardAccelForce = -530f;
                BackwardAccelForce = -225f;
                GripBrakeForce = -570f;
                SlipBrakeForce = -215f;
                SteerConstraint = -2.25f;
                DriftEscapeForce = -750f;
                CornerDrawFactor = -0.05f;
                DriftMaxGauge = 750f;
                TransAccelFactor = -0.2155f;
                BoostAccelFactor = 0.006f;
                StartForwardAccelForceItem = -530f;
                StartForwardAccelForceSpeed = -950f;
                Console.WriteLine("SpeedType:S0");
            }
            else if (StartGameData.StartTimeAttack_SpeedType == 0)//S1 빠름
            {
                AddSpec_SteerConstraint = 1.7f;
                AddSpec_DriftEscapeForce = 150f;
                AddSpec_TransAccelFactor = 0.199f;
                DragFactor = -0.015f;
                ForwardAccelForce = -200f;
                BackwardAccelForce = -225f;
                GripBrakeForce = -270f;
                SlipBrakeForce = -165f;
                SteerConstraint = -0.25f;
                DriftEscapeForce = -250f;
                CornerDrawFactor = -0.03f;
                DriftMaxGauge = -330f;
                TransAccelFactor = -0.0015f;
                BoostAccelFactor = 0.006f;
                StartForwardAccelForceItem = -200f;
                StartForwardAccelForceSpeed = -360f;
                Console.WriteLine("SpeedType:S1");
            }
            else if (StartGameData.StartTimeAttack_SpeedType == 1)//S2 매우빠름
            {
                AddSpec_SteerConstraint = 2.2f;
                AddSpec_DriftEscapeForce = 1100f;
                AddSpec_TransAccelFactor = 0.202f;
                DragFactor = 0.0121f;
                ForwardAccelForce = 200f;
                BackwardAccelForce = 225f;
                GripBrakeForce = 270f;
                SlipBrakeForce = 165f;
                SteerConstraint = 0.25f;
                DriftEscapeForce = 700f;
                CornerDrawFactor = 0f;
                DriftMaxGauge = 580f;
                TransAccelFactor = 0.0015f;
                BoostAccelFactor = 0.006f;
                StartForwardAccelForceItem = 200f;
                StartForwardAccelForceSpeed = 360f;
                Console.WriteLine("SpeedType:S2");
            }
            else if (StartGameData.StartTimeAttack_SpeedType == 2)//S3 가장빠름
            {
                AddSpec_SteerConstraint = 2.7f;
                AddSpec_DriftEscapeForce = 1500f;
                AddSpec_TransAccelFactor = 0.2f;
                DragFactor = 0.04f;
                ForwardAccelForce = 750f;
                BackwardAccelForce = 450f;
                GripBrakeForce = 540f;
                SlipBrakeForce = 325f;
                SteerConstraint = 0.75f;
                DriftEscapeForce = 1100f;
                CornerDrawFactor = -0.02f;
                DriftMaxGauge = 1700f;
                TransAccelFactor = -0.0005f;
                BoostAccelFactor = 0.006f;
                StartForwardAccelForceItem = 750f;
                StartForwardAccelForceSpeed = 1350f;
                Console.WriteLine("SpeedType:S3");
            }
            else if (StartGameData.StartTimeAttack_SpeedType == 4 || StartGameData.StartTimeAttack_SpeedType == 6 || StartGameData.StartTimeAttack_SpeedType == 7)//무부, 통합
            {
                AddSpec_SteerConstraint = 1.95f;
                AddSpec_DriftEscapeForce = 400f;
                AddSpec_TransAccelFactor = 0.2005f;
                DragFactor = 0f;
                ForwardAccelForce = 0f;
                BackwardAccelForce = 0f;
                GripBrakeForce = 0f;
                SlipBrakeForce = 0f;
                SteerConstraint = 0f;
                DriftEscapeForce = 0f;
                CornerDrawFactor = 0f;
                DriftMaxGauge = 0f;
                TransAccelFactor = 0f;
                BoostAccelFactor = 0f;
                StartForwardAccelForceItem = 0f;
                StartForwardAccelForceSpeed = 0f;
                Console.WriteLine("SpeedType:Integration");
            }
            else
            {
                GameSupport.OnDisconnect();
                Console.WriteLine("SpeedType:null");
            }
            FlyingPet.FlyingPet_Spec();
        }
    }
}

using KartLauncher;

namespace KartLauncher.Data.ExcData
{
    public class SpeedPatch
    {
        public static float DragFactor = 0f; //최고 속도
        public static float ForwardAccelForce = 0f; //전진 가속도
        public static float DriftEscapeForce = 0f; //드리프트 탈출력
        public static float CornerDrawFactor = 0f; //코너 가속
        public static float DriftMaxGauge = 0f; //게이지 충전량
        public static float TransAccelFactor = 0f; //변신 부스터 가속력
        public static float BoostAccelFactor = 0f; //부스터 가속력
        public static float StartForwardAccelForceItem = 0f; //출발 부스터 가속 아이템
        public static float StartForwardAccelForceSpeed = 0f; //출발 부스터 가속 스피드

        public static void SpeedPatcData()
        {
            if (Program.SpeedPatch)
            {
                DragFactor = -0.003f;
                ForwardAccelForce = 30f;
                DriftEscapeForce = 200f;
                CornerDrawFactor = 0.0015f;
                DriftMaxGauge = -70f;
                TransAccelFactor = 0.005f;
                BoostAccelFactor = 0.005f;
                StartForwardAccelForceItem = 100f;
                StartForwardAccelForceSpeed = 100f;
            }
            else
            {
                DragFactor = 0f;
                ForwardAccelForce = 0f;
                DriftEscapeForce = 0f;
                CornerDrawFactor = 0f;
                DriftMaxGauge = 0f;
                TransAccelFactor = 0f;
                BoostAccelFactor = 0f;
                StartForwardAccelForceItem = 0f;
                StartForwardAccelForceSpeed = 0f;
            }
        }
    }
}
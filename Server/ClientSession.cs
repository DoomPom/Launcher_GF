using KartLauncher.Common;
using KartLauncher.Common.Common.Utilities;
using KartLauncher.Common.IO;
using KartLauncher.Common.KartRider.Common.Network;
using KartLauncher.Data;
using KartLauncher.Data.Set_Data;
using KartLauncher.ExcData;
using KartLauncher.KartSpec;
using KartLauncher.Rider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Xml;

namespace KartLauncher.Server
{
    public class ClientSession : Session
    {
        public static Dictionary<uint, MethodInfo> actions;

        static ClientSession()
        {
            // 加载方法。
            actions = new Dictionary<uint, MethodInfo>();
            Type type = typeof(ClientSession);
            MethodInfo[] methodInfos = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            string name;
            foreach (MethodInfo methodInfo in methodInfos)
            {
                name = methodInfo.Name;
                if (!name.StartsWith("On"))
                {
                    uint hash = Adler32Helper.GenerateAdler32(Encoding.ASCII.GetBytes(name), 0);
                    actions.Add(hash, methodInfo);
                    //Console.WriteLine(name);
                }
            }
        }
        public SessionGroup Parent { get; set; }
        public ClientSession(SessionGroup parent, Socket socket) : base(socket)
        {
            Parent = parent;
        }
        public override void OnDisconnect()
        {
            Parent.Client.Disconnect();
        }
        private InPacket iPacket;
        private const object[] args = null;
        public override void OnPacket(InPacket iPacket)
        {
            lock (Parent.m_lock)
            {
                iPacket.Position = 0;
                this.iPacket = iPacket;
                uint hash = iPacket.ReadUInt();
                if (actions.TryGetValue(hash, out MethodInfo action))
                {
                    action.Invoke(this, args);
                }
            }

        }
        //public void PqServerSideUdpBindCheck()// 1950550337 PqServerSideUdpBindCheck
        //{
        //    Console.WriteLine((PacketName)1950550337 + "：" + BitConverter.ToString(iPacket.ToArray()).Replace("-", ""));
        //}
        public void PqCnAuthenLogin()
        {
            using (OutPacket outPacket = new OutPacket("PrCnAuthenLogin"))
            {
                outPacket.WriteInt(1);
                outPacket.WriteString("pnlcdfngkdjfdhdermnkicqknmqrnjnkrlpdirerjrqkcllhpckngophnrrfclgiojmopomonkjilgmheoldpmmcdokgdqljqcnkrplffhflqdnchherghnhoihgfnon");
                outPacket.WriteByte(0);
                outPacket.WriteString("https://www.tiancity.com/agreement");
                Parent.Client.Send(outPacket);
            }
        }
        //public void PcReportRaidOccur() { }
        //public void PqGameReportMyBadUdp() { } // 1340475309
        //public void GrRiderTalkPacket() { }
        //public void PqEnterMagicHatPacket() { }
        //public void LoPingRequestPacket() { }
        //public void PqGetRiderQuestUX2ndData() { }
        //public void PqAddTimeEventInitPacket() { }
        //public void PqCountdownBoxPeriodPacket() { }
        //public void PqServerSideUdpBindCheck() { }
        //public void PqVipGradeCheck() { }
        //public void LoRqUpdateRiderSchoolDataPacket() { }
        //public void RmRiderTalkPacket() { }
        //public void PqNeedTimerGiftEvent() { }
        //public void GameBoosterAddPacket() { }
        //public void LoRqCheckReplayItemPacket() { }
        //public void PqGetRecommandChatServerInfo() { }
        //public void LoCheckLoginEvent() { }
        //public void PqBlockWordLogPacket() { }
        //public void PqWriteActionLogPacket() { }
        //public void PqAddTimeEventTimerPacket() { }
        //public void PqTimeShopOpenTimePacket() { }
        //public void PqItemPresetSlotDataList() { }
        //public void VipPlaytimeCheck() { }
        //public void LoRqEventRewardPacket() { }
        public void LoRqAddRacingTimePacket()
        {
            using (OutPacket outPacket = new OutPacket("LoRpAddRacingTimePacket"))
            {
                outPacket.WriteHexString("FF FF FF FF 00 00 00 00 00 00 00 00 00 00");
                Parent.Client.Send(outPacket);
            }
        }
        //public void LoRqUploadFilePacket()
        //{
        //}
        public void LoRqStartSinglePacket()
        {
            int ALLnum;
            int TimeAttackStartTicks = iPacket.ReadInt();
            Parent.TimeAttackStartTicks = TimeAttackStartTicks;
            Parent.PlaneCheck1 = (byte)Parent.TimeAttackStartTicks;
            uint key = CryptoConstants.GetKey(CryptoConstants.GetKey((uint)Parent.TimeAttackStartTicks)) % 5 + 6;
            ALLnum = (int)key;
            Parent.SendPlaneCount = (int)key;
            Parent.TotalSendPlaneCount = 0;
            Console.WriteLine("PlaneCheckMax: {0}", Parent.SendPlaneCount);
        }
        public void GameReportPacket()
        {
            byte[] DateTime1 = iPacket.ReadBytes(18);
            int GetItem = iPacket.ReadInt();
            int UseItem = iPacket.ReadInt();
            int UseBooster = iPacket.ReadEncodedInt();
            int[][] hashArray1 = new int[20][];
            for (int k = 0; k < 20; k++)
            {
                hashArray1[k] = new int[3];
                hashArray1[k][0] = iPacket.ReadEncodedInt();
                hashArray1[k][1] = iPacket.ReadEncodedInt();
                hashArray1[k][2] = iPacket.ReadEncodedInt();
            }
            int hash1 = iPacket.ReadEncodedInt();
            int hash2 = iPacket.ReadEncodedInt();
            int hash3 = iPacket.ReadEncodedInt();
            float single1 = iPacket.ReadEncodedFloat();
            float single2 = iPacket.ReadEncodedFloat();
            float single3 = iPacket.ReadEncodedFloat();
            int PlaneCheck = iPacket.ReadInt();
            byte[] hashArray2 = iPacket.ReadBytes(20);
            int hash4 = iPacket.ReadInt();
            byte[] hashArray3 = iPacket.ReadBytes(16);
            Parent.TotalSendPlaneCount += PlaneCheck;
            Console.WriteLine("PlaneCheck: {0}, Total: {1}, Max: {2}, Dist: {3}", PlaneCheck, Parent.TotalSendPlaneCount, Parent.SendPlaneCount, single3);
        }
        public void SpRqRenameRidPacket()
        {
            SetRider.Nickname = iPacket.ReadString(false);
            using (OutPacket outPacket = new OutPacket("SpRpRenameRidPacket"))
            {
                outPacket.WriteInt(0);
                Parent.Client.Send(outPacket);
            }
            SetGameData.Save_Nickname();
        }
        public void PqGetRider()
        {
            NewRider.LoadItemData();
        }
        //public void LoRqGetRiderItemPacket()
        //{
        //}
        public void LoRqSetRiderItemOnPacket()
        {
            SetRiderItem.Set_Character = iPacket.ReadShort();
            SetRiderItem.Set_Paint = iPacket.ReadShort();
            SetRiderItem.Set_Kart = iPacket.ReadShort();
            SetRiderItem.Set_Plate = iPacket.ReadShort();
            SetRiderItem.Set_Goggle = iPacket.ReadShort();
            SetRiderItem.Set_Balloon = iPacket.ReadShort();
            iPacket.ReadShort();
            SetRiderItem.Set_HeadBand = iPacket.ReadShort();
            iPacket.ReadShort();
            SetRiderItem.Set_HandGearL = iPacket.ReadShort();
            iPacket.ReadShort();
            SetRiderItem.Set_Uniform = iPacket.ReadShort();
            iPacket.ReadShort();
            SetRiderItem.Set_Pet = iPacket.ReadShort();
            SetRiderItem.Set_FlyingPet = iPacket.ReadShort();
            SetRiderItem.Set_Aura = iPacket.ReadShort();
            SetRiderItem.Set_SkidMark = iPacket.ReadShort();
            iPacket.ReadShort();
            SetRiderItem.Set_RidColor = iPacket.ReadShort();
            SetRiderItem.Set_BonusCard = iPacket.ReadShort();
            iPacket.ReadShort();
            short Set_KartPlant1 = iPacket.ReadShort();
            short Set_KartPlant2 = iPacket.ReadShort();
            short Set_KartPlant3 = iPacket.ReadShort();
            short Set_KartPlant4 = iPacket.ReadShort();
            iPacket.ReadShort();
            iPacket.ReadShort();
            SetRiderItem.Set_Tachometer = iPacket.ReadShort();
            SetRiderItem.Set_Dye = iPacket.ReadShort();
            SetRiderItem.Set_KartSN = iPacket.ReadShort();
            short Set_KartEffect = iPacket.ReadShort();
            short Set_KartBoosterEffect = iPacket.ReadShort();
            iPacket.ReadByte();
            SetRiderItem.Set_slotBg = iPacket.ReadByte();
            SetRiderItem.Save_SetRiderItem();
            TuneSpec.Use_PartsSpec(SetRiderItem.Set_Kart, SetRiderItem.Set_KartSN);
            TuneSpec.Use_TuneSpec(SetRiderItem.Set_Kart, SetRiderItem.Set_KartSN);
            TuneSpec.Use_PlantSpec(SetRiderItem.Set_Kart, SetRiderItem.Set_KartSN);
            TuneSpec.Use_KartLevelSpec(SetRiderItem.Set_Kart, SetRiderItem.Set_KartSN);
        }
        public void PqGetRiderInfo()
        {
            iPacket.ReadInt();
            iPacket.ReadInt();
            string Nickname = iPacket.ReadString(false);
            if (Nickname == SetRider.Nickname)
            {
                //GameSupport.PrGetRiderInfo();
                using (OutPacket outPacket = new OutPacket("PrGetRiderInfo"))
                {
                    outPacket.WriteByte(1);
                    outPacket.WriteUInt(SetRider.UserNO);
                    outPacket.WriteString(SetRider.UserID);
                    outPacket.WriteString(SetRider.Nickname);
                    outPacket.WriteUShort((ushort)RouterListener.DataTime()[0]);
                    outPacket.WriteUShort((ushort)RouterListener.DataTime()[1]);
                    for (int i = 0; i <= Program.MAX_EQP_P; i++)
                    {
                        outPacket.WriteShort(0);
                    }
                    outPacket.WriteByte(0);
                    outPacket.WriteString("");
                    outPacket.WriteInt(SetRider.RP);
                    outPacket.WriteInt(0);
                    outPacket.WriteByte(6);//Licenses
                    outPacket.WriteUShort((ushort)RouterListener.DataTime()[0]);
                    outPacket.WriteUShort((ushort)RouterListener.DataTime()[1]);
                    outPacket.WriteBytes(new byte[17]);
                    outPacket.WriteShort(SetRider.Emblem1);
                    outPacket.WriteShort(SetRider.Emblem2);
                    outPacket.WriteShort(0);
                    outPacket.WriteString(SetRider.RiderIntro);
                    outPacket.WriteInt(SetRider.Premium);
                    outPacket.WriteByte(1);
                    if (SetRider.Premium == 0)
                        outPacket.WriteInt(0);
                    else if (SetRider.Premium == 1)
                        outPacket.WriteInt(10000);
                    else if (SetRider.Premium == 2)
                        outPacket.WriteInt(30000);
                    else if (SetRider.Premium == 3)
                        outPacket.WriteInt(60000);
                    else if (SetRider.Premium == 4)
                        outPacket.WriteInt(120000);
                    else if (SetRider.Premium == 5)
                        outPacket.WriteInt(200000);
                    else
                        outPacket.WriteInt(0);
                    if (SetRider.ClubMark_LOGO == 0)
                    {
                        outPacket.WriteInt(0);
                        outPacket.WriteInt(0);
                        outPacket.WriteInt(0);
                        outPacket.WriteString("");
                    }
                    else
                    {
                        outPacket.WriteInt(SetRider.ClubCode);
                        outPacket.WriteInt(SetRider.ClubMark_LOGO);
                        outPacket.WriteInt(SetRider.ClubMark_LINE);
                        outPacket.WriteString(SetRider.ClubName);
                    }
                    outPacket.WriteInt(0);
                    outPacket.WriteByte(SetRider.Ranker);
                    outPacket.WriteInt(0);
                    outPacket.WriteInt(0);
                    outPacket.WriteInt(0);
                    outPacket.WriteInt(0);
                    outPacket.WriteInt(0);
                    outPacket.WriteByte(0);
                    outPacket.WriteByte(0);
                    outPacket.WriteByte(0);
                    RouterListener.MySession.Client.Send(outPacket);
                }
            }
            else
            {
                using (OutPacket outPacket = new OutPacket("PrGetRiderInfo"))
                {
                    outPacket.WriteByte(0);
                    Parent.Client.Send(outPacket);
                }
            }
        }
        public void PqUpdateRiderIntro()
        {
            SetRider.RiderIntro = iPacket.ReadString(false);
            SetGameData.Save_RiderIntro();
        }
        public void PqUpdateRiderSchoolLevelPacket()
        {
            using (OutPacket outPacket = new OutPacket("PrUpdateRiderSchoolLevelPacket"))
            {
                outPacket.WriteInt(0);
                outPacket.WriteInt(0);
                Parent.Client.Send(outPacket);
            }
        }
        public void PqSetPlaytimeEventTick()
        {
            using (OutPacket outPacket = new OutPacket("PrSetPlaytimeEventTick"))
            {
                outPacket.WriteByte(0);
                Parent.Client.Send(outPacket);
            }
        }
        public void PqUpdateGameOption()
        {
            SetGameOption.Set_BGM = iPacket.ReadFloat();
            SetGameOption.Set_Sound = iPacket.ReadFloat();
            SetGameOption.Main_BGM = iPacket.ReadByte();
            SetGameOption.Sound_effect = iPacket.ReadByte();
            SetGameOption.Full_screen = iPacket.ReadByte();
            SetGameOption.Unk1 = iPacket.ReadByte();
            SetGameOption.Unk2 = iPacket.ReadByte();
            SetGameOption.Unk3 = iPacket.ReadByte();
            SetGameOption.Unk4 = iPacket.ReadByte();
            SetGameOption.Unk5 = iPacket.ReadByte();
            SetGameOption.Unk6 = iPacket.ReadByte();
            SetGameOption.Unk7 = iPacket.ReadByte();
            SetGameOption.Unk8 = iPacket.ReadByte();//오토 레디
            SetGameOption.Unk9 = iPacket.ReadByte();//아이템 설명
            SetGameOption.Unk10 = iPacket.ReadByte();//녹화 품질
            SetGameOption.Unk11 = iPacket.ReadByte();
            SetGameOption.BGM_Check = iPacket.ReadByte();//배경음
            SetGameOption.Sound_Check = iPacket.ReadByte();//효과음
            SetGameOption.Unk12 = iPacket.ReadByte();
            SetGameOption.Unk13 = iPacket.ReadByte();
            SetGameOption.GameType = iPacket.ReadByte();//팀전 개인전 여부
            SetGameOption.SetGhost = iPacket.ReadByte();//고스트 사용여부
            SetGameOption.SpeedType = iPacket.ReadByte();//채널 속도
            SetGameOption.Unk14 = iPacket.ReadByte();
            SetGameOption.Unk15 = iPacket.ReadByte();
            SetGameOption.Unk16 = iPacket.ReadByte();
            SetGameOption.Unk17 = iPacket.ReadByte();
            SetGameOption.Set_screen = iPacket.ReadByte();
            SetGameOption.Unk18 = iPacket.ReadByte();
            SetGameOption.Save_SetGameOption();
        }
        public void PqGetGameOption()
        {
            GameSupport.PrGetGameOption();
        }
        public void PqVipInfo()
        {
            using (OutPacket outPacket = new OutPacket("PrVipInfo"))
            {
                outPacket.WriteInt(1);
                for (int i = 0; i < 10; i++)
                {
                    outPacket.WriteInt(0);
                }
                Parent.Client.Send(outPacket);
            }
        }
        public void PqLoginVipInfo()
        {
            using (OutPacket outPacket = new OutPacket("PrLoginVipInfo"))
            {
                outPacket.WriteInt(SetRider.Premium);
                outPacket.WriteByte(1);
                outPacket.WriteInt(0);
                Parent.Client.Send(outPacket);
            }
            using (OutPacket outPacket = new OutPacket("LoRpEventRewardPacket"))
            {
                outPacket.WriteInt(0);
                outPacket.WriteInt(0);
                Parent.Client.Send(outPacket);
            }
            using (OutPacket outPacket = new OutPacket("PcSlaveNotice"))
            {
                outPacket.WriteString("单机版完全免费，跑跑資訊站：https://kartinfo.me/thread-9369-1-1.html");
                Parent.Client.Send(outPacket);
            }
        }
        public void ChReRqEnterMyRoomPacket()
        {
            GameType.EnterMyRoomType = 0;
            GameSupport.ChRpEnterMyRoomPacket();
        }
        public void ChRqEnterRandomMyRoomPacket()
        {
            GameType.EnterMyRoomType = 5;
            GameSupport.ChRpEnterMyRoomPacket();
        }
        public void ChRqEnterMyRoomPacket()
        {
            string Nickname = iPacket.ReadString(false);
            if (Nickname == SetRider.Nickname)
            {
                GameType.EnterMyRoomType = 0;
            }
            else
            {
                GameType.EnterMyRoomType = 3;
            }
            GameSupport.ChRpEnterMyRoomPacket();
        }
        public void RmFirstRequestPacket()
        {
            using (OutPacket outPacket = new OutPacket("RmSlotDataPacket"))
            {
                outPacket.WriteUInt(SetRider.UserNO);
                outPacket.WriteBytes(new byte[12]);
                outPacket.WriteString(SetRider.Nickname);
                outPacket.WriteBytes(new byte[67]);
                outPacket.WriteInt(SetRider.RP);
                outPacket.WriteBytes(new byte[910]);
                Parent.Client.Send(outPacket);
            }
        }
        public void RmNotiMyRoomInfoPacket()
        {
            SetMyRoom.MyRoom = iPacket.ReadShort();
            SetMyRoom.MyRoomBGM = iPacket.ReadByte();
            SetMyRoom.UseRoomPwd = iPacket.ReadByte();
            iPacket.ReadByte();
            SetMyRoom.UseItemPwd = iPacket.ReadByte();
            SetMyRoom.TalkLock = iPacket.ReadByte();
            SetMyRoom.RoomPwd = iPacket.ReadString(false);
            iPacket.ReadString(false);
            SetMyRoom.ItemPwd = iPacket.ReadString(false);
            SetMyRoom.MyRoomKart1 = iPacket.ReadShort();
            SetMyRoom.MyRoomKart2 = iPacket.ReadShort();
            SetMyRoom.Save_SetMyRoom();
            GameSupport.RmNotiMyRoomInfoPacket();
        }
        public void ChRqSecedeMyRoomPacket()
        {
            //마이룸 나갈때
            using (OutPacket outPacket = new OutPacket("ChRpSecedeMyRoomPacket"))
            {
                outPacket.WriteByte(1);
                Parent.Client.Send(outPacket);
            }
        }
        public void PqStartScenario()
        {
            GameType.ScenarioType = iPacket.ReadInt();
            using (OutPacket outPacket = new OutPacket("PrStartScenario"))
            {
                outPacket.WriteInt(GameType.ScenarioType);
                outPacket.WriteByte(0);
                Parent.Client.Send(outPacket);
            }
        }
        public void PqCompleteScenarioSingle()
        {
            using (OutPacket outPacket = new OutPacket("PrCompleteScenarioSingle"))
            {
                outPacket.WriteInt(GameType.ScenarioType);
                outPacket.WriteByte(0);
                Parent.Client.Send(outPacket);
            }
        }
        public void PqKartSpec()
        {
            StartGameData.StartTimeAttack_SpeedType = iPacket.ReadByte();
            StartGameData.Kart_id = iPacket.ReadShort();
            StartGameData.FlyingPet_id = iPacket.ReadShort();
            GameType.StartType = 1;
            SpeedType.SpeedTypeData();
        }
        public void PqChapterInfoPacket()
        {
            using (OutPacket outPacket = new OutPacket("PrChapterInfoPacket"))
            {
                outPacket.WriteInt(56);
                for (int i = 1; i <= 56; i++)
                {
                    outPacket.WriteInt(i | 0x1000000);
                    outPacket.WriteInt((int)(Math.Pow(2, 20) - 1));
                    outPacket.WriteInt(0);
                    outPacket.WriteByte(0);
                }
                Parent.Client.Send(outPacket);
            }
        }
        public void PqChallengerInfoPacket()
        {
            using (OutPacket outPacket = new OutPacket("PrChallengerInfoPacket"))
            {
                int stage = 40;
                outPacket.WriteInt(stage);
                for (int i = 0; i < stage; i++)
                {
                    outPacket.WriteShort(55);
                }
                outPacket.WriteInt(0);
                outPacket.WriteByte(1);
                Parent.Client.Send(outPacket);
            }
        }
        public void PqStartChallenger()
        {
            int stage_id = iPacket.ReadInt();
            int GameType = iPacket.ReadInt();
            short Kart = iPacket.ReadShort();
            byte Unk1 = iPacket.ReadByte();
            byte Unk2 = iPacket.ReadByte();
            byte Unk3 = iPacket.ReadByte();
            using (OutPacket outPacket = new OutPacket("PrStartChallenger"))
            {
                outPacket.WriteInt(stage_id);
                outPacket.WriteInt(GameType);
                outPacket.WriteByte(0);
                outPacket.WriteByte(1);
                Parent.Client.Send(outPacket);
            }
        }
        public void PqchallengerKartSpec()
        {
            StartGameData.StartTimeAttack_SpeedType = iPacket.ReadByte();
            StartGameData.Kart_id = iPacket.ReadShort();
            StartGameData.FlyingPet_id = iPacket.ReadShort();
            GameType.StartType = 2;
            SpeedType.SpeedTypeData();
        }
        public void PqCompleteChallenger()
        {
            int stage = 40;
            byte StageType = iPacket.ReadByte();
            iPacket.ReadInt();
            int EndType = iPacket.ReadInt();
            using (OutPacket outPacket = new OutPacket("PrCompleteChallenger"))
            {
                outPacket.WriteByte(StageType);
                outPacket.WriteInt(0);
                outPacket.WriteInt(EndType);
                outPacket.WriteInt(0);
                outPacket.WriteInt(0);
                outPacket.WriteInt(stage);
                for (int i = 0; i < stage; i++)
                {
                    outPacket.WriteShort(55);
                }
                outPacket.WriteInt(0);
                outPacket.WriteInt(0);
                outPacket.WriteInt(0);
                outPacket.WriteInt(0);
                outPacket.WriteByte(0);
                Parent.Client.Send(outPacket);
            }
        }
        public void PqExChangePacket()
        {
            GameSupport.OnDisconnect();
        }
        public void PqKartLevelPointClear()
        {
            short Kart = iPacket.ReadShort();
            short SN = iPacket.ReadShort();
            using (OutPacket outPacket = new OutPacket("PrKartLevelPointClear"))
            {
                outPacket.WriteInt(1);
                outPacket.WriteShort(Kart);
                outPacket.WriteShort(SN);
                outPacket.WriteShort(5);
                outPacket.WriteShort(35);
                outPacket.WriteShort(0);
                outPacket.WriteShort(0);
                outPacket.WriteShort(0);
                outPacket.WriteShort(0);
                outPacket.WriteShort(0);
                outPacket.WriteInt(10000);
                Parent.Client.Send(outPacket);
            }
            KartExcData.AddLevelList(Kart, SN, 5, 35, 0, 0, 0, 0, 0);
        }
        public void PqDisassembleXPartsItem()
        {
            iPacket.ReadByte();
            iPacket.ReadShort();
            short Kart = iPacket.ReadShort();
            iPacket.ReadShort();
            short SN = iPacket.ReadShort();
            iPacket.ReadBytes(6);
            byte[] data = iPacket.ReadBytes(28);
            Console.WriteLine("DisassembleXPartsItem: " + Kart + " " + SN);
            using (OutPacket outPacket = new OutPacket("PrDisassembleXPartsItem"))
            {
                outPacket.WriteInt(0);
                outPacket.WriteShort(3);
                outPacket.WriteShort(0);
                outPacket.WriteShort(0);
                outPacket.WriteShort(0);
                outPacket.WriteInt(0);
                outPacket.WriteShort(0);
                outPacket.WriteShort(Kart);
                outPacket.WriteShort(1);
                outPacket.WriteShort(0);
                outPacket.WriteByte(1);
                outPacket.WriteByte(2);
                outPacket.WriteShort(0);
                outPacket.WriteShort(0);
                outPacket.WriteBytes(data);
                outPacket.WriteUInt(SetRider.Lucci);
                outPacket.WriteUInt(SetRider.Koin);
                Parent.Client.Send(outPacket);
            }
            using (OutPacket outPacket = new OutPacket("PrRequestKartInfoPacket"))
            {
                outPacket.WriteByte(1);
                outPacket.WriteInt(1);
                outPacket.WriteShort(3);
                outPacket.WriteShort(Kart);
                outPacket.WriteShort(SN);
                outPacket.WriteShort(1);//수량
                outPacket.WriteShort(0);
                outPacket.WriteShort(-1);
                outPacket.WriteShort(0);
                outPacket.WriteShort(0);
                outPacket.WriteShort(0);
                Parent.Client.Send(outPacket);
            }
            KartExcData.AddPartsList(Kart, SN, 63, 0, 0, 0);
            KartExcData.AddPartsList(Kart, SN, 64, 0, 0, 0);
            KartExcData.AddPartsList(Kart, SN, 65, 0, 0, 0);
            KartExcData.AddPartsList(Kart, SN, 66, 0, 0, 0);
            KartExcData.AddPlantList(Kart, SN, 43, 0);
            KartExcData.AddPlantList(Kart, SN, 44, 0);
            KartExcData.AddPlantList(Kart, SN, 45, 0);
            KartExcData.AddPlantList(Kart, SN, 46, 0);
            TuneSpec.Use_PartsSpec(Kart, SN);
            TuneSpec.Use_PlantSpec(Kart, SN);
            //GameSupport.OnDisconnect();
        }
        public void PqKartLevelUpProbText()
        {
            short Kart = iPacket.ReadShort();
            short SN = iPacket.ReadShort();
            iPacket.ReadShort();
            iPacket.ReadShort();
            using (OutPacket outPacket = new OutPacket("PrKartLevelUpProbText"))
            {
                outPacket.WriteInt(0);
                Parent.Client.Send(outPacket);
            }
        }
        public void PqKartLevelUp()
        {
            short Kart = iPacket.ReadShort();
            short SN = iPacket.ReadShort();
            short Kart2 = iPacket.ReadShort();
            short SN2 = iPacket.ReadShort();
            using (OutPacket outPacket = new OutPacket("PrKartLevelUp"))
            {
                outPacket.WriteUShort((ushort)RouterListener.DataTime()[0]);
                outPacket.WriteUShort((ushort)RouterListener.DataTime()[1]);
                outPacket.WriteInt(1);
                outPacket.WriteShort(Kart);
                outPacket.WriteShort(SN);
                outPacket.WriteShort(5);
                outPacket.WriteShort(35);
                outPacket.WriteShort(0);
                outPacket.WriteShort(0);
                outPacket.WriteShort(0);
                outPacket.WriteShort(0);
                outPacket.WriteInt(0);
                outPacket.WriteShort(Kart2);
                outPacket.WriteShort(SN2);
                outPacket.WriteUInt(SetRider.Koin);
                outPacket.WriteUInt(SetRider.Lucci);
                outPacket.WriteInt(0);
                Parent.Client.Send(outPacket);
            }
            KartExcData.AddLevelList(Kart, SN, 5, 35, 0, 0, 0, 0, 0);
        }
        public void PqKartLevelPointUpdate()
        {
            short Kart = iPacket.ReadShort();
            short SN = iPacket.ReadShort();
            short v1 = iPacket.ReadShort();
            short v2 = iPacket.ReadShort();
            short v3 = iPacket.ReadShort();
            short v4 = iPacket.ReadShort();
            short pointleft = 0;
            short Effect = 0;
            using (OutPacket outPacket = new OutPacket("PrKartLevelPointUpdate"))
            {
                outPacket.WriteInt(1);
                outPacket.WriteShort(Kart);
                outPacket.WriteShort(SN);
                outPacket.WriteShort(5);
                outPacket.WriteShort(pointleft);
                outPacket.WriteShort(v1);
                outPacket.WriteShort(v2);
                outPacket.WriteShort(v3);
                outPacket.WriteShort(v4);
                outPacket.WriteShort(Effect);
                Parent.Client.Send(outPacket);
            }
            TuneSpec.Use_KartLevelSpec(Kart, SN);
            var kartLevelList = KartExcData.LevelList;
            var kartAndSN = new { Kart, SN };
            var existingLevelList = kartLevelList.FirstOrDefault(list => list[0] == kartAndSN.Kart && list[1] == kartAndSN.SN);
            if (existingLevelList == null)
            {
                pointleft = (short)(35 - v1 - v2 - v3 - v4);
                KartExcData.AddLevelList(kartAndSN.Kart, kartAndSN.SN, 5, pointleft, v1, v2, v3, v4, 0);
            }
            else
            {
                pointleft = (short)(existingLevelList[3] - v1 - v2 - v3 - v4);
                short v1New = (short)(existingLevelList[4] + v1);
                short v2New = (short)(existingLevelList[5] + v2);
                short v3New = (short)(existingLevelList[6] + v3);
                short v4New = (short)(existingLevelList[7] + v4);
                short effect = existingLevelList[8];
                KartExcData.AddLevelList(kartAndSN.Kart, kartAndSN.SN, 5, pointleft, v1New, v2New, v3New, v4New, effect);
            }
        }
        public void SpRqGetMaxGiftIdPacket()
        {
        }
        public void PqKartLevelSpecialSlotUpdate()
        {
            short Kart = iPacket.ReadShort();
            short SN = iPacket.ReadShort();
            short Effect = iPacket.ReadShort();
            var kartLevelList = KartExcData.LevelList;
            var kartAndSN = new { Kart, SN };
            var existingLevelList = kartLevelList.FirstOrDefault(list => list[0] == kartAndSN.Kart && list[1] == kartAndSN.SN);
            using (OutPacket outPacket = new OutPacket("PrKartLevelSpecialSlotUpdate"))
            {
                outPacket.WriteInt(1);
                outPacket.WriteShort(kartAndSN.Kart);
                outPacket.WriteShort(kartAndSN.SN);
                if (existingLevelList != null)
                {
                    outPacket.WriteShort(existingLevelList[2]);
                    outPacket.WriteShort(existingLevelList[3]);
                    outPacket.WriteShort(existingLevelList[4]);
                    outPacket.WriteShort(existingLevelList[5]);
                    outPacket.WriteShort(existingLevelList[6]);
                    outPacket.WriteShort(existingLevelList[7]);
                    outPacket.WriteShort(Effect);
                    KartExcData.AddLevelList(kartAndSN.Kart, kartAndSN.SN, existingLevelList[2], existingLevelList[3], existingLevelList[4], existingLevelList[5], existingLevelList[6], existingLevelList[7], Effect);
                }
                else
                {
                    outPacket.WriteShort(5);
                    outPacket.WriteShort(0);
                    outPacket.WriteShort(10);
                    outPacket.WriteShort(10);
                    outPacket.WriteShort(10);
                    outPacket.WriteShort(5);
                    outPacket.WriteShort(Effect);
                    KartExcData.AddLevelList(kartAndSN.Kart, kartAndSN.SN, 5, 0, 10, 10, 10, 5, Effect);
                }
                Parent.Client.Send(outPacket);
            }
        }
        public void PqUseSocketItem()
        {
            short Item = iPacket.ReadShort();
            short Item_Id = iPacket.ReadShort();
            short Kart = iPacket.ReadShort();
            iPacket.ReadShort();
            short KartSN = iPacket.ReadShort();
            using (OutPacket outPacket = new OutPacket("PrUseSocketItem"))
            {
                outPacket.WriteInt(0);
                outPacket.WriteShort(Item);
                outPacket.WriteShort(Item_Id);
                outPacket.WriteShort(Kart);
                outPacket.WriteShort(KartSN);
                outPacket.WriteShort(KartSN);
                outPacket.WriteShort(2);
                outPacket.WriteHexString("00 00 00 00 FF FF 00 00 00 00 00 00 00 00");
                Parent.Client.Send(outPacket);
            }
            using (OutPacket outPacket = new OutPacket("PcSlaveNotice"))
            {
                outPacket.WriteString("使用粒子激活器R直接获得启变佳！");
                Parent.Client.Send(outPacket);
            }
        }
        public void PqUseTuneItem()
        {
            short Item = iPacket.ReadShort();
            short Item_Id = iPacket.ReadShort();
            short Kart = iPacket.ReadShort();
            iPacket.ReadShort();
            short KartSN = iPacket.ReadShort();
            Random random = new Random();
            List<string> numbers = new List<string>();
            if (Item == 5)
            {
                numbers.Add("603");
                numbers.Add("703");
                numbers.Add("903");
            }
            else
            {
                while (numbers.Count < 3)
                {
                    string number = random.Next(1, 10).ToString() + "03";
                    if (!numbers.Contains(number))
                    {
                        numbers.Add(number);
                    }
                }
            }
            KartExcData.AddTuneList(Kart, KartSN, short.Parse(numbers[0]), short.Parse(numbers[1]), short.Parse(numbers[2]));
            TuneSpec.Use_TuneSpec(Kart, KartSN);
            using (OutPacket outPacket = new OutPacket("PrUseTuneItem"))
            {
                outPacket.WriteInt(0);
                outPacket.WriteShort(Item);
                outPacket.WriteShort(Item_Id);
                outPacket.WriteShort(Kart);
                outPacket.WriteShort(KartSN);
                outPacket.WriteShort(0);
                outPacket.WriteShort(short.Parse(numbers[0]));
                outPacket.WriteShort(short.Parse(numbers[1]));
                outPacket.WriteShort(short.Parse(numbers[2]));
                outPacket.WriteHexString("00 00 00 00 00 00 00 00");
                Parent.Client.Send(outPacket);
            }
        }
        public void PqUseResetSocketItem()
        {
            short Item = iPacket.ReadShort();
            short Item_Id = iPacket.ReadShort();
            short Kart = iPacket.ReadShort();
            iPacket.ReadShort();
            short KartSN = iPacket.ReadShort();
            KartExcData.DelTuneList(Kart, KartSN);
            TuneSpec.Use_TuneSpec(Kart, KartSN);
            using (OutPacket outPacket = new OutPacket("PrUseResetSocketItem"))
            {
                outPacket.WriteInt(0);
                outPacket.WriteShort(Item);
                outPacket.WriteShort(Item_Id);
                outPacket.WriteShort(Kart);
                outPacket.WriteShort(KartSN);
                outPacket.WriteHexString("22 00 4C 00 01 00 01 00 00 00 00 00 FF FF 00 00 00 00 00 00 00 00");
                Parent.Client.Send(outPacket);
            }
        }
        public void PqEquipTuningExPacket()
        {
            short Item = iPacket.ReadShort();
            short Item_Id = iPacket.ReadShort();
            short Kart = iPacket.ReadShort();
            short Kart_Id = iPacket.ReadShort();
            short SN = iPacket.ReadShort();
            KartExcData.AddPlantList(Kart_Id, SN, Item, Item_Id);
            TuneSpec.Use_PlantSpec(Kart_Id, SN);
            using (OutPacket outPacket = new OutPacket("PrEquipTuningPacket"))
            {
                outPacket.WriteByte(1);
                outPacket.WriteShort(SN);
                outPacket.WriteShort(SN);
                outPacket.WriteShort(Kart_Id);
                outPacket.WriteShort(Item);
                outPacket.WriteShort(Item_Id);
                Parent.Client.Send(outPacket);
            }
        }
        public void PqUnequipXPartsItem()
        {
            short Kart = iPacket.ReadShort();
            short SN = iPacket.ReadShort();
            short item = iPacket.ReadShort();
            using (OutPacket outPacket = new OutPacket("PrUnequipXPartsItem"))
            {
                outPacket.WriteInt(0);
                outPacket.WriteShort(Kart);
                outPacket.WriteShort(SN);
                outPacket.WriteShort(item);
                Parent.Client.Send(outPacket);
            }
            KartExcData.AddPartsList(Kart, SN, item, 0, 0, 0);
        }
        public void PqEquipXPartsItem()
        {
            short Kart = iPacket.ReadShort();
            short KartSN = iPacket.ReadShort();
            short Item_Cat_Id = iPacket.ReadShort();
            short Item_Id = iPacket.ReadShort();
            short Quantity = iPacket.ReadShort();
            short Unk1 = iPacket.ReadShort();
            byte Grade = iPacket.ReadByte();
            byte Unk2 = iPacket.ReadByte();
            short PartsValue = iPacket.ReadShort();
            short Unk3 = iPacket.ReadShort();
            using (OutPacket outPacket = new OutPacket("PrEquipXPartsItem"))
            {
                outPacket.WriteInt(0);
                outPacket.WriteShort(Kart);
                outPacket.WriteShort(KartSN);
                outPacket.WriteShort(Item_Cat_Id);
                outPacket.WriteShort(Item_Id);
                outPacket.WriteShort(Quantity);
                outPacket.WriteShort(Unk1);
                outPacket.WriteByte(Grade);
                outPacket.WriteByte(Unk2);
                outPacket.WriteShort(PartsValue);
                outPacket.WriteShort(Unk3);
                Parent.Client.Send(outPacket);
            }
            KartExcData.AddPartsList(Kart, KartSN, Item_Cat_Id, Item_Id, Grade, PartsValue);
            Console.WriteLine("ClientSession : Kart: {0}, KartSN: {1}, Item: {2}:{3}, Quantity: {4}, Grade: {5}, PartsValue: {6}", Kart, KartSN, Item_Cat_Id, Item_Id, Quantity, Grade, PartsValue);
            TuneSpec.Use_PartsSpec(Kart, KartSN);
        }
        public void PqGetTrainingMission()
        {
            int type = iPacket.ReadInt();
            uint track = iPacket.ReadUInt();
            //PrGetTrainingMission 00 08 B7 51 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 
            using (OutPacket outPacket = new OutPacket("PrGetTrainingMission"))
            {
                outPacket.WriteInt(type);
                outPacket.WriteInt(0);
                outPacket.WriteInt(0);
                outPacket.WriteInt(0);
                Parent.Client.Send(outPacket);
            }
        }
        public void PqGetDuelMissionBulk()
        {
            using (OutPacket outPacket = new OutPacket("PrGetDuelMissionBulk"))
            {
                outPacket.WriteInt(0);
                outPacket.WriteInt(0);
                outPacket.WriteUShort((ushort)RouterListener.DataTime()[0]);
                outPacket.WriteUShort((ushort)RouterListener.DataTime()[1]);
                outPacket.WriteHexString("0F 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");
                Parent.Client.Send(outPacket);
            }
        }
        public void PqAdjustDuelMissionDifficulty()
        {
            Console.WriteLine("PqAdjustDuelMissionDifficulty: {0}", iPacket);
            int type = iPacket.ReadInt();
            int unk = iPacket.ReadInt();
            using (OutPacket outPacket = new OutPacket("PrAdjustDuelMissionDifficulty"))
            {
                outPacket.WriteInt(type);
                outPacket.WriteInt(unk);
                outPacket.WriteInt(0);
                outPacket.WriteShort(0);
                Parent.Client.Send(outPacket);
            }
        }
        public void PqBlueMarble()
        {
            using (OutPacket outPacket = new OutPacket("PrBlueMarble"))
            {
                outPacket.WriteHexString("00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");
                Parent.Client.Send(outPacket);
            }
        }
        public void LoRqGetTrackRankPacket()
        {
            uint track = iPacket.ReadUInt();
            byte SpeedType = iPacket.ReadByte();
            byte GameType = iPacket.ReadByte();
            using (OutPacket outPacket = new OutPacket("LoRpGetTrackRankPacket"))
            {
                outPacket.WriteUInt(track);
                outPacket.WriteByte(SpeedType);
                outPacket.WriteByte(GameType);
                outPacket.WriteInt(0);
                Parent.Client.Send(outPacket);
            }
        }
        public void PqFavoriteTrackUpdate()
        {
            iPacket.ReadByte();
            int tracks = iPacket.ReadInt(); //赛道数量
            for (int i = 0; i < tracks; i++)
            {
                short theme = iPacket.ReadShort(); //主题代码
                int track = iPacket.ReadInt(); //赛道代码
                byte Add_Del = iPacket.ReadByte(); //1添加，2删除
                if (Add_Del == 1)
                {
                    FavoriteItem.Favorite_Track_Add(theme, track);
                }
                else if (Add_Del == 2)
                {
                    FavoriteItem.Favorite_Track_Del(theme, track);
                }
            }
        }
        public void LoRqDecLucciPacket()
        {
            iPacket.ReadByte();
            uint Lucci = iPacket.ReadUInt();
            SetRider.Lucci -= Lucci;
            SetGameData.Save_TimeAttackDecLucci();
        }
        public void PqStartTimeAttack()
        {
            StartGameData.StartTimeAttack_Unk1 = iPacket.ReadInt();
            StartGameData.StartTimeAttack_Unk2 = iPacket.ReadInt();
            StartGameData.StartTimeAttack_Track = iPacket.ReadUInt();
            StartGameData.StartTimeAttack_SpeedType = iPacket.ReadByte();
            StartGameData.StartTimeAttack_GameType = iPacket.ReadByte();
            StartGameData.Kart_id = iPacket.ReadShort();
            StartGameData.FlyingPet_id = iPacket.ReadShort();
            StartGameData.StartTimeAttack_StartType = iPacket.ReadByte();
            StartGameData.StartTimeAttack_Unk3 = iPacket.ReadInt();
            StartGameData.StartTimeAttack_Unk4 = iPacket.ReadInt();
            StartGameData.StartTimeAttack_Unk5 = iPacket.ReadByte();
            StartGameData.StartTimeAttack_RankingTimaAttackType = iPacket.ReadByte();
            StartGameData.StartTimeAttack_TimaAttackMpdeType = iPacket.ReadByte();
            StartGameData.StartTimeAttack_TimaAttackMpde = iPacket.ReadInt();
            StartGameData.StartTimeAttack_RandomTrackGameType = iPacket.ReadByte();
            TrackName trackName = (TrackName)StartGameData.StartTimeAttack_Track;
            if (StartGameData.StartTimeAttack_TimaAttackMpdeType == 1)
            {
                SetRider.Lucci -= 1000;
                SetGameData.Save_TimeAttackDecLucci();
            }
            Console.WriteLine("StartTimeAttack: {0} / {1} / {2} / {3} / {4} / {5} / {6} / {7}", StartGameData.StartTimeAttack_SpeedType, StartGameData.StartTimeAttack_GameType, StartGameData.Kart_id, StartGameData.FlyingPet_id, trackName, StartGameData.StartTimeAttack_StartType, StartGameData.StartTimeAttack_RankingTimaAttackType, StartGameData.StartTimeAttack_TimaAttackMpdeType);
            GameType.StartType = 3;
            RandomTrack.SetGameType();
        }
        public void PqFinishTimeAttack()
        {
            int type = iPacket.ReadInt();
            iPacket.ReadInt();
            GameType.RewardType = iPacket.ReadByte();
            iPacket.ReadInt();
            iPacket.ReadInt();
            iPacket.ReadInt();
            iPacket.ReadInt();
            int Time = iPacket.ReadInt();
            GameType.min = Time / 60000;
            int sec = Time - GameType.min * 60000;
            GameType.sec = sec / 1000;
            GameType.mil = Time % 1000;
            if (GameType.RewardType == 0)
            {
                GameType.TimeAttack_RP = 10;
                GameType.TimeAttack_Lucci = 20;
            }
            else if (GameType.RewardType == 1)
            {
                GameType.TimeAttack_RP = 20;
                GameType.TimeAttack_Lucci = 50;
            }
            SetRider.RP += GameType.TimeAttack_RP;
            SetRider.Lucci += GameType.TimeAttack_Lucci;
            TrackName trackName = (TrackName)StartGameData.StartTimeAttack_Track;
            Console.WriteLine("FinishTimeAttack: {0} / {1} / {2} / {3} / {4}:{5}:{6}", GameType.RewardType, GameType.TimeAttack_RP, GameType.TimeAttack_Lucci, trackName, GameType.min, GameType.sec, GameType.mil);
            using (OutPacket outPacket = new OutPacket("PrFinishTimeAttack"))
            {
                outPacket.WriteInt(type);
                outPacket.WriteHexString("00 00 00 00 00 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 00");
                outPacket.WriteInt(GameType.TimeAttack_RP);//RP
                outPacket.WriteUInt(GameType.TimeAttack_Lucci);//LUCCI
                Parent.Client.Send(outPacket);
            }
            SetGameData.Save_RewardTimeAttack();
            SetGameData.Save_RecordTimeAttack();
        }
        public void PqRewardTimeAttack()
        {
            byte RewardType = iPacket.ReadByte();
            int RP = iPacket.ReadInt();
            int Lucci = iPacket.ReadInt();
            int TimeAttack_StartTicks = iPacket.ReadInt();
            uint Track = iPacket.ReadUInt();
            TrackName trackName = (TrackName)Track;
            Console.WriteLine("RewardTimeAttack : ResultType: {0}, RP: {1}, Lucci: {2}, Track: {3}", RewardType, RP, Lucci, trackName);
            if (RewardType == 0)
            {
                SetRider.RP += 10;
                SetRider.Lucci += 20;
            }
            else if (RewardType == 1)
            {
                SetRider.RP += 20;
                SetRider.Lucci += 50;
            }
            SetGameData.Save_RewardTimeAttack();
        }
        public void LoRqUseItemPacket()
        {
            short ItemType = iPacket.ReadShort();
            short Type = iPacket.ReadShort();
            SetRider.SlotChanger = iPacket.ReadShort();
            if (Type == 1)
            {
                SetGameData.Save_SlotChanger();
            }
        }
        public void PqQuestUX2ndPacket()
        {
            GameSupport.PrQuestUX2ndPacket();
        }
        public void PqGameOutRunUX2ndClearPacket()
        {
            using (OutPacket outPacket = new OutPacket("PrGameOutRunUX2ndClearPacket"))
            {
                outPacket.WriteInt(0);
                Parent.Client.Send(outPacket);
            }
        }
        public void PqGetTrainingMissionReward()
        {
            Console.WriteLine("PqGetTrainingMissionReward: {0}", iPacket);
        }
        public void SpRqBingoGachaPacket()
        {
            int BingoType = iPacket.ReadInt();
            if (BingoType == 0)
            {
                using (OutPacket outPacket = new OutPacket("SpRpBingoGachaPacket"))
                {
                    outPacket.WriteInt(BingoType);
                    for (int i = 0; i < 5; i++)
                    {
                        outPacket.WriteInt(0);
                    }
                    outPacket.WriteByte(0);
                    outPacket.WriteByte(0);
                    outPacket.WriteByte(0);
                    Parent.Client.Send(outPacket);
                }
            }
            else if (BingoType == 4)
            {
                using (OutPacket outPacket = new OutPacket("SpRpBingoGachaPacket"))
                {
                    outPacket.WriteInt(BingoType);
                    for (int i = 0; i < 5; i++)
                    {
                        outPacket.WriteInt(0);
                    }
                    outPacket.WriteByte(0);
                    outPacket.WriteByte(0);
                    outPacket.WriteByte(0);
                    Parent.Client.Send(outPacket);
                }
            }
        }
        public void PqCheckMyClubStatePacket()
        {
            GameSupport.PrCheckMyClubStatePacket();
        }
        public void PqCheckMyLeaveDatePacket()
        {
            using (OutPacket outPacket = new OutPacket("PrCheckMyLeaveDatePacket"))
            {
                outPacket.WriteInt(0);
                Parent.Client.Send(outPacket);
            }
        }
        public void PqGetUserWaitingJoinClubPacket()
        {
            using (OutPacket outPacket = new OutPacket("PrGetUserWaitingJoinClubPacket"))
            {
                outPacket.WriteInt(1);
                outPacket.WriteInt(0);
                outPacket.WriteInt(0);
                Parent.Client.Send(outPacket);
            }
        }
        public void PqCheckCreateClubConditionPacket()
        {
            using (OutPacket outPacket = new OutPacket("PrCheckCreateClubConditionPacket"))
            {
                outPacket.WriteInt(3);
                Parent.Client.Send(outPacket);
            }
        }
        public void PqClubChannelSwitch()
        {
            using (OutPacket outPacket = new OutPacket("PrInitClubPacket"))
            {
                outPacket.WriteInt(0);
                Parent.Client.Send(outPacket);
            }
        }
        public void PqInitClubInfoPacket()
        {
            using (OutPacket outPacket = new OutPacket("PrInitClubInfoPacket"))
            {
                outPacket.WriteHexString("50 F7 EA 07 00 00 00 00 00 00 FA DC 98 00 00 00 00 00 02 00 00 00 50 F7 EA 07 00 00 00 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 02 00 00 00 0F 00 00 00 00 00 00 00");
                Parent.Client.Send(outPacket);
            }
        }
        public void PqSearchClubListPacket()
        {
            using (OutPacket outPacket = new OutPacket("PrSearchClubListPacket"))
            {
                outPacket.WriteHexString("0C 00 00 00 7F 3D 00 00 04 00 00 00 1C 75 C7 8F 1D 52 4B 60 05 F4 01 00 00 FF FF FF FF 00 00 00 00 40 4B 4C 00 07 00 00 00 00 00 00 00 07 00 00 00 0B 4E E8 96 56 00 52 00 61 00 69 00 6E 00 64 00 00 00 E7 AA 50 46 0F 00 00 00 A1 6C C0 4E 48 4E 79 72 7F 95 2C 00 31 5C 2F 66 65 55 FD 90 1A 4F B9 70 2E 00 2E 00 2E 00 00 05 C4 D6 6E 01 5D 37 00 00 08 00 00 00 D0 67 9D 5B 1C 64 EB 77 C5 60 E5 5D 5C 4F A4 5B 05 2C 01 00 00 FF FF FF FF 00 00 00 00 C0 C6 2D 00 1C 01 00 00 00 00 00 00 06 00 00 00 13 4E 1A 4E 37 52 5A 80 50 4E E8 90 1B 00 00 00 A3 AA B7 2A 4C 00 00 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 3D 00 3D 00 3D 00 3D 00 D1 8D D1 8D 94 54 01 4E 66 8F 20 00 D8 98 FB 79 3D 00 3D 00 3D 00 3D 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 A4 7F 3A 00 37 00 39 00 30 00 30 00 33 00 33 00 36 00 31 00 37 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 7D 59 0B 67 CB 53 00 4E 77 8D D8 98 00 04 8F 1C 4E 00 04 00 00 00 07 00 00 00 59 00 78 00 36 4E 54 00 65 00 61 00 6D 00 05 2C 01 00 00 FF FF FF FF 00 00 00 00 C0 C6 2D 00 92 01 00 00 00 00 00 00 05 00 00 00 59 00 78 00 36 4E 1F 96 7F 95 24 00 00 00 33 AA 99 2A 46 00 00 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 28 4E E0 65 50 96 66 8F 1F 96 28 4E 20 00 66 8F 1F 96 03 80 38 68 36 65 BA 4E 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 A5 63 85 5F 2F 00 03 80 38 68 71 00 A4 7F 3B 00 34 00 39 00 39 00 33 00 33 00 33 00 33 00 31 00 31 00 20 00 00 04 DA 93 27 00 DF 21 00 00 04 00 00 00 28 4E 18 7F 2F 54 28 4E 05 F4 01 00 00 FF FF FF FF 00 00 00 00 40 4B 4C 00 70 01 00 00 00 00 00 00 04 00 00 00 CC 51 75 70 36 4E 63 00 14 00 00 00 47 AA EF 2E 2F 00 00 00 2E 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 3C 00 20 00 20 00 20 00 22 6B 20 00 11 7B 20 00 C5 60 20 00 82 59 20 00 E7 65 20 00 2D 00 20 00 27 84 20 00 8F 75 20 00 13 9B 20 00 F2 5D 20 00 91 65 20 00 20 00 3E 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 00 05 50 6B 20 00 64 3E 00 00 04 00 00 00 52 00 69 00 63 00 68 00 05 2C 01 00 00 FF FF FF FF 00 00 00 00 C0 C6 2D 00 8B 01 00 00 00 00 00 00 07 00 00 00 52 00 69 00 63 00 68 00 CE 8F A8 60 65 67 60 00 00 00 F4 AA CF 4E 5E 00 00 00 20 00 20 00 20 00 20 00 20 00 52 00 69 00 63 00 68 00 94 4E A7 7E 66 8F 1F 96 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 22 6B CE 8F A8 60 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 3B 4E A9 73 E0 65 50 96 20 00 20 00 20 00 20 00 20 00 20 00 66 8F 1F 96 03 80 38 68 A5 63 85 5F A4 7F 3A 00 35 00 32 00 37 00 31 00 32 00 36 00 39 00 38 00 37 00 00 04 3C 45 14 00 7A 49 00 00 05 00 00 00 08 54 A6 7E 36 65 CF 85 B6 5B 05 2C 01 00 00 FF FF FF FF 00 00 00 00 C0 C6 2D 00 75 00 00 00 00 00 00 00 06 00 00 00 48 00 79 00 2C 7B 00 4E 73 59 4C 80 23 00 00 00 5D AB AB 36 05 00 00 00 5E 97 F7 8B FF 52 65 51 2E 00 00 04 D4 1E 11 00 8F 55 00 00 06 00 00 00 28 4E 5D 4E 29 59 FD 63 08 67 28 4E 05 2C 01 00 00 FF FF FF FF 00 00 00 00 C0 C6 2D 00 8F 01 00 00 00 00 00 00 06 00 00 00 3D 63 1F 66 B8 82 50 6C E5 82 36 4E 30 00 00 00 A4 AB 44 52 07 00 00 00 66 8F 1F 96 82 66 F6 65 0D 4E 36 65 BA 4E 00 04 90 6D 10 00 AD 0B 00 00 06 00 00 00 28 4E A2 7E D7 65 66 8F 1F 96 28 4E 05 2C 01 00 00 FF FF FF FF 00 00 00 00 C0 C6 2D 00 75 00 00 00 00 00 00 00 06 00 00 00 A2 7E D7 65 85 8D A7 7E 66 5B 38 97 18 00 00 00 33 AA 4C 4A 25 00 00 00 65 51 1F 96 81 89 42 6C 3A 00 66 8F 93 5E E5 62 09 67 A2 7E D7 65 68 51 FB 7C 66 8F 86 8F 2C 00 3A 7F 00 4E 0D 4E EF 53 2C 00 26 7B 08 54 81 89 42 6C 84 76 A0 52 A4 7F 31 00 32 00 39 00 30 00 34 00 33 00 33 00 37 00 32 00 00 04 EC 39 10 00 75 01 00 00 06 00 00 00 28 4E 0D 54 1F 66 66 8F 1F 96 28 4E 05 F4 01 00 00 FF FF FF FF 00 00 00 00 40 4B 4C 00 95 01 00 00 00 00 00 00 05 00 00 00 0D 54 1F 66 01 80 05 5E E5 54 33 01 00 00 33 AA 6B 2B 54 00 00 00 0D 54 1F 66 F1 4F 50 4E E8 90 2F 66 CC 53 94 4E A7 7E CC 53 EE 4F F1 4F 50 4E E8 90 20 00 DE 7A 1F 90 3B 4E 53 62 53 00 32 00 20 00 53 90 77 51 3A 4E 4E 4F 1F 90 CC 53 81 79 8C 54 26 5E 01 95 20 00 16 59 A4 4E A4 7F A4 7F F7 53 3A 4E 33 00 31 00 36 00 36 00 34 00 31 00 32 00 30 00 30 00 20 00 22 6B CE 8F FF 7E 72 82 A9 73 B6 5B A0 52 65 51 20 00 81 89 42 6C 39 65 0D 54 20 00 D1 53 B0 73 28 75 85 8F A9 52 D1 8D 66 8F 20 00 05 6E 06 74 20 00 0C 5E 1B 67 27 59 B6 5B 92 4E F8 76 D1 76 63 77 3E 4E A5 62 00 05 06 82 09 00 31 15 00 00 06 00 00 00 28 4E 64 8D DA 8B 4B 4E C3 5F 28 4E 05 2C 01 00 00 FF FF FF FF 00 00 00 00 C0 C6 2D 00 71 01 00 00 00 00 00 00 06 00 00 00 64 8D DA 8B 28 4E 6B 84 A6 82 28 4E 1C 00 00 00 36 AA 63 24 4C 00 00 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 00 4E 47 72 64 8D DA 8B 4B 4E C3 5F 20 00 B3 7E B0 65 A4 7F 31 00 30 00 35 00 36 00 39 00 31 00 39 00 38 00 36 00 31 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 2A 67 39 65 0D 54 00 4E 8B 5F 0D 4E 88 4E 1A 90 C7 8F 20 00 20 00 20 00 3C 68 0F 5F 20 00 20 00 20 00 64 8D DA 8B 28 4E 78 00 78 00 28 4E 00 04 C5 1A 05 00 F7 32 00 00 08 00 00 00 50 00 6C 00 61 00 79 00 43 00 6C 00 75 00 62 00 05 2C 01 00 00 FF FF FF FF 00 00 00 00 C0 C6 2D 00 75 00 00 00 00 00 00 00 06 00 00 00 50 00 6C 00 61 00 79 00 1C 4E CE 98 A0 00 00 00 81 AA 71 25 49 00 00 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 50 00 6C 00 61 00 79 00 20 00 2D 00 20 00 43 00 6C 00 75 00 62 00 20 00 2D 00 20 00 46 00 6F 00 72 00 65 00 76 00 65 00 72 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 20 00 00 04 9A E7 03 00 6B 20 00 00 03 00 00 00 28 4E 6A 8C 28 4E 05 F4 01 00 00 FF FF FF FF 00 00 00 00 40 4B 4C 00 03 00 00 00 00 00 00 00 02 00 00 00 E4 4E 77 83 3F 00 00 00 43 AA E0 01 25 00 00 00 53 90 77 51 66 8F 1F 96 20 00 20 00 20 00 00 97 81 89 39 65 0D 54 20 00 20 00 20 00 A5 63 85 5F A4 7F 20 00 31 00 20 00 31 00 20 00 35 00 20 00 39 00 20 00 30 00 20 00 35 00 20 00 33 00 20 00 35 00 20 00 32 00 20 00 36 00 00 05 CF 9C 03 00 01");
                Parent.Client.Send(outPacket);
            }
        }
        public void PqGetClubListCountPacket()
        {
            using (OutPacket outPacket = new OutPacket("PrGetClubListCountPacket"))
            {
                outPacket.WriteHexString("7F F7 00 00 01 00 00 00");
                Parent.Client.Send(outPacket);
            }
        }
        public void PqGetClubWaitingCrewCountPacket()
        {
            using (OutPacket outPacket = new OutPacket("PrGetClubWaitingCrewCountPacket"))
            {
                outPacket.WriteHexString("32 00 00 00 32 00 00 00");
                Parent.Client.Send(outPacket);
            }
        }
        public void SpRqLotteryPacket()
        {
            short Lottery_Item = iPacket.ReadShort();
            byte Unk = iPacket.ReadByte();
            int Type = iPacket.ReadInt();
            GameSupport.SpRpLotteryPacket();
        }
        public void PqEventBuyCount()
        {
            EventBuyCount.BuyCount = iPacket.ReadInt();
            if (EventBuyCount.BuyCount >= 1) EventBuyCount.ShopItem1 = iPacket.ReadInt();
            if (EventBuyCount.BuyCount >= 2) EventBuyCount.ShopItem2 = iPacket.ReadInt();
            if (EventBuyCount.BuyCount >= 3) EventBuyCount.ShopItem3 = iPacket.ReadInt();
            if (EventBuyCount.BuyCount >= 4) EventBuyCount.ShopItem4 = iPacket.ReadInt();
            if (EventBuyCount.BuyCount >= 5) EventBuyCount.ShopItem5 = iPacket.ReadInt();
            if (EventBuyCount.BuyCount >= 6) EventBuyCount.ShopItem6 = iPacket.ReadInt();
            if (EventBuyCount.BuyCount >= 7) EventBuyCount.ShopItem7 = iPacket.ReadInt();
            if (EventBuyCount.BuyCount >= 8) EventBuyCount.ShopItem8 = iPacket.ReadInt();
            if (EventBuyCount.BuyCount >= 9) EventBuyCount.ShopItem9 = iPacket.ReadInt();
            if (EventBuyCount.BuyCount >= 10) EventBuyCount.ShopItem10 = iPacket.ReadInt();
            if (EventBuyCount.BuyCount >= 11) EventBuyCount.ShopItem11 = iPacket.ReadInt();
            if (EventBuyCount.BuyCount >= 12) EventBuyCount.ShopItem12 = iPacket.ReadInt();
            if (EventBuyCount.BuyCount >= 13) EventBuyCount.ShopItem13 = iPacket.ReadInt();
            if (EventBuyCount.BuyCount >= 14) EventBuyCount.ShopItem14 = iPacket.ReadInt();
            if (EventBuyCount.BuyCount >= 15) EventBuyCount.ShopItem15 = iPacket.ReadInt();
            if (EventBuyCount.BuyCount >= 16) EventBuyCount.ShopItem16 = iPacket.ReadInt();
            if (EventBuyCount.BuyCount >= 17) EventBuyCount.ShopItem17 = iPacket.ReadInt();
            if (EventBuyCount.BuyCount >= 18) EventBuyCount.ShopItem18 = iPacket.ReadInt();
            if (EventBuyCount.BuyCount >= 19) EventBuyCount.ShopItem19 = iPacket.ReadInt();
            if (EventBuyCount.BuyCount >= 20) EventBuyCount.ShopItem20 = iPacket.ReadInt();
            EventBuyCount.PrEventBuyCount();
        }
        public void PqGetRiderTaskContext()
        {
            using (OutPacket outPacket = new OutPacket("PrGetRiderTaskContext"))
            {
                outPacket.WriteInt(0);
                Parent.Client.Send(outPacket);
            }
        }
        public void PqVersusModeRankOnePacket()
        {
            using (OutPacket outPacket = new OutPacket("PrVersusModeRankOnePacket"))
            {
                outPacket.WriteHexString("00 FF FF FF FF FF FF FF FF");
                Parent.Client.Send(outPacket);
            }
        }
        public void PqRiderSchoolDataPacket()
        {
            //RiderSchool.PrRiderSchoolData();
            using (OutPacket outPacket = new OutPacket("PrRiderSchoolDataPacket"))
            {
                outPacket.WriteByte(6);//라이센스 등급
                outPacket.WriteByte(42);//마지막 클리어
                outPacket.WriteUShort((ushort)RouterListener.DataTime()[0]);
                outPacket.WriteUShort((ushort)RouterListener.DataTime()[1]);
                outPacket.WriteInt(0);
                outPacket.WriteByte(0);
                RouterListener.MySession.Client.Send(outPacket);
            }
        }
        public void PqRiderSchoolProPacket()
        {
            //RiderSchool.PrRiderSchoolPro();
            int stepcount = 6;
            int remainder = RouterListener.DataTime()[2] % stepcount;
            if (remainder == 0) remainder = stepcount;
            byte step;
            switch (remainder)
            {
                case 1:
                    step = 31;
                    break;
                case 2:
                    step = 33;
                    break;
                case 3:
                    step = 35;
                    break;
                case 4:
                    step = 37;
                    break;
                case 5:
                    step = 39;
                    break;
                case 6:
                    step = 41;
                    break;
                default:
                    step = 31;
                    break;
            }
            using (OutPacket oPacket = new OutPacket("PrRiderSchoolProPacket"))
            {
                oPacket.WriteByte(1);//엠블럼 체크
                oPacket.WriteByte(step);
                oPacket.WriteByte(6);
                oPacket.WriteByte((byte)(step + 1));
                oPacket.WriteInt(0);
                oPacket.WriteInt(0);
                oPacket.WriteInt(0);
                RouterListener.MySession.Client.Send(oPacket);
            }
        }
        public void PqStartRiderSchool()
        {
            RiderSchool.PrStartRiderSchool();
        }
        public void PqRiderSchoolExpiredCheck()
        {
            using (OutPacket outPacket = new OutPacket("PrRiderSchoolExpiredCheck"))
            {
                outPacket.WriteBytes(new byte[10]);
                Parent.Client.Send(outPacket);
            }
        }
        public void PqRankerInfoPacket()
        {
            using (OutPacket outPacket = new OutPacket("PrRankerInfoPacket"))
            {
                outPacket.WriteByte(0);
                outPacket.WriteByte(SetRider.Ranker);
                outPacket.WriteHexString("00 00 C8 42 00 00 00 00");
                Parent.Client.Send(outPacket);
            }
        }
        public void PqRequestExtradata()
        {
            using (OutPacket outPacket = new OutPacket("PrRequestExtradata"))
            {
                outPacket.WriteShort(0);
                Parent.Client.Send(outPacket);
            }
        }
        public void ChRequestChStaticRequestPacket()
        {
            GameSupport.ChRequestChStaticReplyPacket();
        }
        public void PqDynamicCommand()
        {
            GameSupport.PrDynamicCommand();
        }
        public void PqPubCommandPacket()
        {
            using (OutPacket outPacket = new OutPacket("PrPubCommandPacket"))
            {
                outPacket.WriteInt(0);
                outPacket.WriteInt(0);
                Parent.Client.Send(outPacket);
            }
        }
        public void PqWebEventCompleteCheckPacket()
        {
            using (OutPacket outPacket = new OutPacket("PrWebEventCompleteCheckPacket"))
            {
                Parent.Client.Send(outPacket);
            }
        }
        public void SpRqKoinBalance()
        {
            using (OutPacket outPacket = new OutPacket("SpRpKoinBalance"))
            {
                outPacket.WriteUInt(SetRider.Koin);
                outPacket.WriteUInt(0);
                Parent.Client.Send(outPacket);
            }
        }
        public void PqFavoriteTrackMapGet()
        {
            FavoriteItem.Favorite_Track();
        }
        public void PqGetFavoriteChannel()
        {
            using (OutPacket outPacket = new OutPacket("PrGetFavoriteChannel"))
            {
                outPacket.WriteHexString("02 00 00 00 00 00 00 00 00 00 01 00");
                Parent.Client.Send(outPacket);
            }
        }
        public void PqKartPassInitPacket()
        {
            using (OutPacket outPacket = new OutPacket("PrKartPassInitPacket"))
            {
                outPacket.WriteInt(3);
                outPacket.WriteInt(0);
                Parent.Client.Send(outPacket);
            }
        }
        public void SpRqGetCashInventoryPacket()
        {
            using (OutPacket outPacket = new OutPacket("SpRpGetCashInventoryPacket"))
            {
                outPacket.WriteInt(0);
                outPacket.WriteByte(0);
                Parent.Client.Send(outPacket);
            }
        }
        public void SpRqRemainCashPacket()
        {
            using (OutPacket outPacket = new OutPacket("SpRpRemainCashPacket"))
            {
                outPacket.WriteUInt(0);
                outPacket.WriteUInt(0);
                Parent.Client.Send(outPacket);
            }
        }
        public void SpRqRemainTcCashPacket()
        {
            using (OutPacket outPacket = new OutPacket("SpRpRemainTcCashPacket"))
            {
                outPacket.WriteUInt(99);
                outPacket.WriteUInt(0);
                Parent.Client.Send(outPacket);
            }
        }
        public void SpReqNormalShopBuyItemPacket()
        {
            using (OutPacket outPacket = new OutPacket("SpRepBuyItemPacket"))
            {
                outPacket.WriteHexString("01 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");
                Parent.Client.Send(outPacket);
            }
        }
        public void SpReqItemPresetShopBuyItemPacket()
        {
            SpReqNormalShopBuyItemPacket();
        }
        public void PqGetCurrentRid()
        {
            using (OutPacket outPacket = new OutPacket("PrGetCurrentRid"))
            {
                outPacket.WriteInt(0);
                Parent.Client.Send(outPacket);
            }
        }
        public void PqGetMyCouponList()
        {
            using (OutPacket outPacket = new OutPacket("PrGetMyCouponList"))
            {
                outPacket.WriteInt(0);
                Parent.Client.Send(outPacket);
            }
        }
        public void PqDisassembleFeeInfo()
        {
            using (OutPacket outPacket = new OutPacket("PrDisassembleFeeInfo"))
            {
                outPacket.WriteHexString("00 00 00 00 06 00 00 00 00 00 E8 03 01 00 F4 01 00 00 E8 03 01 00 F4 01 00 00 E8 03 01 00 F4 01");
                Parent.Client.Send(outPacket);
            }
            using (OutPacket outPacket = new OutPacket("PcSlaveNotice"))
            {
                outPacket.WriteString("分解卡丁车可以重置此车装备的部件！");
                Parent.Client.Send(outPacket);
            }
        }
        public void PqRequestExchangeInitPacket()
        {
            using (OutPacket outPacket = new OutPacket("PrRequestExchangeInitPacket"))
            {
                outPacket.WriteHexString("01 03 00 00 00 F4 01 00 00 01 00 00 00 02 00 00 00 03 00 00 00");
                Parent.Client.Send(outPacket);
            }
        }
        public void PqRequestPeriodExchangeInitPacket()
        {
            using (OutPacket outPacket = new OutPacket("PrRequestPeriodExchangeInitPacket"))
            {
                outPacket.WriteBytes(new byte[22]);
                Parent.Client.Send(outPacket);
            }
        }
        public void SpRqEnterRewardBoxStage()
        {
            using (OutPacket outPacket = new OutPacket("SpRpEnterRewardBoxStage"))
            {
                outPacket.WriteInt(0);
                outPacket.WriteInt(0);
                outPacket.WriteByte(1);
                Parent.Client.Send(outPacket);
            }
        }
        public void SpRqExitRewardBoxStage()
        {
        }
        public void SpRqGetGiftListIncomingPacket()
        {
            using (OutPacket outPacket = new OutPacket("SpRpGetGiftListIncomingPacket"))
            {
                outPacket.WriteInt(0);
                outPacket.WriteInt(0);
                outPacket.WriteInt(0);
                Parent.Client.Send(outPacket);
            }
        }
        public void SpRqGetGiftListReceivedPacket()
        {
            using (OutPacket outPacket = new OutPacket("SpRpGetGiftListReceivedPacket"))
            {
                outPacket.WriteInt(0);
                Parent.Client.Send(outPacket);
            }
        }
        public void PqGetCompetitiveRankInfo()
        {
            using (OutPacket outPacket = new OutPacket("PrGetCompetitiveRankInfo"))
            {
                outPacket.WriteHexString("01 00 00 00 00 FF 00 00 00 00 00 00 00 00 00 00 00 00");
                Parent.Client.Send(outPacket);
            }
        }
        public void PqGetCompetitiveSlotInfo()
        {
            using (OutPacket outPacket = new OutPacket("PrGetCompetitiveSlotInfo"))
            {
                outPacket.WriteInt(0);
                Parent.Client.Send(outPacket);
            }
        }
        public void PqGetCompetitiveCount()
        {
            using (OutPacket outPacket = new OutPacket("PrGetCompetitiveCount"))
            {
                outPacket.WriteHexString("B3 02 52 1B 00 00 B4 02 54 1B 00 00 B9 02 82 1B 00 00");
                Parent.Client.Send(outPacket);
            }
        }
        public void PqSearchCompetitiveRankPacket()
        {
            using (OutPacket outPacket = new OutPacket("PrSearchCompetitiveRankPacket"))
            {
                outPacket.WriteInt(0);
                outPacket.WriteInt(0);
                Parent.Client.Send(outPacket);
            }
        }
        public void PqGetCompetitivePreRankPacket()
        {
            using (OutPacket outPacket = new OutPacket("PrGetCompetitivePreRankPacket"))
            {
                outPacket.WriteInt(0);
                outPacket.WriteInt(0);
                Parent.Client.Send(outPacket);
            }
        }
        public void RmRequestEmblemsPacket()
        {
            Emblem.RmOwnerEmblemPacket();
        }
        public void RmRqUpdateMainEmblemPacket()
        {
            SetRider.Emblem1 = iPacket.ReadShort();
            SetRider.Emblem2 = iPacket.ReadShort();
            using (OutPacket outPacket = new OutPacket("RmRpUpdateMainEmblemPacket"))
            {
                outPacket.WriteByte(1);
                outPacket.WriteByte(0);
                Parent.Client.Send(outPacket);
            }
            SetGameData.Save_Emblem();
        }
        public void PqSyncDictionaryInfoPacket()
        {
            int Dictionary = iPacket.ReadInt();
            using (OutPacket outPacket = new OutPacket("PrSyncDictionaryInfoPacket"))
            {
                outPacket.WriteInt(1);
                outPacket.WriteInt(1);
                outPacket.WriteInt(0);
                outPacket.WriteInt(0);
                outPacket.WriteInt(0);
                outPacket.WriteInt(0);
                outPacket.WriteInt(0);
                outPacket.WriteInt(0);
                Parent.Client.Send(outPacket);
            }
        }
        //public void PqGetDictionaryRewardInfoPacket()
        //{
        //}
        public void PqNewCareerListPacket()
        {
            using (OutPacket outPacket = new OutPacket("PrNewCareerListPacket"))
            {
                for (int i = 0; i < 5; i++)
                {
                    outPacket.WriteInt(0);
                }
                Parent.Client.Send(outPacket);
            }
        }
        public void LoRqDeleteItemPacket()
        {
            iPacket.ReadInt();
            iPacket.ReadInt();
            iPacket.ReadInt();
            iPacket.ReadShort();
            short ItemType = iPacket.ReadShort();
            short ItemID = iPacket.ReadShort();
            short SN = iPacket.ReadShort();
            using (OutPacket outPacket = new OutPacket("LoRpDeleteItemPacket"))
            {
                Parent.Client.Send(outPacket);
            }
            if (ItemType == 3)
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(@"Profile\NewKart.xml");
                XmlElement elementToRemove = doc.SelectSingleNode("//Kart[@id='" + ItemID + "' and @sn='" + SN + "']") as XmlElement;
                if (elementToRemove != null)
                {
                    elementToRemove.ParentNode.RemoveChild(elementToRemove);
                }
                doc.Save(@"Profile\NewKart.xml");
            }
        }
        public void SpRqQueryCoupon()
        {
            using (OutPacket outPacket = new OutPacket("SpRpQueryCoupon"))
            {
                outPacket.WriteInt(1);
                outPacket.WriteInt(0);
                Parent.Client.Send(outPacket);
            }
        }
        public void PqShopCashPage()
        {
            using (OutPacket outPacket = new OutPacket("PrShopCashPage"))
            {
                outPacket.WriteString("https://ripay.nexon.com/Payment/Index");
                Parent.Client.Send(outPacket);
            }
        }
        public void PqShopURLPage()
        {
            int URLPageType = iPacket.ReadInt();
            using (OutPacket outPacket = new OutPacket("PrShopURLPage"))
            {
                outPacket.WriteInt(URLPageType);
                outPacket.WriteString("https://pay.tiancity.com/InnerGame/IndexII.aspx");
                Parent.Client.Send(outPacket);
            }
        }
        public void PqBingoSync()
        {
            using (OutPacket outPacket = new OutPacket("PrBingoSync"))
            {
                outPacket.WriteByte(0);
                outPacket.WriteUShort(0);
                outPacket.WriteUShort(0);
                for (int i = 0; i < 15; i++)
                {
                    outPacket.WriteByte(0);
                }
                Parent.Client.Send(outPacket);
            }
        }
        public void PqEnterKartPassPacket()
        {
            using (OutPacket outPacket = new OutPacket("PrEnterKartPassPacket"))
            {
                outPacket.WriteHexString("00 00 00 00 01 00 00 00 00 00 00 00 00 00 00 00 00 01 00 00 00 00 00 00 00 00 00 00 00");
                Parent.Client.Send(outPacket);
            }
        }
        public void PqKartPassPlayTimePacket()
        {
            using (OutPacket outPacket = new OutPacket("PrKartPassPlayTimePacket"))
            {
                outPacket.WriteInt(0);
                Parent.Client.Send(outPacket);
            }
        }
        public void PqKartPassRewardPacket()
        {
            using (OutPacket outPacket = new OutPacket("PrKartPassRewardPacket"))
            {
                outPacket.WriteHexString("00 00 00 00 00 00 00 00 01 00 00 00 01 00 00 00");
                Parent.Client.Send(outPacket);
            }
        }
        public void PqEnterSeasonPassPacket()
        {
            byte SeasonPassType = iPacket.ReadByte();
            using (OutPacket outPacket = new OutPacket("PrEnterSeasonPassPacket"))
            {
                outPacket.WriteInt(0);
                outPacket.WriteByte(SeasonPassType);
                outPacket.WriteInt(0);
                Parent.Client.Send(outPacket);
            }
        }
        public void PqSeasonPassRewardPacket()
        {
            using (OutPacket outPacket = new OutPacket("PrSeasonPassRewardPacket"))
            {
                outPacket.WriteHexString("00 00 00 00 00 00 00 00 01 00 00 00 01 00 00 00");
                Parent.Client.Send(outPacket);
            }
        }
        public void PqCheckPassword()
        {
            using (OutPacket outPacket = new OutPacket("PrCheckPassword"))
            {
                outPacket.WriteInt(0);
                Parent.Client.Send(outPacket);
            }
        }
        public void PqUnLockedItem()
        {
            int useType = iPacket.ReadInt();
            int stringType = iPacket.ReadInt();
            for (int i = 0; i < useType; i++)
            {
                iPacket.ReadString(false);
            }
            byte Type = iPacket.ReadByte();
            using (OutPacket outPacket = new OutPacket("PrUnLockedItem"))
            {
                outPacket.WriteByte(Type);
                Parent.Client.Send(outPacket);
            }
        }
        public void PqFavoriteItemGet() //즐겨 찾기 목록
        {
            FavoriteItem.Favorite_Item();
        }
        public void PqFavoriteItemUpdate()
        {
            iPacket.ReadByte();
            int j = iPacket.ReadShort();
            iPacket.ReadShort();
            for (int i = 0; i < j; i++)
            {
                short item = iPacket.ReadShort();
                short id = iPacket.ReadShort();
                short sn = iPacket.ReadShort();
                byte Add_Del = iPacket.ReadByte();
                if (Add_Del == 1)
                {
                    FavoriteItem.Favorite_Item_Add(item, id, sn);
                }
                else if (Add_Del == 2)
                {
                    FavoriteItem.Favorite_Item_Del(item, id, sn);
                }
            }
        }
        public void PqLockedItemGet()//아이템 보호
        {
            using (OutPacket outPacket = new OutPacket("PrLockedItemGet"))
            {
                outPacket.WriteInt(0);
                Parent.Client.Send(outPacket);
            }
        }
        public void PqLockedItemUpdate()
        {
        }
        public void PqSimGameSimpleInfoAndRankPacket()
        {
            using (OutPacket outPacket = new OutPacket("PrSimGameSimpleInfoAndRankPacket"))
            {
                outPacket.WriteInt(0);
                outPacket.WriteInt(0);
                outPacket.WriteInt(0);
                outPacket.WriteInt(0);
                Parent.Client.Send(outPacket);
            }
        }
        public void PqSimGameEnterPacket()
        {
            using (OutPacket outPacket = new OutPacket("PrSimGameEnterPacket"))
            {
                outPacket.WriteInt(0);
                Parent.Client.Send(outPacket);
            }
        }
        public void SpRqTimeShopPacket()
        {
            using (OutPacket outPacket = new OutPacket("SpRpTimeShopPacket"))
            {
                outPacket.WriteHexString("00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 FF FF FF FF FF FF FF FF FF FF FF FF FF 47 00 00 00 00 00 47 00 00 00 00 00 00 00 02 00 00 00");
                Parent.Client.Send(outPacket);
            }
        }
        public void PqSecretShopEnterPacket()
        {
            using (OutPacket outPacket = new OutPacket("PrSecretShopEnterPacket"))
            {
                outPacket.WriteHexString("00 FF FF FF FF 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");
                Parent.Client.Send(outPacket);
            }
        }
        public void PqEnterUpgradeGearPacket()
        {
            using (OutPacket outPacket = new OutPacket("PrEnterUpgradeGearPacket"))
            {
                outPacket.WriteHexString("05 00 00 00 03 00 00 00 05 00 00 00 00 00 00 00 00 00 00 00");
                Parent.Client.Send(outPacket);
            }
        }
        public void PqBlockCatchEnterPacket()
        {
            using (OutPacket outPacket = new OutPacket("PrBlockCatchEnterPacket"))
            {
                outPacket.WriteInt(0);
                outPacket.WriteInt(0);
                outPacket.WriteInt(0);
                outPacket.WriteInt(3);
                outPacket.WriteInt(3);
                outPacket.WriteInt(0);
                outPacket.WriteInt(5);
                outPacket.WriteInt(1);
                outPacket.WriteInt(7);
                outPacket.WriteInt(2);
                outPacket.WriteInt(600);
                outPacket.WriteInt(300);
                outPacket.WriteInt(200);
                outPacket.WriteInt(100);
                outPacket.WriteInt(-100);
                Parent.Client.Send(outPacket);
            }
        }
        public void RqEnterFishingStagePacket()
        {
            using (OutPacket outPacket = new OutPacket("RpEnterFishingStagePacket"))
            {
                outPacket.WriteByte(0);
                Parent.Client.Send(outPacket);
            }
        }
        public void PqPcCafeShowcaseCoupon()
        {
            using (OutPacket outPacket = new OutPacket("PrPcCafeShowcaseCoupon"))
            {
                outPacket.WriteInt(0);
                outPacket.WriteInt(0);
                Parent.Client.Send(outPacket);
            }
        }
        public void PqGetRiderCareerSummary()
        {
            using (OutPacket outPacket = new OutPacket("PrGetRiderCareerSummary"))
            {
                outPacket.WriteInt(0);
                outPacket.WriteInt(0);
                Parent.Client.Send(outPacket);
            }
        }
        public void checkSecondAuthenPacket()
        {
            using (OutPacket outPacket = new OutPacket("checkSecondAuthenPacket"))
            {
                outPacket.WriteInt(2);
                outPacket.WriteInt(0);
                Parent.Client.Send(outPacket);
            }
        }
        public void PqTestServerAddItemPacket()
        {
            TestServer.Type = iPacket.ReadShort();
            TestServer.ItemID = iPacket.ReadShort();
            TestServer.Amount = iPacket.ReadShort();
            TestServer.TestServerAddItem();
        }
        public void PqServerTime()
        {
            using (OutPacket outPacket = new OutPacket("PrServerTime"))
            {
                outPacket.WriteUShort((ushort)RouterListener.DataTime()[0]);
                outPacket.WriteUShort((ushort)RouterListener.DataTime()[1]);
                Parent.Client.Send(outPacket);
            }
        }
        public void PqLogin()
        {
            GameDataReset.DataReset();
            using (OutPacket outPacket = new OutPacket("PrLogin"))
            {
                outPacket.WriteInt(0);
                outPacket.WriteUShort((ushort)RouterListener.DataTime()[0]);
                outPacket.WriteUShort((ushort)RouterListener.DataTime()[1]);
                outPacket.WriteUInt(SetRider.UserNO);
                outPacket.WriteString(SetRider.UserID);
                outPacket.WriteByte(2);
                outPacket.WriteByte(1);
                outPacket.WriteByte(0);
                outPacket.WriteInt(0);
                outPacket.WriteByte(0);
                outPacket.WriteInt(1415577599);
                outPacket.WriteUInt(SetRider.pmap);
                for (int i = 0; i < 11; i++)
                {
                    outPacket.WriteInt(0);
                }
                outPacket.WriteByte(0);
                outPacket.WriteEndPoint(IPAddress.Parse(RouterListener.forceConnect), 39311);
                outPacket.WriteEndPoint(IPAddress.Parse(RouterListener.forceConnect), 39312);
                outPacket.WriteInt(0);
                outPacket.WriteString("");
                outPacket.WriteInt(0);
                outPacket.WriteByte(1);
                outPacket.WriteString("content");
                outPacket.WriteInt(0);
                outPacket.WriteInt(1);
                outPacket.WriteString("cc");
                outPacket.WriteString(SessionGroup.Service);
                outPacket.WriteInt(4);
                outPacket.WriteString("content");
                outPacket.WriteInt(0);
                outPacket.WriteInt(2);
                outPacket.WriteString("name");
                outPacket.WriteString("dynamicPpl");
                outPacket.WriteString("enable");
                outPacket.WriteString("false");
                outPacket.WriteInt(1);
                outPacket.WriteString("region");
                outPacket.WriteInt(0);
                outPacket.WriteInt(1);
                outPacket.WriteString("szId");
                outPacket.WriteString(SessionGroup.usLocale.ToString());
                outPacket.WriteInt(0);
                outPacket.WriteString("content");
                outPacket.WriteInt(0);
                outPacket.WriteInt(3);
                outPacket.WriteString("name");
                outPacket.WriteString("endingBanner");
                outPacket.WriteString("enable");
                outPacket.WriteString("false");
                outPacket.WriteString("value");
                outPacket.WriteString("http://popkart.tiancity.com/homepage/endbanner.html");
                outPacket.WriteInt(0);
                outPacket.WriteString("content");
                outPacket.WriteInt(0);
                outPacket.WriteInt(3);
                outPacket.WriteString("name");
                outPacket.WriteString("themeXyy");
                outPacket.WriteString("enable");
                outPacket.WriteString("true");
                outPacket.WriteString("visible");
                outPacket.WriteString("true");
                outPacket.WriteInt(0);
                outPacket.WriteString("content");
                outPacket.WriteInt(0);
                outPacket.WriteInt(3);
                outPacket.WriteString("name");
                outPacket.WriteString("themeKorea");
                outPacket.WriteString("enable");
                outPacket.WriteString("true");
                outPacket.WriteString("visible");
                outPacket.WriteString("true");
                outPacket.WriteInt(0);
                outPacket.WriteByte(0);
                outPacket.WriteByte(SetGameOption.Set_screen);
                outPacket.WriteByte(SetRider.IdentificationType);
                RouterListener.MySession.Client.Send(outPacket);
            }
        }
        public void PqSyncJackpotPointCS()
        {
            using (OutPacket outPacket = new OutPacket("PrSyncJackpotPointCS"))
            {
                outPacket.WriteByte(0);
                Parent.Client.Send(outPacket);
            }
        }
        public void PqEnterShopPacket()
        {
        }
        public void PqGetlotteryMileageInfoPacket()
        {
            using (OutPacket outPacket = new OutPacket("PrGetlotteryMileageInfoPacket"))
            {
                outPacket.WriteInt(0);
                Parent.Client.Send(outPacket);
            }
        }
        public void PqTcCashEventUserInfoPacket()
        {
            int unk1 = iPacket.ReadInt();
            using (OutPacket outPacket = new OutPacket("PrTcCashEventUserInfoPacket"))
            {
                outPacket.WriteInt(unk1);
                outPacket.WriteInt(0);
                outPacket.WriteInt(0);
                Parent.Client.Send(outPacket);
            }
        }
        public void PqServerSideUdpBindCheck() { }
        public void PqMissionAttendUserStatePacket() { }
        public void PqMissionAttendNRUserStatePacket() { }
        public void PqBoomhillExchangeInfo()
        {
            using (OutPacket outPacket = new OutPacket("PrBoomhillExchangeInfo"))
            {
                outPacket.WriteBytes(new byte[8]);
                Parent.Client.Send(outPacket);
            }
        }
        public void PqBoomhillExchangeNeedNotice()
        {
        }
        public void PqMixItemExchangeCount()
        {
            using (OutPacket outPacket = new OutPacket("PrMixItemExchangeCount"))
            {
                outPacket.WriteInt(0);
                Parent.Client.Send(outPacket);
            }
        }
        public void RqBoomhillExchangeKoin()
        {
            using (OutPacket outPacket = new OutPacket("RpBoomhillExchangeKoin"))
            {
                outPacket.WriteInt(0);
                outPacket.WriteInt(0);
                Parent.Client.Send(outPacket);
            }
        }
        public void PqQuestUX2ndForShutDownPacket()
        {
            using (OutPacket outPacket = new OutPacket("PrQuestUX2ndForShutDownPacket"))
            {
                outPacket.WriteInt(0);
                Parent.Client.Send(outPacket);
            }
        }
    }
}
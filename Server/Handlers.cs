using OrangeApi;
using System.Collections.Generic;
using System;
using System.Net;
using System.Text;

namespace RiCO.Server;

public static class Handlers
{
    [RequestHandler(typeof(LoginToServerRes))]
    public static void LoginToServer(HttpListenerContext context, string data)
    {
        SendResponse(context, new LoginToServerRes
        {
            Token = string.Empty,
            DailyResetTime = 4,
            TimeZone = 8,
            CurrentTime = DateTime.Now.ToUnixTimeSeconds(),
            DayResetTime = new NetResetTimeInfo
            {
                CurrentResetTime = DateTime.Now.ToUnixTimeSeconds() * 60 * 60 * 24,
                PreResetTime = DateTime.Now.ToUnixTimeSeconds() * 60 * 60 * 24 - 3600,
            },
            WeekResetTime = new NetResetTimeInfo
            {
                CurrentResetTime = DateTime.Now.ToUnixTimeSeconds() * 60 * 60 * 24 * 7,
                PreResetTime = DateTime.Now.ToUnixTimeSeconds() * 60 * 60 * 24 * 7 - 3600,
            },
            MonthResetTime = new NetResetTimeInfo
            {
                CurrentResetTime = DateTime.Now.ToUnixTimeSeconds() * 60 * 60 * 24 * 30,
                PreResetTime = DateTime.Now.ToUnixTimeSeconds() * 60 * 60 * 24 * 30 - 3600,
            },
            PlayerID = "Kyle873",
            ServerID = 1,
            BirthTime = "",
            Region = "CA",
            CheatType = 0,
            CheatExpireTime = 0,
            ValidTableList = new List<string>(),

            PatchVer = 316,
            ServerTime = DateTime.Now.ToUnixTimeSeconds(),
            MissionProgressList = new List<NetMissionProgressInfo>(),
            DataCRC = 0,
            ExDataCRC = 0,
            SeqID = Server.SeqCount++,
            Code = 1000
        });;
    }

    [RequestHandler(typeof(RetrievePlayerInfoRes))]
    public static void RetrievePlayerInfo(HttpListenerContext context, string data)
    {
        SendResponse(context, new RetrievePlayerInfoRes
        {
            PlayerInfo = new NetPlayerInfo()
            {
                ActionPoint = 0,
                ActionPointTimer = 0,
                EventActionPoint = 0,
                EventActionPointTimer = 0,
                Exp = 0,
                MainWeaponFSID = 0,
                MainWeaponID = 0,
                Nickname = "Kyle873",
                PlayerCreateTime = DateTime.Now.ToUnixTimeSeconds() - 60,
                PortraitID = 0,
                StandbyChara = 0,
                SubWeaponFSID = 0,
                SubWeaponID = 0,
                TitleID = 0
            },

            PatchVer = 316,
            ServerTime = DateTime.Now.ToUnixTimeSeconds(),
            MissionProgressList = new List<NetMissionProgressInfo>(),
            DataCRC = 0,
            ExDataCRC = 0,
            SeqID = Server.SeqCount++,
            Code = 10000
        });
    }

    [RequestHandler(typeof(LoginRetrieveCollector1Res))]
    public static void LoginRetrieveCollector1(HttpListenerContext context, string data)
    {
        SendResponse(context, new LoginRetrieveCollector1Res
        {
            ItemList = new List<NetItemInfo>(),
            CharacterList = new List<NetCharacterInfo>(),
            CharacterSkillList = new List<NetCharacterSkillInfo>(),
            CharacterSkinList = new List<NetCharacterSkinInfo>(),
            PetList = new List<NetPetInfo>(),
            CardList = new List<NetCardInfo>(),
            CharacterCardSlotInfoList = new List<NetCharacterCardSlotInfo>(),
            CardDeployInfoList = new List<NetCardDeployInfo>(),
            CardDeployNameInfoList = new List<NetCardDeployNameInfo>(),
            CharacterDNAInfoList = new List<NetCharacterDNAInfo>(),
            CharacterDNALinkInfoList = new List<NetCharacterDNALinkInfo>(),
            RawExtData = string.Empty,

            PatchVer = 316,
            ServerTime = DateTime.Now.ToUnixTimeSeconds(),
            MissionProgressList = new List<NetMissionProgressInfo>(),
            DataCRC = 0,
            ExDataCRC = 0,
            SeqID = Server.SeqCount++,
            Code = 200
        });
    }

    [RequestHandler(typeof(LoginRetrieveCollector2Res))]
    public static void LoginRetrieveCollector2(HttpListenerContext context, string data)
    {
        SendResponse(context, new LoginRetrieveCollector2Res
        {
            WeaponList = new List<NetWeaponInfo>(),
            WeaponExpertList = new List<NetWeaponExpertInfo>(),
            WeaponSkillList = new List<NetWeaponSkillInfo>(),
            EquipmentList = new List<NetEquipmentInfo>(),
            PlayerEquipList = new List<NetPlayerEquipInfo>(),
            FSList = new List<NetFinalStrikeInfo>(),
            ChipList = new List<NetChipInfo>(),
            ChargeInfoList = new List<NetChargeInfo>(),
            TutorialList = new List<int>(),
            PlayerServiceInfoList = new List<NetPlayerServiceInfo>(),
            BenchWeaponInfoList = new List<NetBenchInfo>(),
            WeaponDiVESkillList = new List<NetWeaponDiVESkillInfo>(),
            RawExtData = string.Empty,

            PatchVer = 316,
            ServerTime = DateTime.Now.ToUnixTimeSeconds(),
            MissionProgressList = new List<NetMissionProgressInfo>(),
            DataCRC = 0,
            ExDataCRC = 0,
            SeqID = Server.SeqCount++,
            Code = 200
        });
    }

    [RequestHandler(typeof(LoginRetrieveCollector3Res))]
    public static void LoginRetrieveCollector3(HttpListenerContext context, string data)
    {
        SendResponse(context, new LoginRetrieveCollector3Res
        {
            StageClearList = new List<NetStageInfo>(),
            GalleryList = new List<NetGalleryInfo>(),
            GalleryExpList = new List<NetGalleryExpInfo>(),
            MailListCount = 0,
            ReservedMailList = new List<NetMailInfo>(),
            SystemContextList = new List<NetExtraSystemContext>(),
            CompletedMissionList = new List<NetMissionInfo>(),
            ResearchInfoList = new List<NetResearchInfo>(),
            ResearchRecordList = new List<NetResearchRecord>(),
            FreeResearchInfoList = new List<NetFreeResearchInfo>(),
            StageSecretList = new List<NetStageSecretInfo>(),
            TowerBossInfoList = new List<NetTowerBossInfo>(),
            GalleryCardList = new List<NetGalleryMainIdInfo>(),
            RawExtData = string.Empty,

            PatchVer = 316,
            ServerTime = DateTime.Now.ToUnixTimeSeconds(),
            MissionProgressList = new List<NetMissionProgressInfo>(),
            DataCRC = 0,
            ExDataCRC = 0,
            SeqID = Server.SeqCount++,
            Code = 200
        });
    }

    [RequestHandler(typeof(LoginRetrieveCollector4Res))]
    public static void LoginRetrieveCollector4(HttpListenerContext context, string data)
    {
        SendResponse(context, new LoginRetrieveCollector4Res
        {
            GachaEventRecordList = new List<NetGachaEventRecord>(),
            GachaGuaranteeRecordList = new List<NetGachaGuaranteeRecord>(),
            MultiPlayGachaRecordList = new List<NetMultiPlayerGachaInfo>(),
            ShopRecordList = new List<NetShopRecord>(),
            BoxGachaStatusList = new List<NetBoxGachaStatus>(),
            BREventInfoList = new List<NetBREventInfo>(),
            ExBannerList = new List<NetBannerEx>(),
            ExItemList = new List<NetItemInfoEx>(),
            ExGachaInfoList = new List<NetGachaInfoEx>(),
            ExGachaEventInfoList = new List<NetGachaEventInfoEx>(),
            ExShopInfoList = new List<NetShopInfoEx>(),
            ExEventList = new List<NetEventEx>(),
            RawExtData = string.Empty,

            PatchVer = 316,
            ServerTime = DateTime.Now.ToUnixTimeSeconds(),
            MissionProgressList = new List<NetMissionProgressInfo>(),
            DataCRC = 0,
            ExDataCRC = 0,
            SeqID = Server.SeqCount++,
            Code = 200
        });
    }

    [RequestHandler(typeof(GuildCheckGuildStateRes))]
    public static void GuildCheckGuildState(HttpListenerContext context, string data)
    {
        SendResponse(context, new GuildCheckGuildStateRes
        {
            GuildId = 0,
            HasInviteGuild = 0,
            HasEddieReward = 0,

            PatchVer = 316,
            ServerTime = DateTime.Now.ToUnixTimeSeconds(),
            MissionProgressList = new List<NetMissionProgressInfo>(),
            DataCRC = 0,
            ExDataCRC = 0,
            SeqID = Server.SeqCount++,
            Code = 105106 // Code for not in a guild, presumably
        });
    }

    static void SendResponse(HttpListenerContext context, IResponse response)
    {
        byte[] data = LZ4Helper.EncodeWithoutHeader(Encoding.UTF8.GetBytes(AesCrypto.Encode(JsonHelper.Serialize(response))));

        context.Response.ContentType = "text/plain";
        context.Response.ContentEncoding = Encoding.UTF8;
        context.Response.ContentLength64 = data.Length;
        context.Response.StatusCode = (int)HttpStatusCode.OK;

        context.Response.Headers.Add("authorization", string.Empty);
        context.Response.Headers.Add("X-Unity-Version", "2018.4.36f1");

        context.Response.OutputStream.Write(data, 0, data.Length);
        context.Response.OutputStream.Close();
    }
}

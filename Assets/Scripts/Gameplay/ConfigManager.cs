using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ConfigManager
{
    static ConfigData configData;
    public static void Initialize()
    {
        configData = new ConfigData();
    }

    public static Color32 NeutralColor
    { 
        get { return configData.NeutralColor; } 
    }

    public static Color32 BadColor
    { 
        get { return configData.BadColor; } 
    }

    public static Color32 GoodColor
    {
        get { return configData.GoodColor; }
    }

    public static Color32 ColorblindBadColor
    {
        get { return configData.ColorblindBadColor; }
    }

    public static Color32 ColorblindGoodColor
    {
        get { return configData.ColorblindGoodColor; }
    }

    public static Color32 NonColorblindBadColor
    {
        get { return configData.NonColorblindBadColor; }
    }

    public static Color32 NonColorblindGoodColor
    {
        get { return configData.NonColorblindGoodColor; }
    }

    public static int MoneyPerLetter
    {
        get { return configData.MoneyPerLetter; }
    }
    public static int StartingMoney
    {
        get { return configData.StartingMoney; }
    }
    public static int BasicGhostBaseHealth
    {
        get { return configData.BasicGhostBaseHealth; }
    }
    public static int JumpingGhostBaseHealth
    {
        get { return configData.JumpingGhostBaseHealth; }
    }
    public static int MiniGhostBaseHealth
    {
        get { return configData.MiniGhostBaseHealth; }
    }
    public static float BasicGhostSpawnRateMin
    {
        get { return configData.BasicGhostSpawnRateMin; }
    }

    public static float BasicGhostSpawnRateMax
    {
        get { return configData.BasicGhostSpawnRateMax; }
    }

    public static float BasicInterfereRate
    {
        get { return configData.BasicInterfereRate; }
    }

    public static int CurrentGhostBombs
    {
        get { return configData.CurrentGhostBombs; }
    }

    public static int MaxGhostBombs
    {
        get { return configData.MaxGhostBombs; }
    }

    public static int CurrentGhostBarrierPowerUps
    {
        get { return configData.CurrentGhostBarrierPowerUps; }
    }

    public static int MaxGhostBarrierPowerUps
    {
        get { return configData.MaxGhostBarrierPowerUps; }
    }

    public static int CurrentBasicAttackRank
    {
        get { return configData.CurrentBasicAttackRank; }
    }

    public static int MaxBasicAttackRank
    {
        get { return configData.MaxBasicAttackRank; }
    }

    public static int GhostBombCapacityRank
    {
        get { return configData.GhostBombCapacityRank; }
    }

    public static int CurrentGhostBarrierRank
    {
        get { return configData.CurrentGhostBarrierRank; }
    }

    public static int BasicAttackUpgradeCost
    {
        get { return configData.BasicAttackUpgradeCost; }
    }

    public static int GhostBombCapacityUpgradeCost
    {
        get { return configData.GhostBombCapacityUpgradeCost; }
    }

    public static int GhostBarrierUpgradeCost
    {
        get { return configData.GhostBarrierUpgradeCost; }
    }

    public static int GhostBombCost
    {
        get { return configData.GhostBombCost; }
    }

    public static int GhostBarrierCost
    {
        get { return configData.GhostBarrierCost; }
    }

    public static int MaxGhostBombCapacityRank
    {
        get { return configData.MaxGhostBombCapacityRank; }
    }

    public static int MaxGhostBarrierRank
    {
        get { return configData.MaxGhostBarrierRank; }
    }
    public static int CurrentAntiGhostWareRank
    {
        get {  return configData.CurrentAntiGhostWareRank; }
    }
    public static int MaxAntiGhostWareRank
    {
        get { return configData.MaxAntiGhostWareRank; }
    }
    public static int AntiGhostWareUpgradeCost
    {
        get { return configData.AntiGhostWareUpgradeCost; }
    }
    //public static float GhostWareTime
    //{
    //    get { return configData.GhostWareTime; }
    //}
    public static float GhostBarrierTime
    {
        get { return configData.GhostBarrierTime; }
    }
    public static int CurrentMiniGhostReducerRank
    {
        get { return configData.CurrentMiniGhostReducerRank; }
    }
    public static int MaxMiniGhostReducerRank
    {
        get { return configData.MaxMiniGhostReducerRank; }
    }
    public static int MiniGhostReducerCost
    {
        get { return configData.MiniGhostReducerCost; }
    }
    public static int NumMiniGhostToSpawn
    {
        get { return configData.NumMiniGhostToSpawn; }
    }
    public static int CurrentCatAttackRank
    {
        get { return configData.CurrentCatAttackRank; }
    }
    public static int MaxCatAttackRank
    {
        get { return configData.MaxCatAttackRank; }
    }
    public static int CatAttackCost
    {
        get { return configData.CatAttackCost; }
    }
    public static int CatHealth
    {
        get { return configData.CatHealth; }
    }

    public static void SetNeutralColor(Color32 color)
    {
        configData.SetNeutralColor(color);
    }

    public static void SetBadColor(Color32 color)
    {
        configData.SetBadColor(color);
    }

    public static void SetGoodColor(Color32 color)
    {
        configData.SetGoodColor(color);
    }

    public static void SetCurrentGhostBombs(int total)
    {
        configData.SetCurrentGhostBombs(total);
    }

    public static void SetCurrentBarrierGhostPowerUps(int total)
    {
        configData.SetCurrentBarrierGhostPowerUps(total);
    }

    public static void SetMaxBarrierGhostPowerUps(int total)
    {
        configData.SetMaxBarrierGhostPowerUps(total);
    }

    public static void SetStartingMoney(int money)
    {
        configData.SetStartingMoney(money);
    }

    public static void SetCurrentBasicAttackRank(int rank)
    {
        configData.SetCurrentBasicAttackRank(rank);
    }

    public static void SetGhostBombCapacityRank(int rank)
    {
        configData.SetGhostBombCapacityRank(rank);
    }

    public static void SetGhostBarrierRank(int rank)
    {
        configData.SetGhostBarrierRank(rank);
    }
    public static void SetCurrentAntiGhostWareRank(int rank)
    {
        configData.SetCurrentAntiGhostWareRank(rank);
    }
    public static void SetGhostBarrierTime()
    {
        configData.SetGhostBarrierTime();
    }
    public static void ElapseGhostBarrierTime()
    {
        configData.ElapseGhostBarrierTime();
    }
    public static void SetCurrentMiniGhostReducerRank(int rank)
    {
        configData.SetCurrentMiniGhostReducerRank(rank);
    }
    public static void SetCurrentCatAttackRank(int rank)
    {
        configData.SetCurrentCatAttackRank(rank);
    }
    public static void LoadConfigData()
    {
        configData.LoadConfigData();
    }
    public static void SaveConfigData()
    {
        configData.SaveConfigData();
    }
    public static void ResetData()
    {
        configData.ResetData();
    }
}

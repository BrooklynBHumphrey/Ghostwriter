using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ConfigData
{
    const string ConfigFileName = "ConfigData.csv";
    const string SaveFileName = "SaveData.csv";

    static int moneyPerLetter = 5;
    static int startingMoney = 0;
    static int basicGhostBaseHealth = 5;
    static int jumpingGhostBaseHealth = 3;
    static int miniGhostBaseHealth = 1;

    static float basicGhostSpawnRateMin = 10.0f;
    static float basicGhostSpawnRateMax = 15.0f;

    static float basicInterfereRate = 1.2f;


    //basic attack upgrades
    static int currentBasicAttackRank = 0;
    static int maxBasicAttackRank = 2;
    static int basicAttackUpgradeCost = 750;
    //ghostbomb
    static int currentGhostBombs = 1;
    static int ghostBombCost = 500;
    //ghostbomb rank upgrade
    static int ghostBombCapacityRank = 1;
    static int maxGhostBombCapacityRank = 3;
    static int ghostBombCapacityUpgradeCost = 500;
    //antiGhostware rank
    static int currentAntiGhostWareRank = 0;
    static int maxAntiGhostWareRank = 3;
    static int antiGhostWareUpgradeCost = 1000;
    //static float ghostWareTime = 3.0f;
    //ghostBarrier
    static int currentGhostBarrierPowerUps = 0;
    static int maxGhostBarrierPowerUps = 0;
    static int ghostBarrierCost = 500;
    //ghostBarrier rank
    static int currentGhostBarrierRank = 0;
    static int maxGhostBarrierRank = 2;
    static int ghostBarrierUpgradeCost = 500;
    static float ghostBarrierTime = 0.0f;
    const float GHOSTBARRIER_RANK1_TIME = 10.0f;
    const float GHOSTBARRIER_RANK2_TIME = 20.0f;
    //miniGhostReducer
    static int currentMiniGhostReducerRank = 0;
    static int maxMiniGhostReducerRank = 2;
    static int miniGhostReducerCost = 1000;
    static int numMiniGhostToSpawn = 5;
    //citrus-scented gloves
    static int currentCatAttackRank = 0;
    static int maxCatAttackRank = 2;
    static int catAttackCost = 1000;
    static int catHealth = 5;
    //colors for letters
    Color32 colorblindBadColor = new Color32(180, 54, 98, 255);
    Color32 colorblindGoodColor = new Color32(153, 249, 60, 255);
    Color32 nonColorblindBadColor = new Color32(255, 0, 0, 255);
    Color32 nonColorblindGoodColor = new Color32(0, 255, 0, 255);
    Color32 neutralColor = new Color32(255, 255, 255, 255);
    Color32 badColor = new Color32(255, 0, 0, 255);
    Color32 goodColor = new Color32(0, 255, 0, 255);



    public Color32 NeutralColor { get { return neutralColor; } }

    public Color32 BadColor { get { return badColor; } }

    public Color32 GoodColor { get { return goodColor; } }

    public Color32 ColorblindBadColor { get { return colorblindBadColor; } }

    public Color32 ColorblindGoodColor { get { return colorblindGoodColor; } }

    public Color32 NonColorblindBadColor { get { return nonColorblindBadColor; } }

    public Color32 NonColorblindGoodColor { get { return nonColorblindGoodColor; } }


    public int MoneyPerLetter { get { return moneyPerLetter; } }
    public int StartingMoney { get { return startingMoney; } }

    public int BasicGhostBaseHealth { get { return basicGhostBaseHealth; } }
    public int JumpingGhostBaseHealth { get { return jumpingGhostBaseHealth; } }
    public int MiniGhostBaseHealth {  get {  return miniGhostBaseHealth; } }

    public float BasicGhostSpawnRateMin { get { return Mathf.Max(basicGhostSpawnRateMin - LevelManager.CurrentLevel, 3); } }
    public float BasicGhostSpawnRateMax { get { return Mathf.Max(basicGhostSpawnRateMax - LevelManager.CurrentLevel, 8); } }

    public float BasicInterfereRate { get { return basicInterfereRate; } }

    public int CurrentBasicAttackRank { get { return currentBasicAttackRank; } }
    public int MaxBasicAttackRank { get { return maxBasicAttackRank; } }
    public int BasicAttackUpgradeCost { get { return basicAttackUpgradeCost + basicAttackUpgradeCost * currentBasicAttackRank; } }

    public int CurrentGhostBombs { get { return currentGhostBombs; } }
    public int MaxGhostBombs { get { return ghostBombCapacityRank; } }
    public int GhostBombCost { get { return ghostBombCost; } }

    public int GhostBombCapacityRank { get { return ghostBombCapacityRank; } }
    public int MaxGhostBombCapacityRank { get { return maxGhostBombCapacityRank; } }
    public int GhostBombCapacityUpgradeCost { get { return ghostBombCapacityUpgradeCost + ghostBombCapacityUpgradeCost * ghostBombCapacityRank; } }

    public int CurrentAntiGhostWareRank {  get { return currentAntiGhostWareRank; } }
    public int MaxAntiGhostWareRank { get { return maxAntiGhostWareRank; } }
    public int AntiGhostWareUpgradeCost {  get { return antiGhostWareUpgradeCost; } } //+ antiGhostWareUpgradeCost * currentAntiGhostWareRank;} }
    //public float GhostWareTime { get { return ghostWareTime; } }


    public int CurrentGhostBarrierPowerUps { get { return currentGhostBarrierPowerUps; } }
    public int MaxGhostBarrierPowerUps { get { return maxGhostBarrierPowerUps; } }
    public int GhostBarrierCost { get { return ghostBarrierCost; } }

    public int CurrentGhostBarrierRank { get { return currentGhostBarrierRank; } }
    public int MaxGhostBarrierRank { get { return maxGhostBarrierRank; } }
    public int GhostBarrierUpgradeCost { get { return ghostBarrierUpgradeCost + ghostBarrierUpgradeCost * currentGhostBarrierRank; } }
    public float GhostBarrierTime { get { return ghostBarrierTime; } }

    public int CurrentMiniGhostReducerRank { get { return currentMiniGhostReducerRank; } }
    public int MaxMiniGhostReducerRank { get { return maxMiniGhostReducerRank; } }
    public int MiniGhostReducerCost { get { return miniGhostReducerCost + miniGhostReducerCost * currentMiniGhostReducerRank; } }
    public int NumMiniGhostToSpawn { get { return numMiniGhostToSpawn - currentMiniGhostReducerRank; } }

    public int CurrentCatAttackRank { get { return currentCatAttackRank; } }
    public int MaxCatAttackRank { get { return maxCatAttackRank; } }
    public int CatAttackCost { get { return catAttackCost + catAttackCost * currentCatAttackRank; } }
    public int CatHealth { get { return catHealth - currentCatAttackRank; } }

    public void SetNeutralColor(Color32 color)
    {
        neutralColor = color;
    }

    public void SetBadColor(Color32 color)
    {
        badColor = color;
    }

    public void SetGoodColor(Color32 color)
    {
        goodColor = color;
    }
    public void SetGhostBarrierTime() 
    {
        switch(currentGhostBarrierRank)
        {
            case 1:
                ghostBarrierTime = GHOSTBARRIER_RANK1_TIME;
                break;
            case 2:
                ghostBarrierTime =  GHOSTBARRIER_RANK2_TIME;
                break;
            default:
                ghostBarrierTime = 0.0f;
                break;
        }
    }
    public void ElapseGhostBarrierTime()
    {
        ghostBarrierTime -= Time.deltaTime;
    }

    public void SetCurrentGhostBombs(int total)
    {
        currentGhostBombs = total;
    }

    public void SetCurrentBarrierGhostPowerUps(int total)
    {
        currentGhostBarrierPowerUps = total;
    }

    public void SetMaxBarrierGhostPowerUps(int total)
    {
        maxGhostBarrierPowerUps = total;
    }

    public void SetStartingMoney(int money)
    {
        startingMoney = money;
    }
    public void SetCurrentBasicAttackRank(int rank)
    {
        currentBasicAttackRank = rank;
    }

    public void SetGhostBarrierRank(int rank)
    {
        currentGhostBarrierRank = rank;
    }

    public void SetGhostBombCapacityRank(int rank)
    {
        ghostBombCapacityRank = rank;
    }
    public void SetCurrentAntiGhostWareRank(int rank)
    {
        currentAntiGhostWareRank = rank;
    }

    public void SetGhostBarrierTime(float time)
    {
        ghostBarrierTime = time;
    }

    public void SetCurrentMiniGhostReducerRank(int rank)
    {
        currentMiniGhostReducerRank = rank;
    }
    public void SetCurrentCatAttackRank(int rank)
    {
        currentCatAttackRank = rank;
    }

    public void ResetData()
    {
        StreamReader input = null;
        try
        {
            input = File.OpenText(Path.Combine(Application.streamingAssetsPath, ConfigFileName));
            string names = input.ReadLine();
            string values = input.ReadLine();
            SetConfigurationDataFields(values);
        }
        catch (System.Exception e)
        { Debug.LogException(e); }
        finally
        {
            if (input != null)
            {
                input.Close();
            }
        }
    }

    public void LoadConfigData()
    {
        StreamReader input = null;
        try
        {
            input = File.OpenText(Path.Combine(Application.persistentDataPath, SaveFileName));
            string names = input.ReadLine();
            string values = input.ReadLine();
            SetConfigurationDataFields(values);
        }
        catch (System.Exception e)
        { Debug.LogException(e); }
        finally
        {
            if (input != null)
            {
                input.Close();
            }
        }
    }

    static void SetConfigurationDataFields(string csvValues)
    {
        string[] values = csvValues.Split(',');
        LevelManager.SetCurrentLevel(int.Parse(values[0]));
        int level = LevelManager.CurrentLevel;
        startingMoney = int.Parse(values[1]);
        currentBasicAttackRank = int.Parse(values[2]);
        currentGhostBombs = int.Parse(values[3]);
        ghostBombCapacityRank = int.Parse(values[4]);
        currentAntiGhostWareRank = int.Parse(values[5]);
        currentGhostBarrierPowerUps = int.Parse(values[6]);
        maxGhostBarrierPowerUps = int.Parse(values[7]);
        currentGhostBarrierRank = int.Parse(values[8]);
        currentMiniGhostReducerRank = int.Parse(values[9]);
        currentCatAttackRank = int.Parse(values[10]);
    }

    public void SaveConfigData()
    {
        int level = LevelManager.CurrentLevel;
        if (LevelManager.LevelCompeleted)
        {
            level++;
        }
        LevelManager.SetLevelCompleteStatus(false);
        string data = "CurrentLevel,StartingMoney,BasicAttackRank,GhostBombs,GhostBombRank,"
            + "AntiGhostRank,Barriers,MaxBarriers,BarrierRank,MiniGhostRank,CatAttackRank\n";

        data += level.ToString() + ","
            + startingMoney.ToString() + ","
            + currentBasicAttackRank.ToString() + ","
            + currentGhostBombs.ToString() + ","
            + ghostBombCapacityRank.ToString() + ","
            + currentAntiGhostWareRank.ToString() + ","
            + currentGhostBarrierPowerUps.ToString() + ","
            + maxGhostBarrierPowerUps.ToString() + ","
            + currentGhostBarrierRank.ToString() + ","
            + currentMiniGhostReducerRank.ToString() + ","
            + currentCatAttackRank.ToString();
#if !UNITY_WEBPLAYER
        File.WriteAllText(Path.Combine(Application.persistentDataPath, SaveFileName), data);
#endif
    }

    public ConfigData()
    {
    }
}

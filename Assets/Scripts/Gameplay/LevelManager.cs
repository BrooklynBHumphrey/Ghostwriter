using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LevelManager
{
    static LevelData levelData;
    public static void Initialize()
    {
        levelData = new LevelData();
    }

    public static bool GameStarted
    { get { return levelData.GameStarted; } }
    public static void SetGameStartedStatus(bool started)
    {
        levelData.SetGameStartedStatus(started);
    }
    public static int CurrentLevel
    { get { return levelData.CurrentLevel;} }
    public static void SetCurrentLevel(int level)
    {
        levelData.SetCurrentLevel(level);
    }
    public static bool CatActive
    { get { return levelData.CatActive; } }
    public static void SetCatActive(bool active)
    {
        levelData.SetCatActive(active);
    }
    public static int MaxLevels
    { get { return levelData.MaxLevels;} }
    public static bool LevelCompeleted
    { get { return levelData.LevelCompleted; } }
    public static void SetLevelCompleteStatus(bool status)
    {
        levelData.SetLevelCompleteStatus(status);
    }
    public static int PhrasesCompleted
    { get { return levelData.PhrasesCompleted;} }

    public static int PhrasesRequired
    { get { return levelData.PhrasesRequired;} }

    public static int CurrentMoney
    { get { return levelData.CurrentMoney;} }

    public static float LevelTime
    { get { return levelData.LevelTime; } }



    public static void AddGhostBombsUsed()
    {
        levelData.AddGhostBombsUsed();
    }
    public static void AddBarrierUsed()
    {
        levelData.AddBarrierUsed();
    }
    public static void BasicGhostKilled(float time)
    {
        levelData.BasicGhostKilled(time);
    }
    public static void JumpingGhostKilled(float time)
    {
        levelData.JumpingGhostKilled(time);
    }
    public static void MiniGhostKilled(float time)
    {
        levelData.MiniGhostKilled(time);
    }
    public static void CatGhostKilled(float time)
    {
        levelData.CatGhostKilled(time);
    }
    public static void ReplayLevel()
    {
        levelData.ReplayLevel();
    }
}

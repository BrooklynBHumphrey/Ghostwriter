using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInfo
{
    int level;
    int wordCount;
    float time;
    float wpm;
    int basicCount;
    float basicKillTime;
    int jumpingCount;
    float jumpingKillTime;
    int miniCount;
    float miniKillTime;
    int catCount;
    float catKillTime;
    int ghostBombUsed;
    int barrierUsed;
    bool success;
    string levelReq;
    public LevelInfo(int currentLevel, int wc, float phraseTime, float levelWPM
        ,int bCount, float bKT, int jCount, float jKT, int mCount, float mKT, int cCount, float cKT, int gUsed, int bUsed
        , bool levelComplete, string levelRequirement)
    {
        level = currentLevel;
        wordCount = wc;
        time = phraseTime;
        wpm = levelWPM;
        basicCount = bCount;
        if(bCount != 0)
        {
            basicKillTime = bKT/bCount;
        }
        else
        {
            basicKillTime = 0.0f;
        }
        jumpingCount = jCount;
        if(jCount != 0)
        {
            jumpingKillTime = jKT/jCount;
        }
        else
        {
            jumpingKillTime = 0.0f;
        }
        miniCount = mCount;
        if(mCount != 0)
        {
            miniKillTime = mKT/mCount;
        }
        else
        {
            miniKillTime = 0.0f;
        }
        if(cCount != 0)
        {
            catKillTime = cKT;
        }
        else
        {
            catKillTime = 0.0f;
        }
        ghostBombUsed = gUsed;
        barrierUsed = bUsed;
        success = levelComplete;
        levelReq = levelRequirement;
    }
    public int Level { get { return level; } }
    public int WordCount { get { return wordCount; } }
    public float Time { get { return time; } } 
    public float WPM { get { return wpm; } }
    public int BasicGhostCount { get { return basicCount; } }
    public float BasicGhostKillTime { get { return basicKillTime; } }
    public int JumpingGhostCount {  get { return jumpingCount; } }
    public float JumpingGhostKillTime { get { return jumpingKillTime; } }
    public int MiniGhostCount { get { return miniCount; } }
    public float MiniGhostKillTime { get { return miniKillTime; } }
    public int CatGhostCount { get { return catCount; } }
    public float CatGhostKillTime { get { return catKillTime; } }
    public int GhostBombsUsed { get { return ghostBombUsed; } }
    public int BarrierUsed {  get { return barrierUsed; } }
    public bool Success { get { return success; } }    
    public string LevelRequirement { get { return levelReq; } }
          
}

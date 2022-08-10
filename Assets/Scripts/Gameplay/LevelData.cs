using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData
{
    public bool GameStarted { get { return gameStarted; } }
    static bool gameStarted = false;
    public int CurrentLevel { get { return currentLevel; } }
    static int currentLevel = 1; //8+ to test random phrase generation
    public int MaxLevels { get { return maxLevels; } }
    static int maxLevels = 30;
    public bool LevelCompleted { get { return levelCompleted; } }
    static bool levelCompleted = false;
    public int PhrasesCompleted { get { return phrasesCompleted; } }
    static int phrasesCompleted;
    public int PhrasesRequired { get { return phrasesRequired; } }
    static int phrasesRequired;
    public int CurrentMoney { get { return currentMoney; } }
    static int currentMoney;
    public bool CatActive { get { return catActive; } }
    static bool catActive = false;

    const float LEVELTIME_DEFAULT = 85.0f;
    const float LEVELTIME_INCREMENT = 5.0f;
    const float LEVELTIME_MAX = 180.0f;
    public float LevelTime { get { return Mathf.Min(LEVELTIME_DEFAULT + LEVELTIME_INCREMENT * currentLevel, LEVELTIME_MAX); } }
    public int LevelWordCount { get { return levelWordCount; } }
    static int levelWordCount = 0;
    public float PhraseTime { get { return phraseTime; } }
    static float phraseTime = 0.0f;

    public int GhostBombsUsed { get { return ghostBombsUsed; } }
    static int ghostBombsUsed = 0;
    public int BarrierUsed { get { return barrierUsed; } }
    static int barrierUsed = 0;

    static int basicGhostCount = 0;
    static float basicGhostKillTime = 0.0f;
    static int jumpingGhostCount = 0;
    static float jumpingGhostKillTime = 0.0f;
    static int miniGhostCount = 0;
    static float miniGhostKillTime = 0.0f;
    static int catGhostCount = 0;
    static float catGhostKillTime = 0.0f;

    Animator moneyTextAnimator;

    public void SetCurrentLevel(int level)
    {
        currentLevel = level;
    }
    public void SetCatActive(bool active)
    {
        catActive = active;
    }
    public void SetLevelCompleteStatus(bool complete)
    {
        levelCompleted = complete;
    }

    public LevelData()
    {
        EventManager.AddPhraseCompletedListener(PhraseComplete);
        EventManager.AddLevelStartListener(LevelStart);
        EventManager.AddTimesUpListener(TimesUp);
        currentMoney = 0;
    }
    // Start is called before the first frame update

    void PhraseComplete(string phrase, float time)
    {
        phrasesCompleted++;
        currentMoney += ConfigManager.MoneyPerLetter * phrase.Length;
        moneyTextAnimator = GameObject.Find("InGameScreen").GetComponent<Animator>();
        moneyTextAnimator.SetTrigger("MoneyTrigger");
        levelWordCount += phrase.Split(' ').Length;
        phraseTime += time;
        if (phrasesCompleted == phrasesRequired)
        {
            //fanfare woohoo!
            levelCompleted = true;
        }
    }
    public void AddPhraseTime(float time)
    {
        phraseTime += time;
    }

    public void SetGameStartedStatus(bool started)
    {
        gameStarted = started;

    }
    void LevelStart()
    {
        currentMoney = 0;
        phrasesCompleted = 0;
        levelWordCount = 0;
        phraseTime = 0.0f;
        ghostBombsUsed = 0;
        barrierUsed = 0;
        basicGhostCount = 0;
        jumpingGhostCount = 0;
        miniGhostCount = 0;
        catGhostCount = 0;
        //levelCompleted = true; //!!!!!!FOR PLAYTESTING PURPOSES ONLY!!!!!
        if(levelCompleted && currentLevel < maxLevels)
        {
            currentLevel++;
        }
        levelCompleted = false;
        phrasesRequired = GetPhrasesRequired(currentLevel);
    }

    void TimesUp()
    {
        string levelReq = phrasesCompleted + "/" + phrasesRequired;
        LevelInfo info = new LevelInfo(currentLevel, levelWordCount, phraseTime
            , levelWordCount / phraseTime * 60.0f, basicGhostCount, basicGhostKillTime
            , jumpingGhostCount, jumpingGhostKillTime, miniGhostCount, miniGhostKillTime
            , catGhostCount, catGhostKillTime,ghostBombsUsed, barrierUsed, levelCompleted, levelReq);
        MetricManager.AddToMetric1(info);
    }

    public void ReplayLevel()
    {
        levelCompleted = false;
    }

    private int GetPhrasesRequired(int currentLevel)
    {
        switch (currentLevel)
        {
            case 1:
                return 8;
            case 2:
                return 10;
            //return 30;
            case 3:         //PLAYTEST
                return 10;
            case 4:
                return 20;
            case 5:
                return 5;
            case 6:
                return 2;
            case 7:
                return 6;
            default:
                return 5;
        }
    }
    public void AddGhostBombsUsed()
    {
        ghostBombsUsed++;
    }
    public void AddBarrierUsed()
    {
        barrierUsed++;
    }
    public void BasicGhostKilled(float time)
    {
        basicGhostCount++;
        basicGhostKillTime += time;
    }
    public void JumpingGhostKilled(float time)
    {
        jumpingGhostCount++;
        jumpingGhostKillTime += time;
    }
    public void MiniGhostKilled(float time)
    {
        miniGhostCount++;
        miniGhostKillTime += time;
    }
    public void CatGhostKilled(float time)
    {
        catGhostCount++;
        catGhostKillTime = time;
    }
}

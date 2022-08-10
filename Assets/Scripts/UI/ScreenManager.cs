using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class ScreenManager : MonoBehaviour
{
    [SerializeField] GameObject InGameScreen;
    [SerializeField] GameObject InBetweenScreen;
    [SerializeField] TextMeshProUGUI scoreText;

    [SerializeField] GameObject InstructionScreen;
    [SerializeField] GameObject playLevelButton;
    [SerializeField] GameObject ScreenOne;
    [SerializeField] GameObject ScreenTwo;
    [SerializeField] GameObject ScreenThree;
    [SerializeField] GameObject ScreenFour;
    [SerializeField] GameObject ScreenFive;
    [SerializeField] GameObject ScreenSix;
    [SerializeField] GameObject ScreenSeven;
    [SerializeField] GameObject instructionMenuButton;
    [SerializeField] GameObject prevButton;
    [SerializeField] GameObject nextButton;
    int currentPage = 1;

    [SerializeField] GameObject SettingsScreen;
    [SerializeField] GameObject UpgradeScreen;
    [SerializeField] GameObject MainMenuScreen;
    [SerializeField] GameObject CreditsScreen;

    [SerializeField] LoadingProgressBar progressBar;
    [SerializeField] GameObject LoadLevelScreen;
    [SerializeField] TextMeshProUGUI loadLevelText;

    [SerializeField] GameObject LevelSelectScreen;

    

    LevelStartedEvent levelStartedEvent;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        levelStartedEvent = new LevelStartedEvent();
        EventManager.AddLevelStartInvoker(this);
        EventManager.AddLevelLoadedListener(LevelLoaded);
        EventManager.AddTimesUpListener(TimesUp);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddLevelStartListener(UnityAction listener)
    {
        levelStartedEvent.AddListener(listener);
    }

    void TimesUp()
    {
        InGameScreen.SetActive(false);
        InBetweenScreen.SetActive(true);
        SetScoreText();
    }
    public void SetScoreText()
    {
        if (LevelManager.LevelCompeleted)
        {
            scoreText.text = "Level " + LevelManager.CurrentLevel + " Complete!";
        }
        else
        {
            scoreText.text = "Level " + LevelManager.CurrentLevel + " Failed!";
        }
        scoreText.text = scoreText.text + "\nPhrases Completed: " + LevelManager.PhrasesCompleted
            + "/" + LevelManager.PhrasesRequired
            + "\nMoney Earned: $" + (LevelManager.CurrentMoney).ToString()
            + "\nTotal Money: $" + (ConfigManager.StartingMoney).ToString();
    }
    public void AccessUpgradeMenu()
    {
        AudioManager.Play(AudioClipName.ButtonClick);
        InBetweenScreen.SetActive(false);
        UpgradeScreen.SetActive(true);
        //EventSystem.current.SetSelectedGameObject(null);
        //EventSystem.current.SetSelectedGameObject(upgradeFirstButton);
    }
    public void ExitFromUpgradeMenu()
    {
        AudioManager.Play(AudioClipName.ButtonClick);
        InBetweenScreen.SetActive(true);
        UpgradeScreen.SetActive(false);
        //EventSystem.current.SetSelectedGameObject(null);
        //EventSystem.current.SetSelectedGameObject(betweenLevelFirstButton);
        SetScoreText();
    }


    public void AccessLevelSelect()
    {
        MainMenuScreen.SetActive(false);
        LevelSelectScreen.SetActive(true);
        //EventSystem.current.SetSelectedGameObject(null);
        //EventSystem.current.SetSelectedGameObject(levelSelectFirstButton);
    }
    public void ExitLevelSelect()
    {
        LevelSelectScreen.SetActive(false);
        MainMenuScreen.SetActive(true);
        //EventSystem.current.SetSelectedGameObject(null);
        //EventSystem.current.SetSelectedGameObject(mainMenuFirstButton);
    }

    public void TurnOnInstructionScreen()
    {
        AudioManager.Play(AudioClipName.ButtonClick);
        MainMenuScreen.SetActive(false);
        InstructionScreen.SetActive(true);
        instructionMenuButton.SetActive(true);
        ScreenOne.SetActive(true);
        currentPage = 1;
        playLevelButton.SetActive(false);
        prevButton.SetActive(false);
        nextButton.SetActive(true);
        //EventSystem.current.SetSelectedGameObject(null);
        //EventSystem.current.SetSelectedGameObject(nextButton);
    }
    public void NextInstructionScreen()
    {
        AudioManager.Play(AudioClipName.ButtonClick);
        switch (currentPage)
        {
            case 1:
                ScreenOne.SetActive(false);
                ScreenTwo.SetActive(true);
                prevButton.SetActive(true);
                break;
            case 2:
                ScreenTwo.SetActive(false);
                ScreenThree.SetActive(true);
                break;
            case 3:
                ScreenThree.SetActive(false);
                ScreenFour.SetActive(true);
                break;
            case 4:
                ScreenFour.SetActive(false);
                ScreenFive.SetActive(true);
                break;
            case 5:
                ScreenFive.SetActive(false);
                ScreenSix.SetActive(true);
                break;
            case 6:
                ScreenSix.SetActive(false);
                ScreenSeven.SetActive(true);
                nextButton.SetActive(false);
                break;
            default:
                break;
        }
        //EventSystem.current.SetSelectedGameObject(null);
        //EventSystem.current.SetSelectedGameObject(nextButton);
        currentPage++;
    }
    public void PreviousInstructionScreen()
    {
        AudioManager.Play(AudioClipName.ButtonClick);
        switch (currentPage)
        {
            case 2:
                ScreenTwo.SetActive(false);
                ScreenOne.SetActive(true);
                prevButton.SetActive(false);
                break;
            case 3:
                ScreenThree.SetActive(false);
                ScreenTwo.SetActive(true);
                break;
            case 4:
                ScreenFour.SetActive(false);
                ScreenThree.SetActive(true);
                break;
            case 5:
                ScreenFive.SetActive(false);
                ScreenFour.SetActive(true);
                break;
            case 6:
                ScreenSix.SetActive(false);
                ScreenFive.SetActive(true);
                break;
            case 7:
                ScreenSeven.SetActive(false);
                ScreenSix.SetActive(true);
                nextButton.SetActive(true);
                break;
            default:
                break;
        }
        currentPage--;
        //EventSystem.current.SetSelectedGameObject(null);
        //EventSystem.current.SetSelectedGameObject(prevButton);
    }

    public void GetToSettingsScreen()
    {
        AudioManager.Play(AudioClipName.ButtonClick);
        MainMenuScreen.SetActive(false);
        SettingsScreen.SetActive(true);
        //EventSystem.current.SetSelectedGameObject(null);
        //EventSystem.current.SetSelectedGameObject(SettingsFirstButton);
    }
    public void ExitSettingsScreen()
    {
        AudioManager.Play(AudioClipName.ButtonClick);
        SettingsScreen.SetActive(false);
        MainMenuScreen.SetActive(true);
        //EventSystem.current.SetSelectedGameObject(null);
        //EventSystem.current.SetSelectedGameObject(mainMenuFirstButton);
    }

    public void GetToCreditsScreen()
    {
        AudioManager.Play(AudioClipName.ButtonClick);
        MainMenuScreen.SetActive(false);
        CreditsScreen.SetActive(true);
        //EventSystem.current.SetSelectedGameObject(null);
        //EventSystem.current.SetSelectedGameObject(creditsScreenFirstButton);
    }

    public void ExitCreditsScreen()
    {
        AudioManager.Play(AudioClipName.ButtonClick);
        CreditsScreen.SetActive(false);
        MainMenuScreen.SetActive(true);
        //EventSystem.current.SetSelectedGameObject(null);
        //EventSystem.current.SetSelectedGameObject(mainMenuFirstButton);
    }

    public void ExitInstructionScreen(bool toMenu)
    {
        AudioManager.Play(AudioClipName.ButtonClick);
        MainMenuScreen.SetActive(toMenu);
        InstructionScreen.SetActive(false);
        instructionMenuButton.SetActive(false);
        ScreenOne.SetActive(false);
        ScreenTwo.SetActive(false);
        ScreenThree.SetActive(false);
        ScreenFour.SetActive(false);
        ScreenFive.SetActive(false);
        ScreenSix.SetActive(false);
        ScreenSeven.SetActive(false);
        prevButton.SetActive(false);
        nextButton.SetActive(false);

        //EventSystem.current.SetSelectedGameObject(null);
        //EventSystem.current.SetSelectedGameObject(mainMenuFirstButton);
    }


    public void LevelSelect(int level)
    {
        LevelManager.SetCurrentLevel(level);
        StartLevel();
    }

    public void LoadLevel()
    {
        AudioManager.Play(AudioClipName.ButtonClick);
        LevelSelectScreen.SetActive(false);
        MainMenuScreen.SetActive(false);
        InGameScreen.SetActive(false);
        InBetweenScreen.SetActive(false);
        UpgradeScreen.SetActive(false);
        ExitInstructionScreen(false);
        progressBar.ResetLoadingProgressBar();
        levelStartedEvent.Invoke();
        loadLevelText.text = "Level " + LevelManager.CurrentLevel;
        LoadLevelScreen.SetActive(true);
        AudioManager.PlayBGM(LevelManager.CurrentLevel);
    }
    public void LevelLoaded()
    {
        LoadLevelScreen.SetActive(false);
        MainMenuScreen.SetActive(false);
        InGameScreen.SetActive(true);
        InBetweenScreen.SetActive(false);
        UpgradeScreen.SetActive(false);
        LevelManager.SetGameStartedStatus(true);
    }

    public void NewGame()
    {
        ConfigManager.ResetData();
        StartLevel();
    }
    public void StartLevel()
    {
        LevelSelectScreen.SetActive(false);
        MainMenuScreen.SetActive(false);
        InGameScreen.SetActive(false);
        InBetweenScreen.SetActive(false);
        UpgradeScreen.SetActive(false);

        int level = LevelManager.CurrentLevel;
        if (LevelManager.LevelCompeleted)
        {
            level++;
        }
        if (level == 1 || level == 2 || level == 4 || level == 6)
        {
            AudioManager.Play(AudioClipName.ButtonClick);
            InstructionScreen.SetActive(true);
            playLevelButton.SetActive(true);
            instructionMenuButton.SetActive(false);
            nextButton.SetActive(false);
            prevButton.SetActive(false);
            switch (level)
            {
                case 1:
                    ScreenFour.SetActive(true);
                    break;
                case 2:
                    ScreenFive.SetActive(true);
                    break;
                case 4:
                    ScreenSix.SetActive(true);
                    break;
                case 6:
                    ScreenSeven.SetActive(true);
                    break;
            }
        }
        else
        {
            LoadLevel();
        }
    }
    public void NextLevelButton()
    {
        if (LevelManager.LevelCompeleted)
        {
            StartLevel();
        }
        else
        {
            AudioManager.Play(AudioClipName.Cant);
        }
    }
    public void ReplayLevel()
    {
        LevelManager.ReplayLevel();
        LoadLevel();
    }
    public void QuitGame()
    {
        AudioManager.Play(AudioClipName.ButtonClick);
        Application.Quit();
    }

    public void ContinueGame()
    {
        ConfigManager.LoadConfigData();
        StartLevel();
    }
    public void SaveGame()
    {
        AudioManager.Play(AudioClipName.PhraseComplete);
        //InBetweenScreen.SetActive(false); 
        //MainMenuScreen.SetActive(true);
        //EventSystem.current.SetSelectedGameObject(null);
        //EventSystem.current.SetSelectedGameObject(mainMenuFirstButton);
        ConfigManager.SaveConfigData();
        ConfigManager.ResetData();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Linq;

/// <summary>
/// Initializes the game
/// </summary>
public class GameManager : MonoBehaviour 
{
    [SerializeField] GameObject typerObject;
    Typer typerScript;

    [SerializeField] GameObject SettingsScreen;

    [SerializeField] GhostManager ghostManager;

    [SerializeField] AudioSource bgmSource;
    [SerializeField] AudioSource sfxSource;


    [SerializeField] Slider slider;
    [SerializeField] Toggle colorblindToggle;


    [SerializeField] Image flashbang;
    bool flash = false;
    float flashSpeed = 40.0f;

    [SerializeField] GameObject confetti;
    [SerializeField] GameObject confettiSpawnPoint;

    [SerializeField] ParticleSystem basicAttackUpgradeParticles;
    [SerializeField] ParticleSystem antiGhostWareUpgradeParticles;
    [SerializeField] ParticleSystem ghostBombParticles;
    [SerializeField] ParticleSystem ghostBombCapacityParticles;
    [SerializeField] ParticleSystem ghostBarrierParticles;
    [SerializeField] ParticleSystem ghostBarrierCapacityParticles;
    [SerializeField] ParticleSystem screamSaverParticles;
    [SerializeField] ParticleSystem catAttackParticles;

    /// <summary>
    /// Awake is called before Start
    /// </summary>
	void Awake()
    {
        typerScript = typerObject.GetComponent<Typer>();
        AudioManager.Initialize(sfxSource, bgmSource);
        AudioManager.PlayBGM(0);
        // initialize screen utils
        ConfigManager.Initialize();
        LevelManager.Initialize();
        MetricManager.Initialize();
        EventManager.AddTimesUpListener(TimesUp);

        EventManager.AddLevelLoadedListener(LevelLoaded);
    }

    private void Start()
    {
        ChangeMasterVolume(slider.value);
        slider.onValueChanged.AddListener(val => ChangeMasterVolume(val));
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (flash)
        {
            if (flashbang.fillAmount >= 1)
            {
                flashbang.fillAmount = 1;
                flash = false;
            }
            else
            {
                flashbang.fillAmount += Time.deltaTime * flashSpeed;
            }
        }
        else
        {
            if (flashbang.fillAmount > 0)
            {
                flashbang.fillAmount -= Time.deltaTime * flashSpeed;
            }
            else
            {
                flashbang.fillAmount = 0;
            }
        }
        if(LevelManager.GameStarted && ghostManager.IsMiniGhostActive())
        {
            List<GameObject> minis = GameObject.FindGameObjectsWithTag("Ghost").Where(h => h.GetComponent<Ghost>().ghostType == Ghost.GhostType.Mini).ToList();
            if (minis.Count == 0)
            {
                AudioManager.PlayRandom(AudioClipName.GhostDeath);
                ghostManager.TurnMonitorOff(false);
                ghostManager.SetMiniGhostActive(false);
            }
        }

        if (colorblindToggle.isOn)
        {
            ConfigManager.SetBadColor(ConfigManager.ColorblindBadColor);
            ConfigManager.SetGoodColor(ConfigManager.ColorblindGoodColor);
        }
        else
        {
            ConfigManager.SetBadColor(ConfigManager.NonColorblindBadColor);
            ConfigManager.SetGoodColor(ConfigManager.NonColorblindGoodColor);
        }
    }
    void TimesUp()
    {
        GameObject[] ghosts = GameObject.FindGameObjectsWithTag("Ghost");
        foreach (GameObject ghost in ghosts)
        {
            ghost.GetComponent<Ghost>().Die(true);
        }
        var catGhosts = GameObject.FindGameObjectsWithTag("CatGhost");
        foreach(var catGhost in catGhosts)
        {
            catGhost.GetComponent<CatGhost>().Die(true);
        }

        ConfigManager.SetStartingMoney(LevelManager.CurrentMoney + ConfigManager.StartingMoney);
        LevelManager.SetGameStartedStatus(false);
        ghostManager.TurnMonitorOff(false);
        ghostManager.SetMiniGhostActive(false);
        if (LevelManager.LevelCompeleted)
        {
            StartCoroutine(AudioManager.PlayRandomDialog(AudioClipName.YouWin, 7.0f));
            var confettiClone = Instantiate(confetti, confettiSpawnPoint.transform);
            Destroy(confettiClone, 10.0f);
        }
        else
        {
            StartCoroutine(AudioManager.PlayRandomDialog(AudioClipName.YouLose, 6.0f));
        }      
    }

    public void LevelLoaded()
    {
        LevelManager.SetGameStartedStatus(true);
        ghostManager.GetComponent<GhostManager>().ResetTimer();
        ghostManager.GetComponent<GhostManager>().SetCatGhostWasSpawnedThisLevel(false);
        ghostManager.GetComponent<GhostManager>().GenerateCatSpawnTime();
        typerScript.Initialize();  
    }

    public void UpgradeBasicAttack()
    {
        if(ConfigManager.CurrentBasicAttackRank < ConfigManager.MaxBasicAttackRank 
            && ConfigManager.StartingMoney >= ConfigManager.BasicAttackUpgradeCost)
        {
            ConfigManager.SetStartingMoney(ConfigManager.StartingMoney - ConfigManager.BasicAttackUpgradeCost);
            ConfigManager.SetCurrentBasicAttackRank(ConfigManager.CurrentBasicAttackRank+1);
            AudioManager.Play(AudioClipName.Buy);
            basicAttackUpgradeParticles.Play();
        }
        else
        {
            AudioManager.Play(AudioClipName.Cant);
        }
    }

    public void BuyGhostBomb()
    {
        if(ConfigManager.CurrentGhostBombs < ConfigManager.MaxGhostBombs 
            && ConfigManager.StartingMoney >= ConfigManager.GhostBombCost)
        {
            ConfigManager.SetStartingMoney(ConfigManager.StartingMoney - ConfigManager.GhostBombCost);
            ConfigManager.SetCurrentGhostBombs(ConfigManager.CurrentGhostBombs + 1);
            AudioManager.Play(AudioClipName.Buy);
            ghostBombParticles.Play();
        }
        else
        {
            AudioManager.Play(AudioClipName.Cant);
        }
    }

    public void BuyGhostBarrier()
    {
        if (ConfigManager.CurrentGhostBarrierPowerUps < ConfigManager.MaxGhostBarrierPowerUps
            && ConfigManager.StartingMoney >= ConfigManager.GhostBarrierCost)
        {
            ConfigManager.SetStartingMoney(ConfigManager.StartingMoney - ConfigManager.GhostBarrierCost);
            ConfigManager.SetCurrentBarrierGhostPowerUps(ConfigManager.CurrentGhostBarrierPowerUps + 1);
            AudioManager.Play(AudioClipName.Buy);
            ghostBarrierParticles.Play();
        }
        else
        {
            AudioManager.Play(AudioClipName.Cant);
        }
    }

    public void ClearGhosts()
    {
        if (ConfigManager.CurrentGhostBombs > 0)
        {
            GameObject[] ghosts = GameObject.FindGameObjectsWithTag("Ghost");
            foreach (GameObject ghost in ghosts)
            {
                ghost.GetComponent<Ghost>().Die(false);
            }
            gameObject.GetComponent<GhostBombCameraShake>().ShakeCamera();
            Flashbang();
            ConfigManager.SetCurrentGhostBombs(ConfigManager.CurrentGhostBombs - 1);
            ghostManager.TurnMonitorOff(false);
            LevelManager.AddGhostBombsUsed();
            AudioManager.Play(AudioClipName.Bomb);
        }
        else
        {
            AudioManager.Play(AudioClipName.Cant);
        }

    }

    public void BlockGhosts()
    {
        if (ConfigManager.CurrentGhostBarrierPowerUps > 0)
        {
            // TODO: figure out how to delay the spawn times
            ConfigManager.SetGhostBarrierTime();
            ConfigManager.SetCurrentBarrierGhostPowerUps(ConfigManager.CurrentGhostBarrierPowerUps - 1);
            LevelManager.AddBarrierUsed();
            AudioManager.Play(AudioClipName.Barrier);
        }
        else
        {
            AudioManager.Play(AudioClipName.Cant);
        }
    }

    public void UpgradeGhostBomb()
    {
        if (ConfigManager.GhostBombCapacityRank < ConfigManager.MaxGhostBombCapacityRank
            && ConfigManager.StartingMoney >= ConfigManager.GhostBombCapacityUpgradeCost)
        {
            ConfigManager.SetCurrentGhostBombs(ConfigManager.CurrentGhostBombs + 1);
            ConfigManager.SetStartingMoney(ConfigManager.StartingMoney - ConfigManager.GhostBombCapacityUpgradeCost);
            ConfigManager.SetGhostBombCapacityRank(ConfigManager.GhostBombCapacityRank + 1);
            AudioManager.Play(AudioClipName.Buy);
            ghostBombCapacityParticles.Play();
        }
        else
        {
            AudioManager.Play(AudioClipName.Cant);
        }
    }

    public void UpgradeGhostBarrierCapacity()
    {
        if (ConfigManager.CurrentGhostBarrierRank < ConfigManager.MaxGhostBarrierRank
            && ConfigManager.StartingMoney >= ConfigManager.GhostBarrierUpgradeCost)
        {
            if(ConfigManager.CurrentGhostBarrierRank == 0)
            {
                ConfigManager.SetCurrentBarrierGhostPowerUps(ConfigManager.CurrentGhostBarrierPowerUps + 1);
                ConfigManager.SetMaxBarrierGhostPowerUps(ConfigManager.MaxGhostBarrierPowerUps + 1);
            }
            ConfigManager.SetStartingMoney(ConfigManager.StartingMoney - ConfigManager.GhostBarrierUpgradeCost);
            ConfigManager.SetGhostBarrierRank(ConfigManager.CurrentGhostBarrierRank + 1);
            AudioManager.Play(AudioClipName.Buy);
            ghostBarrierCapacityParticles.Play();
        }
        else
        {
            AudioManager.Play(AudioClipName.Cant);
        }
    }

    public void UpgradeAntiGhostWare()
    {
        if(ConfigManager.CurrentAntiGhostWareRank < ConfigManager.MaxAntiGhostWareRank
            && ConfigManager.StartingMoney >= ConfigManager.AntiGhostWareUpgradeCost
            && LevelManager.CurrentLevel >= 2)
        {
            ConfigManager.SetStartingMoney(ConfigManager.StartingMoney - ConfigManager.AntiGhostWareUpgradeCost);
            ConfigManager.SetCurrentAntiGhostWareRank(ConfigManager.CurrentAntiGhostWareRank + 1);
            AudioManager.Play(AudioClipName.Buy);
            antiGhostWareUpgradeParticles.Play();
        }
        else
        {
            AudioManager.Play(AudioClipName.Cant);
        }
    }
    public void UpgradeMiniGhostReducer()
    {
        if (ConfigManager.CurrentMiniGhostReducerRank < ConfigManager.MaxMiniGhostReducerRank
            && ConfigManager.StartingMoney >= ConfigManager.MiniGhostReducerCost
            && LevelManager.CurrentLevel >= 4)
        {
            ConfigManager.SetStartingMoney(ConfigManager.StartingMoney - ConfigManager.MiniGhostReducerCost);
            ConfigManager.SetCurrentMiniGhostReducerRank(ConfigManager.CurrentMiniGhostReducerRank + 1);
            AudioManager.Play(AudioClipName.Buy);
            screamSaverParticles.Play();
        }
        else
        {
            AudioManager.Play(AudioClipName.Cant);
        }
    }
    public void UpgradeCatAttack()
    {
        if(ConfigManager.CurrentCatAttackRank < ConfigManager.MaxCatAttackRank
            && ConfigManager.StartingMoney >= ConfigManager.CatAttackCost
            && LevelManager.CurrentLevel >= 6)
        {
            ConfigManager.SetStartingMoney(ConfigManager.StartingMoney - ConfigManager.CatAttackCost);
            ConfigManager.SetCurrentCatAttackRank(ConfigManager.CurrentCatAttackRank + 1);
            AudioManager.Play(AudioClipName.Buy);
            catAttackParticles.Play();
        }
        else
        {
            AudioManager.Play(AudioClipName.Cant);
        }
    }

    public void ChangeMasterVolume(float value)
    {
        AudioListener.volume = value;
    }

    private void OnApplicationQuit()
    {
        MetricManager.Quit();
    }

    private void Flashbang()
    {
        flash = true;
    }
}

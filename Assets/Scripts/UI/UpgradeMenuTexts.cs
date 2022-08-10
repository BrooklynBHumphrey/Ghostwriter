using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class UpgradeMenuTexts : MonoBehaviour
{
    [SerializeField] GameObject attackButton;
    [SerializeField] TextMeshProUGUI attackRankText;
    [SerializeField] TextMeshProUGUI attackCostText;

    [SerializeField] GameObject bombButton;
    [SerializeField] TextMeshProUGUI bombRankText;
    [SerializeField] TextMeshProUGUI bombCostText;

    [SerializeField] GameObject barrierButton;
    [SerializeField] TextMeshProUGUI barrierRankText;
    [SerializeField] TextMeshProUGUI barrierCostText;
    [SerializeField] TextMeshProUGUI barrierUpgradeButtonText;
    [SerializeField] TextMeshProUGUI barrierUpgradeDescriptionText;

    [SerializeField] GameObject antiGhostButton;
    [SerializeField] GameObject antiGhostInfo;
    [SerializeField] TextMeshProUGUI antiGhostwareRankText;
    [SerializeField] TextMeshProUGUI antiGhostwareCostText;
    [SerializeField] TextMeshProUGUI antiGhostwareDescriptionText;

    [SerializeField] GameObject miniGhostReducerButton;
    [SerializeField] GameObject miniGhostReducerInfo;
    [SerializeField] TextMeshProUGUI miniGhostReducerRankText;
    [SerializeField] TextMeshProUGUI miniGhostReducerCostText;
    [SerializeField] TextMeshProUGUI miniGhostReduerDescriptionText;

    [SerializeField] GameObject catAttackButton;
    [SerializeField] GameObject catAttackInfo;
    [SerializeField] TextMeshProUGUI catAttackRankText;
    [SerializeField] TextMeshProUGUI catAttackCostText;
    [SerializeField] TextMeshProUGUI catAttackDescriptionText;

    [SerializeField] Sprite attackSprite00; //00 - unselected, unavailable
    [SerializeField] Sprite attackSprite01; //01 - unselected, available
    [SerializeField] Sprite attackSprite10; //10 - selected, unavailable
    [SerializeField] Sprite attackSprite11; //11 - selected, available

    [SerializeField] Sprite bombSprite00; //00 - unselected, unavailable
    [SerializeField] Sprite bombSprite01; //01 - unselected, available
    [SerializeField] Sprite bombSprite10; //10 - selected, unavailable
    [SerializeField] Sprite bombSprite11; //11 - selected, available

    [SerializeField] Sprite barrierSprite00; //00 - unselected, unavailable
    [SerializeField] Sprite barrierSprite01; //01 - unselected, available
    [SerializeField] Sprite barrierSprite10; //10 - selected, unavailable
    [SerializeField] Sprite barrierSprite11; //11 - selected, available

    [SerializeField] Sprite antiGhostSprite00; //00 - unselected, unavailable
    [SerializeField] Sprite antiGhostSprite01; //01 - unselected, available
    [SerializeField] Sprite antiGhostSprite10; //10 - selected, unavailable
    [SerializeField] Sprite antiGhostSprite11; //11 - selected, available

    [SerializeField] Sprite screamSaverSprite00; //00 - unselected, unavailable
    [SerializeField] Sprite screamSaverSprite01; //01 - unselected, available
    [SerializeField] Sprite screamSaverSprite10; //10 - selected, unavailable
    [SerializeField] Sprite screamSaverSprite11; //11 - selected, available

    [SerializeField] Sprite lemonGloveSprite00; //00 - unselected, unavailable
    [SerializeField] Sprite lemonGloveSprite01; //01 - unselected, available
    [SerializeField] Sprite lemonGloveSprite10; //10 - selected, unavailable
    [SerializeField] Sprite lemonGloveSprite11; //11 - selected, available

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //attack upgrades
        attackRankText.text = ConfigManager.CurrentBasicAttackRank + "/" + ConfigManager.MaxBasicAttackRank;
        attackCostText.text = "$ " + ConfigManager.BasicAttackUpgradeCost.ToString();
        if(ConfigManager.StartingMoney >= ConfigManager.BasicAttackUpgradeCost 
            && ConfigManager.CurrentBasicAttackRank < ConfigManager.MaxBasicAttackRank)
        {
            if(EventSystem.current.currentSelectedGameObject == attackButton)
            {
                attackButton.GetComponent<Image>().sprite = attackSprite11;
                attackButton.GetComponent<Button>().interactable = true;
            }
            else
            {
                attackButton.GetComponent<Image>().sprite = attackSprite01;
                attackButton.GetComponent<Button>().interactable = true;
            }

        }
        else
        {
            if (EventSystem.current.currentSelectedGameObject == attackButton)
            {
                attackButton.GetComponent<Image>().sprite = attackSprite10;
                attackButton.GetComponent<Button>().interactable = false;
            }
            else
            {
                attackButton.GetComponent<Image>().sprite = attackSprite00;
                attackButton.GetComponent<Button>().interactable = false;
            }
        }
        //ghost bomb upgrades
        bombRankText.text = ConfigManager.GhostBombCapacityRank + "/" + ConfigManager.MaxGhostBombCapacityRank;
        bombCostText.text = "$ " + ConfigManager.GhostBombCapacityUpgradeCost.ToString();
        if(ConfigManager.StartingMoney >= ConfigManager.GhostBombCapacityUpgradeCost 
            && ConfigManager.GhostBombCapacityRank < ConfigManager.MaxGhostBombCapacityRank)
        {
            if (EventSystem.current.currentSelectedGameObject == bombButton)
            {
                bombButton.GetComponent<Image>().sprite = bombSprite11;
                bombButton.GetComponent <Button>().interactable = true;
            }
            else
            {
                bombButton.GetComponent<Image>().sprite = bombSprite01;
                bombButton.GetComponent<Button>().interactable = true;
            }
        }
        else
        {
            if (EventSystem.current.currentSelectedGameObject == bombButton)
            {
                bombButton.GetComponent<Image>().sprite = bombSprite10;
                bombButton.GetComponent<Button>().interactable = false;
            }
            else
            {
                bombButton.GetComponent<Image>().sprite = bombSprite00;
                bombButton.GetComponent<Button>().interactable = false;
            }
        }

        //ghost barrier upgrades
        barrierRankText.text = ConfigManager.CurrentGhostBarrierRank + "/" + ConfigManager.MaxGhostBarrierRank;
        barrierCostText.text = "$ " + ConfigManager.GhostBarrierUpgradeCost.ToString();
        if (ConfigManager.CurrentGhostBarrierRank >= 1)
        {
            barrierUpgradeButtonText.text = "Ghost Barrier Time";
            barrierUpgradeDescriptionText.text = "Increases the amount of time ghosts are blocked from haunting the keyboard after using a ghost barrier by 10 seconds.";
        }
        if (ConfigManager.StartingMoney >= ConfigManager.GhostBarrierUpgradeCost 
            && ConfigManager.CurrentGhostBarrierRank < ConfigManager.MaxGhostBarrierRank)
        {
            if (EventSystem.current.currentSelectedGameObject == barrierButton)
            {
                barrierButton.GetComponent<Image>().sprite = barrierSprite11;
                barrierButton.GetComponent<Button>().interactable = true;
            }
            else
            {
                barrierButton.GetComponent<Image>().sprite = barrierSprite01;
                barrierButton.GetComponent<Button>().interactable = true;
            }
        }
        else
        {
            if (EventSystem.current.currentSelectedGameObject == barrierButton)
            {
                barrierButton.GetComponent<Image>().sprite = barrierSprite10;
                barrierButton.GetComponent<Button>().interactable = false;
            }
            else
            {
                barrierButton.GetComponent<Image>().sprite = barrierSprite00;
                barrierButton.GetComponent<Button>().interactable = false;
            }
        }

        //anti ghost
        if (LevelManager.CurrentLevel >= 2)
        {
            antiGhostButton.SetActive(true);
            antiGhostInfo.SetActive(true);
        }
        else
        {
            antiGhostButton.SetActive(false);
            antiGhostInfo.SetActive(false);
        }

        antiGhostwareRankText.text = ConfigManager.CurrentAntiGhostWareRank + "/" + ConfigManager.MaxAntiGhostWareRank;
        antiGhostwareCostText.text = "$ " + ConfigManager.AntiGhostWareUpgradeCost.ToString();
        if (ConfigManager.CurrentAntiGhostWareRank > 1)
        {
            antiGhostwareDescriptionText.text = "Install security software specifically tailored for your needs. Rank 3: Prevents typing while exorcising ghosts.";      
        }
        else if (ConfigManager.CurrentAntiGhostWareRank > 0)
        {
             antiGhostwareDescriptionText.text = "Install security software specifically tailored for your needs. Rank 2: Adds an Area of Effect to your attacks.";    
        }
        else if (ConfigManager.CurrentAntiGhostWareRank == 0)
        {
            antiGhostwareDescriptionText.text = "Install security software specifically tailored for your needs. Rank 1: Predicts destination of Jumping Ghosts.";
        }
        if (ConfigManager.StartingMoney >= ConfigManager.AntiGhostWareUpgradeCost 
            && ConfigManager.CurrentAntiGhostWareRank < ConfigManager.MaxAntiGhostWareRank
            && LevelManager.CurrentLevel >= 2)
        {
            if (EventSystem.current.currentSelectedGameObject == antiGhostButton)
            {
                antiGhostButton.GetComponent<Image>().sprite = antiGhostSprite11;
                antiGhostButton.GetComponent<Button>().interactable = true;
            }
            else
            {
                antiGhostButton.GetComponent<Image>().sprite = antiGhostSprite01;
                antiGhostButton.GetComponent<Button>().interactable = true;
            }
        }
        else
        {
            if (EventSystem.current.currentSelectedGameObject == antiGhostButton)
            {
                antiGhostButton.GetComponent<Image>().sprite = antiGhostSprite10;
                antiGhostButton.GetComponent<Button>().interactable = false;
            }
            else
            {
                antiGhostButton.GetComponent<Image>().sprite = antiGhostSprite00;
                antiGhostButton.GetComponent<Button>().interactable = false;
            }
        }

        //mini ghost reducer upgrade
        if (LevelManager.CurrentLevel >= 4)
        {
            miniGhostReducerButton.SetActive(true);
            miniGhostReducerInfo.SetActive(true);
        }
        else
        {
            miniGhostReducerButton.SetActive(false);
            miniGhostReducerInfo.SetActive(false);
        }

        miniGhostReducerRankText.text = ConfigManager.CurrentMiniGhostReducerRank + "/" + ConfigManager.MaxMiniGhostReducerRank;
        miniGhostReducerCostText.text = "$ " + ConfigManager.MiniGhostReducerCost.ToString();

        if (ConfigManager.StartingMoney >= ConfigManager.MiniGhostReducerCost 
            && ConfigManager.CurrentMiniGhostReducerRank < ConfigManager.MaxMiniGhostReducerRank
            && LevelManager.CurrentLevel >= 4)
        {
            if (EventSystem.current.currentSelectedGameObject == miniGhostReducerButton)
            {
                miniGhostReducerButton.GetComponent<Image>().sprite = screamSaverSprite11;
                miniGhostReducerButton.GetComponent<Button>().interactable = true;
            }
            else
            {
                miniGhostReducerButton.GetComponent<Image>().sprite = screamSaverSprite01;
                miniGhostReducerButton.GetComponent<Button>().interactable = true;
            }
        }
        else
        {
            if (EventSystem.current.currentSelectedGameObject == miniGhostReducerButton)
            {
                miniGhostReducerButton.GetComponent<Image>().sprite = screamSaverSprite10;
                miniGhostReducerButton.GetComponent<Button>().interactable = false;
            }
            else
            {
                miniGhostReducerButton.GetComponent<Image>().sprite = screamSaverSprite00;
                miniGhostReducerButton.GetComponent<Button>().interactable = false;
            }
        }

        //cat attack
        if (LevelManager.CurrentLevel >= 6)
        {
            catAttackButton.SetActive(true);
            catAttackInfo.SetActive(true);
        }
        else
        {
            catAttackButton.SetActive(false);
            catAttackInfo.SetActive(false);
        }

        catAttackRankText.text = ConfigManager.CurrentCatAttackRank + "/" + ConfigManager.MaxCatAttackRank;
        catAttackCostText.text = "$ " + ConfigManager.CatAttackCost.ToString();

        if (ConfigManager.StartingMoney >= ConfigManager.CatAttackCost 
            && ConfigManager.CurrentCatAttackRank < ConfigManager.MaxCatAttackRank
            && LevelManager.CurrentLevel >= 6)
        {
            if (EventSystem.current.currentSelectedGameObject == catAttackButton)
            {
                catAttackButton.GetComponent<Image>().sprite = lemonGloveSprite11;
                catAttackButton.GetComponent<Button>().interactable = true;
            }
            else
            {
                catAttackButton.GetComponent<Image>().sprite = lemonGloveSprite01;
                catAttackButton.GetComponent<Button>().interactable = true;
            }
        }
        else
        {
            if (EventSystem.current.currentSelectedGameObject == catAttackButton)
            {
                catAttackButton.GetComponent<Image>().sprite = lemonGloveSprite10;
                catAttackButton.GetComponent<Button>().interactable = false;
            }
            else
            {
                catAttackButton.GetComponent<Image>().sprite = lemonGloveSprite00;
                catAttackButton.GetComponent<Button>().interactable = false;
            }
        }
    }
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class PowerupMenuTexts : MonoBehaviour
{
    [SerializeField] GameObject bombButton;
    [SerializeField] TextMeshProUGUI bombText;
    [SerializeField] TextMeshProUGUI bombCostText;

    [SerializeField] GameObject barrierButton;
    [SerializeField] TextMeshProUGUI barrierText;
    [SerializeField] TextMeshProUGUI barrierCostText;

    [SerializeField] Sprite bombSprite00; //00 - unselected, unavailable
    [SerializeField] Sprite bombSprite01; //01 - unselected, available
    [SerializeField] Sprite bombSprite10; //10 - selected, unavailable
    [SerializeField] Sprite bombSprite11; //11 - selected, available

    [SerializeField] Sprite barrierSprite00; //00 - unselected, unavailable
    [SerializeField] Sprite barrierSprite01; //01 - unselected, available
    [SerializeField] Sprite barrierSprite10; //10 - selected, unavailable
    [SerializeField] Sprite barrierSprite11; //11 - selected, available

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        bombText.text = ConfigManager.CurrentGhostBombs + "/" + ConfigManager.MaxGhostBombs;
        barrierText.text = ConfigManager.CurrentGhostBarrierPowerUps + "/" + ConfigManager.MaxGhostBarrierPowerUps;
        bombCostText.text = "$ " + ConfigManager.GhostBombCost.ToString();
        barrierCostText.text = "$ " + ConfigManager.GhostBarrierCost.ToString();
        if(ConfigManager.StartingMoney >= ConfigManager.GhostBombCost 
            && ConfigManager.CurrentGhostBombs < ConfigManager.MaxGhostBombs)
        {
            if (EventSystem.current.currentSelectedGameObject == bombButton)
            {
                bombButton.GetComponent<Image>().sprite = bombSprite11;
                bombButton.GetComponent<Button>().interactable = true;
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
        if(ConfigManager.StartingMoney >= ConfigManager.GhostBarrierUpgradeCost 
            && ConfigManager.CurrentGhostBarrierPowerUps < ConfigManager.MaxGhostBarrierPowerUps)
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
    }
}

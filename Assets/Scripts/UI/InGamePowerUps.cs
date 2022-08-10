using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InGamePowerUps : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI bombText;
    [SerializeField] TextMeshProUGUI barrierText;
    [SerializeField] GameObject bombButton;
    [SerializeField] GameObject barrierButton;
    [SerializeField] Sprite bombBlueBorder;
    [SerializeField] Sprite bombRedBorder;
    [SerializeField] Sprite barrierBlueBorder;
    [SerializeField] Sprite barrierRedBorder;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        bombText.text = ConfigManager.CurrentGhostBombs + "/" + ConfigManager.MaxGhostBombs;
        barrierText.text = ConfigManager.CurrentGhostBarrierPowerUps + "/" + ConfigManager.MaxGhostBarrierPowerUps;
        if (ConfigManager.CurrentGhostBombs > 0)
        {
            bombButton.GetComponent<Image>().sprite = bombBlueBorder;
            bombButton.GetComponent<Button>().interactable = true;
        }
        else
        {
            bombButton.GetComponent<Image>().sprite = bombRedBorder;
            bombButton.GetComponent<Button>().interactable = false;
        }
        if (ConfigManager.CurrentGhostBarrierPowerUps > 0)
        {
            barrierButton.GetComponent<Image>().sprite = barrierBlueBorder;
            barrierButton.GetComponent<Button>().interactable = true;
        }
        else
        {
            barrierButton.GetComponent <Image>().sprite = barrierRedBorder;
            barrierButton.GetComponent<Button>().interactable = false;
        }
    }
}

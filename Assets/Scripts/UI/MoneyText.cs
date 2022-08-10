using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyText : MonoBehaviour
{
    public bool currentOrTotal;
    [SerializeField] TextMeshProUGUI moneyText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(currentOrTotal)
        {
            moneyText.text = "$" + LevelManager.CurrentMoney.ToString();
        }
        else
        {
            moneyText.text = "$" + ConfigManager.StartingMoney.ToString();
        }

    }
}

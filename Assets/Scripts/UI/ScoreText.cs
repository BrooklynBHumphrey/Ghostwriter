using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI scoreText;
    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Level Complete!" +
            "\nPhrases Completed: " + LevelManager.PhrasesCompleted
            + "\nMoney Earned: $" + (LevelManager.CurrentMoney).ToString()
            + "\nTotal Money: $" + (ConfigManager.StartingMoney).ToString();
    }
}

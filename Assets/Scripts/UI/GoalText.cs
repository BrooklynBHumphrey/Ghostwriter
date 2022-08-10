using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoalText : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI goalText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        goalText.text = LevelManager.PhrasesCompleted + "/" + LevelManager.PhrasesRequired;
    }
}

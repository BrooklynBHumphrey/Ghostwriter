using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NextLevelButton : MonoBehaviour
{
    Button button;
    Image sprite;
    [SerializeField] Sprite nextLevelSprite00;
    [SerializeField] Sprite nextLevelSprite01;
    [SerializeField] Sprite nextLevelSprite10;
    [SerializeField] Sprite nextLevelSprite11;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        sprite = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (LevelManager.LevelCompeleted)
        {
            button.interactable = true;
            if (gameObject == EventSystem.current.currentSelectedGameObject)
            {
                sprite.sprite = nextLevelSprite11;
            }
            else
            {
                sprite.sprite = nextLevelSprite01;
            }
        }
        else
        {
            button.interactable=false;
            sprite.sprite = nextLevelSprite00;
        }
    }
}

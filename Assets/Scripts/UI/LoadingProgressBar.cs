using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class LoadingProgressBar : MonoBehaviour
{
    [SerializeField] Image loadingProgressForeground;
    [SerializeField] float reduceSpeed = 0.01f;
    [SerializeField] GameManager gameManager;
    float target = 1;
    LevelLoadedEvent levelLoadedEvent;
    // Start is called before the first frame update
    void Start()
    {
        levelLoadedEvent = new LevelLoadedEvent();
        EventManager.AddLevelLoadedInvoker(this);
    }

    // Update is called once per frame
    void Update()
    {
        loadingProgressForeground.fillAmount = Mathf.MoveTowards(loadingProgressForeground.fillAmount, target, reduceSpeed * Time.deltaTime);
        if (loadingProgressForeground.fillAmount == target)
        {
            levelLoadedEvent.Invoke();
            ResetLoadingProgressBar();
        }
    }

    public void AddLevelLoadedListener(UnityAction listener)
    {
        levelLoadedEvent.AddListener(listener);
    }


    public void ResetLoadingProgressBar()
    {
        loadingProgressForeground.fillAmount = 0.0f;
    }


}

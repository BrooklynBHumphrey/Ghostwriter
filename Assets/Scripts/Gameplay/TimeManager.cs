using UnityEngine;
using TMPro;
using System;
using UnityEngine.Events;
using UnityEngine.Rendering.PostProcessing;
using System.Collections;

public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance;
    [SerializeField] GameObject timeLeftText;
    TextMeshProUGUI timeLeft;

    [SerializeField] GameObject barrierTimeText;
    TextMeshProUGUI barrierTime;
    float timeValue;
    float prevTime;

    TimesUpEvent timesUpEvent;
    bool timesUpPlayed = false;
    bool countdownPlayed = false;
    const float TIMESUP_TIME = 15.0f;
    const float COUNTDOWN_TIME = 5.0f;

    [SerializeField] PostProcessLayer ppLayer;
    [SerializeField] GameObject shield;
    [SerializeField] PostProcessVolume ppVolume;
    Bloom bloom;


    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        timeValue = prevTime = LevelManager.LevelTime;
        timeLeft = timeLeftText.GetComponent<TextMeshProUGUI>();
        barrierTime = barrierTimeText.GetComponent<TextMeshProUGUI>();
        barrierTime.text = string.Empty;
        timesUpEvent = new TimesUpEvent();
        EventManager.AddTimesUpInvoker(this);
        EventManager.AddLevelStartListener(NextLevel);
        ppVolume.profile.TryGetSettings(out bloom);
        bloom.intensity.value = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if(LevelManager.GameStarted)
        {
            timeValue -= Time.deltaTime;
            if (timeValue < 0)
            {
                timeValue = 0;
                timesUpEvent.Invoke();
            }
            else if (timeValue <= TIMESUP_TIME && !timesUpPlayed)
            {
                StartCoroutine(AudioManager.PlayRandomDialog(AudioClipName.TimesUp, 6.0f));
                timesUpPlayed = true;
                
            }
            else if(timeValue <= COUNTDOWN_TIME && !countdownPlayed)
            {
                AudioManager.Play(AudioClipName.CountDown);
                countdownPlayed = true;
            }
            DisplayTime(timeLeft, timeValue);
            if (timesUpPlayed)
            {
                timeLeft.color = Color.red;
                if((int)prevTime - (int)timeValue > 0 && countdownPlayed)
                {
                    StartCoroutine(FlashTime(timeLeft));
                    prevTime = timeValue;
                }
            }
            else
            {
                timeLeft.color = Color.white;
            }
            if (ConfigManager.GhostBarrierTime > 0.0f)
            {    
                DisplayTime(barrierTime, ConfigManager.GhostBarrierTime);
                Debug.Log(ConfigManager.GhostBarrierTime);
                //ppLayer.enabled = true;
                bloom.intensity.value = 8;
                shield.SetActive(true);
            }
            else
            {
                barrierTime.text = string.Empty;
                //ppLayer.enabled = false;
                bloom.intensity.value = 5;
                shield.SetActive(false);
            }
        }
        else
        {
            barrierTime.text = string.Empty;
        }
    }

    private void DisplayTime(TextMeshProUGUI textMesh,float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        textMesh.text = String.Format("{0:0}:{1:00}", minutes, seconds);

    }
    
    IEnumerator FlashTime(TextMeshProUGUI textMesh)
    {
        for(int i = 0; i <3; i++)
        {
            textMesh.color = Color.white;
            yield return new WaitForSecondsRealtime(0.1f);
            textMesh.color = Color.red;
        }
    }
    


    void NextLevel()
    {
        timeValue = LevelManager.LevelTime;
        timesUpPlayed = false;
        countdownPlayed=false;
    }

    public float GetCurrentTime()
    {
        return timeValue;
    }

    public void AddTimesUpListener(UnityAction listener)
    {
        timesUpEvent.AddListener(listener);
    }
}

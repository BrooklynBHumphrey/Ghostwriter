using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] AnimationCurve curve;
    [SerializeField] Vector3 inGamePos;
    [SerializeField] Vector3 menuPos;
    Vector3 startPos;
    Vector3 endPos;
    float duration = 0.5f;
    float elapsedTime = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        startPos = menuPos;
        endPos = menuPos;
        EventManager.AddLevelStartListener(LevelStart);
        EventManager.AddTimesUpListener(TimesUp);
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        float percent = elapsedTime / duration;
        transform.position = Vector3.Lerp(startPos, endPos, curve.Evaluate(percent));
    }
    void LevelStart()
    {
        elapsedTime = 0.0f;
        startPos = menuPos;
        endPos = inGamePos;
    }
    void TimesUp()
    {
        elapsedTime = 0.0f;
        startPos = inGamePos;
        endPos = menuPos;
    }
}

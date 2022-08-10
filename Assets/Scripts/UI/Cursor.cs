using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    private float timer = 0;
    private const float TIME_LIMIT = 0.5f;
    private bool visible = true;
    // Start is called before the first frame update
    void Start()
    {
        timer = TIME_LIMIT;
    }

    // Update is called once per frame
    void Update()
    {
        if(isActiveAndEnabled)
        {
            timer -= Time.deltaTime;
            if(timer <= 0.0f)
            {
                if (visible)
                {
                    GetComponent<CanvasRenderer>().SetAlpha(0.0f);
                }
                else
                {
                    GetComponent<CanvasRenderer>().SetAlpha(255.0f);
                }
                visible = !visible;
                timer = TIME_LIMIT;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBombCameraShake : MonoBehaviour
{
    [SerializeField] bool start = false;
    [SerializeField] AnimationCurve curve;
    [SerializeField] float duration = 0.5f;

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            start = false;
            StartCoroutine(Shaking());
        }
    }

    public void ShakeCamera()
    {
        start = true;
    }

    IEnumerator Shaking()
    {
        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float strength = curve.Evaluate(elapsedTime / duration);
            transform.position = startPosition + Random.insideUnitSphere * strength;
            yield return null;
        }

        transform.position = startPosition;
    }
}

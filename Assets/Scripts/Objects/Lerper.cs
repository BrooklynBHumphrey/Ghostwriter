using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lerper : MonoBehaviour
{
    [SerializeField] AnimationCurve curve;
    GameObject[] jumpPoints;
    Vector3 endPosition;
    Vector3 startPosition;
    float duration = 0.2f;
    float elapsedTime;
    char character;
    bool isLerping = false;
    SpawnPoint futureSpawnPoint;
    Ghost ghost;

    // Start is called before the first frame update
    void Start()
    {
        ghost = GetComponent<Ghost>();
        jumpPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isLerping)
        {
            elapsedTime += Time.deltaTime;
            float percentageComplete = elapsedTime / duration;
            transform.position = Vector3.Lerp(startPosition, endPosition, curve.Evaluate(percentageComplete));
        }
    }

    public void LerpHacker(Vector3 startPos, Vector3 endPos)
    {
        isLerping = true;
        startPosition = startPos;
        endPosition = endPos;
        ghost.character = character;
    }

    public void ResetElapsedTime()
    {
        elapsedTime = 0f;
    }

    public Vector3 GetJumpPoint()
    {
        GameObject jumpPoint;
 
        while (true)
        {
            int randIndex = Random.Range(0, jumpPoints.Length);
            jumpPoint = jumpPoints[randIndex];

            if (jumpPoint.GetComponent<SpawnPoint>().GetGhostKey() != GetComponent<Ghost>().character)
            {
                break;
            }
        }
        futureSpawnPoint = jumpPoint.GetComponent<SpawnPoint>();
        character = futureSpawnPoint.GetGhostKey();
        return jumpPoint.transform.position;
    }

    public SpawnPoint GetNextSpawnPoint()
    {
        return futureSpawnPoint;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slerper : MonoBehaviour
{
    GameObject[] jumpPoints;
    Transform startPosition;
    Transform endPosition;
    float journeyTime = 0.5f;
    float speed = 0.1f;
    Vector3 centerPoint;
    Vector3 startRelativeCenter;
    Vector3 endRelativeCenter;
    bool isSlerping = false;
    char character;

    // Start is called before the first frame update
    void Start()
    {
        jumpPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
        startPosition = this.transform;
        endPosition = GetJumpPoint();
    }

    // Update is called once per frame
    void Update()
    {
        if (isSlerping)
        {
            GetCenter(Vector3.up);
            float fracComplete = Time.time / journeyTime * speed;
            transform.position = Vector3.Slerp(startRelativeCenter, endRelativeCenter, fracComplete * speed);
            transform.position += centerPoint;
        }
    }

    public void SlerpGhost(Transform startPos, Transform endPos)
    {
        isSlerping = true;
        startPosition = startPos;
        endPosition = endPos;
        GetComponent<Ghost>().character = character;
    }

    public void GetCenter(Vector3 direction)
    {
        centerPoint = (startPosition.position + endPosition.position) * 0.5f;
        centerPoint -= direction;
        startRelativeCenter = startPosition.position - centerPoint;
        endRelativeCenter = endPosition.position - centerPoint;
    }

    public Transform GetJumpPoint()
    {
        GameObject jumpPoint;

        while (true)
        {
            int randIndex = Random.Range(0, jumpPoints.Length);
            jumpPoint = jumpPoints[randIndex];

            if (!transform.position.Equals(jumpPoint.transform.position)) break;
        }

        character = char.Parse(jumpPoint.name.ToLower());

        return jumpPoint.transform;
    }
}

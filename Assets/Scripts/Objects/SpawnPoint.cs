using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] GameObject[] adjacentKeys;
    [SerializeField] char key;
    [SerializeField] TextMeshProUGUI textMesh;
    [SerializeField] Sprite blueSquareBorder;
    [SerializeField] Sprite redSquareBorder;
    [SerializeField] Sprite greenSquareBorder;

    bool haunted = false;
    bool jumpingGhostTarget = false;

    Ghost currentGhost;


    SpriteRenderer spriteRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        textMesh.text = key.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(haunted)
        {
            spriteRenderer.sprite = redSquareBorder;
        }
        else
        {
            currentGhost = null;
            if(jumpingGhostTarget)
            {
                spriteRenderer.sprite = greenSquareBorder;
            }
            else
            {
                spriteRenderer.sprite = blueSquareBorder;
            }
        }
    }

    public char GetGhostKey()
    {
        return key;
    }
    public GameObject[] GetAdjacent()
    { 
        return adjacentKeys;
    }
    public Ghost GetGhost()
    {
        return currentGhost;
    }
    public void SetGhost(Ghost ghost)
    {
        currentGhost = ghost;
    }

    public bool IsHaunted
    {
        get { return haunted; }
    }

    public void SetHauntedStatus(bool haunted)
    {
        this.haunted = haunted;
    }

    public void SetJumpingGhostTargetStatus(bool haunted)
    {
        jumpingGhostTarget = haunted;
    }
}

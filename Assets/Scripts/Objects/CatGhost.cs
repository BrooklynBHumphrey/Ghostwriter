using TMPro;
using UnityEngine;

public class CatGhost : Ghost
{
    [SerializeField] GameObject catGhostSpawnPoint;
    [SerializeField] Animator animator;
    [SerializeField] TextMeshPro cursor;

    public TextMeshPro wordOutput = null;

    private string remainingWord = string.Empty;
    private string currentWord = string.Empty;
    private CatBank catBank;

    private void Start()
    {
        ghostType = GhostType.Cat;
        shift = new Vector3(Random.Range(-30.0f, 30.0f), Random.Range(25.0f, 50.0f), -15.0f);
        AudioManager.PlayRandom(AudioClipName.CatSpawn);
        LevelManager.SetCatActive(true);
        maxHealth = ConfigManager.CatHealth;
        catBank = gameObject.AddComponent<CatBank>();  
        SetCurrentWord();
        health = maxHealth;
    }
    private void FixedUpdate()
    {
        lifetime+=Time.deltaTime;
    }

    public override void Die(bool levelend)
    {
        cursor.enabled = false;
        if (!levelend)
        {
            LevelManager.CatGhostKilled(lifetime);
            AudioManager.PlayRandom(AudioClipName.GhostDeath);
        }

        animator.SetBool("IsDead", true);
    }

    private void SetCurrentWord()
    {
        currentWord = catBank.GetPhrase();
        SetRemainingWord(currentWord);
    }

    private void SetRemainingWord(string newString)
    {
        remainingWord = newString;
        wordOutput.text = remainingWord;
    }

    // TODO: remove update method when ready to push - for testing purposes only
    private void Update()
    {
        CheckInput();
        AdjustCursorPosition();
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Finished"))
        {
            LevelManager.SetCatActive(false);
            Destroy(this.gameObject);
        }
    }

    protected override void CheckInput()
    {
        if(Input.anyKeyDown)
        {
            string keysPressed = Input.inputString;
            if(keysPressed.Length == 1)
            {
                Type(keysPressed);
            }
        }
    }

    private void Type(string letter)
    {
        if(IsCorrectLetter(letter))
        {
            RemoveLetter();
            AudioManager.PlayRandom(AudioClipName.Smack);
            PlayParticleEffect(attackParticles);
            if(IsWordComplete())
            {
                if(--health < 1)
                {
                    Die(false);
                }
                else
                {
                    AudioManager.PlayRandom(AudioClipName.CatDamaged);
                    SetCurrentWord();
                }
            }
        }
    }

    private bool IsCorrectLetter(string letter)
    {
        return remainingWord.IndexOf(letter) == 0;
    }

    private void RemoveLetter()
    {
        string newString = remainingWord.Remove(0, 1);
        SetRemainingWord(newString);
    }

    private bool IsWordComplete()
    {
        return remainingWord.Length == 0;
    }

    private void AdjustCursorPosition()
    {
        TMP_CharacterInfo currentCharacter = wordOutput.textInfo.characterInfo[0];
        Vector3 bottomLeft = currentCharacter.bottomLeft;
        bottomLeft.y = (currentCharacter.ascender - currentCharacter.descender) / 2 + currentCharacter.descender;
        cursor.transform.position = wordOutput.transform.TransformPoint(bottomLeft);
    }

    private void PlayParticleEffect(GameObject particle)
    {
        var ghostTransform = gameObject.transform;
        Vector3 shift = new Vector3(Random.Range(-30.0f, 30.0f), Random.Range(25.0f, 50.0f), -15.0f);

        Instantiate(particle, ghostTransform.position + shift, Quaternion.Euler(new Vector3(-90, 0, 0)));
    }
}

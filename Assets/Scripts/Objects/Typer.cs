using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.Events;
using System.Linq;

public class Typer : MonoBehaviour
{
    ////colors for letters
    //Color32 white32 = new Color32(255, 255, 255, 255);
    //Color32 red32 = new Color32(255, 0, 0, 255);
    //Color32 green32 = new Color32(0, 255, 0, 255);

    [SerializeField] TextMeshProUGUI outputText;
    TMP_TextInfo textInfo;
    [SerializeField] TextMeshProUGUI cursor;

    [SerializeField] PhraseBank phraseBank;
    [SerializeField] GameManager gameManager;
    private Dictionary<char, SpawnPoint> keysDict;

    private string typedString;
    private string targetString;
    private int currentIndex = 0;

    private float phraseTimer = 0.0f;

    

    //Events
    PhraseCompletedEvent phraseCompletedEvent;
    // Start is called before the first frame update
    void Start()
    {
        keysDict = new Dictionary<char, SpawnPoint>();
        phraseCompletedEvent = new PhraseCompletedEvent();
        EventManager.AddPhraseCompletedInvoker(this);
    }
    public void Initialize()
    {
        if (keysDict.Count == 0)
        {
            GameObject[] keys = GameObject.FindGameObjectsWithTag("SpawnPoint");
            foreach(GameObject key in keys)
            {
                SpawnPoint spawnPoint = key.GetComponent<SpawnPoint>();
                keysDict.Add(spawnPoint.GetGhostKey(), spawnPoint);
            }
        }
        phraseBank.StartLevel();
        SetTargetPhrase();     
    }

    // Update is called once per frame
    void Update()
    {
        if (!LevelManager.GameStarted) return;

        phraseTimer += Time.deltaTime;
        CheckInput();
        UpdateMonitorText();
        CheckText();
        AdjustCursorPosition();

    }

    private void AdjustCursorPosition()
    {
        TMP_CharacterInfo currentCharacter;
        Vector3 point;
        if(currentIndex < outputText.textInfo.characterInfo.Length)
        {
            currentCharacter = outputText.textInfo.characterInfo[currentIndex];
            point = currentCharacter.bottomLeft;
            
        }
        else
        {
            currentCharacter = outputText.textInfo.characterInfo.Last();
            point = currentCharacter.bottomRight;
        }
        point.y = (currentCharacter.ascender - currentCharacter.descender)/2 + currentCharacter.descender;
        cursor.transform.position = outputText.transform.TransformPoint(point);
    }

    private void SetTargetPhrase()
    {
        typedString = string.Empty;
        currentIndex = 0;
        if(LevelManager.CurrentLevel > 7)
        {
            targetString = phraseBank.GetComponent<PhraseBank>().GetRandomPhrase();
        }
        else
        {
            targetString = phraseBank.GetComponent<PhraseBank>().GetPhrase();
        }
        outputText.text = targetString;
        //CheckText();
        //AdjustCursorPosition();
        AudioManager.Play(AudioClipName.PhraseComplete);
    }

    private void PlayerType(char letter)
    {
        if (!keysDict.ContainsKey(char.ToUpper(letter)))
        {
            Type(gameObject, letter);
            return;
        }

        SpawnPoint key = keysDict[char.ToUpper(letter)];
        if(ConfigManager.CurrentAntiGhostWareRank > 1)
        {
            foreach(GameObject adjacentKey in key.GetAdjacent())
            {
                SpawnPoint adjacent = adjacentKey.GetComponent<SpawnPoint>();
                if(adjacent.IsHaunted)
                {
                    adjacent.GetGhost().TakeDamage();
                }
            }
        }

        if (ConfigManager.CurrentAntiGhostWareRank <= 2)
        {
            Type(gameObject, letter);
            return;
        }

        if (!key.IsHaunted)
        {
            Type(gameObject, letter);
        }   
        
    }

    public void Type(GameObject typer ,char letter)
    {
        if (currentIndex >= 600) return;
        if(typer != null)
        {
            if (typer.tag == "Ghost")
            {
                AudioManager.Play(AudioClipName.GhostType);
            }
            else
            {
                AudioManager.PlayRandom(AudioClipName.Typing);
            }
        }
        typedString += letter;
        currentIndex++;
        //UpdateMonitorText();
    }


    public void Backspace()
    {
        if(currentIndex > 0)
        {
            AudioManager.PlayRandom(AudioClipName.Typing);           
            typedString = typedString.Substring(0, typedString.Length - 1);
            currentIndex--; 
            //UpdateMonitorText();
        }
    }

    private void UpdateMonitorText()
    {
        if (currentIndex > targetString.Length-1)
        {
            outputText.text = typedString;
        }
        else
        {
            outputText.text = typedString + targetString.Substring(typedString.Length, targetString.Length - typedString.Length);
        }
        //CheckText();
    }

    private void CheckInput()
    {
        if (LevelManager.CatActive) return;

        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            gameManager.ClearGhosts();
        }
        if (Input.GetKeyDown(KeyCode.RightAlt))
        {
            gameManager.BlockGhosts();
        }
       
        foreach (char c in Input.inputString)
        {
            if (c == '\b')
            {
                Backspace();
            }
            else if (c!='\n' && c != '\r')
            {
                PlayerType(c);
            }
        }  
    }

    private void CheckText()
    {
        outputText.ForceMeshUpdate();
        textInfo = outputText.textInfo;
        int size = typedString.Length;
        int targetSize = targetString.Length;
        if (typedString.Equals(targetString))
        {
            phraseCompletedEvent.Invoke(targetString, phraseTimer);
            phraseTimer = 0.0f;
            SetTargetPhrase();
            size = 0;
            targetSize = targetString.Length;
            textInfo = outputText.textInfo;
            return;
        }

        if (size > targetSize)
        {
            for (int i = 0; i < targetSize; i++)
            {
                CheckCharacter(textInfo, i);
            }
            for (int i = targetSize; i < size; i++)
            {
                CheckForSpace(i);
                SetCharColor(textInfo, i, ConfigManager.BadColor);
            }
        }
        else
        {
            for (int i = 0; i < size; i++)
            {
                CheckCharacter(textInfo, i);
            }
            for (int i = size; i < targetSize; i++)
            {
                SetCharColor(textInfo, i, ConfigManager.NeutralColor);
            }
        }
        if (size > 0)
        {
            CheckCharacter(textInfo, 0);
        }
    }

    private void CheckCharacter(TMP_TextInfo textInfo, int position)
    {
        if (typedString[position] == targetString[position])
        {
            SetCharColor(textInfo, position, ConfigManager.GoodColor);
        }
        else
        {
            CheckForSpace(position);
            SetCharColor(textInfo, position, ConfigManager.BadColor);
        }
    }
    private void CheckForSpace(int i)
    {
        if (typedString[i].Equals(' '))
        {
            Backspace();
            Type(null,'_');
        }
    }
    private void SetCharColor(TMP_TextInfo textInfo, int charId, Color32 color)
    {
        if(charId < textInfo.characterInfo.Length)
        {
            int materialIndex = textInfo.characterInfo[charId].materialReferenceIndex;
            Color32[] vertexColors = textInfo.meshInfo[materialIndex].colors32;
            int vertexIndex = textInfo.characterInfo[charId].vertexIndex;
            vertexColors[vertexIndex + 0] = color;
            vertexColors[vertexIndex + 1] = color;
            vertexColors[vertexIndex + 2] = color;
            vertexColors[vertexIndex + 3] = color;
            outputText.UpdateVertexData(TMP_VertexDataUpdateFlags.Colors32);
        }
    }

    public void AddPhraseCompletedListener(UnityAction<string, float> listener)
    {
        phraseCompletedEvent.AddListener(listener);
    }
}




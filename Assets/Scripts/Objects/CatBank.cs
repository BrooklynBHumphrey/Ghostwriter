using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CatBank : MonoBehaviour
{
    private List<string> originalWords = new List<string>()
    {
        "Whatcha doin'?","Look at me!","Meow!", "Feed me.", "Bad human!", "Pspspspsps"
        ,"Woof!","Brrrp?","I watch you while you sleep."
    };
    private List<string> workingWords = new List<string>();
    private void Awake()
    {
        ResetWorkingPhrases();
    }    
    private void ResetWorkingPhrases()
    {
        workingWords.AddRange(originalWords);
        Shuffle(workingWords);
    }
    private void Shuffle(List<string> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int random = Random.Range(i, list.Count);
            string temporary = list[i];
            list[i] = list[random];
            list[random] = temporary;
        }
    }

    public string GetPhrase()
    {
        string newPhrase = string.Empty;
        if (workingWords.Count != 0)
        {
            newPhrase = workingWords.Last();
            workingWords.Remove(newPhrase);
        }
        else
        {
            ResetWorkingPhrases();
            newPhrase = workingWords.Last();
            workingWords.Remove(newPhrase);
        }
        return newPhrase;
    }
}

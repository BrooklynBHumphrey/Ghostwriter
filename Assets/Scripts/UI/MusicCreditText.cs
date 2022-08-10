using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MusicCreditText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI creditText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch(LevelManager.CurrentLevel)
        {
            case 1:
                creditText.text = "Placeholder Music: Chipzel - Crypteque (Crypt of the Necrodancer OST Remix) (orig. by Danny Baranowsky)";
                break;
            case 2:
                creditText.text = "Placeholder Music: Chimpazilla - Voltzwaltz (Crypt of the Necrodancer OST Remix) (orig. by Danny Baranowsky)";
                break;
            case 3:
                creditText.text = "Placeholder Music: Kruai - March of the Profane (Crypt of the Necrodancer OST Remix) (orig. by Danny Baranowsky)";
                break;
            default:
                creditText.text = "Placeholder Music: Suizin - Heart of the Crypt (Crypt of the Necrodancer OST Remix) (orig. by Danny Baranowsky)";
                break;
        }
    }
}

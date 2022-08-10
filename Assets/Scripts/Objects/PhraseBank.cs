using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//PhraseBank code from VR with Andrew - https://www.youtube.com/watch?v=tdXXW0ln_LU
public class PhraseBank : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI quoteText;
    private List<string> level1Phrases = new List<string>() //Basic
    {
        "Quack!","Beans on toast.","You must be a fast typer, huh?","supercalifragilisticexpialidocious", "Sorry, that sounded really ominous earlier."
        ,"Since you're supposed to be working here and all...","Actually, you're not going anywhere."
        ,  "Get out there and start hunting some ghosts!","That's it. Have fun!"
        , "Complete as many phrases as you can within the time limit.","Block hauntings with Right-Alt.", "Smite all with Left-Alt.", "Wash your hands."
        ,  "With your finger.","Poke ghosts."  ,"CASE-SENSITIVE", "no mistakes","type what you see"
    };
    private List<string> level2Phrases = new List<string>() //game quotes Jumping
    {
        "Khajiit has wares.",  "Take a look!", "Would you kindly?", "My life for Aiur.","Get over here!",
        "Nanomachines, son!", "Fus-Roh-Dah!", "Rise and shine, Mr. Freeman.", "Nothing is true, everything is permitted.", "Sir, finishing this fight."
        ,"Do you know the definition of insanity?", "HYEEEEAHHH!" , "The cake is a lie."
        ,"War. War never changes...", "It's dangerous to go alone! Take this.", "Endure and survive.", "Good night, good luck.", "Protocol three: Protect the Pilot.", "I miss the internet."
        ,"Stay awhile, and listen!", "It's a-me, Mario!", "What is a man?", "Rip and Tear, until it is done!", "Snake? Snake? SNAAAAAAAKE!!!!"
        ,"Every puzzle has an answer.", "Hey! Listen!", "It hurt itself in its confusion!", "I'm in space. SPAAAAACE!", "Do a barrel roll!", "Stop right there, criminal scum!", "Someone else might have gotten it wrong."
        ,"Does this unit have a soul?", "Cousin! Let's go bowling!", "Praise the sun!", "You have died of dysentery."
    };
    private List<string> level3Phrases = new List<string>() //TV film quotes, Basic Jumping
    {
        "Ring ding ding ding ding ding ding ding.","I see dead people...", "Treat yo self." ,"Seize the day!",  "Do I feel lucky? Well, do ya, punk?", "Who you callin' pinhead?", "Hasta la vista, baby." ,"We dug coal together.", "What is grief, but love persevering?"
        ,"I don't want it. You're my queen.", "So, pick me. Choose me. Love me.", "You come at the king, you best not miss", "Frankly, my dear, I don't give a damn.", "Go ahead, make my day.", "May the Force be with you.", "Love means never having to say you're sorry."
        ,"E.T. phone home.", "There's no place like home.", "You can't handle the truth!", "I'll have what she's having.", "You're gonna need a bigger boat.", "Well, nobody's perfect.", "Houston, we have a problem.", "Say \"hello\" to my little friend!"
        ,"You ain't heard nothin' yet!", "Soylent Green is people!", "I'm afraid I can't do that.", "It was Beauty killed the Beast.", "You have no power here, Gandalf!", "A martini, shaken, not stirred."
        ,"I feel the need - the need for speed!", "Nobody puts Baby in a corner.", "I'm king of the world!", "Sorry I annoyed you with my friendship.", "Legen-wait for it!... DARY!!"
    };
    private List<string> level4Phrases = new List<string>() //spelling bee Mini
    {
        "achievement","appearance","syzygy","caveola", "brouillon", "dreikanter","enthusiasm","cabochon", "penicillin","embolus"
        ,"effleurage", "pneumonia", "xiphas","demitasse", "zydeco","kaffeeklatsch","shareholder", "denouement","malleolus" , "courtesy"
        , "peregrination", "glaucomatous", "vamoose", "garrulity", "ambystoma", "saxicolous", "relaxation","mathematics", "physical","demulcent"
        ,"neglect", "abysmal", "geriatric", "egregious", "galvanizing", "omnipotent", "promulgate","reconsideration","melodramatic","indiscriminately"
        ,"pharaoh", "pronunciation", "handkerchief", "logorrhea", "gobbledegook", "portmanteau", "telecommunications", "clinquant", "gladiolus"
        ,"insouciant","crustaceology", "xanthosis", "stichomythia", "scherenschnitte", "schaedenfreude", "gesellschaft","fossiliferous", "chiffonade"
        ,"rembrandt" ,"beelzebub","hydrargyrum", "laryngitis", "misdemeanor", "tumultuous", "crystallographer", "woebegoneness","montessorian"
        ,"oryzivorous", "soliloquy", "prerogative", "corpuscle", "repertoire", "rendezvous", "surveillance", "fusillade","lieutenant"
        ,"smaragdine", "soubrette", "eudaemonic", "chiaroscurist", "autochthonous", "staphylococci", "onomatopoeia", "prospicience", "malfeasance"
        ,"antediluvian", "foudroyant", "feuilleton", "chrematistic"
    };
    private List<string> level5Phrases = new List<string>() //Literature quotes Basic Jumping Mini
    {
        "To be or not to be. That is the question", "I don't like that Sam I Am.", "Whatever our souls are made of, his and mine are the same.", "Not all those who wander are lost.", "What light through yonder window breaks?"
        ,"I assure you that the world is not so amusing as something we imagined.", "Sometimes, I've believed as many as six impossible things before breakfast.", "Laugh as much as you choose, but you will not laugh me out of my opinion."
        ,"Time, which sees all things, has found you out.", "They looked at each other, baffled, in love and hate.","The pain of parting is nothing to the joy of meeting again.","Procrastination is the thief of time, collar him."
        ,"I gave my whole heart up, for him to hold.","Who controls the past controls the future. Who controls the present controls the past.", "We shall meet in the place where there is no darkness."
        ,"All we have to decide is what to do with the time that is given us.","That is the one unforgivable sin in any society. Be different and be damned!","Every man desires to live long, but no man wishes to be old"
        ,"I know not all that may be coming, but be it what it will, I'll go it laughing","It's no use going back to yesterday, because I was a different person then","If you tell the truth you do not need a good memory!"
        ,"I have got key to my castle in the air, but whether I can unlock the door remains to be seen.","We are asleep until we fall in love!"
    };
    private List<string> level6Phrases = new List<string>() //Etc Cat basic
    {
        "Have you ever had a dream, that you, um, you had, your, you- you could, you'll do, you- you wants, you, you could do so, you-",
        "WARNING! Prolonged interactions with ghosts may afhect your central nervous ssystems in unexpeafcted waasu so bre caraewafil!",
        "We are obligated under Prop 65 to warn you that significant exposure to ectoplasm may cause cancer, birth defects, or other reproductive harm.",
        "Hello! This is Brooklyn and James, the developers of this game. We would like to sincerely thank you for playing our game! We hope you enjoyed it so far!",
        "sihT esarhp sah on neddih gninaem. tI si ylno tnaem ot etartsurf uoy.",
        "Feeling dry, wrinkly, and ashy? Moisturize! Cover yourself with snails for silky smooth skin on the go! Get your free sample pack today!",
        "We here at Ghoulastic Publishing value the physical and mental well-being of our employers. Criticisms of management is strictly forbidden.",
        "Ghosts have feelings too. How about you ask them for some writing tips instead of poking them all the time?",
        "Clean your keyboard at the end of the day. Ectoplasm is sticky, can accumulate quickly, and will negatively affect your productivity.",
        "Exorcism methods not sold by Ghoulastic are prohibited from company premises. Anyone in violation will be subject to termination immediately.",
        "You may encounter some ghosts that claim to be a former co-worker. This is a common phishing tactic. Disregard them and keep working.",
        "Having some trouble with your writing? Ask for assistance from one of our many reformed ghosts at the Ghoulastic Writing Center!",
        "In the event of a ghost uprising, please calmly make your way to the Human Resources department and file"
    };
    private List<string> level7Phrases = new List<string>() //All Programming
    {
        "if(gameState==GameState::ongoing)", 
        "User->GetComponent<Typer>().IsItEverGoingToEnd();" , 
        "public static void main (String[] args)",
        "IteratorTestSync.list.iterator();" ,
        "while(ghost->IsPoltergeistin())", 
        "Debug.Log(\"Welcome to Level 7!\");", 
        "Ghost* ghost = new Ghost(this,1.4f);",
        "else if(IsGibberish()) ReevaluateLife();", 
        "int health = ConfigManager.BaseHealth;", 
        "for(int i=0; i<7; i++) Poke();" ,
        "SmooshGhost(Ghost* target, float duration);",
        "AudioManager.PlayRandom(AudioClipName.Scream);" ,
        "StartCoroutine(PokePlayer(mForeheadPos,0.1f));", 
        "public bool DoesCatCare() { return false; }",
        "std::cout << \"Hello world!\" << std::endl;" ,
        "Ghost[] smooshVictims = FindObjectsOfType<Ghost>();", 
        "printf(\"Hope Left = %f\", mHope);"
    };
    private Dictionary<string, string> quoteCredits = new Dictionary<string, string>()
    {
        //level 2
        { "Khajiit has wares.", "- <i>The Elder Scrolls V: Skyrim</i>. Bethesda Softworks, 2011." },
        { "Take a look!", "- <i>The Elder Scrolls V: Skyrim</i>. Bethesda Softworks, 2011." },
        { "Would you kindly?", "- <i>BioShock</i>. 2K Games, 2007." },
        { "My life for Aiur.","- <i>StarCraft</i>. Blizzard Entertainment, 1998." },
        { "Get over here!","- <i>Mortal Kombat</i>. Midway, 1992." },
        { "Nanomachines, son!" ,"<i>Metal Gear Rising: Revengeance</i>. Konami Digital Entertainment, 2013." },
        { "Fus-Roh-Dah!" , "- <i>The Elder Scrolls V: Skyrim</i>. Bethesda Softworks, 2011." },
        { "Rise and shine, Mr. Freeman.", "- <i>Half-Life 2</i>. Valve, 2004." },
        { "Nothing is true, everything is permitted.","- <i>Assassin's Creed</i>. Ubisoft, 2007." },
        { "Sir, finishing this fight.", "- <i>Halo 3</i>. Microsoft Game Studios, 2007." },
        { "Do you know the definition of insanity?", "- <i>Far Cry 3</i>. Ubisoft, 2012." },
        { "HYEEEEAHHH!" , "- <i>The Legend of Zelda</i>. Nintendo, 1986." },
        { "The cake is a lie.", "- <i>Portal</i>. Valve, 2007." },
        { "War. War never changes...","- <i>Fallout</i>. Interplay Productions, 1997." },
        { "It's dangerous to go alone! Take this.", "- <i>The Legend of Zelda</i>. Nintendo, 1986." },
        { "Endure and survive.", "- <i>The Last of Us</i>. Sony Interactive Entertainment, 2014." },
        { "Good night, good luck.","- <i>Dying Light</i>. Warner Bros. Interactive Entertainment, 2015." },
        { "Protocol three: Protect the Pilot.","- <i>Titanfall 2</i>. Electronic Arts, 2016." },
        { "I miss the internet.","- <i>Left 4 Dead</i>. Valve 2008." },
        { "Stay awhile, and listen!", "- <i>Diablo 2</i>. Blizzard Entertainment, 2000." },
        { "It's a-me, Mario!", "- <i>Super Mario 64</i>. Nintendo, 1996." },
        { "What is a man?", "- <i>Castlevania: Symphony of the Night</i>. Konami, 1997." },
        { "Rip and Tear, until it is done!" , "- <i>Doom (2016)</i>. Bethesda Softworks, 2016."},
        { "Snake? Snake? SNAAAAAAAKE!!!!" , "- <i>Metal Gear Solid 2</i>. Konami, 2001." },
        { "Every puzzle has an answer." , "- <i>Professor Layton and the Curious Village</i>. Nintendo, 2007." },
        { "Hey! Listen!", "- <i>The Legend of Zela: Ocarina of Time</i>. Nintendo, 1998." },
        { "It hurt itself in its confusion!", "- <i>Pokemon Red and Blue</i>. Nintendo, 1996." },
        { "I'm in space. SPAAAAACE!", "- <i>Portal 2</i>. Valve, 2011." },
        { "Do a barrel roll!", "- <i>Star Fox 64</i>. Nintendo, 1997." },
        { "Stop right there, criminal scum!", "- <i>The Elder Scrolls IV: Oblivion</i>. Bethesda Softworks, 2006." },
        { "Someone else might have gotten it wrong.", "- <i>Mass Effect 3</i>. Electronic Arts, 2012." },
        { "Does this unit have a soul?", "- <i>Mass Effect 3</i>. Electronic Arts, 2012." },
        { "Cousin! Let's go bowling!", "- <i>Grand Theft Auto IV</i>. Rockstar Games, 2008." },
        { "Praise the sun!", "- <i>Dark Souls</i>. Namco Bandai Games, 2011." },
        { "You have died of dysentery." , "- <i>The Oregon Trail</i>. MECC, 1971." },
        //Level 3
        { "Ring ding ding ding ding ding ding ding.", "- \"The Fox (What Does the Fox Say?\". <i>YouTube</i>, 1971." },
        { "I see dead people...", "- <i>The Sixth Sense</i>. Buena Vista Pictures, 1999." },
        { "Treat yo self." , "- <i>Parks & Recreation</i>. NBC Universal, 2011." },
        { "Seize the day!", "- <i>Dead Poets Society</i>. Buena Vista Pictures, 1989." },
        { "Do I feel lucky? Well, do ya, punk?", "- <i>Dirty Harry</i>. Warner Bros., 1971." },
        { "Who you callin' pinhead?", "- <i>SpongeBob SquarePants</i>. Nickelodeon, 1999." },
        { "Hasta la vista, baby." , "- <i>Terminator 2: Judgement Day</i>. Tri-Star Pictures, 1991." },
        { "We dug coal together.", "- <i>Justified</i>. FX, 2010." },
        { "What is grief, but love persevering?", "- <i>WandaVision</i>. Disney, 2021." },
        { "I don't want it. You're my queen.", "- <i>Game of Thrones</i>. HBO, 2019." },
        { "So, pick me. Choose me. Love me.", "- <i>Grey's Anatomy</i>. ABC, 2005." },
        { "You come at the king, you best not miss", "- <i>The Wire</i>. HBO, 2002." },
        { "Frankly, my dear, I don't give a damn.", "- <i>Gone with the Wind</i>. Loew's Inc., 1939." },
        { "Go ahead, make my day.", "- <i>Sudden Impact</i>. Warner Bros., 1983." },
        { "May the Force be with you.", "- <i>Star Wars</i>. 20th Century Fox, 1977." },
        { "Love means never having to say you're sorry.", "- <i>Love Story</i>. Paramount Pictures, 1970." },
        { "E.T. phone home.", "- <i>E.T. the Extra-Terrestrial</i>. Universal Pictures, 1982." },
        { "There's no place like home.", "- <i>The Wizard of Oz</i>. Loew's Inc., 1939." },
        { "You can't handle the truth!", "- <i>A Few Good Men</i>. Columbia Pictures, 1992." },
        { "I'll have what she's having.", "- <i>When Harry Met Sally...</i>. Columbia Pictures, 1989." },
        { "You're gonna need a bigger boat.", "- <i>Jaws</i>. Universal Pictures, 1975." },
        { "Well, nobody's perfect.", "- <i>Some Like It Hot</i>. United Artists, 1959." },
        { "Houston, we have a problem.", "- <i>Apollo 13</i>. Universal Pictures, 1995." },
        { "Say \"hello\" to my little friend!", "- <i>Scarface</i>. Universal Pictures, 1983." },
        { "You ain't heard nothin' yet!", "- <i>The Jazz Singer</i>. Warner Bros., 1927." },
        { "Soylent Green is people!", "- <i>Soylent Green</i>. Metro-Goldwyn-Mayer, 1973." },
        { "I'm afraid I can't do that.", "- <i>2001: A Space Odyssey</i>. Metro-Goldwyn-Mayer, 1968." },
        { "It was Beauty killed the Beast.", "- <i>King Kong</i>. RKO Radio Pictures, 1933." },
        { "You have no power here, Gandalf!", "- <i>The Lord of the Rings: The Two Towers</i>. New Line Cinema, 2002." },
        { "A martini, shaken, not stirred.", "- <i>Goldfinger</i>. United Artists, 1964." },
        { "I feel the need - the need for speed!", "- <i>Top Gun</i>. Paramount Pictures, 1986." },
        { "Nobody puts Baby in a corner.", "- <i>Dirty Dancing</i>. Vestron Pictures, 1987." },
        { "I'm king of the world!", "- <i>Titanic</i>. Paramount Pictures, 1997." },
        { "Sorry I annoyed you with my friendship.", "- <i>The Office</i>. NBC, 2005." },
        { "Legen-wait for it!... DARY!!", "- <i>How I Met YOur Mother</i>. CBS, 2005." },
        //Level 5
        { "To be or not to be. That is the question", "- William Shakespeare, <i>Hamlet</i>" },
        { "I don't like that Sam I Am.", "- Dr. Seuss, <i>Green Eggs and Ham</i>" },
        { "Whatever our souls are made of, his and mine are the same.", "- Emily Bronte, <i>Wuthering Heights</i>" },
        { "Not all those who wander are lost.", "- J.R.R. Tolkein, <i>The Fellowship of the Ring</i>" },
        { "What light through yonder window breaks?", "- William Shakespeare, <i>Romeo and Juliet</i>" },
        { "I assure you that the world is not so amusing as something we imagined.", "- Pierre Choderlos de Laclos, <i>Dangerous Liasons</i>" },
        { "Sometimes, I've believed as many as six impossible things before breakfast.", "- Lewis Carroll, <i>Alice's Adventures in Wonderland</i>" },
        { "Laugh as much as you choose, but you will not laugh me out of my opinion.", "- Jane Austen, <i>Pride and Prejudice</i>" },
        { "Time, which sees all things, has found you out.", "- Sophocles, <i>Oedipus the King</i>" },
        { "They looked at each other, baffled, in love and hate.", "- William Golding, <i>Lord of the Flies</i>" },
        { "The pain of parting is nothing to the joy of meeting again.", "- Charles Dickens, <i>Nicholas Nickleby</i>" },
        { "Procrastination is the thief of time, collar him.", "- Charles Dickens, <i>David Copperfield</i>" },
        { "I gave my whole heart up, for him to hold.", "- Geoffrey Chaucer, <i>The Canterbury Tales</i>" },
        { "Who controls the past controls the future. Who controls the present controls the past.", "- George Orwell, <i>1984</i>" },
        { "We shall meet in the place where there is no darkness.", "- George Orwell, <i>1984</i>" },
        { "All we have to decide is what to do with the time that is given us.", "- J.R.R. Tolkein, <i>The Fellowship of the Ring</i>" },
        { "That is the one unforgivable sin in any society. Be different and be damned!", "- Margaret Mitchell, <i>Gone with the Wind</i>" },
        { "Every man desires to live long, but no man wishes to be old", "- Jonathan Swift, <i>Gulliver's Travels</i>" },
        { "I know not all that may be coming, but be it what it will, I'll go it laughing", "- Herman Melville, <i>Moby-Dick</i>" },
        { "It's no use going back to yesterday, because I was a different person then", "- Lewis Carroll, <i>Alice's Adventures in Wonderland</i>" },
        { "If you tell the truth you do not need a good memory!", "- MArk Twain, <i>Adventures of Huckleberry Finn</i>" },
        { "I have got key to my castle in the air, but whether I can unlock the door remains to be seen.", "- Louisa May Alcott, <i>Little Women</i>" },
        { "We are asleep until we fall in love!", "- Leo Tolstoy, <i>War and Peace</i>" }
    };

    private List<string> nouns = new List<string>()
    {
        "the Rock", "our sponsor","Spider-man","Macho Man Randy Savage", "the Undertaker", 
        "Scooby-Doo", "Buzz Lightyear", "Mr. Potato-Head", "Scarlett Johansson", "Ashley Tisdale", 
        "Taylor Swift", "Inigo Montoya","Vincent D'Onofrio", "Mankind", "a cake", "Peter Pan",
        "Amanda Seyfried", "Alfred Hitchcock", "Mary Poppins","Rick James", "Liz Lemon", 
        "Amy Poehler", "Meredith Palmer", "a calico cat", "the german shepherd", "the ragamuffin",
        "Daft Punk", "the League of Scottish Folds", "Omni-man", "Margo Martindale", "Zendaya", 
        "Matt Murdock", "Jeff Bridges","Microsoft","Walt Disney","Michael Scott", "John Wick", "Eric Cartman",
        "my psychiatrist", "your soul"
    };
    private List<string> verbs = new List<string>()
    {
        "admonished", "destroys", "emulsified", "claims to dislike", "wants to feel like", "threw", "baked", "avenged","toyed with", "protects", "pets", "wallops"
        ,"is a fan of", "runs away from", "was horrified by", "triumphed over", "initiated a hostile takeover of", "bankrupted"
        ,"humiliated", "enjoyed a nice walk with", "helped","chased", "was fed", "ran away from", "is chasing", "felt disappointed by", "failed"
    };
    private List<string> prepostionals = new List<string>()
    {
        "for the time being", "with some strawberries","from the shadows", "in ten seconds", "for being such a fool", "just because", "as they were told", "with friends", "with family", "surrounded by loved ones", "underground","away from civilization",
        "under the bed", "in Central Park", "to the moon", "with love", "over there", "right here"
    };
    private List<string> objects = new List<string>()
    {
        //singular
        "the Rock", "our sponsor","Spider-man","Macho Man Randy Savage", "the Undertaker",
        "Scooby-Doo", "Buzz Lightyear", "Mr. Potato-Head", "Scarlett Johansson", "Ashley Tisdale",
        "Taylor Swift", "Inigo Montoya","Vincent D'Onofrio", "Mankind", "a cake", "Peter Pan",
        "Amanda Seyfried", "Alfred Hitchcock", "Mary Poppins","Rick James", "Liz Lemon",
        "Amy Poehler", "Meredith Palmer", "a calico cat", "the german shepherd", "the ragamuffin",
        "Daft Punk", "the League of Scottish Folds", "Omni-man", "Margo Martindale", "Zendaya",
        "Matt Murdock", "Jeff Bridges","Microsoft","Walt Disney","Michael Scott", "John Wick", "Eric Cartman",
        "my psychiatrist", "your soul"
        //plural
        ,"fish people","all the people", "five old men", "a bucket of blood", "three blind mice", "onion soup", "stacks of pamphlets", "chicken fingers", "Krabby-Patties"
    };

    private List<string> conjunctions = new List<string>()
    {
        "and","but","or","yet", "so"
    };
    private List<string> punctuations = new List<string>()
    {
        ".","?","!",","
    };

    private List<string> workingPhrases = new List<string>();

    public void StartLevel()
    {
        ResetWorkingPhrases(LevelManager.CurrentLevel);
    }

    private void ResetWorkingPhrases(int currentLevel)
    {
        workingPhrases.Clear();
        switch (currentLevel)
        {
            case 1:
                workingPhrases.AddRange(level1Phrases);
                break;
            case 2:
                workingPhrases.AddRange(level2Phrases);        
                break;
            case 3:                                                     
                workingPhrases.AddRange(level3Phrases);
                break;
            case 4:
                workingPhrases.AddRange(level4Phrases);
                break;
            case 5:
                workingPhrases.AddRange(level5Phrases);
                break;
            case 6:
                workingPhrases.AddRange(level6Phrases);
                break;
            case 7:
                workingPhrases.AddRange(level7Phrases);
                break;
            default:
                break;

        }
        if(currentLevel != 1)
        {
            Shuffle(workingPhrases);
        }

    }

    private void Shuffle(List<string> list)
    {
        for(int i=0; i <list.Count;i++)
        {
            int random = Random.Range(i, list.Count);
            string temporary = list[i];
            list[i] = list[random];
            list[random] = temporary;
        }
    }

    public string GetPhrase()
    {
        string newPhrase;
        if (workingPhrases.Count != 0)
        {
            newPhrase = workingPhrases.Last();
            
            workingPhrases.Remove(newPhrase);
        }
        else
        {
            ResetWorkingPhrases(LevelManager.CurrentLevel);
            newPhrase = workingPhrases.Last();
            workingPhrases.Remove(newPhrase);
        }
        if (LevelManager.CurrentLevel == 2 || LevelManager.CurrentLevel == 3 || LevelManager.CurrentLevel == 5)
        {
            quoteText.text = quoteCredits[newPhrase];
        }
        else
        {
            quoteText.text = string.Empty;
        }
        return newPhrase;
    }
    public string GetRandomPhrase()
    {
        string newPhrase;
        int wordCount = 5+LevelManager.CurrentLevel/2;
        newPhrase = nouns[Random.Range(0, nouns.Count)] + " "
            + verbs[Random.Range(0,verbs.Count)] + " "
            + nouns[Random.Range(0, nouns.Count)];
        if (newPhrase.Split(" ").Length < wordCount/2)
        {
            newPhrase += ", "+ conjunctions[Random.Range(0, conjunctions.Count)] + " " 
                + nouns[Random.Range(0, nouns.Count)] + " "
                + verbs[Random.Range(0, verbs.Count)] + " "
                + nouns[Random.Range(0, nouns.Count)];

        }
        if(newPhrase.Split(" ").Length < wordCount)
        {
            newPhrase += " " + prepostionals[Random.Range(0, prepostionals.Count)];
        }

        newPhrase += punctuations[Random.Range(0,punctuations.Count-1)];
        char[] phrase = newPhrase.ToCharArray();
        phrase[0] = char.ToUpper(phrase[0]);;
        return new string(phrase);
    }

}

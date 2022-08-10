using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The audio manager
/// </summary>
public static class AudioManager
{
    static AudioSource bgmSource;
    static List<AudioClip> bgmClips = new List<AudioClip>();
    static AudioSource audioSource;
    static Dictionary<AudioClipName, AudioClip> audioClips =
        new Dictionary<AudioClipName, AudioClip>();

    static Dictionary<AudioClipName, List<AudioClip>> audioRange =
        new Dictionary<AudioClipName, List<AudioClip>>();

    /// <summary>
    /// Initializes the audio manager
    /// </summary>
    /// <param name="source">audio source</param>
    public static void Initialize(AudioSource source, AudioSource bgm)
    {
        bgmSource = bgm;
        
        bgmClips.Add(Resources.Load<AudioClip>("bgm0"));
        bgmClips.Add(Resources.Load<AudioClip>("bgm1"));
        bgmClips.Add(Resources.Load<AudioClip>("bgm2"));
        bgmClips.Add(Resources.Load<AudioClip>("bgm3"));
        bgmClips.Add(Resources.Load<AudioClip>("bgm4"));
        bgmClips.Add(Resources.Load<AudioClip>("bgm5"));


        audioSource = source;
        audioSource.volume = 0.75f;
        //sfx play upon phrase completion. sound by dustyroom.com
        audioClips.Add(AudioClipName.PhraseComplete,
            Resources.Load<AudioClip>("phraseComplete"));
        audioClips.Add(AudioClipName.Bomb,
            Resources.Load<AudioClip>("Bomb"));
        audioClips.Add(AudioClipName.Barrier,
            Resources.Load<AudioClip>("Barrier"));
        audioClips.Add(AudioClipName.GhostSpawn01,
            Resources.Load<AudioClip>("spawn"));
        audioClips.Add(AudioClipName.GhostDeath01,
            Resources.Load<AudioClip>("goAway"));
        audioClips.Add(AudioClipName.GhostType,
            Resources.Load<AudioClip>("ghostType"));
        audioClips.Add(AudioClipName.CountDown,
            Resources.Load<AudioClip>("CountDown"));
        audioClips.Add(AudioClipName.Cant,
            Resources.Load<AudioClip>("Cant"));
        audioClips.Add(AudioClipName.MonitorOff,
            Resources.Load<AudioClip>("MonitorOff"));
        audioClips.Add(AudioClipName.MonitorOn,
            Resources.Load<AudioClip>("MonitorOn"));
        audioClips.Add(AudioClipName.ButtonClick, 
            Resources.Load<AudioClip>("ButtonClick"));
        audioClips.Add(AudioClipName.Buy,
            Resources.Load<AudioClip>("Buy"));

        //GHOST DAMAGED
        List<AudioClip> ghostDamaged = new List<AudioClip>();
        ghostDamaged.Add(Resources.Load<AudioClip>("Ghost Damage 2"));
        ghostDamaged.Add(Resources.Load<AudioClip>("Ghost Damage 4"));
        ghostDamaged.Add(Resources.Load<AudioClip>("Ghost Damage 6"));
        ghostDamaged.Add(Resources.Load<AudioClip>("Ghost Damage 7"));
        ghostDamaged.Add(Resources.Load<AudioClip>("Ghost Damage 8"));
        ghostDamaged.Add(Resources.Load<AudioClip>("Ghost Damage 9"));
        audioRange.Add(AudioClipName.GhostDamaged, ghostDamaged);

        //GHOST DEATH
        List<AudioClip> ghostDeath = new List<AudioClip>();
        ghostDeath.Add(Resources.Load<AudioClip>("Ghost No 1"));
        ghostDeath.Add(Resources.Load<AudioClip>("Ghost No 2"));
        ghostDeath.Add(Resources.Load<AudioClip>("Ghost No 3"));
        ghostDeath.Add(Resources.Load<AudioClip>("Ghost No 4"));
        audioRange.Add(AudioClipName.GhostDeath, ghostDeath);

        //CAT SPAWN
        List<AudioClip> catSpawned = new List<AudioClip>();
        catSpawned.Add(Resources.Load<AudioClip>("CatSpawn1"));
        catSpawned.Add(Resources.Load<AudioClip>("CatSpawn2"));
        catSpawned.Add(Resources.Load<AudioClip>("CatSpawn3"));
        catSpawned.Add(Resources.Load<AudioClip>("CatSpawn4"));
        audioRange.Add(AudioClipName.CatSpawn, catSpawned);

        //CAT DAMAGED
        List<AudioClip> catDamaged = new List<AudioClip>();
        catDamaged.Add(Resources.Load<AudioClip>("CatDamage1"));
        catDamaged.Add(Resources.Load<AudioClip>("CatDamage2"));
        catDamaged.Add(Resources.Load<AudioClip>("CatDamage3"));
        catDamaged.Add(Resources.Load<AudioClip>("CatDamage4"));
        audioRange.Add(AudioClipName.CatDamaged, catDamaged);

        //TYPING
        List<AudioClip> typing = new List<AudioClip>();
        typing.Add(Resources.Load<AudioClip>("Keyboard1"));
        typing.Add(Resources.Load<AudioClip>("Keyboard2"));
        typing.Add(Resources.Load<AudioClip>("Keyboard3"));
        typing.Add(Resources.Load<AudioClip>("Keyboard4"));
        typing.Add(Resources.Load<AudioClip>("Keyboard5"));
        typing.Add(Resources.Load<AudioClip>("Keyboard6"));
        typing.Add(Resources.Load<AudioClip>("Keyboard7"));
        typing.Add(Resources.Load<AudioClip>("Keyboard8"));
        typing.Add(Resources.Load<AudioClip>("Keyboard9"));
        audioRange.Add(AudioClipName.Typing, typing);

        //TIMES UP
        List<AudioClip> timesUp = new List<AudioClip>();
        timesUp.Add(Resources.Load<AudioClip>("TimesUp1"));
        timesUp.Add(Resources.Load<AudioClip>("TimesUp2"));
        timesUp.Add(Resources.Load<AudioClip>("TimesUp3"));
        audioRange.Add(AudioClipName.TimesUp, timesUp);

        //YOU LOSE
        List<AudioClip> youLose = new List<AudioClip>();
        youLose.Add(Resources.Load<AudioClip>("YouLose1"));
        youLose.Add(Resources.Load<AudioClip>("YouLose2"));
        youLose.Add(Resources.Load<AudioClip>("YouLose3"));
        youLose.Add(Resources.Load<AudioClip>("YouLose4"));
        youLose.Add(Resources.Load<AudioClip>("YouLose5"));
        audioRange.Add(AudioClipName.YouLose, youLose);

        //YOU WIN
        List<AudioClip> youWin = new List<AudioClip>();
        youWin.Add(Resources.Load<AudioClip>("YouWin1"));
        youWin.Add(Resources.Load<AudioClip>("YouWin2"));
        youWin.Add(Resources.Load<AudioClip>("YouWin3"));
        audioRange.Add(AudioClipName.YouWin, youWin);

        List<AudioClip> smack = new List<AudioClip>();
        smack.Add(Resources.Load<AudioClip>("Smack1"));
        smack.Add(Resources.Load<AudioClip>("Smack2"));
        smack.Add(Resources.Load<AudioClip>("Smack3"));
        smack.Add(Resources.Load<AudioClip>("Smack4"));
        smack.Add(Resources.Load<AudioClip>("Smack5"));
        smack.Add(Resources.Load<AudioClip>("Smack6"));
        smack.Add(Resources.Load<AudioClip>("Smack7"));
        smack.Add(Resources.Load<AudioClip>("Smack8"));

        audioRange.Add(AudioClipName.Smack, smack);
    }

    /// <summary>
    /// Plays the audio clip with the given name
    /// </summary>
    /// <param name="name">name of the audio clip to play</param>
    public static void Play(AudioClipName name)
    {
        audioSource.PlayOneShot(audioClips[name]);
    }
    public static void PlayRandom(AudioClipName name)
    {
        audioSource.PlayOneShot(audioRange[name][Random.Range(0, audioRange[name].Count)]);
    }

    public static IEnumerator PlayRandomDialog(AudioClipName audioClip, float time)
    {
        float currentVolume = bgmSource.volume;
        bgmSource.volume = 0.25f;
        PlayRandom(audioClip);
        yield return new WaitForSecondsRealtime(time);
        bgmSource.volume = currentVolume;
    }

    public static void PlayBGM(int currentLevel)
    {
        if(currentLevel == 0)
        {
            bgmSource.clip = bgmClips[0];
        }
        if(currentLevel < 6)
        {
            bgmSource.clip = bgmClips[currentLevel];
        }
        else
        {
            bgmSource.clip = bgmClips[Random.Range(1, bgmClips.Count)];
        }
        bgmSource.Play();
    }
}

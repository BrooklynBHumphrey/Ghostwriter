using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GhostManager : MonoBehaviour
{
    [SerializeField] GameObject[] spawnPoints;
    [SerializeField] GameObject[] ghosts;
    [SerializeField] GameObject catGhost;
    [SerializeField] GameObject catGhostSpawnPoint;
    [SerializeField] GameObject MonitorOffScreen;
    [SerializeField] GameObject monitorOffAnimation;

    GameObject randGhost;
    GameObject spawn;
    float timer;
    float catSpawnTime;
    bool catGhostWasSpawned = false;
    bool miniGhostActive = false;

    void Start()
    {
        ResetTimer();
        GenerateCatSpawnTime();
    }

    private void Update()
    {
        if (LevelManager.GameStarted)
        {
            timer -= Time.deltaTime;

            if (timer < 0)
            {
                if (ConfigManager.GhostBarrierTime < 0.0f)
                {
                    SpawnGhost();
                    ResetTimer();
                }
            }
            ConfigManager.ElapseGhostBarrierTime();
        }
    }

    void SpawnGhost()
    {
        float time = TimeManager.Instance.GetCurrentTime();
        List<Ghost> spawnedGhosts = FindObjectsOfType<Ghost>().ToList();

        // Keep cats from spawning until level 6
        if (LevelManager.CurrentLevel > 5)
        {
            if (time < catSpawnTime && !catGhostWasSpawned)
            {
                // kill all the other ghosts and spawn the cat
                foreach (var ghost in spawnedGhosts)
                {
                    ghost.Die(false);
                }
                TurnMonitorOff(false);
                Instantiate(catGhost, catGhostSpawnPoint.transform.position, catGhostSpawnPoint.transform.rotation);
                catGhostWasSpawned = true;
            }
        }

        if (FindObjectsOfType<CatGhost>().ToList().Count == 0)
        {
            GameObject randGhost = GetRandomGhost(spawnedGhosts);
            if (randGhost == null) return;
            int numToSpawn = 1;

            if (randGhost.GetComponent<Ghost>().ghostType == Ghost.GhostType.Mini)
            {
                numToSpawn = ConfigManager.NumMiniGhostToSpawn;
            }

            if (spawnedGhosts.Count <= 21)
            {
                for (int i = 0; i < numToSpawn; i++)
                {
                    SpawnPoint randomSpawn = GetRandomUnusedSpawnPoint(spawnedGhosts);

                    GameObject currentGhost = Instantiate(randGhost, spawn.transform.position, Quaternion.Euler(0, 180, 0));
                    currentGhost.GetComponent<Ghost>().character = randomSpawn.GetGhostKey();
                    currentGhost.GetComponent<Ghost>().SetSpawnPoint(randomSpawn);
                    spawnedGhosts.Add(currentGhost.GetComponent<Ghost>());
                    if (randGhost.GetComponent<Ghost>().ghostType == Ghost.GhostType.Mini)
                    {
                        TurnMonitorOff(true);
                        MiniGhostActive();
                    }
                }
            }
        }
    }

    public void ResetTimer()
    {
        timer = Random.Range(ConfigManager.BasicGhostSpawnRateMin, ConfigManager.BasicGhostSpawnRateMax);
    }

    public void SetMiniGhostActive(bool setActive)
    {
        miniGhostActive = setActive;
    }

    public bool IsMiniGhostActive()
    {
        return miniGhostActive;
    }

    public void SetCatGhostWasSpawnedThisLevel(bool wasSpawnedThisLevel)
    {
        catGhostWasSpawned = wasSpawnedThisLevel;
    }

    public void GenerateCatSpawnTime()
    {
        catSpawnTime = Random.Range(60.0f, LevelManager.LevelTime - 5);
    }

    GameObject GetRandomGhost(List<Ghost> spawnedGhosts)
    {
        var canSpawn = false;
        var isMini = false;
        var canSpawnJumpingGhost = false;
        var canSpawnBasicGhost = false;
        var canSpawnMiniGhost = false;

        if (LevelManager.CurrentLevel == 1)
        {
            canSpawnBasicGhost = true;
            canSpawnJumpingGhost = false;
            canSpawnMiniGhost = false;
        }

        if (LevelManager.CurrentLevel == 2)
        {
            canSpawnBasicGhost = false;
            canSpawnJumpingGhost = true;
            canSpawnMiniGhost = false;
        }

        if (LevelManager.CurrentLevel == 3)
        {
            canSpawnBasicGhost = true;
            canSpawnJumpingGhost = true;
            canSpawnMiniGhost = false;
        }

        if (LevelManager.CurrentLevel == 4)
        {
            canSpawnBasicGhost = false;
            canSpawnJumpingGhost = false;
            canSpawnMiniGhost = true;
        }

        if (LevelManager.CurrentLevel == 5)
        {
            canSpawnBasicGhost = true;
            canSpawnJumpingGhost = true;
            canSpawnMiniGhost = true;
        }

        if (LevelManager.CurrentLevel == 6)
        {
            canSpawnBasicGhost = true;
            canSpawnJumpingGhost = false;
            canSpawnMiniGhost = false;
        }

        if (LevelManager.CurrentLevel > 6)
        {
            canSpawnBasicGhost = true;
            canSpawnJumpingGhost = true;
            canSpawnMiniGhost = true;
        }

        foreach (var ghost in spawnedGhosts)
        {
            if (ghost.GetComponent<Ghost>().ghostType == Ghost.GhostType.Mini)
            {
                isMini = true;
                break;
            }
        }

        if (isMini && LevelManager.CurrentLevel == 4) // needed when only spawning mini ghosts
        {
            randGhost = null;
            return randGhost;
        }

        while (!canSpawn)
        {
            int randIndex = Random.Range(0, ghosts.Length);
            randGhost = ghosts[randIndex];

            if (isMini)
            {
                if (randGhost.GetComponent<Ghost>().ghostType != Ghost.GhostType.Mini)
                {
                    if (canSpawnBasicGhost && randGhost.GetComponent<Ghost>().ghostType == Ghost.GhostType.Basic)
                    {
                        canSpawn = true;
                    }

                    if (canSpawnJumpingGhost && randGhost.GetComponent<Ghost>().ghostType == Ghost.GhostType.Jumping)
                    {
                        canSpawn = true;
                    }
                }
            }
            else
            {
                if (canSpawnBasicGhost && randGhost.GetComponent<Ghost>().ghostType == Ghost.GhostType.Basic)
                {
                    canSpawn = true;
                }

                if (canSpawnJumpingGhost && randGhost.GetComponent<Ghost>().ghostType == Ghost.GhostType.Jumping)
                {
                    canSpawn = true;
                }

                if (canSpawnMiniGhost && randGhost.GetComponent<Ghost>().ghostType == Ghost.GhostType.Mini)
                {
                    canSpawn = true;
                }
            }
        }

        return randGhost;
    }

    SpawnPoint GetRandomUnusedSpawnPoint(List<Ghost> spawnedGhosts)
    {
        var isOpen = false;

        while (!isOpen)
        {
            int randIndex = Random.Range(0, spawnPoints.Length);
            spawn = spawnPoints[randIndex];
            var test = spawnedGhosts.FirstOrDefault(sg => sg.character.ToString().ToLower() == spawn.GetComponent<SpawnPoint>().GetGhostKey().ToString().ToLower());
            if (test == null) isOpen = true;
        }
        return spawn.GetComponent<SpawnPoint>();
    }

    public void TurnMonitorOff(bool turnOff)
    {
        if (turnOff)
        {
            if (!MonitorOffScreen.activeInHierarchy)
            {
                MonitorOffScreen.SetActive(turnOff);
                monitorOffAnimation.GetComponent<Animator>().Play("MonitorOff");
                AudioManager.Play(AudioClipName.MonitorOff);
            }
        }
        else if (MonitorOffScreen.activeInHierarchy)
        {
            StartCoroutine(MonitorOn());
        }
    }

    IEnumerator MonitorOn()
    {
        AudioManager.Play(AudioClipName.MonitorOn);
        monitorOffAnimation.GetComponent<Animator>().Play("MonitorOn");
        yield return new WaitForSeconds(0.35f);
        MonitorOffScreen.SetActive(false);
    }

    public void MiniGhostActive()
    {
        miniGhostActive = true;
    }
}

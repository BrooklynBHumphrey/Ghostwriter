using UnityEngine;

public class JumpingGhost : Ghost
{
    Lerper lerpComp;
    Vector3 nextPos;
    SpawnPoint nextKey;

    void Start()
    {
        ghostType = GhostType.Jumping;
        typer = GameObject.FindGameObjectWithTag("Typer").GetComponent<Typer>();
        lerpComp = GetComponent<Lerper>();
        typer = GameObject.FindGameObjectWithTag("Typer").GetComponent<Typer>();
        nextPos = lerpComp.GetJumpPoint();
        nextKey = lerpComp.GetNextSpawnPoint();
        maxHealth = ConfigManager.JumpingGhostBaseHealth;

        if (ConfigManager.CurrentAntiGhostWareRank > 0)
        {
            nextKey.SetJumpingGhostTargetStatus(true);
        }

        AudioManager.Play(AudioClipName.GhostSpawn01);
        health = maxHealth;
    }

    void Update()
    {
        lifetime += Time.deltaTime;
        interfereTime -= Time.deltaTime;

        if (interfereTime <= 0)
        {
            Interfere();
            interfereTime = ConfigManager.BasicInterfereRate;
        }

        CheckInput();
        healthBarSprite.fillAmount = Mathf.MoveTowards(healthBarSprite.fillAmount, target, reduceSpeed * Time.deltaTime);
    }

    public override void TakeDamage()
    {
        //add other stuff like effects here
        health--;
        UpdateHealthBar(maxHealth, (float)health);
        PlayParticleEffect(attackParticles, shift);
        StartCoroutine(TurnRed());
        AudioManager.PlayRandom(AudioClipName.Smack);
        if (health <= 0)
        {
            Die(false);
        }
        else
        {
            AudioManager.PlayRandom(AudioClipName.GhostDamaged);
        }
        if (!dead)
        {
            lerpComp.ResetElapsedTime();
            currentKey.SetHauntedStatus(false);
            nextKey.SetJumpingGhostTargetStatus(false);
            nextKey.SetHauntedStatus(true);
            lerpComp.LerpHacker(transform.position, nextPos);
            currentKey = nextKey;
            currentKey.SetGhost(this);
            nextPos = lerpComp.GetJumpPoint();
            nextKey = lerpComp.GetNextSpawnPoint();
            if (ConfigManager.CurrentAntiGhostWareRank > 0 && health > 1)
            {
                nextKey.SetJumpingGhostTargetStatus(true);
            }
        }
    }
    public override void Die(bool levelend)
    {
        if (!levelend)
        {
            AudioManager.PlayRandom(AudioClipName.GhostDeath);
            LevelManager.JumpingGhostKilled(lifetime);
        }

        currentKey.SetHauntedStatus(false);
        nextKey.SetHauntedStatus(false);
        nextKey.SetJumpingGhostTargetStatus(false);

        PlayParticleEffect(deathParticles, shift);
        DeathForEveryone();
    }
}

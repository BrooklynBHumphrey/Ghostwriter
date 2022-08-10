using UnityEngine;

public class BasicGhost : Ghost
{
    void Start()
    {
        ghostType = GhostType.Basic;
        typer = GameObject.FindGameObjectWithTag("Typer").GetComponent<Typer>();
        maxHealth = ConfigManager.BasicGhostBaseHealth - ConfigManager.CurrentBasicAttackRank;
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

    public override void Die(bool levelend)
    {
        if (!levelend)
        {
            AudioManager.PlayRandom(AudioClipName.GhostDeath);
            LevelManager.BasicGhostKilled(lifetime);
        }

        currentKey.SetHauntedStatus(false);

        PlayParticleEffect(deathParticles, shift);
        DeathForEveryone();
    }
}

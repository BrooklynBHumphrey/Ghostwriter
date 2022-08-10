using UnityEngine;

public class MiniGhost : Ghost
{
    void Start()
    {
        ghostType = GhostType.Mini;
        typer = GameObject.FindGameObjectWithTag("Typer").GetComponent<Typer>();
        shift = new Vector3(0, 5, 0);
        maxHealth = ConfigManager.MiniGhostBaseHealth;
        AudioManager.Play(AudioClipName.MonitorOff);
        health = maxHealth;
    }

    void Update()
    {
        lifetime += Time.deltaTime; 
        CheckInput();
        healthBarSprite.fillAmount = Mathf.MoveTowards(healthBarSprite.fillAmount, target, reduceSpeed * Time.deltaTime);
    }

    public override void Die(bool levelend)
    {
        if (!levelend)
        {
            AudioManager.PlayRandom(AudioClipName.GhostDamaged);
        }

        currentKey.SetHauntedStatus(false);

        PlayParticleEffect(deathParticles, shift);
        DeathForEveryone();
    }
}

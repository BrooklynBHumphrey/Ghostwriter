using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public abstract class Ghost : MonoBehaviour
{
    [SerializeField] protected Image healthBarSprite;
    [SerializeField] protected float reduceSpeed = 2.0f;
    [SerializeField] protected GameObject deathParticles;
    [SerializeField] protected GameObject attackParticles;

    public GhostType ghostType;
    public char character;

    protected Vector3 shift = new Vector3(0, 10, 0);
    protected float target = 1;
    protected int maxHealth;
    protected int health;
    protected Typer typer;
    protected SpawnPoint currentKey;
    protected bool dead = false;
    protected float lifetime;
    protected float interfereTime = 0.6f;

    public void SetSpawnPoint(SpawnPoint spawnPoint)
    {
        currentKey = spawnPoint;
        currentKey.SetHauntedStatus(true);
        currentKey.SetGhost(this);
    }

    protected void Interfere()
    {
        typer.Type(gameObject,character);
    }

    protected virtual void CheckInput()
    {
        foreach (char c in Input.inputString)
        {
            if (c == character || c == char.ToLower(character))
            {
                TakeDamage();
            }
        }
    }
    
    public virtual void TakeDamage()
    {
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

    }

    public abstract void Die(bool levelend);

    protected void DeathForEveryone()
    {
        currentKey.SetHauntedStatus(false);
        Destroy(this.gameObject);
        dead = true;
    }

    public void UpdateHealthBar(float maxHealth, float currentHealth)
    {
        target = currentHealth / maxHealth;
    }

    protected void PlayParticleEffect(GameObject particle, Vector3 shift)
    {
        var ghostTransform = gameObject.transform;
        Instantiate(particle, ghostTransform.position + shift, Quaternion.Euler(new Vector3(-90, 0, 0)));
    }

    protected IEnumerator TurnRed()
    {
        Material mat = GetComponentInChildren<SkinnedMeshRenderer>().material;
        Color emission = mat.GetColor("_EmissionColor");
        Color albedo = mat.GetColor("_Color");
        mat.SetColor("_EmissionColor", Color.red);
        mat.SetColor("_Color", Color.red);
        yield return new WaitForSeconds(0.1f);
        mat.SetColor("_EmissionColor", emission);
        mat.SetColor("_Color", albedo);
    }

    public enum GhostType { Basic, Jumping, Mini, Cat }
}

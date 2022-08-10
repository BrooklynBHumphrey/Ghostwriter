using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDeathParticles : MonoBehaviour
{
    [SerializeField] ParticleSystem smoke;
    [SerializeField] ParticleSystem debris;
    // Update is called once per frame
    void Update()
    {
        if (!smoke.isPlaying && !debris.isPlaying)
        {
            Destroy(gameObject);
        }
    }
}

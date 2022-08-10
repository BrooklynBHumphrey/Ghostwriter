using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAttackParticles : MonoBehaviour
{
    [SerializeField] ParticleSystem smoke;
    // Update is called once per frame
    void Update()
    {
        if (!smoke.isPlaying)
        {
            Destroy(gameObject);
        }
    }
}

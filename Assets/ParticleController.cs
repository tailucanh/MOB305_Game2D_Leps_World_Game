using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    private ParticleSystem particle;

    private void Start()
    {
        particle = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (particle != null && particle.isStopped && particle.particleCount == 0)
        {
            Destroy(gameObject);
        }

    }
}

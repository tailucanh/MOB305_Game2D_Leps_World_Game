using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    private ParticleSystem particleSystem ;

    private void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (particleSystem != null && particleSystem.isStopped && particleSystem.particleCount == 0)
        {
            Destroy(gameObject);
        }
      
    }
}

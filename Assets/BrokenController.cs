using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenController : MonoBehaviour
{
   
    public GameObject particleSystemPrefab;
   
    private void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            if (col.contacts[0].normal == Vector2.up)
            { 
                GameObject particleSystemObject = Instantiate(particleSystemPrefab, transform.position, Quaternion.identity);
                ParticleSystem particleSystem = particleSystemObject.GetComponent<ParticleSystem>();
                particleSystem.Play();
             
                Destroy(gameObject);
            }
            
          
          
        }
    }
}

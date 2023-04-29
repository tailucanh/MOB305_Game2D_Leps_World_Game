using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CoinsController : MonoBehaviour
{
    public GameObject particleSystemPrefab;
    private TextCountCoin _textCountCoin;
    private Text textCount;
  
    private void Start()
    {
        _textCountCoin = GameObject.FindWithTag("TextCoin").GetComponent<TextCountCoin>();
        textCount = GameObject.FindWithTag("TextCoin").GetComponent<Text>();
        textCount.text = "" + _textCountCoin.quantity.ToString();
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
           
            GameObject particleSystemObject = Instantiate(particleSystemPrefab, transform.position, Quaternion.identity);
            ParticleSystem particleSystem = particleSystemObject.GetComponent<ParticleSystem>();
            particleSystem.Play();
           _textCountCoin.quantity++;
            textCount.text = "x" + _textCountCoin.quantity.ToString();
            Destroy(gameObject);
          
        }
    }
    
}

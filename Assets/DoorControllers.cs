using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorControllers : MonoBehaviour
{
 
    public GameObject notifiSuccess;
    public GameObject notifiFald1;
    public GameObject notifiFald2;
    private Text _textCountCoin;
    private float time = 2f;
    private string desiredText = "x20";
    void Start()
    {
       
        _textCountCoin = GameObject.FindWithTag("TextCoin").GetComponent<Text>();
        
        notifiSuccess.SetActive(false);
        notifiFald1.SetActive(false);
        notifiFald2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Key")  && desiredText.Equals(_textCountCoin.text) )
        {
            notifiSuccess.SetActive(true);
            notifiFald1.SetActive(false);
            notifiFald2.SetActive(false);
        }
        else
        {
            StartCoroutine(ShowGameObjectForTime(notifiFald1));
            notifiSuccess.SetActive(false);
            notifiFald2.SetActive(false);
            StartCoroutine(DestroyGameObjectAfterTime(notifiFald1, time));
        }
        

        
        if(!desiredText.Equals(_textCountCoin.text))
        {
            StartCoroutine(ShowGameObjectForTime(notifiFald2));
            notifiSuccess.SetActive(false);
            notifiFald1.SetActive(false);
            StartCoroutine(DestroyGameObjectAfterTime(notifiFald2, time));
           
        }
      
        
    }
    private IEnumerator ShowGameObjectForTime(GameObject obj)
    {
        obj.SetActive(true);
        yield return new WaitForSeconds(time);
     
    }
    private IEnumerator DestroyGameObjectAfterTime(GameObject gameObjectToDestroy, float time)
    {
        yield return new WaitForSeconds(time);
        gameObjectToDestroy.SetActive(false);
    }
}

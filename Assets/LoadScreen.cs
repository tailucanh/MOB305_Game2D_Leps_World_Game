using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScreen : MonoBehaviour
{
  
    public float minScale = 1f;
    public float maxScale = 1.5f;
    public float speed = 1f;
    public int isScene = 1;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         float scale = Mathf.PingPong(Time.time * speed, maxScale - minScale) + minScale;
        transform.localScale = new Vector3(scale, scale, 1f);
    }

    private void OnMouseDown()
    {
        SceneManager.LoadScene(isScene);
    }

   
}

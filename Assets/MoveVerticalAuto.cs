using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveVerticalAuto : MonoBehaviour
{
    public float moveDistance = 1f; // The distance the character will move up and down
    public float moveSpeed = 1f; // The speed at which the character will move
    private float startY; 
    public float time = 1f;
    void Start()
    {
        startY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time * time;
        float sinValue = Mathf.Sin(t);
        float yPos = startY + sinValue * moveDistance;
        transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    public Transform characterTransform;
    public Transform characterHeadTransform;

    private bool isAttached = false;

    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!isAttached && characterTransform != null && characterHeadTransform != null)
        {
            // Attach the lock to the character and position it above the character's head
            transform.parent = characterHeadTransform;
            transform.position = characterHeadTransform.position + Vector3.up * 1.1f;
            isAttached = true;
        }
    }
}

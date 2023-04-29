using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
   public GameObject character;
   private Vector3 initialPosition;
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (character.transform.position.x > initialPosition.x) {
            transform.position = new Vector3(character.transform.position.x, initialPosition.y, initialPosition.z);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatController : MonoBehaviour
{
   
    public Transform character;
    public float tiltAmount = 30f;
    public float tiltSpeed = 40f;
    private Vector3 previousPosition;
    private float currentTiltAngle;
  
    private void Start()
    {
        previousPosition = character.position;
     
    }

    private void Update()
    {
        float horizontalMovement = character.position.x - previousPosition.x;
        float currentRotation = transform.localEulerAngles.z;

        if (horizontalMovement > 0.1f)
        {
            currentTiltAngle = Mathf.Lerp(currentTiltAngle, tiltAmount, tiltSpeed * Time.deltaTime );
        }
        else if (horizontalMovement < -0.1f)
        {
            currentTiltAngle = Mathf.Lerp(currentTiltAngle, -tiltAmount, tiltSpeed * Time.deltaTime );
        }
        else
        {
            currentTiltAngle = Mathf.Lerp(currentTiltAngle, 0f, tiltSpeed * Time.deltaTime );
        }

        transform.localEulerAngles = new Vector3(0f, 0f, Mathf.LerpAngle(currentRotation, currentTiltAngle,tiltSpeed *  Time.deltaTime));

        previousPosition = character.position; 
    }
}

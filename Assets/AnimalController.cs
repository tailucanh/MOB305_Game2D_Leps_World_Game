using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalController : MonoBehaviour
{
    public float minMoveDistance = 1f;
    public float maxMoveDistance = 3f;
    public float moveSpeed = 1f;
    public float rotateAngle = 180f;

    private float startPosX;
    private float moveDir = 1f;
    private Vector3 startScale;

    public int numberOfBlinks = 5;
    public float blinkTime = 2f;
    private float moveDistance;

    private bool canBlink = true;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;
    private Rigidbody2D rb2D;


    private void Start()
    {
        startPosX = transform.position.x;
        startScale = transform.localScale;
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
        rb2D = GetComponent<Rigidbody2D>();

        moveDistance = UnityEngine.Random.Range(minMoveDistance, maxMoveDistance);
    }

    private void Update()
    {
        float newPosX = transform.position.x + moveDir * moveSpeed * Time.deltaTime;
        float dist = Mathf.Abs(newPosX - startPosX);

        if (dist >= moveDistance)
        {
            moveDir *= -1f;
            float newAngle = Mathf.Abs(-rotateAngle) * Mathf.Sign(moveDir);
            transform.rotation = Quaternion.Euler(0f, newAngle, 0f);


            moveDistance = UnityEngine.Random.Range(minMoveDistance, maxMoveDistance);
        }

        transform.position = new Vector3(newPosX, transform.position.y, transform.position.z);
        transform.localScale = new Vector3(startScale.x * moveDir, startScale.y, startScale.z);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.CompareTag("Player"))
        {
            if (collision.contacts[0].normal == Vector2.down)
            {
                StartCoroutine(BlinkBox());
                Debug.Log("Chạm góc trên!");
            }
        }

        if (collision.collider.CompareTag("Animal"))
        {
            boxCollider.enabled = false;

        }


        if (collision.collider.CompareTag("Ground"))
        {
            moveDir *= -1f;
            float newAngle = Mathf.Abs(-rotateAngle) * Mathf.Sign(moveDir);
            transform.rotation = Quaternion.Euler(0f, newAngle, 0f);

            moveDistance = UnityEngine.Random.Range(minMoveDistance, maxMoveDistance);
        }


    }



    private IEnumerator BlinkBox()
    {
        if (canBlink)
        {
            boxCollider.enabled = false;
            canBlink = false;

            for (int i = 0; i < numberOfBlinks; i++)
            {
                spriteRenderer.enabled = !spriteRenderer.enabled;
                yield return new WaitForSeconds(blinkTime);
            }

            Destroy(gameObject);
        }
    }
}





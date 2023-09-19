using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer _sprite;
    private GameObject objHat;
    private SpriteRenderer _spriteHat;
    private float dirX = 0f;
    private float moveSpeed = 5f;
    public float jumpForce = 13f;
    public int maxJumps = 2;
    private int jumpCount = 0;
    public Camera mainCamera;
    private float leftEdge;
    private bool isDead = false;
    public Jump2ndController jump2Nd;
    private AudioSource[] audioSources;
    private BoxCollider2D boxCollider;

    private enum MovementState
    {
        idle, runing, jumping, falling, die
    };


    void Start()
    {
        objHat = GameObject.FindWithTag("Hat");
        _spriteHat = objHat.GetComponent<SpriteRenderer>();
        audioSources = GetComponents<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        _sprite = GetComponent<SpriteRenderer>();
        float camHalfWidth = mainCamera.orthographicSize * Screen.width / Screen.height;
        leftEdge = mainCamera.transform.position.x - camHalfWidth;

    }


    void Update()
    {
        dirX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        if (Input.GetButtonDown("Jump") && jumpCount < maxJumps)
        {
            Jump();
            if (jumpCount == 2)
            {
                audioSources[0].Play();
            }
        }
        if (transform.position.x < leftEdge)
        {

            Vector3 newPos = transform.position;
            newPos.x = leftEdge;
            transform.position = newPos;
        }
        updateAnimation();
    }


    void Jump()
    {
        jumpCount++;
        jump2Nd.jumpCount = jumpCount;
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Golden") || collision.gameObject.CompareTag("Earth") || collision.gameObject.CompareTag("Animal")
            || collision.gameObject.CompareTag("Ice"))
        {
            jumpCount = 0;
            jump2Nd.jumpCount = jumpCount;
        }

        if (collision.gameObject.CompareTag("Animal Die"))
        {
            diePlayer();
        }

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Coin"))
        {
            audioSources[1].Play();
        }
    }

    private void updateAnimation()
    {
        MovementState state;
        if (isDead)
        {
            state = MovementState.die;
        }
        else if (dirX > 0f)
        {

            state = MovementState.runing;
            _sprite.flipX = false;
            _spriteHat.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.runing;

            _sprite.flipX = true;
            _spriteHat.flipX = true;
        }
        else
        {
            state = MovementState.idle;

        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);

    }

    private void diePlayer()
    {
        isDead = true;
        updateAnimation();
        boxCollider.isTrigger = true;
        objHat.GetComponent<CircleCollider2D>().isTrigger = true;
        rb.simulated = true;
        rb.isKinematic = false;
        audioSources[2].Play();

        Invoke(nameof(LoadSceneDelayed), 2f);
    }
    private void LoadSceneDelayed()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}

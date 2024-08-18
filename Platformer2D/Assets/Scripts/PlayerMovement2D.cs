using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    PlayerControls controls;

    public float moveSpeed = 10f;
    public float jumpForce = 20f;

    public Transform groundCheck;
    public LayerMask whatIsGround;
    public Animator animator;
    public CoinManager coinManager;
    public KeysManager keysManager;
    public HeartManager heartManager;

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool facingRight = true;

    AudioManager audioManager;

    float moveInput;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        controls = new PlayerControls();
        controls.Enable();

        controls.Player.Move.performed += ctx =>
        {
            moveInput = ctx.ReadValue<float>();
        };

        controls.Player.Jump.performed += ctx => Jump();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Movement();
        CheckGrounded();
    }

    void Jump()
    {
        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            animator.SetBool("IsJumping", true);
            audioManager.PlaySFX(audioManager.jump);
        }
    }

    void Movement()
    {
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        animator.SetFloat("Speed", Mathf.Abs(moveInput));

        if (moveInput > 0 && !facingRight || moveInput < 0 && facingRight)
        {
            Flip();
        }
    }

    void CheckGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(groundCheck.position, Vector2.down, 0.1f, whatIsGround);
        if (hit.collider != null)
        {
            isGrounded = true;
            animator.SetBool("IsJumping", false);
        }
        else
        {
            isGrounded = false;
            animator.SetBool("IsJumping", true);
        }
    }

    void Flip()
    {
        facingRight = !facingRight;

        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            collision.gameObject.SetActive(false);
            heartManager.TakeDamage();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Coin"))
        {
            audioManager.PlaySFX(audioManager.coinsGet);
            coinManager.AddCoins(1);
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.layer == LayerMask.NameToLayer("SilverKey"))
        {
            audioManager.PlaySFX(audioManager.keysGet);
            keysManager.AddSilverKey(1);
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.layer == LayerMask.NameToLayer("GoldKey"))
        {
            audioManager.PlaySFX(audioManager.keysGet);
            keysManager.AddGoldKey(1);
            other.gameObject.SetActive(false);
        }
    }
}

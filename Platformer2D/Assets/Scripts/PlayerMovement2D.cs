using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
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

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        Movement(moveInput);
    }

    void Movement(float moveInput)
    {
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        animator.SetFloat("Speed", Mathf.Abs(moveInput));

        if (moveInput > 0 && !facingRight || moveInput < 0 && facingRight)
        {
            Flip();
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
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
        if (Physics2D.OverlapCircle(groundCheck.position, 0.1f, whatIsGround))
        {
            isGrounded = true;
            animator.SetBool("IsJumping", false);
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            collision.gameObject.SetActive(false);
            heartManager.TakeDamage();
        }
    }

    void OnCollisionExit2D()
    {
        if (!Physics2D.OverlapCircle(groundCheck.position, 0.1f, whatIsGround))
        {
            isGrounded = false;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Coin"))
        {
            coinManager.AddCoins(1);
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.layer == LayerMask.NameToLayer("SilverKey"))
        {
            keysManager.AddSilverKey(1);
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.layer == LayerMask.NameToLayer("GoldKey"))
        {
            keysManager.AddGoldKey(1);
            other.gameObject.SetActive(false);
        }
    }
}

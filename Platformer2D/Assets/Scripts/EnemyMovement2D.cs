using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement2D : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float jumpForce = 10f;
    public bool isJumper;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public float timeToChangeDirection = 2f;

    private Rigidbody2D rb;
    private Animator animator;
    private bool facingRight = true;
    private bool isGrounded;
    private float directionChangeTimer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        directionChangeTimer = timeToChangeDirection;
    }

    void Update()
    {
        directionChangeTimer -= Time.deltaTime;

        if (isJumper)
        {
            JumpBehavior();
        }
        else
        {
            WalkBehavior();
        }
    }

    void JumpBehavior()
    {
        if (isGrounded && directionChangeTimer <= 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            animator.SetBool("IsJumping", true);
        }
    }

    void WalkBehavior()
    {
        if (directionChangeTimer <= 0)
        {
            Flip();
            directionChangeTimer = timeToChangeDirection;
        }
        if (isGrounded)
        {
            rb.velocity = new Vector2(facingRight ? moveSpeed : -moveSpeed, rb.velocity.y);
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
    void OnCollisionEnter2D()
    {
        if (Physics2D.OverlapCircle(groundCheck.position, 0.1f, whatIsGround))
        {
            isGrounded = true;
            animator.SetBool("IsJumping", false);
            directionChangeTimer = timeToChangeDirection;
        }
    }

    void OnCollisionExit2D()
    {
        if (!Physics2D.OverlapCircle(groundCheck.position, 0.1f, whatIsGround))
        {
            isGrounded = false;
        }
    }
}

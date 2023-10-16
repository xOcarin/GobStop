using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float maxMoveSpeed = 7f;
    public float jumpForce = 10f;
    public float groundCheckRadius = 0.1f;
    public LayerMask groundLayer;
    private Animator anim;
    private Rigidbody2D rb;
    private bool isGrounded;

    [SerializeField]
    private Transform groundCheck;

    // anim bools
    private bool isJumping;
    private bool isWalking;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Horizontal movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float targetSpeed = horizontalInput * maxMoveSpeed;

        // Update the character's velocity
        rb.velocity = new Vector2(targetSpeed, rb.velocity.y);

        // Flip the character when changing direction
        if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1); // Normal scale (no flip)
        }
        else if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // Flip horizontally
        }

        // Handle animations
        if (isGrounded)
        {
            anim.SetBool("isJumping", false);
        }
        else
        {
            anim.SetBool("isJumping", true);
        }

        if (Mathf.Abs(horizontalInput) > 0)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        // Jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            anim.SetBool("isJumping", true);
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    // This is just to show the grounded circle in the editor
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}

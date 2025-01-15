using System;
using UnityEngine;

public class NewPlayerMovement : MonoBehaviour
{
    public float MaxSpeed = 20f;
    public float MoveForce = 15f;
    public float JumpForce = 80f;
    public float VertVelocity = 0.0f;
    public float JumpDelay = 0.02f;

    private float jumpCooldownTimer = 0f;
    private bool IsGrounded = false;
    private Animator animator;
    private Rigidbody2D rb;

    private float rollTimer = 0f;

    void Start()
    {
        animator = GetComponent<Animator>();

        rb = GetComponent<Rigidbody2D>();

        Debug.Log("Creating player");
    }

    void Update()
    {
        // Lock the angular velocity (Might get changed later)
        rb.angularVelocity = 0f;
        rb.freezeRotation = true;

        // Walking mechanics
        float Horizontal = Input.GetAxisRaw("Horizontal");

        rb.AddForce(new Vector2(Horizontal * MoveForce * (Time.deltaTime * 1000), 0f), ForceMode2D.Force);

        // Character flipping
        if (Horizontal != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(Horizontal), 1, 1);
        }

        // Jumping mechanics
        if (jumpCooldownTimer > 0f)
        {
            jumpCooldownTimer -= Time.deltaTime;
        }

        if (rollTimer > 0f)
        {
            rollTimer -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump") && IsGrounded && jumpCooldownTimer <= 0f)
        {
            rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            jumpCooldownTimer = JumpDelay;
        }

        // Jumping animation bools
        if (rb.linearVelocity.y > 0.2)
        {
            animator.SetBool("Jumping", true);
            animator.SetBool("Falling", false);
        }
        else if (rb.linearVelocity.y < 0.2)
        {
            animator.SetBool("Falling", true);
            animator.SetBool("Jumping", false);
        }

        // Roll animation
        if (Input.GetKey(KeyCode.E))
        {
            animator.SetBool("Roll", true);
            rollTimer = 0.1f;
        }
        else if (rollTimer <= 0)
        {
            animator.SetBool("Roll", false);
        }

        if (IsGrounded == true)
        {
            animator.SetBool("Falling", false);
            animator.SetBool("Jumping", false);
        }
        animator.SetFloat("Speed", Mathf.Abs(Horizontal));
        animator.SetFloat("LinearVelocity", Mathf.Abs(rb.linearVelocity.x));

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            IsGrounded = true;
            animator.SetBool("Falling", false);
            animator.SetBool("Jumping", false);
            animator.SetBool("OnGround", true);
            jumpCooldownTimer = JumpDelay;
            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            IsGrounded = false;
            animator.SetBool("OnGround", false);
        }
    }

}

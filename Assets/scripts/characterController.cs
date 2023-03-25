using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class characterController : MonoBehaviour
{
    public float speed = 5.0f;  // Movement speed
    public float jumpForce = 50.0f;  // Jump force
    public float groundDistance = 0.2f;  // Distance from the ground
    public TilemapCollider2D groundCollider;  // Collider2D for the ground
    private Rigidbody2D rb = null;  // Rigidbody2D component reference
    private bool isGrounded;  // Is the character grounded?

    void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();  // Get the Rigidbody2D component reference
    }

    void FixedUpdate()
    {
        // Move left or right
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(horizontalInput, 0) * speed;
        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);


    }

    void Update()
    {

        // Jump if the character is grounded and the Jump button is pressed
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            //rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse) ;
            rb.AddForce(Vector2.up*jumpForce);
            
            isGrounded = false;
        }

        // Check if the character is grounded
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundDistance, groundCollider.gameObject.layer);

        // Check for collisions with the ground collider
        Collider2D[] hitColliders = Physics2D.OverlapBoxAll(groundCollider.bounds.center, groundCollider.bounds.extents, 0, groundCollider.gameObject.layer);
        foreach (Collider2D hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.tag == "Wall")
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
        }
    }
}
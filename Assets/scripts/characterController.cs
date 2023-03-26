using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System;
using UnityEngine.SceneManagement;

public class characterController : MonoBehaviour
{
    public float speed = 5.0f;  // Movement speed
    public float jumpForce = 50.0f;  // Jump force
    public float groundDistance = 0.2f;  // Distance from the ground
    public TilemapCollider2D groundCollider;  // Collider2D for the ground
    private Rigidbody2D rb = null;  // Rigidbody2D component reference
    private bool isGrounded;  // Is the character grounded?
    private DateTime bufferStart;
    public float bufferLength = 0.5f;
    public float numJump = 0;
    public cycleObject cycle;

    void Start()
    {
        cycle = gameObject.GetComponent<cycleObject>();
        this.rb = GetComponent<Rigidbody2D>();  // Get the Rigidbody2D component reference
        //bufferStart = DateTime.Now;
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
        DateTime currentTime = DateTime.Now;
        TimeSpan timeSinceJump = currentTime - bufferStart;
        // Jump if the character is grounded and the Jump button is pressed
        if (Input.GetButtonDown("Jump"))
        {

            if (cycle.type == 'a')
            {
                if (timeSinceJump.TotalSeconds >= bufferLength)
                {
                    numJump = 0;
                }
                if (numJump < 2)
                {
                    rb.AddForce(Vector2.up*jumpForce);
                    bufferStart = DateTime.Now;
                    numJump++;
                } 
            }
            else
            {
                if(timeSinceJump.TotalSeconds >= bufferLength)
                {
                    rb.AddForce(Vector2.up*jumpForce);
                    bufferStart = DateTime.Now;
                }
            }
            

        }
        if (rb.position.y < -9)
        {
            SceneManager.LoadScene ("scene1");
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -30f;
    public float jumpHeight = 3f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        // Perform ground check
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // If grounded and falling, reset velocity
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Get input for movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        // Move the character controller
        controller.Move(move * speed * Time.deltaTime);

        // Debug log to check if "Jump" input is detected
        Debug.Log("Jump Input: " + Input.GetButtonDown("Jump"));

        // If jump button is pressed and grounded, apply jump force
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Debug.Log("Jumping!"); // Debug log to check if this block is executed
            // Calculate the jump velocity needed to reach the desired jump height
            float jumpVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);
            velocity.y = jumpVelocity;
        }

        // Debug log to check current velocity before applying jump
        Debug.Log("Current Velocity: " + velocity.y);

        // Apply gravity to velocity
        velocity.y += gravity * Time.deltaTime;

        // Move the character controller with velocity
        controller.Move(velocity * Time.deltaTime);

        // Debug log to check velocity after applying jump
        Debug.Log("Velocity after jump: " + velocity.y);
    }
}

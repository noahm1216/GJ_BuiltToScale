using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonPlayer : MonoBehaviour
{
    public float speed = 5f;          // Movement speed of the player
    public float mouseSensitivity = 2f; // Sensitivity of the mouse movement
    public float jumpForce = 5f;      // Force applied when jumping
    public float gravity = -9.81f;    // Gravity value applied to the player

    private CharacterController controller;
    private Vector3 velocity;         // Player's velocity for gravity and jumping
    private Transform cameraTransform; // Reference to the player's camera
    private float xRotation = 0f;     // Current rotation around the X axis for the camera

    void Start()
    {
        // Get the CharacterController component attached to the player
        controller = GetComponent<CharacterController>();

        // Get the player's camera (assumes the camera is a child of the player)
        cameraTransform = Camera.main.transform;

        // Lock the cursor to the center of the screen and hide it
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Handle mouse look
        HandleMouseLook();

        // Handle player movement
        HandleMovement();
    }

    void HandleMouseLook()
    {
        // Get the mouse input for looking around
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Adjust the xRotation value for vertical looking
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Clamp vertical rotation to avoid flipping

        // Apply the rotation to the camera
        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Rotate the player horizontally based on the mouse X input
        transform.Rotate(Vector3.up * mouseX);
    }

    void HandleMovement()
    {
        // Get input for moving in the horizontal and vertical directions
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Calculate the direction of movement relative to the player’s orientation
        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        // Apply the movement to the CharacterController
        controller.Move(move * speed * Time.deltaTime);

        // Check if the player is grounded
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Set a small negative value to keep the player grounded
        }

        // Handle jumping
        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
        }

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;

        // Apply the gravity effect to the player's movement
        controller.Move(velocity * Time.deltaTime);
    }
}



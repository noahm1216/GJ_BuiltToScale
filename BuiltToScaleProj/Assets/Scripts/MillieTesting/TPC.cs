using UnityEngine;

public class TPC : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpHeight = 2f;
    public float gravity = -9.81f;
    public float mouseSensitivity = 2f;
    public Transform cameraTransform; // Reference to the camera

    private CharacterController characterController;
    private Vector3 velocity;
    private bool isGrounded;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked; // Hide and lock the cursor to the center of the screen
    }

    void Update()
    {
        Move();
        RotateCharacter();
    }

    void Move()
    {
        isGrounded = characterController.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Small value to ensure the player sticks to the ground
        }

        // Get input from WASD or arrow keys
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Calculate the movement direction relative to the camera
        Vector3 direction = cameraTransform.forward * vertical + cameraTransform.right * horizontal;
        direction.y = 0f; // Keep the movement in the horizontal plane

        characterController.Move(direction * moveSpeed * Time.deltaTime);

        // Handle Jumping
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

    void RotateCharacter()
    {
        // Get the horizontal mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;

        // Rotate the player based on the mouse movement
        transform.Rotate(Vector3.up * mouseX);
    }
}
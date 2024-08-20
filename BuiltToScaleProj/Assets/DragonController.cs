using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public float groundCheckDistance = 0.1f;
    public LayerMask groundLayer;

    private Rigidbody rb;
    private Vector3 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Handle movement input
        float horizontalInput = Input.GetAxis("Horizontal");
        movement = new Vector3(horizontalInput, 0, 0).normalized * moveSpeed;

        // Check if the character is grounded

        // Handle jump input
        if (Input.GetKeyDown(KeyCode.W))
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        // Move the character
        Vector3 newPosition = rb.position + movement * Time.fixedDeltaTime;
        rb.MovePosition(newPosition);
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void OnDrawGizmosSelected()
    {
        // Draw ground check ray for debugging
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundCheckDistance);
    }
}

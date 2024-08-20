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

    public ParticleSystem fireBreath;
    private Quaternion from = Quaternion.Euler(0f, 0f, 0f);
    private Quaternion to = Quaternion.Euler(0f, 180f, 0f);

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        fireBreath.Stop();
    }

    void Update()
    {
        // Handle movement input
        float horizontalInput = Input.GetAxis("Horizontal");
        movement = new Vector3(horizontalInput, 0, 0).normalized * moveSpeed;
        GetComponent<Rigidbody>().velocity = new Vector3 (movement.x, GetComponent<Rigidbody>().velocity.y, 0);

        // Check if the character is grounded

        // Handle right input input
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.rotation = to;
        }
        // Handle left input input
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.rotation = from;
        }

        // Handle jump input
        if (Input.GetKeyDown(KeyCode.W))
        {
            Jump();
        }

        // Handle space input
        if (Input.GetKey(KeyCode.Space))
        {
            fireBreath.Play();
        }
        else
        {
            fireBreath.Stop();
        }
    }

    void FixedUpdate()
    {

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

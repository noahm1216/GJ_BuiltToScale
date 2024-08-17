using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkProjectile : MonoBehaviour
{
    public float shrinkFactor = 0.5f; // The factor by which the object will shrink
    public float speed = 20f;         // The speed of the projectile

    void Start()
    {
        // Move the projectile forward
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Collided");
        // Shrink the object the projectile collides with
        //collision.transform.localScale *= shrinkFactor;
        Animator animator = collision.gameObject.GetComponent<Animator>();
        if (animator != null)
        {
            // Trigger the animation by setting the trigger
            animator.SetBool("isGrowing", false);
        }
        // Destroy the projectile after the collision
        Destroy(gameObject);
    }
}

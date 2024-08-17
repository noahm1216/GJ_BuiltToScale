using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowProjectile : MonoBehaviour
{
    public float growFactor = 1.5f; // The factor by which the object will grow
    public float speed = 20f;       // The speed of the projectile

    void Start()
    {
        // Move the projectile forward
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

    void OnTriggerEnter(Collider collision)
    {
        // Grow the object the projectile collides with
        //collision.transform.localScale *= growFactor;
        Animator animator = collision.gameObject.GetComponent<Animator>();
        if (animator != null)
        {
            // Trigger the animation by setting the trigger
            //animator.SetTrigger("isGrowing");
            animator.SetBool("isGrowing", true);

        }

        // Destroy the projectile after the collision
        Destroy(gameObject);
    }
}

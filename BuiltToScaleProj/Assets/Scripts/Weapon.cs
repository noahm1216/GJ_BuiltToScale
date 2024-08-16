using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject shrinkProjectilePrefab; // Assign the ShrinkProjectile prefab in the inspector
    public GameObject growProjectilePrefab;   // Assign the GrowProjectile prefab in the inspector
    public Transform firePoint;               // The point from which the projectiles will be fired

    void Update()
    {
        // Fire shrink projectile when pressing the left mouse button
        if (Input.GetButtonDown("Fire1"))
        {
            ShootShrinkProjectile();
        }

        // Fire grow projectile when pressing the right mouse button
        if (Input.GetButtonDown("Fire2"))
        {
            ShootGrowProjectile();
        }
    }

    void ShootShrinkProjectile()
    {
        // Instantiate and fire the shrink projectile
        Instantiate(shrinkProjectilePrefab, firePoint.position, firePoint.rotation);
    }

    void ShootGrowProjectile()
    {
        // Instantiate and fire the grow projectile
        Instantiate(growProjectilePrefab, firePoint.position, firePoint.rotation);
    }
}

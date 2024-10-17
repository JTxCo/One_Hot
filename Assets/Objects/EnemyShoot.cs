using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab; // Reference to the bullet prefab

    [SerializeField]
    private float shootInterval = 2f; // Time between shots
    [SerializeField]
    private float bulletSpeed = 20f; 

    private GameObject playerTarget;
    private float shootTimer;

    void Start()
    {
        shootTimer = shootInterval; 
    }

    private void OnTriggerEnter(Collider other)
    {
        // if (other.CompareTag("Player")) // Ensure it's the player
        {
            playerTarget = other.gameObject;
        }
    }

    void Update()
    {
        if (playerTarget != null)
        {
            transform.LookAt(playerTarget.transform.position);

            shootTimer -= Time.deltaTime;
            if (shootTimer <= 0f)
            {
                Debug.Log("Shoot");
                ShootAtPlayer();
                shootTimer = shootInterval; // Reset the timer after shooting
            }
        }
    }

    void ShootAtPlayer()
    {
        // Instantiate a new bullet
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

        // Calculate direction towards the player
        Vector3 direction = (playerTarget.transform.position - transform.position).normalized;

        // Set bullet velocity
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        if (bulletRigidbody != null)
        {
            bulletRigidbody.velocity = direction * bulletSpeed;
        }
        // Destroy the bullet after 2 seconds
        Destroy(bullet, 2f);
    }
    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject); // Destroy the enemy
        Debug.Log("Enemy destroyed");
    }
}

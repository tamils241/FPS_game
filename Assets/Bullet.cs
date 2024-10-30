using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{ 
    public float speed = 50f;  // Speed of the bullet
    public float lifetime = 5f;  // Bullet will be destroyed after this time
    public GameObject Blood_Effect;
    public AudioSource audioSource;
    public AudioClip Enemy_Sound;

    void Start()
    {
        // Destroy the bullet after a set amount of time
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        // Move the bullet forward each frame by modifying its position directly
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    // Handle collision with other objects
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            // Attempt to get the Health component from the enemy
            Health enemyHealth = other.gameObject.GetComponent<Health>();

            if (enemyHealth != null)
            {
                // Apply damage to the enemy
                enemyHealth.TakeDamage(10f);

                // Instantiate the blood effect at the collision point
                GameObject Blood = Instantiate(Blood_Effect, transform.position, transform.rotation);
                
                audioSource.PlayOneShot(Enemy_Sound);
            }

            // Destroy the bullet on impact
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public Transform player; // Reference to the player's position
    public float moveSpeed = 2.0f; // Speed at which the enemy moves towards the player
    public float attackRange = 6.0f; // Distance at which the enemy will stop and attack
    public float attackCooldown = 1.0f; // Cooldown time between attacks

    private bool hasAttacked = false; // To check if the enemy has attacked
    public Animator ani; 
    public float chasingDistance = 20f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         // Calculate the distance to the player
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (hasAttacked)
        {
            // Enemy has already attacked, so stop moving
            return;
        }
        else if (distanceToPlayer <= attackRange)
        {
            // Enemy is close enough to attack
            AttackPlayer();
        }
        else
        {
            // Move towards the player
            MoveTowardsPlayer();
        }
    }

    void MoveTowardsPlayer()
    {
        if(Vector3.Distance(transform.position,player.position) < chasingDistance)
        {
          // Move enemy towards the player at the specified speed
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
         ani.SetBool("Attack",false);
         ani.SetBool("Walk",true);
        }
       
    }

    void AttackPlayer()
    {
        // Placeholder for the attack logic
        Debug.Log("Enemy attacks the player!");

        // Set hasAttacked to true to prevent further movement
        hasAttacked = true;
         ani.SetBool("Attack",true);
         ani.SetBool("Walk",false);

        // Optionally, you can reset `hasAttacked` after some cooldown
        Invoke("ResetAttack", attackCooldown);
    }

    void ResetAttack()
    {
        hasAttacked = false;
    
    }
    }


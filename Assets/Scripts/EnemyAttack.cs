using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Transform attackPoint; // The position from which the raycast is cast
    public float attackRange = 5f; // The length of the raycast
    public LayerMask playerLayer; // The layer on which the player exists
    public int damageAmount = 10; // Amount of damage to deal to the player

    // Call this method when the enemy's attack animation occurs
    public void PerformAttack()
    {
        // Perform the raycast
        if (Physics.Raycast(attackPoint.position, attackPoint.forward, out RaycastHit hit, attackRange, playerLayer))
        {
            // Check if the raycast hit the player
            PlayerHealth playerHealth = hit.collider.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
            }
            if (hit.transform.TryGetComponent<PlayerHealth>(out PlayerHealth T))
            { T.TakeDamage(damageAmount); }
            
        }
    }
}

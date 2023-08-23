using UnityEngine;
using UnityEngine.AI;

public class Enemy_1 : MonoBehaviour
{
    private Spawn_Waves spawn_Waves;
    public NavMeshAgent enemy_Ai;
    public Transform Player;
    int currentHealth;
    public int maxHealth;

    private void Start()
    {
       
    }
    public void Update()
    {
        
        enemy_Ai.SetDestination(Player.position);
    }

    void Awake()
    {
        enemy_Ai.GetComponent<NavMeshAgent>();
        spawn_Waves = FindObjectOfType<Spawn_Waves>();
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if(currentHealth <= 0)
        { Death(); }
    }

    void Death()
    {
        Debug.Log("Enemy Defeated");
        spawn_Waves.EnemyDefeated();
        // Death function
        // TEMPORARY: Destroy Object
        Destroy(gameObject);
    }
}

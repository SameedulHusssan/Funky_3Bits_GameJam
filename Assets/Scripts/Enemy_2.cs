using UnityEngine;
using UnityEngine.AI;

public class Enemy_2 : MonoBehaviour
{
    private Spawn_Waves spawn_Waves;
    public NavMeshAgent enemy_2_Ai;   
    public Transform tower;
    int currentHealth;
    public int maxHealth;

    //public Transform tower;
    void Awake()
    {
        enemy_2_Ai.GetComponent<NavMeshAgent>();
        spawn_Waves = FindObjectOfType<Spawn_Waves>();
        currentHealth = maxHealth;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Is it running");
        enemy_2_Ai.SetDestination(tower.position);
    }
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        { Death(); }
    }
    void Death()
    {

        // Death function
        // TEMPORARY: Destroy Object
        spawn_Waves.EnemyDefeated();
        Destroy(gameObject);
    }
}

using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy_1 : MonoBehaviour
{
    private Spawn_Waves spawn_Waves;
    public NavMeshAgent enemy_Ai;
    public Transform player;
    int currentHealth;
    public int maxHealth;
    [SerializeField] Slider enemyHealthBar;
    public Animator EnemyAnimator;
    public EnemyAttack enemyAttack;

    private void Start()
    {
        enemy_Ai = GetComponent<NavMeshAgent>();
        
        enemyHealthBar.value = currentHealth;
    }
    public void Update()
    {
        
        if (player != null)
        {
            enemy_Ai.SetDestination(player.position);
        }
       
        if (enemy_Ai != null && player != null)
        {
            float distance = Vector3.Distance(transform.position, player.position);
            

            // You can now use the distance value for your gameplay logic
            if (distance < 5)
            {
                EnemyAnimator.SetTrigger("Sowrd");
                enemyAttack.PerformAttack();
                // Take action based on the distance
            }
            else
            {
                EnemyAnimator.SetTrigger("Walk");
            }

        }
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
        enemyHealthBar.value = currentHealth;
            if (currentHealth <= 0)
            { Death(); }
        }

        public void Death()
        {
            Debug.Log("Enemy Defeated");
            spawn_Waves.EnemyDefeated();
            // Death function
            // TEMPORARY: Destroy Object
            Destroy(gameObject);
        }
}


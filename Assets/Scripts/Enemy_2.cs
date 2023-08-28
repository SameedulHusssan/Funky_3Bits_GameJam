using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy_2 : MonoBehaviour
{
    private Spawn_Waves spawn_Waves;
    public NavMeshAgent enemy_2_Ai;   
    public Transform tower;
    public Animator enemy_2_Animator;
    [SerializeField] Slider enemyHealthBar;
    int currentHealth;
    public int maxHealth;

    //public Transform tower;
    void Awake()
    {
        this.enemy_2_Ai = GetComponent<NavMeshAgent>();
        this.enemy_2_Animator = GetComponent<Animator>();
        spawn_Waves = FindObjectOfType<Spawn_Waves>();
        currentHealth = maxHealth;
    }
    // Start is called before the first frame update
    void Start()
    {
        enemy_2_Ai = GetComponent<NavMeshAgent>();
        enemyHealthBar.value = currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
       
        enemy_2_Ai.SetDestination(tower.position);
        if (enemy_2_Ai != null && tower != null)
        {
            float distance = Vector3.Distance(transform.position, tower.position);
            Debug.Log("Distance to player: " + distance);

            // You can now use the distance value for your gameplay logic
            if (distance < 5)
            {
                enemy_2_Animator.SetTrigger("Hammer");
                // Take action based on the distance
            }
            else
            {
                enemy_2_Animator.SetTrigger("Walk");
            }

        }
    }
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        enemyHealthBar.value = currentHealth;
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

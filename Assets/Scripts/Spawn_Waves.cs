using System.Collections;
using UnityEngine;

public class Spawn_Waves : MonoBehaviour
{

    public Transform[] spawnPoints;  // Assign the spawn points in the Inspector
    public GameObject[] enemyTypes;  // Assign the enemy prefabs in the Inspector
    private int currentWave = 1;
    public Transform player;
    public Transform tower;
    private int enemiesAlive;

    private void Start()
    {
        enemiesAlive = currentWave * spawnPoints.Length;
        StartCoroutine(SpawnWaves());
    }

    private void StartNextWave()
    {
        enemiesAlive = currentWave;
        StartCoroutine(SpawnWaves());
    }
    private IEnumerator SpawnWaves()
    {
        Debug.Log("Start Enenmy LIve: " + enemiesAlive);
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            for (int j = 0; j < currentWave; j++)
            {
                GameObject enemyPrefab = enemyTypes[currentWave % 2];
                GameObject enemy_Spawn = Instantiate(enemyPrefab, spawnPoints[i].position, Quaternion.identity);
                if (enemy_Spawn.GetComponent<Enemy_1>()) { enemy_Spawn.GetComponent<Enemy_1>().Player = player; }
                if (enemy_Spawn.GetComponent<Enemy_2>()) { enemy_Spawn.GetComponent<Enemy_2>().tower = tower; }
                //enemy_Spawn.GetComponent<Enemy_2>().tower = checking;
                yield return new WaitForSeconds(0.5f);
            }
        }

        while (enemiesAlive > 0)
        {
            yield return null; // Wait until all enemies are defeated
        }

        currentWave++;
        Debug.Log("End Enenmy Live: " + enemiesAlive);
        StartNextWave();
    }
    public void EnemyDefeated()
    {
        Debug.Log("Enenmy Live: " + enemiesAlive);
        enemiesAlive--;
    }

}




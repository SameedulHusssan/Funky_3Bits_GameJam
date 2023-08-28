using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
   [SerializeField] int currentHealth;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] Slider playerHealth;
     void Start()
    {
        Time.timeScale = 1;
        playerHealth.value = currentHealth;        
    }
    public void TakeDamage(int amount)
    {
       
        currentHealth -= amount;
        playerHealth.value = currentHealth;
        if (currentHealth <= 0)
        { Death(); }
    }
    public void Death()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }
}

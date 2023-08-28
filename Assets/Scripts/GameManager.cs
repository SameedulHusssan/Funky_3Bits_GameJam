using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

   public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void GamePause(GameObject pauseMenu)
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void GameResume(GameObject pauseMenu)
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
 public void StartGame(string scene_Name)
    {
        SceneManager.LoadScene(scene_Name);
    }
public void ExitGame()
    {
        Application.Quit();
    }
    public void ExitPanelON(GameObject exitPanel)
    {
        exitPanel.SetActive(true);
    }
    public void ExitPanelOff(GameObject exitPanel)
    {
        exitPanel.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{

    public GameObject cam;
    public GameObject MainMenuCanvas;
    public GameObject SettingsMenuCanvas;
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void OpenSettings()
    {
        MainMenuCanvas.SetActive(false);
        SettingsMenuCanvas.SetActive(true);
    }
   
   
}

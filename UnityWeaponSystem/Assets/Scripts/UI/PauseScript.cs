using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PauseScript : MonoBehaviour
{

    public static bool GamePaused = false;
    public bool GameIsPaused = false;
    public GameObject PauseMenuUI;
    public GameObject GameUI;
    public GameObject SettingsBackdrop;

    public GameObject SettingsButton;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused)
            {
                Resume();
                GameIsPaused = false;
            }
            else
            {
                Pause();
                GameIsPaused = true;
            }
        }
        if (FindObjectOfType<MainMenuScript>().SettingsMenuCanvas.activeInHierarchy)
        {
            EnablePauseBackButton();
        }
        else
        {
            RemovePauseBackButton();
        }
    }
    public void Resume()
    {
        GameUI.SetActive(true);
        PauseMenuUI.SetActive(false);
        SettingsBackdrop.SetActive(false);
        SettingsButton.SetActive(false);
        CloseSettings();
        Time.timeScale = 1f;
        GamePaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        



    }
    void Pause()
    {
        GameUI.SetActive(false);
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void GoToMainMenu()
    {
        PauseMenuUI.SetActive(false);
        FindObjectOfType<SoundManagerScript>().StopMusic();
        StartCoroutine(LoadMainMenu());
        FindObjectOfType<MainMenuScript>().MainMenuCanvas.SetActive(true);
        FindObjectOfType<SoundManagerScript>().GameStarted = false;
        StartCoroutine(FindObjectOfType<SoundManagerScript>().StartMainMenuMusic());
        Time.timeScale = 1f;
        ResetUI();
        



    }
    public void QuitGame()
    {
        Application.Quit();
    }
    IEnumerator LoadMainMenu()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("MainMenu");
        ResetUI();
        yield return null;

    }
    public void OpenSettings()
    {
        PauseMenuUI.SetActive(false);
        SettingsBackdrop.SetActive(true);
        FindObjectOfType<MainMenuScript>().SettingsMenuCanvas.SetActive(true);
        FindObjectOfType<MainMenuScript>().MainMenuBackButton.SetActive(false);
        SettingsButton.SetActive(true);

    }
    void ResetUI()
    {
        SettingsButton.SetActive(false);
        FindObjectOfType<MainMenuScript>().MainMenuBackButton.SetActive(true);
    }
    public void CloseSettings()
    {
        FindObjectOfType<MainMenuScript>().SettingsMenuCanvas.SetActive(false);
        FindObjectOfType<MainMenuScript>().GraphicsCanvas.SetActive(false);
        FindObjectOfType<MainMenuScript>().SecretCanvas.SetActive(false);
        FindObjectOfType<MainMenuScript>().AudioCanvas.SetActive(false);

    }
   
    public void RemovePauseBackButton()
    {
        SettingsButton.SetActive(false);
    }
    public void EnablePauseBackButton()
    {
        SettingsButton.SetActive(true);
    }
    public void CloseSetttingsCanvas()
    {
        FindObjectOfType<MainMenuScript>().SettingsMenuCanvas.SetActive(false);
    }
    }


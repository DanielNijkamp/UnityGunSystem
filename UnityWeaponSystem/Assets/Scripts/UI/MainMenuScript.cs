using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class MainMenuScript : MonoBehaviour
{
    public GameObject LoadingCanvas;
    public Slider slider;
    public TextMeshProUGUI ProgressText;

    public void PlayGame(int sceneIndex)
    {
        StartCoroutine(LoadAsync(sceneIndex));
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    IEnumerator LoadAsync(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("GameScene");
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            ProgressText.text = progress * 100f + "%";
            yield return null;
        }
        if (operation.isDone)
        {
            LoadingCanvas.SetActive(false);
        }
    }
   
    
   
   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFreezer : MonoBehaviour
{
    GameObject[] pauseObjects;
    GameObject pauseGameButton;
    Scene activeScene;

    void Start()
    {
        Time.timeScale = 1;
        pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
        pauseGameButton = GameObject.FindGameObjectWithTag("HideOnPause");
        HidePauseObjects();
        ShowPauseGameButton();
        activeScene = SceneManager.GetActiveScene();
    }

    private void Update()
    {
        //activeScene = SceneManager.GetActiveScene();
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        ShowPauseObjects();
        HidePauseGameButton();
        activeScene = SceneManager.GetActiveScene();
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        HidePauseObjects();
        ShowPauseGameButton();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(activeScene.name);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void HidePauseObjects()
    {
        foreach (GameObject gameObject in pauseObjects)
        {
            gameObject.SetActive(false);
        }
    }

    private void ShowPauseObjects()
    {
        foreach (GameObject gameObject in pauseObjects)
        {
            gameObject.SetActive(true);
        }
    }

    private void HidePauseGameButton()
    {
        pauseGameButton.SetActive(false);
    }

    private void ShowPauseGameButton()
    {
        pauseGameButton.SetActive(true);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFreezer : MonoBehaviour
{
    GameObject[] pauseObjects;
    GameObject pauseGameButton;
    Scene activeScene;

    public static bool isPaused;

    void Start()
    {
        Time.timeScale = 1;
        pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
        pauseGameButton = GameObject.FindGameObjectWithTag("HideOnPause");
        HidePauseObjects();
        ShowPauseGameButton();
        activeScene = SceneManager.GetActiveScene();
        isPaused = false;
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
        isPaused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        HidePauseObjects();
        ShowPauseGameButton();
        isPaused = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("AskFirstLevel");  //to tak nie działa, trzeba jeszcze zmienne przygotować,
                                                   //także dodaje linjke z kodem, która czyści dane gry, 
        newGameReset.prepareNewGame();             //restart rozumiem jako restart całej gry anie tylko lvl
                                                   //inaczej będzie ciężko to zakodować
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
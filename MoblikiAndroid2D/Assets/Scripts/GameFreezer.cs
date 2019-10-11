using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFreezer : MonoBehaviour
{
    GameObject[] pauseObjects;
    GameObject pauseGameButton;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
        pauseGameButton = GameObject.FindGameObjectWithTag("HideOnPause");
        HidePauseObjects();
        ShowPauseGameButton();
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        ShowPauseObjects();
        HidePauseGameButton();
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        HidePauseObjects();
        ShowPauseGameButton();
    }

    public void RestartGame()
    {
        // TODO: odwolywac sie do zmiennej identyfikujacej level
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
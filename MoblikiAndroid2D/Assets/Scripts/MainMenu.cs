using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        newGameReset.prepareNewGame();
        SceneManager.LoadScene("AskFirstLevel");
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void BestScore()
    {
        SceneManager.LoadScene("BestScoreMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

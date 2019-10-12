using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public InputField playername;

    void Start()
    {
        //Changes the character limit in the main input field.
        playername.characterLimit = 10;
    }
    public void Play()
    {
        bonusScript.playernamestr = playername.text;
        BestScoreMenu.playernamestr = playername.text;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class MainMenu : MonoBehaviour
{
    public InputField playername;


    void Start()
    {
        //FindObjectOfType<AudioManager>().Play("MenuMusic");
        //Changes the character limit in the main input field.
        playername.characterLimit = 10;
        playername.text = BestScoreMenu.playernamestr;
    }
    public void Play()
    {
        bonusScript.playernamestr = playername.text;
        BestScoreMenu.playernamestr = playername.text;
        newGameReset.prepareNewGame();
        SceneManager.LoadScene("AskFirstLevel");
    }

    public void UpdatePlayerName()
    {
        BestScoreMenu.playernamestr = playername.text;
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void BestScore()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            BestScoreMenu.isLoadedFromMainMenuScene = true;
        }
        else
        {
            BestScoreMenu.isLoadedFromMainMenuScene = false;
        }
        SceneManager.LoadScene("BestScoreMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

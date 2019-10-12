using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endScore : MonoBehaviour
{
    public Text score;

    private void Start()
    {
        score.text = "Twój wynik: " + scoreCounter.points.ToString("0.0") + ".";
    }

    public void mainMenu()
    {
        BestScoreMenu.isLoadedFromEndScreen = true;
        SceneManager.LoadScene("BestScoreMenu");
    }
}
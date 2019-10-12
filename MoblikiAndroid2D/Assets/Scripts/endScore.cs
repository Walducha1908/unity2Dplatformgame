using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endScore : MonoBehaviour
{
/*    ScoreTable scoreTable;*/
    public Text score;

    private void Start()
    {
        score.text = "Twój wynik: " + scoreCounter.points.ToString("0.0") + ".";
/*        scoreTable = new ScoreTable();
        scoreTable.Create();*/
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
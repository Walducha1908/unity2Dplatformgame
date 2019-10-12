using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BestScoreMenu : MonoBehaviour
{
    public static string playernamestr; //string do ktorego przekazywana jest imie po wpisaniu go w okienku

    public Text score;

    public void Start()
    {
        ShowBestScore();
    }

    public void ShowBestScore()
    {
        score.text = playernamestr +": " + scoreCounter.points; // TODO: uwzgledniac najlepszy wynik, a nie jakikolwiek
    }
}
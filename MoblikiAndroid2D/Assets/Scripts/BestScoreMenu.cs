using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScoreMenu : MonoBehaviour
{
    public Text score;

    public void Start()
    {
        ShowBestScore();
    }

    public void ShowBestScore()
    {
        score.text = "Najlepszy wynik: " + scoreCounter.points; // TODO: uwzgledniac najlepszy wynik, a nie jakikolwiek
    }
}
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
        if (firstLevelStart.infBonus)
        {
            FindObjectOfType<AudioManager>().Play("DeathSoundINF");
            score.text = "Twój wynik: " + scoreCounter.points.ToString("0.0") + ".";
        }
        else
        {
            FindObjectOfType<AudioManager>().Play("DeathSound");
            score.text = "Twój wynik: " + scoreCounter.points.ToString("0.0") + ".";
        }


    }

    public void mainMenu()
    {
        BestScoreMenu.isLoadedFromEndScreen = true;
        SceneManager.LoadScene("BestScoreMenu");
    }
}
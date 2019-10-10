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
        score.text = "Your score: " + scoreCounter.points;
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

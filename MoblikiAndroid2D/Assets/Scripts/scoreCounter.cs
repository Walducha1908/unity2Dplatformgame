using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class scoreCounter : MonoBehaviour
{
    public float scorePerSecond;
    public static float points;
    public Text scoreLine;

    private float theCountdown = 0.5f;
    private float waitingForNextPoints = 0.5f;

    void Update()
    {
        theCountdown -= Time.deltaTime;
        if (theCountdown <= 0)
        {
            theCountdown = waitingForNextPoints;
            points += theCountdown*scorePerSecond;
            updateScore();
        }
    }

    void updateScore()
    {
        scoreLine.text = "ECTS: " + points;
    }
}

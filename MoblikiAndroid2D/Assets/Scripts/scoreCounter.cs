using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class scoreCounter : MonoBehaviour
{
    public float scorePerSecond;
    public static float points;
    public Text scoreLine;
    public static float bonus = 1;

    private float theCountdown = 0.2f;
    private float waitingForNextPoints = 0.2f;

    void Update()
    {
        theCountdown -= Time.deltaTime;
        if (theCountdown <= 0)
        {
            theCountdown = waitingForNextPoints;
            points += theCountdown*scorePerSecond*bonus;
            updateScore();
        }
    }

    void updateScore()
    {
        scoreLine.text = "ECTS: " + points.ToString("0");
    }
}

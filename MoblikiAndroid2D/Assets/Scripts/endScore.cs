using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class endScore : MonoBehaviour
{
    public Text score;

    private void Start()
    {
        score.text = "Your score: " + scoreCounter.points;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class endLevelTrigger : MonoBehaviour
{
    public Text bonusText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        scoreCounter.level++;

        if (firstLevelStart.infBonus && scoreCounter.level == 2)
        {
            hitRock.numberOfHits = 0;
            SceneManager.LoadScene("AskSecondLevelInf");
        }
        else
        {
            bonusText.text = "";
            SceneManager.LoadScene("endScreen");
        }
    }
}

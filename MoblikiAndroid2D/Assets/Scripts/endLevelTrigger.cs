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
        hitRock.numberOfHits = 0;

        if (firstLevelStart.infBonus && scoreCounter.level == 2)
        {
            hitRock.numberOfHits = 0;
            SceneManager.LoadScene("AskSecondLevelInf");
        }
        else if(firstLevelStart.mathsBonus && scoreCounter.level == 2)
        {
            SceneManager.LoadScene("AskSecondLevelMath");
        }
        else if(firstLevelStart.physicsBonus && scoreCounter.level == 2)
        {
            SceneManager.LoadScene("AskSecondLevelPhysics");
        }
        else if(scoreCounter.level == 3)
        {
            SceneManager.LoadScene("AskThirdLevel");
        }
    }
}

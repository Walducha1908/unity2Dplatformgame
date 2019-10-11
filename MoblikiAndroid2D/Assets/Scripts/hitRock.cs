using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class hitRock : MonoBehaviour
{
    public float currentPenaltyValue;
    public Text penaltyLine;
    public Text awardLine;
    public GameObject player;

    private static bool penaltyFlag;
    private static float theCountdown = 0.7f;

    private static bool awardFlag;
    private static float theCountdownAward = 0.7f;

    public static float programEnemyValue = 1;
    public static int numberOfHits = 0;
    public GameObject shield;

    private bool awardCollected = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        numberOfHits++;
        Destroy(gameObject);

        if (firstLevelStart.infBonus && numberOfHits <= 2)
        {
            return;
        }

        scoreCounter.points -= currentPenaltyValue*programEnemyValue;
        
        penaltyLine.text = "-" + (currentPenaltyValue*programEnemyValue).ToString("0.0");
        penaltyFlag = true;
    }

    private void Update()
    {
        if (this.transform.position.x < player.transform.position.x - 10)
            Destroy(gameObject);

        if (this.transform.position.x < player.transform.position.x)
        {
            if (secondMathsLevelStart.mathsBonus && !awardCollected)
            {
                scoreCounter.points += 0.5f;
                awardLine.text = "+0,5";
                awardFlag = true;
                awardCollected = true;
            }
        }

        if (awardFlag && theCountdownAward >= 0)
        {
            theCountdownAward -= Time.deltaTime;
        }
        else if (awardFlag && theCountdownAward <= 0)
        {
            awardFlag = false;
            awardLine.text = "";
            theCountdownAward = 0.7f;
        }

        if (penaltyFlag && theCountdown >= 0)
        {
            theCountdown -= Time.deltaTime;
        }
        else if (penaltyFlag && theCountdown <= 0)
        {
            penaltyFlag = false;
            penaltyLine.text = "";
            theCountdown = 0.7f;
        }

        if (numberOfHits == 2)
        {
            shield.SetActive(false);
        }
    }
}

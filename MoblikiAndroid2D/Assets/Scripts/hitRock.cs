using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class hitRock : MonoBehaviour
{
    public float currentPenaltyValue;
    public Text penaltyLine;

    private static bool penaltyFlag;
    private static float theCountdown = 0.7f;

    public static float programEnemyValue = 1;
    public static int numberOfHits = 0;

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
        if (this.transform.position.x < -13f)
            Destroy(gameObject);

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

    }
}

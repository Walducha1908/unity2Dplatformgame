using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class bonusScript : MonoBehaviour
{
    public Text textBonus;
    public Text levelText;
    public Text PlayerName;

    public Button physIcon;
    public Button softIcon;
    public Button mechIcon;
    public Button graphIcon;
    public Button mathIcon;
    public Button docIcon;
    public Button workerIcon;

    public GameObject bomb;
    public GameObject shield;
    public Text thirdLevelAward;

    public static bool isPlayerProtected = false;
    public static string playernamestr;

    private float waitingForNextAward = 10;
    private float theCountdown = 10;
    private float theCountdownToClose = 1;
    private float bonusScienceVal = 10;
    private bool awardTextIsShown = false;


    void Start()
    {
        PlayerName.text = "Gracz:" + playernamestr;

        if (firstLevelStart.mathsBonus)
        {
            scoreCounter.bonus = 1.2f;
        }
        else if(firstLevelStart.infBonus)
        {
            isPlayerProtected = true;
            shield.SetActive(true);
        }
        else if(firstLevelStart.physicsBonus)
        {
            PlayerControls.jumpPower = 7.7f;
        }

        if(secondInfLevelStart.ioadBonus)
        {
            softIcon.gameObject.SetActive(true);
            isPlayerProtected = true;
            hitRock.programEnemyValue = 0.5f;
        }
        else if(secondInfLevelStart.gkimBonus)
        {
            graphIcon.gameObject.SetActive(true);
            isPlayerProtected = true;
            PlayerControls.reduceValue = 2.5f;
        }

        if (secondMathsLevelStart.mathsBonus)
        {
            mathIcon.gameObject.SetActive(true);
        }
        else if(secondMathsLevelStart.architectureBonus)
        {
            bomb.SetActive(true);
        }

        if (secondPhysicsLevelStart.physicsBonus)
        {
            physIcon.gameObject.SetActive(true);
        }
        else if(secondPhysicsLevelStart.mechaBonus)
        {
            mechIcon.gameObject.SetActive(true);
        }



        if (thirdLevelStart.corpoBonus)
        {
            workerIcon.gameObject.SetActive(true);
        }
        else if(thirdLevelStart.scienceBonus)
        {
            docIcon.gameObject.SetActive(true);
        }

        if (scoreCounter.level == 1)
        {
            levelText.text = "Poziom 1 - matura";
        }
        else if(scoreCounter.level == 2)
        {
            levelText.text = "Poziom 2 - studia";
        }
        else if(scoreCounter.level == 3)
        {
            levelText.text = "Poziom 3 - praca";
        }
    }

    private void Update()
    {
        theCountdown -= Time.deltaTime;
        if (theCountdown <= 0 && scoreCounter.level == 3)
        {
            theCountdown = waitingForNextAward;
            if (thirdLevelStart.corpoBonus)
            {
                scoreCounter.points += 30;
                thirdLevelAward.text = "+30";
                awardTextIsShown = true;
            }
            else if(thirdLevelStart.scienceBonus)
            {
                scoreCounter.points += bonusScienceVal;
                thirdLevelAward.text = "+" + bonusScienceVal.ToString("0");
                bonusScienceVal += 10;
                awardTextIsShown = true;
            }
        }

        if(awardTextIsShown)
        {
            theCountdownToClose -= Time.deltaTime;
        }

        if(theCountdownToClose <= 0)
        {
            thirdLevelAward.text = "";
            theCountdownToClose = 1;
            awardTextIsShown = false;
        }
    }
}

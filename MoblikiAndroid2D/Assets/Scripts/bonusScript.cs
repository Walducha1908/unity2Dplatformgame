using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class bonusScript : MonoBehaviour
{
    public Text textBonus;
    public Text levelText;
    public Text PlayerName;
    public GameObject bomb;
    public GameObject shield;
    public Text thirdLevelAward;

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
            textBonus.text = "Matematyka - x1.2 do ECTS";
        }
        else if(firstLevelStart.infBonus)
        {
            textBonus.text = "Informatyka - pierwsze" + " dwa uderzenia bezpłatne";
            shield.SetActive(true);
        }
        else if(firstLevelStart.physicsBonus)
        {
            textBonus.text = "Fizyka - siła skoku + 10%";
            PlayerControls.jumpPower = 7.7f;
        }

        if(secondInfLevelStart.ioadBonus)
        {
            textBonus.text = textBonus.text + "\nIOAD - 50% mniej straconych ECTS-ów";
            hitRock.programEnemyValue = 0.5f;
        }
        else if(secondInfLevelStart.gkimBonus)
        {
            textBonus.text = textBonus.text + "\nGKiM - +50% do zmniejszania";
            PlayerControls.reduceValue = 2.5f;
        }

        if (secondMathsLevelStart.mathsBonus)
        {
            textBonus.text = textBonus.text + "\nStosowana - +3pkt za każdy unik";
        }
        else if(secondMathsLevelStart.architectureBonus)
        {
            textBonus.text = textBonus.text + "\nArchitektura - Wynaleziono bombę!";
            bomb.SetActive(true);
        }

        if (secondPhysicsLevelStart.physicsBonus)
        {
            textBonus.text = textBonus.text + "\nTechniczna - 5x podwójny wyskok!";
        }
        else if(secondPhysicsLevelStart.mechaBonus)
        {
            textBonus.text = textBonus.text + "\nMechanika - 10s spowolnienia przeciwników!";
        }

        if (thirdLevelStart.corpoBonus)
        {
            textBonus.text = textBonus.text + "\nPraca w firmie - +30pkt co 10s";
        }
        else if(thirdLevelStart.scienceBonus)
        {
            textBonus.text = textBonus.text + "\nPraca naukowa - +10, 20, 30pkt narastająco co 10s";
        }

        if(scoreCounter.level == 1)
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

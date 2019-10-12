using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class bonusScript : MonoBehaviour
{
    public Text textBonus;
    public Text levelText;
    public GameObject bomb;
    public GameObject shield;

    void Start()
    {
        if (firstLevelStart.mathsBonus)
        {
            scoreCounter.bonus = 1.2f;
            textBonus.text = "Matematyka - x1.2 do ECTS";
        }
        else if(firstLevelStart.infBonus)
        {
            textBonus.text = "Informatyka - pierwsze\n" + "dwa uderzenia bezpłatne";
            shield.SetActive(true);
        }
        else if(firstLevelStart.physicsBonus)
        {
            textBonus.text = "Fizyka - siła skoku + 10%";
            PlayerControls.jumpPower = 7.7f;
        }

        if(secondInfLevelStart.ioadBonus)
        {
            textBonus.text = textBonus.text + "\nIOAD - 30% mniej \nstraconych ECTS-ów";
            hitRock.programEnemyValue = 0.7f;
        }
        else if(secondInfLevelStart.gkimBonus)
        {
            textBonus.text = textBonus.text + "\nGKiM - +50% do zmniejszania";
            PlayerControls.reduceValue = 2.5f;
        }

        if (secondMathsLevelStart.mathsBonus)
        {
            textBonus.text = textBonus.text + "\nStosowana -\n+0.5pkt za każdy unik";
        }
        else if(secondMathsLevelStart.architectureBonus)
        {
            textBonus.text = textBonus.text + "\nArchitektura -\nWynaleziono bombę!";
            bomb.SetActive(true);
        }

        if (secondPhysicsLevelStart.physicsBonus)
        {
            textBonus.text = textBonus.text + "\nTechniczna -\nPodwójny wyskok!";
        }
        else if(secondPhysicsLevelStart.mechaBonus)
        {
            textBonus.text = textBonus.text + "\nMechanika - 10s \nspowolnienia przeciwników!";
        }

        if(scoreCounter.level == 1)
        {
            levelText.text = "Poziom 1 - matura";
        }
        else if(scoreCounter.level == 2)
        {
            levelText.text = "Poziom 2 - studia";
        }
    }
}

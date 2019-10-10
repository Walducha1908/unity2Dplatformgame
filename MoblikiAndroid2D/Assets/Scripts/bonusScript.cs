using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class bonusScript : MonoBehaviour
{
    public Text textBonus;

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
        }
        else if(firstLevelStart.physicsBonus)
        {
            textBonus.text = "Fizyka - siła skoku + 10%";
            PlayerControls.jumpPower = 7.7f;
        }
    }
}

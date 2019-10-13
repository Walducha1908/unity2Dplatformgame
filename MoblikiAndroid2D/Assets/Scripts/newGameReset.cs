using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class newGameReset : MonoBehaviour
{
    public static void prepareNewGame()
    {
        scoreCounter.points = 0;
        scoreCounter.bonus = 1;
        scoreCounter.level = 1;

        firstLevelStart.mathsBonus = false;
        firstLevelStart.infBonus = false;
        firstLevelStart.physicsBonus = false;

        secondInfLevelStart.ioadBonus = false;
        secondInfLevelStart.gkimBonus = false;
        secondMathsLevelStart.mathsBonus = false;
        secondMathsLevelStart.architectureBonus = false;
        secondPhysicsLevelStart.physicsBonus = false;
        secondPhysicsLevelStart.mechaBonus = false;

        thirdLevelStart.corpoBonus = false;
        thirdLevelStart.scienceBonus = false;

        PlayerControls.jumpPower = 7;
        PlayerControls.reduceValue = 2;

        hitRock.numberOfHits = 0;
        hitRock.programEnemyValue = 1;
    
    }
}

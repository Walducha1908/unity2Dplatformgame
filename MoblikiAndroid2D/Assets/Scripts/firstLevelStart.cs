using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class firstLevelStart : MonoBehaviour
{
    public static bool mathsBonus = false;
    public static bool infBonus = false;
    public static bool physicsBonus = false;

    public void mathsClicked()
    {
        mathsBonus = true;
        whateverClicked();
    }

    public void physicsClicked()
    {
        physicsBonus = true;
        whateverClicked();
    }

    public void infClicked()
    {
        infBonus = true;
        whateverClicked();
    }

    public void whateverClicked()
    {
        SceneManager.LoadScene(1);
    }
}

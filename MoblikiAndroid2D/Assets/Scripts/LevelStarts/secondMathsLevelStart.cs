using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class secondMathsLevelStart : MonoBehaviour
{
    public static bool mathsBonus = false;
    public static bool architectureBonus = false;

    public void mathsClicked()
    {
        mathsBonus = true;
        whateverClicked();
    }

    public void architectureClicked()
    {
        architectureBonus = true;
        whateverClicked();
    }

    public void whateverClicked()
    {
        SceneManager.LoadScene("FirstLevel");
    }

    public void backScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

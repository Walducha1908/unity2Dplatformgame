using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class thirdLevelStart : MonoBehaviour
{
    public static bool corpoBonus = false;
    public static bool scienceBonus = false;

    public void corpoClicked()
    {
        corpoBonus = true;
        whateverClicked();
    }

    public void scienceClicked()
    {
        scienceBonus = true;
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

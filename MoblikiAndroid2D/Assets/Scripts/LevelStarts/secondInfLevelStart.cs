using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class secondInfLevelStart : MonoBehaviour
{
    public static bool ioadBonus = false;
    public static bool gkimBonus = false;

    public void ioadClicked()
    {
        ioadBonus = true;
        whateverClicked();
    }

    public void gkimClicked()
    { 
        gkimBonus = true;
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

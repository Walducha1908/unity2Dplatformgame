using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class secondPhysicsLevelStart : MonoBehaviour
{
    public static bool physicsBonus = false;
    public static bool mechaBonus = false;

    public void physicsClicked()
    {
        physicsBonus = true;
        whateverClicked();
    }

    public void mechaClicked()
    {
        mechaBonus = true;
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

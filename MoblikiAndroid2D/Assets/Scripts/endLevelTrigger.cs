using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class endLevelTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(2);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombExsplosion : MonoBehaviour
{
    public void bum()
    {
        FindObjectOfType<AudioManager>().Play("Bomb");
        this.gameObject.SetActive(false);

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
    }
}

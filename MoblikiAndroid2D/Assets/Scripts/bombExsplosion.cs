using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombExsplosion : MonoBehaviour
{
    public void bum()
    {
        this.gameObject.SetActive(false);

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
    }
}

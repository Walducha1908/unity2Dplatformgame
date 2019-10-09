using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnRocks : MonoBehaviour
{
    public GameObject theRock;
    public GameObject player;

    public float waitingForNextSpawn = 10;
    public float theCountdown = 10;

    public float xSpawn;
    public float yMin;
    public float yMax;

    void Update()
    {
        theCountdown -= Time.deltaTime;
        if (theCountdown <= 0)
        {
            SpawnRocks();
            theCountdown = waitingForNextSpawn;
        }
    }

    void SpawnRocks()
    {
        GameObject newRock = (GameObject)Instantiate
            (theRock, new Vector3(player.transform.position.x + xSpawn, Random.Range(yMin, yMax), 10), Quaternion.identity);
    }
}

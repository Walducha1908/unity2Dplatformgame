﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnRocks : MonoBehaviour
{
    public GameObject theRock;
    public GameObject player;

    public float waitingForNextSpawn;
    public float theCountdown;

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
        GameObject newSpikes = (GameObject)Instantiate
            (theRock, new Vector3(player.transform.position.x + xSpawn, Random.Range(yMin, yMax), 10), Quaternion.identity);

        newSpikes.transform.Rotate(0, 0, 90);
    }
}
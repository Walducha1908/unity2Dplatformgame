using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnRocks : MonoBehaviour
{
    public GameObject[] theRock;
    public GameObject player;

    public float waitingForNextSpawn;
    public float theCountdown;

    public float xSpawn;
    public float yMin;
    public float yMax;

    private void Start()
    {
        if (scoreCounter.level == 2)
        {
            waitingForNextSpawn *= 0.88f;
            theCountdown *= 0.88f;
        }
        else if (scoreCounter.level == 3)
        {
            waitingForNextSpawn *= 0.75f;
            theCountdown *= 0.75f;
        }
    }

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
        int result = Random.Range(0, 3);                //losujemy miejsce w tablicy wyloswanych kolców

        GameObject newSpikes = (GameObject)Instantiate
            (theRock[result], new Vector3(player.transform.position.x + xSpawn, Random.Range(yMin, yMax), 10), Quaternion.identity);

        newSpikes.transform.Rotate(0, 0, 90);
    }
}

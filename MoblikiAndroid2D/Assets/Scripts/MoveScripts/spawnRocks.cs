using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class spawnRocks : MonoBehaviour
{
    public GameObject[] theRock;
    public GameObject player;

    public Text mechaText;
    public Button mechaButton;

    public float waitingForNextSpawn;
    public float theCountdown;
    private float theCountdownMechaBonus = 10;

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
            waitingForNextSpawn *= 0.77f;
            theCountdown *= 0.77f;
        }

        if (secondPhysicsLevelStart.mechaBonus)
        {
            waitingForNextSpawn *= 1.15f;
            mechaButton.gameObject.SetActive(true);
        }
    }

    void Update()
    {
        theCountdown -= Time.deltaTime;
        if (theCountdownMechaBonus <= 10)
            theCountdownMechaBonus -= Time.deltaTime; 

        if (theCountdown <= 0)
        {
            SpawnRocks();
            if (scoreCounter.level == 3)
            {
                waitingForNextSpawn = 1.48f * Random.Range(0.82f, 1.18f);
            }
            theCountdown = waitingForNextSpawn;
        }
        if (theCountdownMechaBonus <= 0)
        {
            waitingForNextSpawn *= 0.87f;
            mechaButton.gameObject.SetActive(false);
            theCountdownMechaBonus = 11;
        }

        if (secondPhysicsLevelStart.mechaBonus && theCountdownMechaBonus > 0)
        {
            mechaText.text = theCountdownMechaBonus.ToString("0") + "s";
        }
    }

    void SpawnRocks()
    {
        int result = Random.Range(0, 3);                //losujemy miejsce w tablicy wyloswanych kolców

        GameObject newSpikes = (GameObject)Instantiate
            (theRock[result], new Vector3(player.transform.position.x + xSpawn, Random.Range(yMin, yMax), 10), Quaternion.identity);

        newSpikes.tag = "Enemy";
    }
}

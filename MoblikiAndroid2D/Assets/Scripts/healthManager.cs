using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class healthManager : MonoBehaviour
{
    public Button life1;
    public Button life2;
    public Button life3;

    public Text bonusText;

    private bool life1Flag;
    private bool life2Flag;
    private bool life3Flag;

    private int hitCounter = 0;
    public GameObject shield;

    void Start()
    {
        if (scoreCounter.level == 3)
        {
            life1.gameObject.SetActive(true);
            life2.gameObject.SetActive(true);
            life3.gameObject.SetActive(true);
    
            life1Flag = true;
            life2Flag = true;
            life3Flag = true;
        }
    }

    void Update()
    {
        if (scoreCounter.level == 3)
        {
            if (hitRock.numberOfHits == 1 && life3Flag)
            {
                if (bonusScript.isPlayerProtected == false)
                {
                    life3.gameObject.SetActive(false);
                    life3Flag = false;
                } else
                {
                    hitRock.numberOfHits = 0;
                    hitCounter += 1;
                    if (hitCounter == 2)
                    {
                        bonusScript.isPlayerProtected = false;
                    }
                    if (hitCounter == 3)
                    {
                        hitRock.numberOfHits = 1;
                    }
                }
            } 
            else if(hitRock.numberOfHits == 2 && life2Flag)
            {
                life2.gameObject.SetActive(false);
                life2Flag = false;
            }
            else if (hitRock.numberOfHits == 3 && life1Flag)
            {
                life1.gameObject.SetActive(false);
                life1Flag = false;
            }
            else if (hitRock.numberOfHits == 4)
            {
                scoreCounter.points = Mathf.Round(scoreCounter.points * 100f) / 100f;
                bonusText.text = "";
                SceneManager.LoadScene("endScreen");
            }
        }
    }
}

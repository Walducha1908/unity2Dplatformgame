using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D rb;
    public Camera mainCamera;
    public static float jumpPower = 7;
    public float speed;

    private bool hidden;
    private int normalPosBlock; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hidden = false;                             // flaga określająca to czy gracz jest zmniejszony czy też nie
        normalPosBlock = 0;                         // licznik opóźnienia zeby po zwiekszeniu postaci ona nie skakała od razu
    }

    void Update()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);

        if (Swiping.swipingDown && !hidden)
        {
            player.transform.localScale /= 2f;
            hidden = true;
        }
        else if (!hidden && normalPosBlock == 0)
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Ended && player.transform.position.y < -7.67f)
                    rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            }
        }
        else if (Swiping.swipingUp && hidden)
        {
            player.transform.localScale *= 2f;
            hidden = false;
            normalPosBlock++;
        }

        if (normalPosBlock > 0 && normalPosBlock < 5)
        {
            normalPosBlock++;
        }
        else if (normalPosBlock == 5)
        {
            normalPosBlock = 0;
        }
    }
}

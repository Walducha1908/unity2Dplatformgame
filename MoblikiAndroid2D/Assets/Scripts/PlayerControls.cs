using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D rb;
    public Camera mainCamera;
    public float jumpPower;

    public bool hidden;
    private int i = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hidden = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (player.transform.position.y < -7.67f)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            }
        }

        foreach (Touch touch in Input.touches)
        {
            if (player.transform.position.y < -7.67f)
                rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }

        if (Swiping.swipingDown)
        {
            player.transform.localScale /= 2f;
            hidden = true;
        }

        if (hidden)
        {
            i++;
        }

        if (i > 50)
        {
            i = 0;
            player.transform.localScale *= 2f;
            hidden = false;
        }
    }
}

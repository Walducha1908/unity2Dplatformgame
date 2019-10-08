using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D rb;
    public float jumpPower;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (player.transform.position.y < -7.48f)
                rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }

        foreach (Touch touch in Input.touches)
        {
            if (player.transform.position.y < -7.48f)
                rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }
    }
}

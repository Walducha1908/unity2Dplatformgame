using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveWorld : MonoBehaviour
{
    void Update()
    {
        this.transform.position = new Vector2(this.transform.position.x + 0.1f, this.transform.position.y);
    }
}

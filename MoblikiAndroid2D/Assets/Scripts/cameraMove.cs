using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour
{
    public GameObject player;

    private Camera myCamera;
    private float lastPlayerPosition;

    void Start()
    {
        myCamera = this.GetComponent<Camera>();
        lastPlayerPosition = player.transform.position.x;
    }

    void LateUpdate()
    {

        float move = lastPlayerPosition + 6.1f;
        myCamera.transform.position = new Vector3(move, 
                                                  myCamera.transform.position.y, myCamera.transform.position.z);
        lastPlayerPosition = player.transform.position.x;
    }
}

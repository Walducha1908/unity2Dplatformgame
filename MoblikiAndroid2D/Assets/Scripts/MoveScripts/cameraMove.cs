using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour
{
    public GameObject player;
    public GameObject bg;
    public GameObject mountains;
    public GameObject background;
    public float parralaxMountains;
    public float parralaxBackground;

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
        float moveMountains = (myCamera.transform.position.x * parralaxMountains);
        float moveBackground = (myCamera.transform.position.x * parralaxBackground);

        mountains.transform.position = new Vector3(moveMountains, mountains.transform.position.y, mountains.transform.position.z);
        background.transform.position = new Vector3(moveBackground, background.transform.position.y, background.transform.position.z);

        //if (myCamera.transform.position.x - bg.transform.position.x < 4.6f)
        {
            myCamera.transform.position = new Vector3(move, myCamera.transform.position.y, myCamera.transform.position.z);
            lastPlayerPosition = player.transform.position.x;
        }
    }
}

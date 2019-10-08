using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour
{
    public GameObject player;

    private Camera myCamera;
    private Vector3 lastPlayerPosition;

    void Start()
    {
        myCamera = this.GetComponent<Camera>();
        lastPlayerPosition = player.transform.position;
    }

    void LateUpdate()
    {

        Vector3 move = (lastPlayerPosition - player.transform.position);
        Debug.Log(move);
        myCamera.transform.position = myCamera.transform.position - move;
        lastPlayerPosition = player.transform.position;
    }
}

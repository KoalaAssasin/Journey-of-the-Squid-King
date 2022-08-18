using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_movement : MonoBehaviour
{
    public GameObject player;
    public Camera mainCamera;

    public bool playerAlive = true;
    bool cameraReset = false;

    Vector2 cameraToPlayer = new Vector2();

    float cameraMoveCD = 4.1f;

    // Update is called once per frame
    void Update()
    {
        if (!playerAlive && cameraMoveCD > 0)
        {
            cameraMoveCD -= Time.deltaTime;

            cameraToPlayer = player.transform.position - transform.position;

            transform.position += new Vector3(Time.deltaTime * cameraToPlayer.x, Time.deltaTime * cameraToPlayer.y);

            if (mainCamera.orthographicSize > 5)
                mainCamera.orthographicSize -= Time.deltaTime;
        }
        else if (cameraMoveCD < 0 && !cameraReset)
        {
            transform.position = new Vector3(0, 0, -10);
            mainCamera.orthographicSize = 10;

            cameraReset = true;
        }
    }
}

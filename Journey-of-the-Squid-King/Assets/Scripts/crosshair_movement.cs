using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crosshair_movement : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // mouse stuff from screen to game world
        Vector2 mousePosInScreenCoords = Input.mousePosition;
        Vector3 mousePosInWorldCoords = Camera.main.ScreenToWorldPoint(mousePosInScreenCoords);
        mousePosInWorldCoords.z = 0.0f;

        transform.position = mousePosInWorldCoords;
    }
}

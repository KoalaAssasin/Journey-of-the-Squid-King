using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crosshair_movement : MonoBehaviour
{
    float crosshairRotation = 0;

    // Update is called once per frame
    void Update()
    {
        // mouse stuff from screen to game world
        Vector2 mousePosInScreenCoords = Input.mousePosition;
        Vector3 mousePosInWorldCoords = Camera.main.ScreenToWorldPoint(mousePosInScreenCoords);
        mousePosInWorldCoords.z = 0.0f;

        transform.position = mousePosInWorldCoords;

        crosshairRotation += Time.deltaTime * 10;
        transform.rotation = Quaternion.Euler(0, 0, crosshairRotation);
    }
}

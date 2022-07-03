using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform_movement : MonoBehaviour
{
    float minX = -5.9f;
    float maxX = 5.9f;

    float bottomOfArena = -10.0f;

    float minY = 10.0f;
    float maxY = 15.0f;

    float platformSpeed = 0.0f;
    Vector3 platformDirection = new Vector2(0, -1);

    // Update is called once per frame
    void Update()
    {
        platformDirection.Normalize();
        transform.position += platformDirection * platformSpeed * Time.deltaTime;

        if (transform.position.y < bottomOfArena)
        {
            transform.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        }
    }
}

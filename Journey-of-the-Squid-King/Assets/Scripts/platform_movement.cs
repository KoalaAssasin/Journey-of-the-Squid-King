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

    public float platformSpeed = 1.0f;
    Vector3 platformDirection = new Vector2(0, -1);

    GameObject Player;

    private void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        platformDirection.Normalize();
        transform.position += platformDirection * platformSpeed * Time.deltaTime;

        if (transform.position.y < bottomOfArena)
        {
            transform.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        }

        // Allows jump UP through the platforms
        if (Player.transform.position.y - 0.6f > this.transform.position.y)
        {
            GetComponent<BoxCollider2D>().enabled = true;
        }
        else if (Player.transform.position.y < this.transform.position.y)
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}

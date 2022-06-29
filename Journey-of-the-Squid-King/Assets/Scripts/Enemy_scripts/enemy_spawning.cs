using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_spawning : MonoBehaviour
{
    public GameObject Enemy;
    float spawnTimer = 0.0f;
    public float spawnDelay = 5.0f;

    void Update()
    {
        if (spawnTimer > spawnDelay)
        {
            Instantiate(Enemy, transform.position, transform.rotation);
            spawnTimer = 0.0f;
            spawnDelay -= 0.1f;
        }

        spawnTimer += Time.deltaTime;
    }
}

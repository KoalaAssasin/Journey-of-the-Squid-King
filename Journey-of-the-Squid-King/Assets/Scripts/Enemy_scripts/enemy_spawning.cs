using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_spawning : MonoBehaviour
{
    public GameObject Enemy;
    float spawnTimer = 0.0f;
    public float spawnDelay = 9.0f;

    int rnd;

    void Update()
    {
        if (spawnTimer > spawnDelay)
        {
            rnd = Random.Range(1, 10);

            if (rnd < 6)
            {
                Instantiate(Enemy, transform.position, transform.rotation);
                spawnTimer = 0.0f;
            }
            else
            {
                spawnTimer = 1.3f;
            }

            if (spawnDelay > 3.0f)
            {
                spawnDelay -= 0.1f;
            }
        }

        spawnTimer += Time.deltaTime;
    }
}

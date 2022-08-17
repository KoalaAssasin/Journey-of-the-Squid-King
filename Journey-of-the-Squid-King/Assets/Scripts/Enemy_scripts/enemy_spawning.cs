using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_spawning : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject FastEnemy;
    public GameObject TankEnemy;
    float spawnTimer = 4.0f;
    float gameTime = 0.0f;
    public float spawnDelay = 6.5f;

    int rnd;

    void Update()
    {
        gameTime += Time.deltaTime;

        if (spawnTimer > spawnDelay)
        {
            if (gameTime > 60.0f) // can spawn basic, fast and heavy enemies
            {
                rnd = Random.Range(1, 10);
                if (rnd < 8 && rnd > 4) // spawn basic on a 5 - 7
                {
                    Instantiate(Enemy, transform.position, transform.rotation);
                    spawnTimer = 0.0f;

                    if (spawnDelay > 3.0f)
                    {
                        spawnDelay -= 0.1f;
                    }
                }
                else if (rnd < 5 && rnd > 2) // spawn fast on a 3 or 4
                {
                    Instantiate(FastEnemy, transform.position, transform.rotation);
                    spawnTimer = 0.0f;

                    if (spawnDelay > 3.0f)
                    {
                        spawnDelay -= 0.1f;
                    }

                }
                else if (rnd < 3) // spawn tank on a 1 or 2
                {
                    Instantiate(TankEnemy, transform.position, transform.rotation);
                    spawnTimer = 0.0f;

                    if (spawnDelay > 3.0f) // when a tank enemy spawns the spawn delay is increased instead of decreased
                    {
                        spawnDelay += 0.1f;
                    }

                }
                else
                {
                    spawnTimer = 1.3f;
                }
            }
            else if (gameTime > 30.0f) // can spawn basic and fast enemies
            {
                rnd = Random.Range(1, 10);
                if (rnd < 8 && rnd > 2) // spawn basic on a 3 - 7
                {
                    Instantiate(Enemy, transform.position, transform.rotation);
                    spawnTimer = 0.0f;

                    if (spawnDelay > 3.0f)
                    {
                        spawnDelay -= 0.1f;
                    }
                }
                else if (rnd < 3) // spawn fast on a 1 or 2
                {
                    Instantiate(FastEnemy, transform.position, transform.rotation);
                    spawnTimer = 0.0f;

                    if (spawnDelay > 3.0f) // when a fast enemy spawns the spawn delay is increased instead of decreased
                    {
                        spawnDelay += 0.1f;
                    }
                }
                else
                {
                    spawnTimer = 1.2f;
                }
            }
            else // can only spawn basic enemies
            {
                rnd = Random.Range(1, 10);

                if (rnd < 7)
                {
                    Instantiate(Enemy, transform.position, transform.rotation);
                    spawnTimer = 0.0f;

                    if (spawnDelay > 3.0f)
                    {
                        spawnDelay -= 0.1f;
                    }
                }
                else
                {
                    spawnTimer = 1.0f;
                }

            }
        }

        spawnTimer += Time.deltaTime;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scene_transition_SM : MonoBehaviour
{
    public bool playerAlive = true;

    float playerHasSpawnedCD = 0.5f;
    float playerHasDiedCD = 3.0f;

    // Update is called once per frame
    void Update()
    {
        if (playerAlive && playerHasSpawnedCD > 0)
        {
            playerHasSpawnedCD -= Time.deltaTime;
        }
        else if (playerAlive && playerHasSpawnedCD < 0 && transform.localScale.x < 50)
        {
            transform.localScale += new Vector3(Time.deltaTime * 50, Time.deltaTime * 50, 0);
        }
        else if (!playerAlive && playerHasDiedCD > 0)
        {
            playerHasDiedCD -= Time.deltaTime;
        }
        else if (!playerAlive && playerHasDiedCD < 0 && transform.localScale.x > 0.1f)
        {
            transform.localScale -= new Vector3(Time.deltaTime * 50, Time.deltaTime * 50, 0);
        }
    }
}

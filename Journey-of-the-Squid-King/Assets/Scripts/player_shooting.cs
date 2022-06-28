using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_shooting : MonoBehaviour
{
    public GameObject crosshair;
    public GameObject bullet;

    public Vector3 vectorToCrosshair = new Vector3();

    float fireRate = 0.5f;
    float shootTimer = 0;

    // Update is called once per frame
    void Update()
    {
        vectorToCrosshair = crosshair.transform.position - transform.position;

        shootTimer += Time.deltaTime;
        
        if (shootTimer > fireRate)
        {
            Instantiate(bullet, transform.position, transform.rotation);
            shootTimer = 0.0f;
        }
    }
}

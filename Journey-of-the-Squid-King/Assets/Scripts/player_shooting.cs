using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_shooting : MonoBehaviour
{
    public GameObject crosshair;
    public GameObject bullet;
    GameObject prefab;

    public Vector3 vectorToCrosshair = new Vector3();

    float fireRate = 0.47f; // was previously 0.5f
    float shootTimer = 0;

    // Update is called once per frame
    void Update()
    {
        vectorToCrosshair = crosshair.transform.position - transform.position;

        shootTimer += Time.deltaTime;
        
        if (shootTimer > fireRate)
        {
            prefab = Instantiate(bullet, transform.position, transform.rotation);
            //to be able to render the trail renderer, set the z to -1 to layer over other elements
            prefab.transform.position = new Vector3(prefab.transform.position.x, prefab.transform.position.y, -1);
            shootTimer = 0.0f;
        }
    }
}

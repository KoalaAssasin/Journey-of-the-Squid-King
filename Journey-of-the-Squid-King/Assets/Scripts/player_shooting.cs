using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_shooting : MonoBehaviour
{
    public GameObject crosshair;
    public GameObject bullet;

    public Vector3 vectorToCrosshair = new Vector3();

    float fireRate = 0.47f; // was previously 0.5f
    float shootTimer = 0;

    public ParticleSystem particleShoot;

    // Update is called once per frame
    void Update()
    {
        vectorToCrosshair = crosshair.transform.position - transform.position;

        shootTimer += Time.deltaTime;
        
        if (shootTimer > fireRate)
        {
            Instantiate(bullet, transform.position, transform.rotation);
            // Insert some way to shoot particles in the direction of vectortoCrosshair
            particleShoot.transform.rotation = Quaternion.Euler(vectorToCrosshair.x, vectorToCrosshair.y, vectorToCrosshair.z - 90);
            particleShoot.Play();
            shootTimer = 0.0f;
        }
    }
}

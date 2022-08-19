using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_behaviour : MonoBehaviour
{
    Vector3 travelDirection;

    float bulletSpeed = 0.035f; // was previously 0.03f

    float bulletLifetime = 2.0f;

    public ParticleSystem bulletPS;
    public GameObject bulletHitEnemy;
    public GameObject bulletHitWall;

    public AudioSource enemyHit;

    // Start is called before the first frame update
    void Awake()
    {
        travelDirection = FindObjectOfType<player_shooting>().vectorToCrosshair;
        travelDirection.Normalize();
        travelDirection *= bulletSpeed;
        transform.position += travelDirection;

        bulletPS.Play();
    }

    // Update is called once per frame
    void Update()
    {
        bulletPS.Play();

        transform.position += travelDirection;
        bulletLifetime -= Time.deltaTime;
        if (bulletLifetime < 0) Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Instantiate(bulletHitEnemy, this.transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "BottomWall")
        {
            Instantiate(bulletHitWall, this.transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }
}

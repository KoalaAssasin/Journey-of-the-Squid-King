using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_behaviour : MonoBehaviour
{
    Vector3 travelDirection;

    float bulletSpeed = 0.03f;

    float bulletLifetime = 2.0f;

    // Start is called before the first frame update
    void Awake()
    {
        travelDirection = FindObjectOfType<player_shooting>().vectorToCrosshair;
        travelDirection.Normalize();
        travelDirection *= bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += travelDirection;
        bulletLifetime -= Time.deltaTime;
        if (bulletLifetime < 0) Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tank_enemy_movement : MonoBehaviour
{
    private GameObject wayPoint;
    private GameObject bullet;
    private Vector3 wayPointPos;
    //This will be the enemy's speed. Adjust as necessary.
    public float enemySpeed = 1.0f;
    private int health = 9;
    float oldPosition;

    public ParticleSystem hitPS;
    public ParticleSystem deathPS;
    public GameObject screenFlash;

    void Start()
    {
        //When spawned, enemies will find the gameobject called wayPoint.
        wayPoint = GameObject.Find("Waypoint");
    }

    void Update()
    {
        if(oldPosition < transform.position.x) //Sprite rotator
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        oldPosition = transform.position.x;

        wayPointPos = new Vector3(wayPoint.transform.position.x, wayPoint.transform.position.y, wayPoint.transform.position.z);
        //Here the enemies will follow the waypoint.
        transform.position = Vector3.MoveTowards(transform.position, wayPointPos, enemySpeed * Time.deltaTime);


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If hit by a bullet, remove 1 HP
        if (collision.gameObject.tag == "Bullet")
        {
            health -= 1;
            //Darkening as health is lost
            if (health == 6)
                GetComponent<SpriteRenderer>().color -= new Color(0.0f, 0.33f, 0.33f, 0.0f);
            else if (health == 3)
                GetComponent<SpriteRenderer>().color -= new Color(0.0f, 0.33f, 0.33f, 0.0f);

            hitPS.Play();

            // If HP hits 0, add 1 to score and destroy this enemy
            if (health == 0)
            {
                deathPS.Play();
                Instantiate(screenFlash, transform.position, transform.rotation);

                FindObjectOfType<score_manager>().currentScore += 1;
                StartCoroutine(FindObjectOfType<Animation_reel>().PlayClip());

                Destroy(this.gameObject);
            }
        }
    }

}
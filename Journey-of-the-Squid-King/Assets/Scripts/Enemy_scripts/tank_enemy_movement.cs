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
    private int health = 12;
    void Start()
    {
        //When spawned, enemies will find the gameobject called wayPoint.
        wayPoint = GameObject.Find("Waypoint");
    }

    void Update()
    {
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
            // If HP hits 0, add 1 to score and destroy this enemy
            if (health == 0)
            {
                FindObjectOfType<score_manager>().currentScore += 1;
                Destroy(this.gameObject);
            }
        }
    }

}
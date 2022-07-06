using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waypoint : MonoBehaviour
{
    public GameObject wayPoint;
    //This is how often your waypoint's position will update to the player's position
    //private float timer = 0.5f;

    Vector3 waypointToPlayer = new Vector3();
    float waypointSpeed = 2.0f;

    void Update()
    {
        //if (timer > 0)
        //{
        //    timer -= Time.deltaTime;
        //}
        //if (timer <= 0)
        //{
        //    //The position of the waypoint will update to the player's position
        //    UpdatePosition();
        //    timer = 0.5f;
        //}

        //waypointToPlayer = transform.position - wayPoint.transform.position;
        //waypointToPlayer.Normalize();
        //wayPoint.transform.position += waypointToPlayer * waypointSpeed * Time.deltaTime;

        wayPoint.transform.position = transform.position;
    }

    //void UpdatePosition()
    //{
    //    //The wayPoint's position will now be the player's current position.
    //    wayPoint.transform.position = transform.position;
    //}
}

//This code was referenced from https://answers.unity.com/questions/750933/make-a-gameobject-follow-player-footsteps.html
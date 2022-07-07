using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_health : MonoBehaviour
{
    public int playerHP = 3;
    float baseInvulTimer = 2.1f;
    float invulTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (invulTimer > 0.1f) invulTimer -= Time.deltaTime;
        else if (invulTimer < 0.1f && invulTimer > 0) GetComponent<SpriteRenderer>().color = Color.white;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && invulTimer < 0.1f)
        {
            invulTimer = baseInvulTimer;
            GetComponent<SpriteRenderer>().color = Color.green;
            --playerHP;
        }
    }
}

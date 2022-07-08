using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_health : MonoBehaviour
{
    public int playerHP = 3;
    float baseInvulTimer = 2.1f;
    float invulTimer = 0;

    public bool isPlayerAlive = true;

    public Text healthText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (invulTimer > 0.1f) invulTimer -= Time.deltaTime;
        //else if (invulTimer < 0.1f && invulTimer > 0) GetComponent<SpriteRenderer>().color = Color.white;

        if (playerHP <= 0)
        {
            isPlayerAlive = false;
            GetComponent<player_movement>().enabled = false;
            GetComponent<player_shooting>().enabled = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && invulTimer < 0.1f)
        {
            invulTimer = baseInvulTimer;
            //GetComponent<SpriteRenderer>().color = Color.green;
            --playerHP;

            healthText.text = playerHP.ToString();
        }
    }
}

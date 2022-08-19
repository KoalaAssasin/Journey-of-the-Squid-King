using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_health : MonoBehaviour
{
    public int playerHP = 3;
    float baseInvulTimer = 2.1f;
    float invulTimer = -1;

    public bool isPlayerAlive = true;

    public Text healthText;

    public Animator animator;

    public GameObject sceneSpriteMask;
    public GameObject hitEdgeEffect;
    public GameObject cameraParent;
    public GameObject uiGameOver;
    //public camera_shake cameraShake;

    public ParticleSystem deadPS;

    public AudioSource playerHit;
    public AudioSource playerDeath;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (invulTimer > 0) invulTimer -= Time.deltaTime;
        //else if (invulTimer < 0.1f && invulTimer > 0) GetComponent<SpriteRenderer>().color = Color.white;

        if (playerHP <= 0)
        {
            isPlayerAlive = false;
            animator.SetBool("isPlayerDead", true);
            GetComponent<player_movement>().enabled = false;
            GetComponent<player_shooting>().enabled = false;

            deadPS.Play();

            uiGameOver.SetActive(true);
            sceneSpriteMask.GetComponent<scene_transition_SM>().playerAlive = false;
            cameraParent.GetComponent<camera_movement>().playerAlive = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && invulTimer < 0)
        {
            invulTimer = baseInvulTimer;
            //GetComponent<SpriteRenderer>().color = Color.green;
            --playerHP;
            //Removing health icons
            HealthMonitor.HealthValue -= 1;

            healthText.text = playerHP.ToString();

            Instantiate(hitEdgeEffect, transform.position, transform.rotation);

            if (playerHP > 0)
                playerHit.Play();
            else
                playerDeath.Play();


            //shake camera at duration of .15 and magnitude of .4
            //make sure to start the couroutine
            //StartCoroutine(cameraShake.Shake(.15f, .2f));
            StartCoroutine(cameraParent.GetComponent<camera_shake>().Shake(0.15f, 0.2f));
        }
        if (collision.gameObject.tag == "BottomWall" && invulTimer < 0)
        {
            invulTimer = baseInvulTimer;
            //GetComponent<SpriteRenderer>().color = Color.green;
            --playerHP;
            //Removing health icons
            HealthMonitor.HealthValue -= 1;

            healthText.text = playerHP.ToString();

            Instantiate(hitEdgeEffect, transform.position, transform.rotation);

            if (playerHP > 0)
                playerHit.Play();
            else
                playerDeath.Play();

            //StartCoroutine(cameraShake.Shake(.15f, .2f));
            StartCoroutine(cameraParent.GetComponent<camera_shake>().Shake(0.15f, 0.2f));
        }
    }
}

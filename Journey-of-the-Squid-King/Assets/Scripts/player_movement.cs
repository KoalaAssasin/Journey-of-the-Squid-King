using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    Rigidbody2D rigidBody;

    Vector2 playerJump = new Vector2();
    Vector3 playerVelocity = new Vector3();
    Vector3 playerDown = new Vector3(0, -1);

    float playerJumpCharge = 0.3f;
    float playerAirControl = 1.5f;

    public bool isOnPlatform = false;
    public bool groundSlamActive = false;

    public Animator animator;
    public ParticleSystem particleLand;

    public AudioSource jump;
    public AudioSource jumpCharged;
    public AudioSource landing;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Jump charge controls - On a platform
        if (Input.GetKey(KeyCode.W) && playerJumpCharge < 1.0f && isOnPlatform) // W held increases jump power (While on a platform)
        {
            playerJumpCharge += Time.deltaTime;
            animator.SetBool("Charging", true);
        }
        else if (!Input.GetKey(KeyCode.W) && playerJumpCharge > 0.3f) // W not held decreases jump power twice as fast
        {
            playerJumpCharge -= Time.deltaTime * 2;
            animator.SetBool("Charging", false);
        }

        // Jump Controls - On a platform
        if (Input.GetKeyUp(KeyCode.W) && (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)) && isOnPlatform) // Up - W
        {
            playerJump = new Vector2(0, 1);
            this.transform.parent = null;
            animator.SetBool("Jumping", true);
            Landing();

            if (playerJumpCharge > 0.9f)
                jumpCharged.Play();

            jump.Play();
        }
        else if (Input.GetKeyUp(KeyCode.W) && Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && isOnPlatform) // Left - W + A
        {
            playerJump = new Vector2(-0.2f, 1);
            this.transform.parent = null;
            animator.SetBool("Jumping", true);
            Landing();

            if (playerJumpCharge > 0.9f)
                jumpCharged.Play();

            jump.Play();
        }
        else if (Input.GetKeyUp(KeyCode.W) && Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A) && isOnPlatform) // Right - W + D
        {
            playerJump = new Vector2(0.2f, 1);
            this.transform.parent = null;
            animator.SetBool("Jumping", true);
            Landing();

            if (playerJumpCharge > 0.9f)
                jumpCharged.Play();

            jump.Play();
        }

        // In air controls - Not on a platform
        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && !isOnPlatform)
        {
            playerJump = new Vector2(-1.0f, 0);
        }
        else if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A) && !isOnPlatform)
        {
            playerJump = new Vector2(1.0f, 0);
        }

        // Ground Pound/ Slam thing - S pressed while in the air, only allowed once per airborne
        // First impulse stops vertical velocity, second impulse blasts downwards
        if (Input.GetKey(KeyCode.S) && !isOnPlatform && !groundSlamActive)
        {
            playerVelocity = rigidBody.velocity * playerDown;
            rigidBody.AddForce(playerVelocity, ForceMode2D.Impulse);

            playerVelocity = 10 * playerDown;
            rigidBody.AddForce(playerVelocity, ForceMode2D.Impulse);
            groundSlamActive = true;
        }

        playerVelocity = playerJump;
        playerVelocity.Normalize();

        if (isOnPlatform) // Jump handling - while on a platform
        {
            playerVelocity *= (16 * playerJumpCharge);
            rigidBody.AddForce(playerVelocity, ForceMode2D.Impulse);
            groundSlamActive = false;
        }
        else // Air control - while not on a platform
        {
            playerVelocity *= playerAirControl;
            rigidBody.AddForce(playerVelocity, ForceMode2D.Force);
        }


        if (!isOnPlatform)
            playerJumpCharge = 0.3f; 

        playerJump = Vector2.zero;

        // If they player is at the bottom of the screen, moves them up to a higher position on the same X
        if (transform.position.y < -7.9f)
        {
            // nothing
        }

        //Animation falling tester
        if (rigidBody.velocity.y < -0.5f)
        {
            animator.SetBool("Jumping", false);
            animator.SetBool("Falling", true);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            Landing();

            isOnPlatform = true;
            //rigidBody.drag = 5.0f;
            this.transform.SetParent(collision.transform);
            animator.SetBool("Falling", false);

            
        }
        if (collision.gameObject.tag == "BottomWall")
        {
            transform.position = new Vector2(transform.position.x, 0.0f);
            Landing();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Platform")
        {
            isOnPlatform = false;
            this.transform.parent = null;
        }
        //rigidBody.drag = 0.5f;
    }

    public void Landing()
    {
        particleLand.Play();

        if (!isOnPlatform)
            landing.Play();
    }
}

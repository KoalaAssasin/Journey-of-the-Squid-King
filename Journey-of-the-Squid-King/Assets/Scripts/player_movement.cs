using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    Rigidbody2D rigidBody;

    Vector2 playerJump = new Vector2();
    Vector3 playerVelocity = new Vector3();

    float playerJumpCharge = 0.3f;
    public float playerAirControl = 0.5f;

    bool isOnPlatform = false;

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
        }
        else if (!Input.GetKey(KeyCode.W) && playerJumpCharge > 0.3f) // W not held decreases jump power twice as fast
        {
            playerJumpCharge -= Time.deltaTime * 2;
        }

        // Jump Controls - On a platform
        if (Input.GetKeyUp(KeyCode.W) && (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)) && isOnPlatform) // Up - W
        {
            playerJump = new Vector2(0, 1);
        }
        else if (Input.GetKeyUp(KeyCode.W) && Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && isOnPlatform) // Left - W + A
        {
            playerJump = new Vector2(-0.2f, 1);
        }
        else if (Input.GetKeyUp(KeyCode.W) && Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A) && isOnPlatform) // Right - W + D
        {
            playerJump = new Vector2(0.2f, 1);
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

        playerVelocity = playerJump;
        playerVelocity.Normalize();

        if (isOnPlatform) // Jump handling - while on a platform
        {
            playerVelocity *= (playerJumpCharge * 10);
            rigidBody.AddForce(playerVelocity, ForceMode2D.Impulse);
        }
        else // Air control - while not on a platform
        {
            playerVelocity *= playerAirControl;
            rigidBody.AddForce(playerVelocity, ForceMode2D.Force);
        }


        if (!isOnPlatform) playerJumpCharge = 0.3f;
        playerJump = Vector2.zero;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform") isOnPlatform = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isOnPlatform = false;
    }
}

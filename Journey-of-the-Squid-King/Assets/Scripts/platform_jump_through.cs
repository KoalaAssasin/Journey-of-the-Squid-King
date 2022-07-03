using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform_jump_through : MonoBehaviour
{
    public GameObject platform;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            platform.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            platform.GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
        }
        else if (collision.gameObject.tag != "Player")
        {
            platform.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}

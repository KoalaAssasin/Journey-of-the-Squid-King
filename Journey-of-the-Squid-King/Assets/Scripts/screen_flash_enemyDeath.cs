using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screen_flash_enemyDeath : MonoBehaviour
{
    float screenLifeTime = 0.2f;

    SpriteRenderer spriteRenderer;

    Color colorSR;

    // Start is called before the first frame update
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        colorSR = new Color(0, 0, 0, Time.deltaTime);
        spriteRenderer.color -= colorSR;

        screenLifeTime -= Time.deltaTime;
        if (screenLifeTime < 0) Destroy(this.gameObject);
    }
}

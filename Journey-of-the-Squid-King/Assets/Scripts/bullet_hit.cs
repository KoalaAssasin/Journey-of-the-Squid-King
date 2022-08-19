using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_hit : MonoBehaviour
{
    float effectLifeTime = 0.1f;

    float rotAngle = 0;

    public AudioSource objHit;

    // Start is called before the first frame update
    void Awake()
    {
        objHit.Play();
    }

    // Update is called once per frame
    void Update()
    {
        rotAngle += 300 * Time.deltaTime;

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, -rotAngle));

        effectLifeTime -= Time.deltaTime;
        if (effectLifeTime < 0) Destroy(this.gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class edge_screen_behaviour : MonoBehaviour
{
    float screenLifeTime = 0.2f;

    // Start is called before the first frame update
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Sin(Time.deltaTime), Mathf.Sin(Time.deltaTime) * -1, 0);

        screenLifeTime -= Time.deltaTime;
        if (screenLifeTime < 0) Destroy(this.gameObject);
    }
}

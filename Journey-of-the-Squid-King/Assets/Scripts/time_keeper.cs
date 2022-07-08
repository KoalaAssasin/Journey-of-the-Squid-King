using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class time_keeper : MonoBehaviour
{
    float time = 0;
    int displayedTime = 0;

    public Text timeText;
    public GameObject Player;

    // Update is called once per frame
    void Update()
    {
        if (Player.GetComponent<player_health>().isPlayerAlive) time += Time.deltaTime;

        displayedTime = (int)time;

        timeText.text = displayedTime.ToString();
    }
}

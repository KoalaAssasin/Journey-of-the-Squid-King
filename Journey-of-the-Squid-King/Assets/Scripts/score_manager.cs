using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score_manager : MonoBehaviour
{
    public int currentScore = 0;

    public Text scoreText;

    void Update()
    {
        scoreText.text = currentScore.ToString();
    }
}

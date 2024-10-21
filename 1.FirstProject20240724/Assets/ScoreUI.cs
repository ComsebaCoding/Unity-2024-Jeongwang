using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    public Text scoreLabel;
    // Update is called once per frame
    void Update()
    {
        scoreLabel.text = 
            "SCORE :" + GameManager.score.ToString("D4"); 
    }
}
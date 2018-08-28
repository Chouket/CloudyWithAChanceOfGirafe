using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseScorePrint : MonoBehaviour
{
    public Text currScore;
    public Text currHighScore;

    // Use this for initialization
    void Start()
    {
        ScoreManager scoreMgr = GameObject.FindObjectOfType<ScoreManager>();

        currScore.text = scoreMgr.scoreValue.ToString();
        currHighScore.text = scoreMgr.GetHighScore().ToString();
    }
}

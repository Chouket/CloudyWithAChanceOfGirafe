using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text currScore;
    public Text m_highScore;

    public int scoreValue = 0;

    public void Start()
    {
        m_highScore.text = GetHighScore().ToString();
    }

    public void UpdateScore(int currScoreValue)
    {
        if (currScoreValue > int.Parse(currScore.text))
        {
            currScore.text = currScoreValue.ToString();
            scoreValue = currScoreValue;
        }
    }

    public bool UpdateHighScore()
    {
        int highScore = GetHighScore();

        Debug.Log(highScore);

        bool result = false;
        if (scoreValue > highScore)
        {
            result = true;
            PlayerPrefs.SetInt("HighScore", scoreValue);
            PlayerPrefs.Save();
            m_highScore.text = scoreValue.ToString();
        }

        return result;
    }

    public int GetHighScore()
    {
        return PlayerPrefs.GetInt("HighScore");
    }
}

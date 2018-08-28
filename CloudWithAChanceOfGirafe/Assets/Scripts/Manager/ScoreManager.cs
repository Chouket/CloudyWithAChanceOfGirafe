using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text currScore;
    public Text m_highScore;

    public void UpdateScore(int currScoreValue)
    {
        if (currScoreValue > int.Parse(currScore.text))
            currScore.text = currScoreValue.ToString();
    }

    public bool UpdateHighScore(int newScore)
    {
        int highScore = GetHighScore();

        bool result = false;
        if (newScore > highScore)
        {
            result = true;
            PlayerPrefs.SetInt("HighScore", newScore);
            m_highScore.text = newScore.ToString();
        }

        return result;
    }

    public int GetHighScore()
    {
        return PlayerPrefs.GetInt("HighScore");
    }
}

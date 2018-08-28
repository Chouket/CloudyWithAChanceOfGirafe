using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuHighScore : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        GetComponent<Text>().text = PlayerPrefs.GetInt("HighScore").ToString();
    }

}

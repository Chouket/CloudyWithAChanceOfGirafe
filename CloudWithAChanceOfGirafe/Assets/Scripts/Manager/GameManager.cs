using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager instance = null;
    public static GameManager Instance
    {
        get
        {
            if (!instance)
                instance = new GameManager();

            return instance;
        }
    }
    #endregion

    private void Awake()
    {
        if (instance && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadGameplayScene()
    {
        SceneManager.LoadScene("TestScene");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Lose()
    {
        InGameUIManager UiManager = GameObject.FindObjectOfType<InGameUIManager>();
        ScoreManager scoreMgr = GameObject.FindObjectOfType<ScoreManager>();
        scoreMgr.UpdateHighScore((int)GameObject.FindObjectOfType<PlayerMove>().gameObject.transform.position.y);

        if (UiManager)
            UiManager.LosingUI();
    }
}

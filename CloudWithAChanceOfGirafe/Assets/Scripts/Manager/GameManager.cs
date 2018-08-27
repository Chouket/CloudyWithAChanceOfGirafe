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
            Destroy(gameObject);
    }



    [SerializeField] string m_gameplaySceneName = "";

    public void Play()
    {
        SceneManager.LoadScene(m_gameplaySceneName);
    }

    public void Quit()
    {
        Application.Quit();
    }
}

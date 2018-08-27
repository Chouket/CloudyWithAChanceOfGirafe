using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUIManager : MonoBehaviour
{
    GameManager m_gameManager;
    [SerializeField] GameObject m_pausePanel;
    [SerializeField] GameObject m_losePanel;

    private void Start()
    {
        m_gameManager = GameManager.Instance;
    }

    public void Pause(bool active)
    {
        if (!m_pausePanel)
        {
            Debug.LogError("No Pause panel found ...");
            return;
        }

        Time.timeScale = (active ? 0f : 1f);
        m_pausePanel.SetActive(active);
    }

    public void PlayAgain()
    {
        Time.timeScale = 1f;
        m_gameManager.LoadGameplayScene();
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1f;
        m_gameManager.LoadMainMenuScene();
    }

    public void LosingUI()
    {
        Time.timeScale = 0f;
        m_losePanel.SetActive(true);
    }
}

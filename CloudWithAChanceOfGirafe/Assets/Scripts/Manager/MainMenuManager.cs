using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    GameManager m_gameManager;

    private void Start()
    {
        m_gameManager = GameManager.Instance;
    }

    public void PlayButtonPressed()
    {
		SoundManager.instance.PlayAudioClip("MenuButton");
		m_gameManager.LoadGameplayScene();
    }

    public void QuitButtonPressed()
    {
		SoundManager.instance.PlayAudioClip("MenuButton");
		m_gameManager.Quit();
    }
}

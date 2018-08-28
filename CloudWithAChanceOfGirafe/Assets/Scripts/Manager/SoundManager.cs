using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
	#region Singleton
	public static SoundManager instance = null;
	public static SoundManager Instance
	{
		get
		{
			if (!instance)
				instance = new SoundManager();

			return instance;
		}
	}
	#endregion

	[SerializeField]
	List<AudioClip> m_audioClips;

	[SerializeField]
	AudioSource m_soundtrack;
	[SerializeField]
	List<AudioSource> m_eventSounds;

	private void Awake()
	{
		if (instance && instance != this)
		{
			Destroy(gameObject);
			return;
		}

		instance = this;
		DontDestroyOnLoad(gameObject);

		m_soundtrack.clip = GetAudioClip("avantLOrage");
		m_soundtrack.loop = true;
		m_soundtrack.Play();
	}

	AudioClip GetAudioClip(string str)
	{
		foreach(AudioClip audio in m_audioClips)
		{
			if (audio.name == str)
				return audio;
		}
		return null;
	}

	public void PlayAudioClip(string str)
	{
		AudioClip clip = GetAudioClip(str);
		if (clip == null)
			return;

		foreach(AudioSource audio in m_eventSounds)
		{
			if (audio.isPlaying && audio.clip == clip)
				return;
			if(!audio.isPlaying)
			{
				audio.clip = clip;
				audio.Play();
				return;
			}
		}
	}
}

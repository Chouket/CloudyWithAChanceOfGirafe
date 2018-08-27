using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
	[SerializeField]
	List<List<GameObject>> m_objects;

	[SerializeField]
	GameObject m_spawnerGao;

	[SerializeField]
	float m_minTimeInterval = 1f;
	[SerializeField]
	float m_maxTimeInterval = 3f;

	float m_intervalStart = 0;

	float m_currentTime = 0;

	float m_spawnTime;

	Spawner m_spawner = null;

	void Start ()
	{
		m_spawner = m_spawnerGao.GetComponent<Spawner>();
	}
	
	void Update ()
	{
		m_currentTime += Time.deltaTime;
		
		if(m_currentTime >= m_intervalStart + m_spawnTime)
		{
			m_spawner.Spawn();
			m_spawnTime = Random.Range(m_minTimeInterval, m_maxTimeInterval);
			m_intervalStart = m_currentTime;
		}
	}
}

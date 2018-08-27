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
	int m_timeInterval = 10;

	[SerializeField]
	int m_spawnNumber = 3;

	float m_intervalStart = 0;

	float m_currentTime = 0;

	List<int> m_spawnTimes;

	Spawner m_spawner = null;

	private void Awake()
	{
		m_spawnTimes = new List<int>();
	}

	void Start ()
	{
		m_spawner = m_spawnerGao.GetComponent<Spawner>();
		RollSpawnTimes();
	}
	
	void Update ()
	{
		m_currentTime += Time.deltaTime;
		if (m_currentTime >= m_intervalStart + m_timeInterval)
		{
			RollSpawnTimes();
			m_intervalStart = m_currentTime;
		}

		int value = -1;
		foreach(int i in m_spawnTimes)
		{
			if (m_currentTime >= m_intervalStart + i)
			{
				m_spawner.Spawn();
				value = i;
				break;
			}
		}
		if (value != -1)
			m_spawnTimes.Remove(value);
	}

	void RollSpawnTimes()
	{
		for (int i = 0; i < m_spawnNumber; i++)
		{
			int time = Random.Range(0, m_timeInterval);

			while (m_spawnTimes.Contains(time))
			{
				time = Random.Range(0, m_timeInterval);
			}
			m_spawnTimes.Add(time);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    int m_spawnerOffsetY = 0;

	FallingObjectList m_objects;
	public FallingObjectList m_Objects
	{
		set { m_objects = value; }
	}

	[SerializeField]
	float m_minSize = 0.5f;

	[SerializeField]
	float m_maxSize = 1.5f;

	[SerializeField]
	float m_spawnWidth = 5f;

	Camera m_camera;
	int minus = 1;

    void Awake()
	{
		Vector3 pos = transform.localPosition;
        pos.y = m_spawnerOffsetY;
        transform.localPosition = pos;
    }

	void Start()
	{
		m_camera = Camera.main;
	}

	public void Spawn()
	{
		float size = Random.Range(m_minSize, m_maxSize);
		int rand = Random.Range(0, 100);
		int index = 0;
		float percent = 0;
		for (int i = 0; i < m_objects.m_fallingObjects.Count; i++)
		{
			if (rand < m_objects.m_fallingObjects[i].m_dropRate + percent)
			{
				index = i;
				break;
			}
			else
				percent += m_objects.m_fallingObjects[i].m_dropRate;
		}

		int rotate = Random.Range(0, 360);

		Vector3 scale = m_objects.m_fallingObjects[index].m_gameObject.transform.localScale;
		scale *= size;

		float posX = Random.Range((0 + size/2) * minus,(m_spawnWidth/2 * minus));
		minus *= -1;

		Vector3 pos = transform.position;
		pos.x = posX;
		pos.z = 0f;

		
		GameObject gao = Instantiate(m_objects.m_fallingObjects[index].m_gameObject, pos, Quaternion.Euler(0f,0f,rotate));

		if (m_objects.m_fallingObjects[index].m_resize)
		{
			gao.GetComponent<Rigidbody2D>().gravityScale = gao.GetComponent<Rigidbody2D>().gravityScale * size;
			gao.transform.localScale = scale;
		}
    }

	private void Update()
	{
		//if (Input.GetButtonDown("Fire1"))
		//{
		//	Spawn();
		//}
	}
}

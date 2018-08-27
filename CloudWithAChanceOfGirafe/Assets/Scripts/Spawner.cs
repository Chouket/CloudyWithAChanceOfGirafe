using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    int m_spawnerOffsetY = 0;

	[SerializeField]
	List<GameObject> m_objects;

	[SerializeField]
	float m_minSize = 0.5f;

	[SerializeField]
	float m_maxSize = 1.5f;

	[SerializeField]
	float m_spawnWidth = 5f;

	Camera m_camera;

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
		float size = Random.Range(m_minSize,m_maxSize);
		int rand = Random.Range(0, m_objects.Count);
		int rotate = Random.Range(0, 360);

		Vector3 scale = m_objects[rand].transform.localScale;
		scale *= size;

		int cameraSize = (int )(m_camera.orthographicSize - scale.x/2);
		float posX = Random.value * m_spawnWidth - (m_spawnWidth/2);

		Vector3 pos = transform.position;
		pos.x = posX;
		pos.z = 0f;

		
		GameObject gao = Instantiate(m_objects[rand], pos, Quaternion.Euler(0f,0f,rotate));
		
		gao.transform.localScale = scale;
    }

	private void Update()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			Spawn();
		}
	}

	void SetList(List<GameObject> list)
    {
		m_objects = list;
    }
}

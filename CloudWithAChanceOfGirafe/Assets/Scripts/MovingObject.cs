using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
	[SerializeField]
	float m_minMagnitude = 0.1f;

	[SerializeField]
	int m_tapToDestroy = 2;

	[SerializeField]
	bool m_indestructible = false;

	int m_tapNumber = 0;

	Vector3 m_previousPos;
	Rigidbody2D m_rigidbody;
	bool m_checkForMovement = false;

	private void Awake()
	{
		m_previousPos = transform.position;
		m_rigidbody = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		if(m_rigidbody.bodyType == RigidbodyType2D.Dynamic)
		{
			if (m_checkForMovement)
			{
				if ((transform.position - m_previousPos).magnitude <= m_minMagnitude)
					m_rigidbody.bodyType = RigidbodyType2D.Static;
			}
			m_previousPos = transform.position;
		}
	}

	private void OnBecameVisible()
	{
		m_checkForMovement = true;
	}

	private void OnMouseDown()
	{
		m_tapNumber++;
		if (m_tapNumber >= m_tapToDestroy && !m_indestructible)
			Destroy(gameObject);
	}
}

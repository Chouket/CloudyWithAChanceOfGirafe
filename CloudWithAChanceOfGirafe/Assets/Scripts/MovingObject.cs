﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
	//[SerializeField]
	//float m_minMagnitude = 0.1f;

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

	private void OnBecameVisible()
	{
		m_checkForMovement = true;
	}

	private void OnMouseDown()
	{
		if (gameObject.tag == "Giraffe")
			SoundManager.instance.PlayAudioClip("SqueakToy");
		else
		{
			int i = Random.Range(0, 3);
			string str = "Crack" + (i+1).ToString();
			SoundManager.instance.PlayAudioClip(str);
			m_tapNumber++;
			if (m_tapNumber >= m_tapToDestroy && !m_indestructible)
			{
				SoundManager.instance.PlayAudioClip("BlockBreak");
				Destroy(gameObject);
			}
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{ 
		if (col.collider.tag == "Player")
			SoundManager.instance.PlayAudioClip("Collision");

	}
}

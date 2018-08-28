using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class FallingObject : ScriptableObject
{
	public GameObject m_gameObject;
	public bool m_resize = true;
	public float m_speed = 1f;
	public float m_dropRate = 10;
}

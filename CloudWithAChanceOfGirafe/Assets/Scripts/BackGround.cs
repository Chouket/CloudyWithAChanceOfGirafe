using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour {

    public float DestroyHaight;
    private Camera _camera;

    private void Start()
    {
        _camera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    void Update () {
		if(_camera.transform.position.y - transform.position.y > DestroyHaight)
        {
            Destroy(gameObject);
        }
	}
}

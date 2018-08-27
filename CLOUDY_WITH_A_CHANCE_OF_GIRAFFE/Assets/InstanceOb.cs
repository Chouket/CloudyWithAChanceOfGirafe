using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceOb : MonoBehaviour {

    public GameObject _object;
    public Transform _Vec;
	// Use this for initialization
	void Start () {
		
	}
	
    public void Instance()
    {
        GameObject clone ;
        clone = Instantiate(_object,_Vec);
    }

	// Update is called once per frame
	void Update () {
		
	}
}

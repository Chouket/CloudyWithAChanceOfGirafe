using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyingObjectPC : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}
    // Update is called once per frame
    void Update () {

    }

#if UNITY_EDITOR || UNITY_STANDALONE
    private float clicktimer;

    void OnMouseDown()
    {
        clicktimer = Time.time;
    }

    private void OnMouseUp()
    {
        if (Time.time - clicktimer < 0.25f)
        {
            Debug.Log("tap");
            //health function
        }
    }

#endif
}

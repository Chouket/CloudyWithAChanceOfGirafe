using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGroundChecker : MonoBehaviour {

    public bool _isGroundCheck;

	void Update () {
		
	}
    private void OnTriggerStay(Collider collision)
    {
        Debug.Log("OnGround!");

        if (collision.tag != "Player")
        {
            _isGroundCheck = true;

        }
        
    }

    private void OnTriggerExit(Collider collision)
    {
        _isGroundCheck = false;
    }

}

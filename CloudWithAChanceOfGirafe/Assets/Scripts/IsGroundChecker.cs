using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGroundChecker : MonoBehaviour {

    public bool _isGroundCheck;

    private float waitTime = 0;
	void Update () {
        _isGroundCheck= Physics2D.Linecast(transform.position,
            transform.position - transform.up * 1.2f);
        waitTime += 0.01f;
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

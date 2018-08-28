using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGroundChecker : MonoBehaviour {

    public bool _isGroundCheck;

	void Update () {
        RaycastHit2D hit = Physics2D.Linecast(transform.position,
            transform.position - transform.up * 1.2f);

        _isGroundCheck = false;

        if (hit.collider)
            if (hit.collider.tag != "FDline" && hit.collider.tag != "PDline")
                _isGroundCheck = true;
    }

    //private void OnTriggerStay(Collider collision)
    //{
    //    Debug.Log("OnGround!");

    //    if (collision.tag != "Player")
    //    {
    //        _isGroundCheck = true;

    //    }
        
    //}

    //private void OnTriggerExit(Collider collision)
    //{
    //    _isGroundCheck = false;
    //}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeandDestroyScripts : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("enter");

        if (col.tag == "Falling")
        {
            col.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            col.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            col.gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0;
        }

    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Falling")
        {
            Debug.Log("exit");
            Destroy(col.gameObject);
        }

    }
}

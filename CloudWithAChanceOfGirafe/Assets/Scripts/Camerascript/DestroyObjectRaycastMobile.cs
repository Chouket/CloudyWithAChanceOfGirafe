using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectRaycastMobile : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

#if UNITY_IOS || UNITY_ANDROID
    GameObject[] TouchOb = new GameObject[2];
    float[] TouchTime = new float[2] ;
#endif
    // Update is called once per frame
    void Update()
    {
#if UNITY_IOS || UNITY_ANDROID
        if(Input.touchCount > 0)
         {
             for(int i = 0; i<2&& i < Input.touchCount ;i++)
             {
                if (Input.touchCount > 0 && Input.GetTouch(i).phase == TouchPhase.Began)
                {
                    Vector2 test = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);
                    TouchTime[i]=Time.time;
                     RaycastHit2D hit = Physics2D.Raycast(test, (Input.GetTouch(i).position));
                     if (hit.collider && hit.collider.tag == "Falling") //Changetag
                     {
                         TouchOb[i] = hit.collider.gameObject;           
                     }
                }
                if (Input.touchCount > 0 && Input.GetTouch(i).phase == TouchPhase.Ended)
                {
                    if (TouchOb[i] != null && Time.time - TouchTime[i] < 0.25f)
                     {
                          //TouchOb[i].reduceHP();
                          TouchOb[i]=null;
                     }
                }
             }
         }
#endif
    }
}
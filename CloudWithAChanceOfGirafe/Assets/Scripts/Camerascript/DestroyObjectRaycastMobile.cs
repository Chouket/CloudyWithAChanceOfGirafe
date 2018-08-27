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
    float[] TouchTime = new float[] ;
#endif
    // Update is called once per frame
    void Update()
    {
#if UNITY_IOS || UNITY_ANDROID
        if(Input.touchCount > 0)
         {
             for(int i < 0;i<2;i++)
             {
                if (Input.touchCount > 0 && Input.GetTouch(i).phase == TouchPhase.Began)
                {
                     TouchTime[i]=Time.time;
                     RaycastHit2D hit = Physics2D.Raycast(test, (Input.GetTouch(i).position);
                     if (hit.collider && hit.collider.tag == "Falling") //Changetag
                     {
                         TouchOb[i] = hit.collider.gameObject;           
                     }
                }
                if (Input.touchCount > 0 && Input.GetTouch(i).phase == TouchPhase.Ended)
                {
                     if(TouchOb[i]!=NULL && Time.time - TouchTime < 0.25f)
                     {
                          //TouchOb[i].reduceHP();
                          TouchOb[i]=NULL;
                     }
                }
             }
         }
#endif
    }
}
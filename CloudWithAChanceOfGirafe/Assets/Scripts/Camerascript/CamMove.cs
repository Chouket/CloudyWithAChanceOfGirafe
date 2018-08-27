using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour {

    static int Stage = 1;
    static int State = 1;
    static bool Statechange = false;
    readonly int DefaultSpeed = 1;    
    float Modifier = 1;
    Vector3 Iniposition;
	// Use this for initialization
	void Start () {
        Modifiercalculate();
        Iniposition = this.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (State == 1)
        {
            this.transform.Translate( new Vector3(0,Time.deltaTime * Modifier,0));
            try
            {
                
                Vector3 BL = GetComponent<Camera>().ScreenToWorldPoint(new Vector3(0,0, GetComponent<Camera>().nearClipPlane));
                Vector3 TL = GetComponent<Camera>().ScreenToWorldPoint(new Vector3(0,GetComponent<Camera>().pixelHeight, GetComponent<Camera>().nearClipPlane));
                GameObject pl = GameObject.FindGameObjectsWithTag("player")[0]; //locate player change accordingly
                if (pl.transform.position.y > (TL-BL).y*0.7f)
                {
                    this.transform.Translate(new Vector3(0,pl.transform.position.y- (TL - BL).y * 0.7f, 0)); //translate to player height
                }
            }
            catch (UnityException e)
            {
                Debug.Log("cant find player");
            }
             
        }

        if (Statechange)
        {
            Statechange = false;
            if (State != 0)
                Modifiercalculate();
            else
                ResetCam();
            
        }
	}

    public static void StateChange(int i,int j)
    {

        if (i < 0)
            State = 0;
        else if (i == 1)
            State = 1;
        else
            State = 2;


        if (Stage > 0)
            Stage = j;

        Statechange = true;
    }

    public static void StateChange(int i)
    {
        if (i < 0)
            State = 0;
        else if (i == 1)
            State = 1;
        else
            State = 2;

        Statechange = true;
    }
    
    void ResetCam()
    {
        this.transform.position = Iniposition;
        Stage = 1;
        
    }
    void Modifiercalculate()
    {
        Modifier = 1;//expression
    }
}

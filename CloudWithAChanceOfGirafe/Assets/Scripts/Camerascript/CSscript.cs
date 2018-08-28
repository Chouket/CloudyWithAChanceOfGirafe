using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSscript : MonoBehaviour {

    int State = 1;
    float Timer = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        switch (State)
        {
            case 1:
                this.transform.Translate(new Vector3(Time.deltaTime * 4, 0));
                if (this.transform.position.x > 12.5)
                {
                    this.transform.position = new Vector3(12.5f, this.transform.position.y, this.transform.position.z);
                    this.transform.Find("elevatordoor").gameObject.SetActive(true);
                    this.transform.Find("elevatordoor2").gameObject.SetActive(true);

                    State++;
                }
                break;
            case 2:
                this.transform.Translate(new Vector3(0, Time.deltaTime * 50));
                if (this.transform.position.y > 100)
                {
                    this.transform.position = new Vector3(this.transform.position.x, 100, this.transform.position.z);
                    this.transform.Find("elevatordoor").gameObject.SetActive(false);
                    this.transform.Find("elevatordoor2").gameObject.SetActive(false);
                
                State++;
                }
                break;
            case 3:
                this.transform.Translate(new Vector3(Time.deltaTime * -3, 0));
                if (this.transform.position.x <7.5)
                {
                    this.transform.position = new Vector3(7.5f, this.transform.position.y, this.transform.position.z);
                    this.transform.Find("Lightsaber2").gameObject.SetActive(true);
                    this.transform.Find("PTFace").gameObject.SetActive(true);
                    GameObject.Find("Lightsaber").gameObject.SetActive(false);
                    State++;
                }
                break;
            case 4:
                this.transform.Translate(new Vector3(Time.deltaTime * -3, 0));
                if (this.transform.position.x < -0.5)
                {
                    this.transform.position = new Vector3(-0.5f, this.transform.position.y, this.transform.position.z);
                    State++;
                }
                break;
            case 5:
                Timer += Time.deltaTime;
                if (Timer > 1)
                {
                    State++;
                    Timer = 0;
                }
                break;
            case 6:

                Timer += Time.deltaTime;
                if (Timer > 0.5f)
                {
                    State++;
                    Timer = 0;
                    this.transform.Find("blackSC").gameObject.SetActive(true);
                }
                break;
            case 7:
                Timer += Time.deltaTime;
                if (Timer > 0.5f)
                {
                    State++;
                    Timer = 0;
                    this.transform.Find("blackSlash").gameObject.SetActive(true);
                }
                break;
            case 8:
                Timer += Time.deltaTime;
                if (Timer > 0.5f)
                {
                    State++;
                    Timer = 0;
                    this.transform.Find("explosion").gameObject.SetActive(true);
                }
                break;
            case 9:
                Timer += Time.deltaTime;
                if (Timer > 1f)
                {
                    State++;
                    Timer = 0;
                    this.transform.Find("END").gameObject.SetActive(true);
                }
                break;
            case 10:
                Timer += Time.deltaTime;
                if (Timer > 2f)
                {
                   //calltitle
                }
                break;


        }
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackGroundInstance : MonoBehaviour {

    [Header("0 = Stage1," +
            "1 = Stage1 into Stage2,")]
    public GameObject[] _backGrounds;

    public Transform[] CheckPoint;

    [Header("Imageの高さ")]
    public float ImageHeight = 15.8f;

    [Header("インスタンスする間隔")]
    public float reroadReach = 10;

    public Transform cameraPos;

    public List<GameObject> InstanceBackgroundImage;
	void Start () {
		
	}


	void Update () {
        Instance();

    }

    void Instance()
    {


       if((cameraPos.position.y%ImageHeight)>=reroadReach&& InstanceBackgroundImage.Count < 3)
        {
            InstanceBackgroundImage.Add(_backGrounds[0]);
            GameObject Clone = Instantiate(_backGrounds[0]);
            Clone.transform.position = new Vector3(0, Mathf.Floor(cameraPos.position.y / ImageHeight)*reroadReach+(4));
        }
    }
}

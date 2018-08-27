using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackGroundInstance : MonoBehaviour {

    public GameObject[] _backGrounds;

    [Header("Imageの高さ")]
    public float ImageHeight;

    [Header("インスタンスする間隔")]
    public float reroadReach;

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserIntarface : MonoBehaviour {

    enum Platform
    {
        PC,
        ANDROID,
    }
    private Platform platform;

    public enum Forward
    {
        RIGHT,
        LEFT,
        UP,
        IDLE,
    }
    public Forward _forward;

    public enum StateCTRL
    {
        ENTER,
        HOLD,
        OUT,
    }
    public StateCTRL stateCTRL;

    public float raddian,mag;

    public Image joyStick;
    private Vector2 localJoystickPos;

    private Vector2 InPosition;

	void Start () {
        localJoystickPos = joyStick.transform.position;
        if (Application.platform == RuntimePlatform.Android)
        {
            // Android
            platform = Platform.ANDROID;
        }
        else
        {
            platform = Platform.PC;
        }
    }
	
	// Update is called once per frame
	void Update () {
        switch (platform)
        {
            case Platform.PC:
                PCUI();
                break;
            case Platform.ANDROID:
                break;

            default:
                break;
        }
    }

    void AndroidUI()
    {
        Touch touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Ended)
        {
            stateCTRL = StateCTRL.OUT;
            return;
        }
        raddian = GetAim(InPosition, touch.position);
        mag = Mathf.Clamp((InPosition - (Vector2)touch.position).magnitude,0,40);
        ForwardType(raddian);
        joyStick.transform.position = touch.position;
    }

    void PCUI()
    {
        if (!Input.GetMouseButton(0))
        {
            joyStick.transform.position = localJoystickPos;
            _forward = Forward.IDLE;
            return;
        }
        if(Input.GetMouseButtonDown(0)) InPosition = Input.mousePosition;

        raddian = GetAim(InPosition, Input.mousePosition);
        mag = (InPosition - (Vector2)Input.mousePosition).magnitude;
        ForwardType(raddian);
        joyStick.transform.position = Input.mousePosition;

    }

    public float GetAim(Vector3 p1, Vector3 p2)
    {
        //ラジアンをfloatで返すクラス
        float dx = p2.x - p1.x;
        float dy = p2.y - p1.y;
        float rad = Mathf.Atan2(dy, dx);
        return rad * Mathf.Rad2Deg;
    }

    public void ForwardType(float rad)
    {
        if ((-90 > rad && rad  >-180)||(140<rad&&rad<180))
        {
            _forward = Forward.LEFT;
        }else
        if (60 <= rad && rad < 140)
        {
            _forward = Forward.UP;
        }
        else
        {
            _forward = Forward.RIGHT;
        }


    }
}

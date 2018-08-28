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

    static public bool OnUIMousePos;

    public float raddian,mag;

    public Image joyStick;
    private Vector2 localJoystickPos,addCameraPosLocalJoystickPos;

    private Vector2 InPosition;

    private Camera _camera;

    public UIZone uIZone;

	void Start () {
        _camera = GameObject.Find("Main Camera").GetComponent<Camera>();
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
       
              addCameraPosLocalJoystickPos = localJoystickPos + (Vector2)_camera.transform.position + new Vector2(0, -3.85f);
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
        if (touch.phase == TouchPhase.Moved) InPosition = touch.position;
        raddian = GetAim(InPosition, touch.position);
        mag = Mathf.Clamp((InPosition - (Vector2)touch.position).magnitude, 0, 40);
        ForwardType(raddian);
        joyStick.transform.position = localJoystickPos - (InPosition - touch.position).normalized * mag;
    }

    void PCUI()
    {
        if (!Input.GetMouseButton(0))
        {
            joyStick.transform.position = addCameraPosLocalJoystickPos;
            _forward = Forward.IDLE;
            return;
        }
        if (Input.GetMouseButtonDown(0)) InPosition = Input.mousePosition;

        raddian = GetAim(InPosition, Input.mousePosition);
        mag = Mathf.Clamp((InPosition - (Vector2)Input.mousePosition).magnitude, 0, 40);
        ForwardType(raddian);
        joyStick.transform.position = addCameraPosLocalJoystickPos - (InPosition - (Vector2)Input.mousePosition).normalized ;

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CScontroller : MonoBehaviour {

    Rigidbody2D myrigid;

    [SerializeField]
    [Header("junp power")]
    private float junpPower = 1.0f;


    [SerializeField]
    [Header("side power")]
    private float sidePower = 1.0f;

    //----Infinite jump prohibition----//
    [SerializeField]
    [Header("Foot colloder")]
    private bool isGround;

    //-----use Animation-----//
    public Animator anim;

    //-----Ground Check--//
    private IsGroundChecker _IsGroundChecker;

    //-----jumpWaitTime----//
    private float waitTime;
    static int State;
    //----Player Animation Enum---//
    public enum PlayerAnimationState
    {
        IDLE,
        JUMP,
        JUMPING,
        BOUNDING,
        GRAB,
        SWING,

    }
    public PlayerAnimationState _PlayerAnimationState;

    public static void StateChange(int i)
    {
        State = i;

    }
    //----Player Have a power up Item-----//



    //---UIScript----//
    public UserIntarface _uiScript;

    void Start()
    {
        myrigid = GetComponent<Rigidbody2D>();
        _IsGroundChecker = GetComponentInChildren<IsGroundChecker>();

    }

    //----use rigidBody Update--//
    void FixedUpdate()
    {
        Move();
        Animation();
        waitTime += 0.05f;
    }


    private void Update()
    {

    }

    void Move()
    {

            switch (State)
            {

                case 1:
                _PlayerAnimationState = PlayerAnimationState.IDLE;
                    break;
                case 2:
                _PlayerAnimationState = PlayerAnimationState.GRAB;
                    break;
                case 3:
                _PlayerAnimationState = PlayerAnimationState.SWING;
                    break;
                default:

                    break;
            




            //if (Input.GetAxis("Horizontal") != 0)
            //{
            //    myrigid.AddForce(new Vector2(Input.GetAxis("Horizontal") * sidePower, 0));
            //}

            ////--------
            //if (Input.GetKey(KeyCode.Space))
            //{
            //    //-----jumping Animation----//
            //    _PlayerAnimationState = PlayerAnimationState.JUMP;
            //}

            //if (Input.GetKeyUp(KeyCode.Space))
            //{
            //    if (_IsGroundChecker._isGroundCheck == true)
            //    {
            //        //------jumping-----//
            //        myrigid.AddForce(Vector2.up * junpPower);
            //    }

            //    //-----jumping Animation----//
            //    _PlayerAnimationState = PlayerAnimationState.JUMPING;
            //}
        }

    }

    void Animation()
    {

        switch (_PlayerAnimationState)
        {
            case PlayerAnimationState.IDLE:
                anim.Play("PlayerAnimstion");
                break;
            case PlayerAnimationState.JUMP:
                anim.Play("PlayerJumping");
                _PlayerAnimationState = PlayerAnimationState.JUMPING;
                break;
            case PlayerAnimationState.JUMPING:

                anim.Play("PlayerJumpLoop");
                if (_IsGroundChecker._isGroundCheck == true && waitTime > 1) _PlayerAnimationState = PlayerAnimationState.BOUNDING;

                break;
            case PlayerAnimationState.BOUNDING:
                // anim.Play("PlayerJump");
                _PlayerAnimationState = PlayerAnimationState.IDLE;
                break;
            case PlayerAnimationState.GRAB:
                anim.Play("PlayerGrab");
                break;
            case PlayerAnimationState.SWING:
                anim.Play("PlayerSwing");
                break;

            default:
                break;
        }

    }


}

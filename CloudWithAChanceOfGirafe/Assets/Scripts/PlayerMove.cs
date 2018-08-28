using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    Rigidbody2D myrigid;

    [SerializeField]
    [Header("junp power")]
    private float junpPower=1.0f;


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
    
    //----Player Animation Enum---//
    public enum PlayerAnimationState
    {
        IDLE,
        JUMP,
        JUMPING,
        BOUNDING,

    }
    public PlayerAnimationState _PlayerAnimationState;

    //----Player Have a power up Item-----//
    


    //---UIScript----//
    public UserIntarface _uiScript;

    void Start () {
        myrigid = GetComponent<Rigidbody2D>();
        _IsGroundChecker = GetComponentInChildren<IsGroundChecker>();

    }
	
	//----use rigidBody Update--//
	void FixedUpdate () {
        Move();
        Animation();
        waitTime += 0.05f;
	}


    private void Update()
    {
        
    }

    void Move()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            // Android
        }
        else
        {
            switch (_uiScript._forward)
            {
                case UserIntarface.Forward.RIGHT:
                    myrigid.AddForce(Vector2.right * sidePower, 0);
                    break;
                case UserIntarface.Forward.LEFT:
                    myrigid.AddForce(Vector2.left * sidePower, 0);
                    break;
                case UserIntarface.Forward.UP:
                    if (_IsGroundChecker._isGroundCheck == true && waitTime > 1)
                    {
                        myrigid.AddForce(Vector2.up * junpPower);
                        waitTime = 0;
                        _PlayerAnimationState = PlayerAnimationState.JUMP;
						SoundManager.instance.PlayAudioClip("Jump");
					}
                    break;
                case UserIntarface.Forward.IDLE:
                    break;
                default:
                    break;
            }




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
                if(_IsGroundChecker._isGroundCheck == true&& waitTime > 1) _PlayerAnimationState = PlayerAnimationState.BOUNDING;

                break;
            case PlayerAnimationState.BOUNDING:
               // anim.Play("PlayerJump");
                _PlayerAnimationState = PlayerAnimationState.IDLE;
                break;
            default:
                break;
        }
       
    }

    
}

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

    //----Player Animation Enum---//
    public enum PlayerAnimationState
    {
        IDLE,
        JUMP,
        JUMPING,

    }
    public PlayerAnimationState _PlayerAnimationState;

    void Start () {
        myrigid = GetComponent<Rigidbody2D>();
        _IsGroundChecker = GetComponentInChildren<IsGroundChecker>();

    }
	
	//----use rigidBody Update--//
	void FixedUpdate () {
        Move();
        
	}


    private void Update()
    {
        Animation();
    }

    void Move()
    {
        
        if (Input.GetAxis("Horizontal")!=0)
        {
            myrigid.AddForce(new Vector2(Input.GetAxis("Horizontal")* sidePower,0));
        }

        //--------
        if (Input.GetKey(KeyCode.Space))
        {
            //-----jumping Animation----//
            _PlayerAnimationState = PlayerAnimationState.JUMP;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (_IsGroundChecker._isGroundCheck == true)
            {
                //------jumping-----//
                myrigid.AddForce(Vector2.up * junpPower);
            }

            //-----jumping Animation----//
            _PlayerAnimationState = PlayerAnimationState.JUMPING;
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
                anim.Play("PlayerJump");
                break;
            case PlayerAnimationState.JUMPING:
                anim.Play("PlayerJumping");

                if(_IsGroundChecker._isGroundCheck == true) _PlayerAnimationState = PlayerAnimationState.IDLE;

                break;
            default:
                break;
        }
        if (!Input.GetKey(KeyCode.Space))
        {
            
        }
        else
        {
           
        }
    }
}

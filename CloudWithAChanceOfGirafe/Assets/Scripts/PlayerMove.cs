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

    public Animator anim;

    private IsGroundChecker _IsGroundChecker;

    void Start () {
        myrigid = GetComponent<Rigidbody2D>();
        _IsGroundChecker = GetComponentInChildren<IsGroundChecker>();

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        Move();
        Animation();
	}

    void Move()
    {
        if (Input.GetAxis("Horizontal")!=0)
        {
            myrigid.AddForce(new Vector2(Input.GetAxis("Horizontal")* sidePower,0));
        }


        if (Input.GetKeyUp(KeyCode.Space)&&_IsGroundChecker._isGroundCheck == true)
        {
            
            myrigid.AddForce(Vector2.up * junpPower);
        }

    }

    void Animation()
    {

        if (!Input.GetKey(KeyCode.Space))
        {
            anim.Play("PlayerAnimstion");
        }
        else
        {
            anim.Play("PlayerJump");
        }
    }
}

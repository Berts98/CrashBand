using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MovementBase
{
    private bool jump = false;
    public float MovementSpeed;
    //public Rigidbody RB;
    public float JumpForce;
    public CharacterController CharController;
    AnimationController animCtrl;

    private Vector3 MoveDirection;
    public float gravityScale;

    // Start is called before the first frame update
    void Start()
    {
        CharController = GetComponent<CharacterController>();
        animCtrl = GetComponent<AnimationController>();
        if (animCtrl != null)
            animCtrl.Init(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (CharController.isGrounded && jump == false)
        {
            MoveDirection = new Vector3(Input.GetAxis("Horizontal") * MovementSpeed, MoveDirection.y, Input.GetAxis("Vertical") * MovementSpeed);

            if (Input.GetButtonDown("Jump"))
            {
                jump = true;
                MoveDirection.y = JumpForce;
                JumpAnim();
            }
            else if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                WalkAnim();
            }
            else
            {
                IdleAnim();
            }
        }
        else if (CharController.isGrounded == false)
        {
            jump = false;
        }
            MoveDirection.y = MoveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
            CharController.Move(MoveDirection * Time.deltaTime);
    }

    public void JumpAnim()
    {
        if (OnJump != null)
        {
            OnJump();
        }
    }
    public void WalkAnim()
    {
        if (OnWalk != null)
        {
            OnWalk();
        }
    }
    public void IdleAnim()
    {
        if (OnIdle != null)
        {
            OnIdle();
        }
    }
}

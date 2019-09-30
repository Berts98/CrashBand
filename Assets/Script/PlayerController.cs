using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MovementBase
{
    private bool jump = false;
    public float MovementSpeed;
    //public Rigidbody RB;
    public float JumpForce;
    public int currentHealth;
    public CharacterController CharController;
    AnimationController animCtrl;

    private Vector3 MoveDirection;
    public float gravityScale;
    public Transform Pivot;
    public float RotationSpeed;
    public GameObject PlayerModel;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = 5;
        CharController = GetComponent<CharacterController>();
        animCtrl = GetComponentInChildren<AnimationController>();
        if (animCtrl != null)
            animCtrl.Init(this);
    }

    // Update is called once per frame
    void Update()
    {
        LifeValue();
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

        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            transform.rotation = Quaternion.Euler(0f, Pivot.rotation.eulerAngles.y, 0f);
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(MoveDirection.x, 0f, MoveDirection.z));
            PlayerModel.transform.rotation = Quaternion.Slerp(PlayerModel.transform.rotation, newRotation, RotationSpeed * Time.deltaTime);
        }
    }

    public void Damage(int dmg)
    {
        currentHealth -= dmg;
    }

    public void LifeValue()
    {
        GameManager.singleton.UI.LifeTextValue.text = "X " + currentHealth;
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

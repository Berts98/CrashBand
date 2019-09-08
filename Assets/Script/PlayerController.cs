using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MovementSpeed;
    //public Rigidbody RB;
    public float JumpForce;
    public CharacterController CharController;

    private Vector3 MoveDirection;
    public float gravityScale;

    // Start is called before the first frame update
    void Start()
    {
        CharController = GetComponent<CharacterController>();   
    }

    // Update is called once per frame
    void Update()
    {
        MoveDirection = new Vector3(Input.GetAxis("Horizontal") * MovementSpeed, MoveDirection.y, Input.GetAxis("Vertical") * MovementSpeed);

        if (CharController.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                MoveDirection.y = JumpForce; 
            }
        }

        MoveDirection.y = MoveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
        CharController.Move(MoveDirection * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    bool inputOK = false;
    [Header("Playerのステータス")]
    public float moveSpeed = 10;   //移動スピード
    public float gravity = 10;

    CharacterController characon;
    Rigidbody rig;
    float hor;
    Vector3 moveDirection;
    Vector3 gravityDirection;

    void Start()
    {
        characon = GetComponent<CharacterController>();
        rig = GetComponent<Rigidbody>();
    }

    void Update()
    {
        InputCheck();
        if(inputOK)
        {
            Move();
            Gravity();
            //Rotation();
        }
       
    }

    public void InputCheck()
    {
        if(GameManager.Instance.mainGame)
        {
            inputOK = true;
        }
        else
        {
            inputOK = false;
        }
    }
    public void Move()
    {
        hor = Input.GetAxis("Horizontal");
        moveDirection.x = hor * moveSpeed;
        characon.Move(moveDirection * Time.deltaTime);
    }
    void Rotation()
    {
        transform.LookAt(Input.mousePosition);
    }
    void Gravity()
    {
        gravityDirection.y -= gravity * Time.deltaTime;

        characon.Move(gravityDirection * Time.deltaTime);
        if(characon.isGrounded)
        {
            gravityDirection.y = -0.1f;
        }
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    bool inputOK = false;
    [Header("Playerのステータス")]
    public float moveSpeed = 10;   //移動スピード
    public float gravity = 10;

    CharacterController characon;
    float hor;
    Vector3 moveDirection;
    Vector3 gravityDirection;

    [SerializeField] Transform target;

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
            Rotation();
            //Squat();
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
        Vector3 ver = gameObject.transform.rotation * moveDirection;
        characon.Move(ver * Time.deltaTime);
    }
    void Rotation()
    {
        transform.LookAt(target);
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
    /*public void Squat()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
        }
    }*/
}

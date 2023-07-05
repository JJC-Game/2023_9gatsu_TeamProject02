using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    bool inputOK = false;
    [Header("Player�̃X�e�[�^�X")]
    public float moveSpeed = 10;   //�ړ��X�s�[�h

    CharacterController characon;
    float hor;
    Vector3 moveDirection;

    void Start()
    {
        characon = GetComponent<CharacterController>();
    }

    void Update()
    {
        InputCheck();
        if(inputOK)
        {
            Move();

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
}
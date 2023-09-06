﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private float EnemyMoveSpeed = 2f;
    Vector3 LeftRightstartpos;
    Vector3 UpDownstartpos;
    [SerializeField]
    [Tooltip("生成する範囲A")]
    private Transform rangeA;

    [SerializeField]
    [Tooltip("生成する範囲B")]

    private Transform rangeB;
    Animator animator;
    Rigidbody rig;
    EnemyAddObject EA;

    [SerializeField] float pointmoveTime;
    [SerializeField] float Routeinterval;
    [SerializeField] GameObject[] routePoint;

    int current = 0;
    int next = 1;
    Vector3 currentPos;
    Vector3 nextPos;
    float timer;
    private float random;
    [SerializeField] Vector3 LeftRightDistans = new Vector3(2, 0, 0);
    [SerializeField] Vector3 UpDownDistans = new Vector3(0, 1, 0);
    private bool animationspeedFLG;
    public enum MoveTypelist
    {
        左右移動,
        上下移動,
        ルート移動,
        左右上下移動,
        停止,
    }
    [SerializeField] MoveTypelist movetype;

    void Start()
    {
         random = Random.Range(1, 3);
        rig = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        

        float Enemyrandompattern = Random.Range(1, 6);
        if (Enemyrandompattern == 1)
        {
            movetype = MoveTypelist.停止;
        }
        if(Enemyrandompattern == 2)
        {
            movetype = MoveTypelist.左右移動;
        }
        if(Enemyrandompattern==3)
        {
            movetype = MoveTypelist.上下移動;
        }
        if(Enemyrandompattern == 4)
        {
            movetype = MoveTypelist.ルート移動;
        }
        if(Enemyrandompattern == 5)
        {
            movetype = MoveTypelist.左右移動;
        }
        /*switch (movetype)
        {
            case MoveTypelist.左右上下移動:
                InvokeRepeating("hukugou", 0, 5);
                break;
        }*/
    }
    void Update()
    {
        switch (movetype)
        {
            case MoveTypelist.左右移動:
                rerere();
                break;
            case MoveTypelist.上下移動:
                jouge();
                break;
            case MoveTypelist.ルート移動:
                route();
                break;
            /*case MoveTypelist.左右上下移動:
                hukugou();
                break;*/
            case MoveTypelist.停止:
                teisi();
                break;
                
                

                
        }
        LeftRightstartpos = new Vector3(EA.EnemyX[EA.Enemyid], EA.EnemyY[EA.Enemyid], EA.EnemyZ[EA.Enemyid]);
        UpDownstartpos = new Vector3(EA.EnemyX[EA.Enemyid], EA.EnemyY[EA.Enemyid], EA.EnemyZ[EA.Enemyid]);

        Debug.Log(EA.EnemyX + "Xです" + EA.EnemyY + "Yです" + EA.EnemyZ + " Zです");
        Debug.Log(EA.Enemyid);
    }
    void rerere()
    {
        if (random == 1)
        {
            float cos = Mathf.Cos(Time.time) * EnemyMoveSpeed;
            transform.position = LeftRightstartpos + (LeftRightDistans * cos);
            //Debug.Log(LeftRightstartpos);
            if (cos >= 1.75f)
            {
                animationspeedFLG = true;
            }
            if (cos <= -1.75f)
            {
                animationspeedFLG = false;
            }

            if (animationspeedFLG == true)
            {
                animator.SetFloat(Animator.StringToHash("Speed"), 1f);
                animator.SetBool("Run", true);
                animator.SetBool("Idle", false);
                //Debug.Log("通常再生してほしい所");
            }
            /*
            if(sin > 0)
            {
                animator.SetBool("Idle", true);
                animator.SetBool("Run", false);
                Debug.Log("サイン関数がゼロになりました");
                ]
            }*/
            else if (animationspeedFLG == false)
            {
                animator.SetFloat(Animator.StringToHash("Speed"), -1f);
                animator.SetBool("Run", true);
                animator.SetBool("Idle", false);
                //Debug.Log("逆再生してほしいところ");
            }
        }
        if (random == 2)
        {
            float sin = Mathf.Sin(Time.time) * EnemyMoveSpeed;
            transform.position = LeftRightstartpos + (LeftRightDistans * sin);
            //Debug.Log("サインです");
            if (sin >= 1.75f)
            {
                animationspeedFLG = true;
            }
            if (sin <= -1.75f)
            {
                animationspeedFLG = false;
            }

            if (animationspeedFLG == true)
            {
                animator.SetFloat(Animator.StringToHash("Speed"), 1f);
                animator.SetBool("Run", true);
                animator.SetBool("Idle", false);
                //Debug.Log("通常再生してほしい所");
            }
            /*
            if(sin > 0)
            {
                animator.SetBool("Idle", true);
                animator.SetBool("Run", false);
                Debug.Log("サイン関数がゼロになりました");
                ]
            }*/
            else if (animationspeedFLG == false)
            {
                animator.SetFloat(Animator.StringToHash("Speed"), -1f);
                animator.SetBool("Run", true);
                animator.SetBool("Idle", false);
                //Debug.Log("逆再生してほしいところ");
            }
        }
        
       
    }
    private void route()
    {
        if(timer <= pointmoveTime)
        {
            timer += Time.fixedDeltaTime;
            currentPos = routePoint[current].transform.position;
            nextPos = routePoint[next].transform.position;
            rig.MovePosition(Vector3.Lerp(currentPos, nextPos, timer / pointmoveTime));

            animator.SetBool("Run", true);
            animator.SetBool("Idle", false);
        }
        else
        {
            EnemyPause();

            animator.SetBool("Idle", true);
            animator.SetBool("Run", false);
        }
    }
    private void jouge()
    {
        if (random == 1)
        {
            float sin = Mathf.Sin(Time.time) * EnemyMoveSpeed;
            transform.position = UpDownstartpos + (UpDownDistans * sin);
        }
        if(random == 2)
        {
            float cos = Mathf.Cos(Time.time) * EnemyMoveSpeed;
            transform.position = UpDownstartpos + (UpDownDistans * cos);
        }
    }

    /*private void hukugou()
    {
        float hukugoX = Random.Range(1, 3);
        float hukugoY = Random.Range(1, 3);
        HukugoDistans = new Vector3(hukugoX, 0, hukugoY);
        Vector3.MoveTowards(Hukugostartpos, HukugoDistans, 0);
        Debug.Log("五秒に一回処理してね");
    }
    */
    private void teisi()
    {

    }

    private void EnemyPause()
    { 
        if(timer <= pointmoveTime + Routeinterval)
        {
            timer += Time.fixedDeltaTime;
        }
        else
        {
            current = next;
            next = (next + 1) % routePoint.Length;
            timer = 0;
        }
    }
}
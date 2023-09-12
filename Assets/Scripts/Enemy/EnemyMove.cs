using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    private float EnemyMoveSpeed = 2f;
    Vector3 LeftRightstartpos;
    Vector3 UpDownstartpos;
    Vector3 Hukugostartpos;
    Vector3 Routestartpos;
    [SerializeField]
    [Tooltip("生成する範囲A")]
    private Transform rangeA;

    [SerializeField]
    [Tooltip("生成する範囲B")]

    private Transform rangeB;
    Animator animator;
    Rigidbody rig;
    GameObject EnemyPosA;
    GameObject EnemyPosB;
    public GameObject[] EnemyRoute;
    NavMeshAgent nav;
    int nextPoint;

    private float StartPosX;
    private float StartPosY;
    private float StartPosZ;

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
        nav = GetComponent<NavMeshAgent>();
        float Enemyrandompattern = Random.Range(1, 5);
        if (Enemyrandompattern == 1)
        {
            movetype = MoveTypelist.停止;
        }
        if(Enemyrandompattern == 2)
        {
            movetype = MoveTypelist.左右移動;
        }
        if(Enemyrandompattern == 3)
        {
            movetype = MoveTypelist.ルート移動;
        }
        if(Enemyrandompattern == 4)
        {
            movetype = MoveTypelist.左右移動;
        }

        EnemyPosA = GameObject.FindWithTag("EnemySpownPoint");
        EnemyPosB = GameObject.FindWithTag("EnemySpownPointB");
        StartPosX = Random.Range(EnemyPosA.transform.position.x, EnemyPosB.transform.position.x);
        StartPosY = Random.Range(EnemyPosA.transform.position.y, EnemyPosB.transform.position.y);
        StartPosZ = Random.Range(EnemyPosA.transform.position.z, EnemyPosB.transform.position.z);
        LeftRightstartpos = new Vector3(StartPosX, StartPosY, StartPosZ);
        UpDownstartpos = new Vector3(StartPosX, 3f, StartPosZ);
        Routestartpos = new Vector3(StartPosX, StartPosY, StartPosZ);
        routePoint = GameObject.FindGameObjectsWithTag("EnemyRoute");
    }
    void Update()
    {
        switch (movetype)
        {
            case MoveTypelist.左右移動:
                rerere();
                break;
            case MoveTypelist.ルート移動:
                route();
                break;
            case MoveTypelist.停止:
                teisi();
                break;
                
                

                
        }
    }
    void rerere()
    {
        if (random == 1)
        {
            float cos = Mathf.Cos(Time.time) * EnemyMoveSpeed;
            transform.position = LeftRightstartpos + (LeftRightDistans * cos);
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
            }
            else if (animationspeedFLG == false)
            {
                animator.SetFloat(Animator.StringToHash("Speed"), -1f);
                animator.SetBool("Run", true);
                animator.SetBool("Idle", false);
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
        if (nav.pathPending == false  && nav.remainingDistance <=0.5f)
        {
            //次の地点のポイントを目標に
            nav.destination = routePoint[nextPoint].transform.position;

            //配列の次の値を設定、次がなければ0に戻る
            nextPoint = (nextPoint + 1) %routePoint.Length;
            animator.SetBool("Run", true);
        }
    }

    // 次の地点のポイントを目標に

    // 配列の次の値を設定、次がなければ０に戻る



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
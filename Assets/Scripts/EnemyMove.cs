using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private float EnemyMoveSpeed = 2f;
    Vector3 LeftRightstartpos;
    Vector3 UpDownstartpos;
    Vector3 Hukugostartpos;

    [SerializeField] float pointmoveTime;
    [SerializeField] float interval;

    [SerializeField] GameObject[] routePoint;

    Rigidbody rig;

    int current = 0;
    int next = 1;

    Vector3 currentPos;
    Vector3 nextPos;

    float timer;
    Vector3 vel;

    [SerializeField] Vector3 LeftRightDistans = new Vector3(2, 0, 0);
    [SerializeField] Vector3 UpDownDistans = new Vector3(0, 1, 0);
    [SerializeField] Vector3 HukugoDistans = new Vector3(0, 0, 2);
    enum MoveTypelist
    {
        左右移動,
        上下移動,
        ルート移動,
        左右上下移動,

    }
    [SerializeField] MoveTypelist movetype;


    private int RouteCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        int Zrandompostion = Random.Range(3, 30);
        int xrandompostion = Random.Range(-18, 18);
        LeftRightstartpos = new Vector3(0, 0.5f, Zrandompostion);
        UpDownstartpos = new Vector3(xrandompostion, 1.5f, Zrandompostion);
        Hukugostartpos = new Vector3(xrandompostion, 0.5f, Zrandompostion);
    }

    // Update is called once per frame
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

            case MoveTypelist.左右上下移動:
                
                hukugou();
                break;


        }


    }
    void rerere()
    {
        float sin = Mathf.Sin(Time.time) * EnemyMoveSpeed;
        transform.position = LeftRightstartpos + (LeftRightDistans * sin);
    }
    void route()
    {
        if(timer <= pointmoveTime)
        {
            timer += Time.fixedDeltaTime;

            currentPos = routePoint[current].transform.position;
            nextPos = routePoint[next].transform.position;
            rig.MovePosition(Vector3.Lerp(currentPos, nextPos, timer / pointmoveTime));

        }
        else
        {
            EnemyPause();
        }
    }
    void jouge()
    {
        float sin = Mathf.Sin(Time.time) * EnemyMoveSpeed;
        transform.position = UpDownstartpos + (UpDownDistans * sin);
    }

    private void hukugou()
    {
        HukugoDistans = new Vector3(Random.Range(-18f, 18f), Random.Range(0.5f, 1.5f), Random.Range(3f, 30f));
        transform.position = Vector3.Lerp(transform.position, HukugoDistans, 1);
    }

    private void EnemyPause()
    { 
        if(timer <= pointmoveTime + interval)
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
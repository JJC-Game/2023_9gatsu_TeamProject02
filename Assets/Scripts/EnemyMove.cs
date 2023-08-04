using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private float EnemyMoveSpeed = 2f;
    Vector3 LeftRightstartpos;
    Vector3 UpDownstartpos;
    Vector3 Hukugostartpos;

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

    public List<GameObject> RoutePoints = new List<GameObject>();
    private int RouteCount = 0;
    // Start is called before the first frame update
    void Start()
    {
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
        if (RoutePoints.Count == 0)
            return;

        Vector3 TartgetPosition = RoutePoints[RouteCount].transform.position;
        Vector3 moveDirection = (TartgetPosition - transform.position).normalized;
        transform.position += moveDirection * EnemyMoveSpeed * Time.deltaTime;

        if (Vector3.Distance(transform.position, TartgetPosition) < 0.1f)
        {
            RouteCount = (RouteCount + 1) % RoutePoints.Count;
        }
    }
    void jouge()
    {
        float sin = Mathf.Sin(Time.time) * EnemyMoveSpeed;
        transform.position = UpDownstartpos + (UpDownDistans * sin);
    }

    void hukugou()
    {
        float sin = Mathf.Sin(Time.time) * EnemyMoveSpeed;
        transform.position = Hukugostartpos + (HukugoDistans * sin);
    }
}
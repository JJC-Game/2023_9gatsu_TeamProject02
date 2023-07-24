using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private Rigidbody rb;
    private float EnemyMoveSpeed = 2f;
    Vector3 startpos;

    [SerializeField] Vector3 movedistans = new Vector3(2, 0, 0);
    enum MoveTypelist
    {
        左右移動,
        上下移動,
        ルート移動,

    }
    [SerializeField] MoveTypelist movetype;

    // Start is called before the first frame update
    void Start()
    {
        int randompostion = Random.Range(3, 30);
        startpos = new Vector3(0, 0.5f, randompostion);
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


            }
        

    }
    void rerere()
    {
        float sin = Mathf.Sin(Time.time) * EnemyMoveSpeed;
        transform.position = startpos + (movedistans * sin);
    }
    void route()
    {

    }
    void jouge()
    {
    }
     
}
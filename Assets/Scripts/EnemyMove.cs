using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [Header("敵のパラメータ")]
    public float moveSpeed;//移動スピード
    public float StopTime;//停止時間
    Vector3 StrafeDirection = new Vector3(2, 0, 0);//移動する方向

    Vector3 StartPos;　//初期位置


    enum MoveType
    {
        左右移動,
        上下移動,
        ルート移動,

    }
    [SerializeField] MoveType movetype;

    // Start is called before the first frame update
    void Start()
    {
        StartPos = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.mainGame == true )
        {
            switch(movetype)
            {
                case MoveType.左右移動:
                    rerere();
                    break;

                case MoveType.上下移動:
                    jouge();
                    break;

                case MoveType.ルート移動:
                    route();
                    break;
                    
                   
            }
        }

    }

    void  rerere()
    {
       
    }

    void jouge()
    {

    }

    void route()
    {

    }
}
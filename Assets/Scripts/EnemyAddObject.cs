﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//指定した位置に三体の敵オブジェクトを配置する
public class EnemyAddObject : MonoBehaviour
{
    public GameObject[] EnemyObject;

    public int Enemynum;

    public Transform[] Enemyposition;
    public int EnemyCountMax;
    public int EnemyCount;
    [SerializeField]
    [Tooltip("生成する範囲A")]
    private Transform rangeA;

    [SerializeField]
    [Tooltip("生成する範囲B")]
    private Transform rangeB;

    void Start()
    {
     
    }

    void Update()
    {
        if(GameManager.Instance.mainGame)
        {
            EnemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

            if (EnemyCountMax > EnemyCount)
            {
                for (int i = 0; i < Enemyposition.Length; i++)
                {
                    // rangeAとrangeBのx座標の範囲内でランダムな数値を作成
                    float x = Random.Range(rangeA.position.x, rangeB.position.x);
                    // rangeAとrangeBのy座標の範囲内でランダムな数値を作成
                    float y = Random.Range(rangeA.position.y, rangeB.position.y);
                    // rangeAとrangeBのz座標の範囲内でランダムな数値を作成
                    float z = Random.Range(rangeA.position.z, rangeB.position.z);
                    Enemynum = Random.Range(0, EnemyObject.Length);
                    Instantiate(EnemyObject[Enemynum], new Vector3(x, y, z), Quaternion.Euler(0,180,0));
                }
            }
            if (Input.GetKeyDown(KeyCode.T))
           {
                GameObject[] Enemys = GameObject.FindGameObjectsWithTag("Enemy");

                foreach (GameObject EnemyObjects in Enemys)
                {
                    Destroy(EnemyObjects);
                }
            }
        }
    }

    public void EnemySpown()
    {
        EnemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        //Destroy(GameObject.FindWithTag("Enemy"));
        if (EnemyCountMax > EnemyCount)
        {
            for (int i = 0; i < Enemyposition.Length; i++)
            {
                Enemynum = Random.Range(0, EnemyObject.Length);
                Instantiate(EnemyObject[Enemynum], Enemyposition[i].position, Quaternion.identity);
            }
        }
    }


}

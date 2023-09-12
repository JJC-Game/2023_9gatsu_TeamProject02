using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAddObject : Singleton<EnemyAddObject>
{
    bool respawn;

    public GameObject[] EnemyObject;

    public int Enemyid;

    public int EnemyCountMax = 10; //敵の生成数
    int EnemyCount;  //敵の現存数

    public float EnemyXPosition;
    public float EnemyYPosition;
    public float EnemyZPosition;

    [SerializeField]
    [Tooltip("生成する範囲A")]
    private Transform rangeA;

    [SerializeField]
    [Tooltip("生成する範囲B")]
    private Transform rangeB;

    void Start()
    {
        EnemyAdd();
    }
    void Update()
    {
        if (GameManager.Instance.mainGame && respawn)
        {
            Invoke("EnemyAdd", 1f);
            respawn = false;
        }
    }
    public void DestroyEnemy()
    {
        GameObject[] Enemys = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject EnemyObjects in Enemys)
        {
            Enemyid = 0;
            Destroy(EnemyObjects);
        }
        respawn = true;
    }
    public void EnemyAdd()
    {
        EnemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (EnemyCountMax > EnemyCount)
        {
            while (EnemyCount < EnemyCountMax)
            {
                if (Enemyid >= EnemyObject.Length) { Enemyid = 0; }
                // rangeAとrangeBのx座標の範囲内でランダムな数値を作成
                EnemyXPosition = Random.Range(rangeA.position.x, rangeB.position.x);
                // rangeAとrangeBのy座標の範囲内でランダムな数値を作成
                EnemyYPosition = Random.Range(rangeA.position.y, rangeB.position.y);
                // rangeAとrangeBのz座標の範囲内でランダムな数値を作成
                EnemyZPosition = Random.Range(rangeA.position.z, rangeB.position.z);
                Instantiate(EnemyObject[Enemyid], new Vector3(EnemyXPosition, EnemyYPosition, EnemyZPosition), Quaternion.Euler(0, 180, 0));
                Enemyid++;
                EnemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//指定した位置に三体の敵オブジェクトを配置する
public class EnemyAddObject : MonoBehaviour
{
    public GameObject[] EnemyObject;    

    private int Enemyid;

    public int EnemyCountMax = 10; //敵の生成数
    private int EnemyCount;  //敵の現存数

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
                while(EnemyCount < EnemyCountMax)
                {
                    if (Enemyid >= EnemyObject.Length) { Enemyid = 0; }
                    // rangeAとrangeBのx座標の範囲内でランダムな数値を作成
                    float x = Random.Range(rangeA.position.x, rangeB.position.x);
                    // rangeAとrangeBのy座標の範囲内でランダムな数値を作成
                    float y = Random.Range(rangeA.position.y, rangeB.position.y);
                    // rangeAとrangeBのz座標の範囲内でランダムな数値を作成
                    float z = Random.Range(rangeA.position.z, rangeB.position.z);
                    Instantiate(EnemyObject[Enemyid], new Vector3(0, 0, 0), Quaternion.Euler(0,180,0));
                    Enemyid++;
                    EnemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
                }
            }
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
    }

    /*public void EnemySpown()
    {
        EnemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        //Destroy(GameObject.FindWithTag("Enemy"));
        if (EnemyCountMax > EnemyCount)
        {
            for (int i = 0; i < EnemyCountMax; i++)
            {
                Enemyid = Random.Range(0, EnemyObject.Length);
                Instantiate(EnemyObject[Enemyid], EnemySpawnposition[i].position, Quaternion.identity);
            }
        }
    }*/
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//指定した位置に三体の敵オブジェクトを配置する
public class EnemyAddObject : Singleton<EnemyAddObject>
{
    public GameObject[] EnemyObject;

    public int Enemyid;

    public int EnemyCountMax = 10; //敵の生成数
    int EnemyCount;  //敵の現存数

    public float[] EnemyX;
    public float[] EnemyY;
    public float[] EnemyZ;

    [SerializeField]
    [Tooltip("生成する範囲A")]
    private Transform rangeA;

    [SerializeField]
    [Tooltip("生成する範囲B")]
    private Transform rangeB;
    private void Awake()
    {
        EnemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (EnemyCountMax > EnemyCount)
        {
            while (EnemyCount < EnemyCountMax)
            {
                if (Enemyid >= EnemyObject.Length) { Enemyid = 0; }
                // rangeAとrangeBのx座標の範囲内でランダムな数値を作成
                EnemyX[Enemyid] = Random.Range(rangeA.position.x, rangeB.position.x);
                // rangeAとrangeBのy座標の範囲内でランダムな数値を作成
                EnemyY[Enemyid] = Random.Range(rangeA.position.y, rangeB.position.y);
                // rangeAとrangeBのz座標の範囲内でランダムな数値を作成
                EnemyZ[Enemyid] = Random.Range(rangeA.position.z, rangeB.position.z);
                Instantiate(EnemyObject[Enemyid], new Vector3(EnemyX[Enemyid], EnemyY[Enemyid], EnemyZ[Enemyid]), Quaternion.Euler(0, 180, 0));
                Enemyid++;
                EnemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
            }
        }
    }
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
                    EnemyX[Enemyid] = Random.Range(rangeA.position.x, rangeB.position.x);
                    // rangeAとrangeBのy座標の範囲内でランダムな数値を作成
                    EnemyY[Enemyid] = Random.Range(rangeA.position.y, rangeB.position.y);
                    // rangeAとrangeBのz座標の範囲内でランダムな数値を作成
                    EnemyZ[Enemyid] = Random.Range(rangeA.position.z, rangeB.position.z);
                    Instantiate(EnemyObject[Enemyid], new Vector3(EnemyX[Enemyid], EnemyY[Enemyid], EnemyZ[Enemyid]), Quaternion.Euler(0,180,0));
                    Enemyid++;
                    EnemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
                    //Debug.Log(EnemyX + "Xです"+ EnemyY+"Yです" + EnemyZ+ " Zです");
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

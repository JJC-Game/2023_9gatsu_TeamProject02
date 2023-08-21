using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//指定した位置に三体の敵オブジェクトを配置する
public class EnemyAddObject : MonoBehaviour
{
    public GameObject[] EnemyObject;    
    /* 
     * COMMENT_KUWABARA　敵キャラクターのプレハブを納めておくためのリストなので、変数名を修正してほしいです.
     * １．Objectという単語だと、インスタンスをさしているのか、プレハブをさしているのかわからない.
     * ２．EnemyObjectと書いてあると、１つのオブジェクトを格納した変数だと思われるが、実態はリスト.
    */

    private int Enemyid;
    // COMMENT_KUWABARA おそらく意味合いとしては、numではなくて、idか、indexだと思います。また、この変数はパブリックにしておく意味がありますか？.

    public Transform[] EnemySpawnposition;
    // COMMENT_KUWABARA 敵の何の座標？敵が湧く座標なら、EnemySpawnPositionです。また、これもListという名前にしてください.

    private int EnemyCountMax;
    private int EnemyCount;
    // COMMENT_KUWABARA　これも、パブリックの意味が薄いと感じます.
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
                for (int i = 0; i < EnemySpawnposition.Length; i++)
                {
                    // rangeAとrangeBのx座標の範囲内でランダムな数値を作成
                    float x = Random.Range(rangeA.position.x, rangeB.position.x);
                    // rangeAとrangeBのy座標の範囲内でランダムな数値を作成
                    float y = Random.Range(rangeA.position.y, rangeB.position.y);
                    // rangeAとrangeBのz座標の範囲内でランダムな数値を作成
                    float z = Random.Range(rangeA.position.z, rangeB.position.z);
                    Enemyid = Random.Range(0, EnemyObject.Length);
                    Instantiate(EnemyObject[Enemyid], new Vector3(x, y, z), Quaternion.Euler(0,180,0));
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
            for (int i = 0; i < EnemySpawnposition.Length; i++)
            {
                Enemyid = Random.Range(0, EnemyObject.Length);
                Instantiate(EnemyObject[Enemyid], EnemySpawnposition[i].position, Quaternion.identity);
            }
        }
    }


}

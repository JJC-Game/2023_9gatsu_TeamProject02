using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyNavnesh : MonoBehaviour
{
    // 移動の方法
    enum MoveType
    {
        ルートを巡回,
    }

    // 移動方法をエディターに表示
    // 表示したいが、他のところからアクセスさせたくない
    [SerializeField] private MoveType type;
    // public MoveType type;
    // 他からアクセスしたいが、表示はしたくない
    // [System.NonSerialized] public MoveType type;
    //                        ↳ 無くてもいい

    // 追跡したい対象
    GameObject target;

    // ルート移動用のポイント設定
    [SerializeField] GameObject[] routePoint;
    int nextPoint;

    // NavMeshAgentコンポーネント用
    NavMeshAgent nav;

    // 索敵をしている子オブジェクト
    // [SerializeField] GameObject searchObject;
    void Start()
    {
        // 追跡したい対象をTagから検索
        target = GameObject.FindGameObjectWithTag("Player");

        // コンポーネントを取得
        nav = GetComponent<NavMeshAgent>();
        routePoint = GameObject.FindGameObjectsWithTag("EnemyRoute");

    }
    void Update()
    {
        // ゲームごとの移動法を実行
        switch (type)
        {
            case MoveType.ルートを巡回:
                routePatrol();
                break;
        }
    }
    // ルート移動の処理
    void routePatrol()
    {
        // 目標地点に近づいたら次の拠点を設定
        if (nav.pathPending == false && nav.remainingDistance <= 0.1f)
        {
            // 次の地点のポイントを目標に
            nav.destination = routePoint[nextPoint].transform.position;

            // 配列の次の値を設定、次がなければ０に戻る
            nextPoint = (nextPoint + 1) % routePoint.Length;
        }
    }
}
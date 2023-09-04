using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyNum : MonoBehaviour
{
    GameObject playerObj;
    Transform playerTransform;
    public int num;

    EnemyAddObject enemyAdd;

    void Start()
    {
        playerObj = GameObject.FindWithTag("Player");
        enemyAdd = GameObject.FindWithTag("EnemyAdd").GetComponent<EnemyAddObject>();
        playerTransform = playerObj.transform;
    }

    void Update()
    {
        transform.LookAt(playerTransform);
    }
    void OnDestroy()
    {
        enemyAdd.DestroyEnemy();
        return;
    }
}

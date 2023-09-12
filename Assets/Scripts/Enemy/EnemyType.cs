using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyType : MonoBehaviour
{
    [SerializeField] GameObject EnemyBulletPrefab;
    public float EnemyshotDelay;
    [SerializeField] private float EnemyshotSpeed;
    [SerializeField] private Transform Enemypos;
    enum EnemyAtackType
    {
        通常型,
        防御型,
        ドローン型,
    }
    [SerializeField] EnemyAtackType AtackType;
    Rigidbody rig;

    private void Awake()
    {
        if(ChangeScene.difficultyNum == 0)
        {
            AtackType = EnemyAtackType.防御型;
        }
        if (ChangeScene.difficultyNum == 1)
        {
            AtackType = EnemyAtackType.通常型;
            EnemyshotDelay = 10f;
        }
        if (ChangeScene.difficultyNum == 1)
        {
            AtackType = EnemyAtackType.通常型;
            EnemyshotDelay = Random.Range(6f,11f);
        }
    }
    void Start()
    {
        switch (AtackType)
        {
            case EnemyAtackType.通常型:
                InvokeRepeating("Normal", EnemyshotDelay, EnemyshotDelay);
                break;
            case EnemyAtackType.防御型:
                Defense();
                break;
            case EnemyAtackType.ドローン型:
                Drone();
                break;
        }
        Rigidbody rig = GetComponent<Rigidbody>();
    }
    void Update()
    {
       
    }

    private void Normal()
    {
        SoundManager.Instance.PlaySE_Game(1);
        GameObject shell = Instantiate(EnemyBulletPrefab, Enemypos.transform.position, Quaternion.Euler(90,0,0));
        Rigidbody shellRb = shell.GetComponent<Rigidbody>();
        // 弾速は自由に設定
        shellRb.AddForce(transform.forward * EnemyshotSpeed ,ForceMode.Impulse);

    }

    private void Defense()
    {

    }

    private void Drone()
    {

    }
}

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
    // Start is called before the first frame update
    void Start()
    {
        switch (AtackType)
        {
            case EnemyAtackType.通常型:
                InvokeRepeating("Normal", 0, EnemyshotDelay);
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

    // Update is called once per frame
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

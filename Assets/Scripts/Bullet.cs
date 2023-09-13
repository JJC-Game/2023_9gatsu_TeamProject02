using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    EnemyNum enemyNum;
    AimController aimcon;
    Calculation calc;
    float timer = 1.5f;
    bool destroyFlg = false;

    void Start()
    {
        aimcon = GameObject.FindWithTag("AimController").GetComponent<AimController>();
        calc = GameObject.FindWithTag("CalculationManager").GetComponent<Calculation>();
    }
    void Update()
    {
        
         if (timer > 0)
         {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                destroyFlg = true;
            }
         }
          if (destroyFlg)
          {
            Destroy(this.gameObject);
          }
        // COMMENT_KUWABARA 弾丸にインパルスで力を与えて飛ばした場合に、射程距離が正確にわからなくなってしまうため.
        // Time.deltaTimeと、bulletSpeed変数を用いて、少しずつ動かすことで、弾丸を飛ばしてほしいです.
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if(!calc.updateNum)
            {
                calc.ansnum -= calc.receiveNum;
            }
            calc.receiveNum = collision.gameObject.GetComponent<EnemyNum>().num;
            aimcon.hitEnemy = true;
            Vector3 effectPos = new Vector3(collision.transform.position.x,collision.transform.position.y +1.5f,collision.transform.position.z);
            GameObject DesEffect = Instantiate(EffectManager.Instance.StageFX[3], effectPos, Quaternion.identity);
            Destroy(DesEffect, 2f);
            Destroy(collision.gameObject);
            EnemyAddObject.Instance.DestroyEnemy();
            SoundManager.Instance.PlaySE_Game(3);
            destroyFlg = true;
        }
        if(collision.gameObject)
        {
            destroyFlg = true;
        }
    }
}

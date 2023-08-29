using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    AimController aimcon;
    float timer = 1.5f;


    void Start()
    {
        aimcon = GameObject.FindWithTag("AimController").GetComponent<AimController>();
    }
    void Update()
    {
        bool destroyFlg = false;
         if (timer > 0)
         {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                destroyFlg = true;
            }
         }
          if (aimcon.hitEnemy)
          {
            destroyFlg = true;
          }

          if (destroyFlg)
          {
            Destroy(this.gameObject);
          }
        // COMMENT_KUWABARA 弾丸にインパルスで力を与えて飛ばした場合に、射程距離が正確にわからなくなってしまうため.
        // Time.deltaTimeと、bulletSpeed変数を用いて、少しずつ動かすことで、弾丸を飛ばしてほしいです.
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            aimcon.hitEnemy = true;
        }
    }
}

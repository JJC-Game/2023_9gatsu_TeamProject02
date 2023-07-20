using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    AimController aimcon;

    void Start()
    {
        aimcon = GameObject.FindWithTag("AimController").GetComponent<AimController>();
        Destroy(this.gameObject, 2.0f);
    }
    void Update()
    {
        Destroy(this.gameObject, 2.0f);
        // COMMENT_KUWABARA 毎フレーム呼んでしまっています.
        // Destroyを2重に読んでほしくないので、弾丸の寿命をタイマーで設定しておいて、タイマーが条件を満たすか、あるいは、ヒットするか、どちらかが起きたら、Destroyをするようにしてください.
        /*
         * bool destroyFlag = false;
         * if(timer > 0){
         *      timer -= Time.deltaTime;
         *      if(timer <= 0){
         *          destroyFlag = true;
         *      }
         *  }
         *  if (aimcon.hitEnemy) {
         *      destroyFlag = true;
         *  }
         *  
         *  if(destroyFlag){
         *      Destroy(this.gameObject);
         *  }
         */

        if (aimcon.hitEnemy) { Destroy(this.gameObject); }

        // COMMENT_KUWABARA 弾丸にインパルスで力を与えて飛ばした場合に、射程距離が正確にわからなくなってしまうため.
        // Time.deltaTimeと、bulletSpeed変数を用いて、少しずつ動かすことで、弾丸を飛ばしてほしいです.
    }

    void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Enemy":
                if (!aimcon.firstHit)
                {
                    Destroy(other.gameObject);
                    aimcon.firstHit = true;
                    aimcon.hitEnemy = true;
                    break;
                }
                if (!aimcon.secondHit)
                {
                    Destroy(other.gameObject);
                    aimcon.secondHit = true;
                    aimcon.hitEnemy = true;
                    break;
                }
                break;
            case "+":
                Destroy(other.gameObject);
                break;
        }
    }
}

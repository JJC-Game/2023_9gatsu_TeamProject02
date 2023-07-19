using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    AimController aimcon;

    void Start()
    {
        aimcon = GameObject.FindWithTag("AimController").GetComponent<AimController>();
    }
    void Update()
    {
        Destroy(this.gameObject, 2.0f);
        if (aimcon.hitEnemy) { Destroy(this.gameObject); }
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

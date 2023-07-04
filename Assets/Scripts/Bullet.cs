using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float bullSpeed = 10;

    Rigidbody bulletRig;

    void Start()
    {
        bulletRig = GetComponent<Rigidbody>();

        bulletRig.AddForce(bulletRig.mass * Vector3.forward * bullSpeed, ForceMode.Impulse);
    }

    void Update()
    {
        Destroy(this.gameObject, 2f);
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject)
        {
            Destroy(this.gameObject);
        }
    }
}

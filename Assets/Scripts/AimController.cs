using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AimController : MonoBehaviour
{
    public bool firstHit = false;
    public bool secondHit = false;
    public bool hitEnemy = false;

    [SerializeField] float shotSpeed;

    public GameObject bulletPre;
    // COMMENT_KUWABARA Pre、は、プレハブ（Prefab）と、前（Previous）の二つの意味があるため、略称として使うと混乱を生じます.略さないでください.

    void Start()
    {

    }

    void Update()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        

        if(Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
            if (GameManager.Instance.pause)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
    void Fire()
    {
        GameObject bullet = Instantiate(bulletPre, transform.position,Quaternion.Euler(transform.parent.eulerAngles.x, transform.parent.eulerAngles.y, 0));
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.AddForce(transform.forward * shotSpeed,ForceMode.Impulse);
    }
    }

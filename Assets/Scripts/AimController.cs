using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AimController : MonoBehaviour
{
    public bool firstHit = false;
    public bool secondHit = false;
    public bool hitEnemy = false;

    public bool hitPlus = false;    //+符号
    public bool hitMinus = false; //－符号
    public bool hitAsterisk = false; //×符号
    public bool hitSlash = false;  //÷符号

    public bool hitSign = false;

    [SerializeField] float shotSpeed;

    public GameObject bulletPrefab;
    public Transform effectPos;

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
        GameObject bullet = Instantiate(bulletPrefab, transform.position,Quaternion.Euler(transform.parent.eulerAngles.x, transform.parent.eulerAngles.y, 0));
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        GameObject shotEffect = Instantiate(EffectManager.Instance.playerFX[0], effectPos.position, Quaternion.Euler(transform.parent.eulerAngles.x, transform.parent.eulerAngles.y, 0));
        Destroy(shotEffect, 0.3f);
        bulletRb.AddForce(transform.forward * shotSpeed,ForceMode.Impulse);
    }
}

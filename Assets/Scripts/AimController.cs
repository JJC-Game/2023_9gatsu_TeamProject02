using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

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

    [SerializeField] CinemachineVirtualCamera vcame;

    [SerializeField] GameObject dot, croos;

    [SerializeField] float maxFOV = 90;
    [SerializeField] float minFOV = 40;


    void Start()
    {
        dot.SetActive(false);
        croos.SetActive(true);
    }

    void Update()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        if (GameManager.Instance.pause)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        if(GameManager.Instance.mainGame)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Fire();
            }

            if (Input.GetButtonDown("Fire2"))
            {
                vcame.m_Lens.FieldOfView = minFOV;
                croos.SetActive(false);
                dot.SetActive(true);
            }
            if (Input.GetButtonUp("Fire2"))
            {
                vcame.m_Lens.FieldOfView = maxFOV;
                croos.SetActive(true);
                dot.SetActive(false);
            }
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

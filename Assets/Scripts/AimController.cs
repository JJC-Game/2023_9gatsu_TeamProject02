using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class AimController : MonoBehaviour
{
    public bool hitEnemy = false;

    public bool hitSign = false;

    bool povReset;

    [SerializeField] float shotSpeed;

    public GameObject bulletPrefab;
    public Transform effectPos;

    [SerializeField] CinemachineVirtualCamera vcame;
    [SerializeField] GameObject dot, croos;

    [SerializeField] float maxFOV = 90;
    [SerializeField] float minFOV = 40;

    CinemachinePOV cinemachinePOV;

    float currentHorSp = 0.5f;
    float currentVerSp = 0.5f;

    private void Awake()
    {
        cinemachinePOV = vcame.GetCinemachineComponent<CinemachinePOV>();

        currentHorSp = cinemachinePOV.m_HorizontalAxis.m_MaxSpeed;
        currentVerSp = cinemachinePOV.m_VerticalAxis.m_MaxSpeed;
    }

    void Start()
    {
        dot.SetActive(false);
        croos.SetActive(true);
    }

    void Update()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        if (GameManager.Instance.mainGame && povReset)
        {
            cinemachinePOV.m_HorizontalAxis.m_MaxSpeed = currentHorSp;
            cinemachinePOV.m_VerticalAxis.m_MaxSpeed = currentVerSp;
            povReset = false;
        }
        if (!GameManager.Instance.mainGame)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            cinemachinePOV.m_HorizontalAxis.m_MaxSpeed = 0;
            cinemachinePOV.m_VerticalAxis.m_MaxSpeed = 0;
            povReset = true;
        }

        if(GameManager.Instance.mainGame)
        {
            if (Input.GetButtonDown("Fire1") && !GameManager.Instance.stun)
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
        SoundManager.Instance.PlaySE_Game(0);
        GameObject bullet = Instantiate(bulletPrefab, transform.position,Quaternion.Euler(transform.parent.eulerAngles.x, transform.parent.eulerAngles.y, 0));
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        GameObject shotEffect = Instantiate(EffectManager.Instance.playerFX[0], effectPos.position, Quaternion.Euler(transform.parent.eulerAngles.x - 90, transform.parent.eulerAngles.y, transform.parent.eulerAngles.z));
        Destroy(shotEffect, 0.3f);
        bulletRb.AddForce(transform.forward * shotSpeed,ForceMode.Impulse);
    }
}

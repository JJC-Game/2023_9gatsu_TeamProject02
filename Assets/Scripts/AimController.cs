﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AimController : MonoBehaviour
{

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

        if(GameManager.Instance.pause)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
    public void Fire()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 50f))
        {
            if(hit.collider.CompareTag("Enemy"))
            {
                Destroy(hit.collider.gameObject, 2f);
            }
        }
        Debug.DrawRay(ray.origin, ray.direction * 50, Color.red, 2);
    }
}

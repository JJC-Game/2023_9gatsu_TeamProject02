using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Scope : MonoBehaviour
{

    [SerializeField] CinemachineVirtualCamera vcame;

    [SerializeField] GameObject dot , croos;

    [SerializeField] float maxFOV = 90;
    [SerializeField] float minFOV = 40;

    void Start()
    {
        dot.SetActive(false);
        croos.SetActive(true);
    }
    void Update()
    {

        if (Input.GetButtonDown("Fire2"))
        {
            vcame.m_Lens.FieldOfView = minFOV;
            croos.SetActive(false);
            dot.SetActive(true);
        }
        if(Input.GetButtonUp("Fire2"))
        {
            vcame.m_Lens.FieldOfView = maxFOV;
            croos.SetActive(true);
            dot.SetActive(false);
        }
    }
    
}

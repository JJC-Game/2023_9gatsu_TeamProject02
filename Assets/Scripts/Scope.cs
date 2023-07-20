using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Scope : MonoBehaviour
{

    [SerializeField] CinemachineVirtualCamera vcame;

    [SerializeField] float maxFOV = 90;
    [SerializeField] float minFOV = 10;

    void Start()
    {
        
    }
    void Update()
    {

        if (Input.GetButtonDown("Fire2"))
        {
            vcame.m_Lens.FieldOfView = minFOV;
        }
        if(Input.GetButtonUp("Fire2"))
        {
            vcame.m_Lens.FieldOfView = maxFOV;
        }
    }
    
}

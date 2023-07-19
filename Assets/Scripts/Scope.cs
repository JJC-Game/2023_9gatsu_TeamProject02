using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Scope : MonoBehaviour
{

    [SerializeField] CinemachineVirtualCamera vcame;

    [SerializeField] float beFOV = 90;
    [SerializeField] float stFOV = 10;

    void Start()
    {
        
    }
    void Update()
    {

        if (Input.GetButton("Fire2"))
        {
            vcame.m_Lens.FieldOfView = stFOV;
        }
        if(Input.GetButtonUp("Fire2"))
        {
            vcame.m_Lens.FieldOfView = beFOV;
        }
    }
    
}

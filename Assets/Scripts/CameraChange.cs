using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraChange : MonoBehaviour
{
    public CinemachineVirtualCamera vcame;

    void Awake()
    {
        if (!GameManager.Instance.mainGame)
        {
            vcame.Priority = 1;
        }
    }
    void Start()
    {
    }

    void Update()
    {
        if(GameManager.Instance.mainGame)
        {
            vcame.Priority = 11;
        }
    }
}

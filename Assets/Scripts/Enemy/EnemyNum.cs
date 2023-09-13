using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyNum : MonoBehaviour
{
    GameObject playerObj;
    Transform playerTransform;
    public int num;

    void Start()
    {
        playerObj = GameObject.FindWithTag("Player");
        playerTransform = playerObj.transform;
    }

    void Update()
    {
        transform.LookAt(playerTransform);
    }
}

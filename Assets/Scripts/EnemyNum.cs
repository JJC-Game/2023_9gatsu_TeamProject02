using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyNum : MonoBehaviour
{
    GameObject playerObj;
    Transform playerTransform;
    public int num;

    Calculation calc;

    void Start()
    {
        calc = GameObject.FindWithTag("CalculationManager").GetComponent<Calculation>();
        playerObj = GameObject.FindWithTag("Player");
        playerTransform = playerObj.transform;
    }

    void Update()
    {
        transform.LookAt(playerTransform);
    }
    void OnDestroy()
    {
        calc.receiveNum = num;
        return;
    }
}

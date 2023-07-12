using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyNum : MonoBehaviour
{

    public int num;

    Calculation calc;

    void Start()
    {
        calc = GameObject.FindWithTag("CalculationManager").GetComponent<Calculation>();
    }

    void Update()
    {
    }
    void OnDestroy()
    {
        calc.receiveNum = num;
        return;
    }
}

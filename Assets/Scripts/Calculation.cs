using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Calculation : MonoBehaviour
{
    public float receiveNum;
    public float num1;
    public float num2;

    public TextMeshProUGUI firNum;
    public TextMeshProUGUI secNum;
    public TextMeshProUGUI ansNum;

    public bool calculation = false;
    public bool destroy = false;

    public AimController aimcon;

    void Start()
    {
    }

    void Update()
    {
       if(destroy)
        {
            NumUpdate();
            destroy = false;
        }

        if (aimcon.firstHit && aimcon.secondHit)
        {
            calculation = true;
        }

    }
    public void NumUpdate()
    {
        if (aimcon.firstHit)
        {
            num1 = receiveNum;
            firNum.text = num1.ToString("0");
            return;
        }
        if (aimcon.secondHit)
        {
            num2 = receiveNum;
            secNum.text = num2.ToString("0");
            return;
        }
    }
}

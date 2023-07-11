using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Calculation : MonoBehaviour
{
    public float receiveNum;
    public float num1;
    public float num2;
    float ansnum;
    float lagTime;
    float timer;

    public TextMeshProUGUI firNum;
    public TextMeshProUGUI secNum;
    public TextMeshProUGUI ansNum;

    public bool calculation = false;
    public bool destroy = false;
    public bool starthit = false;

    public AimController aimcon;

    void Start()
    {
        lagTime = 1.5f;
        timer = 0f;
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
            aimcon.secondHit = false;
            ansnum = num1 + num2;
            ansNum.text = ansnum.ToString("0");
            num1 = ansnum;
            firNum.text = num1.ToString("0");

        }

    }
    public void NumUpdate()
    {
        if (!starthit && aimcon.firstHit && !aimcon.secondHit)
        {
            starthit = true;
            num1 = receiveNum;
            firNum.text = num1.ToString("0");
            return;
        }
        if (aimcon.firstHit && aimcon.secondHit)
        {
            num2 = receiveNum;
            secNum.text = num2.ToString("0");
            return;
        }
    }
}

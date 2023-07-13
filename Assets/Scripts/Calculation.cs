using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Calculation : MonoBehaviour
{
    public int receiveNum;
    public int num1;
    public int num2;
    int ansnum;
    int goalnum;
    float lagTime;
    float timer;

    public TextMeshProUGUI firNum;
    public TextMeshProUGUI secNum;
    public TextMeshProUGUI ansNum;
    public TextMeshProUGUI goalNum;

    public bool calculation = false;
    public bool starthit = false;
    bool challenge = false;      //問題挑戦中
    public bool error = false;            //制限時間を超えたかを判定する

    public AimController aimcon;

    void Start()
    {
        lagTime = 1.5f;
        timer = 0f;
    }

    void Update()
    {
        Judgement();

        if(Input.GetKeyDown(KeyCode.Return))
        {
            if (aimcon.firstHit && aimcon.secondHit)
           {
                calculation = true;
                aimcon.secondHit = false;
                ansnum = num1 + num2;
                ansNum.text = ansnum.ToString("0");
                num1 = ansnum;
                firNum.text = num1.ToString("0");
                secNum.text = ("0");
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            NumReset();
        }

        if (GameManager.Instance.mainGame && !challenge)
        {
            Challenge();
        }

       if (aimcon.hitEnemy)
      {
            NumUpdate();
            aimcon.hitEnemy = false;
       }
    }

    void NumUpdate()
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
    void Challenge()
    {
        challenge = true;
        goalnum = Random.Range(2, 40);
        goalNum.text = goalnum.ToString("0");
    }
    void Judgement()  //合否の判定
    {
        if(goalnum == num1 || goalnum == ansnum)
        {
            NumInit();
            challenge = false;
            calculation = false;
            GameManager.Instance.qCurrent++;
        }
        if(goalnum < num1 || goalnum < ansnum)
        {
            NumInit();
            challenge = false;
            calculation = false;
        }
    }
    void NumInit() //数値初期化
    {
        num1 = 0;
        num2 = 0;
        ansnum = 0;
        firNum.text = num1.ToString("0");
        secNum.text = num2.ToString("0");
        ansNum.text = ansnum.ToString("0");
        aimcon.firstHit = false;
        aimcon.secondHit = false;
        starthit = false;
    }
    void  NumReset()
    {
        if (!calculation)
        {
            num1 = 0;
            firNum.text = num1.ToString("0");
            aimcon.firstHit = false;
            starthit = false;
        }
        num2 = 0;
        secNum.text = num2.ToString("0");
        aimcon.secondHit = false;
    }
}

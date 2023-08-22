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
    public int judgenum;
    public int rangeLow;
    public int rangeHight;
    public int signType; //符号のタイプ
    float lagTime;
    float timer;

    public TextMeshProUGUI firNum;
    public TextMeshProUGUI secNum;
    public TextMeshProUGUI ansNum;
    public TextMeshProUGUI signNum;

    bool challenge = false;      //問題挑戦中
    public bool timeover = false;  //制限時間を超えたかを判定する

    public AimController aimcon;

    void Start()
    {
        lagTime = 1.5f;
        timer = 0f;
        Challenge();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            CalculationStart();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            NumInit();
            SignInit();
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
       if(aimcon.hitSign)
        {
            SignUpdate();
            aimcon.hitSign = false;
        }
    }

    void NumUpdate()
    {
        if ( aimcon.firstHit && !aimcon.secondHit)
        {
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
    void SignUpdate()
    {
        if(aimcon.hitPlus)
        {
            aimcon.hitPlus = false;
            signType = 0;
            signNum.text = ("+");
            return;
        }
        if (aimcon.hitMinus)
        {
            aimcon.hitMinus = false;
            signType = 1;
            signNum.text = ("−");
            return;
        }
        if (aimcon.hitAsterisk)
        {
            aimcon.hitAsterisk = false;
            signType = 2;
            signNum.text = ("×");
            return;
        }
        if (aimcon.hitSlash)
        {
            aimcon.hitSlash = false;
            signType = 3;
            signNum.text = ("÷");
            return;
        }
    }
    void CalculationStart()
    {
        if (aimcon.firstHit && aimcon.secondHit)
        {
            switch (signType)
            {
                case 0:
                    aimcon.secondHit = false;
                    judgenum = num1 + num2;
                    Judgement();
                    break;
                case 1:
                    aimcon.secondHit = false;
                    judgenum = num1 - num2;
                    Judgement();
                    break;
                case 2:
                    aimcon.secondHit = false;
                    judgenum = num1 * num2;
                    Judgement();
                    break;
                case 3:
                    aimcon.secondHit = false;
                    judgenum = num1 / num2;
                    Judgement();
                    break;
            }
            return;
        }
        if(aimcon.hitPlus)
        {
            judgenum = num1 + num2;
            Judgement();
            return;
        }
        if (aimcon.hitMinus)
        {
            judgenum = num1 - num2;
            Judgement();
            return;
        }
        if (aimcon.hitAsterisk)
        {
            judgenum = num1 * num2;
            Judgement();
            return;
        }
        if (aimcon.hitSlash)
        {
            judgenum = num1 / num2;
            Judgement();
            return;
        }
    }
    void Challenge()
    {
        challenge = true;
        ansnum = Random.Range(rangeLow, rangeHight);
        ansNum.text = ansnum.ToString("0");
    }
    void Judgement()  //合否の判定
    {
        if(num1 == ansnum || judgenum == ansnum)
        {
            NumInit();
            challenge = false;
            GameManager.Instance.qCurrent += 1;
        }
        if(ansnum < num1 || ansnum < judgenum)
        {
            NumInit();
            challenge = false;
        }
    }
    void NumInit() //数値初期化
    {
        num1 = 0;
        num2 = 0;
        firNum.text = ("?");
        secNum.text = ("?");
        aimcon.firstHit = false;
        aimcon.secondHit = false;
    }
    void SignInit()
    {
        signNum.text = ("?");
        aimcon.hitPlus = false;
        aimcon.hitMinus = false;
        aimcon.hitAsterisk = false;
        aimcon.hitSlash = false;
    }
}

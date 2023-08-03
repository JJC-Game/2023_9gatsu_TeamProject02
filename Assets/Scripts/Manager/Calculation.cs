using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Calculation : MonoBehaviour
{
    public int receiveNum;
    public int num1;
    public int num2;
    public string sign; 
    int ansnum;
    int judgenum;
    public int rangeLow;
    public int rangeHight;
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
            SignInit();
            aimcon.hitPlus = true;
            signNum.text = ("＋");
        }
        if (aimcon.hitMinus)
        {
            SignInit();
            aimcon.hitMinus = true;
            signNum.text = ("−");
        }
        if (aimcon.hitAsterisk)
        {
            SignInit();
            aimcon.hitAsterisk = true;
            signNum.text = ("×");
        }
        if (aimcon.hitSlash)
        {
            SignInit();
            aimcon.hitSlash = true;
            signNum.text = ("÷");
        }
    }
    void CalculationStart()
    {
        if (aimcon.firstHit && aimcon.secondHit)
        {
            aimcon.secondHit = false;
            judgenum = num1 + num2;
            firNum.text = ("0");
            secNum.text = ("0");
            Judgement();
            return;
        }
        if(aimcon.hitPlus)
        {

            return;
        }
        if (aimcon.hitMinus)
        {

            return;
        }
        if (aimcon.hitAsterisk)
        {

            return;
        }
        if (aimcon.hitSlash)
        {

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
        firNum.text = num1.ToString("?");
        secNum.text = num2.ToString("?");
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

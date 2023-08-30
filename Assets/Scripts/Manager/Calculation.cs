using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Calculation : MonoBehaviour
{
    public int receiveNum;
    public int num1;
    public int num2;
    int adjustmentNum;
    int ansnum;
    public int judgenum;

    enum DifficultyType
    {
        Eaey,
        Normal,
        Hard,
    }
    [SerializeField] DifficultyType difficulty;

    enum SignType
    {
        足し算,
        引き算,
        掛け算,
        割り算,
    }
    [SerializeField] SignType signType;

    public TextMeshProUGUI Num1;
    public TextMeshProUGUI Num2;
    public TextMeshProUGUI ansNum;
    public TextMeshProUGUI signNum;

    bool challenge = false;      //問題挑戦中
    public bool timeover = false;  //制限時間を超えたかを判定する

    public AimController aimcon;

    void Start()
    {
        switch(signType)
        {
            case SignType.足し算:
                signNum.text = ("+");
                break;
            case SignType.引き算:
                signNum.text = ("−");
                break;
            case SignType.掛け算:
                signNum.text = ("×");
                break;
            case SignType.割り算:
                signNum.text = ("÷");
                break;
        }
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
        switch(difficulty)
        {
            case DifficultyType.Eaey:
                num2 = receiveNum;
                Num2.text = num2.ToString("0");
                break;
            case DifficultyType.Normal:

                break;
            case DifficultyType.Hard:

                break;
        }
    }
   
    void CalculationStart()
    {
        switch (signType)
        {
            case SignType.足し算:
                judgenum = num1 + num2;
                Judgement();
                break;
            case SignType.引き算:
                judgenum = num1 - num2;
                Judgement();
                break;
            case SignType.掛け算:
                judgenum = num1 * num2;
                Judgement();
                break;
            case SignType.割り算:
                judgenum = num1 / num2;
                Judgement();
                break;
        }
    }
    void Challenge()
    {
        challenge = true;
        switch (signType)
        {
            case SignType.足し算:
                switch (difficulty)
                {
                    case DifficultyType.Eaey:
                        ansnum = Random.Range(1, 15);
                        ansNum.text = ansnum.ToString("0");
                        adjustmentNum = Random.Range(0, 3);
                        num1 = ansnum / 2;
                        if (num1 > adjustmentNum) { num1 = num1 - adjustmentNum; }
                        Num1.text = num1.ToString("0");
                        break;
                    case DifficultyType.Normal:
                        num1 = Random.Range(5, 26);
                        num2 = Random.Range(5, 26);
                        Num1.text = num1.ToString("0");
                        Num2.text = num2.ToString("0");
                        break;
                    case DifficultyType.Hard:
                        num1 = Random.Range(10, 51);
                        num2 = Random.Range(10, 50);
                        Num1.text = num1.ToString("0");
                        Num2.text = num2.ToString("0");
                        break;
                }
                break;
            case SignType.引き算:
                switch (difficulty)
                {
                    case DifficultyType.Eaey:
                        num1 = Random.Range(1, 15);
                        Num1.text = num1.ToString("0");
                        adjustmentNum = Random.Range(0, 3);
                        ansnum = num1 / 2;
                        if (ansnum > adjustmentNum) { ansnum = ansnum - adjustmentNum; }
                        ansNum.text = ansnum.ToString("0");
                        break;
                    case DifficultyType.Normal:
                        num1 = Random.Range(10, 51);
                        num2 = Random.Range(1, num1);
                        Num1.text = num1.ToString("0");
                        Num2.text = num2.ToString("0");
                        break;
                    case DifficultyType.Hard:
                        num1 = Random.Range(20, 101);
                        num2 = Random.Range(1, num1);
                        Num1.text = num1.ToString("0");
                        Num2.text = num2.ToString("0");
                        break;
                }
                break;
            case SignType.掛け算:
                switch (difficulty)
                {
                    case DifficultyType.Eaey:
                        num1 = Random.Range(1, 10);
                        ansnum = num1 * Random.Range(1, 6);
                        Num1.text = num1.ToString("0");
                        ansNum.text = ansnum.ToString("0");
                        break;
                    case DifficultyType.Normal:
                        num1 = Random.Range(1, 10);
                        num2 = Random.Range(1, 10 );
                        Num1.text = num1.ToString("0");
                        Num2.text = num2.ToString("0");
                        break;
                    case DifficultyType.Hard:
                        num1 = Random.Range(3,16);
                        num2 = Random.Range(3,16);
                        Num1.text = num1.ToString("0");
                        Num2.text = num2.ToString("0");
                        break;
                }
                break;
            case SignType.割り算:
                switch (difficulty)
                {
                    case DifficultyType.Eaey:
                        ansNum.text = ansnum.ToString("0");
                        Num1.text = num1.ToString("0");
                        break;
                    case DifficultyType.Normal:
                        Num1.text = num1.ToString("0");
                        Num2.text = num2.ToString("0");
                        break;
                    case DifficultyType.Hard:
                        Num1.text = num1.ToString("0");
                        Num2.text = num2.ToString("0");
                        break;
                }
                break;
        }
    }
    void Judgement()  //合否の判定
    {
        if(judgenum == ansnum)
        {
            NumInit();
            challenge = false;
            GameManager.Instance.CorrectCountCurrent++;
            GameManager.Instance.CorrectCountText.text = GameManager.Instance.CorrectCountCurrent.ToString("0");
            GameManager.Instance.questionCurrent++;
            return;
        }
        if(ansnum != judgenum)
        {
            NumInit();
            challenge = false;
            GameManager.Instance.InCorrectCountCurrent++;
            GameManager.Instance.InCorrectCountText.text = GameManager.Instance.InCorrectCountCurrent.ToString("0");
            GameManager.Instance.questionCurrent++;
            return;
        }
    }
    void NumInit() //数値初期化
    {
        num2 = 0;
        Num2.text = ("?");
    }
}

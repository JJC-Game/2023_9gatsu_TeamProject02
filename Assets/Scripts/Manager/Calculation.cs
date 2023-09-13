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
    public int ansnum;
    public int judgenum;

    public float timer;
    float timerMax = 35;

    [SerializeField] GameObject CorrentCanvas;
    [SerializeField] GameObject IncorrentCanvas;

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
    public TextMeshProUGUI timerText;

    bool challenge = false;      //問題挑戦中
    public bool timeover = false;  //制限時間を超えたかを判定する

    public bool computable = false; //割り算が計算可能か判別する

    public bool firsthit = false;
    public bool secondhit = false;
    public bool thirdhit = false;
    public bool updateNum = true;

    bool judgement = false;

    public AimController aimcon;

    private void Awake()
    {
        if(ChangeScene.difficultyNum == 0)
        {
            difficulty = DifficultyType.Eaey;
            if(ChangeScene.signTypeNum == 0)
            {
                signType = SignType.足し算;
                return;
            }
            if (ChangeScene.signTypeNum == 1)
            {
                signType = SignType.引き算;
                return;
            }
            if (ChangeScene.signTypeNum == 2)
            {
                signType = SignType.掛け算;
                return;
            }
            if (ChangeScene.signTypeNum == 3)
            {
                signType = SignType.割り算;
                return;
            }
        }
        if (ChangeScene.difficultyNum == 1)
        {
            difficulty = DifficultyType.Normal;
            if (ChangeScene.signTypeNum == 0)
            {
                signType = SignType.足し算;
                return;
            }
            if (ChangeScene.signTypeNum == 1)
            {
                signType = SignType.引き算;
                return;
            }
            if (ChangeScene.signTypeNum == 2)
            {
                signType = SignType.掛け算;
                return;
            }
            if (ChangeScene.signTypeNum == 3)
            {
                signType = SignType.割り算;
                return;
            }
        }
        if (ChangeScene.difficultyNum == 2)
        {
            difficulty = DifficultyType.Hard;
            if (ChangeScene.signTypeNum == 0)
            {
                signType = SignType.足し算;
                return;
            }
            if (ChangeScene.signTypeNum == 1)
            {
                signType = SignType.引き算;
                return;
            }
            if (ChangeScene.signTypeNum == 2)
            {
                signType = SignType.掛け算;
                return;
            }
            if (ChangeScene.signTypeNum == 3)
            {
                signType = SignType.割り算;
                return;
            }
        }
    }

    void Start()
    {
        CanvasOff();

        switch (signType)
        {
            case SignType.足し算:
                signNum.text = ("+");
                break;
            case SignType.引き算:
                signNum.text = ("-");
                break;
            case SignType.掛け算:
                signNum.text = ("×");
                break;
            case SignType.割り算:
                signNum.text = ("÷");
                break;
        }
        timer = timerMax;
    }

    void Update()
    {
        if (GameManager.Instance.mainGame)
        {
            if (judgement || !updateNum || timeover)
            {
                timeover = false;
                judgement = false;
                Judgement();
            }
            if (GameManager.Instance.mainGame && !challenge)
            {
                Challenge();
                Invoke("CanvasOff", 0.5f);
            }
            if (aimcon.hitEnemy)
            {
                NumUpdate();
                aimcon.hitEnemy = false;
                Inspection();
            }
            timer = Mathf.Clamp(timer, 0f, timerMax);
            if (challenge)
            {
                ChallengeTimer();
            }
        }
    }

    void NumUpdate()
    {
        switch(difficulty)
        {
            case DifficultyType.Eaey:
                num2 = receiveNum;
                Num2.text = num2.ToString("0");
                judgement = true;
                break;
            case DifficultyType.Normal:
                if(!firsthit && !secondhit)
                {
                    ansnum = receiveNum;
                    ansNum.text = ansnum.ToString("0");
                    firsthit = true;
                    return;
                }
                if(firsthit && !secondhit)
                {
                    ansnum =   ansnum * 10 + receiveNum;
                    ansNum.text = ansnum.ToString("0");
                    secondhit = true;
                    updateNum = false;
                    return;
                }
                break;
            case DifficultyType.Hard:
                if (!firsthit && !secondhit && !thirdhit)
                {
                    ansnum = receiveNum;
                    ansNum.text = ansnum.ToString("0");
                    firsthit = true;
                    return;
                }
                if (firsthit && !secondhit && !thirdhit)
                {
                    ansnum = ansnum * 10 + receiveNum;
                    ansNum.text = ansnum.ToString("0");
                    secondhit = true;
                    return;
                }
                if(firsthit && secondhit && !thirdhit)
                {
                    ansnum = ansnum * 10 + receiveNum;
                    ansNum.text = ansnum.ToString("0");
                    thirdhit = true;
                    updateNum = false;
                    return;
                }
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
                        num2 = Random.Range(10, 51);
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
                        num2 = Random.Range(1, 10);
                        Num1.text = num1.ToString("0");
                        Num2.text = num2.ToString("0");
                        break;
                    case DifficultyType.Hard:
                        num1 = Random.Range(3,16);
                        num2 = Random.Range(3,11);
                        Num1.text = num1.ToString("0");
                        Num2.text = num2.ToString("0");
                        break;
                }
                break;
            case SignType.割り算:
                switch (difficulty)
                {
                    case DifficultyType.Eaey:
                        while(!computable)
                        {
                            if (computable) { break; }
                            num1 = Random.Range(6, 20);
                            NumFix();
                        }
                        ansnum = Random.Range(2, num1 + 1);
                        while (num1 % ansnum != 0)
                        {
                            ansnum = Random.Range(2, num1+1);
                        }
                        Num1.text = num1.ToString("0");
                        ansNum.text = ansnum.ToString("0");
                        break;
                    case DifficultyType.Normal:
                        while (!computable)
                        {
                            if (computable) { break; }
                            num1 = Random.Range(6, 61);
                            NumFix();
                        }
                        num2 = Random.Range(2, num1 + 1);
                        while (num1 % num2 != 0)
                        {
                            num2 = Random.Range(2, num1 + 1);
                        }
                        Num1.text = num1.ToString("0");
                        Num2.text = num2.ToString("0");
                        break;
                    case DifficultyType.Hard:
                        while (!computable)
                        {
                            if (computable) { break; }
                            num1 = Random.Range(6, 101);
                            NumFix();
                        }
                        num2 = Random.Range(2, num1 + 1);
                        while (num1 % num2 != 0)
                        {
                            num2 = Random.Range(2, num1 + 1);
                        }
                        Num1.text = num1.ToString("0");
                        Num2.text = num2.ToString("0");
                        break;
                }
                break;
        }
    }
    void Inspection()
    {
        switch(signType)
        {
            case SignType.足し算:
                judgenum = num1 + num2;
                if (judgenum == ansnum) { judgement = true; }
                break;
            case SignType.引き算:
                judgenum = num1 - num2;
                if (judgenum == ansnum) { judgement = true; }
                break;
            case SignType.掛け算:
                judgenum = num1 * num2;
                if (judgenum == ansnum) { judgement = true; }
                break;
            case SignType.割り算:
                if(num2 == 0)
                {
                    judgement = true;
                    return;
                }
                judgenum = num1 / num2;
                if (judgenum == ansnum) { judgement = true; }
                break;
        }
    }
    void Judgement()  //合否の判定
    {
        if(judgenum == ansnum)
        {
            CorrentCanvas.SetActive(true);
            SoundManager.Instance.PlaySE_Sys(1);
            challenge = false;
            if (computable) { computable = false; }
            GameManager.Instance.CorrectCountCurrent++;
            GameManager.Instance.CorrectCountText.text = GameManager.Instance.CorrectCountCurrent.ToString("0");
            GameManager.Instance.questionCurrent++;
            NumInit();
            return;
        }
        if(judgenum != ansnum)
        {
            IncorrentCanvas.SetActive(true);
            SoundManager.Instance.PlaySE_Sys(2);
            challenge = false;
            if (computable) { computable = false; }
            GameManager.Instance.InCorrectCountCurrent++;
            GameManager.Instance.InCorrectCountText.text = GameManager.Instance.InCorrectCountCurrent.ToString("0");
            GameManager.Instance.questionCurrent++.ToString("0");
            NumInit();
            return;
        }
    }
    void ChallengeTimer()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            timerText.text = timer.ToString("0.0");
            if (timer <= 0)
            {
                timeover = true;
            }
        }
    }
    void NumInit() //数値初期化
    {
        num2 = 0;
        Num2.text = ("?");
        ansnum = 0;
        ansNum.text = ("?");
        timer = timerMax;
        firsthit = false;
        secondhit = false;
        thirdhit = false;
        updateNum = true;
    }
    void NumFix() //割り算で素数判定するためのもの
    {
        if (num1 < 2)
        {
            computable = true;
            return;
        }
        if (num1 == 2 || num1 == 3)
        {
            computable = false;
            return;
        }
        if (num1 % 2 == 0)
        {
            computable = true;
            return;
        }

        double sqrtX = Mathf.Sqrt(num1);
        for (long i = 3; i < sqrtX; i += 2)
        {
            if (num1 % i == 0)
            {
                computable = true;
                return;
            }

            if (num1 / i <= i) break;
        }
        computable = false;
        return;
    }
    void CanvasOff()
    {
        CorrentCanvas.SetActive(false);
        IncorrentCanvas.SetActive(false);
    }
}

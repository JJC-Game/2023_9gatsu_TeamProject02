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
    int judgenum;
    public int rangeLow;
    public int rangeHight;
    float lagTime;
    float timer;

    public TextMeshProUGUI firNum;
    public TextMeshProUGUI secNum;
    public TextMeshProUGUI ansNum;

    bool challenge = false;      //問題挑戦中
    public bool error = false;            //制限時間を超えたかを判定する
    // COMMENT_KUWABARA　エラー判定は今後いろいろ出てくると思うので、何のエラーか、も変数名に情報として含めてください.

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
            if (aimcon.firstHit && aimcon.secondHit)
           {
                aimcon.secondHit = false;
                judgenum = num1 + num2;
                firNum.text = ("0");
                secNum.text = ("0");
                Judgement();
            }
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
        firNum.text = num1.ToString("0");
        secNum.text = num2.ToString("0");
        aimcon.firstHit = false;
        aimcon.secondHit = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using TMPro;

public class GameManager : Singleton<GameManager>
{
    [Header("ゲーム進行に必要なフラグ")]
    public bool mainGame = false;    //ゲーム中
    public bool gameClear = false;    //ゲームクリア
    public bool gameOver = false;    //ゲームオーバー
    public bool stun = false;             //スタン中
    public bool deadLimit = false;     //ゲームオーバー条件
    public bool pause = false;           //一時停止

    [Header("PlayableDirector")]
    [SerializeField] PlayableDirector GameStartTimeline;
    [SerializeField] PlayableDirector GameClearTimeline;
    [SerializeField] PlayableDirector GameOverTimeline;

    [Header("Canvas( 0:main, 1:pause, 2:start, 3:clear, 4:over)")]
    [SerializeField] GameObject[] UI;

    [Header("問題に必要な変数")]
    public int CorrectCountCurrent = 0;   //正解数
    public int InCorrectCountCurrent = 0;  //不正解数

    public int questionCurrent = 0;   //解答数
    public int CorrectCountMax = 10;  //問題数

    public int InCorrectCountMax = 5; //ゲームオーバーになる不正解数
    
    public TextMeshProUGUI CorrectCountText;
    public TextMeshProUGUI InCorrectCountText;

    float stunTime;
    public float stunTimeMax = 3f;
    [Header("テスト用HP")]
    public float playerHP = 10;

    void Awake()
    {
        CanvasInit();
        UI[2].SetActive(true);
    }
    void Start()
    {
       GameStartTimeline.Play();
       CorrectCountText.text = ("0");
       InCorrectCountText.text = ("0");
        stunTime = stunTimeMax;
    }

    void Update()
    {
        if(GameStartTimeline.state == PlayState.Playing && Input.GetKeyDown(KeyCode.Space))
        {
            DemoSkip();
        }
        if(Input.GetKeyDown(KeyCode.P))
        {
            Pause();
        }
        if(CorrectCountMax == questionCurrent || Input.GetKeyDown(KeyCode.F1))
        {
            GameClearTimeline.Play();
            GameClear();
            Debug.Log("ゲームクリア");
        }
        if(InCorrectCountMax == InCorrectCountCurrent || Input.GetKeyDown(KeyCode.F2) || playerHP <= 0)
        {
            GameOverTimeline.Play();
            GameOver();
            Debug.Log("ゲームオーバー");
        }
        if (stun)
        {
          if(stunTime > 0)
            {
                stunTime -= Time.deltaTime;
                if (stunTime <= 0)
                {
                    stun = false;
                    stunTime = stunTimeMax;
                }
            }
        }
    }

    public void MainGame()
    {
        mainGame = true;
        CanvasInit();
        UI[0].SetActive(true);
    }
    public void DemoSkip()
    {
        mainGame = true;
        GameStartTimeline.Stop();
        CanvasInit();
        UI[0].SetActive(true);
    }
    public void Pause()
    {
        if(!pause && mainGame)
        {
            mainGame = false;
            pause = true;
            Time.timeScale = 0;
            CanvasInit();
            UI[1].SetActive(true);
            return;
        }
        
    }

    void GameClear()
    {
        mainGame = false;
        gameClear = true;
        CanvasInit();
        UI[3].SetActive(true);
    }

    void GameOver()
    {
        mainGame = false;
        gameOver = true;
        CanvasInit();
        UI[4].SetActive(true);
    }
    public void CanvasInit()
    {
        for(int i = 0; i < UI.Length; i++)
        {
            UI[i].SetActive(false);
        }
    }
    public void Pauseclick()
    {
        mainGame = true;
        pause = false;
        Time.timeScale = 1;
        CanvasInit();
        UI[0].SetActive(true);
    }
}

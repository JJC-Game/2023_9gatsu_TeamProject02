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
    [SerializeField] PlayableDirector GameStart;

    [Header("Canvas( 0:main, 1:pause, 2:time, 3:start, 4:clear, 5:over)")]
    [SerializeField] GameObject[] UI;

    [Header("問題に必要な変数")]
    public int qCurrent = 0;
    public int qMax = 5;
    public int errorCurrent = 0;
    public int errorMax = 3;

    void Awake()
    {
        CanvasInit();
        UI[3].SetActive(true);
    }
    void Start()
    {
       GameStart.Play();
    }

    void Update()
    {
        if(GameStart.state == PlayState.Playing && Input.GetKeyDown(KeyCode.Space))
        {
            DemoSkip();
        }

        if(Input.GetKeyDown(KeyCode.P))
        {
            Pause();
        }
        if(qMax == qCurrent || Input.GetKeyDown(KeyCode.F1))
        {
            GameClear();
            Debug.Log("ゲームクリアした");
        }
        if(errorMax == errorCurrent || Input.GetKeyDown(KeyCode.F2))
        {
            GameOver();
            Debug.Log("ゲームオーバー");
        }
    }

    public void MainGame()
    {
        mainGame = true;
        CanvasInit();
        UI[0].SetActive(true);
        UI[2].SetActive(true);
    }
    public void DemoSkip()
    {
        mainGame = true;
        GameStart.Stop();
        CanvasInit();
        UI[0].SetActive(true);
        UI[2].SetActive(true);
    }
    public void Pause()
    {
        if(!pause && mainGame)
        {
            pause = true;
            Time.timeScale = 0;
            CanvasInit();
            UI[1].SetActive(true);
            UI[2].SetActive(true);
            return;
        }
        if(pause)
        {
            pause = false;
            Time.timeScale = 1;
            CanvasInit();
            UI[0].SetActive(true);
            UI[2].SetActive(true);
            return;
        }
    }

    void GameClear()
    {
        mainGame = false;
        gameClear = true;
        CanvasInit();
        UI[4].SetActive(true);
    }

    void GameOver()
    {
        mainGame = false;
        gameOver = true;
        CanvasInit();
        UI[5].SetActive(true);
    }
    public void CanvasInit()
    {
        for(int i = 0; i < UI.Length; i++)
        {
            UI[i].SetActive(false);
        }
    }
}

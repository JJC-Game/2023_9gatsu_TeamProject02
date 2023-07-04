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
    public bool error = false;            //問題を間違えたか
    public bool stun = false;             //スタン中
    public bool deadLimit = false;     //ゲームオーバー寸前
    public bool pause = false;           //一時停止

    [Header("PlayableDirector")]
    [SerializeField] PlayableDirector GameStart;

    [Header("使用Canvas")]
    [SerializeField] GameObject MainGameUI;
    [SerializeField] GameObject StartUI;
    [SerializeField] GameObject PauseUI;

    [Header("問題に必要な変数")]
    int qCurrent = 0;
    public int qMax = 5;
    int errorCurrent = 0;
    public int errorMax = 3;

    void Awake()
    {
        MainGameUI.SetActive(false);
        StartUI.SetActive(true);
        PauseUI.SetActive(false);
    }
    void Start()
    {
       GameStart.Play();
        PauseUI.SetActive(false);
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
    }

    public void MainGame()
    {
        mainGame = true;
        StartUI.SetActive(false);
        MainGameUI.SetActive(true);
    }
    public void DemoSkip()
    {
        mainGame = true;
        GameStart.Stop();

        StartUI.SetActive(false);
        MainGameUI.SetActive(true);
    }
    public void Pause()
    {
        if(!pause && mainGame)
        {
            pause = true;
            Time.timeScale = 0;
            MainGameUI.SetActive(false);
            PauseUI.SetActive(true);
            return;
        }
        if(pause)
        {
            pause = false;
            Time.timeScale = 1;
            PauseUI.SetActive(false);
            MainGameUI.SetActive(true);
            return;
        }
    }
}

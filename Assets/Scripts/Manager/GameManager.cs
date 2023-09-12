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
    bool startTimeLine;

    [Header("PlayableDirector")]
    [SerializeField] PlayableDirector GameStartTimeline;
    [SerializeField] PlayableDirector GameClearTimeline;
    [SerializeField] PlayableDirector GameOverTimeline;

    [SerializeField] GameObject startCam;

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
    public float stunTimeMax = 1f;
    bool stunEffectOn;
    [SerializeField] GameObject StunEffectpos;

    void Awake()
    {
        CanvasInit();
        UI[2].SetActive(true);
    }
    void Start()
    {
       GameStartTimeline.Play();
        startTimeLine = true;
       CorrectCountText.text = ("0");
       InCorrectCountText.text = ("0");
       stunTime = stunTimeMax;
    }

    void Update()
    {
        if(startTimeLine && Input.GetKeyDown(KeyCode.Space))
        {
            DemoSkip();
        }
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            Pause();
        }
        if(CorrectCountMax == questionCurrent || Input.GetKeyDown(KeyCode.F1))
        {
            GameClearTimeline.Play();
            GameClear();
            Debug.Log("ゲームクリア");
        }
        if(InCorrectCountMax == InCorrectCountCurrent || Input.GetKeyDown(KeyCode.F2))
        {
            GameOverTimeline.Play();
            GameOver();
            Debug.Log("ゲームオーバー");
        }
        if (stun)
        {
            if(!stunEffectOn)
            {
                SoundManager.Instance.PlaySE_Game(2);
                stunEffectOn = true;
                GameObject shotEffect = Instantiate(EffectManager.Instance.StageFX[2], StunEffectpos.transform.position,Quaternion.identity);
                Destroy(shotEffect,2.2f);
            }
            if (stunTime > 0)
            {
                stunTime -= Time.deltaTime;
                if (stunTime <= 0)
                {
                    stun = false;
                    stunEffectOn = false;
                    stunTime = stunTimeMax;
                }
            }
        }
    }

    public void MainGame()
    {
        mainGame = true;
        GameStartTimeline.Stop();
        startTimeLine = false;
        CanvasInit();
        UI[0].SetActive(true);
        SoundManager.Instance.PlayBGM(1);
        startCam.SetActive(false);
    }
    public void DemoSkip()
    {
        mainGame = true;
        GameStartTimeline.Stop();
        startTimeLine = false;
        CanvasInit();
        UI[0].SetActive(true);
        startCam.SetActive(false);
    }
    public void Pause()
    {
        if(!pause && mainGame)
        {
            mainGame = false;
            pause = true;
            CanvasInit();
            UI[1].SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void SceneChange()
    {
        mainGame = false;
        pause = false;
        Time.timeScale = 1;
        CanvasInit();
    }

    void GameClear()
    {
        EnemyAddObject.Instance.DestroyEnemy();
        SoundManager.Instance.StopBGM();
        mainGame = false;
        gameClear = true;
        CanvasInit();
        UI[3].SetActive(true);
    }

    void GameOver()
    {
        EnemyAddObject.Instance.DestroyEnemy();
        SoundManager.Instance.StopBGM();
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
        SoundManager.Instance.PlaySE_Sys(0);
        mainGame = true;
        pause = false;
        Time.timeScale = 1;
        CanvasInit();
        UI[0].SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using TMPro;

public class GameManager : Singleton<GameManager>
{
    [Header("�Q�[���i�s�ɕK�v�ȃt���O")]
    public bool mainGame = false;    //�Q�[����
    public bool gameClear = false;    //�Q�[���N���A
    public bool gameOver = false;    //�Q�[���I�[�o�[
    public bool error = false;            //�����ԈႦ����
    public bool stun = false;             //�X�^����
    public bool deadLimit = false;     //�Q�[���I�[�o�[���O
    public bool pause = false;           //�ꎞ��~

    [Header("PlayableDirector")]
    [SerializeField] PlayableDirector GameStart;

    [Header("�g�pCanvas")]
    [SerializeField] GameObject MainGameUI;
    [SerializeField] GameObject StartUI;
    [SerializeField] GameObject PauseUI;

    [Header("���ɕK�v�ȕϐ�")]
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

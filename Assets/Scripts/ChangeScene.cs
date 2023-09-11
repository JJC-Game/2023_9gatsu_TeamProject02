using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public static int difficultyNum;
    public static int signTypeNum;

    void Start()
    {
        
    }

    void Update()
    {
    }

    public void GameScene()
    {
        SoundManager.Instance.PlaySE_Sys(0);
        GameManager.Instance.SceneChange();
        Scene scene = SceneManager.GetActiveScene();
        int buildIndex = scene.buildIndex;
        SceneManager.LoadScene(buildIndex);
    }
    public void TitleScene()
    {
        SoundManager.Instance.PlaySE_Sys(0);
        GameManager.Instance.SceneChange();
        FadeManager.Instance.LoadSceneIndex(0, 1);
    }
    public void AddEasyScene()
    {
        SoundManager.Instance.PlaySE_Sys(0);
        difficultyNum = 0;
        signTypeNum = 0;
        FadeManager.Instance.LoadSceneIndex(1, 1);
    }
    public void AddNormalScene()
    {
        SoundManager.Instance.PlaySE_Sys(0);
        difficultyNum = 1;
        signTypeNum = 0;
        FadeManager.Instance.LoadSceneIndex(2, 1);
    }
    public void AddHardScene()
    {
        SoundManager.Instance.PlaySE_Sys(0);
        difficultyNum = 2;
        signTypeNum = 0;
        FadeManager.Instance.LoadSceneIndex(3, 1);
    }
    public void SubEasyScene()
    {
        SoundManager.Instance.PlaySE_Sys(0);
        difficultyNum = 0;
        signTypeNum = 1;
        FadeManager.Instance.LoadSceneIndex(1, 1);
    }
    public void SubNormalScene()
    {
        SoundManager.Instance.PlaySE_Sys(0);
        difficultyNum = 1;
        signTypeNum = 1;
        FadeManager.Instance.LoadSceneIndex(2, 1);
    }
    public void SubHardScene()
    {
        SoundManager.Instance.PlaySE_Sys(0);
        difficultyNum = 2;
        signTypeNum = 1;
        FadeManager.Instance.LoadSceneIndex(3, 1);
    }
    public void MultiEasyScene()
    {
        SoundManager.Instance.PlaySE_Sys(0);
        difficultyNum = 0;
        signTypeNum = 2;
        FadeManager.Instance.LoadSceneIndex(1, 1);
    }
    public void MultiNormalScene()
    {
        SoundManager.Instance.PlaySE_Sys(0);
        difficultyNum = 1;
        signTypeNum = 2;
        FadeManager.Instance.LoadSceneIndex(2, 1);
    }
    public void MultiHardScene()
    {
        SoundManager.Instance.PlaySE_Sys(0);
        difficultyNum = 2;
        signTypeNum = 2;
        FadeManager.Instance.LoadSceneIndex(3, 1);
    }
    public void DivEasyScene()
    {
        SoundManager.Instance.PlaySE_Sys(0);
        difficultyNum = 0;
        signTypeNum = 3;
        FadeManager.Instance.LoadSceneIndex(1, 1);
    }
    public void DivNormalScene()
    {
        SoundManager.Instance.PlaySE_Sys(0);
        difficultyNum = 1;
        signTypeNum = 3;
        FadeManager.Instance.LoadSceneIndex(2, 1);
    }
    public void DivHardScene()
    {
        SoundManager.Instance.PlaySE_Sys(0);
        difficultyNum = 2;
        signTypeNum = 3;
        FadeManager.Instance.LoadSceneIndex(3, 1);
    }
}

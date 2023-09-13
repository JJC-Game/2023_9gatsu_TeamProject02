using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public static int difficultyNum;
    public static int signTypeNum;

    bool InputButton = false; //ボタン押した時のフラグ

    void Start()
    {
    }

    void Update()
    {
    }

    public void GameScene()
    {
        if (InputButton) return;
        InputButton = true;
        SoundManager.Instance.PlaySE_Sys(0);
        GameManager.Instance.SceneChange();
        Scene scene = SceneManager.GetActiveScene();
        int buildIndex = scene.buildIndex;
        SceneManager.LoadScene(buildIndex);
    }
    public void TitleScene()
    {
        if (InputButton)  return; 
        InputButton = true;
        SoundManager.Instance.PlaySE_Sys(0);
        GameManager.Instance.SceneChange();
        FadeManager.Instance.LoadSceneIndex(0, 1);
    }
    public void AddEasyScene()
    {
        if (InputButton) return;
        InputButton = true;
        SoundManager.Instance.PlaySE_Sys(0);
        difficultyNum = 0;
        signTypeNum = 0;
        FadeManager.Instance.LoadSceneIndex(1, 1);
    }
    public void AddNormalScene()
    {
        if (InputButton)  return;
        InputButton = true;
        SoundManager.Instance.PlaySE_Sys(0);
        difficultyNum = 1;
        signTypeNum = 0;
        FadeManager.Instance.LoadSceneIndex(2, 1);
    }
    public void AddHardScene()
    {
        if (InputButton) return; 
        InputButton = true;
        SoundManager.Instance.PlaySE_Sys(0);
        difficultyNum = 2;
        signTypeNum = 0;
        FadeManager.Instance.LoadSceneIndex(3, 1);
    }
    public void SubEasyScene()
    {
        if (InputButton) return; 
        InputButton = true;
        SoundManager.Instance.PlaySE_Sys(0);
        difficultyNum = 0;
        signTypeNum = 1;
        FadeManager.Instance.LoadSceneIndex(1, 1);
    }
    public void SubNormalScene()
    {
        if (InputButton) return; 
        InputButton = true;
        SoundManager.Instance.PlaySE_Sys(0);
        difficultyNum = 1;
        signTypeNum = 1;
        FadeManager.Instance.LoadSceneIndex(2, 1);
    }
    public void SubHardScene()
    {
        if (InputButton) return; 
        InputButton = true;
        SoundManager.Instance.PlaySE_Sys(0);
        difficultyNum = 2;
        signTypeNum = 1;
        FadeManager.Instance.LoadSceneIndex(3, 1);
    }
    public void MultiEasyScene()
    {
        if (InputButton) return; 
        InputButton = true;
        SoundManager.Instance.PlaySE_Sys(0);
        difficultyNum = 0;
        signTypeNum = 2;
        FadeManager.Instance.LoadSceneIndex(1, 1);
    }
    public void MultiNormalScene()
    {
        if (InputButton) return;
        InputButton = true;
        SoundManager.Instance.PlaySE_Sys(0);
        difficultyNum = 1;
        signTypeNum = 2;
        FadeManager.Instance.LoadSceneIndex(2, 1);
    }
    public void MultiHardScene()
    {
        if (InputButton) return;
        InputButton = true;
        SoundManager.Instance.PlaySE_Sys(0);
        difficultyNum = 2;
        signTypeNum = 2;
        FadeManager.Instance.LoadSceneIndex(3, 1);
    }
    public void DivEasyScene()
    {
        if (InputButton) return;
        InputButton = true;
        SoundManager.Instance.PlaySE_Sys(0);
        difficultyNum = 0;
        signTypeNum = 3;
        FadeManager.Instance.LoadSceneIndex(1, 1);
    }
    public void DivNormalScene()
    {
        if (InputButton) return;
        InputButton = true;
        SoundManager.Instance.PlaySE_Sys(0);
        difficultyNum = 1;
        signTypeNum = 3;
        FadeManager.Instance.LoadSceneIndex(2, 1);
    }
    public void DivHardScene()
    {
        if (InputButton) return;
        InputButton = true;
        SoundManager.Instance.PlaySE_Sys(0);
        difficultyNum = 2;
        signTypeNum = 3;
        FadeManager.Instance.LoadSceneIndex(3, 1);
    }
}

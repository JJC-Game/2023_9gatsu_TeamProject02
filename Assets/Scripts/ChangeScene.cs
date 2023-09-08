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
        GameManager.Instance.SceneChange();
        Scene scene = SceneManager.GetActiveScene();
        int buildIndex = scene.buildIndex;
        SceneManager.LoadScene(buildIndex);
    }
    public void TitleScene()
    {
        GameManager.Instance.SceneChange();
        FadeManager.Instance.LoadSceneIndex(0, 1);
    }
    public void AddEasyScene()
    {
        difficultyNum = 0;
        signTypeNum = 0;
        FadeManager.Instance.LoadSceneIndex(1, 1);
    }
    public void AddNormalScene()
    {
        difficultyNum = 1;
        signTypeNum = 0;
        FadeManager.Instance.LoadSceneIndex(2, 1);
    }
    public void AddHardScene()
    {
        difficultyNum = 2;
        signTypeNum = 0;
        FadeManager.Instance.LoadSceneIndex(3, 1);
    }
    public void SubEasyScene()
    {
        difficultyNum = 0;
        signTypeNum = 1;
        FadeManager.Instance.LoadSceneIndex(1, 1);
    }
    public void SubNormalScene()
    {
        difficultyNum = 1;
        signTypeNum = 1;
        FadeManager.Instance.LoadSceneIndex(2, 1);
    }
    public void SubHardScene()
    {
        difficultyNum = 2;
        signTypeNum = 1;
        FadeManager.Instance.LoadSceneIndex(3, 1);
    }
    public void MultiEasyScene()
    {
        difficultyNum = 0;
        signTypeNum = 2;
        FadeManager.Instance.LoadSceneIndex(1, 1);
    }
    public void MultiNormalScene()
    {
        difficultyNum = 1;
        signTypeNum = 2;
        FadeManager.Instance.LoadSceneIndex(2, 1);
    }
    public void MultiHardScene()
    {
        difficultyNum = 2;
        signTypeNum = 2;
        FadeManager.Instance.LoadSceneIndex(3, 1);
    }
    public void DivEasyScene()
    {
        difficultyNum = 0;
        signTypeNum = 3;
        FadeManager.Instance.LoadSceneIndex(1, 1);
    }
    public void DivNormalScene()
    {
        difficultyNum = 1;
        signTypeNum = 3;
        FadeManager.Instance.LoadSceneIndex(2, 1);
    }
    public void DivHardScene()
    {
        difficultyNum = 2;
        signTypeNum = 3;
        FadeManager.Instance.LoadSceneIndex(3, 1);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
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
    public void FPSSampleScene()
    {
        FadeManager.Instance.LoadSceneIndex(1, 1);
    }
    public void yamaguchiScene()
    {
        FadeManager.Instance.LoadSceneIndex(2,1);
    }
    public void Stage1Scene()
    {
        FadeManager.Instance.LoadSceneIndex(3, 1);
    }
    public void Stage2Scene()
    {
        FadeManager.Instance.LoadSceneIndex(4, 1);
    }
    public void Stage3Scene()
    {
        FadeManager.Instance.LoadSceneIndex(5, 1);
    }
}

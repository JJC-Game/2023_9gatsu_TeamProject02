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
        GameScene();
    }

    public void GameScene()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SceneManager.LoadScene("Stage1");
            // COMMENT_KUWABARA　シーンのインデックス番号を指定して遷移するのでなく、シーン名を指定して対象シーンを識別してください.
            // 数字で入力していると、将来インデックス番号が変動した時に不具合が生じます。そのうえで、エラーにはならないので、不具合を見つけるのが難しくなります.
            // 文字列で入力すると、シーン名が変動した場合にはエラーが起きるので、誤りが存在していることがすぐにわかります.
        }
    }
    public void TitleScene()
    {
        //GameManager.Instance.Pause();
        FadeManager.Instance.LoadSceneIndex(0, 1);
    }
    public void FPSSampleScene()
    {
        FadeManager.Instance.LoadSceneIndex(1, 1);
    }
    public void yamaguchiScene()
    {
        //GameManager.Instance.Pause();
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

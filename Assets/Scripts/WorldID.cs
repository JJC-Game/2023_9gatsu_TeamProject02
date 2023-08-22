using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldID : MonoBehaviour
{
    public float SceneID;

    /*public void Awake()
    {
        //もし他のオブジェクトの子であれば、親子関係を解除
        if (gameObject.transform.parent != null) gameObject.transform.parent = null;

        if (this != Instance)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);  //このスクリプトはシーン遷移しても削除しない
    }*/
    // Start is called before the first frame update
    void Start()
    {
        SceneID = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

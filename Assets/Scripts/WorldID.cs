using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldID : Singleton<WorldID>
{
    public float SceneID;

    public void Awake()
    {
        //もし他のオブジェクトの子であれば、親子関係を解除
        if (gameObject.transform.parent != null) gameObject.transform.parent = null;

        if (this != Instance)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);  //このスクリプトはシーン遷移しても削除しない
    }
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("IDUpdate", 0, 2);       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void IDUpdate()
    {
        SceneID = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("保持しているIDは" + SceneID);
    }
}

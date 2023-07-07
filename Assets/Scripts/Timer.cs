using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    private float countup = 0.0f;
    public TextMeshProUGUI timer;

    void Start()
    {
        
    }

    void Update()
    {
        if(GameManager.Instance.mainGame)
        {
            countup += Time.deltaTime;
            timer.text = countup.ToString("000.0");
        }
        if(GameManager.Instance.gameOver)
        {
            Time.timeScale = 0;
        }
    }
}

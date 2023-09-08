using System.Collections;
using UnityEngine;
using TMPro;

public class TextBlinker : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;
    public RectTransform a;
    public float X;//480
    public float Y;//476
    public float Interbal;
    [SerializeField] Vector3 HabaDistans = new Vector3(0, 2, 0);
    Vector3  HabaStartDistans;
    private void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        X = this.transform.position.x;
        Y = this.transform.position.y;
        HabaStartDistans = new Vector3 (480, 476, 0);
    }
    private void Update()
    {
        
        float sin = Mathf.Sin(Time.unscaledTime) * Interbal;
        //textMeshPro.fontSize = sin + 100;
        if (sin <= 0)
        {
            sin = sin * -1;
        }
        textMeshPro.alpha = 00 + sin;
    }
    void JOuge()
    {
        if (GameManager.Instance.pause == true)
        {
            float sin = Mathf.Sin(Time.unscaledTime) * Interbal;
            //textMeshPro.fontSize = sin + 100;
            if(sin <= 0)
            {
                sin = sin * -1;
            }
            textMeshPro.alpha = 00 + sin; 
            //a.transform.position = HabaStartDistans + (HabaDistans * sin);
        }
    }
}
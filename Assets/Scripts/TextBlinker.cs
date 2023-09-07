using System.Collections;
using UnityEngine;
using TMPro;

public class TextBlinker : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;
    public float blinkInterval = 1.0f; // 点滅の間隔（秒）
    private Coroutine blinkCoroutine;

    private void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        StartBlinking();
    }

    private void StartBlinking()
    {
        if (blinkCoroutine == null)
        {
            blinkCoroutine = StartCoroutine(BlinkTextCoroutine());
        }
    }

    private void StopBlinking()
    {
        if (blinkCoroutine != null)
        {
            StopCoroutine(blinkCoroutine);
            blinkCoroutine = null;
            textMeshPro.enabled = true; // 点滅停止時にテキストを表示
        }
    }

    private IEnumerator BlinkTextCoroutine()
    {
        while (true)
        {
            // テキストの表示/非表示を切り替える
            textMeshPro.enabled = !textMeshPro.enabled;

            // 次の点滅まで待つ
            yield return new WaitForSeconds(blinkInterval);
        }
    }

    private void Update()
    {
        if (GameManager.Instance.pause)
        {
            StopBlinking(); // ポーズ中は点滅を停止
        }
        else
        {
            StartBlinking(); // ポーズ解除時に点滅を再開
        }
    }
}


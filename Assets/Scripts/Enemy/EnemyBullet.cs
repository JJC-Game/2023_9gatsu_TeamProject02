using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public bool DestroyFLG;
    float timer = 5f;
    // Start is called before the first frame update
    void Start()
    {
        GameObject Enemyshoteffect = Instantiate(EffectManager.Instance.StageFX[1], transform.position, Quaternion.Euler(180,0,0));
        Destroy(Enemyshoteffect, 0.25f);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                DestroyFLG = true;
            }
        }
        if (DestroyFLG)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == ("Player"))
        {
            GameManager.Instance.playerHP--;
            DestroyFLG = true;

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject Enemyshoteffect = Instantiate(EffectManager.Instance.StageFX[1], transform.position, Quaternion.identity);
        Destroy(Enemyshoteffect, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == ("Player"))
        {

        }
    }
}

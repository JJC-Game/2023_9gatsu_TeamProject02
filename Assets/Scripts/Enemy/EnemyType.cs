using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyType : MonoBehaviour
{
    enum EnemyAtackType
    {
        通常型,
        防御型,
        ドローン型,
    }
    [SerializeField] EnemyAtackType AtackType;
    // Start is called before the first frame update
    void Start()
    {
        switch(AtackType)
        {
            case EnemyAtackType.通常型:
                InvokeRepeating("Normal",0, 5);
                break;
            case EnemyAtackType.防御型:
                Defense();
                break;
            case EnemyAtackType.ドローン型:
                Drone();
                break;
        }
        Rigidbody rig = GetComponent<Rigidbody>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Normal()
    {
        
    }

    private void Defense()
    {

    }

    private void Drone()
    {

    }
}

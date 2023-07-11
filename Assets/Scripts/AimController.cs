using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AimController : MonoBehaviour
{
    public bool firstHit = false;
    public bool secondHit = false;

    void Start()
    {
    }

    void Update()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        if(Input.GetButtonDown("Fire1"))
        {
            Fire();
        }

        if(GameManager.Instance.pause)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
    public void Fire()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 50f))
        {
             switch (hit.collider.gameObject.tag)
            {
                  case "Enemy":
                    if (!firstHit)
                    {
                        Destroy(hit.collider.gameObject);
                        firstHit = true;
                        break;
                    }
                    if (!secondHit)
                    {
                        Destroy(hit.collider.gameObject);
                        secondHit = true;
                        break;
                    }
                    break;
                  case "+":
                     break;
             }
        }
        Debug.DrawRay(ray.origin, ray.direction * 50, Color.red, 1.5f);
    }
}

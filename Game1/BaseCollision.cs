using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCollision : MonoBehaviour
{
    public static bool isColliding;

    void Start()
    {
        isColliding = false;
    }

    void OnTriggerEnter(Collider obj)
    {
        if (obj.tag == "Ship")
        {
            FindObjectOfType<AudioManager>().Play("Jump");
            isColliding = true;
            
        }
    }

    void OnTriggerExit(Collider obj)
    {
        isColliding = false;
    }

    // void Update()
    // {
    //     print(isColliding);
    // }
}

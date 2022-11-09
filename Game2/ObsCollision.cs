using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ObsCollision : MonoBehaviour
{

    GameObject nave;

    private void Awake()
    {
        nave = GameObject.FindGameObjectWithTag("Ship");
    }

    private void OnTriggerEnter(Collider obj)
    {
        if (obj.tag == "Ship")
        {
            Destroy(gameObject);
            ShipMovement.vidas--;
        }
    }


}

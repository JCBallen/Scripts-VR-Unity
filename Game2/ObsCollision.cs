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

            // Sounds Controllers
            if (ShipMovement.vidas > 1)
            {
                FindObjectOfType<AudioManager>().Play("ObsHit");

            }
            else
            {
                FindObjectOfType<AudioManager>().Play("DeathSFX");
            }

            
            Destroy(gameObject);
            ShipMovement.vidas--;
        }
    }


}

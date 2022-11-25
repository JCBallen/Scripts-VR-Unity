using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartsCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider obj)
    {
        if (obj.tag == "Ship")
        {
            FindObjectOfType<AudioManager>().Play("HeartHit");
            Destroy(gameObject);
            ShipMovement.vidas++;
        }
    }
}

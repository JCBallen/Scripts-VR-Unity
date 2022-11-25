using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider obj)
    {
        if (obj.tag == "Ship")
        {
            FindObjectOfType<AudioManager>().Play("CoinHit");
            Destroy(gameObject);
            ShipMovement.puntos++;
        }
    }
}

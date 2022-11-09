using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider obj)
    {
        if (obj.tag == "Ship")
        {
            Destroy(gameObject);
            ShipMovement.puntos++;
        }
    }
}

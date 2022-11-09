using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    public Transform shipPos;
    private float x;
    private float y;
    private Vector3 auxPos;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Tomamos como referencia la posicion de la nave para poner la camara
        auxPos = shipPos.position / 1f;
        auxPos.y = auxPos.y + 2; // +2
        auxPos.z = 3; // 3
        transform.position = auxPos;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsMovement : MonoBehaviour
{
    // ! Modificar La valocidad desde aqui
    public static float velocidad;
    public Transform ObsPos;

    Vector3 aum;

    // Start is called before the first frame update
    void Start()
    {

        velocidad = -20f;
        // el primer valor es la "velocidad" a la que se mueve en environment

    }

    // Update is called once per frame
    void Update()
    {
        aum = new Vector3(0, 0, velocidad * Time.deltaTime);
        transform.Translate(aum);
        // Calculo de la distancia recorrido
        ShipMovement.distancia = -(int)ObsPos.position.z + 23;
    }
}

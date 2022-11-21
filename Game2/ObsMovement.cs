using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsMovement : MonoBehaviour
{
    // ! Modificar La valocidad desde aqui
    public static float velocidad;
    public static float default_velocity;
    public Transform ObsPos;

    Vector3 aum;

    // Start is called before the first frame update
    void Start()
    {

        default_velocity = -20f;
        velocidad = default_velocity;
        // el primer valor es la "velocidad" a la que se mueve en environment

    }

    // Update is called once per frame
    void Update()
    {
        aum = new Vector3(0, 0, velocidad * Time.deltaTime);
        transform.Translate(aum);
        // Calculo de la distancia recorrido (xd no se por que lo puse aqui)
        ShipMovement.distancia = -(int)ObsPos.position.z + 23; // desfase para igualar a 0
    }
}

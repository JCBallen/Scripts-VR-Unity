using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMovement : MonoBehaviour
{
    // ! Modificar La valocidad desde aqui
    public static float velocidad;
    public Transform BasePos;

    Vector3 aum;

    // Start is called before the first frame update
    void Start()
    {

        velocidad = -10f;
        // el primer valor es la "velocidad" a la que se mueve en environment

    }

    // Update is called once per frame
    void Update()
    {
        aum = new Vector3(0, 0, velocidad * Time.deltaTime);
        transform.Translate(aum);
        // Calculo de la distancia recorrido
        BallMovement.distancia = -(int)BasePos.position.z + 1;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvMovement : MonoBehaviour
{
    // ! Modificar La valocidad desde aqui, default 20f
    public static float velocidad;
    public static float default_velocity;
    Vector3 aum;

    // Start is called before the first frame update
    void Start()
    {
        // el primer valor es la "velocidad" a la que se mueve en environment
        default_velocity = -20f;
        velocidad = default_velocity;
    }

    // Update is called once per frame
    void Update()
    {
        aum = new Vector3(0, 0, velocidad * Time.deltaTime); // default 20f
        transform.Translate(aum);
        print(velocidad);
    }
}

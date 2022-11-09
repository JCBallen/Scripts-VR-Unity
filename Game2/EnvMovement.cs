using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvMovement : MonoBehaviour
{
    // ! Modificar La valocidad desde aqui, default 20f
    public static float velocidad = 20f;
    Vector3 aum;

    // Start is called before the first frame update
    void Start()
    {

        // el primer valor es la "velocidad" a la que se mueve en environment

    }

    // Update is called once per frame
    void Update()
    {
        aum = new Vector3(velocidad * Time.deltaTime, 0, 0); // default 20f
        transform.Translate(aum);
    }
}

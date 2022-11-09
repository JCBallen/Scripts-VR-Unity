using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Up3dButton : MonoBehaviour
{
    public float t;
    public Transform Btn3D;
    // Antes todo seteado
    // Vector3 final = new Vector3(0, 1.5f, 3.5f);
    // Vector3 origen = new Vector3(0, 0.5f, 3.5f);
    // Vector3 sum = new Vector3(0, 0.5f, 0);

    // Ahora queremos que sea variable para cualquier boton,
    // este script funciona para x cantidad de botones
    Vector3 origen;
    Vector3 sum = new Vector3(0, 0.3f, 0); // Cantidad de elevacion del boton al hacer hover
    Vector3 final;

    private void Start()
    {
        //Primer tick guarda la pos inicial 
        origen = Btn3D.position;
        final = origen + sum;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 a = Btn3D.position;
        Vector3 b = final;
        Btn3D.position = Vector3.Lerp(a, b, t);
    }



}

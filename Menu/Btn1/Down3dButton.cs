using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Down3dButton : MonoBehaviour
{
    public float t;
    public Transform Btn3D;
    // Vector3 final = new Vector3(0, 1.5f, 3.5f);
    // Vector3 origen = new Vector3(0, 0.5f, 3.5f);
    Vector3 sum = new Vector3(0, 0.3f, 0);
    Vector3 origen;
    Vector3 final;

    // Es necesario duplicar este script para cada boton nuevo
    private void Start()
    {
        // Primer tick guarda pos inicial, por eso el final es alla, ya que actualmente esta arriba y quiere "bajar" a su pos inicial
        origen = Btn3D.position;
        final = origen - sum;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 a = Btn3D.position;
        Vector3 b = final;
        Btn3D.position = Vector3.Lerp(a, b, t);
    }
}

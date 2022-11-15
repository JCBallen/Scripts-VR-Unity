using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphQLController : MonoBehaviour
{
    
    public GameObject PostProcesado;
    // Start is called before the first frame update
    void Update()
    {
        if (GraphQuality.isHighQL)
        {
            PostProcesado.SetActive(true);
        }
        else
        {
            PostProcesado.SetActive(false);
        }
    }

}

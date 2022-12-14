using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphQuality : MonoBehaviour
{
    public static bool isHighQL = true;
    public RectTransform indicador;
    float t = 0.1f;


    public void HighQL()
    {
        isHighQL = true;
        FindObjectOfType<AudioManager>().Play("Selection");
    }

    public void LowQL()
    {
        isHighQL = false;
        FindObjectOfType<AudioManager>().Play("Selection");
    }

    void Update()
    {
        if (isHighQL)
        {
            Vector3 a = indicador.anchoredPosition3D;
            Vector3 b = new Vector3(indicador.anchoredPosition3D.x, 40f, indicador.anchoredPosition3D.z);
            indicador.anchoredPosition3D = Vector3.Lerp(a, b, t);
        }
        else
        {
            Vector3 a = indicador.anchoredPosition3D;
            Vector3 b = new Vector3(indicador.anchoredPosition3D.x, 8f, indicador.anchoredPosition3D.z);
            indicador.anchoredPosition3D = Vector3.Lerp(a, b, t);
        }
    }
}

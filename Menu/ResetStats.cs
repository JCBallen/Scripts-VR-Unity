using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetStats : MonoBehaviour
{
    public void setToZero()
    {
        try
        {
            FindObjectOfType<AudioManager>().Play("Selection");
            PlayerPrefs.SetInt("HSDistanciaGame1", 0);
            PlayerPrefs.SetInt("HSDistanciaGame2", 0);
        }
        catch
        {
            print("Nada que borrar");
        }
    }
}

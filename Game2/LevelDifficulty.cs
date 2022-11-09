using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDifficulty : MonoBehaviour
{
    public static int value;// valor de dificultad
    int aux;

    void Start()
    {
        aux = 100;
        value = 1;
    }
    void Update()
    {
        if (ShipMovement.distancia % 100 == 0 && aux < 0)
        {
            increaseDifficulty();
            aux = 100;
        }
        else
        {
            aux--;
        }
    }

    void increaseDifficulty()
    {
        value++;
        // print($"hard: {value}");
    }
}

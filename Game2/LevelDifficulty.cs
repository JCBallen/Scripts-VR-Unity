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
        if (ShipMovement.distancia % 50 == 0 && aux < 0 && value < 20)
        {
            increaseDifficulty();
            aux = 100;
            print("Dificultad aumentada");
        }
        else
        {
            aux--;
        }
    }

    void increaseDifficulty()
    {
        value++;
        EnvMovement.velocidad -= (value * 0.5f);
        ObsMovement.velocidad -= (value * 0.5f);
        // print($"hard: {value}");
    }
}

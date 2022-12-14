using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDifficulty : MonoBehaviour
{
    public static int value;// valor de dificultad
    int aux;
    bool isIncreasingvelocity;

    void Start()
    {
        aux = 100;
        isIncreasingvelocity = false;
        value = 1;
    }
    void Update()
    {
        if (ShipMovement.distancia % 1000 == 0 && aux < 0 && value < 12)
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
        if (isIncreasingvelocity)
        {
            // ? incrementa la velocidad de la nave
            EnvMovement.velocidad -= (10);
            ObsMovement.velocidad -= (10);
            isIncreasingvelocity = false;
        }
        else
        {
            // ? incrementa el spawn rate de los obstaculos
            value++;
            isIncreasingvelocity = true;
        }
    }
}

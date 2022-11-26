using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levels : MonoBehaviour
{

    public static int value; // valor de dificultad
    int aux;

    void Start()
    {
        aux = 50;
        value = 1;
    }
    void Update()
    {
        if (BallMovement.distancia % 300 == 0 && aux < 0 && value < 16)
        {
            increaseDifficulty();
            aux = 50;
        }
        else
        {
            aux--;
        }
    }

    void increaseDifficulty()
    {
        BallMovement.acceleration -= 1;
        value++;
    }
}





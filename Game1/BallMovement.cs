using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{

    public Transform CameraRot;
    public float t;
    public float velocidad_maxima = 10; // aumento por tick de la posicion
    public float inclinacion_maxima = 45; // grados
    public float factor_rotacion = 1.5f; // Factor de rotacion

    public static int vidas;
    public static int puntos;
    public static int distancia;
    public static int distanciaHS;

    int d_camera_ball;
    // es la distancia en z entre la camara y la nave
    float x, y, auxTime, acumulatedTime, initialVel, acceleration;

    void Start()
    {
        distancia = 0;
        puntos = 0;

        d_camera_ball = 10;
        t = 0.5f;
        initialVel = 10;
        acceleration = -20;
        acumulatedTime = 0;
    }


    // Update is called once per frame
    void Update()
    {
        auxTime = Time.realtimeSinceStartup - acumulatedTime;

        x = d_camera_ball * Mathf.Tan(Mathf.PI * CameraRot.eulerAngles.y / 180);
        
        y = -2.3f + initialVel * (auxTime) + acceleration * Mathf.Pow(auxTime, 2) / 2;

        if (transform.position.y <= -2.3)
        {
            Jump();
        }

        // Movimiento suavizado con Lerp (a = desde , b = hasta)
        Vector3 a = transform.position;
        Vector3 b = new Vector3(x, y, transform.position.z);
        transform.position = Vector3.Lerp(a, b, t);


    }

    void Jump()
    {
        acumulatedTime = Time.realtimeSinceStartup;
    }

}

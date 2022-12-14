using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{

    public Transform CameraRot;
    public Animator animator;
    public float t;

    public static int vidas;
    public static int puntos;
    public static int distancia;
    public static int distanciaHS;
    public static float acceleration;
    int caux;

    // es la distancia en z entre la camara y la nave
    int d_camera_ball;
    float x, y, auxTime, acumulatedTime, initialVel;


    void Start()
    {
        vidas = 1;
        distancia = 0;
        puntos = 0;

        d_camera_ball = 10;
        t = 0.5f;
        initialVel = 10;  //def 10
        acceleration = -20; //def -20
        acumulatedTime = 0;

        caux = 0;
        Jump();
    }

    // Update is called once per frame
    void Update()
    {
        // Animation cotroller
        if (BaseCollision.isColliding && caux < 0)
        {
            caux = 5;
            animator.SetBool("isColliding", true);
        }
        else
        {
            animator.SetBool("isColliding", false);
            caux--;
        }



        auxTime = Time.realtimeSinceStartup - acumulatedTime;
        // x is controlled by camera rotation
        x = d_camera_ball * Mathf.Tan(Mathf.PI * CameraRot.eulerAngles.y / 180);
        // y is controlled by math, parabolic movement
        y = -2f + initialVel * (auxTime) + acceleration * Mathf.Pow(auxTime, 2) / 2;


        // temp if die
        if (BaseCollision.isColliding)
        {
            Jump();
        }

        // death
        if (transform.position.y <= -20)
        {
            vidas--;
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

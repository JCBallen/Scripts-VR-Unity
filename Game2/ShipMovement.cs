using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public Transform CameraRot;
    public float t;
    public float velocidad_maxima = 14f + (Mathf.Abs(EnvMovement.velocidad - 20f) * 3f); // aumento por tick de la posicion
    public float inclinacion_maxima = 60f; // grados
    public float factor_rotacion = 1.5f; // Factor de rotacion

    public static int vidas;
    public static int puntos;
    public static int distancia;
    public static int distanciaHS;


    // private float x;
    // private float y;
    // private Vector3 auxPos;
    // private Vector3 originPos = new Vector3(0, 0, 11); // unused
    // private Vector3 planePos; // Proyeccion del avion en el plano 2d segun mirada // unused
    // Start is called before the first frame update
    void Start()
    {
        vidas = 3;
        puntos = 0;
        distancia = 0;
    }

    // Update is called once per frame
    void Update()
    {


        // rotacion de la nave igual a la camara
        transform.rotation = Quaternion.Euler(CameraRot.rotation.eulerAngles.x * factor_rotacion, CameraRot.rotation.eulerAngles.y * factor_rotacion, CameraRot.rotation.eulerAngles.z * factor_rotacion);
        // transform.rotation = CameraRot.rotation;


        // Full trigonometria para el movimiento en y
        // 11 es la distancia en z entre la camara y la nave
        // y = 11 * Mathf.Tan(Mathf.PI * CameraRot.eulerAngles.x / 180);
        // x = 11 * Mathf.Tan(Mathf.PI * CameraRot.eulerAngles.y / 180);

        // planePos = new Vector3(x, -y + 3, 11);

        // Movimiento suavizado con Lerp (a = desde , b = hasta)

        // Limites del movimientos de la nave, respecto a el angulo de la camara
        // Parte rotacion en x parte arriba
        float opcX = CameraRot.eulerAngles.x;
        float opcY = CameraRot.eulerAngles.y;


        // 
        if (!BorderLimits.isInYLimits)
        {
            //arriba
            if (opcX > 360 - inclinacion_maxima && opcX < 360)
            {
                // Ej : opc=350
                float valRot = -1 * (opcX - 360); // 10
                float velocidad_proporcional = valRot * velocidad_maxima / inclinacion_maxima; //regla de tres (10*10/45)

                Vector3 a = transform.position;
                Vector3 b = new Vector3(transform.position.x, transform.position.y + velocidad_proporcional, transform.position.z);
                transform.position = Vector3.Lerp(a, b, t);
                // transform.Translate(0, velocidad_proporcional * Time.deltaTime, 0);

            }


            // switch (opcX)
            // {
            //     case float n when (n < 355 && n >= 350):
            //         Vector3 a = transform.position;
            //         Vector3 b = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
            //         transform.position = Vector3.Lerp(a, b, t);
            //         break;
            //     case float n when (n < 350 && n >= 345):
            //         a = transform.position;
            //         b = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
            //         transform.position = Vector3.Lerp(a, b, t);
            //         break;
            //     case float n when (n < 345 && n >= 340):
            //         a = transform.position;
            //         b = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z);
            //         transform.position = Vector3.Lerp(a, b, t);
            //         break;
            //     case float n when (n < 340 && n >= 335):
            //         a = transform.position;
            //         b = new Vector3(transform.position.x, transform.position.y + 3f, transform.position.z);
            //         transform.position = Vector3.Lerp(a, b, t);
            //         break;
            //     case float n when (n < 335 && n >= 270):
            //         a = transform.position;
            //         b = new Vector3(transform.position.x, transform.position.y + 5f, transform.position.z);
            //         transform.position = Vector3.Lerp(a, b, t);
            //         break;

            //     default:
            //         // print("noooo");
            //         break;
            // }


            //abajo
            if (opcX > 0 && opcX < inclinacion_maxima)
            {
                float velocidad_proporcional = opcX * velocidad_maxima / inclinacion_maxima; //regla de tres

                Vector3 a = transform.position;
                Vector3 b = new Vector3(transform.position.x, transform.position.y - velocidad_proporcional, transform.position.z);
                transform.position = Vector3.Lerp(a, b, t);
                // transform.Translate(0, -velocidad_proporcional * Time.deltaTime, 0);

            }
        } // if YLimits

        // switch (opcX)
        // {
        //     case float n when (n < 10 && n >= 5):
        //         Vector3 a = transform.position;
        //         Vector3 b = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
        //         transform.position = Vector3.Lerp(a, b, t);
        //         break;
        //     case float n when (n < 15 && n >= 10):
        //         a = transform.position;
        //         b = new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z);
        //         transform.position = Vector3.Lerp(a, b, t);
        //         break;
        //     case float n when (n < 20 && n >= 15):
        //         a = transform.position;
        //         b = new Vector3(transform.position.x, transform.position.y - 2f, transform.position.z);
        //         transform.position = Vector3.Lerp(a, b, t);
        //         break;
        //     case float n when (n < 25 && n >= 20):
        //         a = transform.position;
        //         b = new Vector3(transform.position.x, transform.position.y - 3f, transform.position.z);
        //         transform.position = Vector3.Lerp(a, b, t);
        //         break;
        //     case float n when (n < 90 && n >= 25):
        //         a = transform.position;
        //         b = new Vector3(transform.position.x, transform.position.y - 5f, transform.position.z);
        //         transform.position = Vector3.Lerp(a, b, t);
        //         break;

        //     default:
        //         // print("noooo");
        //         break;
        // }


        // if (CameraRot.eulerAngles.x < 355 && CameraRot.eulerAngles.x > 350)
        // {
        //     // auxPos = transform.position;
        //     Vector3 a = transform.position;
        //     Vector3 b = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z);
        //     transform.position = Vector3.Lerp(a, b, t);

        // }
        // // parte abajo
        // else if (CameraRot.eulerAngles.x > 5 && CameraRot.eulerAngles.x < 10)
        // {
        //     Vector3 a = transform.position;
        //     Vector3 b = new Vector3(transform.position.x, transform.position.y - 0.1f, transform.position.z);
        //     transform.position = Vector3.Lerp(a, b, t);
        // }



        if (!BorderLimits.isInXLimits)
        {
            //izquierda
            if (opcY > 360 - inclinacion_maxima && opcY < 360)
            {
                float valRot = -1 * (opcY - 360);
                float velocidad_proporcional = valRot * velocidad_maxima / inclinacion_maxima; //regla de tres

                Vector3 a = transform.position;
                Vector3 b = new Vector3(transform.position.x - velocidad_proporcional, transform.position.y, transform.position.z);
                transform.position = Vector3.Lerp(a, b, t);

            }



            // switch (opcY)
            // {
            //     case float n when (n < 355 && n >= 350):
            //         Vector3 a = transform.position;
            //         Vector3 b = new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z);
            //         transform.position = Vector3.Lerp(a, b, t);
            //         break;
            //     case float n when (n < 350 && n >= 345):
            //         a = transform.position;
            //         b = new Vector3(transform.position.x - 1f, transform.position.y, transform.position.z);
            //         transform.position = Vector3.Lerp(a, b, t);
            //         break;
            //     case float n when (n < 345 && n >= 340):
            //         a = transform.position;
            //         b = new Vector3(transform.position.x - 2f, transform.position.y, transform.position.z);
            //         transform.position = Vector3.Lerp(a, b, t);
            //         break;
            //     case float n when (n < 340 && n >= 335):
            //         a = transform.position;
            //         b = new Vector3(transform.position.x - 3f, transform.position.y, transform.position.z);
            //         transform.position = Vector3.Lerp(a, b, t);
            //         break;
            //     case float n when (n < 335 && n >= 270):
            //         a = transform.position;
            //         b = new Vector3(transform.position.x - 5f, transform.position.y, transform.position.z);
            //         transform.position = Vector3.Lerp(a, b, t);
            //         break;

            //     default:
            //         // print("noooo");
            //         break;
            // }





            //derecha
            if (opcY > 0 && opcY < inclinacion_maxima)
            {
                float velocidad_proporcional = opcY * velocidad_maxima / inclinacion_maxima; //regla de tres

                Vector3 a = transform.position;
                Vector3 b = new Vector3(transform.position.x + velocidad_proporcional, transform.position.y, transform.position.z);
                transform.position = Vector3.Lerp(a, b, t);

            }

        } // if XLimits


        // switch (opcY)
        // {
        //     case float n when (n < 10 && n >= 5):
        //         Vector3 a = transform.position;
        //         Vector3 b = new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z);
        //         transform.position = Vector3.Lerp(a, b, t);
        //         break;
        //     case float n when (n < 15 && n >= 10):
        //         a = transform.position;
        //         b = new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z);
        //         transform.position = Vector3.Lerp(a, b, t);
        //         break;
        //     case float n when (n < 20 && n >= 15):
        //         a = transform.position;
        //         b = new Vector3(transform.position.x + 2f, transform.position.y, transform.position.z);
        //         transform.position = Vector3.Lerp(a, b, t);
        //         break;
        //     case float n when (n < 25 && n >= 20):
        //         a = transform.position;
        //         b = new Vector3(transform.position.x + 3f, transform.position.y, transform.position.z);
        //         transform.position = Vector3.Lerp(a, b, t);
        //         break;
        //     case float n when (n < 90 && n >= 25):
        //         a = transform.position;
        //         b = new Vector3(transform.position.x + 5f, transform.position.y, transform.position.z);
        //         transform.position = Vector3.Lerp(a, b, t);
        //         break;

        //     default:
        //         // print("noooo");
        //         break;
        // }






        // if (CameraRot.eulerAngles.y < 359 && CameraRot.eulerAngles.y > 300)
        // {
        //     // auxPos = transform.position;
        //     Vector3 a = transform.position;
        //     Vector3 b = new Vector3(transform.position.x - 0.1f, transform.position.y, transform.position.z);
        //     transform.position = Vector3.Lerp(a, b, t);

        // }
        // else if (CameraRot.eulerAngles.y > 0 && CameraRot.eulerAngles.y < 45)
        // {
        //     Vector3 a = transform.position;
        //     Vector3 b = new Vector3(transform.position.x + 0.1f, transform.position.y, transform.position.z);
        //     transform.position = Vector3.Lerp(a, b, t);
        // }

    }
}

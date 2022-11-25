using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderLimits : MonoBehaviour
{
    public static bool isInXLimits;
    public static bool isInYLimits;
    public GameObject Camara;
    GameObject Nave;
    // ShipMovement ShipMovementScript;
    // Start is called before the first frame update
    void Start()
    {
        isInXLimits = false;
        isInYLimits = false;
        Nave = GameObject.FindGameObjectWithTag("Ship");
        // ShipMovementScript = Nave.GetComponent<ShipMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Nave.transform.position.x > 21)
        {
            if (Camara.transform.rotation.eulerAngles.y > 0 && Camara.transform.rotation.eulerAngles.y < 180)
            {
                isInXLimits = true;
            }
            else
            {
                isInXLimits = false;
            }
        }


        if (Nave.transform.position.x < -21)
        {
            if (Camara.transform.rotation.eulerAngles.y > 180 && Camara.transform.rotation.eulerAngles.y < 360)
            {
                isInXLimits = true;
            }
            else
            {
                isInXLimits = false;
            }
        }


        if (Nave.transform.position.y < 0)
        {
            if (Camara.transform.rotation.eulerAngles.x > 0 && Camara.transform.rotation.eulerAngles.x < 180)
            {
                isInYLimits = true;
            }
            else
            {
                isInYLimits = false;
            }
        }


        if (Nave.transform.position.y > 18)
        {
            if (Camara.transform.rotation.eulerAngles.x > 180 && Camara.transform.rotation.eulerAngles.x < 360)
            {
                isInYLimits = true;
            }
            else
            {
                isInYLimits = false;
            }
        }

    }
}

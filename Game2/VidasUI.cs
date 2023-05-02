using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VidasUI : MonoBehaviour
{
    public Animator animatorVP1;
    public Animator animatorPP1;
    int auxVidasCount;
    int auxPuntosCount;

    public TextMeshProUGUI VidasTxt;
    public TextMeshProUGUI PuntosTxt;
    public TextMeshProUGUI DistanciaTxt;
    public TextMeshProUGUI HighTxt;
    public TextMeshProUGUI VidasFB;
    public TextMeshProUGUI PuntosFB;
    // Start is called before the first frame update
    void Start()
    {
        ShipMovement.distanciaHS = PlayerPrefs.GetInt("HSDistanciaGame2",0);

        auxVidasCount = 3;
        auxPuntosCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            VidasTxt.text = $"Vidas: {ShipMovement.vidas}";
            PuntosTxt.text = $"Puntos: {ShipMovement.puntos}";
            DistanciaTxt.text = $"{ShipMovement.distancia}";
            // DistanciaTxt.text = $"{ShipMovement.distancia}";
            // Si pasas el highscore muestralo en vivo 
            if (ShipMovement.distancia < ShipMovement.distanciaHS)
            {
                HighTxt.text = $"Max: {ShipMovement.distanciaHS}";
            }
            else
            {
                HighTxt.text = $"Max: {ShipMovement.distancia}";

            }



            // ? Animation +1 and -1 (Hearts)
            if (ShipMovement.vidas != auxVidasCount)
            {

                if (ShipMovement.vidas > auxVidasCount)
                {
                    VidasFB.text = "+1 Vida";
                    VidasFB.color = Color.green;
                    animatorVP1.SetBool("plusOne", true);
                    Invoke("cancelAnimationV", 1.3f);
                }

                if (ShipMovement.vidas < auxVidasCount)
                {
                    VidasFB.text = "-1 Vida";
                    VidasFB.color = Color.red;
                    animatorVP1.SetBool("plusOne", true);
                    Invoke("cancelAnimationV", 1.3f);
                }

                auxVidasCount = ShipMovement.vidas;

            }

            // ? Animation +1 Coins (Points)
            if (ShipMovement.puntos > auxPuntosCount)
            {
                PuntosFB.text = "+1";
                PuntosFB.color = Color.green;
                animatorPP1.SetBool("plusOne", true);
                Invoke("cancelAnimationP", 1.3f);
                auxPuntosCount = ShipMovement.puntos;
            }


        }
        catch
        {
            print("no pude");

        }
    }

    void cancelAnimationV()
    {
        animatorVP1.SetBool("plusOne", false);
    }

    void cancelAnimationP()
    {
        animatorPP1.SetBool("plusOne", false);
    }
}

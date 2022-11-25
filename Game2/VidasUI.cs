using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VidasUI : MonoBehaviour
{
    public Animator animatorVP1;
    int auxVidasCount;

    public TextMeshProUGUI VidasTxt;
    public TextMeshProUGUI PuntosTxt;
    public TextMeshProUGUI DistanciaTxt;
    public TextMeshProUGUI HighTxt;
    public TextMeshProUGUI VidasFB;
    // Start is called before the first frame update
    void Start()
    {
        ShipMovement.distanciaHS = PlayerPrefs.GetInt("HSDistanciaGame2", 0);

        auxVidasCount = 3;
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


            
            // Animation +1 and -1
            if (ShipMovement.vidas != auxVidasCount)
            {

                if (ShipMovement.vidas > auxVidasCount)
                {
                    VidasFB.text = "+1 Vida";
                    VidasFB.color = Color.green;
                    animatorVP1.SetBool("plusOne", true);
                    Invoke("cancelAnimation", 1.3f);
                }

                if (ShipMovement.vidas < auxVidasCount)
                {
                    VidasFB.text = "-1 Vida";
                    VidasFB.color = Color.red;
                    animatorVP1.SetBool("plusOne", true);
                    Invoke("cancelAnimation", 1.3f);
                }

                auxVidasCount = ShipMovement.vidas;

            }


        }
        catch
        {
            print("no pude");

        }
    }

    void cancelAnimation()
    {
        animatorVP1.SetBool("plusOne", false);
    }
}

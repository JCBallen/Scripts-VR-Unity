using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VidasUI : MonoBehaviour
{
    public TextMeshProUGUI VidasTxt;
    public TextMeshProUGUI PuntosTxt;
    public TextMeshProUGUI DistanciaTxt;
    public TextMeshProUGUI HighTxt;
    // Start is called before the first frame update
    void Start()
    {
        ShipMovement.distanciaHS = PlayerPrefs.GetInt("HSDistanciaGame2", 0);
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            VidasTxt.text = $"Vidas: {ShipMovement.vidas}";
            PuntosTxt.text = $"Puntos: {ShipMovement.puntos}";
            DistanciaTxt.text = $"fps {Mathf.Pow(Time.deltaTime,-1)}";
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
        }
        catch
        {
            print("no pude");

        }
    }
}

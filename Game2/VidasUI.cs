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

        ShipMovement.actualHighScore = PlayerPrefs.GetInt("HighScoreGame2", 0);
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            VidasTxt.text = $"Vidas: {ShipMovement.vidas}";
            PuntosTxt.text = $"Puntos: {ShipMovement.puntos}";
            DistanciaTxt.text = $"{ShipMovement.distancia}";
            // Si pasas el highscore muestralo en vivo 
            if (ShipMovement.distancia < ShipMovement.actualHighScore)
            {
                HighTxt.text = $"Max: {ShipMovement.actualHighScore}";
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

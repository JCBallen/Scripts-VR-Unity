using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDUI : MonoBehaviour
{
    public TextMeshProUGUI DistanciaTxt;
    public TextMeshProUGUI HighTxt;
    // Start is called before the first frame update
    void Start()
    {
        BallMovement.distanciaHS = PlayerPrefs.GetInt("HSDistanciaGame1", 0);
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            DistanciaTxt.text = $"{BallMovement.distancia}";
            if (BallMovement.distancia < BallMovement.distanciaHS)
            {
                HighTxt.text = $"Max: {BallMovement.distanciaHS}";
            }
            else
            {
                HighTxt.text = $"Max: {BallMovement.distancia}";

            }
        }
        catch
        {
            print("no pude");

        }
    }
}

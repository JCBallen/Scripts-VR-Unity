using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetStats : MonoBehaviour
{
    public void setToZero()
    {
        try
        {
            PlayerPrefs.SetInt("HighScoreGame2", 0);
        }
        catch
        {
            print("Nada que borrar");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DeathMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject DeathMenuUI;

    GameObject nave;
    GameObject camara;
    CameraPointerManager CameraPointerManagerScript;
    ShipMovement ShipMovementScript;
    ObstacleGenerator ObstacleGeneratorScript;
    PointsGenerator PointsGeneratorScript;
    GameObject GazePointer;
    GameObject VidasUI;
    // Start is called before the first frame update
    void Start()
    {
        EnvMovement.velocidad = 20f; // Movimiento del entorno inicialmente se mueve
        camara = GameObject.Find("Main Camera");
        nave = GameObject.FindGameObjectWithTag("Ship"); // referencia de la nave

        CameraPointerManagerScript = camara.GetComponent<CameraPointerManager>(); // Referencia script Gaze
        ShipMovementScript = nave.GetComponent<ShipMovement>(); // referencia script movimiento de la nave
        PointsGeneratorScript = nave.GetComponent<PointsGenerator>();
        ObstacleGeneratorScript = nave.GetComponent<ObstacleGenerator>(); // referencia generador de obstaculos
        VidasUI = GameObject.Find("VidasUI");

        DeathMenuUI.SetActive(false);
        VidasUI.SetActive(true);
        CameraPointerManagerScript.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            if (ShipMovement.vidas == 0)
            {
                Pause();
            };
        }
        catch
        {
            print("no pude");

        }
    }

    public void Pause()
    {
        if (ShipMovement.distancia > ShipMovement.distanciaHS)
        {
            PlayerPrefs.SetInt("HSDistanciaGame2", ShipMovement.distancia);
            PlayerPrefs.Save();
            ShipMovement.distanciaHS = PlayerPrefs.GetInt("HSDistanciaGame2", 0);
        }

        ShipMovementScript.enabled = false;
        ObstacleGeneratorScript.enabled = false;
        PointsGeneratorScript.enabled = false;
        EnvMovement.velocidad = 0f;
        ObsMovement.velocidad = 0f;
        // Time.timeScale = 1f;
        VidasUI.SetActive(false);
        DeathMenuUI.SetActive(true);
        CameraPointerManagerScript.enabled = true;
        isPaused = true;
    }

    // Reinicia el nivel
    public void Restart()
    {
        // Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        EnvMovement.velocidad = 20f;
        ObsMovement.velocidad = -20f;
        isPaused = false;
    }

    // Al menu
    public void toMenu()
    {
        SceneManager.LoadScene("MainMenu");
        // Time.timeScale = 1f;
        isPaused = false;
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("HSDistanciaGame2", ShipMovement.distanciaHS);
        PlayerPrefs.Save();
    }
}

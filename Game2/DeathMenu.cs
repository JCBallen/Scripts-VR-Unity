using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
// Este script se encarga de manejar el menu de muerte, este script lo lleva el "canvas death"
public class DeathMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject DeathMenuUI;

    GameObject nave;
    GameObject camara;
    GameObject[] triggers_terrain_generator;

    CameraPointerManager CameraPointerManagerScript;
    ShipMovement ShipMovementScript;
    ObstacleGenerator ObstacleGeneratorScript;
    PointsGenerator PointsGeneratorScript;
    HeartsGenerator HeartsGeneratorScript;

    GameObject GazePointer;
    GameObject VidasUI;
    
    // Start is called before the first frame update
    void Start()
    {
        camara = GameObject.Find("Main Camera");
        nave = GameObject.FindGameObjectWithTag("Ship"); // referencia de la nave

        CameraPointerManagerScript = camara.GetComponent<CameraPointerManager>(); // Referencia script Gaze
        ShipMovementScript = nave.GetComponent<ShipMovement>(); // referencia script movimiento de la nave
        ObstacleGeneratorScript = nave.GetComponent<ObstacleGenerator>(); // referencia generador de obstaculos
        PointsGeneratorScript = nave.GetComponent<PointsGenerator>();
        HeartsGeneratorScript = nave.GetComponent<HeartsGenerator>();
        VidasUI = GameObject.Find("VidasUI");

        DeathMenuUI.SetActive(false);
        VidasUI.SetActive(true);              // solo muestra la interfaz de vidas
        CameraPointerManagerScript.enabled = false; // desactiva el gaze selection
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
        HeartsGeneratorScript.enabled = false;
        EnvMovement.velocidad = 0f;
        ObsMovement.velocidad = 0f;
        // Time.timeScale = 1f;
        
        // Paso op para eliminar todos los bloques de trigger y que no me bugee el menu de muerte
        triggers_terrain_generator = GameObject.FindGameObjectsWithTag("TriggerBlock");
        foreach (GameObject trigger in triggers_terrain_generator)
        {
            trigger.SetActive(false);
        }

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
        EnvMovement.velocidad = EnvMovement.default_velocity;
        ObsMovement.velocidad = ObsMovement.default_velocity;
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

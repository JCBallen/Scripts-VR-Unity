using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class BallDeath : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject DeathMenuUI;

    GameObject ball;
    GameObject camara;

    CameraPointerManager CameraPointerManagerScript;
    BallMovement BallMovementScript;
    // ObstacleGenerator ObstacleGeneratorScript;
    // PointsGenerator PointsGeneratorScript;
    // HeartsGenerator HeartsGeneratorScript;

    GameObject GazePointer;
    GameObject VidasUI;
    // Start is called before the first frame update
    void Start()
    {
        camara = GameObject.Find("Main Camera");
        ball = GameObject.FindGameObjectWithTag("Ship"); // referencia de la ball

        CameraPointerManagerScript = camara.GetComponent<CameraPointerManager>(); // Referencia script Gaze
        BallMovementScript = ball.GetComponent<BallMovement>(); // referencia script movimiento de la nave
        // ObstacleGeneratorScript = nave.GetComponent<ObstacleGenerator>(); // referencia generador de obstaculos
        // PointsGeneratorScript = nave.GetComponent<PointsGenerator>();
        // HeartsGeneratorScript = nave.GetComponent<HeartsGenerator>();
        VidasUI = GameObject.Find("HUDUI");

        DeathMenuUI.SetActive(false);
        VidasUI.SetActive(true);              // solo muestra la interfaz de vidas
        CameraPointerManagerScript.enabled = false; // desactiva el gaze selection
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            if (BallMovement.vidas == 0)
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
        if (BallMovement.distancia > BallMovement.distanciaHS)
        {
            PlayerPrefs.SetInt("HSDistanciaGame1", BallMovement.distancia);
            PlayerPrefs.Save();
            BallMovement.distanciaHS = PlayerPrefs.GetInt("HSDistanciaGame1", 0);
        }

        BallMovementScript.enabled = false;
        // ObstacleGeneratorScript.enabled = false;
        // PointsGeneratorScript.enabled = false;
        // HeartsGeneratorScript.enabled = false;
        BaseMovement.velocidad = 0f;
        // ObsMovement.velocidad = 0f;
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
        // EnvMovement.velocidad = EnvMovement.default_velocity;
        // ObsMovement.velocidad = ObsMovement.default_velocity;
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
        PlayerPrefs.SetInt("HSDistanciaGame1", BallMovement.distanciaHS);
        PlayerPrefs.Save();
    }
}

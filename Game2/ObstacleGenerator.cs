// using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    // Tres tipos diferentes de obtaculos
    public GameObject ObstaclePrefab1;
    public GameObject ObstaclePrefab2;
    public GameObject ObstaclePrefab3;
    bool aux = true;
    // Variables para almacenar randoms para las posiciones, y objeto
    float randX;
    float randY;
    int randObs;
    // Necesarios para crear el Instance prefab
    List<GameObject> listaObstaculos;
    GameObject obstacle_parent;
    Vector3 obstacle_pos;
    Quaternion obstacle_rot;
    Transform parent_transform;


    private void Start()
    {
        // Inicializar lista de Prefabs para aleatorizar
        listaObstaculos = new List<GameObject>();
        listaObstaculos.Add(ObstaclePrefab1);
        listaObstaculos.Add(ObstaclePrefab2);
        listaObstaculos.Add(ObstaclePrefab3);
    }

    private void Update()
    {
        if (aux)
        {
            Invoke("spawnObs", 1f/LevelDifficulty.value);
            aux = false;
        }
    }
    // Start is called before the first frame update
    void spawnObs()
    {
        // Limites de juego / de spawneo
        randX = Random.Range(-20, 20);
        randY = Random.Range(0, 20);
        // randomizador de obstaculos
        randObs = Random.Range(0, 3);
        aux = true;
        // Encuentra el objeto obstaculos para ser el padre
        obstacle_parent = GameObject.Find("Obstacles");
        parent_transform = obstacle_parent.transform;



        obstacle_pos = transform.position;
        obstacle_pos.x = randX;
        obstacle_pos.y = randY;
        obstacle_pos.z = obstacle_pos.z + 200; // distancia en la que aparecera el primer obs

        obstacle_rot = Quaternion.Euler(0, 0, 0);



        GameObject obstacle = Instantiate( // spawnaer un prefab
                listaObstaculos[randObs], // prefab
                obstacle_pos, // position
                obstacle_rot, // rotation
                parent_transform); // padre

        obstacle.name = "PrefabObstacle";

        // Destruye el obstaculo a los n segundos
        try { Destroy(obstacle, 12f); } catch { print("Ya se habia destruido"); }


    }


}

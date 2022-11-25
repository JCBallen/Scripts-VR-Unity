using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsGenerator : MonoBehaviour
{
    // Tres tipos diferentes de obtaculos
    public GameObject PointPrefab;
    bool aux = true;
    // Variables para almacenar randoms para las posiciones, y objeto
    float randX;
    float randY;
    // Necesarios para crear el Instance prefab
    GameObject points_parent;
    Vector3 points_pos;
    Quaternion points_rot;
    Transform parent_transform;


    private void Update()
    {
        if (aux)
        {
            Invoke("spawnPts", 4f);
            aux = false;
        }
    }
    // Start is called before the first frame update
    void spawnPts()
    {
        // Limites de juego
        randX = Random.Range(-20, 20);
        randY = Random.Range(1, 20);

        aux = true;
        // Encuentra el objeto obstaculos para ser el padre
        points_parent = GameObject.Find("Points");
        parent_transform = points_parent.transform;



        points_pos = transform.position;
        points_pos.x = randX;
        points_pos.y = randY;
        points_pos.z = points_pos.z + 200; // distancia en la que aparece el primer punto

        points_rot = Quaternion.Euler(0, 0, 0);



        GameObject point = Instantiate( // spawnaer un prefab
                PointPrefab, // prefab
                points_pos, // position
                points_rot, // rotation
                parent_transform); // padre

        point.name = "PrefabPoint";

        // Destruye el obstaculo a los n segundos
        try { Destroy(point, 12f); } catch { print("Ya se habia destruido"); }
    }
}

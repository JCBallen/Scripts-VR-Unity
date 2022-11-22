using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseGenerator : MonoBehaviour
{
    // Tres tipos diferentes de obtaculos
    public GameObject BasePrefab;
    public GameObject Ball;
    bool aux = true;
    // Variables para almacenar randoms para las posiciones, y objeto
    float randX;
    float randY;
    // Necesarios para crear el Instance prefab
    GameObject base_parent;
    Vector3 base_pos;
    Quaternion base_rot;
    Transform parent_transform;


    void Update()
    {
        if (aux)
        {
            Invoke("spawnObs", 0.1f);
            aux = false;
        }
    }


    void spawnObs()
    {
        if (BallMovement.numBases > -1)
        { // Limites de juego / de spawneo
            randX = Random.Range(-5, 5);
            aux = true;
            // Encuentra el objeto bases para ser el padre
            base_parent = GameObject.Find("Bases");
            parent_transform = base_parent.transform;


            base_pos = transform.position;
            base_pos.x = randX;
            base_pos.y = -3;
            base_pos.z = Ball.transform.position.z + 10; // distancia en la que aparecera el primer obs

            base_rot = Quaternion.Euler(0, 0, 0);



            GameObject bases = Instantiate( // spawnaer un prefab
                    BasePrefab, // prefab
                    base_pos, // position
                    base_rot, // rotation
                    parent_transform); // padre

            bases.name = "PrefabBase";

            // Destruye la base a los n segundos
            try { Destroy(bases, 5f); } catch { print("Ya se habia destruido"); }

            BallMovement.numBases += 1;
        }


    }

}

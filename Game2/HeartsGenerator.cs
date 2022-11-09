using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartsGenerator : MonoBehaviour
{
   // Tres tipos diferentes de obtaculos
    public GameObject HeartPrefab;
    bool aux = true;
    // Variables para almacenar randoms para las posiciones, y objeto
    float randX;
    float randY;
    // Necesarios para crear el Instance prefab
    GameObject hearts_parent;
    Vector3 hearts_pos;
    Quaternion hearts_rot;
    Transform parent_transform;


    private void Update()
    {
        if (aux)
        {
            Invoke("spawnHts", 12.5f);
            aux = false;
        }
    }
    // Start is called before the first frame update
    void spawnHts()
    {
        // Limites de juego
        randX = Random.Range(-20, 20);
        randY = Random.Range(0, 20);

        aux = true;
        // Encuentra el objeto obstaculos para ser el padre
        hearts_parent = GameObject.Find("Hearts");
        parent_transform = hearts_parent.transform;



        hearts_pos = transform.position;
        hearts_pos.x = randX;
        hearts_pos.y = randY;
        hearts_pos.z = hearts_pos.z + 50; // distancia en la que aparece el primer punto

        hearts_rot = Quaternion.Euler(0, 0, 0);



        GameObject heart = Instantiate( // spawnaer un prefab
                HeartPrefab, // prefab
                hearts_pos, // position
                hearts_rot, // rotation
                parent_transform); // padre

        heart.name = "PrefabHeart";

        // Destruye el obstaculo a los n segundos

        try { Destroy(heart, 5f); } catch { print("Ya se habia destruido"); }



    }
}

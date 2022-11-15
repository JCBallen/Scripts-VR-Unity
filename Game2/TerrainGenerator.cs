using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public GameObject prefab; // prefab de cubosEscena
    private GameObject Padre_Terrenos;



    private void OnTriggerEnter(Collider obj)
    {
        Padre_Terrenos = GameObject.Find("EnvironmentCubes");
        Transform Terrain_parent = Padre_Terrenos.transform;
        Vector3 terreno_pos = transform.position;
        terreno_pos.x = terreno_pos.x + 0;
        terreno_pos.y = terreno_pos.y + 0;
        terreno_pos.z = terreno_pos.z + 162f * 5; // distancia a la que se debe spawnear en nuevo bloque

        // forma sencilla de modificar los cuaterniones con angulos de euler
        Quaternion terreno_rot = Quaternion.Euler(transform.rotation.eulerAngles.x, 90, transform.rotation.eulerAngles.z);



        if (obj.tag == "Ship")
        {
            // print("Funciona xd 3d lol");

            GameObject terreno = Instantiate( // spawnaer un prefab
                prefab, // prefab
                terreno_pos, // position
                terreno_rot, // rotation
                Terrain_parent); // padre

            terreno.name = "PrefabTrerrain";

            // Destruye el obstaculo a los n segundos
        try { Destroy(terreno, 50f); } catch { print("Ya se habia destruido"); }
        }
    }
}

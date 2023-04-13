using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField] GameObject groundTile; //pegamos el objecto piso
    Vector3 nextSpawnPoint;                 //el punto donde deberia aparecer el siguiente    

    public void SpawnTile(bool spawnItems)
    {
        GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);     //se crea la variable temp (temporaria) y le decimos que haga aparecer la tile, en el punto, y que su rotacion se la misma de siempre
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;                     //se le dice que el point va a ser en el transform del temp, especificamente en el child de index 1 q es el nextspawnpoint en el prefab

        if (spawnItems)
        {
            temp.GetComponent<GroundTile>().SpawnObstacle();
            temp.GetComponent<GroundTile>().SpawnCoins();
            temp.GetComponent <GroundTile>().SpawnFeather();
            temp.GetComponent<GroundTile>().SpawnTallObstacle();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 15; i++) //para spawnear tiles al principio
        {
            if(i < 2)
            {
                SpawnTile(false);
            }else
            {
                SpawnTile(true);
            }
            
        }
        
    }

}
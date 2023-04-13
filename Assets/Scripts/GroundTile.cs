using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;    //para acceder desde el script  groundSpawner a este mismo

    [SerializeField] GameObject obstaclePrefab;

    [SerializeField] GameObject tallObstaclePrefab;

    [SerializeField] float tallObstacleChance = 0.2f;

    [SerializeField] GameObject coinPrefab;

    [SerializeField] GameObject featherPrefab;

    private void OnTriggerExit(Collider other)  
    {
        groundSpawner.SpawnTile(true);
        Destroy(gameObject, 2);
    }
    // Start is called before the first frame update
    void Start()
    {
        
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();   //para linkear scripts
        
    }   

    public void SpawnObstacle()
    {
        
        int obstacleSpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
    }

    public void SpawnTallObstacle()
    {
        Transform spawnTall = transform.GetChild(1).transform;
        GameObject obstacleToSpawn = obstaclePrefab;
        float random = Random.Range(0f, 1f);
        if (random < tallObstacleChance)
        {
            obstacleToSpawn = tallObstaclePrefab;
            Instantiate(obstacleToSpawn, spawnTall.position, Quaternion.identity, transform);
        }
    }

    public void SpawnCoins()
    {
        int coinsToSpawn = 2;
        for (int i = 0; i < coinsToSpawn; i++)
        {
            GameObject temp = Instantiate(coinPrefab, transform);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }
    }

    public void SpawnFeather()
    {
        int featherToSpawn = 2;
        for (int i = 0; i < featherToSpawn; i++)
        {
            GameObject temp = Instantiate(featherPrefab, transform);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }
    }

    Vector3 GetRandomPointInCollider (Collider collider)
    {
        Vector3 point = new Vector3(

            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
            );

        if (point != collider.ClosestPoint(point))
        {
            point = GetRandomPointInCollider(collider);
        }

        point.y = 1;
        return point;
    }
    
    
}

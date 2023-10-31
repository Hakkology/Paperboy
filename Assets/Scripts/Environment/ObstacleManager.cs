using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager
{
    public List<GameObject> obstaclePrefabs;
    public List<Transform> obstacleSpawnPoints;

    public ObstacleManager(List<GameObject> obstacles, List<Transform> obsSpawns)
    {
        obstaclePrefabs = obstacles;
        obstacleSpawnPoints = obsSpawns;
    }

    public void onStart(){
        HouseObstacleSpawner();
    }

    public GameObject GetRandomObstacle()
    {
        int randomIndex = Random.Range(0, obstaclePrefabs.Count);
        return obstaclePrefabs[randomIndex];
    }

    void HouseObstacleSpawner()
    {
        int totalLeftSpawnDistance = 0;
        Vector3 firstLeftSpawnPosition = obstacleSpawnPoints[0].transform.position;

        for (int i = 1; i < 30; i++)
        {
            GameObject obstaclePrefab = GetRandomObstacle();
            int spawnDistance = Random.Range(3,9);
            int spawnLine = Random.Range(0,3);
            totalLeftSpawnDistance += spawnDistance;
            GameObject newObstacle = UnityEngine.Object.Instantiate(obstaclePrefab, new Vector3(obstacleSpawnPoints[spawnLine].position.x, firstLeftSpawnPosition.y, firstLeftSpawnPosition.z + totalLeftSpawnDistance), Quaternion.Euler(90,Random.Range(0,90),90));
            newObstacle.transform.SetParent(obstacleSpawnPoints[spawnLine].transform.parent);
            if (totalLeftSpawnDistance > 280)
            {
                break;
            }
        }
    }
}

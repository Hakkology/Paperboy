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
            int spawnDistance = Random.Range(7,22);
            totalLeftSpawnDistance += spawnDistance;
            GameObject newObstacle = UnityEngine.Object.Instantiate(obstaclePrefab, new Vector3(firstLeftSpawnPosition.x, firstLeftSpawnPosition.y, firstLeftSpawnPosition.z + totalLeftSpawnDistance), Quaternion.Euler(90,Random.Range(0,90),90));
            newObstacle.transform.SetParent(obstacleSpawnPoints[0].transform.parent);
            if (totalLeftSpawnDistance > 280)
            {
                break;
            }
        }

        int totalLeft2SpawnDistance = 0;
        Vector3 firstLeft2SpawnPosition = obstacleSpawnPoints[2].transform.position;

        for (int i = 1; i < 30; i++)
        {
            GameObject obstaclePrefab = GetRandomObstacle();
            int spawnDistance = Random.Range(7,22);
            totalLeft2SpawnDistance += spawnDistance;
            GameObject newObstacle = UnityEngine.Object.Instantiate(obstaclePrefab, new Vector3(firstLeft2SpawnPosition.x, firstLeft2SpawnPosition.y, firstLeft2SpawnPosition.z + totalLeft2SpawnDistance), Quaternion.Euler(90,Random.Range(0,90),90));
            newObstacle.transform.SetParent(obstacleSpawnPoints[2].transform.parent);
            if (totalLeft2SpawnDistance > 280)
            {
                break;
            }
        }

        int totalRightSpawnDistance = 0;
        Vector3 firstRightSpawnPosition = obstacleSpawnPoints[1].transform.position;
        
        for (int i = 1; i < 30; i++)
        {
            GameObject obstaclePrefab = GetRandomObstacle();
            int spawnDistance = Random.Range(7,22);
            totalRightSpawnDistance += spawnDistance;
            GameObject newObstacle = UnityEngine.Object.Instantiate(obstaclePrefab, new Vector3(firstRightSpawnPosition.x, firstRightSpawnPosition.y, firstRightSpawnPosition.z + totalRightSpawnDistance), Quaternion.Euler(90,Random.Range(0,90),90));
            newObstacle.transform.SetParent(obstacleSpawnPoints[1].transform.parent);
            if (totalRightSpawnDistance > 280)
            {
                break;
            }
        }

        int totalRigh2tSpawnDistance = 0;
        Vector3 firstRight2SpawnPosition = obstacleSpawnPoints[3].transform.position;
        
        for (int i = 1; i < 30; i++)
        {
            GameObject obstaclePrefab = GetRandomObstacle();
            int spawnDistance = Random.Range(7,22);
            totalRigh2tSpawnDistance += spawnDistance;
            GameObject newObstacle = UnityEngine.Object.Instantiate(obstaclePrefab, new Vector3(firstRight2SpawnPosition.x, firstRight2SpawnPosition.y, firstRight2SpawnPosition.z + totalRigh2tSpawnDistance), Quaternion.Euler(90,Random.Range(0,90),90));
            newObstacle.transform.SetParent(obstacleSpawnPoints[3].transform.parent);
            if (totalRigh2tSpawnDistance > 280)
            {
                break;
            }
        }
    }
}

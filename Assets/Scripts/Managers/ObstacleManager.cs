using UnityEngine;
using System.Collections.Generic;

public class ObstacleManager
{
    private static ObstacleManager _instance;
    public static ObstacleManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = new ObstacleManager();
            return _instance;
        }
    }

    private List<GameObject> obstaclePrefabs;

    private ObstacleManager()
    {
        obstaclePrefabs = new List<GameObject>
        {
            // Resources.Load<GameObject>("Obstacles/Obstacle1"),
            // Resources.Load<GameObject>("Obstacles/Obstacle2"),
        };
    }

    public GameObject GetRandomObstacle()
    {
        int randomIndex = Random.Range(0, obstaclePrefabs.Count);
        return obstaclePrefabs[randomIndex];
    }
}

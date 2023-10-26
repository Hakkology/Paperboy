using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class house2 : MonoBehaviour
{
    public ObstacleManager obstacleManager;
    private string targetMaterialName = "map2";
    private MeshRenderer meshRender;
    void  Awake() {
        meshRender = GetComponent<MeshRenderer>();
        obstacleManager = ObstacleManager.Instance;
    }
    void Start(){
        HouseRandomColor(meshRender);
        HouseObstacleSpawner();
    }

    void HouseRandomColor(MeshRenderer meshRender){
        Material[] materials = meshRender.materials;

        for (int i = 0; i < materials.Length; i++)
        {
            if (materials[i].name.StartsWith(targetMaterialName))
            {
                Color randomColor = new Color (Random.value, Random.value, Random.value);
                materials[i].color = randomColor;
                break;
            }
        }
        meshRender.materials = materials;
    }

    void HouseObstacleSpawner(){
        GameObject obstaclePrefab = ObstacleManager.Instance.GetRandomObstacle();
        if (obstaclePrefab != null)
        {
            Vector3 spawnPosition = transform.position + new Vector3(0, obstaclePrefab.transform.localScale.y / 2, 0);
            Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
        }
    }
}

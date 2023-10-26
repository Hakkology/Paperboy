using System.Collections.Generic;
using UnityEngine;

public class TreeManager
{
    public List<GameObject> trees;
    public List<Transform> treeSpawnLocations;

    public TreeManager (List<GameObject> treelist, List<Transform> treespawn) {
        trees = treelist;
        treeSpawnLocations = treespawn;
    }

    public void onStart(){
        SpawnMainTrees();
        SpawnIntersectionLeftTrees();
        SpawnIntersectionRightTrees();
    }

    void SpawnMainTrees() {
        Vector3 firstLeftSpawnPosition = treeSpawnLocations[0].transform.position;
        int totalLeftSpawnDistance = 0;

        for (int i = 1; i < 107; i++)
        {
            int treeIndex = Random.Range(0, trees.Count);
            int spawnDistance = Random.Range(9,25);
            totalLeftSpawnDistance += spawnDistance;
            GameObject newTree = UnityEngine.Object.Instantiate(trees[treeIndex], new Vector3(firstLeftSpawnPosition.x, firstLeftSpawnPosition.y, firstLeftSpawnPosition.z + totalLeftSpawnDistance), Quaternion.identity);
            newTree.transform.SetParent(treeSpawnLocations[0].transform.parent);
            if (totalLeftSpawnDistance > 280)
            {
                break;
            }
        }

        Vector3 firstRightSpawnPosition = treeSpawnLocations[1].transform.position;
        int totalRightSpawnDistance = 0;

        for (int i = 1; i < 107; i++)
        {
            int treeIndex = Random.Range(0, trees.Count);
            int spawnDistance = Random.Range(9,25);
            totalRightSpawnDistance += spawnDistance;
            GameObject newTree = UnityEngine.Object.Instantiate(trees[treeIndex], new Vector3(firstRightSpawnPosition.x, firstRightSpawnPosition.y, firstRightSpawnPosition.z + totalRightSpawnDistance), Quaternion.identity);
            newTree.transform.SetParent(treeSpawnLocations[0].transform.parent);
            if (totalRightSpawnDistance > 280)
            {
                break;
            }
        }

    }

    void SpawnIntersectionLeftTrees(){
        Vector3 firstLeftSpawnPosition = treeSpawnLocations[2].transform.position;
        int totalLeftSpawnDistance = 0;

        for (int i = 1; i < 107; i++)
        {
            int treeIndex = Random.Range(0, trees.Count);
            int spawnDistance = Random.Range(9,25);
            totalLeftSpawnDistance += spawnDistance;
            GameObject newTree = UnityEngine.Object.Instantiate(trees[treeIndex], new Vector3(firstLeftSpawnPosition.x + totalLeftSpawnDistance, firstLeftSpawnPosition.y, firstLeftSpawnPosition.z ), Quaternion.identity);
            newTree.transform.SetParent(treeSpawnLocations[2].transform.parent);
            if (totalLeftSpawnDistance > 100)
            {
                break;
            }
        }

        Vector3 firstRightSpawnPosition = treeSpawnLocations[3].transform.position;
        int totalRightSpawnDistance = 0;

        for (int i = 1; i < 107; i++)
        {
            int treeIndex = Random.Range(0, trees.Count);
            int spawnDistance = Random.Range(9,25);
            totalRightSpawnDistance += spawnDistance;
            GameObject newTree = UnityEngine.Object.Instantiate(trees[treeIndex], new Vector3(firstRightSpawnPosition.x+ totalRightSpawnDistance, firstRightSpawnPosition.y, firstRightSpawnPosition.z ), Quaternion.identity);
            newTree.transform.SetParent(treeSpawnLocations[3].transform.parent);
            if (totalRightSpawnDistance > 100)
            {
                break;
            }
        }

    }
    void SpawnIntersectionRightTrees(){
        Vector3 firstLeftSpawnPosition = treeSpawnLocations[4].transform.position;
        int totalLeftSpawnDistance = 0;

        for (int i = 1; i < 107; i++)
        {
            int treeIndex = Random.Range(0, trees.Count);
            int spawnDistance = Random.Range(9,25);
            totalLeftSpawnDistance += spawnDistance;
            GameObject newTree = UnityEngine.Object.Instantiate(trees[treeIndex], new Vector3(firstLeftSpawnPosition.x - totalLeftSpawnDistance, firstLeftSpawnPosition.y, firstLeftSpawnPosition.z ), Quaternion.identity);
            newTree.transform.SetParent(treeSpawnLocations[4].transform.parent);
            if (totalLeftSpawnDistance > 100)
            {
                break;
            }
        }

        Vector3 firstRightSpawnPosition = treeSpawnLocations[5].transform.position;
        int totalRightSpawnDistance = 0;

        for (int i = 1; i < 107; i++)
        {
            int treeIndex = Random.Range(0, trees.Count);
            int spawnDistance = Random.Range(9,25);
            totalRightSpawnDistance += spawnDistance;
            GameObject newTree = UnityEngine.Object.Instantiate(trees[treeIndex], new Vector3(firstRightSpawnPosition.x- totalRightSpawnDistance, firstRightSpawnPosition.y, firstRightSpawnPosition.z ), Quaternion.identity);
            newTree.transform.SetParent(treeSpawnLocations[5].transform.parent);
            if (totalRightSpawnDistance > 100)
            {
                break;
            }
        }
    }
}

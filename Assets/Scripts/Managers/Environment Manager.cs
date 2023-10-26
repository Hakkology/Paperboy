using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentManager
{
    public GameObject roadLine;
    public List<GameObject> housePrefabs;
    public Transform firstLeftHouse;
    public Transform firstRightHouse;

    public EnvironmentManager(GameObject lines, List<GameObject> housePre, Transform firstLHouse, Transform firstRHouse){
        roadLine = lines;
        housePrefabs = housePre;
        firstLeftHouse = firstLHouse;
        firstRightHouse = firstRHouse;
    }
    
    public void onStart()
    {
        GenerateRoadLines();
        GenerateLeftHouses();
        GenerateRightHouses();
    }

    public void onUpdate()
    {
        
    }

    void GenerateRoadLines(){

        Vector3 firstSpawnPosition = roadLine.transform.position;

        for (int i = 1; i < 500; i++)
        {
            GameObject newLine = UnityEngine.Object.Instantiate(roadLine, new Vector3(firstSpawnPosition.x, firstSpawnPosition.y, firstSpawnPosition.z + 3 * i), Quaternion.identity);
            newLine.transform.SetParent(roadLine.transform.parent);
        }
    }

    void GenerateRightHouses()
    {
        Vector3 firstSpawnPosition = firstLeftHouse.transform.position;
        for (int i = 1; i < 30; i++)
        {
            int j = Random.Range(0,2);
            GameObject newHouse = UnityEngine.Object.Instantiate(housePrefabs[j]);
            
            float houseHeight = newHouse.GetComponent<Renderer>().bounds.size.y;
            Vector3 position = new Vector3(firstSpawnPosition.x, houseHeight / 2, firstSpawnPosition.z + 20 * i);
            
            newHouse.transform.position = position;
            newHouse.transform.rotation = Quaternion.Euler(0, 90, 0);
            newHouse.transform.SetParent(firstLeftHouse.parent);
        }
    }

    void GenerateLeftHouses()
    {
        Vector3 firstSpawnPosition = firstRightHouse.transform.position;
        for (int i = 1; i < 30; i++)
        {
            int j = Random.Range(0,2);
            GameObject newHouse = UnityEngine.Object.Instantiate(housePrefabs[j]);
            
            float houseHeight = newHouse.GetComponent<Renderer>().bounds.size.y;
            Vector3 position = new Vector3(firstSpawnPosition.x, houseHeight / 2, firstSpawnPosition.z + 20 * i);
            
            newHouse.transform.position = position;
            newHouse.transform.rotation = Quaternion.Euler(0, -90, 0);
            newHouse.transform.SetParent(firstRightHouse.parent);
        }
    }

}

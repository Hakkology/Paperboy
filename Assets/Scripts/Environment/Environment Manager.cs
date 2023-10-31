using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentManager
{
    public GameObject roadLine;
    public GameObject roadLine2;
    public List<GameObject> housePrefabs;
    public Transform firstLeftHouse;
    public Transform firstRightHouse;
    public Transform firstLeftIntersectionHouse;
    public Transform firstRightIntersectionHouse;
    public Transform lastLeftIntersectionHouse;
    public Transform lastRightIntersectionHouse;

    public EnvironmentManager(GameObject lines, GameObject lines2, List<GameObject> housePre, Transform firstLHouse, Transform firstRHouse, Transform firstILHouse, Transform firstIRHouse, Transform lastILHouse, Transform lastIRHouse){
        roadLine = lines;
        roadLine2 = lines2;
        housePrefabs = housePre;
        firstLeftHouse = firstLHouse;
        firstRightHouse = firstRHouse;
        firstLeftIntersectionHouse = firstILHouse;
        firstRightIntersectionHouse = firstIRHouse;
        lastLeftIntersectionHouse = lastILHouse;
        lastRightIntersectionHouse = lastIRHouse;
    }
    
    public void onStart()
    {
        GenerateRoadLines();
        GenerateLeftHouses();
        GenerateRightHouses();
        GenerateIntersectionLeftHouses();
        GenerateIntersectionRightHouses();
    }

    public void onUpdate()
    {
        
    }

    void GenerateRoadLines(){

        Vector3 firstSpawnPosition = roadLine.transform.position;

        for (int i = 1; i < 107; i++)
        {
            GameObject newLine = UnityEngine.Object.Instantiate(roadLine, new Vector3(firstSpawnPosition.x, firstSpawnPosition.y, firstSpawnPosition.z + 3 * i), Quaternion.identity);
            newLine.transform.SetParent(roadLine.transform.parent);
        }

        Vector3 secondSpawnPosition = roadLine2.transform.position;

        for (int i = 1; i < 100; i++)
        {
            GameObject newLine = UnityEngine.Object.Instantiate(roadLine2, new Vector3(secondSpawnPosition.x + 3 * i, secondSpawnPosition.y, secondSpawnPosition.z), Quaternion.Euler(0,90,0));
            newLine.transform.SetParent(roadLine2.transform.parent);
        }
    }

    void GenerateRightHouses()
    {
        Vector3 firstSpawnPosition = firstLeftHouse.transform.position;
        for (int i = 1; i < 14; i++)
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
        for (int i = 1; i < 14; i++)
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

    void GenerateIntersectionLeftHouses(){
        Vector3 firstSpawnPosition = firstLeftIntersectionHouse.transform.position;
        for (int i = 1; i < 6; i++)
        {
            int j = Random.Range(0,2);
            GameObject newHouse = UnityEngine.Object.Instantiate(housePrefabs[j]);
            
            float houseHeight = newHouse.GetComponent<Renderer>().bounds.size.y;
            Vector3 position = new Vector3(firstSpawnPosition.x + 20 * i, houseHeight / 2, firstSpawnPosition.z);
            
            newHouse.transform.position = position;
            newHouse.transform.rotation = Quaternion.Euler(0, 180, 0);
            newHouse.transform.SetParent(firstLeftIntersectionHouse.parent);
        }

        Vector3 lastSpawnPosition = lastLeftIntersectionHouse.transform.position;
        for (int i = 1; i < 6; i++)
        {
            int j = Random.Range(0,2);
            GameObject newHouse = UnityEngine.Object.Instantiate(housePrefabs[j]);
            
            float houseHeight = newHouse.GetComponent<Renderer>().bounds.size.y;
            Vector3 position = new Vector3(lastSpawnPosition.x - 20 * i, houseHeight / 2, lastSpawnPosition.z);
            
            newHouse.transform.position = position;
            newHouse.transform.rotation = Quaternion.Euler(0, 180, 0);
            newHouse.transform.SetParent(lastLeftIntersectionHouse.parent);
        }
    }

    void GenerateIntersectionRightHouses(){
        Vector3 firstSpawnPosition = firstRightIntersectionHouse.transform.position;
        for (int i = 1; i < 6; i++)
        {
            int j = Random.Range(0,2);
            GameObject newHouse = UnityEngine.Object.Instantiate(housePrefabs[j]);
            
            float houseHeight = newHouse.GetComponent<Renderer>().bounds.size.y;
            Vector3 position = new Vector3(firstSpawnPosition.x + 20 * i, houseHeight / 2, firstSpawnPosition.z);
            
            newHouse.transform.position = position;
            newHouse.transform.rotation = Quaternion.Euler(0, 0, 0);
            newHouse.transform.SetParent(firstRightIntersectionHouse.parent);
        }

        Vector3 lastSpawnPosition = lastRightIntersectionHouse.transform.position;
        for (int i = 1; i < 6; i++)
        {
            int j = Random.Range(0,2);
            GameObject newHouse = UnityEngine.Object.Instantiate(housePrefabs[j]);
            
            float houseHeight = newHouse.GetComponent<Renderer>().bounds.size.y;
            Vector3 position = new Vector3(lastSpawnPosition.x - 20 * i, houseHeight / 2, lastSpawnPosition.z);
            
            newHouse.transform.position = position;
            newHouse.transform.rotation = Quaternion.Euler(0, 0, 0);
            newHouse.transform.SetParent(lastRightIntersectionHouse.parent);
        }
    }

}

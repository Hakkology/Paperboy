using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentManager
{

    float chanceOfBeingAvailable = 0.5f;
    public GameObject roadLine;
    public GameObject roadLine2;
    public List<GameObject> housePrefabs;
    public List<Transform> housePrefabLocations;
    
    public enum HouseState{
        Available,
        Unavailable
    }

    public EnvironmentManager(GameObject lines, GameObject lines2, List<GameObject> housePre, List<Transform> housePreLocations){
        roadLine = lines;
        roadLine2 = lines2;
        housePrefabs = housePre;
        housePrefabLocations = housePreLocations;
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
        Vector3 firstSpawnPosition = housePrefabLocations[0].transform.position;
        for (int i = 1; i < 14; i++)
        {
            int j = Random.Range(0,2);
            GameObject newHouse = UnityEngine.Object.Instantiate(housePrefabs[j]);
            MeshRenderer meshRender = newHouse.GetComponent<MeshRenderer>();
            string targetMaterialName = GetColourMappingName(newHouse.name);
            SetHouseColor(meshRender, targetMaterialName, chanceOfBeingAvailable);
            
            float houseHeight = newHouse.GetComponent<Renderer>().bounds.size.y;
            Vector3 position = new Vector3(firstSpawnPosition.x, houseHeight / 2, firstSpawnPosition.z + 20 * i);
            
            newHouse.transform.position = position;
            newHouse.transform.rotation = Quaternion.Euler(0, 90, 0);
            newHouse.transform.SetParent(housePrefabLocations[0].parent);
        }
    }

    void GenerateLeftHouses()
    {
        Vector3 firstSpawnPosition = housePrefabLocations[1].transform.position;
        for (int i = 1; i < 14; i++)
        {
            int j = Random.Range(0,2);
            GameObject newHouse = UnityEngine.Object.Instantiate(housePrefabs[j]);
            MeshRenderer meshRender = newHouse.GetComponent<MeshRenderer>();
            string targetMaterialName = GetColourMappingName(newHouse.name);
            SetHouseColor(meshRender, targetMaterialName, chanceOfBeingAvailable);
            
            float houseHeight = newHouse.GetComponent<Renderer>().bounds.size.y;
            Vector3 position = new Vector3(firstSpawnPosition.x, houseHeight / 2, firstSpawnPosition.z + 20 * i);
            
            newHouse.transform.position = position;
            newHouse.transform.rotation = Quaternion.Euler(0, -90, 0);
            newHouse.transform.SetParent(housePrefabLocations[1].parent);
        }

        Vector3 firstSpawnPositionVisual = housePrefabLocations[6].transform.position;
        for (int i = 1; i < 14; i++)
        {
            int j = Random.Range(0,2);
            GameObject newHouse = UnityEngine.Object.Instantiate(housePrefabs[j]);
            MeshRenderer meshRender = newHouse.GetComponent<MeshRenderer>();
            string targetMaterialName = GetColourMappingName(newHouse.name);
            SetHouseColor(meshRender, targetMaterialName, chanceOfBeingAvailable);
            
            float houseHeight = newHouse.GetComponent<Renderer>().bounds.size.y;
            Vector3 position = new Vector3(firstSpawnPositionVisual.x, houseHeight / 2, firstSpawnPositionVisual.z + 20 * i);
            
            newHouse.transform.position = position;
            newHouse.transform.rotation = Quaternion.Euler(0, -90, 0);
            newHouse.transform.SetParent(housePrefabLocations[6].parent);
        }
    }

    void GenerateIntersectionLeftHouses(){
        Vector3 firstSpawnPosition = housePrefabLocations[2].transform.position;
        for (int i = 1; i < 6; i++)
        {
            int j = Random.Range(0,2);
            GameObject newHouse = UnityEngine.Object.Instantiate(housePrefabs[j]);
            MeshRenderer meshRender = newHouse.GetComponent<MeshRenderer>();
            string targetMaterialName = GetColourMappingName(newHouse.name);
            SetHouseColor(meshRender, targetMaterialName, chanceOfBeingAvailable);
            
            float houseHeight = newHouse.GetComponent<Renderer>().bounds.size.y;
            Vector3 position = new Vector3(firstSpawnPosition.x + 20 * i, houseHeight / 2, firstSpawnPosition.z);
            
            newHouse.transform.position = position;
            newHouse.transform.rotation = Quaternion.Euler(0, 180, 0);
            newHouse.transform.SetParent(housePrefabLocations[2].parent);
        }

        Vector3 lastSpawnPosition = housePrefabLocations[3].transform.position;
        for (int i = 1; i < 6; i++)
        {
            int j = Random.Range(0,2);
            GameObject newHouse = UnityEngine.Object.Instantiate(housePrefabs[j]);
            MeshRenderer meshRender = newHouse.GetComponent<MeshRenderer>();
            string targetMaterialName = GetColourMappingName(newHouse.name);
            SetHouseColor(meshRender, targetMaterialName, chanceOfBeingAvailable);
            
            float houseHeight = newHouse.GetComponent<Renderer>().bounds.size.y;
            Vector3 position = new Vector3(lastSpawnPosition.x - 20 * i, houseHeight / 2, lastSpawnPosition.z);
            
            newHouse.transform.position = position;
            newHouse.transform.rotation = Quaternion.Euler(0, 180, 0);
            newHouse.transform.SetParent(housePrefabLocations[3].parent);
        }
    }

    void GenerateIntersectionRightHouses(){
        Vector3 firstSpawnPosition = housePrefabLocations[4].transform.position;
        for (int i = 1; i < 6; i++)
        {
            int j = Random.Range(0,2);
            GameObject newHouse = UnityEngine.Object.Instantiate(housePrefabs[j]);
            MeshRenderer meshRender = newHouse.GetComponent<MeshRenderer>();
            string targetMaterialName = GetColourMappingName(newHouse.name);
            SetHouseColor(meshRender, targetMaterialName, chanceOfBeingAvailable);
            
            float houseHeight = newHouse.GetComponent<Renderer>().bounds.size.y;
            Vector3 position = new Vector3(firstSpawnPosition.x + 20 * i, houseHeight / 2, firstSpawnPosition.z);
            
            newHouse.transform.position = position;
            newHouse.transform.rotation = Quaternion.Euler(0, 0, 0);
            newHouse.transform.SetParent(housePrefabLocations[4].parent);
        }

        Vector3 lastSpawnPosition = housePrefabLocations[5].transform.position;
        for (int i = 1; i < 6; i++)
        {
            int j = Random.Range(0,2);
            GameObject newHouse = UnityEngine.Object.Instantiate(housePrefabs[j]);
            MeshRenderer meshRender = newHouse.GetComponent<MeshRenderer>();
            string targetMaterialName = GetColourMappingName(newHouse.name);
            SetHouseColor(meshRender, targetMaterialName, chanceOfBeingAvailable);
            
            float houseHeight = newHouse.GetComponent<Renderer>().bounds.size.y;
            Vector3 position = new Vector3(lastSpawnPosition.x - 20 * i, houseHeight / 2, lastSpawnPosition.z);
            
            newHouse.transform.position = position;
            newHouse.transform.rotation = Quaternion.Euler(0, 0, 0);
            newHouse.transform.SetParent(housePrefabLocations[5].parent);
        }
    }

    private Color GetRandomNonGreyColor()
    {
        Color randomColor;
        do
        {
            randomColor = new Color(Random.value, Random.value, Random.value);
        }
        while (randomColor.r == randomColor.g && randomColor.g == randomColor.b); 
        return randomColor;
    }

    private string GetColourMappingName(string houseName){
        if (houseName == "House1(Clone)")
        {
            return "map4";
        }
        else
        {
            return "map2";
        }
    }

    private void AssignHouseStatus(GameObject house, bool isAvailable)
    {
        // Attach HouseStatus component and set its availability
        HouseHandler houseStatus = house.GetComponent<HouseHandler>();
        if (houseStatus == null)
        {
            houseStatus = house.AddComponent<HouseHandler>();
        }
        houseStatus.SetAvailability(isAvailable);
    }

    private void SetHouseColor(MeshRenderer meshRender, string targetMaterialName, float chanceOfBeingAvailable)
    {
        Material[] materials = meshRender.materials;
        bool isAvailable = false;

        for (int k = 0; k < materials.Length; k++)
        {
            if (materials[k].name.StartsWith(targetMaterialName))
            {
                isAvailable = Random.value < chanceOfBeingAvailable;
                Color targetColor = isAvailable ? GetRandomNonGreyColor() : Color.grey;

                materials[k].color = targetColor;
                break;
            }
        }

        meshRender.materials = materials;
        AssignHouseStatus(meshRender.gameObject, isAvailable);
    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentManager
{
    public GameObject roadLine;
    public List<GameObject> housePrefabs;

    public EnvironmentManager(GameObject lines, List<GameObject> housePre){
        roadLine = lines;
        housePrefabs = housePre;
    }
    
    public void onStart()
    {
        GenerateRoadLines();
        GenerateHouses();
    }

    public void onUpdate()
    {
        
    }

    void GenerateRoadLines(){

    }

    void GenerateHouses(){

    }
}

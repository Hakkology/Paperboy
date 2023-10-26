using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{

    public EnvironmentManager environmentManager; 
    public BikerManager bikerManager;
    public TreeManager treeManager;

    [Header("Biker Manager Objects")]
    public Transform bikerTransform;
    public Transform cameraTransform;

    [Header("Environment Manager Objects")]
    public GameObject roadLine;
    public GameObject roadLine2;
    public List<GameObject> houseTypes;
    public Transform leftFirstHouse;
    public Transform rightFirstHouse;
    public Transform leftFirstInterHouse;
    public Transform rightFirstInterHouse;
    public Transform leftLastInterHouse;
    public Transform rightLastInterHouse;

    [Header("Tree Manager Objects")]
    public List<GameObject> trees;
    public List<Transform> treeSpawnLocations;

    void Awake() {
        bikerManager = new BikerManager(bikerTransform, cameraTransform);
        environmentManager = new EnvironmentManager(roadLine, roadLine2, houseTypes, leftFirstHouse, rightFirstHouse, 
        leftFirstInterHouse, rightFirstInterHouse, leftLastInterHouse, rightLastInterHouse);
        treeManager = new TreeManager(trees, treeSpawnLocations);
    }

    void Start(){
        treeManager.onStart();
        bikerManager.onStart();
        environmentManager.onStart();
    }

    // Update is called once per frame
    void Update(){
        bikerManager.onUpdate();
        environmentManager.onUpdate();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{

    public EnvironmentManager environmentManager; 
    public BikerManager bikerManager;
    public TreeManager treeManager;
    public ObstacleManager obstacleManager;
    public AnimationManager animationManager;

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

    [Header("Obstacle Manager Objects")]
    public List<GameObject> obstaclePrefabs;
    public List<Transform> obstacleSpawnPoints;

    [Header("Animation Manager Objects")]
    public List<GameObject> bikeWheels;
    public List<GameObject> bikePedals;

    void Awake() {
        bikerManager = new BikerManager(bikerTransform, cameraTransform);
        environmentManager = new EnvironmentManager(roadLine, roadLine2, houseTypes, leftFirstHouse, rightFirstHouse, 
        leftFirstInterHouse, rightFirstInterHouse, leftLastInterHouse, rightLastInterHouse);
        treeManager = new TreeManager(trees, treeSpawnLocations);
        obstacleManager = new ObstacleManager(obstaclePrefabs, obstacleSpawnPoints);
        animationManager = new AnimationManager(bikeWheels, bikePedals);
    }

    void Start(){
        treeManager.onStart();
        bikerManager.onStart();
        environmentManager.onStart();
        obstacleManager.onStart();
        animationManager.onStart();
    }

    void Update(){
        bikerManager.onUpdate();
        environmentManager.onUpdate();
        animationManager.onUpdate();
    }
}

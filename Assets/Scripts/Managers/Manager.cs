using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public EnvironmentManager environmentManager; 
    public BikerManager bikerManager;
    public BikerHandler bikerPedaling;
    public TreeManager treeManager;
    public ObstacleManager obstacleManager;
    public AnimationManager animationManager;

    [Header("Biker Manager Objects")]
    public Transform bikerTransform;
    public Transform cameraTransform;
    [Header ("Biker Pedaling Objects")]
    public Transform leftFootTransform;
    public Transform rightFootTransform;
    public Transform leftPedalTransform;
    public Transform rightPedalTransform;

    [Header("Environment Manager Objects")]
    public GameObject roadLine;
    public GameObject roadLine2;
    public List<GameObject> houseTypes;
    public List<Transform> houseLocations;
    // public Transform leftFirstHouse;
    // public Transform rightFirstHouse;
    // public Transform leftFirstInterHouse;
    // public Transform rightFirstInterHouse;
    // public Transform leftLastInterHouse;
    // public Transform rightLastInterHouse;

    [Header("Tree Manager Objects")]
    public List<GameObject> trees;
    public List<Transform> treeSpawnLocations;

    [Header("Obstacle Manager Objects")]
    public List<GameObject> obstaclePrefabs;
    public List<Transform> obstacleSpawnPoints;

    [Header("Animation Manager Objects")]
    public List<GameObject> bikeWheels;
    public List<GameObject> bikePedals;

    [Header("Car Spawning Mechanics")]
    public List<GameObject> carPrefabs; 
    public List<CarPath> carPathWaypoints;
    private CarSpawner carSpawner;

    void Awake() {
        bikerManager = new BikerManager(bikerTransform, cameraTransform);
        animationManager = new AnimationManager(bikeWheels, bikePedals);
        bikerPedaling = new BikerHandler(leftFootTransform, rightFootTransform, leftPedalTransform, rightPedalTransform);
        environmentManager = new EnvironmentManager(roadLine, roadLine2, houseTypes, houseLocations);
        treeManager = new TreeManager(trees, treeSpawnLocations);
        obstacleManager = new ObstacleManager(obstaclePrefabs, obstacleSpawnPoints);
        carSpawner = new CarSpawner(carPrefabs, carPathWaypoints);
    }

    void Start(){
        treeManager.onStart();
        bikerManager.onStart();
        environmentManager.onStart();
        obstacleManager.onStart();
        animationManager.onStart();
        carSpawner.onStart();
        bikerPedaling.onUpdate();
        
        StartCoroutine(carSpawner.SpawnCarsCoroutine());
    }

    void Update(){
        bikerManager.onUpdate();
        environmentManager.onUpdate();
        animationManager.onUpdate();
    }
}

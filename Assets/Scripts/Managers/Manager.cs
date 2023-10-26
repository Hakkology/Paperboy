using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{

    public EnvironmentManager environmentManager; 
    public BikerManager bikerManager;

    [Header("Biker Manager Objects")]
    public Transform bikerTransform;
    public Transform cameraTransform;

    [Header("Environment Manager Objects")]
    public GameObject roadLine;
    public List<GameObject> houseTypes;
    public Transform leftFirstHouse;
    public Transform rightFirstHouse;

    void Awake() {
        bikerManager = new BikerManager(bikerTransform, cameraTransform);
        environmentManager = new EnvironmentManager(roadLine, houseTypes, leftFirstHouse, rightFirstHouse);
    }

    void Start(){
        bikerManager.onStart();
        environmentManager.onStart();
    }

    // Update is called once per frame
    void Update(){
        bikerManager.onUpdate();
        environmentManager.onUpdate();
    }
}

using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CarPath{
    [Header("Path Segments")]
    public PathSegment spawnPoint;
    public PathSegment rotationPoint;
    public PathSegment endPoint;
}

[System.Serializable]
public class InitialPath{
    [Header("Initial Path Segments")]
    public PathSegment spawnPoint;
    public PathSegment endPoint;
}

[System.Serializable]
public class PathSegment{
    public Transform point;
    public Vector3 rotation;
}
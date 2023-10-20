using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Biker : MonoBehaviour
{

    public float speed = 2f;
    float min_speed = 2f;
    float max_speed = 4f;
    float rotationSpeed =15;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.UpArrow)) speed = max_speed;
        if (Input.GetKeyUp(KeyCode.UpArrow)) speed = min_speed;

        if (Input.GetKey(KeyCode.LeftArrow)) transform.rotation *= UnityEngine.Quaternion.Euler(0, -rotationSpeed * Time.deltaTime, 0);
        if (Input.GetKey(KeyCode.RightArrow)) transform.rotation *= UnityEngine.Quaternion.Euler(0, +rotationSpeed * Time.deltaTime, 0);

    }
}

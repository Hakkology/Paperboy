using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Biker : MonoBehaviour
{
    UnityEngine.Vector3 currentRotation;

    public float speed = 2f;
    float min_speed = 2f;
    float max_speed = 4f;
    float rotationSpeed =50;
    float max_rotation_value = 30;
    float min_rotation_value= -30;


    void Start()
    {
        currentRotation = transform.localEulerAngles;
    }

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
        currentRotation.y = Mathf.Clamp(currentRotation.y, min_rotation_value, max_rotation_value);
        transform.rotation = UnityEngine.Quaternion.Euler(currentRotation);

        Camera.main.transform.position += UnityEngine.Vector3.forward * speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.UpArrow)) speed = max_speed;
        if (Input.GetKeyUp(KeyCode.UpArrow)) speed = min_speed;
        if (Input.GetKey(KeyCode.LeftArrow)) currentRotation.y -= rotationSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.RightArrow)) currentRotation.y += rotationSpeed * Time.deltaTime;
    }
}

using UnityEngine;

public class BikerManager
{
    private Vector3 currentRotation;
    private Transform bikerTransform;
    private Transform cameraTransform;

    public float speed = 2f;
    float min_speed = 2f;
    [SerializeField]
    float max_speed = 4f;
    float rotationSpeed = 50;
    float max_rotation_value = 30;
    float min_rotation_value = -30;

    public BikerManager(Transform bikerT, Transform cameraT)
    {
        bikerTransform = bikerT;
        cameraTransform = cameraT;
        currentRotation = bikerTransform.localEulerAngles;
    }

    public void onStart()
    {
        currentRotation = bikerTransform.localEulerAngles;
    }

    public void onUpdate()
    {
        bikerTransform.position += bikerTransform.forward * speed * Time.deltaTime;
        currentRotation.y = Mathf.Clamp(currentRotation.y, min_rotation_value, max_rotation_value);
        bikerTransform.rotation = Quaternion.Euler(currentRotation);

        cameraTransform.position += Vector3.forward * speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.UpArrow)) speed = max_speed;
        if (Input.GetKeyUp(KeyCode.UpArrow)) speed = min_speed;
        if (Input.GetKey(KeyCode.LeftArrow)) currentRotation.y -= rotationSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.RightArrow)) currentRotation.y += rotationSpeed * Time.deltaTime;
    }
}

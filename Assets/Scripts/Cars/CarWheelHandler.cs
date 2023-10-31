using System.Collections.Generic;
using UnityEngine;
public class CarWheelHandler
{
    private List<GameObject> wheels;
    private CarMover carMover;
    private Vector3 rotationAxis = new Vector3(0, 0, 1);
    private float rotationMultiplier = 50.0f; 

    public CarWheelHandler(CarMover carMover, List<GameObject> wheels)
    {
        this.carMover = carMover;
        this.wheels = wheels;
    }

    public void OnUpdate()
    {
        RotateWheels();
    }

    private void RotateWheels()
    {
        if (carMover != null)
        {
            if (wheels == null)
            {
                Debug.LogError("Wheels array is null!");
                return;
            }

            Debug.Log($"Wheels array length: {wheels.Count}");

            float rotationAmount = carMover._speed * rotationMultiplier;

            for (int i = 0; i < wheels.Count; i++)
            {
                if (wheels[i] != null)
                {
                    wheels[i].transform.Rotate(rotationAxis, rotationAmount);
                }
                else
                {
                    Debug.LogError($"A wheel at index {i} in the wheels array is null!");
                }
            }
        }
        else
        {
            Debug.LogError("carMover is null!");
        }
    }

}

using System.Collections.Generic;
using UnityEngine;
public class CarWheelHandler
{
    private List<GameObject> wheels;
    private CarMover carMover;
    private Vector3 rotationAxis = new Vector3(1, 0, 0);
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
            float rotationAmount = carMover._speed * rotationMultiplier;
            for (int i = 0; i < wheels.Count; i++){
                wheels[i].transform.Rotate(rotationAxis, rotationAmount);
            }
        }
    }
}

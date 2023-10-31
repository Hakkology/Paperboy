using System.Collections.Generic;
using UnityEngine;

public class AnimationManager
{
    public float wheelRotationSpeed = 360f;
    public float pedalRotationSpeed = 180;
    public List<GameObject> bikeWheels;
    public List<GameObject> bikePedals;
    public BikerManager bikerManager;

    public AnimationManager(List<GameObject> bikeW, List<GameObject> bikeP){
        bikeWheels = bikeW;
        bikePedals = bikeP;
    }

    public void onStart(){
        
    }

    public void onUpdate(){
        BikeWheelsRotation();
        BikePedalsRotation();
    }

    private void BikePedalsRotation()
    {
        float rotationAmount = pedalRotationSpeed * Time.deltaTime;

        foreach (GameObject pedal in bikePedals)
        {
            pedal.transform.Rotate(rotationAmount, 0, 0); 
        }
    }


    private void BikeWheelsRotation()
    {
        float rotationAmount = wheelRotationSpeed * Time.deltaTime;

        foreach (GameObject wheel in bikeWheels)
        {
            wheel.transform.Rotate(rotationAmount, 0, 0); 
        }
    }
}

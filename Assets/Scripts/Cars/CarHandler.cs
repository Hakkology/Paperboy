using System.Collections.Generic;
using UnityEngine;
public class CarHandler : MonoBehaviour
{
    private float soundTriggerDistance = 1.0f;
    private bool closeProximity=false;
    private CarMover carMover;
    private Transform bikerTransform;
    // private CarWheelHandler carWheelHandler;
    // [SerializeField]
    // private List<GameObject> wheels;

    public void Initialize(CarPath path, Transform bikerT)
    {
        this.bikerTransform = bikerT;
        carMover = new CarMover(transform, path);
        carMover.OnStart();
        // carWheelHandler = new CarWheelHandler(carMover, wheels);
    }

    private void Update()
    {
        if (carMover != null)
        {
            carMover.OnUpdate();
        }

        // if (carWheelHandler != null)
        // {
        //     carWheelHandler.OnUpdate();
        // }

        CheckProximityToPlayer();
    }

        private void CheckProximityToPlayer()
        {
            
            if (bikerTransform != null)
            {
                if (Mathf.Abs(transform.position.z - bikerTransform.position.z) <= soundTriggerDistance && !closeProximity)
                {
                    closeProximity = true;
                    string soundToPlay = Random.value > 0.5 ? "CarSpeeding" : "CarHorn";
                    AudioManager.Instance.PlaySound(soundToPlay);
                }
            }
        }
}

using System.Collections.Generic;
using UnityEngine;
public class CarHandler : MonoBehaviour
{
    private CarMover carMover;
    // private CarWheelHandler carWheelHandler;
    // [SerializeField]
    // private List<GameObject> wheels;

    public void Initialize(CarPath path)
    {
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
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.layer == 6)
        {
            return;
        }
        if (other.gameObject.layer == 7)
        {
            Destroy(other.gameObject);
        }
    }
}

using UnityEngine;


public class HouseHandler : MonoBehaviour
{
    [SerializeField]
    private bool isAvailable;

    public bool IsAvailable => isAvailable;

    public void SetAvailability(bool available)
    {
        isAvailable = available;
    }
}

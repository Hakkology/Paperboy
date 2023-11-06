using UnityEngine;

public class NewspaperHandler : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]
    private float throwVectorX;

    public void Initialize(float speed)
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(throwVectorX, speed, 0); 
    }

    private void OnTriggerEnter(Collider other) {

        Destroy(this.gameObject, 3f); 

        if (other.gameObject.layer == 10) // If it's a window
        {
            SuccessThrowReflectVelocity(other);
        }
        else // If it's any other object
        {
            FailedThrowReflectVelocity();
        }
    }

    private void FailedThrowReflectVelocity()
    {
        Vector3 presumedNormal = Vector3.right;

        if(rb.velocity.x > 0)
        {
            presumedNormal = Vector3.left;
        }

        Vector3 reflection = Vector3.Reflect(rb.velocity, presumedNormal);
        rb.velocity = new Vector3(Mathf.Abs(reflection.x)/2, reflection.y/2, 0);
    }

    private void SuccessThrowReflectVelocity(Collider other){
        rb.velocity = new Vector3(-1f, 0, 0);
        if (other.gameObject.GetComponentInParent<HouseHandler>().IsAvailable)
        {
            UIManager.Instance.AddScore(20);
        }
        else
        {
            UIManager.Instance.AddScore(10);
        }
    }
}

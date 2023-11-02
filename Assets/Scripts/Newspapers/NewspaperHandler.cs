using UnityEngine;

public class NewspaperHandler : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]
    private float throwVectorX;

    public void Initialize(float speed)
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = true;
        rb.velocity = new Vector3(throwVectorX, speed, 0); 
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject, 1f); 

        if (collision.gameObject.layer == 11) // If it's a window
        {
            rb.velocity = new Vector3(-1f, 0, 0);
        }
        else // If it's any other object
        {
            Vector3 reflection = Vector3.Reflect(rb.velocity, collision.contacts[0].normal);
            rb.velocity = new Vector3(Mathf.Abs(reflection.x), reflection.y, 0);
        }
    }
}

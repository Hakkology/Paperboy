using UnityEngine;

public class BikerHandler : MonoBehaviour
{
    // private Transform leftFootTransform;
    // private Transform rightFootTransform;
    // private Transform leftPedalTransform;
    // private Transform rightPedalTransform;
    
    // private Vector3 footOffset = new Vector3(0, 0.05f, 0);

    // public BikerHandler(Transform leftFoot, Transform rightFoot, Transform leftPedal, Transform rightPedal)
    // {
    //     leftFootTransform = leftFoot;
    //     rightFootTransform = rightFoot;
    //     leftPedalTransform = leftPedal;
    //     rightPedalTransform = rightPedal;
    // }

    // public void onUpdate()
    // {
    //     UpdateFootPosition(leftFootTransform, leftPedalTransform);
    //     UpdateFootPosition(rightFootTransform, rightPedalTransform);
    // }

    // private void UpdateFootPosition(Transform foot, Transform pedal)
    // {
    //     foot.position = pedal.position + footOffset;
    // }

    private void OnCollisionEnter(Collision other) {
        
        if (other.gameObject.layer == 6)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer == 7 || other.gameObject.layer == 8 || other.gameObject.layer == 9)
        {
            Destroy(gameObject);
        }
    }
}

using UnityEngine;

public class BikerHandler
{
    private Transform leftFootTransform;
    private Transform rightFootTransform;
    private Transform leftPedalTransform;
    private Transform rightPedalTransform;
    
    private Vector3 footOffset = new Vector3(0, 0.05f, 0);

    public BikerHandler(Transform leftFoot, Transform rightFoot, Transform leftPedal, Transform rightPedal)
    {
        leftFootTransform = leftFoot;
        rightFootTransform = rightFoot;
        leftPedalTransform = leftPedal;
        rightPedalTransform = rightPedal;
    }

    public void onUpdate()
    {
        UpdateFootPosition(leftFootTransform, leftPedalTransform);
        UpdateFootPosition(rightFootTransform, rightPedalTransform);
    }

    private void UpdateFootPosition(Transform foot, Transform pedal)
    {
        foot.position = pedal.position + footOffset;
    }
}

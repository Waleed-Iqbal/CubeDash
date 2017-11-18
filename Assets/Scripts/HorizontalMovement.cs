using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{

    // Use this for initialization
    private bool movingTowardLeft = true;
    private float offsetEachFrame = 0f;
    private float magnitude = 4f;
    // Update is called once per frame
    void Update()
    {
        offsetEachFrame = movingTowardLeft ? -0.1f : 0.1f;
        transform.position = new Vector3(transform.position.x + offsetEachFrame, transform.position.y, transform.position.z);

        if (transform.position.x <= -magnitude)
            movingTowardLeft = false;
        else if (transform.position.x >= magnitude)
            movingTowardLeft = true;

    }
}

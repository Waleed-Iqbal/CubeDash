using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{

    // Use this for initialization
    private bool movingTowardLeft;
    private float offsetEachFrame;
    private float magnitude;

    private void Start()
    {
        movingTowardLeft = true;
        magnitude = 4f;
    }

    // Update is called once per frame
    void Update()
    {
        offsetEachFrame = movingTowardLeft ? -0.1f : 0.1f;
        transform.position = new Vector3(transform.position.x + offsetEachFrame, transform.position.y, transform.position.z);

        if (transform.position.x <= -magnitude)
            movingTowardLeft = false; // now start moving to right
        else if (transform.position.x >= magnitude)
            movingTowardLeft = true; // now start moving to left



    }
}

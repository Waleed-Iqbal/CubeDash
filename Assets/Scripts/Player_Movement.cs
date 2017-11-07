using UnityEngine;

public class Player_Movement : MonoBehaviour
{

    public Rigidbody rb;
    public float forwardForce = 1000f;
    public float sideWayForce = 120f;
    public float backwardForce = 1000f;
    private float maxRightXPosition = 4f;
    private float middleXPosition = 1f;
    private float maxLeftXPosition = -2f;

    private float xPositionDifference = 1;

    // x -3.743 ----- x 5.752
    // Use this for initialization
    void Start()
    {

    }

    // Marked as "Fixed"Update because we are using it to mess with physics
    void Update()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (Input.GetKey("w"))
        {
            if (rb.position.y <= 0.76f) // only jump when on ground
                rb.AddForce(0, forwardForce * 7 * Time.deltaTime, 0);

        }

        if (Input.GetKey("d"))
            if (rb.position.x < maxRightXPosition)
                rb.MovePosition(new Vector3(rb.position.x + xPositionDifference, rb.position.y, rb.position.z));

        //    rb.AddForce(sideWayForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

        if (Input.GetKey("a"))
            if (rb.position.x > maxLeftXPosition)
                rb.MovePosition(new Vector3(rb.position.x - xPositionDifference, rb.position.y, rb.position.z));

        //AddForce(-sideWayForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

        //if (Input.GetKey("s"))
        //    rb.AddForce(0, 0, -50 * Time.deltaTime, ForceMode.VelocityChange);


    }
}

using UnityEngine;

public class Player_Movement : MonoBehaviour
{

    public Rigidbody rb;
    public float forwardForce = 1000f;
    private float maxRightXPosition = 3.4f;
    private float middleXPosition = 1f;
    private float maxLeftXPosition = -1.4f;

    private float xPositionDifference = 1.2f;

    // Use this for initialization
    void Start()
    {

    }

    // Marked as "Fixed"Update because we are using it to mess with physics
    void Update()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.W) && rb.position.y <= 0.76f)  // only jump when on ground
            rb.AddForce(0, forwardForce * 10 * Time.deltaTime, 0);

        if (rb.position.y > 2f)
            rb.AddForce(0, -forwardForce/2 * Time.deltaTime, 0);

        if (Input.GetKeyDown(KeyCode.D)) //Input.GetKey("d"))
        {

            if (rb.position.x == middleXPosition)
                rb.MovePosition(new Vector3(maxRightXPosition, rb.position.y, rb.position.z));
            else if (rb.position.x == maxLeftXPosition)
                rb.MovePosition(new Vector3(middleXPosition, rb.position.y, rb.position.z));
        }

        //    rb.AddForce(sideWayForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

        if (Input.GetKeyDown(KeyCode.A))
        {

            if (rb.position.x == maxRightXPosition)
                rb.MovePosition(new Vector3(middleXPosition, rb.position.y, rb.position.z));
            else if (rb.position.x == middleXPosition)
                rb.MovePosition(new Vector3(maxLeftXPosition, rb.position.y, rb.position.z));
        }


    }
}

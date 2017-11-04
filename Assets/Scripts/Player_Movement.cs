using UnityEngine;

public class Player_Movement : MonoBehaviour
{

    public Rigidbody rb;
    public float forwardForce = 1000f;
    public float sideWayForce = 120f;
    public float backwardForce = 1000f;

    // Use this for initialization
    void Start()
    {

    }

    // Marked as "Fixed"Update because we are using it to mess with physics
    void Update()
    {

        if (Input.GetKey("w"))
            rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (Input.GetKey("d"))
            rb.AddForce(sideWayForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

        if (Input.GetKey("a"))
            rb.AddForce(-sideWayForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

        if (Input.GetKey("s"))
            rb.AddForce(0, 0, -50 * Time.deltaTime, ForceMode.VelocityChange);


    }
}

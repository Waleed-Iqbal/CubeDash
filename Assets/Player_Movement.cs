using UnityEngine;

public class Player_Movement : MonoBehaviour
{

    public Rigidbody rb;
    public float forwardForce = 1000f;
    public float rightSideForce = 10f;
    public float leftSideForce = -10f;
    // Use this for initialization
    void Start()
    {

    }

    // Marked as "Fixed"Update because we are using it to mess with physics
    void Update()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (Input.GetKey("d"))
            rb.AddForce(rightSideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

        if (Input.GetKey("a"))
            rb.AddForce(leftSideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);


    }
}

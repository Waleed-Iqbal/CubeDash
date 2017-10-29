using UnityEngine;

public class Player_Movement : MonoBehaviour
{

    public Rigidbody rb;
    public float forwardForce = 5000f;
    public float rightSideForce = 50f;
    public float leftSideForce = -50f;
    // Use this for initialization
    void Start()
    {

    }

    // Marked as "Fixed"Update because we are using it to mess with physics
    void Update()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (Input.GetKey("d"))
            rb.AddForce(rightSideForce * Time.deltaTime, 0, 0);

        if (Input.GetKey("a"))
            rb.AddForce(leftSideForce * Time.deltaTime, 0, 0);


    }
}

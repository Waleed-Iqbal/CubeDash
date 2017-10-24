using UnityEngine;

public class Player_Movement : MonoBehaviour
{

    public Rigidbody rb;

    // Use this for initialization
    void Start()
    {

    }

    // Marked as "Fixed"Update because we are using it to mess with physics
    void FixedUpdate()
    {
        rb.AddForce(0, 0, 1000 * Time.deltaTime);

    }
}

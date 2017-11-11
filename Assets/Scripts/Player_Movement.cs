using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player_Movement : MonoBehaviour
{
    // current position of ground
    private enum CurrentPosition { Middle, Left, Right }
    private CurrentPosition currentPosition = CurrentPosition.Middle;

    public Rigidbody rb;

    public SwipeControl swipeControl;

    private float forwardForce = 8000f;
    private float sideWayXForce = 1300f;
    private float sideWayYForce = 1500f;
    private float downwardForceWhenInAir = -200f;
    private float positionToApplyDownwardForce = 2f;
    // Use this for initialization
    void Start()
    {
    }


    // Marked as "Fixed"Update because we are using it to mess with physics
    void Update()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime); // forward movement

        if (rb.position.y > positionToApplyDownwardForce)
        {
            // this makes player comes down on ground faster when jumped by applying a downward
            // force when in air (more than 2 units above ground)
            //rb.AddForce(0, -forwardForce / 2 * Time.deltaTime, 0);
            rb.AddForce(0, downwardForceWhenInAir, 0);
        }

        if ((Input.GetKeyDown(KeyCode.W) || swipeControl.SwipeUp) && isPlayerOnGround()) 
            MakePlayerJump();

        if ((Input.GetKeyDown(KeyCode.D) || swipeControl.SwipeRight) && isPlayerOnGround())
            MovePlayerRight();

        if ((Input.GetKeyDown(KeyCode.A) || swipeControl.SwipeLeft) && isPlayerOnGround())
            MovePlayerLeft();

    }

    private bool isPlayerOnGround()
    {
        return rb.position.y <= 1.2f;
    }

    private void MakePlayerJump()
    {
        rb.AddForce(0, forwardForce * 18 * Time.deltaTime, 0);
    }

    private void MovePlayerRight()
    {
        if (currentPosition == CurrentPosition.Middle)
        {
            rb.AddForce(sideWayXForce, sideWayYForce, 0);
            currentPosition = CurrentPosition.Right;
        }
        else if (currentPosition == CurrentPosition.Left)
        {
            rb.AddForce(sideWayXForce, sideWayYForce, 0);
            currentPosition = CurrentPosition.Middle;
        }
    }

    private void MovePlayerLeft()
    {
        if (currentPosition == CurrentPosition.Right)
        {
            rb.AddForce(-sideWayXForce, sideWayYForce, 0);
            currentPosition = CurrentPosition.Middle;
        }
        else if (currentPosition == CurrentPosition.Middle)
        {
            rb.AddForce(-sideWayXForce, sideWayYForce, 0);
            currentPosition = CurrentPosition.Left;
        }
    }
}

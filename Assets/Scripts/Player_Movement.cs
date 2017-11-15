using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player_Movement : MonoBehaviour
{
    // current position of ground
    private enum CurrentPosition { Middle, Left, Right }
    private CurrentPosition currentPosition = CurrentPosition.Middle;

    public Rigidbody player;
    public GameObject ground;

    public SwipeControl swipeControl;

    private float forwardForce;
    private Vector3 sideWayMovementDestination;
    private float playerCurrentVelocity;
    private float sidewayMotionSmoothTime;


    private float maxLeftPosition;
    private float maxRightPosition;
    private float middlePosition;
    private float downwardForceWhenInAir;
    private float positionToApplyDownwardForce;

    // used for smooth horizontal transition of player
    private bool isPlayerMovingSideWays;

    private void Start()
    {
        sideWayMovementDestination = player.transform.position;
        forwardForce = 8000f;
        //sideWayXForce = 2000f;
        //sideWayYForce = 500f;
        playerCurrentVelocity = 0;
        sidewayMotionSmoothTime = 0.3f;


        maxLeftPosition = -3f;
        maxRightPosition = 3f;
        middlePosition = 0f;
        downwardForceWhenInAir = -200f;
        positionToApplyDownwardForce = 2f;

        isPlayerMovingSideWays = false;

    }

    // Marked as "Fixed"Update because we are using it to mess with physics
    void Update()
    {
        if (isPlayerMovingSideWays)
        {
            player.transform.position = Vector3.Lerp(player.transform.position, sideWayMovementDestination, sidewayMotionSmoothTime);
            Debug.Log("Lerping");
            isPlayerMovingSideWays = Vector3.Distance(player.transform.position, sideWayMovementDestination) >= 1f;
                //player.transform.position.x != sideWayMovementDestination.x;
            //Vector3.Distance(player.transform.position, sideWayMovementDestination) >= 0.1f;
            //
        }
        //else
        //{
        //    sideWayMovementDestination = player.transform.position;
        //}


        playerCurrentVelocity = forwardForce * Time.deltaTime;
        player.AddForce(0, 0, playerCurrentVelocity); // forward movement
        //player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z + 1f);
        if (player.position.y > positionToApplyDownwardForce)
        {
            // this makes player comes down on ground faster when jumped by applying a downward
            // force when in air (more than 2 units above ground)
            //rb.AddForce(0, -forwardForce / 2 * Time.deltaTime, 0);
            player.AddForce(0, downwardForceWhenInAir, 0);
        }


        // if (!isPlayerMovingSideWays)
        //  {
        if ((Input.GetKeyDown(KeyCode.W) || swipeControl.SwipeUp) && IsPlayerOnGround())
            MakePlayerJump();

        if ((Input.GetKeyDown(KeyCode.D) || swipeControl.SwipeRight) && IsPlayerOnGround())
            MovePlayerRight();

        if ((Input.GetKeyDown(KeyCode.A) || swipeControl.SwipeLeft) && IsPlayerOnGround())
            MovePlayerLeft();
        // }
        // else // player is moving sideways
        // {
        
        //     isPlayerMovingSideWays = Vector3.Distance(player.transform.position, sideWayMovementDestination) >= 0.1f;
        // }

    }

    private bool IsPlayerOnGround()
    {
        return player.position.y <= 1.2f;
    }

    private void MakePlayerJump()
    {
        player.AddForce(0, playerCurrentVelocity * 18, 0);
    }

    private void MovePlayerRight()
    {
        if (currentPosition == CurrentPosition.Middle)
        {
            currentPosition = CurrentPosition.Right;
            sideWayMovementDestination = new Vector3(maxRightPosition, player.transform.position.y, player.transform.position.z);
            player.transform.position = Vector3.Lerp(player.transform.position, sideWayMovementDestination, sidewayMotionSmoothTime);
            isPlayerMovingSideWays = true;
        }
        else if (currentPosition == CurrentPosition.Left)
        {
            currentPosition = CurrentPosition.Middle;
            sideWayMovementDestination = new Vector3(middlePosition, player.transform.position.y, player.transform.position.z);
            player.transform.position = Vector3.Lerp(player.transform.position, sideWayMovementDestination, sidewayMotionSmoothTime);
            isPlayerMovingSideWays = true;
        }
    }

    private void MovePlayerLeft()
    {
        if (currentPosition == CurrentPosition.Right)
        {
            currentPosition = CurrentPosition.Middle;
            sideWayMovementDestination = new Vector3(middlePosition, player.transform.position.y, player.transform.position.z);
            player.transform.position = Vector3.Lerp(player.transform.position, sideWayMovementDestination, sidewayMotionSmoothTime);
            isPlayerMovingSideWays = true;
        }
        else if (currentPosition == CurrentPosition.Middle)
        {
            currentPosition = CurrentPosition.Left;
            sideWayMovementDestination = new Vector3(maxLeftPosition, player.transform.position.y, player.transform.position.z);
            player.transform.position = Vector3.Lerp(player.transform.position, sideWayMovementDestination, sidewayMotionSmoothTime);
            isPlayerMovingSideWays = true;
        }
    }
}

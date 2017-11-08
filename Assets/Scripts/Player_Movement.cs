using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player_Movement : MonoBehaviour
{

    public Rigidbody rb;
    public float forwardForce = 1000f;
    private float maxRightXPosition = 3.4f;
    private float middleXPosition = 1f;
    private float maxLeftXPosition = -1.4f;

    //private float xPositionDifference = 1.2f;

    // Use this for initialization
    void Start()
    {
    }


    // Marked as "Fixed"Update because we are using it to mess with physics
    void Update()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (rb.position.y > 2f)
        {
            // this makes player comes down on ground faster when jumped by applying a downward
            // force when in air (more than 2 units above ground)
            rb.AddForce(0, -forwardForce / 2 * Time.deltaTime, 0);
        }

        if (Input.GetKeyDown(KeyCode.W) && isPlayerOnGround())  // only jump when on ground
            MakePlayerJump();

        if (Input.GetKeyDown(KeyCode.D)) //Input.GetKey("d"))
            MovePlayerRight();

        if (Input.GetKeyDown(KeyCode.A))
            MovePlayerLeft();

    }

    private bool isPlayerOnGround()
    {
        return rb.position.y <= 0.76f;
    }

    private void MakePlayerJump()
    {
        rb.AddForce(0, forwardForce * 10 * Time.deltaTime, 0);

    }

    private void MovePlayerRight()
    {
        if (rb.position.x == middleXPosition)
            rb.MovePosition(new Vector3(maxRightXPosition, rb.position.y, rb.position.z));
        else if (rb.position.x == maxLeftXPosition)
            rb.MovePosition(new Vector3(middleXPosition, rb.position.y, rb.position.z));
        else if (rb.position.x == maxRightXPosition)
            rb.MovePosition(new Vector3(maxLeftXPosition, rb.position.y, rb.position.z));
    }

    private void MovePlayerLeft()
    {
        if (rb.position.x == maxRightXPosition)
            rb.MovePosition(new Vector3(middleXPosition, rb.position.y, rb.position.z));
        else if (rb.position.x == middleXPosition)
            rb.MovePosition(new Vector3(maxLeftXPosition, rb.position.y, rb.position.z));
        else if (rb.position.x == maxLeftXPosition)
            rb.MovePosition(new Vector3(maxRightXPosition, rb.position.y, rb.position.z));
    }

    private enum DraggedDirection
    {
        Up,
        Down,
        Right,
        Left
    }

    private DraggedDirection GetDragDirection(Vector3 dragVector)
    {
        float positiveX = Mathf.Abs(dragVector.x);
        float positiveY = Mathf.Abs(dragVector.y);
        DraggedDirection draggedDir;
        if (positiveX > positiveY)
            draggedDir = (dragVector.x > 0) ? DraggedDirection.Right : DraggedDirection.Left;
        else
            draggedDir = (dragVector.y > 0) ? DraggedDirection.Up : DraggedDirection.Down;
        return draggedDir;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Vector3 dragVectorDirection = (eventData.position - eventData.pressPosition).normalized;
        DraggedDirection direction = GetDragDirection(dragVectorDirection);

        if (direction == DraggedDirection.Left)
            MovePlayerLeft();

        if (direction == DraggedDirection.Right)
            MovePlayerRight();

        if (direction == DraggedDirection.Up && isPlayerOnGround())
            MakePlayerJump();
    }
}

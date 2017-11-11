using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeControl : MonoBehaviour
{
    private bool tap;
    private bool swipeLeft;
    private bool swipeRight;
    private bool swipeDown;
    private bool swipeUp;
    private bool isDragging;
    private float deadZoneRadius = 25f;

    private Vector2 startTouch;
    private Vector2 swipeDelta;

    public bool SwipeLeft
    {
        get
        {
            return swipeLeft;
        }

    }

    public bool SwipeRight
    {
        get
        {
            return swipeRight;
        }

    }

    public bool SwipeDown
    {
        get
        {
            return swipeDown;
        }
    }

    public bool SwipeUp
    {
        get
        {
            return swipeUp;
        }
    }

    public Vector2 SwipeDelta
    {
        get
        {
            return swipeDelta;
        }
    }

    private void Update()
    {
        tap = swipeLeft = swipeRight = swipeDown = swipeUp = false;


        #region Standalone Inputs
        if (Input.GetMouseButtonDown(0))
        {
            //tap = true;
            isDragging = true;
            startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            //tap = false;
            isDragging = false;
            Reset();
        }
        #endregion

        #region Mobile Inputs
        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                tap = true;
                isDragging = true;
                startTouch = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                isDragging = false;
                Reset();
            }
        }

        #endregion

        // calculating the distance
        swipeDelta = Vector2.zero;
        if (isDragging)
        {
            if (Input.touches.Length > 0)
                swipeDelta = Input.touches[0].position - startTouch;
            else if (Input.GetMouseButton(0))
            {
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
            }
        }

        // was dead zone crossed?
        if(swipeDelta.magnitude > deadZoneRadius)
        {
            float x = swipeDelta.x;
            float y = swipeDelta.y;

            if(Mathf.Abs(x) > Mathf.Abs(y))
            {
                // left or right
                if (x < 0)
                    swipeLeft = true;
                else
                    swipeRight = true;
            }
            else
            {
                // Up or down
                if (y < 0)
                    swipeDown = true;
                else
                    swipeUp = true;
            }


            Reset();
        }
    }

    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDragging = false;
    }

}

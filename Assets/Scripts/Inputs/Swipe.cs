using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    private bool swipeRight, swipeLeft, swipeUp, swipeDown;
    private bool isDragging = false;
    private Vector2 startTouch, swipeDelta;


    private void Update()
    {
        swipeLeft = swipeRight = swipeUp = swipeDown = false;


        
        #region Mobile Inputs

        if (Input.touches.Length != 0)
        {          

            if (Input.touches[0].phase == TouchPhase.Began)
            {
                isDragging = true;
                startTouch = Input.touches[0].position;

            }
            else if(Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                Reset();
            }
            
        }
        #endregion

        //Calculate the distance between start of touch to end
        swipeDelta = Vector2.zero;

        if(isDragging)
        {
            if(Input.touches.Length > 0)
            {
                swipeDelta = Input.touches[0].position - startTouch;
            }
            else if (Input.GetMouseButton(0))
            {
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
            }
        }

        //Check if touch is outside deadzone
        if (swipeDelta.magnitude > 150)
        {
            //Check direction
            float x = swipeDelta.x;
            float y = swipeDelta.y;

            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                //Left & Right
                if (x < 0)
                    swipeLeft = true;
                else
                    swipeRight = true;
            }
            else
            {
                //Up & Down
                if (y < 0)
                    swipeDown = true;
                else
                    swipeUp = true;
            }

     
            if (swipeRight)
            {
                Debug.Log("swiped right");
            }
            if (swipeLeft)
            {
                Debug.Log("swiped left");
            }
            if (swipeUp)
            {
                Debug.Log("swiped up");
            }
            if (swipeDown)
            {
                Debug.Log("swiped down");
            }

            Reset();
        }
       
    }

    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDragging = false;
    }

    public Vector2 SwipeDelta { get { return swipeDelta; } }
    public bool Left { get { return swipeLeft; } }
    public bool Right { get { return swipeRight; } }
    public bool Up { get { return swipeUp; } }
    public bool Down { get { return swipeDown; } }
}

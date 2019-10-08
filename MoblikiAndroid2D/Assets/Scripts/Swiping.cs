using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swiping : MonoBehaviour
{
    public static bool swipingDown;
    public static bool swipingUp;
    public static bool swipingLeft;
    public static bool swipingRight;

    private bool swiping = false;
    private bool eventSent = false;
    private Vector2 lastPosition;

    void Update()
    {
        if (Input.touchCount == 0)
            return;

        if (Input.GetTouch(0).deltaPosition.sqrMagnitude != 0)
        {
            if (swiping == false)
            {
                swiping = true;
                lastPosition = Input.GetTouch(0).position;
                return;
            }
            else
            {
                if (!eventSent)
                {
                    Vector2 direction = Input.GetTouch(0).position - lastPosition;

                    if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
                    {
                        if (direction.x > 0)
                        {
                            swipingRight = true;
                            swipingLeft = false;
                        }
                        else
                        {
                            swipingLeft = true;
                            swipingRight = false;
                        }
                        swipingDown = false;
                        swipingUp = false;
                    }
                    else
                    {
                        if (direction.y > 0)
                        {
                            swipingUp = true;
                            swipingDown = false;
                        }
                        else
                        {
                            swipingDown = true;
                            swipingUp = false;
                        }
                        swipingLeft = false;
                        swipingRight = false;
                    }

                    eventSent = true;
                }
            }
        }
        else
        {
            swiping = false;
            eventSent = false;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Splashy
{
   public class SwipeDetector : MonoBehaviour
{
    public bool detectSwipeOnlyAfterRelease = false;
    public float forceMultiplayer = 1f;
    public float speed = 0f;
    public float smoothTime = 0.1f;

    void Update()
    {

        foreach (Touch touch in Input.touches)
        {
            
            //Detects Swipe while finger is still moving
            if (touch.phase == TouchPhase.Moved)
            {
                if (!detectSwipeOnlyAfterRelease)
                {
                    Vector3 touchDeltaPosition = touch.deltaPosition;
                    speed = touchDeltaPosition.magnitude * forceMultiplayer;
                    Vector3 movement = touchDeltaPosition.normalized * speed * Time.deltaTime;
                    Vector3 newPosition = transform.position + movement;
                    newPosition.y = transform.position.y;
                    transform.position = Vector3.Lerp(transform.position, newPosition, smoothTime);
                    
                }
            }
            
        }
    }

}
}

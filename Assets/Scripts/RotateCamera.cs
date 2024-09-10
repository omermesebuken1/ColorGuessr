using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RotateCamera : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private Transform target;
    [SerializeField] private float distanceToTarget;
    [SerializeField] private float heightDiff;
    private bool touchEnabled;

    Touch touch;


    private Vector3 previousPosition;

    private void Start() 
    {

        cam.transform.position = target.position;
        cam.transform.LookAt(target);
        cam.transform.Translate(new Vector3(0, heightDiff, -distanceToTarget));
        
        
        
    }

    private void Update()
    {
        UITouchChecker();
        
         if (Input.touchCount > 0 && touchEnabled)
        {
            touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                
                case TouchPhase.Began: 
                previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
                break;

                case TouchPhase.Moved: 
                Vector3 newPosition = cam.ScreenToViewportPoint(Input.mousePosition);
                Vector3 direction = previousPosition - newPosition;

                float rotationAroundYAxis = -direction.x * 180; // camera moves horizontally
                float rotationAroundXAxis = direction.y * 180; // camera moves vertically

                cam.transform.position = target.position;
            
                cam.transform.Rotate(new Vector3(1, 0, 0), rotationAroundXAxis);
                cam.transform.Rotate(new Vector3(0, 1, 0), rotationAroundYAxis, Space.World);
            
                cam.transform.Translate(new Vector3(0, heightDiff, -distanceToTarget));

                previousPosition = newPosition;

                break;

                case TouchPhase.Ended: 
                previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
                break;
                
            }
            
        }

    }

    private void UITouchChecker()
    {
        //Exit if touch is over UI element.
        foreach (Touch touch in Input.touches)
        {
            int id = touch.fingerId;

            if (EventSystem.current.IsPointerOverGameObject(id))
            {
                    touchEnabled = false;
                return;
            }
            
            else
            {
                touchEnabled = true;
                
            }
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraMotor : MonoBehaviour
{
    private Vector2 worldStartPoint;

    private Transform selfTransform;

    private bool activeTap;

    private float resistanceDistance = 0.1f, cameraBounds = 5f;
    private float inputMultiplier = 5f;

    private float zoomValue = 5, minZoom = 2, maxZoom = 5, camOffset = 4f;
    private float swipeZoomSpeed = 5f;

    void Start ()
    {
        selfTransform = transform;
	}
	
    void Update()
    {

#if (UNITY_ANDROID && !UNITY_EDITOR) || (UNITY_IPHONE && !UNITY_EDITOR)
        if (Input.touchCount == 1 && !EventSystem.current.IsPointerOverGameObject())
        {
            Touch currentTouch = Input.GetTouch(0);

            if (currentTouch.phase == TouchPhase.Began)
            {
                worldStartPoint = (Vector2)currentTouch.position;
            }

            if (currentTouch.phase == TouchPhase.Moved)
            {
                Vector2 worldDelta = currentTouch.position - worldStartPoint;

                MoveCamera(worldDelta);
            }
        }

        if (Input.touchCount == 2)
        {

            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);


            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;


            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            // Find the difference in the distances between each frame.
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            zoomValue = Mathf.Clamp(zoomValue + deltaMagnitudeDiff * swipeZoomSpeed, minZoom, maxZoom);

            Vector3 sp = selfTransform.position;

            sp.y = Mathf.Lerp(sp.y, zoomValue, maxZoom * Time.deltaTime);

            selfTransform.position = sp;
        }
#endif

#if UNITY_EDITOR

        if (Input.mouseScrollDelta.y != 0)
        {
            zoomValue = Mathf.Clamp(zoomValue + Input.mouseScrollDelta.y, minZoom, maxZoom);

            Vector3 sp = selfTransform.position;

            sp.y = Mathf.Lerp(sp.y, zoomValue, maxZoom * Time.deltaTime);

            selfTransform.position = sp;
        }

        if (Input.GetMouseButtonDown(0))
        {
            activeTap = true;
            worldStartPoint = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
            activeTap = false;

        Vector2 worldDelta = (Vector2)Input.mousePosition - worldStartPoint;

        if (activeTap && worldDelta.magnitude > resistanceDistance && !EventSystem.current.IsPointerOverGameObject())
        {
            MoveCamera(worldDelta);
        }
#endif


    }

    private void MoveCamera(Vector3 _pos)
    {
        _pos /= Screen.width / inputMultiplier;

        _pos.x = Mathf.Clamp(_pos.x, -cameraBounds, cameraBounds);
        _pos.z = Mathf.Clamp(_pos.z, -cameraBounds, cameraBounds);

        selfTransform.Translate(_pos.y, 0, -_pos.x);

        Vector3 sp = selfTransform.position;

        selfTransform.position = new Vector3(Mathf.Clamp(sp.x, -(cameraBounds - camOffset), cameraBounds + camOffset), zoomValue, Mathf.Clamp(sp.z, -cameraBounds + 2, cameraBounds + 2));
    }

    // convert screen point to world point
    private Vector2 GetWorldPoint(Vector2 screenPoint)
    {
        RaycastHit hit;
        Physics.Raycast(Camera.main.ScreenPointToRay(screenPoint), out hit);
        return hit.point;
    }
}



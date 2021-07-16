using UnityEngine;
using System.Collections;
using System;

public class SimpleGazeCursor : MonoBehaviour {
    public Camera viewCamera;
    public GameObject c_Default, c_Red, c_Blue, c_Orange, c_Yellow, c_Purple, c_Green;
    public float maxCursorDistance = 30;

    private GameObject cursorInstance;
    private int x;

    // Use this for initialization
    private void Start () {
        x = PlayerPrefs.GetInt("VR Zombie Shooter Defender - SelectedColor", 0);
        switch (x)
        {
            case 1:
                cursorInstance = Instantiate(c_Red);
                break;
            case 2:
                cursorInstance = Instantiate(c_Blue);
                break;
            case 3:
                cursorInstance = Instantiate(c_Orange);
                break;
            case 4:
                cursorInstance = Instantiate(c_Yellow);
                break;
            case 5:
                cursorInstance = Instantiate(c_Purple);
                break;
            case 6:
                cursorInstance = Instantiate(c_Green);
                break;
            default:
                cursorInstance = Instantiate(c_Default);
                break;
        }
	}

    // Update is called once per frame
    private void Update () {
        UpdateCursor();
	}

    /// <summary>
    /// Updates the cursor based on what the camera is pointed at.
    /// </summary>
    private void UpdateCursor()
    {
        // Create a gaze ray pointing forward from the camera
        Ray ray = new Ray(viewCamera.transform.position, viewCamera.transform.rotation * Vector3.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            // If the ray hits something, set the position to the hit point and rotate based on the normal vector of the hit
            cursorInstance.transform.position = hit.point;
            cursorInstance.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
        }
        else
        {
            // If the ray doesn't hit anything, set the position to the maxCursorDistance and rotate to point away from the camera
            cursorInstance.transform.position = ray.origin + ray.direction.normalized * maxCursorDistance;
            cursorInstance.transform.rotation = Quaternion.FromToRotation(Vector3.up, -ray.direction);
        }
    }
}

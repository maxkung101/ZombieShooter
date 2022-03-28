using UnityEngine;
using System.Collections;
using System;

public class SimpleGazeCursor : MonoBehaviour {
    public Camera viewCamera;
    public GameObject c_Default, c_Red, c_Blue, c_Orange, c_Yellow, c_Purple, c_Green;
    public float maxCursorDistance = 30;
    public AudioSource eSystem;

    private GameObject cursorInstance;
    private int x;

    // Use this for initialization
    private void Start () {
        x = PlayerPrefs.GetInt("VR Zombie Shooter Defender - SelectedColor", 0);
        switch (x)
        {
            case 1:
                cursorInstance = Instantiate(c_Red) as GameObject;
                break;
            case 2:
                cursorInstance = Instantiate(c_Blue) as GameObject;
                break;
            case 3:
                cursorInstance = Instantiate(c_Orange) as GameObject;
                break;
            case 4:
                cursorInstance = Instantiate(c_Yellow) as GameObject;
                break;
            case 5:
                cursorInstance = Instantiate(c_Purple) as GameObject;
                break;
            case 6:
                cursorInstance = Instantiate(c_Green) as GameObject;
                break;
            default:
                cursorInstance = Instantiate(c_Default) as GameObject;
                break;
        }
	}

    // Update is called once per frame
    private void Update () {
        UpdateCursor();
	}

    // Updates the cursor based on what the camera is pointed at.
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

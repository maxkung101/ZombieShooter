using System.Collections;
using UnityEngine;

// Sends messages to gazed GameObject.
public class CameraPointer : MonoBehaviour
{
    private const float _maxDistance = 100;
    private GameObject _gazedAtObject = null;

    // Update is called once per frame.
    public void Update()
    {
        // Casts ray towards camera's forward direction, to detect if a GameObject is being gazed
        // at.
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, _maxDistance))
        {
            // GameObject detected in front of the camera.
            if (_gazedAtObject != hit.transform.gameObject)
            {
                _gazedAtObject?.SendMessage("OnPointerExit");
                _gazedAtObject = hit.transform.gameObject;
                _gazedAtObject.SendMessage("OnPointerEnter");
            }
        }
        else
        {
            _gazedAtObject?.SendMessage("OnPointerExit");
            _gazedAtObject = null;
        }
    }
}

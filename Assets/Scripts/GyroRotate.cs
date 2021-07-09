using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroRotate : MonoBehaviour
{
    private Gyroscope gyro;

    // Start is called before the first frame update
    private void Start()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
        }
        else
        {
            Debug.Log("Device does not support gyroscope.");
        }
    }

    // Update is called once per frame
    private void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.Rotate(-Input.gyro.rotationRateUnbiased.x, -Input.gyro.rotationRateUnbiased.y, 0);
    }

    private void OnGUI()
    {
        if (SystemInfo.supportsGyroscope)
        {
            GUILayout.Label("Gyroscope attitude : " + gyro.attitude);
        }
    }
}

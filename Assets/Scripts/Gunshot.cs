using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Gunshot : MonoBehaviour
{
    public AudioSource eSystem;

    private float volume;

    // Start is called before the first frame update
    private void Start()
    {
        volume = 0f;
    }

    // Update is called once per frame
    private void Update()
    {
        volume = MicInput.MicLoudness;
        if (volume >= 0.01)
        {
            eSystem.Play();
        }
    }
}

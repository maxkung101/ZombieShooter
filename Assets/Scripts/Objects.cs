using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class Objects : MonoBehaviour
{
    protected bool gvrStatus, isEnabled;
    protected float volume;

    // Start is called before the first frame update
    protected void Start()
    {
        gvrStatus = false;
        isEnabled = true;
        volume = 0f;

        Init();
    }

    protected void Update()
    {
        volume = MicInput.MicLoudness;
        if (volume >= 0.1)
        {
            ObjectEvent();
        }

        ObjectMove();
    }

    public bool GetButtonStats()
    {
        return isEnabled;
    }

    public void DisableButton()
    {
        isEnabled = false;
    }

    public void EnableButton()
    {
        isEnabled = true;
    }

    // This method is called by the Main Camera when it starts gazing at this GameObject.
    protected void OnPointerEnter()
    {
        if (isEnabled)
        {
            gvrStatus = true;
        }
    }

    // This method is called by the Main Camera when it stops gazing at this GameObject.
    protected void OnPointerExit()
    {
        if (isEnabled)
        {
            gvrStatus = false;
        }
    }

    protected void OnApplicationQuit()
    {
        
    }

    public abstract void Init();
    public abstract void ObjectEvent();
    public abstract void ObjectMove();
}

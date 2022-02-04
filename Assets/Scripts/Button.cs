using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : Objects
{
    public UnityEvent GVRClick;
    public AudioSource eSystem;

    // Use this for initialization
    public override void Init()
    {

    }

    public override void LookAtIt()
    {
        eSystem.volume = 0f;
    }

    public override void StopLooking()
    {
        eSystem.volume = 1f;
    }

    public override void ObjectMove()
    {

    }

    public override void ObjectEvent()
    {
        if (gvrStatus)
        {
            GVRClick.Invoke();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : Objects
{
    public UnityEvent GVRClick;

    // Use this for initialization
    public override void Init()
    {

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

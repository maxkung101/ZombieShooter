using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyView : MonoBehaviour
{
    public Material daytime, sunset, nighttime, dawn;

    private DateTime moment;
    private int index, hour;

    // Start is called before the first frame update
    private void Start()
    {
        moment = DateTime.Now;
        hour = moment.Hour;
        index = PlayerPrefs.GetInt("VR Zombie Shooter Defender - ThemeSelected", 1);
        switch (index)
        {
            case 0:
                RenderSettings.skybox = dawn;
                break;
            case 1:
                RenderSettings.skybox = daytime;
                break;
            case 2:
                RenderSettings.skybox = sunset;
                break;
            case 3:
                RenderSettings.skybox = nighttime;
                break;
            default:
                if (hour >= 9 && hour < 17)
                {
                    RenderSettings.skybox = daytime;
                }
                else if (hour >= 17 && hour < 20)
                {
                    RenderSettings.skybox = sunset;
                }
                else if (hour >= 20 || hour < 5)
                {
                    RenderSettings.skybox = nighttime;
                }
                else
                {
                    RenderSettings.skybox = dawn;
                }
                break;
        }
    }
}

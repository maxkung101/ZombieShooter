using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageChange : MonoBehaviour
{
    public int index;

    public void ChangeLanguage()
    {
        PlayerPrefs.SetInt("VR Zombie Shooter Defender - SelectedLanguage", index);
    }
}

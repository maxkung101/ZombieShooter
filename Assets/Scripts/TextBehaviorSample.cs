using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextBehaviorSample : MonoBehaviour
{
    public string[] score, health, quit;
    public TMP_Text scoreTMP, healthTMP, quitTMP;

    private int id;

    // Start is called before the first frame update
    private void Start()
    {
        id = PlayerPrefs.GetInt("VR Zombie Shooter Defender - SelectedLanguage", 0);

        scoreTMP.text = score[id];
        healthTMP.text = health[id];
        quitTMP.text = quit[id];
    }
}

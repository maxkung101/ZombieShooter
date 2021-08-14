using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBehaviourMenu : MonoBehaviour
{
    public string[] lookAround, details, highScore, settings, theme, inGameMusic, pointer, language, resetScore, on, off, dawn, day, sunset, night, auto, play;

    [TextArea]
    public string[] instructions, credits;

    private int id;

    // Start is called before the first frame update
    private void Start()
    {
        id = PlayerPrefs.GetInt("VR Zombie Shooter Defender - SelectedLanguage", 0);
    }
}

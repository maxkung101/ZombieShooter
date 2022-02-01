using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextBehaviourMenu : MonoBehaviour
{
    public string[] lookAround, details, highScore, settings, theme, inGameMusic, pointer, language, resetScore, on, off, dawn, day, sunset, night, auto, play;

    [TextArea]
    public string[] instructions, credits;

    public TMP_Text lookAroundTMP, detailsTMP, highScoreTMP, settingsTMP, themeTMP, inGameMusicTMP, pointerTMP, languageTMP, resetScoreTMP, dawnTMP, dayTMP, sunsetTMP, nightTMP, autoTMP, playTMP;

    private int id;

    // Start is called before the first frame update
    private void Start()
    {
        id = PlayerPrefs.GetInt("VR Zombie Shooter Defender - SelectedLanguage", 0);

        lookAroundTMP.text = lookAround[id];
        detailsTMP.text = details[id];
        highScoreTMP.text = highScore[id];
        settingsTMP.text = settings[id];
        themeTMP.text = theme[id];
        inGameMusicTMP.text = inGameMusic[id];
        pointerTMP.text = pointer[id];
        languageTMP.text = language[id];
        resetScoreTMP.text = resetScore[id];
        dawnTMP.text = dawn[id];
        dayTMP.text = day[id];
        sunsetTMP.text = sunset[id];
        nightTMP.text = night[id];
        autoTMP.text = auto[id];
        playTMP.text = play[id];
    }
}

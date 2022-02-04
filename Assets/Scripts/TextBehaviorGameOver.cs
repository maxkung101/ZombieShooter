using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextBehaviorGameOver : MonoBehaviour
{
    public string[] gameOver, score, play, home, newScore;
    public TMP_Text gameOverTMP, scoreTMP, playTMP, homeTMP, newScoreTMP;

    private int id;

    // Start is called before the first frame update
    private void Start()
    {
        id = PlayerPrefs.GetInt("VR Zombie Shooter Defender - SelectedLanguage", 0);

        gameOverTMP.text = gameOver[id];
        scoreTMP.text = score[id];
        playTMP.text = play[id];
        homeTMP.text = home[id];
        newScoreTMP.text = newScore[id];
    }
}
